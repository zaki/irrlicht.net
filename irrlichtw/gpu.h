#include "main.h"

extern "C"
{
    EXPORT IntPtr MaterialRendererServices_GetVideoDriver(IntPtr mrs);
    EXPORT void MaterialRendererServices_SetBasicRenderStates(IntPtr mrs, IntPtr material, IntPtr lastmaterial, bool resetAllRenderStates);
    EXPORT void MaterialRendererServices_SetPixelShaderConstant(IntPtr mrs, float *data, int startRegister, int constantAmount);
    EXPORT void MaterialRendererServices_SetPixelShaderConstantA(IntPtr mrs, M_STRING name, float *floats, int count);
    EXPORT void MaterialRendererServices_SetVertexShaderConstant(IntPtr mrs, float *data, int startRegister, int constantAmount);
    EXPORT void MaterialRendererServices_SetVertexShaderConstantA(IntPtr mrs, M_STRING name, float *floats, int count);

    typedef bool (STDCALL SHADERCALLBACK)(IntPtr, int);

    EXPORT int GPU_AddHighLevelShaderMaterial(IntPtr gpu, M_STRING program, M_STRING ventrypoint, E_VERTEX_SHADER_TYPE vsCompileTarget, M_STRING pixelShaderProgram, M_STRING psEntryPoint, E_PIXEL_SHADER_TYPE psCompileTarget, SHADERCALLBACK callback, E_MATERIAL_TYPE baseMat, int userData);
    EXPORT int GPU_AddHighLevelShaderMaterialFromFiles(IntPtr gpu, M_STRING file, M_STRING ventrypoint, E_VERTEX_SHADER_TYPE vsCompileTarget, M_STRING psfile, M_STRING psEntryPoint, E_PIXEL_SHADER_TYPE psCompileTarget, SHADERCALLBACK callback, E_MATERIAL_TYPE baseMat, int userData);
    EXPORT int GPU_AddShaderMaterial(IntPtr gpu, M_STRING vsprogram, M_STRING psprogram, SHADERCALLBACK callback, E_MATERIAL_TYPE baseMat, int userData);
    EXPORT int GPU_AddShaderMaterialFromFiles(IntPtr gpu, M_STRING vsprogram, M_STRING psprogram, SHADERCALLBACK callback, E_MATERIAL_TYPE baseMat, int userData);
    
    // TODO:
    // EXPORT int GPU_AddHighLevelShaderMaterialFromFiles(IntPtr gpu, IntPtr vsProgram, M_STRING ventrypoint, E_VERTEX_SHADER_TYPE vsCompileTarget, IntPtr psProgram, M_STRING psEntryPoint, E_PIXEL_SHADER_TYPE psCompileTarget, SHADERCALLBACK callback, E_MATERIAL_TYPE baseMat, int userData);
    // EXPORT int GPU_AddShaderMaterialFromFiles_FromReadFile(IntPtr gpu, IntPtr vsProgram, IntPtr psprogram, SHADERCALLBACK callback, E_MATERIAL_TYPE baseMat, int userData);
}
