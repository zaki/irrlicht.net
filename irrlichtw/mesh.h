#include "main.h"

extern "C"
{
    EXPORT IntPtr Mesh_Create(void);
    EXPORT void   Mesh_GetBoundingBox(IntPtr mesh, M_BOX3D box);
    EXPORT void   Mesh_SetBoundingBox(IntPtr mesh, M_BOX3D box);
    EXPORT void   Mesh_SetMaterialFlag(IntPtr mesh, E_MATERIAL_FLAG flag, bool newValue);
    EXPORT int    Mesh_GetMeshBufferCount(IntPtr mesh);
    EXPORT IntPtr Mesh_GetMeshBuffer(IntPtr mesh, int nr);
    EXPORT void   Mesh_AddMeshBuffer(IntPtr mesh, IntPtr meshbuf);

    // TODO: 
    // EXPORT IntPtr Mesh_RecalculateBoundingBox(IntPtr mesh);
    // EXPORT IntPtr Mesh_GetMeshBuffer_ByMaterial(IntPtr mesh, IntPtr material);
    // EXPORT void   Mesh_SetHardwareMappingHint(IntPtr mesh, E_HARDWARE_MAPPING newMappingHint, E_BUFFER_TYPE buffer);
    // EXPORT void   Mesh_SetDirty(IntPtr mesh, E_BUFFER_TYPE buffer);



    EXPORT void AnimatedMesh_GetBoundingBox(IntPtr mesh, M_BOX3D box);
    EXPORT void AnimatedMesh_SetBoundingBox(IntPtr mesh, M_BOX3D box);
    EXPORT IntPtr AnimatedMesh_GetMesh(IntPtr mesh, int frame, int detailLevel, int startFrameloop, int endFrameloop);
    EXPORT E_ANIMATED_MESH_TYPE AnimatedMesh_GetMeshType(IntPtr mesh);

    // TODO: 
    // EXPORT int    AnimatedMesh_GetFrameCount(IntPtr mesh);
    // EXPORT void   AnimatedMesh_AddMesh(IntPtr amesh, IntPtr mesh);
    // EXPORT void   AnimatedMesh_RecalculateBoundingBox(IntPtr mesh);
    // EXPORT int    AnimatedMesh_GetMeshbufferCount(IntPtr mesh);
    // EXPORT IntPtr AnimatedMesh_GetMeshBuffer(IntPtr mesh, int nr);
    // EXPORT IntPtr AnimatedMesh_GetMeshBuffer_ByMaterial(IntPtr mesh, IntPtr material);
    // EXPORT void   AnimatedMesh_SetMaterialFlag(IntPtr mesh, E_MATERIAL_FLAG flag, bool newValue);
    // EXPORT void   AnimatedMesh_SetHardwareMappingHint(IntPtr mesh, E_HARDWARE_MAPPING newMappingHint, E_BUFFER_TYPE buffer);
    // EXPORT void   AnimatedMesh_SetDirty(IntPtr mesh, E_BUFFER_TYPE buffer);

    // MD2 specific
    EXPORT void AnimatedMesh_GetFrameLoopMD2 (IntPtr mesh, EMD2_ANIMATION_TYPE l, int* outBegin, int* outEnd, int* outFPS);
    EXPORT void AnimatedMesh_GetFrameLoopMD2a (IntPtr mesh, M_STRING name, int *outBegin, int *outEnd, int *outFPS);
    EXPORT int AnimationMesh_GetAnimationCountMD2(IntPtr mesh);
    EXPORT M_STRING AnimationMesh_GetAnimationNameMD2(IntPtr mesh, int nr);
    
    
    EXPORT IntPtr MeshBuffer_Create(int type);
    EXPORT void MeshBuffer_GetBoundingBox(IntPtr meshb, M_BOX3D bb);
    EXPORT void MeshBuffer_SetBoundingBox(IntPtr meshb, M_BOX3D bb);
    EXPORT int MeshBuffer_GetIndexCount(IntPtr meshb);
    EXPORT void MeshBuffer_GetIndices(IntPtr meshb, unsigned short* indices);
    EXPORT void MeshBuffer_SetIndices(IntPtr meshb, unsigned short* indices, int count);
    EXPORT unsigned short MeshBuffer_GetIndex(IntPtr meshb, unsigned int nr);
    EXPORT void MeshBuffer_SetIndex(IntPtr meshb, unsigned int nr, unsigned short val);
    EXPORT IntPtr MeshBuffer_GetMaterial(IntPtr meshb);
    EXPORT void MeshBuffer_SetMaterial(IntPtr meshb, IntPtr material);
    EXPORT int MeshBuffer_GetVertexCount(IntPtr meshb);
    EXPORT E_VERTEX_TYPE MeshBuffer_GetVertexType(IntPtr meshb);
    EXPORT IntPtr MeshBuffer_GetVertex(IntPtr meshb, unsigned int nr);
    EXPORT void MeshBuffer_SetVertex(IntPtr meshb, unsigned int nr, IntPtr vert);
    EXPORT IntPtr MeshBuffer_GetVertex2T(IntPtr meshb, unsigned int nr);
    EXPORT void MeshBuffer_SetVertex2T(IntPtr meshb, unsigned int nr, IntPtr vert);
    EXPORT void MeshBuffer_SetColor(IntPtr meshb, M_SCOLOR color);
    EXPORT void MeshBuffer_RecalculateBoundingBox(IntPtr meshb);

    // TODO:
    // EXPORT E_INDEX_TYPE MeshBuffer_GetIndexType(IntPtr meshb);
    // EXPORT void MeshBuffer_Append(IntPtr meshb, IntPtr vertices, int numVertices, unsigned short* indices, int numIndices);
	// EXPORT void MeshBuffer_Append(IntPtr meshb, IntPtr other);
	// EXPORT E_HARDWARE_MAPPING MeshBuffer_GetHardwareMappingHint_Vertex(IntPtr meshb);
	// EXPORT E_HARDWARE_MAPPING MeshBuffer_GetHardwareMappingHint_Index(IntPtr meshb);
	// EXPORT void MeshBuffer_SetHardwareMappingHint(IntPtr meshb, E_HARDWARE_MAPPING newMappingHint, E_BUFFER_TYPE buffer);
	// EXPORT void MeshBuffer_SetDirty(IntPtr meshb, E_BUFFER_TYPE buffer);
	// EXPORT int MeshBuffer_GetChangedID_Vertex(IntPtr meshb);
	// EXPORT int MeshBuffer_GetChangedID_Index(IntPtr meshb);



    EXPORT void MeshCache_AddMesh (IntPtr mc, M_STRING filename, IntPtr mesh);
    EXPORT void MeshCache_Clear (IntPtr mc);
    EXPORT void MeshCache_ClearUnusedMeshes (IntPtr mc);
    EXPORT IntPtr MeshCache_GetMeshByFilename (IntPtr mc, M_STRING filename);
    EXPORT IntPtr MeshCache_GetMeshByIndex (IntPtr mc, irr::u32 index);
    EXPORT irr::u32 MeshCache_GetMeshCount (IntPtr mc);
    EXPORT M_STRING MeshCache_GetMeshFilename (IntPtr mc, IntPtr mesh);
    EXPORT M_STRING MeshCache_GetMeshFilenameA (IntPtr mc, IntPtr mesh);
    EXPORT M_STRING MeshCache_GetMeshFilenameN (IntPtr mc, irr::u32 index);
    EXPORT irr::s32 MeshCache_GetMeshIndex (IntPtr mc, IntPtr mesh);
    EXPORT irr::s32 MeshCache_GetMeshIndexA (IntPtr mc, IntPtr mesh);
    EXPORT bool MeshCache_IsMeshLoaded (IntPtr mc, M_STRING filename);
    EXPORT void MeshCache_RemoveMesh (IntPtr mc, IntPtr mesh);
    EXPORT void MeshCache_RemoveMeshA (IntPtr mc, IntPtr mesh);
    EXPORT bool MeshCache_SetMeshFilename (IntPtr mc, IntPtr mesh, M_STRING filename);
    EXPORT bool MeshCache_SetMeshFilenameA (IntPtr mc, IntPtr mesh, M_STRING filename);
    EXPORT bool MeshCache_SetMeshFilenameN (IntPtr mc, irr::u32 index, M_STRING filename);
}
