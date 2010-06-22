#include "material.h"

SMaterial *GetMatFromIntPtr(IntPtr material)
{
    return ((SMaterial*)material);
}

SMaterialLayer *GetMatLyrFromIntPtr(IntPtr layer)
{
    return ((SMaterialLayer*)layer);
}

void Material_GetAmbientColor(IntPtr material, M_SCOLOR color)
{
    UM_SCOLOR(GetMatFromIntPtr(material)->AmbientColor, color);
}
void Material_GetDiffuseColor(IntPtr material, M_SCOLOR color)
{
    UM_SCOLOR(GetMatFromIntPtr(material)->DiffuseColor, color);
}
void Material_GetEmissiveColor(IntPtr material, M_SCOLOR color)
{
    UM_SCOLOR(GetMatFromIntPtr(material)->EmissiveColor, color);
}
E_MATERIAL_TYPE Material_GetMaterialType(IntPtr material)
{
    return GetMatFromIntPtr(material)->MaterialType;
}
float Material_GetMaterialTypeParam(IntPtr material)
{
    return GetMatFromIntPtr(material)->MaterialTypeParam;
}
float Material_GetShininess(IntPtr material)
{
    return GetMatFromIntPtr(material)->Shininess;
}
void Material_GetSpecularColor(IntPtr material, M_SCOLOR color)
{
    UM_SCOLOR(GetMatFromIntPtr(material)->SpecularColor, color);
}

/*
* Alarm! This is REALLY deprecated! Do not use it in any way.
*/
IntPtr Material_GetTexture(IntPtr material, int numtex)
{
    return GetMatFromIntPtr(material)->getTexture(numtex);
}
void Material_SetTexture(IntPtr material, s32 nr, IntPtr texture)
{
    GetMatFromIntPtr(material)->setTexture(nr, (ITexture*)texture);
}
/* */

bool Material_GetBackfaceCulling(IntPtr material)
{
    _FIX_BOOL_MARSHAL_BUG(GetMatFromIntPtr(material)->BackfaceCulling);
}

bool Material_GetFogEnable(IntPtr material)
{
    _FIX_BOOL_MARSHAL_BUG(GetMatFromIntPtr(material)->FogEnable);
}
bool Material_GetGouraudShading(IntPtr material)
{
    _FIX_BOOL_MARSHAL_BUG(GetMatFromIntPtr(material)->GouraudShading);
}
bool Material_GetLighting(IntPtr material)
{
    _FIX_BOOL_MARSHAL_BUG(GetMatFromIntPtr(material)->Lighting);
}
bool Material_GetNormalizeNormals(IntPtr material)
{
    _FIX_BOOL_MARSHAL_BUG(GetMatFromIntPtr(material)->NormalizeNormals);
}
bool Material_GetWireframe(IntPtr material)
{
    _FIX_BOOL_MARSHAL_BUG(GetMatFromIntPtr(material)->Wireframe);
}
unsigned int Material_GetZBuffer(IntPtr material)
{
    return (GetMatFromIntPtr(material)->ZBuffer);
}
bool Material_GetZWriteEnable(IntPtr material)
{
    _FIX_BOOL_MARSHAL_BUG(GetMatFromIntPtr(material)->ZWriteEnable);
}
void Material_SetAmbientColor(IntPtr material, M_SCOLOR color)
{
    GetMatFromIntPtr(material)->AmbientColor = MU_SCOLOR(color);
}
void Material_SetDiffuseColor(IntPtr material, M_SCOLOR color)
{
    GetMatFromIntPtr(material)->DiffuseColor = MU_SCOLOR(color);
}
void Material_SetEmissiveColor(IntPtr material, M_SCOLOR color)
{
    GetMatFromIntPtr(material)->EmissiveColor = MU_SCOLOR(color);
}
void Material_SetMaterialType(IntPtr material, E_MATERIAL_TYPE val)
{
    GetMatFromIntPtr(material)->MaterialType = val;
}
void Material_SetMaterialTypeParam(IntPtr material, float val)
{
    GetMatFromIntPtr(material)->MaterialTypeParam = val;
}
void Material_SetShininess(IntPtr material, float val)
{
    GetMatFromIntPtr(material)->Shininess = val;
}
void Material_SetSpecularColor(IntPtr material, M_SCOLOR color)
{
    GetMatFromIntPtr(material)->SpecularColor = MU_SCOLOR(color);
}
void Material_SetBackfaceCulling(IntPtr material, bool val)
{
    GetMatFromIntPtr(material)->BackfaceCulling = val;
}
void Material_SetFogEnable(IntPtr material, bool val)
{
    GetMatFromIntPtr(material)->FogEnable = val;
}
void Material_SetGouraudShading(IntPtr material, bool val)
{
    GetMatFromIntPtr(material)->GouraudShading = val;
}
void Material_SetLighting(IntPtr material, bool val)
{
    GetMatFromIntPtr(material)->Lighting = val;
}
void Material_SetNormalizeNormals(IntPtr material, bool val)
{
    GetMatFromIntPtr(material)->NormalizeNormals = val;
}
void Material_SetWireframe(IntPtr material, bool val)
{
    GetMatFromIntPtr(material)->Wireframe = val;
}
void Material_SetZBuffer(IntPtr material, unsigned int val)
{
    GetMatFromIntPtr(material)->ZBuffer = val;
}
void Material_SetZWriteEnable(IntPtr material, bool val)
{
    GetMatFromIntPtr(material)->ZWriteEnable = val;
}

