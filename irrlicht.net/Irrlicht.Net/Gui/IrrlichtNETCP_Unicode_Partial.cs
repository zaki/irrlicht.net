using System;
using System.Runtime.InteropServices;
using System.Security;

namespace IrrlichtNET
{
    public partial class IrrlichtDevice : NativeElement
    {
        public string WindowCaptionW
        {
            set
            {
#if !LINUX
                Device_SetWindowCaptionW(_raw, value);
#else
                Device_SetWindowCaption(_raw, value);
#endif
            }
        }
        [DllImport(Native.Dll, CharSet = CharSet.Unicode), SuppressUnmanagedCodeSecurity]
        static extern void Device_SetWindowCaptionW(IntPtr raw, string caption);
    }
    public partial class GUIElement : NativeElement
    {
        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void GuiElem_SetToolTipTextW(IntPtr elem, string text);
        public string ToolTipTextW
        {
            get
            {
                try
                {
                    return GuiElem_GetToolTipText(_raw);
                }
                catch (Exception)
                {
                    return "";
                }
            }
            set
            {
#if !LINUX
                GuiElem_SetToolTipTextW(_raw, value);
#else
                GuiElem_SetToolTipText(_raw, value);
#endif
            }
        }
        [DllImport(Native.Dll, CharSet = CharSet.Unicode), SuppressUnmanagedCodeSecurity]
        static extern void GuiElem_SetTextW(IntPtr elem, string text);
        public virtual string TextW
        {
            get
            {
                return GuiElem_GetText(_raw);
            }
            set
            {
#if !LINUX
                GuiElem_SetTextW(_raw, value);
#else
                GuiElem_SetText(_raw, value);
#endif
            }
        }
    }
    public partial class SceneManager : NativeElement
    {
        [DllImport(Native.Dll, CharSet = CharSet.Unicode), SuppressUnmanagedCodeSecurity]
        static extern IntPtr SceneManager_AddTextSceneNodeW(IntPtr scenemanager, IntPtr font, string text, int[] color, IntPtr parent);
        public TextSceneNode AddTextSceneNodeW(GUIFont font, string text, Color color, SceneNode parent)
        {
            IntPtr par = IntPtr.Zero;
            if (parent != null)
                par = parent.Raw;
#if !LINUX
            return (TextSceneNode)
                NativeElement.GetObject(SceneManager_AddTextSceneNodeW(_raw, font.Raw, text, color.ToUnmanaged(), par),
                                        typeof(TextSceneNode));
#else
            return (TextSceneNode)
                NativeElement.GetObject(SceneManager_AddTextSceneNode(_raw, font.Raw, text, color.ToUnmanaged(), par),
                                        typeof(TextSceneNode));
#endif
        }
        [DllImport(Native.Dll, CharSet = CharSet.Unicode), SuppressUnmanagedCodeSecurity]
        static extern IntPtr SceneManager_AddTextSceneNode2W(IntPtr scenemanager, IntPtr font, string text, IntPtr parent, float[] size, float[] pos, int ID, int[] shade_top, int[] shade_down);
        public TextSceneNode AddBillboardTextSceneNodeW(GUIFont font, string text, SceneNode parent, Dimension2Df size, Vector3D position, int id, Color shade_top, Color shade_down)
        {
            IntPtr par = IntPtr.Zero;
            if (parent != null)
                par = parent.Raw;
#if !LINUX
            return (TextSceneNode)
                NativeElement.GetObject(SceneManager_AddTextSceneNode2W(_raw, font.Raw, text, par, size.ToUnmanaged(), position.ToUnmanaged(),
                                                                id, shade_top.ToUnmanaged(), shade_down.ToUnmanaged()),
                                        typeof(TextSceneNode));
#else
            return (TextSceneNode)
                NativeElement.GetObject(SceneManager_AddTextSceneNode2(_raw, font.Raw, text, par, size.ToUnmanaged(), position.ToUnmanaged(),
                                                                id, shade_top.ToUnmanaged(), shade_down.ToUnmanaged()),
                                        typeof(TextSceneNode));
#endif
        }
    }
    public partial class TextSceneNode : SceneNode
    {
        [DllImport(Native.Dll, CharSet = CharSet.Unicode), SuppressUnmanagedCodeSecurity]
        static extern void TextSceneNode_SetTextW(IntPtr text, string ctext);

