#include "camera.h"
#include "CCameraFPSSceneNode.h"

ICameraSceneNode *GetCameraFromIntPtr(IntPtr camera)
{
    return (ICameraSceneNode*)camera;
}
float Camera_GetAspectRatio(IntPtr camera)
{
    return GetCameraFromIntPtr(camera)->getAspectRatio();
}

float Camera_GetFarValue(IntPtr camera)
{
    return GetCameraFromIntPtr(camera)->getFarValue();
}

float Camera_GetFOV(IntPtr camera)
{
    return GetCameraFromIntPtr(camera)->getFOV();
}

float Camera_GetNearValue(IntPtr camera)
{
    return GetCameraFromIntPtr(camera)->getNearValue();
}

void Camera_GetProjectionMatrix(IntPtr camera, M_MAT4 toR)
{
    UM_MAT4(GetCameraFromIntPtr(camera)->getProjectionMatrix(), toR);
}

void Camera_GetTarget(IntPtr camera, M_VECT3DF toR)
{
    UM_VECT3DF(GetCameraFromIntPtr(camera)->getTarget(), toR);
}

void Camera_GetUpVector(IntPtr camera, M_VECT3DF toR)
{
    UM_VECT3DF(GetCameraFromIntPtr(camera)->getUpVector(), toR);
}

void Camera_GetViewMatrix(IntPtr camera, M_MAT4 toR)
{
    UM_MAT4(GetCameraFromIntPtr(camera)->getViewMatrix(), toR);
}

IntPtr Camera_GetViewFrustrum(IntPtr camera)
{
    return (IntPtr)(GetCameraFromIntPtr(camera)->getViewFrustum());
}

bool Camera_IsInputReceiverEnabled(IntPtr camera)
{
    _FIX_BOOL_MARSHAL_BUG(GetCameraFromIntPtr(camera)->isInputReceiverEnabled());
}

bool Camera_IsOrthogonal(IntPtr camera)
{
    _FIX_BOOL_MARSHAL_BUG(GetCameraFromIntPtr(camera)->isOrthogonal());
}

bool Camera_OnEvent(IntPtr camera, IntPtr event)
{
    return GetCameraFromIntPtr(camera)->OnEvent(*((SEvent*)event));
}

void Camera_SetAspectRatio(IntPtr camera, float aspect)
{
    GetCameraFromIntPtr(camera)->setAspectRatio(aspect);
}

void Camera_SetFarValue(IntPtr camera, float ffar)
{
    GetCameraFromIntPtr(camera)->setFarValue(ffar);
}

void Camera_SetFOV(IntPtr camera, float FOV)
{
    GetCameraFromIntPtr(camera)->setFOV(FOV);
}

void Camera_SetInputReceiverEnabled(IntPtr camera, bool enabled)
{
    GetCameraFromIntPtr(camera)->setInputReceiverEnabled(enabled);
}

void Camera_SetIsOrthogonal(IntPtr camera, bool orthogonal)
{
    // TODO: FIX!  Camera Orthogonal parameter has been moved to SetProjectionMatrix
    //GetCameraFromIntPtr(camera)->IsOrthogonal = orthogonal;
    //GetCameraFromIntPtr(camera)->setIsOrthogonal(orthogonal);
}

void Camera_SetNearValue(IntPtr camera, float nnear)
{
    GetCameraFromIntPtr(camera)->setNearValue(nnear);
}

void Camera_SetProjectionMatrix(IntPtr camera, M_MAT4 projection, bool orthogonal)
{
    GetCameraFromIntPtr(camera)->setProjectionMatrix(MU_MAT4(projection), orthogonal);
}

void Camera_SetTarget(IntPtr camera, M_VECT3DF target)
{
    GetCameraFromIntPtr(camera)->setTarget(MU_VECT3DF(target));
}

void Camera_SetUpVector(IntPtr camera, M_VECT3DF upvector)
{
    GetCameraFromIntPtr(camera)->setUpVector(MU_VECT3DF(upvector));
}

void VF_GetBoundingBox(IntPtr vf, M_BOX3D box)
{
    UM_BOX3D(((SViewFrustum*)vf)->getBoundingBox(), box);
}

void VF_GetFarLeftUp(IntPtr vf, M_VECT3DF pf)
{
    UM_VECT3DF(((SViewFrustum*)vf)->getFarLeftUp(), pf);
}

void VF_GetFarLeftDown(IntPtr vf, M_VECT3DF pf)
{
    UM_VECT3DF(((SViewFrustum*)vf)->getFarLeftDown(), pf);
}

void VF_GetFarRightDown(IntPtr vf, M_VECT3DF pf)
{
    UM_VECT3DF(((SViewFrustum*)vf)->getFarRightDown(), pf);
}

void VF_GetFarRightUp(IntPtr vf, M_VECT3DF pf)
{
    UM_VECT3DF(((SViewFrustum*)vf)->getFarRightUp(), pf);
}

void VF_RecalculateBoundingBox(IntPtr vf)
{
    ((SViewFrustum*)vf)->recalculateBoundingBox();
}

void VF_Transform(IntPtr vf, M_MAT4 mat)
{
    ((SViewFrustum*)vf)->transform(MU_MAT4(mat));
}

void VF_GetPlane(IntPtr vf, int idx, M_PLANE3DF plane)
{
    if (idx > ((SViewFrustum*)vf)->VF_PLANE_COUNT || idx < 0)
        return;

    UM_PLANE3DF(((SViewFrustum*)vf)->planes[idx], plane);
}

void CameraFPS_SetRotateSpeed(IntPtr camera, float speed)
{
    ((CCameraFPSSceneNode *)camera)->setRotateSpeed(speed);
}

void CameraFPS_SetMoveSpeed(IntPtr camera, float speed)
{
    ((CCameraFPSSceneNode *)camera)->setMoveSpeed(speed);
}

float CameraFPS_GetRotateSpeed(IntPtr camera)
{
    return ((CCameraFPSSceneNode *)camera)->getRotateSpeed();
}

float CameraFPS_GetMoveSpeed(IntPtr camera)
{
    return ((CCameraFPSSceneNode *)camera)->getMoveSpeed();
}

