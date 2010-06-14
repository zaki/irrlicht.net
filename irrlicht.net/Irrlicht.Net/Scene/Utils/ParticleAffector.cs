using System;
using System.Security;

namespace IrrlichtNET
{
    public class ParticleAffector : NativeElement
    {
        public ParticleAffector(IntPtr raw)
            : base(raw)
        {
        }
    }
}

namespace IrrlichtNET.Inheritable
{
    public interface IParticleAffector
    {
        void Affect(uint now, Particle[] Particles);
    }
}
