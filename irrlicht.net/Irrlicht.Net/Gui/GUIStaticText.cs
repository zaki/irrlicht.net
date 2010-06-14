using System;
using System.Runtime.InteropServices;
using System.Security;

namespace IrrlichtNET
{
    public class GUIStaticText : GUIElement
    {
        public GUIStaticText(IntPtr raw)
            : base(raw)
        {
        }

        public bool OverideColorEnabled
        {
            set
            {
                GUIStaticText_EnableOverrideColor(_raw, value);
            }
        }

        public int TextHeight
        {
            get
            {
                return GUIStaticText_GetTextHeight(_raw);
            }
        }

        public Color OverrideColor
        {
            set
            {
                GUIStaticText_SetOverrideColor(_raw, value.ToUnmanaged());
            }
        }

        public GUIFont OverrideFont
        {
            set
            {
                GUIStaticText_SetOverrideFont(_raw, value.Raw);
            }
        }

        public bool WordWrap
        {
            set
            {
                GUIStaticText_SetWordWrap(_raw, value);
            }
        }

        #region Native Invokes
        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void GUIStaticText_EnableOverrideColor(IntPtr st, bool enabled);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern int GUIStaticText_GetTextHeight(IntPtr st);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void GUIStaticText_SetOverrideColor(IntPtr st, int[] color);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void GUIStaticText_SetOverrideFont(IntPtr st, IntPtr font);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void GUIStaticText_SetWordWrap(IntPtr st, bool enabled);
        #endregion
    }
}
