using System;
using System.Runtime.InteropServices;
using System.Security;

namespace IrrlichtNET
{
    public class CameraSceneNode : SceneNode
    {
        public CameraSceneNode(IntPtr raw)
            : base(raw)
        {
        }

        public float AspectRatio
        {
            get
            {
                return Camera_GetAspectRatio(_raw);
            }
            set
            {
                Camera_SetAspectRatio(_raw, value);
            }
        }

        public float FarValue
        {
            get
            {
                return Camera_GetFarValue(_raw);
            }
            set
            {
                Camera_SetFarValue(_raw, value);
            }
        }

        public ViewFrustum ViewFrustum
        {
            get
            {
                return (ViewFrustum)
                    NativeElement.GetObject(Camera_GetViewFrustrum(_raw),
                                            typeof(ViewFrustum));
            }
        }

        public float FOV
        {
            get
            {
                return Camera_GetFOV(_raw);
            }
            set
            {
                Camera_SetFOV(_raw, value);
            }
        }

        public bool InputReceiverEnabled
        {
            get
            {
                return Camera_IsInputReceiverEnabled(_raw);
            }
            set
            {
                Camera_SetInputReceiverEnabled(_raw, value);
            }
        }

        public float NearValue
        {
            get
            {
                return Camera_GetNearValue(_raw);
            }
            set
            {
                Camera_SetNearValue(_raw, value);
            }
        }

        public Matrix4 ProjectionMatrix
        {
            get
            {
                float[] mat = new float[16];
                Camera_GetProjectionMatrix(_raw, mat);
                return Matrix4.FromUnmanaged(mat);
            }
            set
            {
                Camera_SetProjectionMatrix(_raw, value.ToUnmanaged());
            }
        }

        public Matrix4 ViewMatrix
        {
            get
            {
                float[] mat = new float[16];
                Camera_GetViewMatrix(_raw, mat);
                return Matrix4.FromUnmanaged(mat);
            }
        }

        public Vector3D Target
        {
            get
            {
                float[] targ = new float[3];
                Camera_GetTarget(_raw, targ);
                return Vector3D.FromUnmanaged(targ);
            }
            set
            {
                Camera_SetTarget(_raw, value.ToUnmanaged());
            }
        }

        public Vector3D UpVector
        {
            get
            {
                float[] up = new float[3];
                Camera_GetUpVector(_raw, up);
                return Vector3D.FromUnmanaged(up);
            }
            set
            {
                Camera_SetUpVector(_raw, value.ToUnmanaged());
            }
        }

        public bool Orthogonal
        {
            get
            {
                return Camera_IsOrthogonal(_raw);
            }
            set
            {
                Camera_SetIsOrthogonal(_raw, value);
            }
        }

        public bool OnEvent(Event ev)
        {
            return Camera_OnEvent(_raw, ev.Raw);
        }

        public float RotateSpeed
        {
            get
            {
                return CameraFPS_GetRotateSpeed(_raw);
            }
            set
            {
                CameraFPS_SetRotateSpeed(_raw, value);
            }
        }

        public float MoveSpeed
        {
            get
            {
                return CameraFPS_GetMoveSpeed(_raw);
            }
            set
            {
                CameraFPS_SetMoveSpeed(_raw, value);
            }
        }


        #region .NET Wrapper Native Code
        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern float Camera_GetAspectRatio(IntPtr camera);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern float Camera_GetFarValue(IntPtr camera);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern float Camera_GetFOV(IntPtr camera);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern float Camera_GetNearValue(IntPtr camera);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void Camera_GetProjectionMatrix(IntPtr camera, [MarshalAs(UnmanagedType.LPArray)] float[] toR);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void Camera_GetTarget(IntPtr camera, [MarshalAs(UnmanagedType.LPArray)] float[] toR);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void Camera_GetUpVector(IntPtr camera, [MarshalAs(UnmanagedType.LPArray)] float[] toR);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void Camera_GetViewMatrix(IntPtr camera, [MarshalAs(UnmanagedType.LPArray)] float[] toR);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr Camera_GetViewFrustrum(IntPtr camera);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern bool Camera_IsInputReceiverEnabled(IntPtr camera);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern bool Camera_IsOrthogonal(IntPtr camera);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern bool Camera_OnEvent(IntPtr camera, IntPtr ev);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void Camera_SetAspectRatio(IntPtr camera, float aspect);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void Camera_SetFarValue(IntPtr camera, float far);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void Camera_SetFOV(IntPtr camera, float FOV);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void Camera_SetInputReceiverEnabled(IntPtr camera, bool enabled);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void Camera_SetIsOrthogonal(IntPtr camera, bool orthogonal);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void Camera_SetNearValue(IntPtr camera, float near);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void Camera_SetProjectionMatrix(IntPtr camera, float[] projection);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void Camera_SetTarget(IntPtr camera, float[] target);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void Camera_SetUpVector(IntPtr camera, float[] upvector);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void CameraFPS_SetRotateSpeed(IntPtr camera, float speed);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void CameraFPS_SetMoveSpeed(IntPtr camera, float speed);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern float CameraFPS_GetRotateSpeed(IntPtr camera);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern float CameraFPS_GetMoveSpeed(IntPtr camera);
        #endregion
    }

}

