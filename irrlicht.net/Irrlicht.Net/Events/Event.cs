using System;
using System.Runtime.InteropServices;
using System.Security;

namespace IrrlichtNETCP
{
    public class Event
    {
        protected IntPtr _raw = IntPtr.Zero;
        public IntPtr Raw { get { return (_raw); } set { _raw = value; } }

        // Empty constructor is forbidden, we must not create our own events here
        /*
            public Event()
            {
                _raw = Event_Create();
            }
         */
        // The event struct will get released in Irrlicht native code (see WndProc)
        public Event(IntPtr raw)
        { _raw = raw; }

        //        public void Dispose()
        //        {
        //            Event_Release(_raw);
        //        }

        public EventType Type
        {
            get
            {
                return Event_GetType(_raw);
            }

            set
            {
                Event_SetType(_raw, (int)value);
            }
        }

        public MouseInputEvent MouseInputEvent
        {
            get
            {
                return Event_GetMouseInputEvent(_raw);
            }
        }

        public GUIEventType GUIEvent
        {
            get
            {
                return Event_GetGUIEventType(_raw);
            }
        }

        public float MouseWheelDelta
        {
            get
            {
                return Event_GetMouseWheelDelta(_raw);
            }
        }

        public Position2D MousePosition
        {
            get
            {
                int[] pos = new int[2];
                Event_GetMousePosition(_raw, pos);
                return Position2D.FromUnmanaged(pos);
            }
        }

        public KeyCode KeyCode
        {
            get
            {
                return Event_GetKey(_raw);
            }
        }

        public bool KeyPressedDown
        {
            get
            {
                return Event_GetKeyPressedDown(_raw);
            }
        }

        public bool KeyShift
        {
            get
            {
                return Event_GetKeyShift(_raw);
            }
        }

        public bool KeyControl
        {
            get
            {
                return Event_GetKeyControl(_raw);
            }
        }

        public char Key
        {
            get
            {
                return Event_GetKeyChar(_raw);
            }
        }

        public string LogText
        {
            get
            {
                byte[] str = new byte[1024];
                Event_GetLogString(_raw, str);
                string tor = string.Empty;
                for (int i = 0; i < 1024; i++)
                    if (str[i] == 0)
                        break;
                    else
                        tor += (char)(str[i]);
                return tor;
            }
        }

        public GUIElement Caller
        {
            get
            {
                return (GUIElement)
                    NativeElement.GetObject(Event_GetCaller(_raw),
                                     typeof(GUIElement));
            }
        }

        public int UserData1
        {
            get
            {
                return Event_GetUserDataI(_raw, 0);
            }
            set
            {
                Event_SetUserDataI(_raw, 0, value);
            }
        }

        public int UserData2
        {
            get
            {
                return Event_GetUserDataI(_raw, 1);
            }
            set
            {
                Event_SetUserDataI(_raw, 1, value);
            }
        }

        public float UserData3
        {
            get
            {
                return Event_GetUserDataF(_raw);
            }
            set
            {
                Event_SetUserDataF(_raw, value);
            }
        }

        #region Native Invokes
        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr Event_Create();

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern EventType Event_GetType(IntPtr ev);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern EventType Event_SetType(IntPtr ev, int evtype);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern MouseInputEvent Event_GetMouseInputEvent(IntPtr ev);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern GUIEventType Event_GetGUIEventType(IntPtr ev);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern float Event_GetMouseWheelDelta(IntPtr ev);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void Event_GetMousePosition(IntPtr ev, [MarshalAs(UnmanagedType.LPArray)] int[] pos);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern KeyCode Event_GetKey(IntPtr ev);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern bool Event_GetKeyPressedDown(IntPtr ev);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern bool Event_GetKeyShift(IntPtr ev);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern bool Event_GetKeyControl(IntPtr ev);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern char Event_GetKeyChar(IntPtr ev);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void Event_GetLogString(IntPtr ev, [MarshalAs(UnmanagedType.LPArray)] byte[] cs);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr Event_GetCaller(IntPtr ev);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void Event_SetUserDataI(IntPtr ev, byte num, int data);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void Event_SetUserDataF(IntPtr ev, float data);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern int Event_GetUserDataI(IntPtr ev, byte num);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern float Event_GetUserDataF(IntPtr ev);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern float Event_Release(IntPtr ev);

        #endregion
    }

