using System;
using System.Collections;
using System.Runtime.InteropServices;
using IrrlichtNET.Inheritable;

namespace IrrlichtNET
{
    public class ParticleSystemSceneNode : SceneNode
    {
        public ParticleSystemSceneNode(IntPtr raw)
            : base(raw)
        {
        }
        static ArrayList AntiGC = new ArrayList();

        public void AddAffector(ParticleAffector aff)
        {
            Particle_AddAffector(_raw, aff.Raw);
        }

        protected delegate void OnNativeAffect(uint now, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] IntPtr[] particles, int count);
        public void AddAffector(IParticleAffector aff)
        {
            OnNativeAffect del = delegate(uint now, IntPtr[] Particles, int count)
            {
                Particle[] array = new Particle[count];
                for (int i = 0; i < array.Length; i++)
                    array[i] = (Particle)NativeElement.GetObject((IntPtr)Particles[i], typeof(Particle));
                aff.Affect(now, array);
                for (int i = 0; i < array.Length; i++)
                    array[i].Dispose();
                array = null;
            };
            AntiGC.Add(del);
            Particle_AddAffectorA(_raw, del);
        }

        public ParticleEmitter CreateBoxEmitter(Box3D box, Vector3D direction, uint minPPS, uint maxPPS, Color minSC, Color maxSC, uint minLT, uint maxLT, int maxAngleDegrees)
        {
            return (ParticleEmitter)
                NativeElement.GetObject(Particle_CreateBoxEmitter(_raw, box.ToUnmanaged(), direction.ToUnmanaged(), minPPS, maxPPS, minSC.ToUnmanaged(), maxSC.ToUnmanaged(), minLT, maxLT, maxAngleDegrees),
                                        typeof(ParticleEmitter));
        }

        public ParticleAffector CreateFadeOutParticleAffector(Color TargetColor, uint TimeNeededToFadeOut)
        {
            return (ParticleAffector)
                NativeElement.GetObject(Particle_CreateFadeOutParticleAffector(_raw, TargetColor.ToUnmanaged(), TimeNeededToFadeOut),
                                        typeof(ParticleAffector));
        }

        public ParticleAffector CreateGravityAffector(Vector3D gravity, uint timeForceLost)
        {
            return (ParticleAffector)
                NativeElement.GetObject(Particle_CreateGravityAffector(_raw, gravity.ToUnmanaged(), timeForceLost),
                                        typeof(ParticleAffector));
        }

        public ParticleEmitter CreatePointEmitter(Vector3D direction, uint minPPS, uint maxPPS, Color minSC, Color maxSC, uint minLT, uint maxLT, int maxAngleDegrees)
        {
            return (ParticleEmitter)
                NativeElement.GetObject(Particle_CreatePointEmitter(_raw, direction.ToUnmanaged(), minPPS, maxPPS, minSC.ToUnmanaged(), maxSC.ToUnmanaged(), minLT, maxLT, maxAngleDegrees),
                                        typeof(ParticleEmitter));
        }

        public void RemoveAllAffectors()
        {
            Particle_RemoveAllAffectors(_raw);
        }

        public void SetEmitter(ParticleEmitter emit)
        {
            Particle_SetEmitter(_raw, emit.Raw);
        }

        protected delegate void OnNativeEmit(uint now, uint timeSinceLastCall, IntPtr len);
        public void SetEmitter(IParticleEmitter emit)
        {
            OnNativeEmit del = delegate(uint now, uint timeSinceLastCall, IntPtr emitter)
            {
                Particle[] outParticles;
                emit.Emit(now, timeSinceLastCall, out outParticles);
                IntPtr[] array = new IntPtr[outParticles.Length];
                for (int i = 0; i < outParticles.Length; i++)
                    array[i] = outParticles[i].Raw;
                Emitter_AddParticle(emitter, array, array.Length);

                for (int i = 0; i < outParticles.Length; i++)
                    outParticles[i].Dispose();
                outParticles = null;
            };
            AntiGC.Add(del);
            Particle_SetEmitterA(_raw, del);
        }
        [DllImport(Native.Dll)]
        static extern void Emitter_AddParticle(IntPtr emitter, [MarshalAs(UnmanagedType.LPArray)] IntPtr[] part, int count);

        public bool ParticlesAreGlobal
        {
            set
            {
                Particle_SetParticlesAreGlobal(_raw, value);
            }
        }

        public Dimension2Df ParticleSize
        {
            set
            {
                Particle_SetParticleSize(_raw, value.ToUnmanaged());
            }
        }

        #region Native Invokes
        [DllImport(Native.Dll)]
        static extern void Particle_AddAffector(IntPtr part, IntPtr affector);

        [DllImport(Native.Dll)]
        static extern void Particle_AddAffectorA(IntPtr part, OnNativeAffect affector);

        [DllImport(Native.Dll)]
        static extern IntPtr Particle_CreateBoxEmitter(IntPtr part, float[] box, float[] direction, uint minPPS, uint maxPPS, int[] minSC, int[] maxSC, uint minLT, uint maxLT, int maxAngleDegrees);

        [DllImport(Native.Dll)]
        static extern IntPtr Particle_CreateFadeOutParticleAffector(IntPtr part, int[] tgtColor, uint timeNeeded);

        [DllImport(Native.Dll)]
        static extern IntPtr Particle_CreateGravityAffector(IntPtr part, float[] gravity, uint timeForceLost);

        [DllImport(Native.Dll)]
        static extern IntPtr Particle_CreatePointEmitter(IntPtr part, float[] dir, uint minPPS, uint maxPPS, int[] minSC, int[] maxSC, uint minLT, uint maxLT, int maxAngleDegrees);

        [DllImport(Native.Dll)]
        static extern void Particle_RemoveAllAffectors(IntPtr part);

        [DllImport(Native.Dll)]
        static extern void Particle_SetEmitter(IntPtr part, IntPtr emitter);

        [DllImport(Native.Dll)]
        static extern void Particle_SetEmitterA(IntPtr part, OnNativeEmit emitter);

        [DllImport(Native.Dll)]
        static extern void Particle_SetParticlesAreGlobal(IntPtr part, bool global);

        [DllImport(Native.Dll)]
        static extern void Particle_SetParticleSize(IntPtr part, float[] size);
        #endregion
    }
}
