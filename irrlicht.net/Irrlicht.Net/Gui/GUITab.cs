using System;
using System.Runtime.InteropServices;
using System.Security;

namespace IrrlichtNET
{
    public class GUITab : GUIElement
    {
        public GUITab(IntPtr raw)
            : base(raw)
        {
        }

        public int Number
        {
            get
            {
                return GUITab_GetNumber(_raw);
            }
        }

        public Color BackgroundColor
        {
            set
            {
                GUITab_SetBackgroundColor(_raw, value.ToUnmanaged());
            }
        }

        public bool DrawBackground
        {
            set
            {
                GUITab_SetDrawBackground(_raw, value);
            }
        }

        #region Native Invokes
        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern int GUITab_GetNumber(IntPtr tab);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void GUITab_SetBackgroundColor(IntPtr tab, int[] color);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void GUITab_SetDrawBackground(IntPtr tab, bool draw);
        #endregion
    }
}
