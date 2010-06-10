#include "skinnedmesh.h"
#include <iostream>

IBoneSceneNode *GetBoneFromIntPtr (IntPtr object)
{
    return (IBoneSceneNode*)object;
}

E_BONE_ANIMATION_MODE BoneSceneNode_GetAnimationMode(IntPtr bone)
{
    return GetBoneFromIntPtr(bone)->getAnimationMode();
}

u32 BoneSceneNode_GetBoneIndex(IntPtr bone)
{
    return GetBoneFromIntPtr(bone)->getBoneIndex();
}

M_STRING BoneSceneNode_GetBoneName(IntPtr bone)
{
    return UM_STRING(GetBoneFromIntPtr(bone)->getBoneName());
}

void BoneSceneNode_SetAnimationMode(IntPtr bone, E_BONE_ANIMATION_MODE mode)
{
    GetBoneFromIntPtr(bone)->setAnimationMode(mode);
}

u32 BoneSceneNode_GetSkinningSpace(IntPtr bone)
{
    return GetBoneFromIntPtr(bone)->getSkinningSpace();
}

void BoneSceneNode_SetSkinningSpace (IntPtr bone, E_BONE_SKINNING_SPACE space)
{
    GetBoneFromIntPtr(bone)->setSkinningSpace (space);
}

s32 BoneSceneNode_GetScaleHint (IntPtr bone)
{
    return GetBoneFromIntPtr(bone)->scaleHint;
}
s32 BoneSceneNode_GetRotationHint (IntPtr bone)
{
    return GetBoneFromIntPtr(bone)->rotationHint;
}
s32 BoneSceneNode_GetPositionHint (IntPtr bone)
{
    return GetBoneFromIntPtr(bone)->positionHint;
}
void BoneSceneNode_SetScaleHint (IntPtr bone, s32 hint)
{
    GetBoneFromIntPtr(bone)->scaleHint = hint;
}
void BoneSceneNode_SetRotationHint (IntPtr bone, s32 hint)
{
    GetBoneFromIntPtr(bone)->rotationHint = hint;
}
void BoneSceneNode_SetPositionHint (IntPtr bone, s32 hint)
{
    GetBoneFromIntPtr(bone)->positionHint = hint;
}
void BoneSceneNode_UAPOAC(IntPtr bone)
{

    GetBoneFromIntPtr(bone)->updateAbsolutePositionOfAllChildren();
}

ISkinnedMesh *GetMeshFromIntPtr(IntPtr object)
{
    return (ISkinnedMesh*)object;
}

void SkinnedMesh_AnimateMesh(IntPtr mesh, f32 frame, f32 blend)
{
    GetMeshFromIntPtr(mesh)->animateMesh(frame, blend);
}

void SkinnedMesh_ConvertMeshToTangents(IntPtr mesh)
{
    GetMeshFromIntPtr(mesh)->convertMeshToTangents();
}

void SkinnedMesh_SkinMesh(IntPtr mesh)
{
    GetMeshFromIntPtr(mesh)->skinMesh();
}



