using System;
using System.Text;
using System.Collections;
using System.IO;
using IrrlichtNET;
using IrrlichtNET.Inheritable;

namespace IrrlichtNET.Extensions
{
    public class GrassPatchSceneNode : ISceneNode
    {
        private const int GRASS_PATCH_SIZE = 1024;
        public GrassPatchSceneNode(SceneNode parent, SceneManager mgr, int id, bool createIfEmpty,
                                   Vector3D gridPos, string filepath, Texture heightMap, Texture colourMap,
                                   Texture grassMap, SceneNode terrain, WindGenerator wind)
            : base(parent, mgr, id)
        {
            DrawDistance = GRASS_PATCH_SIZE * 1.5f;
            MaxDensity = 800;
            TerrainHeightMap = heightMap;
            TerrainColourMap = colourMap;
            TerrainGrassMap = grassMap;
            Terrain = terrain;
            WindGen = wind;
            lastwindtime = 0;
            lastdrawcount = 0;
            redrawnextloop = true;
            MaxFPS = 0;
            _mgr = mgr;
            WindRes = 5;

            filename = string.Format("{0}/{1}.{2}.grass", filepath, gridpos.X, gridpos.Z);
            gridpos = gridPos;
            Position = new Vector3D(gridpos.X * GRASS_PATCH_SIZE, 0f,
                                    gridpos.Z * GRASS_PATCH_SIZE);

            ImageCount = new Dimension2D(4, 2);

            if (!Load())
                Create(createIfEmpty);
        }

        Material _material = new Material();
        public override Material GetMaterial(int i)
        {
            return _material;
        }

        public override uint MaterialCount
        {
            get { return 1; }
        }
        public override void OnRegisterSceneNode()
        {
            if (Visible)
            {
                if (Particles.Length > 0)
                {
                    Vector3D campos = _mgr.ActiveCamera.Position;

                    if ((BoundingBox.Center + Position).DistanceFromSQ(campos) <
                        NewMath.Sqr(DrawDistance * 1.5f))
                    {
                        _mgr.RegisterNodeForRendering(this);
                        base.OnRegisterSceneNode();
                    }
                }
            }
        }

        public override void OnAnimate(uint timeMs)
        {
            if (lastwindtime < (timeMs - MaxFPS))
            {
                lastwindtime = timeMs;
                redrawnextloop = true;

                double dist = (BoundingBox.Center + Position).DistanceFrom(_mgr.ActiveCamera.Position) + 1;

                if (WindGen != null && dist < DrawDistance * 1.5f)
                {
                    for (uint x = 0; x < WindRes + 1; x++)
                        for (uint z = 0; z < WindRes + 1; z++)
                            WindGrid[x * WindRes + z] =
                                WindGen.Wind(
                                    new Vector3D((gridpos.X * GRASS_PATCH_SIZE) + x * (GRASS_PATCH_SIZE / WindRes),
                                                 0f,
                                                 (gridpos.X * GRASS_PATCH_SIZE) + x * (GRASS_PATCH_SIZE / WindRes)),
                                    timeMs);
                }
                else
                {
                    redrawnextloop = false;
                }
                base.OnAnimate(timeMs);
            }
        }