        public string TextW
        {
            set
            {
#if !LINUX
                TextSceneNode_SetTextW(_raw, value);
#else
                TextSceneNode_SetText(_raw, value);
#endif
            }
        }
    }
    public partial class GUIFont : NativeElement
    {
        [DllImport(Native.Dll, CharSet = CharSet.Unicode), SuppressUnmanagedCodeSecurity]
        static extern void GUIFont_DrawW(IntPtr font, string text, int[] pos, int[] color, bool hcenter, bool vcenter, int[] clip);

        public void DrawW(string text, Position2D pos, Color color, bool hcenter, bool vcenter, Rect cliprect)
        {
#if !LINUX
            GUIFont_DrawW(_raw, text, pos.ToUnmanaged(), color.ToUnmanaged(), hcenter, vcenter, cliprect.ToUnmanaged());
#else
            GUIFont_Draw(_raw, text, pos.ToUnmanaged(), color.ToUnmanaged(), hcenter, vcenter, cliprect.ToUnmanaged());
#endif
        }

        public void DrawW(string text, Position2D pos, Color color, bool hcenter, bool vcenter)
        {
#if !LINUX
            GUIFont_DrawW(_raw, text, pos.ToUnmanaged(), color.ToUnmanaged(), hcenter, vcenter, null);
#else
            GUIFont_Draw(_raw, text, pos.ToUnmanaged(), color.ToUnmanaged(), hcenter, vcenter, null);
#endif
        }

        public void DrawW(string text, Rect rect, Color color, bool hcenter, bool vcenter, Rect cliprect)
        {
#if !LINUX
            GUIFont_DrawW(_raw, text, rect.ToUnmanaged(), color.ToUnmanaged(), hcenter, vcenter, cliprect.ToUnmanaged());
#else
            GUIFont_Draw(_raw, text, rect.ToUnmanaged(), color.ToUnmanaged(), hcenter, vcenter, cliprect.ToUnmanaged());
#endif
        }

        public void DrawW(string text, Rect rect, Color color, bool hcenter, bool vcenter)
        {
#if !LINUX
            GUIFont_DrawW(_raw, text, rect.ToUnmanaged(), color.ToUnmanaged(), hcenter, vcenter, null);
#else
            GUIFont_Draw(_raw, text, rect.ToUnmanaged(), color.ToUnmanaged(), hcenter, vcenter, null);
#endif
        }
    }

    public partial class GUIEnvironment : NativeElement
    {
        [DllImport(Native.Dll, CharSet = CharSet.Unicode), SuppressUnmanagedCodeSecurity]
        static extern IntPtr GuiEnv_AddStaticTextW(IntPtr guienv, string text, int[] rectangle, bool border, bool wordWrap, IntPtr parent, int id, bool fillBackground);
        public GUIStaticText AddStaticTextW(string text, Rect rectangle, bool border, bool wordWrap, GUIElement parent, int id, bool fillBackground)
        {
#if !LINUX
            return (GUIStaticText)NativeElement.GetObject(GuiEnv_AddStaticTextW(_raw, text, rectangle.ToUnmanaged(), border, wordWrap, GetParent(parent), id, fillBackground),
                                                      typeof(GUIStaticText));
#else
            return (GUIStaticText)NativeElement.GetObject(GuiEnv_AddStaticText(_raw, text, rectangle.ToUnmanaged(), border, wordWrap, GetParent(parent), id, fillBackground), typeof(GUIStaticText));
#endif
        }

