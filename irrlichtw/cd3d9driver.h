#include "main.h"
#include "../irrlicht/source/Irrlicht/CD3D9Driver.h"

extern "C"
{
    EXPORT IntPtr   CD3D9Driver_GetD3DDevice9(IntPtr videodriver);

    // TODO: Expose CAPS information
    // EXPORT int      CD3D9Driver_GetVertexShaderVersion(IntPtr videodriver);
    // EXPORT int      CD3D9Driver_GetPixelShaderVersion(IntPtr videodriver);
    // EXPORT M_STRING CD3D9Driver_GetVendorInfo(IntPtr videodriver);
    // EXPORT int      CD3D9Driver_GetMaxTextureWidth(IntPtr videodriver);
    // EXPORT int      CD3D9Driver_GetMaxTextureHeight(IntPtr videodriver);
    // EXPORT int      CD3D9Driver_GetAdapterMaxActiveLights(IntPtr videodriver);
};