        public override void Render()
        {
            VideoDriver driver = _mgr.VideoDriver;
            CameraSceneNode camera = _mgr.ActiveCamera;

            if (camera == null || driver == null)
                return;

            if (!redrawnextloop)
            {
                driver.SetTransform(TransformationState.World, AbsoluteTransformation);
                driver.SetMaterial(_material);
                driver.DrawIndexedTriangleList(Vertices, lastdrawcount * 4,
                                               Indices, lastdrawcount * 4);
            }
            else
            {
                ReallocateBuffers();

                Vector3D campos = camera.AbsolutePosition;
                Box3D cbox = camera.ViewFrustum.BoundingBox;

                Vector3D pos = Position;
                int drawcount = 0;
                int max = (Particles.Length < MaxDensity) ? Particles.Length : MaxDensity;

                double d = pos.DistanceFrom(campos) / GRASS_PATCH_SIZE;
                if (d > 1.0)
                    max = (int)(((double)max) / d);

                //Matrix4 m = new Matrix4();

                for (int i = 0; i < max; i++)
                {
                    int idx = drawcount * 4;

                    GrassParticle particle = Particles[i];
                    Vector3D gpos = particle.pos + pos;

                    double dist = campos.DistanceFromSQ(gpos);
                    if (dist > NewMath.Sqr(DrawDistance))
                        continue;

                    if (!cbox.IsPointInside(gpos))
                        continue;

                    if (dist > NewMath.Sqr(DrawDistance * 0.5))
                    {
                        if (particle.sprite.Height == 0)
                        {
                            float i1 = ((float)i) / ((float)max);
                            float i2 = ((float)(dist / DrawDistance)) / 2f;

                            if (i1 < i2)
                                continue;
                        }
                    }

                    int igridsize = GRASS_PATCH_SIZE / (int)WindRes;
                    int ihalfres = (int)WindRes / 2;

                    int xgrid = (int)(particle.pos.X / (igridsize) + ihalfres);
                    int zgrid = (int)(particle.pos.Z / (igridsize) + ihalfres);

                    float xnext = particle.pos.X / (GRASS_PATCH_SIZE / WindRes) + (WindRes / 2f) - xgrid;
                    float znext = particle.pos.Z / (GRASS_PATCH_SIZE / WindRes) + (WindRes / 2f) - zgrid;

                    Vector2D wind1 = WindGrid[xgrid * WindRes + zgrid];
                    Vector2D wind2 = WindGrid[(xgrid + 1) * WindRes + zgrid];
                    Vector2D wind3 = WindGrid[xgrid * (WindRes + 1) + zgrid];
                    Vector2D wind4 = WindGrid[(xgrid + 1) * (WindRes + 1) + zgrid];
                    Vector2D wind2d = wind1 * (1.0f - xnext) * (1.0f - znext) +
                                      wind2 * xnext * (1.0f - znext) +
                                      wind3 * (1.0f - xnext) * znext +
                                      wind4 * xnext * znext;

                    wind2d *= particle.flex;
                    Vector3D wind = new Vector3D(wind2d.X, 0f, wind2d.Y);

                    Color gcol = new Color(particle.color.A,
                                           (int)(particle.color.R * 0.8f),
                                           (int)(particle.color.G * 0.8f),
                                           (int)(particle.color.B * 0.8f));

                    Vertices[0 + idx].Position = particle.points[0];
                    Vertices[0 + idx].Color = gcol;

                    Vertices[1 + idx].Position = particle.points[1] + wind;
                    Vertices[1 + idx].Color = particle.color;

                    Vertices[2 + idx].Position = particle.points[2] + wind;
                    Vertices[2 + idx].Color = particle.color;

                    Vertices[3 + idx].Position = particle.points[3];
                    Vertices[3 + idx].Color = gcol;

                    int arrpos = (_imagecount.Width * particle.sprite.Height) + particle.sprite.Width;
                    Vertices[0 + idx].TCoords = new Vector2D(v1[arrpos], v2[arrpos]);
                    Vertices[1 + idx].TCoords = new Vector2D(v1[arrpos], v3[arrpos]);
                    Vertices[2 + idx].TCoords = new Vector2D(v4[arrpos], v3[arrpos]);
                    Vertices[3 + idx].TCoords = new Vector2D(v4[arrpos], v2[arrpos]);

                    drawcount++;
                }
                driver.SetTransform(TransformationState.World, AbsoluteTransformation);
                driver.SetMaterial(_material);

                driver.DrawIndexedTriangleList(Vertices, drawcount * 4,
                                               Indices, drawcount * 4);
                lastdrawcount = drawcount;
            }

            if (DebugDataVisible == DebugSceneType.BoundingBox)
            {
                driver.SetTransform(TransformationState.World, AbsoluteTransformation);
                Material m = new Material();
                m.Lighting = false;
                driver.SetMaterial(m);
                driver.Draw3DBox(BoundingBox, Color.From(0, 255, 255, 255));
                Box3D b2 = new Box3D();

                b2.AddInternalPoint(BoundingBox.MaxEdge * 0.01f);
                driver.Draw3DBox(b2, Color.From(0, 255, 255, 255));
            }
        }

