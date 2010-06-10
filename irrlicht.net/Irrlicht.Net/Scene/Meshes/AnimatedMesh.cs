using System;
using System.Runtime.InteropServices;
using System.Security;

namespace IrrlichtNETCP
{
    public class AnimatedMesh : NativeElement
    {
        public AnimatedMesh(IntPtr raw)
            : base(raw)
        {
        }

        public AnimatedMeshType MeshType
        {
            get
            {
                return AnimatedMesh_GetMeshType(_raw);
            }
        }

        public Mesh GetMesh(int frame, int detailLevel, int startFrameLoop, int endFrameLoop)
        {
            return (Mesh)
                NativeElement.GetObject(AnimatedMesh_GetMesh(_raw, frame, detailLevel, startFrameLoop, endFrameLoop),
                                        typeof(Mesh));
        }
        public Mesh GetMesh(int frame)
        {
            return GetMesh(frame, 255, -1, -1);
        }
        public Box3D BoundingBox
        {
            get
            {
                float[] box = new float[6];
                AnimatedMesh_GetBoundingBox(_raw, box);
                return Box3D.FromUnmanaged(box);
            }
        }


        #region Native Code
        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void AnimatedMesh_GetBoundingBox(IntPtr mesh, [MarshalAs(UnmanagedType.LPArray)] float[] box);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr AnimatedMesh_GetMesh(IntPtr mesh, int frame, int detailLevel, int startFrameloop, int endFrameloop);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern AnimatedMeshType AnimatedMesh_GetMeshType(IntPtr mesh);
        #endregion
    }

    public enum AnimatedMeshType
    {
        Unknown,
        MD2,
        MD3,
        OBJ,
        BSP,
        T3DS,
        MY3D,
        LMTS,
        CSM,
        OCT,
        Skinned
    }
}