IntPtr Material_GetMaterialLayer(IntPtr material, u32 nr)
{
    if ((nr<0)||(nr>3)) return NULL;
    return &GetMatFromIntPtr(material)->TextureLayer[nr];
}

void Material_SetMaterialLayer (IntPtr material, u32 nr, SMaterialLayer* layer)
{
    if ((nr<0)||(nr>3)) return;
    GetMatFromIntPtr(material)->TextureLayer[nr] = *layer;
}

/*
void Material_Release (IntPtr material)
{
if (material == 0)
return;
delete GetMatFromIntPtr(material);
}
*/

/*
* Material Layer
*/

bool MaterialLayer_GetAnisotropicFilter(IntPtr material)
{
    // Values 0 and 1 mean disabled. Values 2-16 gives anisotropy degree
    _FIX_BOOL_MARSHAL_BUG(GetMatLyrFromIntPtr(material)->AnisotropicFilter < 2);
}
void MaterialLayer_SetAnisotropicFilter(IntPtr material, bool val)
{
    GetMatLyrFromIntPtr(material)->AnisotropicFilter = val;
}

bool MaterialLayer_GetBilinearFilter(IntPtr material)
{
    _FIX_BOOL_MARSHAL_BUG(GetMatLyrFromIntPtr(material)->BilinearFilter);
}
void MaterialLayer_SetBilinearFilter(IntPtr material, bool val)
{
    GetMatLyrFromIntPtr(material)->BilinearFilter = val;
}

bool MaterialLayer_GetTrilinearFilter(IntPtr material)
{
    _FIX_BOOL_MARSHAL_BUG(GetMatLyrFromIntPtr(material)->TrilinearFilter);
}
void MaterialLayer_SetTrilinearFilter(IntPtr material, bool val)
{
    GetMatLyrFromIntPtr(material)->TrilinearFilter = val;
}

void MaterialLayer_SetTexture(IntPtr material, IntPtr texture)
{
    GetMatLyrFromIntPtr(material)->Texture = (ITexture*)texture;
}

IntPtr MaterialLayer_GetTexture(IntPtr material)
{
    return GetMatLyrFromIntPtr(material)->Texture;
}

void MaterialLayer_GetTransform(IntPtr lyr, M_MAT4 TxT)
{
    return UM_MAT4(GetMatLyrFromIntPtr(lyr)->getTextureMatrix(),TxT);
}

void MaterialLayer_SetTransform(IntPtr lyr,M_MAT4 TxT)
{
    GetMatLyrFromIntPtr(lyr)->setTextureMatrix(MU_MAT4(TxT));
}
//End Edit Kiwsa*/

/*
void MaterialLayer_Release(IntPtr lyr)
{
if (lyr == 0)
return;

delete GetMatLyrFromIntPtr(lyr);
}
*/
