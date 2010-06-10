#include "main.h"

extern "C"
{
    EXPORT ECOLOR_FORMAT Texture_GetColorFormat(IntPtr texture);
    EXPORT E_DRIVER_TYPE Texture_GetDriverType(IntPtr texture);
    EXPORT void Texture_GetOriginalSize(IntPtr texture, M_DIM2DU toR);
    EXPORT s32 Texture_GetPitch(IntPtr texture);
    EXPORT void Texture_RegenerateMipMapLevels(IntPtr texture);
    EXPORT IntPtr Texture_Lock(IntPtr texture);
    EXPORT void Texture_UnLock(IntPtr texture);
    EXPORT const M_STRING Texture_GetName(IntPtr texture);

    // TODO:
    // EXPORT void Texture_GetSize(IntPtr texture, M_DIM2DU toR);
    // EXPORT bool Texture_HasMipMaps(IntPtr texture);
	// EXPORT bool Texture_HasAlpha(IntPtr texture);
	// EXPORT bool Texture_IsRenderTarget(IntPtr texture);
	// EXPORT M_STRING Texture_GetName(IntPtr texture);

    EXPORT void LockResult_GetPixel(IntPtr lock, IntPtr texture, int x, int y, M_SCOLOR color);
    EXPORT void LockResult_SetPixel(IntPtr lock, IntPtr texture, int x, int y, M_SCOLOR color);
}
