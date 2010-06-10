using System;
using System.Runtime.InteropServices;
using System.Security;

namespace IrrlichtNETCP
{
    public class TerrainSceneNode : SceneNode
    {
        public TerrainSceneNode(IntPtr raw)
            : base(raw)
        {
        }

        public override Box3D BoundingBox
        {
            get
            {
                float[] box = new float[6];
                TerrainSceneNode_GetBoundingBoxA(_raw, box);
                return Box3D.FromUnmanaged(box);
            }
        }

        public int IndexCount
        {
            get
            {
                return TerrainSceneNode_GetIndexCount(_raw);
            }
        }

        public Mesh Mesh
        {
            get
            {
                return (Mesh)
                    NativeElement.GetObject(TerrainSceneNode_GetMesh(_raw),
                                            typeof(Mesh));
            }
        }

        public Vector3D TerrainCenter
        {
            get
            {
                float[] center = new float[3];
                TerrainSceneNode_GetTerrainCenter(_raw, center);
                return Vector3D.FromUnmanaged(center);
            }
        }

        public bool DynamicSelectorUpdate
        {
            set
            {
                TerrainSceneNode_SetDynamicSelectorUpdate(_raw, value);
            }
        }

        /// <summary>
        /// Returns the height for a specified point.
        /// </summary>
        /// <param name="x">X-coordinate on the terrain</param>
        /// <param name="z">Z-coordinate on the terrain</param>
        /// <returns></returns>
        public float GetHeight(float x, float z)
        {
            return TerrainSceneNode_GetHeight(_raw, x, z);
        }

        /// <summary>
        /// Gets the bounding box for the specified patches
        /// </summary>
        /// <returns>A Box3D</returns>
        /// <param name="patchX">Patch X</param>
        /// <param name="patchZ">Patch Z</param>
        public Box3D GetBoundingBox(int patchX, int patchZ)
        {
            float[] box = new float[6];
            TerrainSceneNode_GetBoundingBox(_raw, patchX, patchZ, box);
            return Box3D.FromUnmanaged(box);
        }

        /// <summary>
        /// Override the default generation of distance thresholds.
        /// </summary>
        /// <param name="LOD">LOD</param>
        /// <param name="newDistance">Distance</param>
        public void OverrideLODDistance(int LOD, double newDistance)
        {
            TerrainSceneNode_OverrideLODDistance(_raw, LOD, newDistance);
        }

        /// <summary>
        /// Scales the base texture, similar to makePlanarTextureMapping.
        /// </summary>
        /// <param name="scale">The scaling amount. Values above 1.0 increase the number of time the texture is drawn on the terrain. Values below 0 will decrease the number of times the texture is drawn on the terrain. Using negative values will flip the texture, as well as still scaling it.</param>
        /// <param name="scale2">If set to 0 (default value), this will set the second texture coordinate set to the same values as in the first set. If this is another value than zero, it will scale the second texture coordinate set by this value.</param>
        public void ScaleTexture(float scale, float scale2)
        {
            TerrainSceneNode_ScaleTexture(_raw, scale, scale2);
        }

        /// <summary>
        /// Sets the movement camera threshold.
        /// </summary>
        /// <param name="delta">Delta</param>
        public void SetCameraMovementDelta(float delta)
        {
            TerrainSceneNode_SetCameraMovementDelta(_raw, delta);
        }

        /// <summary>
        /// Sets the rotation camera threshold.
        /// </summary>
        /// <param name="delta">Delta</param>
        public void SetCameraRotationDelta(float delta)
        {
            TerrainSceneNode_SetCameraRotationDelta(_raw, delta);
        }

        /// <summary>
        /// Manually sets the LOD of a patch.
        /// </summary>
        /// <param name="patchX">Patch x coordinate.</param>
        /// <param name="patchZ">Patch z coordinate.</param>
        /// <param name="LOD">The level of detail to set the patch to.</param>
        public void SetLODOfPatch(int patchX, int patchZ, int LOD)
        {
            TerrainSceneNode_SetLODOfPatch(_raw, patchX, patchZ, LOD);
        }

        /// <summary>
        /// Gets the meshbuffer data based on a specified level of detail.
        /// </summary>
        /// <param name="mb">A reference to an MeshBuffer object</param>
        /// <param name="LOD">the level of detail you want the indices from.</param>
        public void GetMeshBufferForLOD(ref MeshBuffer mb, int LOD)
        {
            TerrainSceneNode_GetMeshBufferForLOD(_raw, mb.Raw, LOD);
        }


        #region Native Invokes
        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void TerrainSceneNode_GetBoundingBox(IntPtr terrain, int patchX, int patchZ, [MarshalAs(UnmanagedType.LPArray)] float[] box);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void TerrainSceneNode_GetMeshBufferForLOD(IntPtr terrain, IntPtr mb, int lod);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void TerrainSceneNode_GetBoundingBoxA(IntPtr terrain, [MarshalAs(UnmanagedType.LPArray)] float[] box);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern int TerrainSceneNode_GetIndexCount(IntPtr terrain);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr TerrainSceneNode_GetMesh(IntPtr terrain);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void TerrainSceneNode_GetTerrainCenter(IntPtr terrain, [MarshalAs(UnmanagedType.LPArray)] float[] center);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern float TerrainSceneNode_GetHeight(IntPtr terrain, float x, float z);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void TerrainSceneNode_OverrideLODDistance(IntPtr terrain, int lod, double newDistance);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void TerrainSceneNode_ScaleTexture(IntPtr terrain, float scale, float scale2);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void TerrainSceneNode_SetCameraMovementDelta(IntPtr terrain, float delta);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void TerrainSceneNode_SetCameraRotationDelta(IntPtr terrain, float delta);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void TerrainSceneNode_SetDynamicSelectorUpdate(IntPtr terrain, bool bVal);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void TerrainSceneNode_SetLODOfPatch(IntPtr terrain, int patchX, int patchZ, int LOD);
        #endregion
    }
}
