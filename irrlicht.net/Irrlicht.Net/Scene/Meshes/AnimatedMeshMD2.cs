// AnimatedMeshMD2.cs created with MonoDevelop
// User: lester at 13:39 06.09.2007
//
//
//

using System;
using System.Runtime.InteropServices;
using System.Security;

namespace IrrlichtNETCP
{


    public class AnimatedMeshMD2 : AnimatedMesh
    {

        public AnimatedMeshMD2(IntPtr raw)
            : base(raw)
        {
        }

        public void GetFrameLoopMD2(int count, ref int outBegin, ref int outEnd, ref int outFps)
        {
            if (this.MeshType != AnimatedMeshType.MD2) return;
            AnimatedMesh_GetFrameLoopMD2(_raw, count, outBegin, outEnd, outFps);
        }

        public void GetFrameLoopMD2(string name, ref int outBegin, ref int outEnd, ref int outFps)
        {
            if (this.MeshType != AnimatedMeshType.MD2) return;
            AnimatedMesh_GetFrameLoopMD2a(_raw, name, outBegin, outEnd, outFps);
        }

        public int AnimationCount
        {
            get
            {
                if (this.MeshType != AnimatedMeshType.MD2) return -1;
                return AnimationMesh_GetAnimationCountMD2(_raw);
            }
        }

        public string GetAnimationName(int nr)
        {
            if (this.MeshType != AnimatedMeshType.MD2) return "not_a_MD2_mesh";
            return AnimationMesh_GetAnimationNameMD2(_raw, nr);
        }

        #region native imports
        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void AnimatedMesh_GetFrameLoopMD2(IntPtr mesh, int count,
                                                        int outBegin,
                                                        int outEnd,
                                                        int outFPS);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void AnimatedMesh_GetFrameLoopMD2a(IntPtr mesh, string name,
                                                         int outBegin,
                                                         int outEnd,
                                                         int outFPS);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern int AnimationMesh_GetAnimationCountMD2(IntPtr mesh);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern string AnimationMesh_GetAnimationNameMD2(IntPtr mesh, int nr);
        #endregion

    }
}
