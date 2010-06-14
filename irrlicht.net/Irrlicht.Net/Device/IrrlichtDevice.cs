using IrrlichtNET;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Security;

namespace IrrlichtNET
{
    public delegate bool OnEventDelegate(Event ev);
    public partial class IrrlichtDevice : NativeElement
    {
        internal IrrlichtDevice(IntPtr raw)
            : base(raw)
        {
        }

        public IrrlichtDevice(DriverType type, Dimension2D dim, int bits, bool fullscreen, bool stencil, bool vsync, bool antialias)
        {
#if !QUIET
            Console.WriteLine("Irrlicht.NET v" + CPVersion + " running");
#endif
            Initialize(CreateDevice(type, dim.ToUnmanaged(), bits, fullscreen, stencil, vsync, antialias));
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
            MainNativeEvent = OnNativeEvent;
            Device_SetCallback(_raw, MainNativeEvent);
        }

        public IrrlichtDevice(DriverType type, Dimension2D dim, int bits, bool fullscreen, bool stencil, bool vsync, bool antialias, IntPtr windowHandle)
        {
#if !QUIET
            Console.WriteLine("Irrlicht.NET v" + CPVersion + " running");
#endif
            Initialize(CreateDeviceA(type, dim.ToUnmanaged(), bits, fullscreen, stencil, vsync, antialias, windowHandle));
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
            MainNativeEvent = OnNativeEvent;
            Device_SetCallback(_raw, MainNativeEvent);
        }

        ~IrrlichtDevice()
        {
            //lock (Elements) { if (Elements.ContainsKey(this.FileSystem.Raw)) { Elements.Remove(this.FileSystem.Raw); } }
            //lock (Elements) { if (Elements.ContainsKey(this.CursorControl.Raw)) { Elements.Remove(this.CursorControl.Raw); } }
        }


        protected delegate bool NativeEvent(IntPtr evRaw);
        /// <summary>
        /// Notice that the callback MUST BE KEPT ALIVE not to be collected by the GC
        /// That's why we create this object
        /// </summary>
        NativeEvent MainNativeEvent;

        /// <summary>
        /// Fired on each Irrlicht event.
        /// </summary>
        /// <param name="evRaw">The adress of a pointer linking to the event</param>
        /// <returns>Either the value of the user's own event receiver or false.</returns>
        protected bool OnNativeEvent(IntPtr evRaw)
        {
            Event ev = (Event)NativeElement.GetObject(evRaw, typeof(Event));
            bool toR = false;
            if (OnEvent != null)
                toR = OnEvent(ev);
            //ev.Dispose();
            return toR;
        }

        /// <summary>
        /// Fired when an event occured.
        /// </summary>
        public event OnEventDelegate OnEvent;

        void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            if (!e.IsTerminating)
                return;
            Int32 err = Marshal.GetLastWin32Error();
#if !QUIET
            Console.WriteLine("Irrlicht.NET has received an unhandled exception \n" +
                              e.ExceptionObject.ToString() + "\n\nWindows Exception :\n" +
                              new Win32Exception(err) + ".");
#endif
            //            System.Windows.Forms.MessageBox.Show("Irrlicht.NET has received an unhandled exception \n" + e.ExceptionObject.ToString() + "\n\nWindows Exception :\n" + new Win32Exception(err) + ".");
        }

        /// <summary>
        /// Runs the device. Need to be fired on each frame to invalidate the window.
        /// </summary>
        /// <returns>True if done.</returns>
        public bool Run()
        {
            return Device_Run(_raw);
        }

        /// <summary>
        /// Closes the device.
        /// </summary>
        public void Close()
        {
            Device_Close(_raw);
        }

        /// <summary>
        /// Retrieves the scene manager which is needed for any modification on the scene.
        /// </summary>
        public SceneManager SceneManager
        {
            get
            {
                return (SceneManager)NativeElement.GetObject(Device_GetSceneManager(_raw), typeof(SceneManager));
            }
        }
        /// <summary>
        /// Retrieves the video driver which is used to communicate with the Graphical Processing Unit.
        /// </summary>
        public VideoDriver VideoDriver
        {
            get
            {
                return (VideoDriver)NativeElement.GetObject(Device_GetVideoDriver(_raw), typeof(VideoDriver));
            }
        }
        /// <summary>
        /// Retrieves a General User Interface manager.
        /// </summary>
        public GUIEnvironment GUIEnvironment
        {
            get
            {
                return (GUIEnvironment)NativeElement.GetObject(Device_GetGUIEnvironment(_raw), typeof(GUIEnvironment));
            }
        }

        /// <summary>
        /// Retrieves a tool to manipulate Irrlicht's files.
        /// </summary>
        public FileSystem FileSystem
        {
            get
            {
                return (FileSystem)NativeElement.GetObject(Device_GetFileSystem(_raw), typeof(FileSystem));
            }
        }

        public Timer Timer
        {
            get
            {
                return (Timer)NativeElement.GetObject(Device_GetTimer(_raw), typeof(Timer));
            }
        }

        public CursorControl CursorControl
        {
            get
            {
                return (CursorControl)NativeElement.GetObject(Device_GetCursorControl(_raw), typeof(CursorControl));
            }
        }

