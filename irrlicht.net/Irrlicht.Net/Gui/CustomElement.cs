using System;
using System.Runtime.InteropServices;
using System.Security;

namespace IrrlichtNET.Inheritable
{


    public class IGUIElement : GUIElement
    {

        private delegate void CGE_CALLBACK_VOID(CGE_VOID_METHOD method, IntPtr arg1, int arg2, uint arg3, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] int[] arg4);

        private delegate int CGE_CALLBACK_INT(CGE_INT_METHOD method, IntPtr arg1, int arg2, uint arg3, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] int[] arg4);

        private delegate IntPtr CGE_CALLBACK_INTPTR(CGE_INTPTR_METHOD method, IntPtr arg1, int arg2);

        private CGE_CALLBACK_VOID antigc1;
        private CGE_CALLBACK_INT antigc2;
        private CGE_CALLBACK_INTPTR antigc3;

        public IGUIElement(IntPtr raw)
            : base(raw)
        {
        }

        public IGUIElement(GUIEnvironment guienv, GUIElement parent, int id,
                            Rect rect)
        {
            antigc1 = OnCallbackVoid;
            antigc2 = OnCallbackInt;
            antigc3 = OnCallbackIntptr;

            Initialize(CGE_CREATE(guienv.Raw,
                                   parent == null ? guienv.RootElement.Raw : parent.Raw,
                                   id,
                                   rect.ToUnmanaged(),
                                   antigc1,
                                   antigc2,
                                   antigc3));

        }

        private void OnCallbackVoid(CGE_VOID_METHOD method, IntPtr arg1, int arg2, uint arg3, int[] arg4)
        {
            switch (method)
            {
                case CGE_VOID_METHOD.ADD_CHILD:
                    AddChild((GUIElement)NativeElement.GetObject(arg1, typeof(GUIElement)));
                    break;
                case CGE_VOID_METHOD.DRAW:
                    Draw();
                    break;
                case CGE_VOID_METHOD.MOVE:
                    Move(Position2D.FromUnmanaged(arg4));
                    break;
                case CGE_VOID_METHOD.ON_POST_RENDER:
                    OnPostRender(arg3);
                    break;
                case CGE_VOID_METHOD.REMOVE_CHILD:
                    RemoveChild((GUIElement)NativeElement.GetObject(arg1, typeof(GUIElement)));
                    break;
                case CGE_VOID_METHOD.SET_ENABLED:
                    Enabled = arg2 == 0 ? false : true;
                    break;
                case CGE_VOID_METHOD.SET_ALIGNMENT:
                    SetAlignment((Alignment)arg4[0],
                                 (Alignment)arg4[1],
                                 (Alignment)arg4[2],
                                 (Alignment)arg4[3]);
                    break;
                case CGE_VOID_METHOD.SET_ID:
                    ID = arg2;
                    break;

                case CGE_VOID_METHOD.SET_MAX_SIZE:
                    SetMaxSize(Dimension2D.FromUnmanaged(arg4));
                    break;

                case CGE_VOID_METHOD.SET_MIN_SIZE:
                    SetMinSize(Dimension2D.FromUnmanaged(arg4));
                    break;

                case CGE_VOID_METHOD.SET_NOT_CLIPPED:
                    Noclip = arg2 == 0 ? false : true;
                    break;
                case CGE_VOID_METHOD.UPDATE_ABSOLUTE_POSITION:
                    UpdateAbsolutePosition();
                    break;

                case CGE_VOID_METHOD.SET_TEXT:
                    Text = IrrStringMarshal.IntPtrToString(arg1);
                    break;

            }
        }

        private int OnCallbackInt(CGE_INT_METHOD method, IntPtr arg1, int arg2, uint arg3, int[] arg4)
        {
            switch (method)
            {
                case CGE_INT_METHOD.ON_EVENT:
                    return OnEvent((Event)NativeElement.GetObject(arg1, typeof(Event))) == true ? 1 : 0;

                case CGE_INT_METHOD.IS_ENABLED:
                    return Enabled == true ? 1 : 0;

                case CGE_INT_METHOD.GET_ID:
                    return ID;

                case CGE_INT_METHOD.GET_NOCLIP:
                    return Noclip == true ? 1 : 0;

                case CGE_INT_METHOD.GET_TYPE:
                    return (int)Type;

            }

            return 0;
        }

        private IntPtr OnCallbackIntptr(CGE_INTPTR_METHOD method, IntPtr arg1, int arg2)
        {
            switch (method)
            {
                case CGE_INTPTR_METHOD.GET_PARENT:
                    return Parent.Raw;

                case CGE_INTPTR_METHOD.GET_TEXT:
                    return Marshal.StringToCoTaskMemUni(Text);

            }

            return IntPtr.Zero;
        }

        #region Managed => Unmanaged

        public override void AddChild(GUIElement child)
        {
            CGE_PVOID_METHODS(_raw, CGE_VOID_METHOD.ADD_CHILD, child.Raw, 0, 0, null);
        }

        public override void Draw()
        {
            CGE_PVOID_METHODS(_raw, CGE_VOID_METHOD.DRAW, IntPtr.Zero, 0, 0, null);
        }

        public override void Move(Position2D absolutemovement)
        {
            CGE_PVOID_METHODS(_raw, CGE_VOID_METHOD.MOVE, IntPtr.Zero, 0, 0, absolutemovement.ToUnmanaged());
        }

        public override void OnPostRender(uint timeMs)
        {
            CGE_PVOID_METHODS(_raw, CGE_VOID_METHOD.ON_POST_RENDER, IntPtr.Zero, 0, timeMs, null);
        }

        public override void Remove()
        {
            CGE_PVOID_METHODS(_raw, CGE_VOID_METHOD.REMOVE, IntPtr.Zero, 0, 0, null);
        }

        public override void RemoveChild(GUIElement child)
        {
            CGE_PVOID_METHODS(_raw, CGE_VOID_METHOD.REMOVE_CHILD,
                              child == null ? IntPtr.Zero : child.Raw, 0, 0, null);
        }

        public override bool Enabled
        {
            get { return CGE_PINT_METHODS(_raw, CGE_INT_METHOD.IS_ENABLED, IntPtr.Zero, 0, 0, null) == 0 ? false : true; }
            set
            {
                CGE_PVOID_METHODS(_raw, CGE_VOID_METHOD.SET_ENABLED, IntPtr.Zero,
                                      value == true ? 1 : 0, 0, null);
            }
        }

        public override void SetAlignment(Alignment left, Alignment right, Alignment top, Alignment bottom)
        {
            int[] tor = new int[4];
            tor[0] = (int)left;
            tor[1] = (int)right;
            tor[2] = (int)top;
            tor[3] = (int)bottom;
            CGE_PVOID_METHODS(_raw, CGE_VOID_METHOD.SET_ALIGNMENT, IntPtr.Zero, 0, 0, tor);
        }

        public override int ID
        {
            get { return CGE_PINT_METHODS(_raw, CGE_INT_METHOD.GET_ID, IntPtr.Zero, 0, 0, null); }
            set { CGE_PVOID_METHODS(_raw, CGE_VOID_METHOD.SET_ID, IntPtr.Zero, value, 0, null); }
        }

        public override void SetMaxSize(Dimension2D size)
        {
            CGE_PVOID_METHODS(_raw, CGE_VOID_METHOD.SET_MAX_SIZE, IntPtr.Zero, 0, 0, size.ToUnmanaged());
        }

        public override void SetMinSize(Dimension2D size)
        {
            CGE_PVOID_METHODS(_raw, CGE_VOID_METHOD.SET_MIN_SIZE, IntPtr.Zero, 0, 0, size.ToUnmanaged());
        }

        public override bool Noclip
        {
            get
            {
                return CGE_PINT_METHODS(_raw, CGE_INT_METHOD.GET_NOCLIP, IntPtr.Zero, 0,
                                            0, null) == 0 ? false : true;
            }
            set
            {
                CGE_PVOID_METHODS(_raw, CGE_VOID_METHOD.SET_NOT_CLIPPED, IntPtr.Zero,
                                      value == true ? 1 : 0, 0, null);
            }
        }

        public override bool OnEvent(Event ev)
        {
            return CGE_PINT_METHODS(_raw, CGE_INT_METHOD.ON_EVENT, ev.Raw, 0, 0, null) == 0 ? false : true;
        }

        public override ElementType Type
        {
            get { return (ElementType)CGE_PINT_METHODS(_raw, CGE_INT_METHOD.GET_TYPE, IntPtr.Zero, 0, 0, null); }
        }

        public override void UpdateAbsolutePosition()
        {
            CGE_PVOID_METHODS(_raw, CGE_VOID_METHOD.UPDATE_ABSOLUTE_POSITION, IntPtr.Zero,
                              0, 0, null);
        }

        public override bool Visible
        {
            get { return CGE_PINT_METHODS(_raw, CGE_INT_METHOD.GET_VISIBLE, IntPtr.Zero, 0, 0, null) == 0 ? false : true; }
            set { CGE_PVOID_METHODS(_raw, CGE_VOID_METHOD.SET_VISIBLE, IntPtr.Zero, value ? 1 : 0, 0, null); }
        }

        public override GUIElement Parent
        {
            get { return (GUIElement)NativeElement.GetObject(CGE_PINTPTR_METHODS(_raw, CGE_INTPTR_METHOD.GET_PARENT, IntPtr.Zero, 0), typeof(GUIElement)); }
        }

        public override string Text
        {
            get { return IrrStringMarshal.IntPtrToString(CGE_PINTPTR_METHODS(_raw, CGE_INTPTR_METHOD.GET_TEXT, IntPtr.Zero, 0)); }
            set { CGE_PVOID_METHODS(_raw, CGE_VOID_METHOD.SET_TEXT, Marshal.StringToCoTaskMemUni(value), 0, 0, null); }
        }



        #endregion

        #region Native Imports
        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr CGE_CREATE(IntPtr guienv, IntPtr parent, int id, int[] rect, CGE_CALLBACK_VOID _void, CGE_CALLBACK_INT _int, CGE_CALLBACK_INTPTR _intptr);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void CGE_PVOID_METHODS(IntPtr cge, CGE_VOID_METHOD method, IntPtr arg1, int arg2, uint arg3, int[] arg4);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern int CGE_PINT_METHODS(IntPtr cge, CGE_INT_METHOD method, IntPtr arg1, int arg2, uint arg3, int[] arg4);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr CGE_PINTPTR_METHODS(IntPtr cge, CGE_INTPTR_METHOD method, IntPtr arg1, int arg2);

        #endregion

    }

    internal enum CGE_VOID_METHOD
    {
        ADD_CHILD = 0,
        DRAW,
        MOVE,
        ON_POST_RENDER,
        REMOVE,
        REMOVE_CHILD,
        SET_ALIGNMENT,
        SET_ENABLED,
        SET_ID,
        SET_MAX_SIZE,
        SET_MIN_SIZE,
        SET_NOT_CLIPPED,
        SET_RELATIVE_POSITION,
        SET_SUBELEMENT,
        SET_TAB_GROUP,
        SET_TAB_ORDER,
        SET_TAB_STOP,
        SET_TEXT,
        SET_TOOL_TIP_TEXT,
        SET_VISIBLE,
        UPDATE_ABSOLUTE_POSITION,
    }

    internal enum CGE_INT_METHOD
    {
        ON_EVENT = 0,
        IS_ENABLED,
        GET_ID,
        GET_NOCLIP,
        GET_TYPE,
        GET_VISIBLE,
        IS_SUBELEMENT
    }

    internal enum CGE_INTPTR_METHOD
    {
        GET_PARENT = 0,
        GET_TEXT
    }

}
