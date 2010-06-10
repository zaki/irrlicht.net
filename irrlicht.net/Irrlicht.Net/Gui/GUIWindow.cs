using System;
using System.Runtime.InteropServices;
using System.Security;

namespace IrrlichtNETCP
{
    public class GUIWindow : GUIElement
    {
        public GUIWindow(IntPtr raw)
            : base(raw)
        {
        }

        public GUIButton CloseButton
        {
            get
            {
                return (GUIButton)NativeElement.GetObject(GUIWindow_GetCloseButton(_raw), typeof(GUIButton));
            }
        }

        public GUIButton MaximizeButton
        {
            get
            {
                return (GUIButton)NativeElement.GetObject(GUIWindow_GetMaximizeButton(_raw), typeof(GUIButton));
            }
        }

        public GUIButton MinimizeButton
        {
            get
            {
                return (GUIButton)NativeElement.GetObject(GUIWindow_GetMinimizeButton(_raw), typeof(GUIButton));
            }
        }

        #region Native Invokes (this is the last time I write it for today... I must go to bed now it is late !)
        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr GUIWindow_GetCloseButton(IntPtr window);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr GUIWindow_GetMaximizeButton(IntPtr window);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr GUIWindow_GetMinimizeButton(IntPtr window);
        #endregion
    }
}
