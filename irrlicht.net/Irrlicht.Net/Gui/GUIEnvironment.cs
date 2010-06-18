using System;
using System.Runtime.InteropServices;
using System.Security;

namespace IrrlichtNET
{
    public partial class GUIEnvironment : NativeElement
    {
        public GUIEnvironment(IntPtr raw)
            : base(raw)
        {
        }

        protected IntPtr GetParent(GUIElement parent)
        {
            return (parent == null ? IntPtr.Zero : parent.Raw);
        }

        public GUIButton AddButton(Rect rectangle, GUIElement parent, int id, string text)
        {
            return (GUIButton)NativeElement.GetObject(GuiEnv_AddButton(_raw, rectangle.ToUnmanaged(), GetParent(parent), id, text),
                                                      typeof(GUIButton));
        }

        public GUIColorSelectDialog AddColorSelectDialog(string title, bool modal, GUIElement parent, int id)
        {
            return (GUIColorSelectDialog)NativeElement.GetObject(GuiEnv_AddColorSelectDialog(_raw,
                                                                                             title,
                                                                                             modal,
                                                                                             GetParent(parent),
                                                                                             id),
                                                                 typeof(GUIColorSelectDialog));
        }

        public GUISpinBox AddSpinBox(string text, Rect rectangle, bool border, GUIElement parent, int id)
        {
            return (GUISpinBox)NativeElement.GetObject(GuiEnv_AddSpinBox(_raw, text,
                                                                         rectangle.ToUnmanaged(),
                                                                         border,
                                                                         GetParent(parent), id), typeof(GUISpinBox));
        }

        public GUICheckBox AddCheckBox(bool ischecked, Rect rectangle, GUIElement parent, int id, string text)
        {
            return (GUICheckBox)NativeElement.GetObject(GuiEnv_AddCheckBox(_raw, ischecked, rectangle.ToUnmanaged(), GetParent(parent), id, text),
                                                      typeof(GUICheckBox));
        }

        public GUIComboBox AddComboBox(Rect rectangle, GUIElement parent, int id)
        {
            return (GUIComboBox)NativeElement.GetObject(GuiEnv_AddComboBox(_raw, rectangle.ToUnmanaged(), GetParent(parent), id),
                                                      typeof(GUIComboBox));
        }

        public GUIContextMenu AddContextMenu(Rect rectangle, GUIElement parent, int id)
        {
            return (GUIContextMenu)NativeElement.GetObject(GuiEnv_AddContextMenu(_raw, rectangle.ToUnmanaged(), GetParent(parent), id),
                                                      typeof(GUIContextMenu));
        }

        public GUIEditBox AddEditBox(string text, Rect rectangle, bool border, GUIElement parent, int id)
        {
            return (GUIEditBox)NativeElement.GetObject(GuiEnv_AddEditBox(_raw, text, rectangle.ToUnmanaged(), border, GetParent(parent), id),
                                                      typeof(GUIEditBox));
        }

        public GUIFileOpenDialog AddFileOpenDialog(string title, bool modal, GUIElement parent, int id)
        {
            return (GUIFileOpenDialog)NativeElement.GetObject(GuiEnv_AddFileOpenDialog(_raw, title, modal, GetParent(parent), id),
                                                      typeof(GUIFileOpenDialog));
        }

        public GUIImage AddImage(Rect rectangle, GUIElement parent, int id, string text)
        {
            return (GUIImage)NativeElement.GetObject(GuiEnv_AddImage(_raw, rectangle.ToUnmanaged(), GetParent(parent), id, text),
                                                      typeof(GUIImage));
        }

        public GUIImage AddImage(Texture image, Position2D position, bool useAlphaChannel, GUIElement parent, int id, string text)
        {
            return (GUIImage)NativeElement.GetObject(GuiEnv_AddImageA(_raw, image.Raw, position.ToUnmanaged(), useAlphaChannel, GetParent(parent), id, text),
                                                      typeof(GUIImage));
        }

        public GUIInOutFader AddInOutFader(Rect rectangle, GUIElement parent, int id)
        {
            return (GUIInOutFader)NativeElement.GetObject(GuiEnv_AddInOutFader(_raw, rectangle.ToUnmanaged(), GetParent(parent), id),
                                                      typeof(GUIInOutFader));
        }

        public GUIInOutFader AddInOutFader(GUIElement parent, int id)
        {
            return (GUIInOutFader)NativeElement.GetObject(GuiEnv_AddInOutFader(_raw, null, GetParent(parent), id),
                                                      typeof(GUIInOutFader));
        }

