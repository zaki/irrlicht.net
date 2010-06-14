using System;
using System.Runtime.InteropServices;
using System.Security;

namespace IrrlichtNET
{
    public partial class GUIFont : NativeElement
    {
        public GUIFont(IntPtr raw)
            : base(raw)
        {
        }

        public void Draw(string text, Position2D pos, Color color, bool hcenter, bool vcenter, Rect cliprect)
        {
            GUIFont_Draw(_raw, text, pos.ToUnmanaged(), color.ToUnmanaged(), hcenter, vcenter, cliprect.ToUnmanaged());
        }

        public void Draw(string text, Position2D pos, Color color, bool hcenter, bool vcenter)
        {
            GUIFont_Draw(_raw, text, pos.ToUnmanaged(), color.ToUnmanaged(), hcenter, vcenter, null);
        }

        public int GetCharacterFromPos(string text, int pixel_x)
        {
            return GUIFont_GetCharacterFromPos(_raw, text, pixel_x);
        }

        public Dimension2D GetDimension(string text)
        {
            int[] dim = new int[2];
            GUIFont_GetDimension(_raw, text, dim);
            return Dimension2D.FromUnmanaged(dim);
        }

        #region
        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void GUIFont_Draw(IntPtr font, string text, int[] pos, int[] color, bool hcenter, bool vcenter, int[] clip);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern int GUIFont_GetCharacterFromPos(IntPtr font, string text, int pixel_x);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void GUIFont_GetDimension(IntPtr font, string text, [MarshalAs(UnmanagedType.LPArray)] int[] dim);
        #endregion
    }
}