    public enum EventType
    {
        GUIEvent,
        MouseInputEvent,
        KeyInputEvent,
        JoystickInputEvent,
        LogTextEvent,
        UserEvent
    }

    public enum MouseInputEvent
    {
        LMousePressedDown,
        RMousePressedDown,
        MMousePressedDown,
        LMouseLeftUp,
        RMouseLeftUp,
        MMouseLeftUp,
        MouseMoved,
        MouseWheel,
        MouseDoubleClick,
        MouseTripleClick
    }

    public enum GUIEventType
    {
        ElementFocusLost,
        ElementFocused,
        ElementHovered,
        ElementLeft,
        ElementClosed,
        ButtonClicked,
        ScrollBarChanged,
        CheckBoxChanged,
        ListBoxChanged,
        ListBoxSelectedAgain,
        FileSelected,
        DirectorySelected,
        FileChooseDialogCancelled,
        MessageBoxYes,
        MessageBoxNo,
        MessageBoxOK,
        MessageBoxCancel,
        EditBoxEnter,
        EditBoxChanged,
        EditBoxMarkingChanged,
        TabChanged,
        MenuItemSelected,
        ComboBoxChanged,
        SpinBoxChanged,
        TableChanged,
        TableHeaderChanged,
        TableSelectedAgain,
        TreeviewNodeDeselect,
        TreeviewNodeSelect,
        TreeviewNodeExpand,
        TreeviewNodeCollapse
    }

