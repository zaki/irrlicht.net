#include "mesh.h"

IntPtr Mesh_Create(void)
{
    return new SMesh();
}
void Mesh_AddMeshBuffer(IntPtr mesh, IntPtr meshbuf)
{
    ((SMesh*)mesh)->addMeshBuffer((IMeshBuffer*)meshbuf);
}
void Mesh_GetBoundingBox(IntPtr mesh, M_BOX3D box)
{
    UM_BOX3D(((IMesh*)mesh)->getBoundingBox(), box);
}

void Mesh_SetBoundingBox(IntPtr mesh, M_BOX3D box)
{
    ((IMesh*)mesh)->setBoundingBox(MU_BOX3D(box));
}

void Mesh_SetMaterialFlag(IntPtr mesh, E_MATERIAL_FLAG flag, bool newValue)
{
    ((IMesh*)mesh)->setMaterialFlag(flag, newValue);
}

int Mesh_GetMeshBufferCount(IntPtr mesh)
{
    return ((IMesh*)mesh)->getMeshBufferCount();
}

IntPtr Mesh_GetMeshBuffer(IntPtr mesh, int nr)
{
    return ((IMesh*)mesh)->getMeshBuffer(nr);
}

void AnimatedMesh_GetBoundingBox(IntPtr mesh, M_BOX3D box)
{
    UM_BOX3D(((IAnimatedMesh*)mesh)->getBoundingBox(), box);
}

void AnimatedMesh_SetBoundingBox(IntPtr mesh, M_BOX3D box)
{
    ((IAnimatedMesh*)mesh)->setBoundingBox(MU_BOX3D(box));
}

IntPtr AnimatedMesh_GetMesh(IntPtr mesh, int frame, int detailLevel, int startFrameloop, int endFrameloop)
{
    return ((IAnimatedMesh*)mesh)->getMesh(frame, detailLevel, startFrameloop, endFrameloop);
}
E_ANIMATED_MESH_TYPE AnimatedMesh_GetMeshType(IntPtr mesh)
{
    return ((IAnimatedMesh*)mesh)->getMeshType();
}

void AnimatedMesh_GetFrameLoopMD2 (IntPtr mesh, EMD2_ANIMATION_TYPE l, int* outBegin, int* outEnd, int* outFPS)
{
    int b;
    int en;
    int fps;
    ((IAnimatedMeshMD2 *)mesh)->getFrameLoop(l, b, en, fps);
    *outBegin = b;
    *outEnd = en;
    *outFPS = fps;
}

void AnimatedMesh_GetFrameLoopMD2a (IntPtr mesh, M_STRING name, int *outBegin, int *outEnd, int *outFPS)
{
    int b;
    int en;
    int fps;
    ((IAnimatedMeshMD2 *)mesh)->getFrameLoop(UM_STRING(name), b, en, fps);
    *outBegin = b;
    *outEnd = en;
    *outFPS = fps;
}

int AnimationMesh_GetAnimationCountMD2(IntPtr mesh)
{
    return ((IAnimatedMeshMD2 *)mesh)->getAnimationCount();
}

M_STRING AnimationMesh_GetAnimationNameMD2(IntPtr mesh, int nr)
{
    return UM_STRING(((IAnimatedMeshMD2 *)mesh)->getAnimationName(nr));
}


IMeshBuffer* GetMBForIntPtr(IntPtr mb)
{
    return ((IMeshBuffer*)mb);
}

IntPtr MeshBuffer_Create(int type)
{
    if(type == 0)
        return new SMeshBuffer();
    else if(type == 1)
        return new SMeshBufferLightMap();
    return new SMeshBufferTangents();
}

void MeshBuffer_GetBoundingBox(IntPtr meshb, M_BOX3D bb)
{
    UM_BOX3D(GetMBForIntPtr(meshb)->getBoundingBox(), bb);
}

void MeshBuffer_RecalculateBoundingBox(IntPtr meshb)
{
    GetMBForIntPtr(meshb)->recalculateBoundingBox();
}


void MeshBuffer_SetBoundingBox(IntPtr meshb, M_BOX3D bb)
{
    GetMBForIntPtr(meshb)->setBoundingBox(MU_BOX3D(bb));
}

int MeshBuffer_GetIndexCount(IntPtr meshb)
{
    return GetMBForIntPtr(meshb)->getIndexCount();
}