        public GUIListBox AddListBox(Rect rect, GUIElement parent, int id, bool drawBackground)
        {
            return (GUIListBox)NativeElement.GetObject(GuiEnv_AddListBox(_raw, rect.ToUnmanaged(), GetParent(parent), id, drawBackground),
                                                      typeof(GUIListBox));
        }

        public GUIContextMenu AddMenu(GUIElement parent, int id)
        {
            return (GUIContextMenu)NativeElement.GetObject(GuiEnv_AddMenu(_raw, GetParent(parent), id), typeof(GUIContextMenu));
        }

        public GUIMeshViewer AddMeshViewer(Rect rectangle, GUIElement parent, int id, string text)
        {
            return (GUIMeshViewer)NativeElement.GetObject(GuiEnv_AddMeshViewer(_raw, rectangle.ToUnmanaged(), GetParent(parent), id, text),
                                                      typeof(GUIMeshViewer));
        }

        public GUIWindow AddMessageBox(string caption, string text, bool modal, MessageBoxFlag flags, GUIElement parent, int id)
        {
            return (GUIWindow)NativeElement.GetObject(GuiEnv_AddMessageBox(_raw, caption, text, modal, flags, GetParent(parent), id),
                                                      typeof(GUIWindow));
        }

        public GUIScrollBar AddScrollBar(bool horizontal, Rect rectangle, GUIElement parent, int id)
        {
            return (GUIScrollBar)NativeElement.GetObject(GuiEnv_AddScrollBar(_raw, horizontal, rectangle.ToUnmanaged(), GetParent(parent), id),
                                                      typeof(GUIScrollBar));
        }

        public GUIStaticText AddStaticText(string text, Rect rectangle, bool border, bool wordWrap, GUIElement parent, int id, bool fillBackground)
        {
            return (GUIStaticText)NativeElement.GetObject(GuiEnv_AddStaticText(_raw, text, rectangle.ToUnmanaged(), border, wordWrap, GetParent(parent), id, fillBackground),
                                                      typeof(GUIStaticText));
        }

        public GUITab AddTab(Rect rectangle, GUIElement parent, int id)
        {
            return (GUITab)NativeElement.GetObject(GuiEnv_AddTab(_raw, rectangle.ToUnmanaged(), GetParent(parent), id),
                                                      typeof(GUITab));
        }

        public GUITabControl AddTabControl(Rect rectangle, GUIElement parent, bool fillBackground, bool hasBorder, int id)
        {
            return (GUITabControl)NativeElement.GetObject(GuiEnv_AddTabControl(_raw, rectangle.ToUnmanaged(), GetParent(parent), fillBackground, hasBorder, id),
                                                      typeof(GUITabControl));
        }

        public GUIToolBar AddToolBar(GUIElement parent, int id)
        {
            return (GUIToolBar)NativeElement.GetObject(GuiEnv_AddToolBar(_raw, GetParent(parent), id), typeof(GUIToolBar));
        }

        public GUIWindow AddWindow(Rect rectangle, bool modal, string text, GUIElement parent, int id)
        {
            return (GUIWindow)NativeElement.GetObject(GuiEnv_AddWindow(_raw, rectangle.ToUnmanaged(), modal, text, GetParent(parent), id),
                                                      typeof(GUIWindow));
        }

        public GUISkin CreateSkin(GUISkinTypes skin)
        {
            return (GUISkin)NativeElement.GetObject(GuiEnv_CreateSkin(_raw, skin), typeof(GUISkin));
        }

        public void DrawAll()
        {
            GuiEnv_DrawAll(_raw);
        }


        public void Clear()
        {
            GuiEnv_Clear(_raw);
        }

        public bool LoadGui(string filename)
        {
            return GuiEnv_LoadGUI(_raw, filename);
        }

        public bool SaveGui(string filename)
        {
            return GuiEnv_SaveGUI(_raw, filename);
        }

        public GUIFont GetFont(string filename)
        {
            return (GUIFont)NativeElement.GetObject(GuiEnv_GetFont(_raw, filename), typeof(GUIFont));
        }

        public GUIFont BuiltInFont
        {
            get
            {
                return (GUIFont)NativeElement.GetObject(GuiEnv_GetBuiltInFont(_raw), typeof(GUIFont));
            }
        }

        public GUIElement RootElement
        {
            get
            {
                return (GUIElement)NativeElement.GetObject(GuiEnv_GetRootGUIElement(_raw), typeof(GUIElement));
            }
        }

        public GUISkin Skin
        {
            get
            {
                return (GUISkin)NativeElement.GetObject(GuiEnv_GetSkin(_raw), typeof(GUISkin));
            }
            set
            {
                GuiEnv_SetSkin(_raw, value.Raw);
            }
        }

        public VideoDriver VideoDriver
        {
            get
            {
                return (VideoDriver)NativeElement.GetObject(GuiEnv_GetVideoDriver(_raw), typeof(VideoDriver));
            }
        }

