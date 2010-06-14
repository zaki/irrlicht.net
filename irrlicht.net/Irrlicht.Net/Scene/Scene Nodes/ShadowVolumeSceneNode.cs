using System;
using System.Runtime.InteropServices;
using System.Security;

namespace IrrlichtNET
{
    public class ShadowVolumeSceneNode : SceneNode
    {
        public ShadowVolumeSceneNode(IntPtr raw)
            : base(raw)
        {
        }

        /// <summary>
        /// Sets the mesh the shadow volume uses to be rendered
        /// </summary>
        /// <param name="mesh">The mesh</param>
        public void SetMeshToRenderFrom(Mesh mesh)
        {
            ShadowVolume_SetMeshToRenderFrom(_raw, mesh.Raw);
        }

        #region Native Code
        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void ShadowVolume_SetMeshToRenderFrom(IntPtr shadow, IntPtr mesh);
        #endregion
    }
}