        /*private void DoParticleSystem(uint time)
        {
        }*/
        private void ReallocateBuffers()
        {
            if (Particles.Length * 4 > Vertices.Length || Particles.Length * 6 > Indices.Length)
            {
                int oldSize = Vertices.Length;
                ArrayList newvert = new ArrayList();

                int i = 0;
                newvert.AddRange(Vertices);
                for (i = oldSize; i < (Particles.Length * 4); i++)
                {
                    Vertex3D temp = new Vertex3D();
                    temp.Normal = new Vector3D(0, 1, 0);
                    newvert.Add(temp);
                }
                Vertices = (Vertex3D[])newvert.ToArray(typeof(Vertex3D));


                newvert.Clear();

                int oldIdxSize = Indices.Length;
                int oldvertices = oldSize;

                newvert.AddRange(Indices);

                for (i = oldIdxSize; i < (Particles.Length * 12); i += 12)
                {
                    newvert.Add((ushort)(0 + oldvertices));
                    newvert.Add((ushort)(2 + oldvertices));
                    newvert.Add((ushort)(1 + oldvertices));
                    newvert.Add((ushort)(0 + oldvertices));
                    newvert.Add((ushort)(3 + oldvertices));
                    newvert.Add((ushort)(2 + oldvertices));

                    newvert.Add((ushort)(1 + oldvertices));
                    newvert.Add((ushort)(2 + oldvertices));
                    newvert.Add((ushort)(0 + oldvertices));
                    newvert.Add((ushort)(2 + oldvertices));
                    newvert.Add((ushort)(3 + oldvertices));
                    newvert.Add((ushort)(0 + oldvertices));

                    oldvertices += 4;
                }
                Indices = (ushort[])newvert.ToArray(typeof(ushort));
                newvert.Clear();
            }
        }

        bool Load()
        {
            return false;
        }

        bool Save()
        {
#if !QUIET
            Console.WriteLine(filename + " could not be saved : not yet implemented");
#endif
            return false;
        }

        bool Create(bool save)
        {
            Random rand = new Random((int)((100 * gridpos.X) + gridpos.Z));
            int count = rand.Next(3000, 3200);

            _bbox = new Box3D();

            Particles = new GrassParticle[count];

            /*Matrix4 m = new Matrix4();
            m.RotationDegrees = Terrain.Rotation;
            m.Translation = Terrain.AbsolutePosition;
            m.MakeInverse();*/

            Color[,] TGMRetrieve = TerrainGrassMap.Retrieve();
            Color[,] TCMRetrieve = TerrainColourMap.Retrieve();
            Color[,] THMRetrieve = TerrainHeightMap.Retrieve();
            System.Collections.ArrayList tosave = new System.Collections.ArrayList();

            for (int i = 0; i < count; i++)
            {
                Particles[i].points = new Vector3D[4];

                float x = rand.Next(0, GRASS_PATCH_SIZE * 10) / 10f;
                float z = rand.Next(0, GRASS_PATCH_SIZE * 10) / 10f;

                x -= GRASS_PATCH_SIZE / 2f;
                z -= GRASS_PATCH_SIZE / 2f;

                Particles[i].pos.X = x;
                Particles[i].pos.Z = z;

                Particles[i].flex = rand.Next(0, 100) / 100f;
                Particles[i].sprite.Width = rand.Next(0, _imagecount.Width);

                if (i < 30)
                    Particles[i].sprite.Height = rand.Next(0, _imagecount.Height);
                else
                    Particles[i].sprite.Height = 0;

                Vector3D p = Position + Particles[i].pos;

                Dimension2Df size;

                Vector3D xz = new Vector3D(p.X / Terrain.Scale.X, 0f, p.Z / Terrain.Scale.Z);

                int x1 = (int)Math.Floor(xz.X);
                int z1 = (int)Math.Floor(xz.Z);

                float height;

                if (x1 < 1 ||
                   z1 < 1 ||
                   x1 > TerrainHeightMap.OriginalSize.Width - 1 ||
                   z1 > TerrainHeightMap.OriginalSize.Height - 1)
                    continue;

                Color cDensity = TGMRetrieve[x1, z1];
                if (rand.Next(0, 255) > cDensity.A || cDensity.A < 1)
                    continue;

                float ay = THMRetrieve[x1, z1].B * Terrain.Scale.Y;
                float by = THMRetrieve[x1 + 1, z1].B * Terrain.Scale.Y;
                float cy = THMRetrieve[x1, z1 + 1].B * Terrain.Scale.Y;
                float dy = THMRetrieve[x1 + 1, z1 + 1].B * Terrain.Scale.Y;
                float u1 = xz.X - x1;
                float v1 = xz.Z - z1;
                height = ay * (1.0f - u1) * (1.0f - v1) + by * u1 * (1.0f - v1) + cy * (1.0f - u1) * v1 + dy * u1 * v1;

                size = new Dimension2Df(rand.Next(40, 70), 100);
                size.Height *= (float)cDensity.B / 200f;

                Particles[i].pos.Y = height + (size.Height * 0.5f);

                Particles[i].color = TCMRetrieve[x1, z1];
                Particles[i].startColor = TCMRetrieve[x1, z1];

                _bbox.AddInternalPoint(Particles[i].pos);

                Vector3D dimensions = new Vector3D(0.5f * size.Width,
                                                   -0.5f * size.Height,
                                                   0);

                /*float rotation = rand.Next(0, 3600) / 10f;
                Matrix4 m2 = new Matrix4();
                m2.RotationDegrees = new Vector3D(0, rotation, 0);
                m2.RotateVect(dimensions);*/

                //Vector3D h = new Vector3D(dimensions.X,0.0f,dimensions.Z);
                //Vector3D v = new Vector3D(0.0f,dimensions.Y,0.0f);
                Particles[i].points[0] = Particles[i].pos + new Vector3D(dimensions.X, dimensions.Y, dimensions.Z);
                Particles[i].points[1] = Particles[i].pos + new Vector3D(dimensions.X, -dimensions.Y, dimensions.Z);
                Particles[i].points[2] = Particles[i].pos - new Vector3D(dimensions.X, dimensions.Y, dimensions.Z);
                Particles[i].points[3] = Particles[i].pos - new Vector3D(dimensions.X, -dimensions.Y, dimensions.Z);
                tosave.Add(Particles[i]);
            }

            Particles = (GrassParticle[])tosave.ToArray(typeof(GrassParticle));
            tosave.Clear();
            if (save)
                return Save();

            return true;
        }