    public enum KeyCode
    {
        LButton = 0x01,  // Left mouse button
        RButton = 0x02,  // Right mouse button
        Cancel = 0x03,  // Control-break processing
        MButton = 0x04,  // Middle mouse button (three-button mouse)
        XButton1 = 0x05,  // Windows 2000/XP: X1 mouse button
        XButton2 = 0x06,  // Windows 2000/XP: X2 mouse button
        Back = 0x08,  // BACKSPACE key
        Tab = 0x09,  // TAB key
        Clear = 0x0C,  // CLEAR key
        Return = 0x0D,  // ENTER key
        Shift = 0x10,  // SHIFT key
        Control = 0x11,  // CTRL key
        Menu = 0x12,  // ALT key
        Pause = 0x13,  // PAUSE key
        Capital = 0x14,  // CAPS LOCK key
        Kana = 0x15,  // IME Kana mode
        Hanguel = 0x15,  // IME Hanguel mode (maintained for compatibility use KEY_HANGUL)
        Hangul = 0x15,  // IME Hangul mode
        Junja = 0x17,  // IME Junja mode
        Final = 0x18,  // IME final mode
        Hanja = 0x19,  // IME Hanja mode
        Kanji = 0x19,  // IME Kanji mode
        Escape = 0x1B,  // ESC key
        Convert = 0x1C,  // IME convert
        NonConvert = 0x1D,  // IME nonconvert
        Accept = 0x1E,  // IME accept
        ModeChange = 0x1F,  // IME mode change request
        Space = 0x20,  // SPACEBAR
        Prior = 0x21,  // PAGE UP key
        Next = 0x22,  // PAGE DOWN key
        End = 0x23,  // END key
        Home = 0x24,  // HOME key
        Left = 0x25,  // LEFT ARROW key
        Up = 0x26,  // UP ARROW key
        Right = 0x27,  // RIGHT ARROW key
        Down = 0x28,  // DOWN ARROW key
        Select = 0x29,  // SELECT key
        Print = 0x2A,  // PRINT key
        Execute = 0x2B,  // EXECUTE key
        Snapshot = 0x2C,  // PRINT SCREEN key
        Insert = 0x2D,  // INS key
        Delete = 0x2E,  // DEL key
        Help = 0x2F,  // HELP key
        Key_0 = 0x30,  // 0 key
        Key_1 = 0x31,  // 1 key
        Key_2 = 0x32,  // 2 key
        Key_3 = 0x33,  // 3 key
        Key_4 = 0x34,  // 4 key
        Key_5 = 0x35,  // 5 key
        Key_6 = 0x36,  // 6 key
        Key_7 = 0x37,  // 7 key
        Key_8 = 0x38,  // 8 key
        Key_9 = 0x39,  // 9 key
        Key_A = 0x41,  // A key
        Key_B = 0x42,  // B key
        Key_C = 0x43,  // C key
        Key_D = 0x44,  // D key
        Key_E = 0x45,  // E key
        Key_F = 0x46,  // F key
        Key_G = 0x47,  // G key
        Key_H = 0x48,  // H key
        Key_I = 0x49,  // I key
        Key_J = 0x4A,  // J key
        Key_K = 0x4B,  // K key
        Key_L = 0x4C,  // L key
        Key_M = 0x4D,  // M key
        Key_N = 0x4E,  // N key
        Key_O = 0x4F,  // O key
        Key_P = 0x50,  // P key
        Key_Q = 0x51,  // Q key
        Key_R = 0x52,  // R key
        Key_S = 0x53,  // S key
        Key_T = 0x54,  // T key
        Key_U = 0x55,  // U key
        Key_V = 0x56,  // V key
        Key_W = 0x57,  // W key
        Key_X = 0x58,  // X key
        Key_Y = 0x59,  // Y key
        Key_Z = 0x5A,  // Z key
        LWin = 0x5B,  // Left Windows key (Microsoft Natural keyboard)
        RWin = 0x5C,  // Right Windows key (Natural keyboard)
        Apps = 0x5D,  //Applications key (Natural keyboard)
        Sleep = 0x5F,  // Computer Sleep key
        Numpad_0 = 0x60,  // Numeric keypad 0 key
        Numpad_1 = 0x61,  // Numeric keypad 1 key
        Numpad_2 = 0x62,  // Numeric keypad 2 key
        Numpad_3 = 0x63,  // Numeric keypad 3 key
        Numpad_4 = 0x64,  // Numeric keypad 4 key
        Numpad_5 = 0x65,  // Numeric keypad 5 key
        Numpad_6 = 0x66,  // Numeric keypad 6 key
        Numpad_7 = 0x67,  // Numeric keypad 7 key
        Numpad_8 = 0x68,  // Numeric keypad 8 key
        Numpad_9 = 0x69,  // Numeric keypad 9 key
        Multiply = 0x6A,  // Multiply key
        Add = 0x6B,  // Add key
        Separator = 0x6C,  // Separator key
        Subtract = 0x6D,  // Subtract key
        Decimal = 0x6E,  // Decimal key
        Divide = 0x6F,  // Divide key
        F1 = 0x70,  // F1 key
        F2 = 0x71,  // F2 key
        F3 = 0x72,  // F3 key
        F4 = 0x73,  // F4 key
        F5 = 0x74,  // F5 key
        F6 = 0x75,  // F6 key
        F7 = 0x76,  // F7 key
        F8 = 0x77,  // F8 key
        F9 = 0x78,  // F9 key
        F10 = 0x79,  // F10 key
        F11 = 0x7A,  // F11 key
        F12 = 0x7B,  // F12 key
        F13 = 0x7C,  // F13 key
        F14 = 0x7D,  // F14 key
        F15 = 0x7E,  // F15 key
        F16 = 0x7F,  // F16 key
        F17 = 0x80,  // F17 key
        F18 = 0x81,  // F18 key
        F19 = 0x82,  // F19 key
        F20 = 0x83,  // F20 key
        F21 = 0x84,  // F21 key
        F22 = 0x85,  // F22 key
        F23 = 0x86,  // F23 key
        F24 = 0x87,  // F24 key
        NumLock = 0x90,  // NUM LOCK key
        Scroll = 0x91,  // SCROLL LOCK key
        LShift = 0xA0,  // Left SHIFT key
        RShift = 0xA1,  // Right SHIFT key
        LControl = 0xA2,  // Left CONTROL key
        RControl = 0xA3,  // Right CONTROL key
        LMenu = 0xA4,  // Left MENU key
        RMenu = 0xA5,  // Right MENU key
        Comma = 0xBC,  // Comma Key  (,)
        Plus = 0xBB,  // Plus Key   (+)
        Minus = 0xBD,  // Minus Key  (-)
        Period = 0xBE,  // Period Key (.)
        Attn = 0xF6,  // Attn key
        CrSel = 0xF7,  // CrSel key
        ExSel = 0xF8,  // ExSel key
        ErEOF = 0xF9,  // Erase EOF key
        Play = 0xFA,  // Play key
        Zoom = 0xFB,  // Zoom key
        PA1 = 0xFD,  // PA1 key
        OemClear = 0xFE,   // Clear key

        CODES_COUNT = 0xFF // this is not a key, but the amount of keycodes there are.
    }
}
