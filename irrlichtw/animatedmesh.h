#include "main.h"

extern "C"
{
    typedef void (STDCALL ANIMATIONENDCALLBACK)(IntPtr);

    EXPORT void ShadowVolume_SetMeshToRenderFrom(IntPtr shadow, IntPtr mesh);

    EXPORT void AnimatedMeshSceneNode_SetCurrentFrame(IntPtr node, int cf);
    EXPORT void AnimatedMeshSceneNode_SetFrameLoop(IntPtr node, int start, int end);
    EXPORT void AnimatedMeshSceneNode_SetAnimationSpeed(IntPtr node, int framePS);
    EXPORT IntPtr AnimatedMeshSceneNode_AddShadowVolumeSceneNode(IntPtr node, IntPtr mesh, int ID, bool zfail, float infinity);
    EXPORT IntPtr AnimatedMeshSceneNode_GetJointNodeA(IntPtr node, M_STRING name);
    EXPORT IntPtr AnimatedMeshSceneNode_GetJointNode(IntPtr node, u32 jointn);
    EXPORT IntPtr AnimatedMeshSceneNode_GetMS3DJointNode(IntPtr node, M_STRING jointName);
    EXPORT IntPtr AnimatedMeshSceneNode_GetXJointNode(IntPtr node, M_STRING jointName);
    EXPORT void AnimatedMeshSceneNode_SetMD2Animation(IntPtr node, M_STRING animationname);
    EXPORT void AnimatedMeshSceneNode_SetMD2AnimationA(IntPtr node, EMD2_ANIMATION_TYPE anim);
    EXPORT f32 AnimatedMeshSceneNode_GetFrameNr(IntPtr node);
    EXPORT void AnimatedMeshSceneNode_SetLoopMode(IntPtr node, bool animationLooped);
    EXPORT void AnimatedMeshSceneNode_SetAnimationEndCallback(IntPtr node, ANIMATIONENDCALLBACK callback);
    EXPORT IntPtr AnimatedMeshSceneNode_GetMesh(IntPtr node);
    EXPORT void AnimatedMeshSceneNode_SetJointMode(IntPtr node, E_JOINT_UPDATE_ON_RENDER mode);
    EXPORT void AnimatedMeshSceneNode_SetTransitionTime(IntPtr node, float time);
    EXPORT void AnimatedMeshSceneNode_AnimateJoints (IntPtr node, bool calc);

    // TODO: Implement
    // EXPORT IntPtr AnimatedMeshSceneNode_GetJointCount(IntPtr node);
    // EXPORT s32 AnimatedMeshSceneNode_GetStartFrame(IntPtr node);
    // EXPORT s32 AnimatedMeshSceneNode_GetEndFrame(IntPtr node);
    // EXPORT void AnimatedMeshSceneNode_SetReadOnlyMaterials(IntPtr node, bool readonly);
    // EXPORT bool AnimatedMeshSceneNode_IsReadOnlyMaterials(IntPtr node);
    // EXPORT void AnimatedMeshSceneNode_SetMesh(IntPtr node, IntPtr mesh);
    // EXPORT IntPtr AnimatedMeshSceneNode_GetMD3TagTransformation(IntPtr node, M_STRING tagname);
    // EXPORT void AnimatedMeshSceneNode_SetRenderFromIdentity(bool On);
}
