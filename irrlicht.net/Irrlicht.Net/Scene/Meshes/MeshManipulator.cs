using System;
using System.Runtime.InteropServices;
using System.Security;

namespace IrrlichtNET
{
    public class MeshManipulator : NativeElement
    {
        public MeshManipulator(IntPtr raw)
            : base(raw)
        {
        }

        /// <summary>
        /// Creates a copy of the mesh, which will only consist of S3DVertexTangents vertices.
        /// This is useful if you want to draw tangent space normal mapped geometry because it calculates the tangent and binormal data which is needed there.
        /// </summary>
        /// <param name="baseMesh">Input mesh</param>
        /// <returns>Mesh consiting only of S3DVertexTangents vertices.</returns>
        public Mesh CreateMeshWithTangents(Mesh baseMesh)
        {
            return (Mesh)
                NativeElement.GetObject(MeshManipulator_CreateMeshWithTangents(_raw, baseMesh.Raw),
                                        typeof(Mesh));
        }

        /// <summary>
        /// Creates a copy of the mesh, which will only consist of Vertex3DT2Coord vertices.
        /// </summary>
        /// <param name="baseMesh">
        /// A mesh to be created from<see cref="Mesh"/>
        /// </param>
        /// <returns>
        /// A new mesh with 2T coords <see cref="Mesh"/>
        /// </returns>
        public Mesh CreateMeshWith2TCoords(Mesh baseMesh)
        {
            return (Mesh)
                NativeElement.GetObject(MeshManipulator_CreateMeshWith2TCoords(_raw, baseMesh.Raw),
                                        typeof(Mesh));
        }

        /// <summary>
        /// Unweld vertices.
        /// </summary>
        /// <param name="baseMesh">Input mesh</param>
        /// <returns>Result mesh</returns>
        public Mesh CreateMeshUniquePrimitives(Mesh baseMesh)
        {
            return (Mesh)
                NativeElement.GetObject(MeshManipulator_CreateMeshUniquePrimitives(_raw, baseMesh.Raw),
                                        typeof(Mesh));
        }

        /// <summary>
        /// Returns amount of polygons in mesh.
        /// </summary>
        /// <param name="mesh">Mesh</param>
        /// <returns>Amount of polygons</returns>
        public int GetPolyCount(Mesh mesh)
        {
            return MeshManipulator_GetPolyCount(_raw, mesh.Raw);
        }

        /// <summary>
        /// Returns amount of polygons in mesh.
        /// </summary>
        /// <param name="mesh">Mesh</param>
        /// <returns>Amount of polygons</returns>
        public int GetPolyCount(AnimatedMesh mesh)
        {
            return MeshManipulator_GetPolyCountA(_raw, mesh.Raw);
        }

        /// <summary>
        /// Creates a planar texture mapping on the mesh.
        /// </summary>
        /// <param name="baseMesh">Mesh on which the operation is performed. </param>
        /// <param name="resolution">Resolution of the planar mapping. This is the value specifying which is the relation between world space and texture coordinate space. </param>
        public void MakePlanarTextureMapping(Mesh baseMesh, float resolution)
        {
            MeshManipulator_MakePlanarTextureMapping(_raw, baseMesh.Raw, resolution);
        }

        /// <summary>
        /// Flips the direction of surfaces.
        /// Changes backfacing triangles to frontfacing triangles and vice versa
        /// </summary>
        /// <param name="m">Mesh on which the operation is performed. </param>
        public void FlipSurfaces(Mesh m)
        {
            MeshManipulator_FlipSurfaces(_raw, m.Raw);
        }

        /// <summary>
        /// Recalculates all normals of the mesh.
        /// </summary>
        /// <param name="mesh">Mesh on which the operation is performed.</param>
        /// <param name="smooth"></param>
        public void RecalculateNormals(Mesh mesh, bool smooth)
        {
            MeshManipulator_RecalculateNormals(_raw, mesh.Raw, smooth);
        }

        /// <summary>
        /// Scales the whole mesh.
        /// </summary>
        /// <param name="mesh">Mesh on which the operation is performed. </param>
        /// <param name="scale">Scale factor. </param>
        public void ScaleMesh(Mesh mesh, Vector3D scale)
        {
            MeshManipulator_ScaleMesh(_raw, mesh.Raw, scale.ToUnmanaged());
        }

        /// <summary>
        /// Sets the alpha vertex color value of the whole mesh to a new value.
        /// </summary>
        /// <param name="mesh">Mesh on which the operation is performed. </param>
        /// <param name="alpha">New alpha value. Must be a value between 0 and 255. </param>
        public void SetVertexColorAlpha(Mesh mesh, int alpha)
        {
            MeshManipulator_SetVertexColorAlpha(_raw, mesh.Raw, alpha);
        }

        /// <summary>
        /// Sets the colors of all vertices to one color.
        /// </summary>
        /// <param name="mesh">Mesh on which the operation is performed. </param>
        /// <param name="color">New color.</param>
        public void SetVertexColors(Mesh mesh, Color color)
        {
            MeshManipulator_SetVertexColors(_raw, mesh.Raw, color.ToUnmanaged());
        }

        /// <summary>
        /// Applies a transformation.
        /// </summary>
        /// <param name="mesh">
        /// A mesh to be transformed <see cref="Mesh"/>
        /// </param>
        /// <param name="mat">
        /// A transform matrix <see cref="Matrix4"/>
        /// </param>
        public void TransformMesh(Mesh mesh, Matrix4 mat)
        {
            MeshManipulator_TransformMesh(_raw, mesh.Raw, mat.ToUnmanaged());
        }

        public Mesh CreateMeshCopy(Mesh mesh)
        {
            return (Mesh)
                NativeElement.GetObject(MeshManipulator_CreateMeshCopy(_raw, mesh.Raw),
                                        typeof(Mesh));
        }



        #region Native Invokes
        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr MeshManipulator_CreateMeshWithTangents(IntPtr mm, IntPtr mesh);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr MeshManipulator_CreateMeshUniquePrimitives(IntPtr mm, IntPtr mesh);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void MeshManipulator_MakePlanarTextureMapping(IntPtr mm, IntPtr mesh, float resolution);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void MeshManipulator_FlipSurfaces(IntPtr mm, IntPtr mesh);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void MeshManipulator_RecalculateNormals(IntPtr mm, IntPtr mesh, bool smooth);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void MeshManipulator_ScaleMesh(IntPtr mm, IntPtr mesh, float[] scale);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void MeshManipulator_SetVertexColorAlpha(IntPtr mm, IntPtr mesh, int alpha);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void MeshManipulator_SetVertexColors(IntPtr mm, IntPtr mesh, int[] alpha);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern int MeshManipulator_GetPolyCount(IntPtr mm, IntPtr mesh);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern int MeshManipulator_GetPolyCountA(IntPtr mm, IntPtr amesh);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr MeshManipulator_CreateMeshWith2TCoords(IntPtr mm, IntPtr mesh);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void MeshManipulator_TransformMesh(IntPtr mm, IntPtr mesh, float[] mat);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr MeshManipulator_CreateMeshCopy(IntPtr mm, IntPtr mesh);
        #endregion
    }
}
