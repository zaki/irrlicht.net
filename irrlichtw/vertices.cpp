#include "vertices.h"

void Vertices_GetColor(IntPtr vertex, M_SCOLOR color)
{
    S3DVertex *vert = (S3DVertex*)vertex;
    UM_SCOLOR(vert->Color, color);
}

void Vertices_GetNormal(IntPtr vertex, M_VECT3DF normal)
{
    S3DVertex vert = *((S3DVertex*)vertex);
    UM_VECT3DF(vert.Normal, normal);
}

void Vertices_GetPos(IntPtr vertex, M_VECT3DF pos)
{
    S3DVertex *vert = ((S3DVertex*)vertex);
    UM_VECT3DF(vert->Pos, pos);
}

void Vertices_GetTCoords(IntPtr vertex, M_POS2DF tcoords)
{
    S3DVertex vert = *((S3DVertex*)vertex);
    UM_POS2DF(position2d<float>(vert.TCoords.X, vert.TCoords.Y), tcoords);
}

void Vertices_GetTCoords2(IntPtr vertex, M_POS2DF tcoords)
{
    S3DVertex2TCoords vert = *((S3DVertex2TCoords*)vertex);
    UM_POS2DF(position2d<float>(vert.TCoords2.X, vert.TCoords2.Y), tcoords);
}



void Vertices_SetColor(IntPtr vertex, M_SCOLOR color)
{
    S3DVertex *vert = ((S3DVertex*)vertex);
    vert->Color = MU_SCOLOR(color);
}

void Vertices_SetNormal(IntPtr vertex, M_VECT3DF normal)
{
    S3DVertex *vert = ((S3DVertex*)vertex);
    vert->Normal = MU_VECT3DF(normal);
}

void Vertices_SetPos(IntPtr vertex, M_VECT3DF pos)
{
    S3DVertex *vert = ((S3DVertex*)vertex);
    vert->Pos = MU_VECT3DF(pos);
}

void Vertices_SetTCoords(IntPtr vertex, M_POS2DF tcoords)
{
    S3DVertex *vert = ((S3DVertex*)vertex);
    irr::core::position2d<float> c = MU_POS2DF(tcoords);
    vert->TCoords = irr::core::vector2d<float>(c.X, c.Y);
}

void Vertices_SetTCoords2(IntPtr vertex, M_POS2DF tcoords)
{
    S3DVertex2TCoords *vert = ((S3DVertex2TCoords*)vertex);
    irr::core::position2d<float> c = MU_POS2DF(tcoords);
    vert->TCoords2 = irr::core::vector2d<float>(c.X, c.Y);
}

E_VERTEX_TYPE Vertices_GetType(IntPtr vertex)
{
    return ((S3DVertex*)vertex)->getType();
}

void Vertices_GetBinormal (IntPtr vertex, M_VECT3DF binormal)
{
    S3DVertexTangents *vert = ((S3DVertexTangents*)vertex);
    UM_VECT3DF(vert->Binormal, binormal);
}

void Vertices_SetBinormal (IntPtr vertex, M_VECT3DF binormal)
{
    S3DVertexTangents *vert = ((S3DVertexTangents*)vertex);
    vert->Binormal = MU_VECT3DF(binormal);
}

void Vertices_GetTangent (IntPtr vertex, M_VECT3DF tangent)
{
    S3DVertexTangents *vert = ((S3DVertexTangents*)vertex);
    UM_VECT3DF(vert->Tangent, tangent);
}

void Vertices_SetTangent (IntPtr vertex, M_VECT3DF tangent)
{
    S3DVertexTangents *vert = ((S3DVertexTangents*)vertex);
    vert->Tangent = MU_VECT3DF(tangent);
}

void Vertices_Release (IntPtr vertex)
{
    if (vertex == 0)
        return;
    delete (S3DVertex*)vertex;
}

