using System;
using System.Runtime.InteropServices;
using System.Security;

namespace IrrlichtNET
{
    public partial class GUIElement : NativeElement
    {
        public GUIElement(IntPtr raw)
            : base(raw)
        {
        }

        /// <summary>
        /// Use this constructor only if you know,
        /// what you're doing! Remember this!
        /// </summary>
        public GUIElement()
            : base()
        {
        }

        public virtual void AddChild(GUIElement child)
        {
            GuiElem_AddChild(_raw, child.Raw);
        }

        public bool BringToFront(GUIElement elem)
        {
            return GuiElem_BringToFront(_raw, elem.Raw);
        }

        public virtual void Draw()
        {
            GuiElem_Draw(_raw);
        }

        public GUIElement GetElementFromID(int id, bool searchchildren)
        {
            return (GUIElement)NativeElement.GetObject(GuiElem_GetElementFromID(_raw, id, searchchildren),
                                                       typeof(GUIElement));
        }

        public string ToolTipText
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
                GuiElem_SetToolTipText(_raw, value);
            }
        }

        public GUIElement GetElementFromPoint(Position2D point)
        {
            return (GUIElement)NativeElement.GetObject(GuiElem_GetElementFromPoint(_raw, point.ToUnmanaged()),
                                                       typeof(GUIElement));
        }

        public virtual void Move(Position2D absolutemovement)
        {
            GuiElem_Move(_raw, absolutemovement.ToUnmanaged());
        }

        public virtual bool OnEvent(Event customevent)
        {
            return GuiElem_OnEvent(_raw, customevent.Raw);
        }

        public virtual void Remove()
        {

            RemoveFromElements(this);
            GuiElem_Remove(_raw);
        }

        private void RemoveFromElements(GUIElement node)
        {
            if (NativeElement.Elements.ContainsKey(node.Raw))
            {
                NativeElement.Elements.Remove(node.Raw);
            }
            else
            {
                //throw new Exception("Element was stale!!!!");
            }

            foreach (GUIElement cnode in node.Children)
            {
                System.Diagnostics.Debug.WriteLine("Deleting child nodes for GUI: " + node.Raw + " Elements remaining: " + NativeElement.Elements.Count);
                RemoveFromElements(cnode);
            }
        }

        public virtual void RemoveChild(GUIElement child)
        {
            GuiElem_RemoveChild(_raw, child.Raw);
        }

        public virtual void UpdateAbsolutePosition()
        {
            GuiElem_UpdateAbsolutePosition(_raw);
        }

        public virtual void OnPostRender(uint timeMs)
        {
            GuiElem_OnPostRender(_raw, timeMs);
        }

        public Rect AbsolutePosition
        {
            get
            {
                int[] rect = new int[4];
                GuiElem_GetAbsolutePosition(_raw, rect);
                return Rect.FromUnmanaged(rect);
            }
        }

        public GUIElement[] Children
        {
            get
            {
                uint size = GuiElem_GetChildrenCount(_raw);
                IntPtr[] rawlist = new IntPtr[size];
                GuiElem_GetChildren(_raw, rawlist);
                GUIElement[] tor = new GUIElement[rawlist.Length];
                for (int i = 0; i < rawlist.Length; i++)
                    tor[i] = (GUIElement)NativeElement.GetObject(rawlist[i], typeof(GUIElement));
                return tor;
            }
        }

        public virtual void SetAlignment(Alignment left, Alignment right, Alignment top,
                                     Alignment bottom)
        {
            int[] tor = new int[4];
            tor[0] = (int)left;
            tor[1] = (int)right;
            tor[2] = (int)top;
            tor[3] = (int)bottom;

            GuiElem_SetAlignment(_raw, tor);

        }

        public virtual bool Enabled
        {
            get
            {
                return GuiElem_IsEnabled(_raw);
            }
            set
            {
                GuiElem_SetEnabled(_raw, value);
            }
        }

        public virtual int ID
        {
            get
            {
                return GuiElem_GetID(_raw);
            }
            set
            {
                GuiElem_SetID(_raw, value);
            }
        }

        public virtual GUIElement Parent
        {
            get
            {
                return (GUIElement)NativeElement.GetObject(GuiElem_GetParent(_raw), typeof(GUIElement));
            }
        }

        public Rect RelativePosition
        {
            get
            {
                int[] rect = new int[4];
                GuiElem_GetRelativePosition(_raw, rect);
                return Rect.FromUnmanaged(rect);
            }
            set
            {
                GuiElem_SetRelativePosition(_raw, value.ToUnmanaged());
            }
        }

        public virtual string Text
        {
            get
            {
                IntPtr ptr_value = IntPtr.Zero;
                string value;
                try
                {
                    ptr_value = GuiElem_GetText(_raw);
                    value = IrrStringMarshal.IntPtrToString(ptr_value);
                }
                catch (Exception)
                {
                    return "Error!";
                }

                return value;
            }
            set
            {
                GuiElem_SetText(_raw, value);
            }
        }

        public virtual bool Visible
        {
            get
            {
                return GuiElem_IsVisible(_raw);
            }
            set
            {
                GuiElem_SetVisible(_raw, value);
            }
        }

        public virtual ElementType Type
        {
            get
            {
                return GuiElem_GetType(_raw);
            }
        }

        public virtual void SetMaxSize(Dimension2D size)
        {
            GuiElem_SetMaxSize(_raw, size.ToUnmanaged());
        }

        public virtual void SetMinSize(Dimension2D size)
        {
            GuiElem_SetMinSize(_raw, size.ToUnmanaged());
        }

        /// <value>
        /// Is the element clipped by parent's clip rectangle
        /// </value>
        public virtual bool Noclip
        {
            get { return GuiElem_GetNotClipped(_raw); }
            set
            {
                GuiElem_SetNotClipped(_raw, value);
            }
        }



        #region Native Invokes
        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void GuiElem_AddChild(IntPtr elem, IntPtr child);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern bool GuiElem_BringToFront(IntPtr elem, IntPtr element);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void GuiElem_Draw(IntPtr elem);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void GuiElem_GetAbsolutePosition(IntPtr elem, [MarshalAs(UnmanagedType.LPArray)] int[] pos);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void GuiElem_GetChildren(IntPtr elem, [MarshalAs(UnmanagedType.LPArray)] IntPtr[] list);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern uint GuiElem_GetChildrenCount(IntPtr elem);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr GuiElem_GetElementFromID(IntPtr elem, int id, bool searchchildren);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr GuiElem_GetElementFromPoint(IntPtr elem, int[] point);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern int GuiElem_GetID(IntPtr elem);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr GuiElem_GetParent(IntPtr elem);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void GuiElem_GetRelativePosition(IntPtr elem, int[] pos);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void GuiElem_SetToolTipText(IntPtr elem, string text);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern string GuiElem_GetToolTipText(IntPtr elem);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr GuiElem_GetText(IntPtr elem);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern ElementType GuiElem_GetType(IntPtr elem);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern bool GuiElem_IsEnabled(IntPtr elem);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern bool GuiElem_IsVisible(IntPtr elem);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void GuiElem_Move(IntPtr elem, int[] absolutemovement);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern bool GuiElem_OnEvent(IntPtr elem, IntPtr ev);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void GuiElem_Remove(IntPtr elem);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void GuiElem_RemoveChild(IntPtr elem, IntPtr child);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void GuiElem_SetEnabled(IntPtr elem, bool enabled);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void GuiElem_SetID(IntPtr elem, int id);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void GuiElem_SetRelativePosition(IntPtr elem, int[] pos);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void GuiElem_SetText(IntPtr elem, string text);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void GuiElem_SetVisible(IntPtr elem, bool visible);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void GuiElem_UpdateAbsolutePosition(IntPtr elem);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void GuiElem_OnPostRender(IntPtr elem, uint timeMs);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void GuiElem_SetAlignment(IntPtr elem, int[] align);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void GuiElem_SetMaxSize(IntPtr elem, int[] size);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void GuiElem_SetMinSize(IntPtr elem, int[] size);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void GuiElem_SetNotClipped(IntPtr elem, bool noClip);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern bool GuiElem_GetNotClipped(IntPtr elem);
        #endregion
    }

    public enum Alignment
    {
        UpperLeft = 0,
        LowerRight,
        Center,
        Scale
    }

    public enum ElementType
    {
        Button,
        CheckBox,
        ComboBox,
        ContextMenu,
        Menu,
        EditBox,
        FileOpenDialog,
        ColorSelectDialog,
        InOutFader,
        Image,
        ListBox,
        MeshViewer,
        MessageBox,
        ModalScreen,
        ScrollBar,
        SpinBox,
        StaticText,
        Tab,
        TabControl,
        Table,
        ToolBar,
        TreeView,
        Window,
        Count,
        Element
    }
}
