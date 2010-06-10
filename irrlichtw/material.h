#include "main.h"

extern "C"
{
    EXPORT IntPtr Material_Create() { return new SMaterial(); }
    EXPORT E_MATERIAL_TYPE Material_GetMaterialType(IntPtr material);
    EXPORT void Material_SetMaterialType(IntPtr material, E_MATERIAL_TYPE val);
    EXPORT void Material_GetAmbientColor(IntPtr material, M_SCOLOR color);
    EXPORT void Material_SetAmbientColor(IntPtr material, M_SCOLOR color);
    EXPORT void Material_GetDiffuseColor(IntPtr material, M_SCOLOR color);
    EXPORT void Material_SetDiffuseColor(IntPtr material, M_SCOLOR color);
    EXPORT void Material_GetEmissiveColor(IntPtr material, M_SCOLOR color);
    EXPORT void Material_SetEmissiveColor(IntPtr material, M_SCOLOR color);
    EXPORT void Material_GetSpecularColor(IntPtr material, M_SCOLOR color);
    EXPORT void Material_SetSpecularColor(IntPtr material, M_SCOLOR color);
    EXPORT float Material_GetShininess(IntPtr material);
    EXPORT void Material_SetShininess(IntPtr material, float val);
    EXPORT bool Material_GetWireframe(IntPtr material);
    EXPORT void Material_SetWireframe(IntPtr material, bool val);
    EXPORT float Material_GetMaterialTypeParam(IntPtr material);
    EXPORT void Material_SetMaterialTypeParam(IntPtr material, float val);
    EXPORT unsigned int Material_GetZBuffer(IntPtr material);
    EXPORT void Material_SetZBuffer(IntPtr material, unsigned int val);
    EXPORT bool Material_GetGouraudShading(IntPtr material);
    EXPORT void Material_SetGouraudShading(IntPtr material, bool val);
    EXPORT bool Material_GetLighting(IntPtr material);
    EXPORT void Material_SetLighting(IntPtr material, bool val);
    EXPORT bool Material_GetZWriteEnable(IntPtr material);
    EXPORT void Material_SetZWriteEnable(IntPtr material, bool val);
    EXPORT bool Material_GetBackfaceCulling(IntPtr material);
    EXPORT void Material_SetBackfaceCulling(IntPtr material, bool val);
    EXPORT bool Material_GetFogEnable(IntPtr material);
    EXPORT void Material_SetFogEnable(IntPtr material, bool val);
    EXPORT bool Material_GetNormalizeNormals(IntPtr material);
    EXPORT void Material_SetNormalizeNormals(IntPtr material, bool val);
    

    EXPORT IntPtr Material_GetTexture(IntPtr material,int numtex);
    EXPORT void Material_SetTexture(IntPtr material, int num, IntPtr text);
    EXPORT IntPtr Material_GetMaterialLayer(IntPtr material, u32 nr);
    EXPORT void Material_SetMaterialLayer (IntPtr material, u32 nr, SMaterialLayer* layer);
    //EXPORT void Material_Release (IntPtr material);



    // TODO:
    // EXPORT float Material_GetMaterialTypeParam2(IntPtr material);
    // EXPORT void Material_SetMaterialTypeParam2(IntPtr material, float val);
    // EXPORT float Material_GetThickness(IntPtr material);
    // EXPORT void Material_SetThickness(IntPtr material, float val);
    // EXPORT unsigned int Material_GetAntialiasing(IntPtr material);
    // EXPORT void Material_SetAntialiasing(IntPtr material, unsigned int val);
    // EXPORT unsigned int Material_GetColorMask(IntPtr material);
    // EXPORT void Material_SetColorMask(IntPtr material, unsigned int val);
    // EXPORT unsigned int Material_GetColorMaterial(IntPtr material);
    // EXPORT void Material_SetColorMaterial(IntPtr material, unsigned int val);
    // EXPORT bool Material_GetPointCloud(IntPtr material);
    // EXPORT void Material_SetPointCloud(IntPtr material, bool val);
    // EXPORT bool Material_GetFrontfaceCulling(IntPtr material);
    // EXPORT void Material_SetFrontfaceCulling(IntPtr material, bool val);
    // EXPORT void Material_GetTextureMatrix(IntPtr material, int index, M_MAT4 TxT);
    // EXPORT void Material_SetTextureMatrix(IntPtr material, int index, M_MAT4 TxT);
    // EXPORT bool Material_GetFlag(IntPtr material, E_MATERIAL_FLAG flag);
    // EXPORT void Material_SetFlag(IntPtr material, E_MATERIAL_FLAG flag, bool value);
    // EXPORT bool Material_IsTransparent(IntPtr material);


    //EXPORT IntPtr MaterialLayer_Create() { return new SMaterialLayer(); }
    EXPORT IntPtr MaterialLayer_GetTexture(IntPtr material);
    EXPORT void MaterialLayer_SetTexture(IntPtr material, IntPtr texture);
    EXPORT bool MaterialLayer_GetBilinearFilter(IntPtr material);
    EXPORT void MaterialLayer_SetBilinearFilter(IntPtr material, bool val);
    EXPORT bool MaterialLayer_GetTrilinearFilter(IntPtr material);
    EXPORT void MaterialLayer_SetTrilinearFilter(IntPtr material, bool val);
    EXPORT bool MaterialLayer_GetAnisotropicFilter(IntPtr material);
    EXPORT void MaterialLayer_SetAnisotropicFilter(IntPtr material, bool val);

    EXPORT void MaterialLayer_GetTransform(IntPtr lyr, M_MAT4 TxT);
    EXPORT void MaterialLayer_SetTransform(IntPtr lyr, M_MAT4 TxT);
    //EXPORT void MaterialLayer_Release(IntPtr lyr);


    // TODO:
    // EXPORT int  MaterialLayer_GetTextureWrap(IntPtr lyr);
    // EXPORT void MaterialLayer_SetTextureWrap(IntPtr lyr, int wrap);
    // EXPORT int  MaterialLayer_GetLODBias(IntPtr lyr);
    // EXPORT void MaterialLayer_SetLODBias(IntPtr lyr, int bias);

}
