#include "main.h"

extern "C"
{
    // TODO: Review implementation

    typedef void (STDCALL EMITTERCALLBACK)(unsigned int, unsigned int, IntPtr);
    typedef void (STDCALL AFFECTORCALLBACK)(unsigned int, IntPtr*, int);


    EXPORT void Emitter_AddParticle(IntPtr emitter, IntPtr *part, int count);
    EXPORT void Emitter_SetMinStartSize(IntPtr emitter, M_DIM2DF size);
    EXPORT void Emitter_SetMaxStartSize(IntPtr emitter, M_DIM2DF size);
    EXPORT void Emitter_GetMinStartSize(IntPtr emitter, M_DIM2DF size);
    EXPORT void Emitter_GetMaxStartSize(IntPtr emitter, M_DIM2DF size);

    EXPORT void Particle_AddAffector(IntPtr part, IntPtr affector);
    EXPORT void Particle_AddAffectorA(IntPtr part, AFFECTORCALLBACK affector);
    EXPORT IntPtr Particle_CreateBoxEmitter(IntPtr part,M_BOX3D box, M_VECT3DF direction, unsigned int minPPS, unsigned int maxPPS, M_SCOLOR minSC, M_SCOLOR maxSC, unsigned int minLT, unsigned int maxLT, int maxAngleDegrees);
    EXPORT IntPtr Particle_CreateFadeOutParticleAffector(IntPtr part, M_SCOLOR tgtColor, unsigned int timeNeeded);
    EXPORT IntPtr Particle_CreateGravityAffector(IntPtr part, M_VECT3DF gravity, unsigned int timeForceLost);
    EXPORT IntPtr Particle_CreatePointEmitter(IntPtr part, M_VECT3DF dir, unsigned int minPPS, unsigned int maxPPS, M_SCOLOR minSC, M_SCOLOR maxSC, unsigned int minLT, unsigned int maxLT, int maxAngleDegrees);
    EXPORT void Particle_RemoveAllAffectors(IntPtr part);
    EXPORT void Particle_SetEmitter(IntPtr part, IntPtr emitter);
    EXPORT void Particle_SetEmitterA(IntPtr part, EMITTERCALLBACK callback);
    EXPORT void Particle_SetParticlesAreGlobal(IntPtr part, bool global);
    EXPORT void Particle_SetParticleSize(IntPtr part, M_DIM2DF size);
    EXPORT IntPtr SParticle_Create();
    EXPORT void SParticle_GetPos(IntPtr particle, M_VECT3DF vect);
    EXPORT void SParticle_SetPos(IntPtr particle, M_VECT3DF vect);
    EXPORT void SParticle_GetVect(IntPtr particle, M_VECT3DF vect);
    EXPORT void SParticle_SetVect(IntPtr particle, M_VECT3DF vect);
    EXPORT void SParticle_GetStartVect(IntPtr particle, M_VECT3DF vect);
    EXPORT void SParticle_SetStartVect(IntPtr particle, M_VECT3DF vect);
    EXPORT void SParticle_GetColor(IntPtr particle, M_SCOLOR color);
    EXPORT void SParticle_SetColor(IntPtr particle, M_SCOLOR color);
    EXPORT void SParticle_GetStartColor(IntPtr particle, M_SCOLOR color);
    EXPORT void SParticle_SetStartColor(IntPtr particle, M_SCOLOR color);
    EXPORT unsigned int SParticle_GetStartTime(IntPtr particle);
    EXPORT void SParticle_SetStartTime(IntPtr particle, unsigned int time);
    EXPORT unsigned int SParticle_GetEndTime(IntPtr particle);
    EXPORT void SParticle_SetEndTime(IntPtr particle, unsigned int time);
}
