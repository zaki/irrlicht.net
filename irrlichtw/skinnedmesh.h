#include "main.h"

extern "C"
{
    EXPORT E_BONE_ANIMATION_MODE BoneSceneNode_GetAnimationMode(IntPtr bone);
    EXPORT u32 BoneSceneNode_GetBoneIndex(IntPtr bone);
    EXPORT M_STRING BoneSceneNode_GetBoneName(IntPtr bone);
    EXPORT void BoneSceneNode_SetAnimationMode(IntPtr bone, E_BONE_ANIMATION_MODE mode);
    EXPORT u32 BoneSceneNode_GetSkinningSpace(IntPtr bone);
    EXPORT void BoneSceneNode_SetSkinningSpace(IntPtr bone, E_BONE_SKINNING_SPACE space);
    EXPORT s32 BoneSceneNode_GetScaleHint(IntPtr bone);
    EXPORT s32 BoneSceneNode_GetRotationHint(IntPtr bone);
    EXPORT s32 BoneSceneNode_GetPositionHint(IntPtr bone);
    EXPORT void BoneSceneNode_SetScaleHint(IntPtr bone, s32 hint);
    EXPORT void BoneSceneNode_SetRotationHint(IntPtr bone, s32 hint);
    EXPORT void BoneSceneNode_SetPositionHint(IntPtr bone, s32 hint);
    EXPORT void BoneSceneNode_UAPOAC(IntPtr bone);

    // TODO:
    // EXPORT void BoneSceneNode_GetBoundingBox(IntPtr bone, M_BOX3D boundingbox);


    EXPORT void SkinnedMesh_AnimateMesh(IntPtr mesh, f32 frame, f32 blend);
    EXPORT void SkinnedMesh_ConvertMeshToTangents(IntPtr mesh);
    EXPORT void SkinnedMesh_SkinMesh(IntPtr mesh);

    // TODO:
    // EXPORT int        SkinnedMesh_GetJointCount(IntPtr mesh);
	// EXPORT M_STRING   SkinnedMesh_GetJointName(IntPtr mesh, int number);
	// EXPORT int        SkinnedMesh_GetJointNumber(IntPtr mesh, M_STRING name);
	// EXPORT bool       SkinnedMesh_UseAnimationFrom(IntPtr mesh, IntPtr other);
	// EXPORT void       SkinnedMesh_UpdateNormalsWhenAnimating(IntPtr mesh, bool on);
	// EXPORT void       SkinnedMesh_SetInterpolationMode(IntPtr mesh, E_INTERPOLATION_MODE mode);
	// EXPORT bool       SkinnedMesh_SetHardwareSkinning(IntPtr mesh, bool on);
	// EXPORT IntPtr*    SkinnedMesh_GetMeshBuffers(IntPtr mesh);
	// EXPORT IntPtr*    SkinnedMesh_GetAllJoints(IntPtr mesh);
	// EXPORT IntPtr*    SkinnedMesh_GetAllJoints(IntPtr mesh);
	// EXPORT void       SkinnedMesh_Finalize(IntPtr mesh);
	// EXPORT IntPtr     SkinnedMesh_AddMeshBuffer(IntPtr mesh);
	// EXPORT IntPtr     SkinnedMesh_AddJoint(IntPtr mesh, IntPtr parent);
	// EXPORT IntPtr     SkinnedMesh_AddWeight(IntPtr mesh, IntPtr joint);
	// EXPORT IntPtr     SkinnedMesh_AddPositionKey(IntPtr mesh, IntPtr joint);
	// EXPORT IntPtr     SkinnedMesh_AddScaleKey(IntPtr mesh, IntPtr joint);
	// EXPORT IntPtr     SkinnedMesh_AddRotationKey(IntPtr mesh, IntPtr joint);
	// EXPORT bool       SkinnedMesh_IsStatic(IntPtr mesh);
}