        public Logger Logger
        {
            get
            {
                return (Logger)NativeElement.GetObject(Device_GetLogger(_raw), typeof(Logger));
            }
        }

        public VideoMode DesktopVideoMode
        {
            get
            {
                IntPtr raw = Device_GetVideoModeList(_raw);
                VideoMode mode = new VideoMode();
                int[] res = new int[2];
                VideoModeList_GetDesktopResolution(raw, res);
                mode.Resolution.Set(res[0], res[1]);
                mode.Depth = VideoModeList_GetDesktopDepth(raw);
                return mode;
            }
        }

        public VideoMode[] VideoModeList
        {
            get
            {
                System.Collections.ArrayList list = new System.Collections.ArrayList();
                IntPtr raw = Device_GetVideoModeList(_raw);
                int count = VideoModeList_GetVideoModeCount(raw);
                for (int i = 0; i < count; i++)
                {
                    VideoMode mode = new VideoMode();
                    int[] res = new int[2];
                    VideoModeList_GetVideoModeResolution(raw, i, res);
                    mode.Resolution.Set(res[0], res[1]);
                    mode.Depth = VideoModeList_GetVideoModeDepth(raw, i);
                    list.Add(mode);
                }
                return (VideoMode[])list.ToArray(typeof(VideoMode));
            }
        }

        public bool Resizeable
        {
            set
            {
                Device_SetResizeable(_raw, value);
            }
        }

        public string Version
        {
            get
            {
                return Device_GetVersion(_raw);
            }
        }

        public bool WindowActive
        {
            get
            {
                return Device_IsWindowActive(_raw);
            }
        }

        public string WindowCaption
        {
            set
            {
                Device_SetWindowCaption(_raw, value);
            }
        }

        public override string ToString()
        {
            return "Irrlicht .NET v" + CPVersion;
        }

        public string CPVersion
        {
            get
            {
                System.Reflection.AssemblyName an =
                    System.Reflection.Assembly.GetAssembly(this.GetType()).GetName();
                return an.Version.ToString();
            }
        }
        public override void Dispose()
        {
            try
            {
                if (_raw != IntPtr.Zero)
                    Device_Drop(_raw);
            }
            catch { }
        }

        #region .NET Wrapper Native Code
        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr CreateDevice(DriverType type, int[] dim, int bits, bool full, bool stencil, bool vsync, bool antialias);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr CreateDeviceA(DriverType type, int[] dim, int bits, bool full, bool stencil, bool vsync, bool antialias, IntPtr handle);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr Device_GetSceneManager(IntPtr raw);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr Device_GetVideoDriver(IntPtr raw);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr Device_GetGUIEnvironment(IntPtr raw);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr Device_GetFileSystem(IntPtr raw);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr Device_GetCursorControl(IntPtr raw);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr Device_GetLogger(IntPtr device);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void Device_SetWindowCaption(IntPtr raw, string caption);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr Device_GetVideoModeList(IntPtr device);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern bool Device_Run(IntPtr raw);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void Device_Drop(IntPtr raw);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void Device_Close(IntPtr raw);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr Device_GetTimer(IntPtr device);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void Device_SetResizeable(IntPtr device, bool resizeable);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern string Device_GetVersion(IntPtr device);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern bool Device_IsWindowActive(IntPtr device);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void Device_SetCallback(IntPtr device, NativeEvent callback);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern int VideoModeList_GetDesktopDepth(IntPtr videomodelist);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void VideoModeList_GetDesktopResolution(IntPtr videomodelist, [MarshalAs(UnmanagedType.LPArray)] int[] res);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern int VideoModeList_GetVideoModeCount(IntPtr videomodelist);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern int VideoModeList_GetVideoModeDepth(IntPtr videomodelist, int mode);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void VideoModeList_GetVideoModeResolution(IntPtr videomodelist, int mode, [MarshalAs(UnmanagedType.LPArray)] int[] res);
        #endregion
    }

    public struct VideoMode
    {
        public Dimension2D Resolution;
        public int Depth;
        public override string ToString()
        {
            return Resolution.Width + "x" + Resolution.Height + "x" + Depth;
        }
    }

    public class Logger : NativeElement
    {
        public Logger(IntPtr raw) : base(raw) { }

        public void Log(string text, LogLevel lev)
        {
            Logger_Log(_raw, text, lev);
        }
        public void Log(string text)
        {
            Log(text, LogLevel.Information);
        }
        public void Log(string text, string hint, LogLevel lev)
        {
            Logger_LogA(_raw, text, hint, lev);
        }
        public void Log(string text, string hint)
        {
            Log(text, hint, LogLevel.Information);
        }

        public LogLevel LogLevel
        {
            get { return Logger_GetLogLevel(_raw); }
            set { Logger_SetLogLevel(_raw, value); }
        }

        #region Native Invokes
        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern LogLevel Logger_GetLogLevel(IntPtr logger);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void Logger_Log(IntPtr logger, string text, LogLevel lev);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void Logger_LogA(IntPtr logger, string text, string hint, LogLevel lev);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void Logger_SetLogLevel(IntPtr logger, LogLevel level);
        #endregion
    }

    public enum LogLevel
    {
        Information,
        Warning,
        Error,
        None
    }
}


