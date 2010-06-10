using System;
using System.Runtime.InteropServices;
using System.Security;

namespace IrrlichtNETCP
{
    public class GUISkin : GUIElement
    {
        public GUISkin(IntPtr raw)
            : base(raw)
        {
        }

        /// <summary>
        /// Returns the default color.
        /// </summary>
        /// <param name="color">Specified default color</param>
        /// <returns></returns>
        public Color GetColor(GuiDefaultColor color)
        {
            int[] col = new int[4];
            GuiSkin_GetColor(_raw, color, col);
            return Color.FromUnmanaged(col);
        }

        /// <summary>
        /// Sets the default color.
        /// </summary>
        /// <param name="color">Specified default color</param>
        /// <param name="col">New color</param>
        public void SetColor(GuiDefaultColor color, Color col)
        {
            GuiSkin_SetColor(_raw, color, col.ToUnmanaged());
        }

        /// <summary>
        /// Returns a default text.
        /// For example for Message box button captions: "OK", "Cancel", "Yes", "No" and so on.
        /// </summary>
        /// <param name="text">Specified default text</param>
        /// <returns></returns>
        public string GetDefaultText(GuiDefaultText text)
        {
            return GuiSkin_GetDefaultText(_raw, text);
        }

        /// <summary>
        /// Sets a default text.
        /// For example for Message box button captions: "OK", "Cancel", "Yes", "No" and so on.
        /// </summary>
        /// <param name="text">Specified default text</param>
        /// <param name="txt">New text</param>
        public void SetDefaultText(GuiDefaultText text, string txt)
        {
            GuiSkin_SetDefaultText(_raw, text, txt);
        }

        /// <summary>
        /// Returns the default size.
        /// </summary>
        /// <param name="size">Specified default size</param>
        /// <returns></returns>
        public int GetSize(GuiDefaultSize size)
        {
            return GuiSkin_GetSize(_raw, size);
        }

        /// <summary>
        /// Sets a default size.
        /// </summary>
        /// <param name="size">Specified default size</param>
        /// <param name="s">New size</param>
        public void SetSize(GuiDefaultSize size, int s)
        {
            GuiSkin_SetSize(_raw, size, s);
        }

        /// <summary>
        /// Gets/Sets the default font for the skin.
        /// </summary>
        public GUIFont Font
        {
            get
            {
                return (GUIFont)NativeElement.GetObject(GuiSkin_GetFont(_raw), typeof(GUIFont));
            }
            set
            {
                IntPtr r = (value == null ? IntPtr.Zero : value.Raw);
                GuiSkin_SetFont(_raw, r);
            }
        }

        #region Native Invokes
        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void GuiSkin_GetColor(IntPtr gskin, GuiDefaultColor which, [MarshalAs(UnmanagedType.LPArray)] int[] color);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern string GuiSkin_GetDefaultText(IntPtr gskin, GuiDefaultText which);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr GuiSkin_GetFont(IntPtr gskin);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern int GuiSkin_GetSize(IntPtr gskin, GuiDefaultSize which);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void GuiSkin_SetColor(IntPtr gskin, GuiDefaultColor which, int[] color);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void GuiSkin_SetDefaultText(IntPtr gskin, GuiDefaultText which, string text);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void GuiSkin_SetFont(IntPtr gskin, IntPtr font);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void GuiSkin_SetSize(IntPtr gskin, GuiDefaultSize which, int size);
        #endregion
    }

    public enum GuiDefaultSize
    {
        ScrollBarSize,
        MenuHeight,
        WindowButtonWidth,
        CheckBoxWidth,
        MessageBoxWidth,
        MessageBoxHeight,
        ButtonWidth,
        ButtonHeight,
        TextDistanceX,
        TextDistanceY,
        TitlebarTextDistanceX,
        TitlebarTextDistanceY,
        Count
    }

    public enum GuiDefaultText
    {
        MessageBoxOK,
        MessageBoxCancel,
        MessageBoxYes,
        MessageBoxNo,
        WindowClose,
        WindowMaximize,
        WindowMinimize,
        WindowRestore,
        Count
    }

    public enum GuiDefaultColor
    {
        DarkShadow3D,
        Shadow3D,
        Face3D,
        HighLight3D,
        Light3D,
        ActiveBorder,
        ActiveCaption,
        AppWorkspace,
        ButtonText,
        GrayText,
        HighLight,
        HighLightText,
        InactiveBorder,
        InactiveCaption,
        ToolTip,
        ToolTipBackground,
        Scrollbar,
        Window,
        WindowSymbol,
        Icon,
        IconHighlight,
        Count
    }

}