        [DllImport(Native.Dll, CharSet = CharSet.Unicode), SuppressUnmanagedCodeSecurity]
        static extern IntPtr GuiEnv_AddButtonW(IntPtr guienv, int[] rectangle, IntPtr parent, int id, string text);
        public GUIButton AddButtonW(Rect rectangle, GUIElement parent, int id, string text)
        {
#if !LINUX
            return (GUIButton)NativeElement.GetObject(GuiEnv_AddButtonW(_raw, rectangle.ToUnmanaged(), GetParent(parent), id, text),
                                                      typeof(GUIButton));
#else
            return (GUIButton)NativeElement.GetObject(GuiEnv_AddButton(_raw, rectangle.ToUnmanaged(), GetParent(parent), id, text),
                                                      typeof(GUIButton));
#endif
        }

        [DllImport(Native.Dll, CharSet = CharSet.Unicode), SuppressUnmanagedCodeSecurity]
        static extern IntPtr GuiEnv_AddEditBoxW(IntPtr guienv, string text, int[] rectangle, bool border, IntPtr parent, int id);
        public GUIEditBox AddEditBoxW(string text, Rect rectangle, bool border, GUIElement parent, int id)
        {
#if !LINUX
            return (GUIEditBox)NativeElement.GetObject(GuiEnv_AddEditBoxW(_raw, text, rectangle.ToUnmanaged(), border, GetParent(parent), id),
                                                      typeof(GUIEditBox));
#else
            return (GUIEditBox)NativeElement.GetObject(GuiEnv_AddEditBox(_raw, text, rectangle.ToUnmanaged(), border, GetParent(parent), id),
                                                      typeof(GUIEditBox));
#endif
        }

        [DllImport(Native.Dll, CharSet = CharSet.Unicode), SuppressUnmanagedCodeSecurity]
        static extern IntPtr GuiEnv_AddWindowW(IntPtr guienv, int[] rectangle, bool modal, string text, IntPtr parent, int id);
        public GUIWindow AddWindowW(Rect rectangle, bool modal, string text, GUIElement parent, int id)
        {
#if !LINUX
            return (GUIWindow)NativeElement.GetObject(GuiEnv_AddWindowW(_raw, rectangle.ToUnmanaged(), modal, text, GetParent(parent), id),
                                                      typeof(GUIWindow));
#else
            return (GUIWindow)NativeElement.GetObject(GuiEnv_AddWindow(_raw, rectangle.ToUnmanaged(), modal, text, GetParent(parent), id),
                                                      typeof(GUIWindow));
#endif
        }

    }

    public partial class GUIListBox : GUIElement
    {
        [DllImport(Native.Dll, CharSet = CharSet.Unicode), SuppressUnmanagedCodeSecurity]
        static extern int GUIListBox_AddItemW(IntPtr listb, string text, int icon);

        [DllImport(Native.Dll, CharSet = CharSet.Unicode), SuppressUnmanagedCodeSecurity]
        static extern int GUIListBox_AddItemAW(IntPtr listb, string text);

        public int AddItemW(string text, int icon)
        {
#if !LINUX
            return GUIListBox_AddItemW(_raw, text, icon);
#else
            return GUIListBox_AddItem(_raw, text, icon);
#endif
        }

        public int AddItemW(string text)
        {
#if !LINUX
            return GUIListBox_AddItemAW(_raw, text);
#else
            return GUIListBox_AddItemA(_raw, text);
#endif
        }
    }

    public partial class GUITabControl : GUIElement
    {
        [DllImport(Native.Dll, CharSet = CharSet.Unicode), SuppressUnmanagedCodeSecurity]
        static extern IntPtr GUITabControl_AddTabW(IntPtr guienv, string text, int icon);
        public GUITab AddTabW(string caption, int id)
        {
#if !LINUX
            return (GUITab)NativeElement.GetObject(GUITabControl_AddTabW(_raw, caption, id),
                                                      typeof(GUITab));
#else
            return (GUITab)NativeElement.GetObject(GUITabControl_AddTab(_raw, caption, id),
                                                      typeof(GUITab));
#endif
        }
    }
}