void MeshBuffer_GetIndices(IntPtr meshb, unsigned short* indices)
{
    int count = GetMBForIntPtr(meshb)->getIndexCount();
    for(int i = 0; i < count; i++)
        indices[i] = GetMBForIntPtr(meshb)->getIndices()[i];
}

void MeshBuffer_SetIndices(IntPtr meshb, unsigned short* indices, int count)
{
    switch(MeshBuffer_GetVertexType(meshb))
    {
    case EVT_STANDARD:
        ((SMeshBuffer*)meshb)->Indices.set_pointer(indices, count);
        break;
    case EVT_2TCOORDS:
        ((SMeshBufferLightMap*)meshb)->Indices.set_pointer(indices, count);
        break;
    case EVT_TANGENTS:
        ((SMeshBufferTangents*)meshb)->Indices.set_pointer(indices, count);
        break;
    }
}

unsigned short MeshBuffer_GetIndex(IntPtr meshb, unsigned int nr)
{
    return GetMBForIntPtr(meshb)->getIndices()[nr];
}

void MeshBuffer_SetIndex(IntPtr meshb, unsigned int nr, unsigned short val)
{
    if(GetMBForIntPtr(meshb)->getIndexCount() > nr)
        GetMBForIntPtr(meshb)->getIndices()[nr] = val;
    else
    {
        switch(MeshBuffer_GetVertexType(meshb))
        {
        case EVT_STANDARD:
            ((SMeshBuffer*)meshb)->Indices.push_back(val);
            MeshBuffer_SetIndex(meshb, nr, val);
            break;
        case EVT_2TCOORDS:
            ((SMeshBufferLightMap*)meshb)->Indices.push_back(val);
            MeshBuffer_SetIndex(meshb, nr, val);
            break;
        case EVT_TANGENTS:
            ((SMeshBufferTangents*)meshb)->Indices.push_back(val);
            MeshBuffer_SetIndex(meshb, nr, val);
            break;
        }
    }
}

IntPtr MeshBuffer_GetMaterial(IntPtr meshb)
{
    return &GetMBForIntPtr(meshb)->getMaterial();
}

void MeshBuffer_SetMaterial(IntPtr meshb, IntPtr material)
{
    GetMBForIntPtr(meshb)->getMaterial() = *((SMaterial*)material);
}

int MeshBuffer_GetVertexCount(IntPtr meshb)
{
    return GetMBForIntPtr(meshb)->getVertexCount();
}

E_VERTEX_TYPE MeshBuffer_GetVertexType(IntPtr meshb)
{
    return GetMBForIntPtr(meshb)->getVertexType();
}

IntPtr MeshBuffer_GetVertex(IntPtr meshb, unsigned int nr)
{
    return &(((S3DVertex*)GetMBForIntPtr(meshb)->getVertices())[nr]);
}

void MeshBuffer_SetVertex(IntPtr meshb, unsigned int nr, IntPtr vert)
{
    SMeshBuffer *mb = ((SMeshBuffer*)meshb);
    if(nr >= mb->getVertexCount())
    {
        mb->Vertices.push_back(*((S3DVertex*)vert));
        MeshBuffer_SetVertex(meshb, nr, vert);
    }
    else
        (((S3DVertex*)(mb->getVertices()))[nr]) = *((S3DVertex*)vert);
}
void MeshBuffer_SetColor(IntPtr meshb, M_SCOLOR color)
{
    SMeshBuffer *mb = ((SMeshBuffer*)meshb);
    int cnt = mb->getVertexCount();
    //mb->grab();
    for (int i=0;i<cnt;i++)
    {

        mb->Vertices[i].Color = MU_SCOLOR(color);

    }
    mb->setDirty(irr::scene::EBT_VERTEX);

}

IntPtr MeshBuffer_GetVertex2T(IntPtr meshb, unsigned int nr)
{
    return &(((S3DVertex2TCoords*)GetMBForIntPtr(meshb)->getVertices())[nr]);
}

void MeshBuffer_SetVertex2T(IntPtr meshb, unsigned int nr, IntPtr vert)
{
    SMeshBufferLightMap *mb = ((SMeshBufferLightMap*)meshb);
    if(nr >= mb->getVertexCount())
    {
        mb->Vertices.push_back(*((S3DVertex2TCoords*)vert));
        MeshBuffer_SetVertex2T(meshb, nr, vert);
    }
    else
        (((S3DVertex2TCoords*)(mb->getVertices()))[nr]) = *((S3DVertex2TCoords*)vert);
}

