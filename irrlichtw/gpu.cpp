#include "gpu.h"

IntPtr MaterialRendererServices_GetVideoDriver(IntPtr mrs)
{
    return ((IMaterialRendererServices*)mrs)->getVideoDriver();
}

void MaterialRendererServices_SetBasicRenderStates(IntPtr mrs, IntPtr material, IntPtr lastmaterial, bool resetAllRenderStates)
{
    ((IMaterialRendererServices*)mrs)->setBasicRenderStates(*((SMaterial*)material), *((SMaterial*)lastmaterial), resetAllRenderStates);
}

void MaterialRendererServices_SetPixelShaderConstant(IntPtr mrs, float *data, int startRegister, int constantAmount)
{
    ((IMaterialRendererServices*)mrs)->setPixelShaderConstant(data, startRegister, constantAmount);
}

void MaterialRendererServices_SetPixelShaderConstantA(IntPtr mrs, M_STRING name, float *floats, int count)
{
    ((IMaterialRendererServices*)mrs)->setPixelShaderConstant(name, floats, count);
}

void MaterialRendererServices_SetVertexShaderConstant(IntPtr mrs, float *data, int startRegister, int constantAmount)
{
    ((IMaterialRendererServices*)mrs)->setVertexShaderConstant(data, startRegister, constantAmount);
}

void MaterialRendererServices_SetVertexShaderConstantA(IntPtr mrs, M_STRING name, float *floats, int count)
{
    ((IMaterialRendererServices*)mrs)->setVertexShaderConstant(name, floats, count);
}


class ShaderConstantSetCallBack : public IShaderConstantSetCallBack
{
public:
    ShaderConstantSetCallBack(SHADERCALLBACK call)
    {
        _callback = call;
    }

    virtual void OnSetConstants(IMaterialRendererServices *services, s32 userData)
    {
        _callback(services, userData);
    }

protected:
    SHADERCALLBACK _callback;
};

int GPU_AddHighLevelShaderMaterial(IntPtr gpu, M_STRING program, M_STRING ventrypoint, E_VERTEX_SHADER_TYPE vsCompileTarget, M_STRING pixelShaderProgram, M_STRING psEntryPoint, E_PIXEL_SHADER_TYPE psCompileTarget, SHADERCALLBACK callback, E_MATERIAL_TYPE baseMat, int userData)
{
    return ((IGPUProgrammingServices*)gpu)->addHighLevelShaderMaterial(*program ? 0 : program, ventrypoint, vsCompileTarget, *pixelShaderProgram ? pixelShaderProgram : 0, psEntryPoint, psCompileTarget, new ShaderConstantSetCallBack(callback), baseMat, userData);
}

int GPU_AddHighLevelShaderMaterialFromFiles(IntPtr gpu, M_STRING vsfile, M_STRING ventrypoint, E_VERTEX_SHADER_TYPE vsCompileTarget, M_STRING psfile, M_STRING psEntryPoint, E_PIXEL_SHADER_TYPE psCompileTarget, SHADERCALLBACK callback, E_MATERIAL_TYPE baseMat, int userData)
{
    return ((IGPUProgrammingServices*)gpu)->addHighLevelShaderMaterialFromFiles(*vsfile ? vsfile : 0, ventrypoint, vsCompileTarget, *psfile ? psfile : 0, psEntryPoint, psCompileTarget, new ShaderConstantSetCallBack(callback), baseMat, userData);
}

int GPU_AddShaderMaterial(IntPtr gpu, M_STRING vsprogram, M_STRING psprogram, SHADERCALLBACK callback, E_MATERIAL_TYPE baseMat, int userData)
{
    return ((IGPUProgrammingServices*)gpu)->addShaderMaterial(*vsprogram ? vsprogram : 0, *psprogram ? psprogram : 0, new ShaderConstantSetCallBack(callback), baseMat, userData);
}

int GPU_AddShaderMaterialFromFiles(IntPtr gpu, M_STRING vsprogram, M_STRING psprogram, SHADERCALLBACK callback, E_MATERIAL_TYPE baseMat, int userData)
{
    return ((IGPUProgrammingServices*)gpu)->addShaderMaterialFromFiles(*vsprogram ? vsprogram : 0, *psprogram ? psprogram : 0, new ShaderConstantSetCallBack(callback), baseMat, userData);
}
