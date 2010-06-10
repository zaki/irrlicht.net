using System;
using System.Runtime.InteropServices;
using System.Security;

namespace IrrlichtNETCP
{
    public class LightSceneNode : SceneNode
    {
        public LightSceneNode(IntPtr raw)
            : base(raw)
        {
        }

        public Light LightData
        {
            get
            {
                Light l;
                float[] ambient = new float[4];
                float[] diffuse = new float[4];
                float[] specular = new float[4];
                float[] pos = new float[3];
                float[] dir = new float[3];
                float[] att = new float[3];
                float radius = 0f;
                float falloff = 0f;
                float innercone = 0f;
                float outercone = 0f;
                bool cast = false;
                LightType t = LightType.Point;
                LightSceneNode_GetLight(_raw, ambient, diffuse, specular, pos, dir, att,
                                        ref falloff,
                                        ref innercone,
                                        ref outercone,
                                        ref radius, ref cast, ref t);
                l.AmbientColor = Colorf.FromUnmanaged(ambient);
                l.DiffuseColor = Colorf.FromUnmanaged(diffuse);
                l.SpecularColor = Colorf.FromUnmanaged(diffuse);
                l.Position = Vector3D.FromUnmanaged(pos);
                l.Direction = Vector3D.FromUnmanaged(dir);
                l.Attenuation = Vector3D.FromUnmanaged(att);
                l.Falloff = falloff;
                l.InnerCone = innercone;
                l.OuterCone = outercone;
                l.Radius = radius;
                l.CastShadows = cast;
                l.Type = t;
                return l;
            }
            set
            {
                LightSceneNode_SetLight(_raw, value.AmbientColor.ToUnmanaged(), value.DiffuseColor.ToUnmanaged(), value.SpecularColor.ToUnmanaged(), value.Position.ToUnmanaged(), value.Direction.ToUnmanaged(),
                                        value.Attenuation.ToUnmanaged(),
                                        value.Falloff,
                                        value.InnerCone,
                                        value.OuterCone,
                                        value.Radius, value.CastShadows, value.Type);
            }
        }

        #region Native Invokes
        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void LightSceneNode_GetLight(IntPtr light, [MarshalAs(UnmanagedType.LPArray)] float[] ambient,
                                        [MarshalAs(UnmanagedType.LPArray)] float[] diffuse,
                                        [MarshalAs(UnmanagedType.LPArray)] float[] specular,
                                        [MarshalAs(UnmanagedType.LPArray)] float[] pos,
                                        [MarshalAs(UnmanagedType.LPArray)] float[] dir,
                                        [MarshalAs(UnmanagedType.LPArray)] float[] att,
                                        ref float falloff,
                                        ref float innercone,
                                        ref float outercone,
                                        ref float radius,
                                        ref bool castshadows,
                                        ref LightType type);


        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void LightSceneNode_SetLight(IntPtr light, float[] ambient,
                             float[] diffuse,
                             float[] specular,
                             float[] pos,
                             float[] dir,
                             float[] att,
                             float falloff,
                             float innercone,
                             float outercone,
                             float radius,
                             bool castshadows,
                             LightType type);


        #endregion
    }
}
