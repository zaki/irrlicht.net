using System;
using System.Runtime.InteropServices;
using System.Security;

namespace IrrlichtNETCP
{
    public class GUIInOutFader : GUIElement
    {
        public GUIInOutFader(IntPtr raw)
            : base(raw)
        {
        }

        public void FadeIn(uint time)
        {
            GUIFader_FadeIn(_raw, time);
        }

        public void FadeOut(uint time)
        {
            GUIFader_FadeOut(_raw, time);
        }

        public Color Color
        {
            get
            {
                int[] col = new int[4];
                GUIFader_GetColor(_raw, col);
                return Color.FromUnmanaged(col);
            }
            set
            {
                GUIFader_SetColor(_raw, value.ToUnmanaged());
            }
        }

        public bool Ready
        {
            get
            {
                return GUIFader_IsReady(_raw);
            }
        }

        #region Native Invokes
        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void GUIFader_FadeIn(IntPtr fader, uint time);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void GUIFader_FadeOut(IntPtr fader, uint time);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void GUIFader_GetColor(IntPtr fader, int[] color);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern bool GUIFader_IsReady(IntPtr fader);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void GUIFader_SetColor(IntPtr fader, int[] color);
        #endregion
    }
}