        float _drawdistance;
        public float DrawDistance { get { return _drawdistance; } set { _drawdistance = value; } }
        int _maxdensity;
        public int MaxDensity { get { return _maxdensity; } set { _maxdensity = value; } }
        int _fpslock;
        public int MaxFPS { get { return _fpslock; } set { _fpslock = value; } }
        uint _windres;
        public uint WindRes
        {
            get
            {
                return _windres;
            }
            set
            {
                _windres = value;
                WindGrid = new Vector2D[(value + 1) * (value + 1)];
            }
        }

        Dimension2D _imagecount;
        Dimension2Df _imagesize;
        public Dimension2D ImageCount
        {
            get { return _imagecount; }
            set
            {
                _imagecount = value;
                _imagesize = new Dimension2Df(1f / value.Width, 1f / value.Height);

                v1 = new float[_imagecount.Width * _imagecount.Height];
                v2 = new float[_imagecount.Width * _imagecount.Height];
                v3 = new float[_imagecount.Width * _imagecount.Height];
                v4 = new float[_imagecount.Width * _imagecount.Height];


                for (int x = 0; x < _imagecount.Width; ++x)
                    for (int y = 0; y < _imagecount.Height; ++y)
                    {
                        v1[(_imagecount.Width * y) + x] = _imagesize.Width * x;
                        v2[(_imagecount.Width * y) + x] = _imagesize.Height * (y + 1);
                        v3[(_imagecount.Width * y) + x] = _imagesize.Height * y;
                        v4[(_imagecount.Width * y) + x] = _imagesize.Width * (x + 1);
                    }
            }
        }

        Box3D _bbox;
        public override Box3D BoundingBox { get { return _bbox; } }

        float[] v1, v2, v3, v4;
        Vertex3D[] Vertices = new Vertex3D[0];
        ushort[] Indices = new ushort[0];
        Vector2D[] WindGrid;
        GrassParticle[] Particles;
        SceneNode Terrain;
        Texture TerrainHeightMap;
        Texture TerrainColourMap;
        Texture TerrainGrassMap;
        uint lastwindtime;
        bool redrawnextloop;
        int lastdrawcount;
        WindGenerator WindGen;
        string filename;
        Vector3D gridpos;
        SceneManager _mgr;
    }

    internal struct GrassParticle
    {
        public Color color;
        public Color startColor;
        public Vector3D pos;
        public Dimension2D sprite;
        public Vector3D[] points;
        public float flex;
    }
}
