#include "main.h"

extern "C"
{
    EXPORT void MeshManipulator_FlipSurfaces(IntPtr mm, IntPtr mesh);
    EXPORT void MeshManipulator_SetVertexColorAlpha(IntPtr mm, IntPtr mesh, int alpha);
    EXPORT void MeshManipulator_SetVertexColors(IntPtr mm, IntPtr mesh, M_SCOLOR alpha);
    EXPORT void MeshManipulator_RecalculateNormals(IntPtr mm, IntPtr mesh, bool smooth);
    EXPORT void MeshManipulator_ScaleMesh(IntPtr mm, IntPtr mesh, M_VECT3DF scale);
    EXPORT void MeshManipulator_TransformMesh (IntPtr mm, IntPtr mesh, M_MAT4 mat);
    EXPORT IntPtr MeshManipulator_CreateMeshCopy(IntPtr mm, IntPtr mesh);
    EXPORT void MeshManipulator_MakePlanarTextureMapping(IntPtr mm, IntPtr mesh, float resolution);
    EXPORT IntPtr MeshManipulator_CreateMeshWithTangents(IntPtr mm, IntPtr mesh);
    EXPORT IntPtr MeshManipulator_CreateMeshWith2TCoords (IntPtr mm, IntPtr mesh);
    EXPORT IntPtr MeshManipulator_CreateMeshUniquePrimitives(IntPtr mm, IntPtr mesh);
    EXPORT int MeshManipulator_GetPolyCount(IntPtr mm, IntPtr mesh);
    EXPORT int MeshManipulator_GetPolyCountA(IntPtr mm, IntPtr amesh);

    // TODO: 
   	// EXPORT void MeshManipulator_RecalculateNormals(IntPtr mm, IntPtr buffer, bool smooth, bool angleWeighted);
	// EXPORT void MeshManipulator_Scale(IntPtr mm, IntPtr mesh, M_VECT3DF factor);
	// EXPORT void MeshManipulator_Scale_MeshBuffer(IntPtr mm, IntPtr buffer, M_VECT3DF factor);
	// EXPORT void MeshManipulator_ScaleTCoords(IntPtr mm, IntPtr mesh, M_VECT2DF factor, int level);
	// EXPORT void MeshManipulator_ScaleTCoords_MeshBuffer(IntPtr mm, IntPtr buffer, M_VECT2DF factor, int level);
	// EXPORT void MeshManipulator_Transform(IntPtr mm, IntPtr mesh, M_MAT4 m);
	// EXPORT void MeshManipulator_Transform_MeshBuffer(IntPtr mm, IntPtr buffer, M_MAT4 m);
    // EXPORT void MeshManipulator_MakePlanarTextureMapping_MeshBuffer(IntPtr mm, IntPtr buffer, float resolution);
    // EXPORT void MeshManipulator_MakePlanarTextureMapping_MeshBuffer_Axis(IntPtr mm, IntPtr buffer, float resolutionS, float resolutionT, int axis, const M_VECT3DF offset);
    // EXPORT IntPtr MeshManipulator_CreateMeshWithTangents(IntPtr mm, IntPtr mesh, bool recalculateNormals, bool smooth, bool angleWeighted);
    // EXPORT IntPtr MeshManipulator_CreateMeshWith1TCoords (IntPtr mm, IntPtr mesh);
    // EXPORT IntPtr MeshManipulator_CreateMeshWelded(IntPtr mm, IntPtr mesh, float tolerance);
    // EXPORT IntPtr MeshManipulator_CreateAnimatedMesh(IntPtr mm, IntPtr mesh, E_ANIMATED_MESH_TYPE type);
}
