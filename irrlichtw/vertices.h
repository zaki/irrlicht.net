#include "main.h"

extern "C"
{
    EXPORT IntPtr Vertices_CreateVertex2TCoords() { return new S3DVertex2TCoords(); }
    EXPORT IntPtr Vertices_CreateVertex() { return new S3DVertex(); }
    EXPORT IntPtr Vertices_CreateVertexTangents() { return new S3DVertexTangents(); }

    EXPORT void Vertices_GetColor(IntPtr vertex, M_SCOLOR color);
    EXPORT void Vertices_GetNormal(IntPtr vertex, M_VECT3DF normal);
    EXPORT void Vertices_GetPos(IntPtr vertex, M_VECT3DF pos);
    EXPORT void Vertices_GetTCoords(IntPtr vertex, M_POS2DF tcoords);
    EXPORT void Vertices_GetTCoords2(IntPtr vertex, M_POS2DF tcoords);
    EXPORT void Vertices_SetColor(IntPtr vertex, M_SCOLOR color);
    EXPORT void Vertices_SetNormal(IntPtr vertex, M_VECT3DF normal);
    EXPORT void Vertices_SetPos(IntPtr vertex, M_VECT3DF pos);
    EXPORT void Vertices_SetTCoords(IntPtr vertex, M_POS2DF tcoords);
    EXPORT void Vertices_SetTCoords2(IntPtr vertex, M_POS2DF tcoords);
    EXPORT E_VERTEX_TYPE Vertices_GetType(IntPtr vertex);
    EXPORT void Vertices_GetBinormal (IntPtr vertex, M_VECT3DF binormal);
    EXPORT void Vertices_SetBinormal (IntPtr vertex, M_VECT3DF binormal);
    EXPORT void Vertices_GetTangent (IntPtr vertex, M_VECT3DF tangent);
    EXPORT void Vertices_SetTangent (IntPtr vertex, M_VECT3DF tangent);
    EXPORT void Vertices_Release (IntPtr vertex);
}
