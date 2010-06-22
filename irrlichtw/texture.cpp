#include "texture.h"

ITexture *GetTextureFromPtr(IntPtr texture)
{
    return (ITexture*)texture;
}

ECOLOR_FORMAT Texture_GetColorFormat(IntPtr texture)
{
    return GetTextureFromPtr(texture)->getColorFormat();
}

E_DRIVER_TYPE Texture_GetDriverType(IntPtr texture)
{
    return GetTextureFromPtr(texture)->getDriverType();
}

void Texture_GetOriginalSize(IntPtr texture, M_DIM2DU toR)
{
    UM_DIM2DU(GetTextureFromPtr(texture)->getOriginalSize(), toR);
}

s32 Texture_GetPitch(IntPtr texture)
{
    return GetTextureFromPtr(texture)->getPitch();
}

const M_STRING Texture_GetName(IntPtr texture)
{
    return ((ITexture*)texture)->getName().getPath().c_str();
}

void Texture_RegenerateMipMapLevels(IntPtr texture)
{
    GetTextureFromPtr(texture)->regenerateMipMapLevels();
}


IntPtr Texture_Lock(IntPtr texture)
{
    return GetTextureFromPtr(texture)->lock();
}
void Texture_UnLock(IntPtr texture)
{
    GetTextureFromPtr(texture)->unlock();
}

void LockResult_SetPixel(IntPtr lock, IntPtr texture, int x, int y, M_SCOLOR color)
{
    int ncolor = ((color[0] & 0xff)<<24) |
        ((color[1] & 0xff)<<16) |
        ((color[2] & 0xff)<<8)  |
        (color[3] & 0xff);
    ITexture *text = (ITexture*)texture;
    switch(text->getColorFormat())
    {
    case ECF_A1R5G5B5:
        (((short*)lock)[y * (text->getPitch() / 2) + x]) = irr::video::A8R8G8B8toA1R5G5B5(ncolor);
        break;
    case ECF_R5G6B5:
        ((short*)lock)[y * (text->getPitch() / 2) + x] = (0x8000 | (ncolor & 0x1F) | ((ncolor >> 1)&0x7FE0));
        break;
    case ECF_R8G8B8:
        {
            unsigned char* p = &((unsigned char*)lock)[y * text->getPitch() + (x * 3)];
            p[0] = color[1];
            p[1] = color[2];
            p[2] = color[3];
        }
        break;
    case ECF_A8R8G8B8:
        ((int*)lock)[x + y * (text->getPitch() / 4)] = ncolor;
        break;
    }
}

void LockResult_GetPixel(IntPtr lock, IntPtr texture, int x, int y, M_SCOLOR fcolor)
{
    irr::video::SColor color;
    ITexture *text = (ITexture*)texture;
    switch(text->getColorFormat())
    {
    case ECF_A1R5G5B5:
        color = irr::video::A1R5G5B5toA8R8G8B8(((irr::s16*)lock)[y * (text->getPitch() / 2) + x]);
        break;
    case ECF_R5G6B5:
        color = irr::video::R5G6B5toA8R8G8B8(((irr::s16*)lock)[y * (text->getPitch() / 2) + x]);
        break;
    case ECF_R8G8B8:
        {
            irr::u8* p = &((irr::u8*)lock)[y * text->getPitch() + (x * 3)];
            color.set(255, p[0], p[1], p[2]);
        }
        break;
    default:
    case ECF_A8R8G8B8:
        color = ((irr::s32*)lock)[x + y * (text->getPitch() / 4)];
        break;
    }
    UM_SCOLOR(color, fcolor);
}
