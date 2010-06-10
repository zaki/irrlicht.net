using System;
using System.Runtime.InteropServices;
using System.Security;

namespace IrrlichtNETCP
{
    public class GUIScrollBar : GUIElement
    {
        public GUIScrollBar(IntPtr raw)
            : base(raw)
        {
        }

        public int Pos
        {
            get
            {
                return GUIScrollBar_GetPos(_raw);
            }
            set
            {
                GUIScrollBar_SetPos(_raw, value);
            }
        }

        public int Max
        {
            set
            {
                GUIScrollBar_SetMax(_raw, value);
            }
        }

        #region Native Invokes
        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern int GUIScrollBar_GetPos(IntPtr sb);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void GUIScrollBar_SetMax(IntPtr sb, int max);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void GUIScrollBar_SetPos(IntPtr sb, int pos);
        #endregion
    }
}
