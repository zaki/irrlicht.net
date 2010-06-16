//Thread for this scene node :
//http://irrlichtnetcp.sourceforge.net/phpBB2/viewtopic.php?p=47
using System;
using IrrlichtNET.Inheritable;

namespace IrrlichtNET.Extensions
{
    internal class IrrQuad
    {
        public Vertex3D[] verts = { new Vertex3D(), new Vertex3D(), new Vertex3D(), new Vertex3D() };// = new Vertex3D[4];
    };

    public class BeamNode : ISceneNode
    {
        // The beam material.
        private Material Material = new Material();

        // Start/End Points
        private Vector3D vStart;
        private Vector3D vEnd;

        // Bounding Box
        private Box3D Box = new Box3D();

        // Size of the beam
        private float flScale;

        // Beam color
        private Color beamColor;

        // Scene Manager
        SceneManager smgr;

        // Video Driver
        VideoDriver driver;

        ushort[] indices = { 0, 2, 3, 2, 1, 3, 1, 0, 3, 2, 0, 1 };
        void DrawQuad(IrrQuad quad)
        {
            driver.SetMaterial(Material);
            driver.DrawIndexedTriangleList(quad.verts, 4, indices, 4);
        }

        // Thanks to whoever wrote this little function :)
        Vector3D getTargetAngle(Vector3D v, Vector3D r)
        {
            //v -current node position
            //r -target node position

            Vector3D angle = new Vector3D();
            float x = r.X - v.X;
            float y = r.Y - v.Y;
            float z = r.Z - v.Z;

            //angle in X-Z plane
            angle.Y = (float)Math.Atan2(x, z);
            angle.Y *= 180 / NewMath.PI; //converting from rad to degrees

            //just making sure angle is somewhere between 0-360 degrees
            if (angle.Y < 0) angle.Y += 360;
            if (angle.Y >= 360) angle.Y -= 360;

            //angle in Y-Z plane while Z and X axes are already rotated around Y
            float z1 = (float)Math.Sqrt(x * x + z * z);

            angle.X = (float)Math.Atan2(z1, y);
            angle.X *= 180 / NewMath.PI; //converting from rad to degrees
            angle.X -= 90;

            //just making sure angle is somewhere between 0-360 degrees
            if (angle.X < 0) angle.X += 360;
            if (angle.X >= 360) angle.X -= 360;

            return angle;
        }


        public BeamNode(SceneNode parent, SceneManager mgr, int id, string szBeam)
            : base(parent, mgr, id)
        {
            smgr = mgr;
            driver = smgr.VideoDriver;
            Material = new Material();
            // Setup the beam material
            Material.Wireframe = false;
            Material.Lighting = false;
            Material.MaterialType = MaterialType.TransparentAlphaChannel;
            Material.Texture1 = mgr.VideoDriver.GetTexture(szBeam);

            // Default to 32 units for the scale
            flScale = 32.0f;

            // Default to white
            beamColor.Set(255, 255, 255, 255);
        }

        public override void Render()
        {
            driver.SetTransform(TransformationState.World, AbsoluteTransformation);
            // Figure out quads based on start/end points.
            Matrix4 m = new Matrix4();
            m.RotationDegrees = getTargetAngle(vStart, vEnd);
            Vector3D vUp = new Vector3D(0, 1, 0);
            Vector3D vRight = new Vector3D(-1, 0, 0);
            m.TransformVect(ref vRight);
            m.TransformVect(ref vUp);

            // Draw the first cross
            IrrQuad beam = new IrrQuad();
            beam.verts[0] = new Vertex3D(vStart + vUp * flScale, new Vector3D(1, 1, 0), beamColor, new Vector2D(0, 1));
            beam.verts[1] = new Vertex3D(vStart + vUp * -flScale, new Vector3D(1, 0, 0), beamColor, new Vector2D(1, 1));
            beam.verts[2] = new Vertex3D(vEnd + vUp * -flScale, new Vector3D(0, 1, 1), beamColor, new Vector2D(1, 0));
            beam.verts[3] = new Vertex3D(vEnd + vUp * flScale, new Vector3D(0, 0, 1), beamColor, new Vector2D(0, 0));
            DrawQuad(beam);

            // Draw the second cross.
            beam.verts[0] = new Vertex3D(vStart + vRight * flScale, new Vector3D(1, 1, 0), beamColor, new Vector2D(0, 1));
            beam.verts[1] = new Vertex3D(vStart + vRight * -flScale, new Vector3D(1, 0, 0), beamColor, new Vector2D(1, 1));
            beam.verts[2] = new Vertex3D(vEnd + vRight * -flScale, new Vector3D(0, 1, 1), beamColor, new Vector2D(1, 0));
            beam.verts[3] = new Vertex3D(vEnd + vRight * flScale, new Vector3D(0, 0, 1), beamColor, new Vector2D(0, 0));
            DrawQuad(beam);

            if (DebugDataVisible == DebugSceneType.BoundingBox)
                driver.Draw3DBox(BoundingBox, Color.White);
        }

        public override void OnRegisterSceneNode()
        {
            if (Visible)
            {
                smgr.RegisterNodeForRendering(this, SceneNodeRenderPass.Solid);
            }
            base.OnRegisterSceneNode();
        }


        public override Box3D BoundingBox
        {
            get
            {
                return Box;
            }
        }

        public override uint MaterialCount
        {
            get
            {
                return 1;
            }
        }
        public override Material GetMaterial(int i)
        {
            return Material;
        }

        public Vector3D StartPoint
        {
            get { return vStart; }
            set { vStart = value; RecalculateBoundingBox(); }
        }

        public Vector3D EndPoint
        {
            get { return vEnd; }
            set { vEnd = value; RecalculateBoundingBox(); }
        }

        public void RecalculateBoundingBox()
        {
            Matrix4 m = new Matrix4();
            m.RotationDegrees = getTargetAngle(vStart, vEnd);
            Vector3D vUp = new Vector3D(0, 1, 0);
            Vector3D vRight = new Vector3D(-1, 0, 0);
            m.TransformVect(ref vRight);
            m.TransformVect(ref vUp);
            Box.MinEdge = (vStart + vUp * flScale);
            Box.MaxEdge = (vEnd + vRight * -flScale);
            Box.AddInternalPoint(vStart + vUp * flScale);
            Box.AddInternalPoint(vStart + vUp * -flScale);
            Box.AddInternalPoint(vEnd + vUp * -flScale);
            Box.AddInternalPoint(vEnd + vUp * flScale);

            Box.AddInternalPoint(vStart + vRight * flScale);
            Box.AddInternalPoint(vStart + vRight * -flScale);
            Box.AddInternalPoint(vEnd + vRight * -flScale);
            Box.AddInternalPoint(vEnd + vRight * flScale);
        }

        public float BeamScale
        {
            get { return flScale; }
            set { flScale = value; }
        }

        public Color BeamColor
        {
            get { return beamColor; }
            set { beamColor = value; }
        }
    }
}
