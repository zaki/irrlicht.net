using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Security;

namespace IrrlichtNET
{
    public class Particle : NativeElement
    {
        public Particle()
            : base(SParticle_Create())
        {
        }
        public Particle(IntPtr raw)
            : base(raw)
        {
        }

        public Vector3D Position
        {
            get
            {
                float[] pos = new float[3];
                SParticle_GetPos(_raw, pos);
                return Vector3D.FromUnmanaged(pos);
            }
            set
            {
                SParticle_SetPos(_raw, value.ToUnmanaged());
            }
        }

        public Vector3D Vector
        {
            get
            {
                float[] pos = new float[3];
                SParticle_GetVect(_raw, pos);
                return Vector3D.FromUnmanaged(pos);
            }
            set
            {
                SParticle_SetVect(_raw, value.ToUnmanaged());
            }
        }

        public Vector3D StartVector
        {
            get
            {
                float[] pos = new float[3];
                SParticle_GetStartVect(_raw, pos);
                return Vector3D.FromUnmanaged(pos);
            }
            set
            {
                SParticle_SetStartVect(_raw, value.ToUnmanaged());
            }
        }

        public Color Color
        {
            get
            {
                int[] pos = new int[4];
                SParticle_GetColor(_raw, pos);
                return Color.FromUnmanaged(pos);
            }
            set
            {
                SParticle_SetColor(_raw, value.ToUnmanaged());
            }
        }

        public Color StartColor
        {
            get
            {
                int[] pos = new int[4];
                SParticle_GetStartColor(_raw, pos);
                return Color.FromUnmanaged(pos);
            }
            set
            {
                SParticle_SetStartColor(_raw, value.ToUnmanaged());
            }
        }

        public uint StartTime
        {
            get
            {
                return SParticle_GetStartTime(_raw);
            }
            set
            {
                SParticle_SetStartTime(_raw, value);
            }
        }

        public uint EndTime
        {
            get
            {
                return SParticle_GetEndTime(_raw);
            }
            set
            {
                SParticle_SetEndTime(_raw, value);
            }
        }

        #region Native Invokes
        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr SParticle_Create();

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void SParticle_GetPos(IntPtr particle, [MarshalAs(UnmanagedType.LPArray)] float[] vect);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void SParticle_SetPos(IntPtr particle, float[] vect);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void SParticle_GetVect(IntPtr particle, [MarshalAs(UnmanagedType.LPArray)] float[] vect);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void SParticle_SetVect(IntPtr particle, float[] vect);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void SParticle_GetStartVect(IntPtr particle, [MarshalAs(UnmanagedType.LPArray)] float[] vect);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void SParticle_SetStartVect(IntPtr particle, float[] vect);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void SParticle_GetColor(IntPtr particle, [MarshalAs(UnmanagedType.LPArray)] int[] color);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void SParticle_SetColor(IntPtr particle, int[] color);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void SParticle_GetStartColor(IntPtr particle, [MarshalAs(UnmanagedType.LPArray)] int[] color);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void SParticle_SetStartColor(IntPtr particle, int[] color);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern uint SParticle_GetStartTime(IntPtr particle);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void SParticle_SetStartTime(IntPtr particle, uint time);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern uint SParticle_GetEndTime(IntPtr particle);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void SParticle_SetEndTime(IntPtr particle, uint time);
        #endregion
    }
}
