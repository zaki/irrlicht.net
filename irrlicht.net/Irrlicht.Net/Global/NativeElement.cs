using System;
using System.Collections.Generic;
using System.Security;


namespace IrrlichtNET
{
    public abstract class NativeElement
    {
        public static Dictionary<IntPtr, NativeElement> Elements = new Dictionary<IntPtr, NativeElement>();

        public static object GetObject(IntPtr raw, Type t)
        {
            if (raw == IntPtr.Zero)
                return null;

            if (Elements.ContainsKey(raw))
            {
                //This condition should NEVER BE TRUE but
                //in order to prevent stupid engine crashes I added it
                if (Elements[raw] == null || !t.IsInstanceOfType(Elements[raw]))
                    Elements[raw] = (NativeElement)Activator.CreateInstance(t, raw);
                return Elements[raw];
            }
            return Activator.CreateInstance(t, raw);
        }

        public NativeElement()
        {
        }

        public NativeElement(IntPtr raw)
        {
            Initialize(raw);
        }
        protected virtual void Initialize(IntPtr raw)
        {
            _raw = raw;
            if (!Elements.ContainsKey(raw))
                Elements.Add(raw, this);
            else
                Elements[raw] = this;
        }

        public virtual void Drop()
        {
            // Because sometimes we don't want to remove the item from Elements, just decrease the ReferenceCount
            if (_raw != IntPtr.Zero)
            {
                try
                {
                    int refCount = GetReferenceCount();

                    if (refCount > 0 && refCount < 999999)
                    {
                        Pointer_SafeRelease(_raw);
                        _raw = IntPtr.Zero;
                    }
                    else
                    {
                        throw new AccessViolationException("Invalid pointer given to Drop()");
                    }
                }
                catch (Exception)
                {
                    System.Diagnostics.Debug.WriteLine("WARNING: Drop failed");
                }
            }
        }
        public int GetReferenceCount() { return Pointer_GetReferenceCount(_raw); }

        #region .NET Wrapper Native Code
        protected IntPtr _raw = IntPtr.Zero;
        public IntPtr Raw { get { return _raw; } }
        public bool Null() { return _raw == IntPtr.Zero; }

        [System.Runtime.InteropServices.DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void Pointer_SafeRelease(IntPtr pointer);

        [System.Runtime.InteropServices.DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern int Pointer_GetReferenceCount(IntPtr pointer);
        #endregion
    }

}