/*
* Mesh Cache
*/

irr::scene::IMeshCache *GetMeshCacheFromIntPtr(IntPtr ptr)
{
    return (irr::scene::IMeshCache *)ptr;
}

void MeshCache_AddMesh (IntPtr mc, M_STRING filename, IntPtr mesh)
{
    GetMeshCacheFromIntPtr(mc)->addMesh(UM_STRING(filename), (IAnimatedMesh*)mesh);
}

void MeshCache_Clear (IntPtr mc)
{
    GetMeshCacheFromIntPtr(mc)->clear();
}

void MeshCache_ClearUnusedMeshes (IntPtr mc)
{
    GetMeshCacheFromIntPtr(mc)->clearUnusedMeshes();
}

IntPtr MeshCache_GetMeshByFilename (IntPtr mc, M_STRING filename)
{
    return GetMeshCacheFromIntPtr(mc)->getMeshByName(UM_STRING(filename));
}

IntPtr MeshCache_GetMeshByIndex (IntPtr mc, irr::u32 index)
{
    return GetMeshCacheFromIntPtr(mc)->getMeshByIndex(index);
}

irr::u32 MeshCache_GetMeshCount (IntPtr mc)
{
    return GetMeshCacheFromIntPtr(mc)->getMeshCount();
}

M_STRING MeshCache_GetMeshFilename (IntPtr mc, IntPtr mesh)
{
    return UM_STRING(GetMeshCacheFromIntPtr(mc)->getMeshName(static_cast<irr::scene::IMesh*>(mesh)).getPath().c_str());
}

M_STRING MeshCache_GetMeshFilenameA (IntPtr mc, IntPtr mesh)
{
    return UM_STRING(GetMeshCacheFromIntPtr(mc)->getMeshName(static_cast<irr::scene::IAnimatedMesh*>(mesh)).getPath().c_str());
}

M_STRING MeshCache_GetMeshFilenameN (IntPtr mc, irr::u32 index)
{
    return UM_STRING(GetMeshCacheFromIntPtr(mc)->getMeshName(index).getPath().c_str());
}

irr::s32 MeshCache_GetMeshIndex (IntPtr mc, IntPtr mesh)
{
    return GetMeshCacheFromIntPtr(mc)->getMeshIndex(static_cast<irr::scene::IMesh*>(mesh));
}

irr::s32 MeshCache_GetMeshIndexA (IntPtr mc, IntPtr mesh)
{
    return GetMeshCacheFromIntPtr(mc)->getMeshIndex(static_cast<irr::scene::IAnimatedMesh*>(mesh));
}

bool MeshCache_IsMeshLoaded (IntPtr mc, M_STRING filename)
{
    _FIX_BOOL_MARSHAL_BUG(GetMeshCacheFromIntPtr(mc)->isMeshLoaded(filename));
}

void MeshCache_RemoveMesh (IntPtr mc, IntPtr mesh)
{
    GetMeshCacheFromIntPtr(mc)->removeMesh(static_cast<irr::scene::IMesh*>(mesh));
}

void MeshCache_RemoveMeshA (IntPtr mc, IntPtr mesh)
{
    GetMeshCacheFromIntPtr(mc)->removeMesh(static_cast<irr::scene::IAnimatedMesh*>(mesh));
}

bool MeshCache_SetMeshFilename (IntPtr mc, IntPtr mesh, M_STRING filename)
{
    _FIX_BOOL_MARSHAL_BUG(GetMeshCacheFromIntPtr(mc)->renameMesh(static_cast<irr::scene::IMesh*>(mesh), filename));
}

bool MeshCache_SetMeshFilenameA (IntPtr mc, IntPtr mesh, M_STRING filename)
{
    _FIX_BOOL_MARSHAL_BUG(GetMeshCacheFromIntPtr(mc)->renameMesh(static_cast<irr::scene::IAnimatedMesh*>(mesh), filename));
}

bool MeshCache_SetMeshFilenameN (IntPtr mc, irr::u32 index, M_STRING filename)
{
    _FIX_BOOL_MARSHAL_BUG(GetMeshCacheFromIntPtr(mc)->renameMesh(index, filename));
}