        public bool HasFocus(GUIElement elem)
        {
            return GuiEnv_HasFocus(_raw, elem.Raw);
        }

        public bool PostEventFromUser(Event ev)
        {
            return GuiEnv_PostEventFromUser(_raw, ev.Raw);
        }

        public void RemoveFocus(GUIElement elem)
        {
            GuiEnv_RemoveFocus(_raw, elem.Raw);
        }

        public void SetFocus(GUIElement elem)
        {
            GuiEnv_SetFocus(_raw, elem.Raw);
        }

        #region Native Invokes
        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr GuiEnv_AddButton(IntPtr guienv, int[] rectangle, IntPtr parent, int id, string text);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr GuiEnv_AddCheckBox(IntPtr guienv, bool ischecked, int[] rectangle, IntPtr parent, int id, string text);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr GuiEnv_AddComboBox(IntPtr guienv, int[] rectangle, IntPtr parent, int id);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr GuiEnv_AddContextMenu(IntPtr guienv, int[] rectangle, IntPtr parent, int id);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr GuiEnv_AddEditBox(IntPtr guienv, string text, int[] rectangle, bool border, IntPtr parent, int id);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr GuiEnv_AddFileOpenDialog(IntPtr guienv, string title, bool model, IntPtr parent, int id);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr GuiEnv_AddImage(IntPtr guienv, int[] rectangle, IntPtr parent, int id, string text);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr GuiEnv_AddImageA(IntPtr guienv, IntPtr image, int[] pos, bool useAlphaChannel, IntPtr parent, int id, string text);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr GuiEnv_AddInOutFader(IntPtr guienv, int[] rectangle, IntPtr parent, int id);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr GuiEnv_AddListBox(IntPtr guienv, int[] rectangle, IntPtr parent, int id, bool drawBackground);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr GuiEnv_AddMenu(IntPtr guienv, IntPtr parent, int id);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr GuiEnv_AddMeshViewer(IntPtr guienv, int[] rectangle, IntPtr parent, int id, string text);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr GuiEnv_AddMessageBox(IntPtr guienv, string caption, string text, bool modal, MessageBoxFlag flags, IntPtr parent, int id);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr GuiEnv_AddScrollBar(IntPtr guienv, bool horizontal, int[] rectangle, IntPtr parent, int id);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr GuiEnv_AddStaticText(IntPtr guienv, string text, int[] rectangle, bool border, bool wordWrap, IntPtr parent, int id, bool fillBack);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr GuiEnv_AddTab(IntPtr guienv, int[] rectangle, IntPtr parent, int id);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr GuiEnv_AddTabControl(IntPtr guienv, int[] rectangle, IntPtr parent, bool fillbackGround, bool border, int id);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr GuiEnv_AddToolBar(IntPtr guienv, IntPtr parent, int id);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr GuiEnv_AddWindow(IntPtr guienv, int[] rectangle, bool modal, string text, IntPtr parent, int id);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr GuiEnv_CreateSkin(IntPtr guienv, GUISkinTypes type);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void GuiEnv_DrawAll(IntPtr guienv);


        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void GuiEnv_Clear(IntPtr guienv);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr GuiEnv_GetFont(IntPtr guienv, string filename);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr GuiEnv_GetBuiltInFont(IntPtr guienv);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr GuiEnv_GetRootGUIElement(IntPtr guienv);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr GuiEnv_GetSkin(IntPtr guienv);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr GuiEnv_GetVideoDriver(IntPtr guienv);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern bool GuiEnv_HasFocus(IntPtr guienv, IntPtr element);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern bool GuiEnv_LoadGUI(IntPtr guienv, string filename);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern bool GuiEnv_SaveGUI(IntPtr guienv, string filename);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern bool GuiEnv_PostEventFromUser(IntPtr guienv, IntPtr ev);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void GuiEnv_RemoveFocus(IntPtr guienv, IntPtr element);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void GuiEnv_SetFocus(IntPtr guienv, IntPtr element);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void GuiEnv_SetSkin(IntPtr guienv, IntPtr skin);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr GuiEnv_AddColorSelectDialog(IntPtr guienv, string title, bool modal, IntPtr parent, int id);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr GuiEnv_AddSpinBox(IntPtr guienv, string text, int[] rect, bool border, IntPtr parent, int id);

        #endregion
    }

    public enum MessageBoxFlag
    {
        OK = 0x1,
        Cancel = 0x2,
        Yes = 0x4,
        No = 0x8
    }

    public enum GUISkinTypes
    {
        WindowsClassic,
        WindowsMetallic,
        BurningSkin
    }
}
