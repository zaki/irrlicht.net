using System;
using System.Security;

namespace IrrlichtNETCP
{
    public class ParticleAffector : NativeElement
    {
        public ParticleAffector(IntPtr raw)
            : base(raw)
        {
        }

        public override void Dispose()
        {
            if (Elements.ContainsKey(Raw))
                Elements.Remove(Raw);
            if (_raw != IntPtr.Zero)
                try { Pointer_SafeRelease_AEO(_raw); }
                catch { };
        }

        public override void Drop()
        {
            if (_raw != IntPtr.Zero)
                try { Pointer_SafeRelease_AEO(_raw); }
                catch { };
        }

        [System.Runtime.InteropServices.DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void Pointer_SafeRelease_AEO(IntPtr pointer);
    }
}

namespace IrrlichtNETCP.Inheritable
{
    public interface IParticleAffector
    {
        void Affect(uint now, Particle[] Particles);
    }
}
