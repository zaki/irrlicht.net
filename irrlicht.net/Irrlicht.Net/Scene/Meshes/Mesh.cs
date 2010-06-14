using System;
using System.Runtime.InteropServices;
using System.Security;

namespace IrrlichtNET
{
    public class Mesh : NativeElement
    {
        public Mesh(IntPtr raw)
            : base(raw)
        {
        }

        public Mesh()
            : this(Mesh_Create())
        {

        }

        //        public override void Dispose()
        //        {
        //            for (int i = 0; i < MeshBufferCount; i++)
        //            {
        //                GetMeshBuffer(i).Dispose();
        //            }
        //            base.Dispose();
        //        }

        public Box3D BoundingBox
        {
            get
            {
                float[] box = new float[6];
                Mesh_GetBoundingBox(_raw, box);
                return Box3D.FromUnmanaged(box);
            }
            set
            {
                Mesh_SetBoundingBox(_raw, value.ToUnmanaged());
            }
        }

        public void AddMeshBuffer(MeshBuffer mb)
        {
            Mesh_AddMeshBuffer(_raw, mb.Raw);
        }

        public void SetMaterialFlag(MaterialFlag flag, bool newValue)
        {
            Mesh_SetMaterialFlag(_raw, flag, newValue);
        }

        public int MeshBufferCount
        {
            get
            {
                return Mesh_GetMeshBufferCount(_raw);
            }
        }

        public MeshBuffer GetMeshBuffer(int nr)
        {
            return (MeshBuffer)NativeElement.GetObject(Mesh_GetMeshBuffer(_raw, nr), typeof(MeshBuffer));
        }

        #region .NET Wrapper Native Code
        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void Mesh_GetBoundingBox(IntPtr mesh, [MarshalAs(UnmanagedType.LPArray)] float[] box);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void Mesh_SetBoundingBox(IntPtr mesh, float[] box);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void Mesh_SetMaterialFlag(IntPtr mesh, MaterialFlag flag, bool newValue);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern int Mesh_GetMeshBufferCount(IntPtr mesh);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr Mesh_GetMeshBuffer(IntPtr mesh, int nr);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr Mesh_Create();

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr Mesh_AddMeshBuffer(IntPtr mesh, IntPtr meshbuffer);
        #endregion
    }

}
