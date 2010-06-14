// SkinnedMesh.cs
//

using System;
using System.Runtime.InteropServices;
using System.Security;

namespace IrrlichtNET
{

    public class SkinnedMesh : AnimatedMesh
    {

        public SkinnedMesh(IntPtr raw)
            : base(raw)
        {
        }

        public void AnimateMesh(float frame, float blend)
        {
            SkinnedMesh_AnimateMesh(_raw, frame, blend);
        }

        public void SkinMesh()
        {
            SkinnedMesh_SkinMesh(_raw);
        }

        #region Native Imports
        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void SkinnedMesh_AnimateMesh(IntPtr mesh, float frame, float blend);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void SkinnedMesh_SkinMesh(IntPtr mesh);
        #endregion

    }
}
