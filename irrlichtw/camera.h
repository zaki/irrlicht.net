#include "main.h"

extern "C"
{
    EXPORT void     Camera_GetProjectionMatrix(IntPtr camera, M_MAT4 projection);
    EXPORT void     Camera_SetProjectionMatrix(IntPtr camera, M_MAT4 projection, bool orthogonal);
    EXPORT void     Camera_GetViewMatrix(IntPtr camera, M_MAT4 view);
    EXPORT void     Camera_GetTarget(IntPtr camera, M_VECT3DF target);
    EXPORT void     Camera_SetTarget(IntPtr camera, M_VECT3DF target);
    EXPORT void     Camera_GetUpVector(IntPtr camera, M_VECT3DF toR);
    EXPORT void     Camera_SetUpVector(IntPtr camera, M_VECT3DF upvector);
    EXPORT float    Camera_GetNearValue(IntPtr camera);
    EXPORT void     Camera_SetNearValue(IntPtr camera, float near);
    EXPORT float    Camera_GetFarValue(IntPtr camera);
    EXPORT void     Camera_SetFarValue(IntPtr camera, float far);
    EXPORT float    Camera_GetAspectRatio(IntPtr camera);
    EXPORT void     Camera_SetAspectRatio(IntPtr camera, float aspect);
    EXPORT float    Camera_GetFOV(IntPtr camera);
    EXPORT void     Camera_SetFOV(IntPtr camera, float FOV);
    EXPORT IntPtr   Camera_GetViewFrustrum(IntPtr camera);
    EXPORT void     Camera_SetInputReceiverEnabled(IntPtr camera, bool enabled);
    EXPORT bool     Camera_IsInputReceiverEnabled(IntPtr camera);
    EXPORT bool     Camera_IsOrthogonal(IntPtr camera);
    EXPORT bool     Camera_OnEvent(IntPtr camera, IntPtr event);

    // TODO:
    // EXPORT void Camera_SetViewMatrixAffector(IntPtr camera, M_MAT4 affector);
    // EXPORT void Camera_GetViewMatrixAffector(IntPtr camera, M_MAT4 affector);
    // EXPORT bool Camera_OnEvent
    // EXPORT void Camera_SetRotation(IntPtr camera, M_VECTOR3DF rotation);
    // EXPORT void Camera_BindTargetAndRotation(IntPtr camera, bool bound);
    // EXPORT bool Camera_GetTargetAndRotationBinding();
    
    // ViewFrustum
    EXPORT void VF_GetBoundingBox(IntPtr vf, M_BOX3D box);
    EXPORT void VF_GetFarLeftUp(IntPtr vf, M_VECT3DF pf);
    EXPORT void VF_GetFarLeftDown(IntPtr vf, M_VECT3DF pf);
    EXPORT void VF_GetFarRightDown(IntPtr vf, M_VECT3DF pf);
    EXPORT void VF_GetFarRightUp(IntPtr vf, M_VECT3DF pf);
    EXPORT void VF_RecalculateBoundingBox(IntPtr v);
    EXPORT void VF_Transform(IntPtr vf, M_MAT4 mat);
    EXPORT void VF_GetPlane(IntPtr vf, int idx, M_PLANE3DF plane);

    // TODO:
    // EXPORT bool VF_ClipLine(IntPtr vf, M_LINE3D line);

    EXPORT float CameraFPS_GetRotateSpeed(IntPtr camera);
    EXPORT void CameraFPS_SetRotateSpeed(IntPtr camera, float speed);
    EXPORT float CameraFPS_GetMoveSpeed(IntPtr camera);
    EXPORT void CameraFPS_SetMoveSpeed(IntPtr camera, float speed);

    // TODO:
    // EXPORT void CameraFPS_SetVerticalMovement(IntPtr camera, bool allow);
    // EXPORT void CameraFPS_SetInvertMouse(IntPtr camera, bool invert);
    // EXPORT void CameraFPS_SetKeyMap(IntPtr camera, SKeyMap* map, u32 count);
}
