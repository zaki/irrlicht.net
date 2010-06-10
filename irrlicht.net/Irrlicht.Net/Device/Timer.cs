using System;
using System.Runtime.InteropServices;
using System.Security;

namespace IrrlichtNETCP
{
    public class Timer : NativeElement
    {
        public Timer(IntPtr raw)
            : base(raw)
        { }

        public uint RealTime
        {
            get
            {
                return Timer_GetRealTime(_raw);
            }
        }

        public uint Time
        {
            get
            {
                return Timer_GetTime(_raw);
            }
            set
            {
                Timer_SetTime(_raw, value);
            }
        }

        public float Speed
        {
            get
            {
                return Timer_GetSpeed(_raw);
            }
            set
            {
                Timer_SetSpeed(_raw, value);
            }
        }

        public bool Stopped
        {
            get
            {
                return Timer_IsStopped(_raw);
            }
        }

        public void Start()
        {
            Timer_Start(_raw);
        }

        public void Stop()
        {
            Timer_Stop(_raw);
        }

        public void Tick()
        {
            Timer_Tick(_raw);
        }

        #region Native Invokes
        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern uint Timer_GetRealTime(IntPtr timer);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern float Timer_GetSpeed(IntPtr timer);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern uint Timer_GetTime(IntPtr timer);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern bool Timer_IsStopped(IntPtr timer);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void Timer_SetSpeed(IntPtr timer, float speed);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void Timer_SetTime(IntPtr timer, uint time);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void Timer_Start(IntPtr timer);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void Timer_Stop(IntPtr timer);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void Timer_Tick(IntPtr timer);
        #endregion
    }
}
