using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security;


namespace IrrlichtNET
{
    public delegate void DropCallbackDelegate(IntPtr obj);

    public class DropCallbackClass
    {
        // The following method will be invoked from the IrrlichtW layer whenever an
        // IReferenceCounted object is Dropped and its reference count goes to 0.
        // This allows us to clean up the C# objects corresponding to the C++ object
        // that is just about to be deleted.
        public void OnAboutToDelete(IntPtr obj)
        {
            //Console.WriteLine("drop callback");
        }
    }

    public abstract class NativeElement : IDisposable
    {
        public static Dictionary<IntPtr, NativeElement> Elements = new Dictionary<IntPtr, NativeElement>();

        //static DropCallbackClass dropCallbackObject = new DropCallbackClass();
        //static DropCallbackDelegate dropCallbackDelegateObject = dropCallbackObject.OnAboutToDelete; // ensure that we have ONE delegate used for ALL NativeElements

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
            //this.SetCallback();
        }
        protected virtual void Initialize(IntPtr raw)
        {
            _raw = raw;
            if (!Elements.ContainsKey(raw))
                Elements.Add(raw, this);
            else
                Elements[raw] = this;
            //this.SetCallback();
        }

        [Obsolete]
        protected virtual void SetCallback()
        {
            //ReferenceCounted_SetCallback(_raw, dropCallbackDelegateObject);
        }

        public virtual void Dispose()
        {
            if (Elements.ContainsKey(Raw))
                Elements.Remove(Raw);
            if (_raw != IntPtr.Zero)
                try { Pointer_SafeRelease(_raw); }
                catch { };
        }

        public virtual void Drop()
        {
            // Because sometimes we don't want to remove the item from Elements, just decrease the ReferenceCount
            if (_raw != IntPtr.Zero)
            {
                try
                {
                    // if _raw has become invalid, the vtable for the IReferenceCount* part of _raw will be garbage
                    // and this method call should throw an exception, thus skipping over the Pointer_SafeRelease
                    //int refCount = this.GetReferenceCount();

                    // as an extra check, do a sanity check on refCount. This also ensures that the refCount
                    // variable is used so the above call to this.GetReferenceCount() will definitely get
                    // executed (and not optimized away)
                    //if (refCount > 0 && refCount < 999999)
                    {
                        Pointer_SafeRelease(_raw);
                    }
                }
                catch (Exception)
                {
                    System.Diagnostics.Debug.WriteLine("WARNING: Drop failed");
                }
            }
        }

        #region .NET Wrapper Native Code
        protected IntPtr _raw = IntPtr.Zero;
        public IntPtr Raw { get { return _raw; } }
        public bool Null() { return _raw == IntPtr.Zero; }
        public int GetReferenceCount() { return Pointer_GetReferenceCount(_raw); }

        [System.Runtime.InteropServices.DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void Pointer_SafeRelease(IntPtr pointer);

        [System.Runtime.InteropServices.DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern int Pointer_GetReferenceCount(IntPtr pointer);

        [System.Runtime.InteropServices.DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern int ReferenceCounted_SetCallback(IntPtr obj, DropCallbackDelegate callback);
        #endregion
    }

}
