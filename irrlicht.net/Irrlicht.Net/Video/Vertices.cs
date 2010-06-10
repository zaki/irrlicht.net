using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Security;

namespace IrrlichtNETCP
{
    public class Vertex3D : IDisposable
    {
        protected IntPtr _raw = IntPtr.Zero;
        public IntPtr Raw { get { return (_raw); } set { _raw = value; } }

        public Vertex3D()
        {
            _raw = Vertices_CreateVertex();
        }
        public Vertex3D(IntPtr raw)
        {
            _raw = raw;
        }
        public Vertex3D(Vector3D position, Vector3D normal, Color color, Vector2D tcoord)
            : this()
        {
            Position = position;
            Normal = normal;
            Color = color;
            TCoords = tcoord;
        }

        public void Dispose()
        {
            if (_raw == IntPtr.Zero)
                return;

            Vertices_Release(_raw);
        }

        public Color Color
        {
            get
            {
                int[] color = new int[4];
                Vertices_GetColor(_raw, color);
                return Color.FromUnmanaged(color);
            }
            set
            {
                Vertices_SetColor(_raw, value.ToUnmanaged());
            }
        }

        public VertexType Type()
        {
            return (VertexType)Vertices_GetType(_raw);
        }

        public Vector3D Normal
        {
            get
            {
                float[] norm = new float[3];
                Vertices_GetNormal(_raw, norm);
                return Vector3D.FromUnmanaged(norm);
            }
            set
            {
                Vertices_SetNormal(_raw, value.ToUnmanaged());
            }
        }

        public Vector3D Position
        {
            get
            {
                float[] norm = new float[3];
                Vertices_GetPos(_raw, norm);
                return Vector3D.FromUnmanaged(norm);
            }
            set
            {
                Vertices_SetPos(_raw, value.ToUnmanaged());
            }
        }

        public Vector2D TCoords
        {
            get
            {
                float[] coords = new float[2];
                Vertices_GetTCoords(_raw, coords);
                return Vector2D.FromUnmanaged(coords);
            }
            set
            {
                Vertices_SetTCoords(_raw, value.ToUnmanaged());
            }
        }

        #region Native Invokes
        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr Vertices_CreateVertex();

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void Vertices_GetColor(IntPtr vertex, [MarshalAs(UnmanagedType.LPArray)] int[] color);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void Vertices_GetNormal(IntPtr vertex, [MarshalAs(UnmanagedType.LPArray)] float[] normal);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void Vertices_GetPos(IntPtr vertex, [MarshalAs(UnmanagedType.LPArray)] float[] pos);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void Vertices_GetTCoords(IntPtr vertex, [MarshalAs(UnmanagedType.LPArray)] float[] tcoords);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void Vertices_SetColor(IntPtr vertex, int[] color);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void Vertices_SetNormal(IntPtr vertex, float[] normal);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void Vertices_SetPos(IntPtr vertex, float[] pos);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void Vertices_SetTCoords(IntPtr vertex, float[] tcoords);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern int Vertices_GetType(IntPtr vertex);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern int Vertices_Release(IntPtr vertex);

        #endregion
    }

    public class Vertex3DT2 : Vertex3D
    {
        public Vertex3DT2()
            : base(Vertices_CreateVertex2TCoords())
        {
        }
        public Vertex3DT2(IntPtr raw)
            : base(raw)
        {
        }
        public Vertex3DT2(Vector3D position, Vector3D normal, Color color, Vector2D tcoord, Vector2D tcoord2)
            : this()
        {
            Position = position;
            Normal = normal;
            Color = color;
            TCoords = tcoord;
            TCoords2 = tcoord2;
        }

        public Vector2D TCoords2
        {
            get
            {
                float[] coords = new float[2];
                Vertices_GetTCoords2(_raw, coords);
                return Vector2D.FromUnmanaged(coords);
            }
            set
            {
                Vertices_SetTCoords2(_raw, value.ToUnmanaged());
            }
        }

        #region Native Invokes
        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr Vertices_CreateVertex2TCoords();

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void Vertices_GetTCoords2(IntPtr vertex, [MarshalAs(UnmanagedType.LPArray)] float[] tcoords);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void Vertices_SetTCoords2(IntPtr vertex, float[] tcoords);

        #endregion
    }

    public class Vertex3DTangents : Vertex3D
    {
        public Vertex3DTangents()
            : base(Vertices_CreateVertexTangents())
        {
        }
        public Vertex3DTangents(IntPtr raw)
            : base(raw)
        {
        }
        public Vertex3DTangents(Vector3D position, Vector3D normal, Color color,
                                Vector2D tcoord,
                                Vector3D binormal,
                                Vector3D tangent)
            : this()
        {
            Position = position;
            Normal = normal;
            Color = color;
            TCoords = tcoord;
            Binormal = binormal;
            Tangent = tangent;
        }

        public Vector3D Binormal
        {
            get
            {
                float[] binorm = new float[3];
                Vertices_GetBinormal(_raw, binorm);
                return Vector3D.FromUnmanaged(binorm);
            }
            set
            {
                Vertices_SetBinormal(_raw, value.ToUnmanaged());
            }
        }

        public Vector3D Tangent
        {
            get
            {
                float[] tang = new float[3];
                Vertices_GetTangent(_raw, tang);
                return Vector3D.FromUnmanaged(tang);
            }
            set
            {
                Vertices_SetTangent(_raw, value.ToUnmanaged());
            }
        }


        #region Native Invokes
        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr Vertices_CreateVertexTangents();

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void Vertices_GetBinormal(IntPtr vertex, [MarshalAs(UnmanagedType.LPArray)] float[] binormal);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void Vertices_SetBinormal(IntPtr vertex, float[] binormal);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void Vertices_GetTangent(IntPtr vertex, [MarshalAs(UnmanagedType.LPArray)] float[] tangent);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void Vertices_SetTangent(IntPtr vertex, float[] tangent);

        #endregion
    }
}
