using System;
using System.Runtime.InteropServices;
using System.Security;

namespace IrrlichtNETCP
{
    public class GUIButton : GUIElement
    {
        public GUIButton(IntPtr raw)
            : base(raw)
        {
        }

        public bool UseAlphaChannel
        {
            get
            {
                return GUIButton_GetUseAlphaChannel(_raw);
            }
            set
            {
                GUIButton_SetUseAlphaChannel(_raw, value);
            }
        }

        public bool Pressed
        {
            get
            {
                return GUIButton_IsPressed(_raw);
            }
            set
            {
                GUIButton_SetPressed(_raw, value);
            }
        }

        public bool IsPushButton
        {
            set
            {
                GUIButton_SetIsPushButton(_raw, value);
            }
        }

        public GUIFont OverrideFont
        {
            set
            {
                GUIButton_SetOverrideFont(_raw, value.Raw);
            }
        }

        public void SetImage(Texture image, Rect pos)
        {
            GUIButton_SetImage(_raw, image.Raw, pos.ToUnmanaged());
        }

        public void SetImage(Texture image)
        {
            GUIButton_SetImageA(_raw, image.Raw);
        }

        public void SetPressedImage(Texture image, Rect pos)
        {
            GUIButton_SetPressedImage(_raw, image.Raw, pos.ToUnmanaged());
        }

        public void SetPressedImage(Texture image)
        {
            GUIButton_SetPressedImageA(_raw, image.Raw);
        }


        #region Native Invokes
        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern bool GUIButton_GetUseAlphaChannel(IntPtr button);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern bool GUIButton_IsPressed(IntPtr button);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void GUIButton_SetImage(IntPtr button, IntPtr image, int[] pos);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void GUIButton_SetImageA(IntPtr button, IntPtr image);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void GUIButton_SetIsPushButton(IntPtr button, bool ispush);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void GUIButton_SetOverrideFont(IntPtr button, IntPtr font);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void GUIButton_SetPressed(IntPtr button, bool pressed);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void GUIButton_SetPressedImage(IntPtr button, IntPtr image, int[] pos);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void GUIButton_SetPressedImageA(IntPtr button, IntPtr image);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void GUIButton_SetUseAlphaChannel(IntPtr button, bool use);
        #endregion
    }
}
