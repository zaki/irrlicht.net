using System;
using System.Runtime.InteropServices;
using System.Security;

namespace IrrlichtNETCP
{
    public class CursorControl : NativeElement
    {
        public CursorControl(IntPtr raw)
            : base(raw)
        { }

        public Position2D Position
        {
            get
            {
                int[] pos = new int[2];
                CursorControl_GetPosition(_raw, pos);
                return Position2D.FromUnmanaged(pos);
            }
            set
            {
                CursorControl_SetPosition(_raw, value.X, value.Y);
            }
        }

        public Position2Df Positionf
        {
            get
            {
                return new Position2Df(Position.X, Position.Y);
            }
            set
            {
                CursorControl_SetPositionA(_raw, value.X, value.Y);
            }
        }

        public bool Visible
        {
            get
            {
                return CursorControl_IsVisible(_raw);
            }
            set
            {
                CursorControl_SetVisible(_raw, value);
            }
        }

        public Position2Df RelativePosition
        {
            get
            {
                float[] pos = new float[2];
                CursorControl_GetRelativePosition(_raw, pos);
                return Position2Df.FromUnmanaged(pos);
            }
        }

        #region Native Invokes
        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void CursorControl_GetPosition(IntPtr cc, [MarshalAs(UnmanagedType.LPArray)] int[] pos);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void CursorControl_GetRelativePosition(IntPtr cc, [MarshalAs(UnmanagedType.LPArray)] float[] pos);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern bool CursorControl_IsVisible(IntPtr cc);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void CursorControl_SetPosition(IntPtr cc, int X, int Y);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void CursorControl_SetPositionA(IntPtr cc, float X, float Y);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void CursorControl_SetVisible(IntPtr cc, bool visible);
        #endregion
    }
}
