using System;
using System.Runtime.InteropServices;
using System.Security;

namespace IrrlichtNETCP
{
    public class SceneCollisionManager : NativeElement
    {
        public SceneCollisionManager(IntPtr raw)
            : base(raw)
        {
        }

        public bool GetCollisionPoint(Line3D ray, TriangleSelector selector, out Vector3D collisionPoint, out Triangle3D collisionTriangle)
        {
            float[] colp = new float[3];
            float[] coltri = new float[9];
            bool toR = SceneCollisionManager_GetCollisionPoint(_raw, ray.ToUnmanaged(), selector.Raw, colp, coltri);
            collisionPoint = Vector3D.FromUnmanaged(colp);
            collisionTriangle = Triangle3D.FromUnmanaged(coltri);
            return toR;
        }

        public Vector3D GetCollisionResultPoint(TriangleSelector selector, Vector3D ellipsoidPosition, Vector3D ellipsoidRadius, Vector3D ellipsoidDirectionAndSpeed, out Triangle3D outTriangle, out bool outFalling, float slidingSpeed, Vector3D gravityDirectionAndSpeed)
        {
            float[] outtri = new float[9];
            float[] outpos = new float[3];
            outFalling = false;
            SceneCollisionManager_GetCollisionResultPoint(_raw, selector.Raw, ellipsoidPosition.ToUnmanaged(), ellipsoidRadius.ToUnmanaged(), ellipsoidDirectionAndSpeed.ToUnmanaged(), outtri, ref outFalling, slidingSpeed, gravityDirectionAndSpeed.ToUnmanaged(), outpos);
            outTriangle = Triangle3D.FromUnmanaged(outtri);
            return Vector3D.FromUnmanaged(outpos);
        }

        public Line3D GetRayFromScreenCoordinates(Position2D position, CameraSceneNode camera)
        {
            IntPtr cam = (camera == null ? IntPtr.Zero : camera.Raw);
            float[] outray = new float[6];
            SceneCollisionManager_GetRayFromScreenCoordinates(_raw, position.ToUnmanaged(), cam, outray);
            return Line3D.FromUnmanaged(outray);
        }

        public SceneNode GetSceneNodeFromCamera(CameraSceneNode camera, int idBitMask, bool noDebug)
        {
            IntPtr cam = (camera == null ? IntPtr.Zero : camera.Raw);
            return (SceneNode)
                NativeElement.GetObject(SceneCollisionManager_GetSceneNodeFromCameraBB(_raw, cam, idBitMask, noDebug),
                                        typeof(SceneNode));
        }

        public SceneNode GetSceneNodeFromCamera(CameraSceneNode camera)
        {
            return GetSceneNodeFromCamera(camera, 0, false);
        }

        public SceneNode GetSceneNodeFromRay(Line3D ray, int bitMask, bool noDebug)
        {
            return (SceneNode)
                NativeElement.GetObject(SceneCollisionManager_GetSceneNodeFromRayBB(_raw, ray.ToUnmanaged(), bitMask, noDebug),
                                        typeof(SceneNode));
        }

        public SceneNode GetSceneNodeFromRay(Line3D ray)
        {
            return GetSceneNodeFromRay(ray, 0, false);
        }

        public SceneNode GetSceneNodeFromScreenCoordinates(Position2D screenCoordinates, int idBitMask, bool noDebug)
        {
            return (SceneNode)
                NativeElement.GetObject(SceneCollisionManager_GetSceneNodeFromScreenCoordinatesBB(_raw, screenCoordinates.ToUnmanaged(), idBitMask, noDebug),
                                        typeof(SceneNode));
        }

        public SceneNode GetSceneNodeFromScreenCoordinates(Position2D screenCoordinates)
        {
            return GetSceneNodeFromScreenCoordinates(screenCoordinates, 0, false);
        }

        public Position2D GetScreenCoordinatesFrom3DPosition(Vector3D position, CameraSceneNode camera)
        {
            IntPtr cam = (camera == null ? IntPtr.Zero : camera.Raw);
            int[] sc = new int[2];
            SceneCollisionManager_GetScreenCoordinatesFrom3DPosition(_raw, position.ToUnmanaged(), cam, sc);
            return Position2D.FromUnmanaged(sc);
        }

        #region Native Invokes
        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern bool SceneCollisionManager_GetCollisionPoint(IntPtr SCM, float[] ray, IntPtr selector, [MarshalAs(UnmanagedType.LPArray)] float[] collisionpoint, [MarshalAs(UnmanagedType.LPArray)] float[] outtriangle);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void SceneCollisionManager_GetCollisionResultPoint(IntPtr SCM, IntPtr selector, float[] ellipsoidPosition, float[] ellipsoidRadius, float[] ellipsoidDirectionAndSpeed, [MarshalAs(UnmanagedType.LPArray)] float[] outTriangle, ref bool outFalling, float slidingSpeed, float[] gravity, [MarshalAs(UnmanagedType.LPArray)] float[] outCol);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void SceneCollisionManager_GetRayFromScreenCoordinates(IntPtr SCM, int[] pos, IntPtr camera, [MarshalAs(UnmanagedType.LPArray)] float[] outRay);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr SceneCollisionManager_GetSceneNodeFromCameraBB(IntPtr SCM, IntPtr camera, int idBitMask, bool noDebug);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr SceneCollisionManager_GetSceneNodeFromRayBB(IntPtr SCM, float[] ray, int idBitMask, bool noDebug);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr SceneCollisionManager_GetSceneNodeFromScreenCoordinatesBB(IntPtr SCM, int[] pos, int idBitMask, bool noDebug);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void SceneCollisionManager_GetScreenCoordinatesFrom3DPosition(IntPtr SCM, float[] pos, IntPtr camera, [MarshalAs(UnmanagedType.LPArray)] int[] sc);
        #endregion
    }
}
