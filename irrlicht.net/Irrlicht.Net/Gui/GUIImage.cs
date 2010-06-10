using System;
using System.Runtime.InteropServices;
using System.Security;

namespace IrrlichtNETCP
{
    public class GUIImage : GUIElement
    {
        public GUIImage(IntPtr raw)
            : base(raw)
        {
        }

        public Texture Image
        {
            set
            {
                GUIImage_SetImage(_raw, value.Raw);
            }
        }

        public bool UseAlphaChannel
        {
            set
            {
                GUIImage_SetUseAlphaChannel(_raw, value);
            }
        }

        #region Native Invokes
        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void GUIImage_SetImage(IntPtr image, IntPtr texture);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void GUIImage_SetUseAlphaChannel(IntPtr image, bool use);
        #endregion
    }
}
