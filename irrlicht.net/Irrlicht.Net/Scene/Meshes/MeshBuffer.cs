using System;
using System.Text;
using System.Runtime.InteropServices;
using System.Security;

namespace IrrlichtNET
{
    public class MeshBuffer : NativeElement
    {
        public MeshBuffer(IntPtr raw)
            : base(raw)
        {
        }

        public MeshBuffer(VertexType type)
            : this(MeshBuffer_Create((int)type))
        {
        }

        //        public override void Dispose()
        //        {
        //            Material.Dispose();
        //            base.Dispose();
        //        }

        public Box3D BoundingBox
        {
            get
            {
                float[] box = new float[6];
                MeshBuffer_GetBoundingBox(_raw, box);
                return Box3D.FromUnmanaged(box);
            }
            set
            {
                MeshBuffer_SetBoundingBox(_raw, value.ToUnmanaged());
            }
        }

        public int IndexCount
        {
            get
            {
                return MeshBuffer_GetIndexCount(_raw);
            }
        }

        public int VertexCount
        {
            get
            {
                return MeshBuffer_GetVertexCount(_raw);
            }
        }

        public ushort[] Indices
        {
            get
            {
                ushort[] indices = new ushort[IndexCount];
                MeshBuffer_GetIndices(_raw, indices);
                return indices;
            }
            set
            {
                MeshBuffer_SetIndices(_raw, value, value.Length);
            }
        }

        public ushort GetIndex(uint nr)
        {
            return MeshBuffer_GetIndex(_raw, nr);
        }

        public void SetIndex(uint nr, ushort val)
        {
            MeshBuffer_SetIndex(_raw, nr, val);
        }

        public void SetColor(Color col)
        {
            MeshBuffer_SetColor(_raw, col.ToUnmanaged());
        }

        public Material Material
        {
            get
            {
                return (Material)NativeElement.GetObject(MeshBuffer_GetMaterial(_raw), typeof(Material));
            }
            set
            {
                MeshBuffer_SetMaterial(_raw, value.Raw);
                Material.MaterialType = value.MaterialType;
            }
        }

        public VertexType VertexType
        {
            get
            {
                return MeshBuffer_GetVertexType(_raw);
            }
        }

        public Vertex3D GetVertex(uint nr)
        {
            return (Vertex3D)NativeElement.GetObject(MeshBuffer_GetVertex(_raw, nr), typeof(Vertex3D));
        }

        public Vertex3DT2 GetVertexT2(uint nr)
        {
            return (Vertex3DT2)NativeElement.GetObject(MeshBuffer_GetVertex2T(_raw, nr), typeof(Vertex3DT2));
        }

        public void SetVertex(uint nr, Vertex3D vert)
        {
            MeshBuffer_SetVertex(_raw, nr, vert.Raw);
        }

        public void SetVertexT2(uint nr, Vertex3DT2 vert)
        {
            MeshBuffer_SetVertex2T(_raw, nr, vert.Raw);
        }

        public void RecalculateBoundingBox()
        {
            MeshBuffer_RecalculateBoundingBox(_raw);
        }

        #region Native Invokes
        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr MeshBuffer_Create(int type);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void MeshBuffer_GetBoundingBox(IntPtr meshb, [MarshalAs(UnmanagedType.LPArray)] float[] bb);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void MeshBuffer_SetBoundingBox(IntPtr meshb, float[] bb);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void MeshBuffer_RecalculateBoundingBox(IntPtr meshb);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern int MeshBuffer_GetIndexCount(IntPtr meshb);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void MeshBuffer_GetIndices(IntPtr meshb, [MarshalAs(UnmanagedType.LPArray)] ushort[] indices);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void MeshBuffer_SetIndices(IntPtr meshb, ushort[] indices, int count);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern ushort MeshBuffer_GetIndex(IntPtr meshb, uint nr);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void MeshBuffer_SetIndex(IntPtr meshb, uint nr, ushort val);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void MeshBuffer_SetColor(IntPtr meshb, int[] color);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr MeshBuffer_GetMaterial(IntPtr meshb);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void MeshBuffer_SetMaterial(IntPtr meshb, IntPtr material);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern int MeshBuffer_GetVertexCount(IntPtr meshb);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern VertexType MeshBuffer_GetVertexType(IntPtr meshb);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr MeshBuffer_GetVertex(IntPtr meshb, uint nr);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void MeshBuffer_SetVertex(IntPtr meshb, uint nr, IntPtr vert);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr MeshBuffer_GetVertex2T(IntPtr meshb, uint nr);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void MeshBuffer_SetVertex2T(IntPtr meshb, uint nr, IntPtr vert);
        #endregion
    }
    public enum VertexType
    {
        Standard,
        T2Coords,
        Tangents
    }
}
