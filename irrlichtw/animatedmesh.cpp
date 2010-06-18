#include "animatedmesh.h"

//Shadow Volume Scene Node
void ShadowVolume_SetMeshToRenderFrom(IntPtr shadow, IntPtr mesh)
{
    ((IShadowVolumeSceneNode*)shadow)->setShadowMesh((IMesh*)mesh);
}

//Animated Mesh Scene Node
IAnimatedMeshSceneNode *GetNodeFromIntPtr(IntPtr node)
{
    return (IAnimatedMeshSceneNode*)node;
}

class AnimationEnd : public IAnimationEndCallBack
{
public:
    AnimationEnd()
    {
        isCallbackDefined = false;
    }

    virtual void OnAnimationEnd(IAnimatedMeshSceneNode *node)
    {
        if(isCallbackDefined)
            _callback(node);
    }
    void setCallback(ANIMATIONENDCALLBACK call)
    {
        isCallbackDefined = true;
        _callback = *call;
    }

protected:
    bool isCallbackDefined;
    ANIMATIONENDCALLBACK _callback;
};

IntPtr AnimatedMeshSceneNode_AddShadowVolumeSceneNode(IntPtr node, IntPtr mesh, int ID, bool zfail, float infinity)
{
    return GetNodeFromIntPtr(node)->addShadowVolumeSceneNode((IMesh *)(mesh), ID, zfail, infinity);
}

f32 AnimatedMeshSceneNode_GetFrameNr(IntPtr node)
{
    return GetNodeFromIntPtr(node)->getFrameNr();
}

IntPtr AnimatedMeshSceneNode_GetMS3DJointNode(IntPtr node, M_STRING jointName)
{
    return GetNodeFromIntPtr(node)->getMS3DJointNode(jointName);
}


/*
* New functions present in irrlicht 1.4
*/
IntPtr AnimatedMeshSceneNode_GetJointNode(IntPtr node, u32 jointn)
{
    return GetNodeFromIntPtr(node)->getJointNode(jointn);
}

IntPtr AnimatedMeshSceneNode_GetJointNodeA(IntPtr node, M_STRING name)
{
    return GetNodeFromIntPtr(node)->getJointNode(UM_STRING(name));
}

void AnimatedMeshSceneNode_SetJointMode(IntPtr node, E_JOINT_UPDATE_ON_RENDER mode)
{
    GetNodeFromIntPtr(node)->setJointMode(mode);
}

void AnimatedMeshSceneNode_SetTransitionTime(IntPtr node, float time)
{
    GetNodeFromIntPtr(node)->setTransitionTime(time);
}

void AnimatedMeshSceneNode_AnimateJoints (IntPtr node, bool calc)
{
    GetNodeFromIntPtr(node)->animateJoints(calc);
}

/*
* This stuff is marked as deprecated. Maybe we should warn users not to use it
*/
IntPtr AnimatedMeshSceneNode_GetXJointNode(IntPtr node, M_STRING jointName)
{
    return GetNodeFromIntPtr(node)->getXJointNode(jointName);
}

void AnimatedMeshSceneNode_SetAnimationEndCallback(IntPtr node, ANIMATIONENDCALLBACK callback)
{
    AnimationEnd *end = new AnimationEnd();
    end->setCallback(callback);
    GetNodeFromIntPtr(node)->setAnimationEndCallback(end);
}

void AnimatedMeshSceneNode_SetAnimationSpeed(IntPtr node, int framePS)
{
    GetNodeFromIntPtr(node)->setAnimationSpeed((irr::f32)framePS);
}

void AnimatedMeshSceneNode_SetCurrentFrame(IntPtr node, int cf)
{
    GetNodeFromIntPtr(node)->setCurrentFrame((irr::f32)cf);
}

void AnimatedMeshSceneNode_SetFrameLoop(IntPtr node, int start, int end)
{
    GetNodeFromIntPtr(node)->setFrameLoop(start, end);
}

void AnimatedMeshSceneNode_SetLoopMode(IntPtr node, bool animationLooped)
{
    GetNodeFromIntPtr(node)->setLoopMode(animationLooped);
}

void AnimatedMeshSceneNode_SetMD2Animation(IntPtr node, M_STRING animationname)
{
    GetNodeFromIntPtr(node)->setMD2Animation(animationname);
}

void AnimatedMeshSceneNode_SetMD2AnimationA(IntPtr node, EMD2_ANIMATION_TYPE anim)
{
    GetNodeFromIntPtr(node)->setMD2Animation(anim);
}

IntPtr AnimatedMeshSceneNode_GetMesh(IntPtr node)
{
    return (IntPtr)GetNodeFromIntPtr(node)->getMesh();
}

