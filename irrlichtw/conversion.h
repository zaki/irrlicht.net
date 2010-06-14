#ifndef CONVERSION_H
#define CONVERSION_H

#include <stdlib.h>

#include <stdio.h>
#include <iostream>
#include <wchar.h>
#include <string>
#include "../irrlicht/include/irrlicht.h"

#ifdef WIN32
#define STDCALL __stdcall*
#define uint unsigned int
#else
#define STDCALL *
#endif

//This type's name is taken from dotNET's match
//Of course in C++ it is just a basic pointer but it is quite more in C#
typedef void* IntPtr;

//Special header for Microsoft's Visual Studio
//Needed for DllImport
//Of course for a Linux compilation, nothing is needed that's why we almost undefine the EXPORT macro
#ifdef _MSC_VER
#define EXPORT __declspec(dllexport)
#else
#define EXPORT
#endif

//Please, DO NOT THINK I AM MAD, this is needed for a pointless bug
//In Visual Studio 8
// Zaki:
//#ifdef _MSC_VER
//bool fixmarshal(bool val);
//#define _FIX_BOOL_MARSHAL_BUG(val) return fixmarshal(val);
//#else
#define _FIX_BOOL_MARSHAL_BUG(val) return val;
//#endif

extern "C" { EXPORT int Pointer_GetReferenceCount(IntPtr pointer); }
extern "C" { EXPORT void Pointer_SafeRelease(IntPtr pointer); }

//Now we will define all structures that need to be converted
//Between Managed and Unmanaged code.
//PS : UM means Unmanaged => Managed and MU means Managed => Unmanaged
#define M_DIM2DS int*
#define M_DIM2DU unsigned int*
#define MU_DIM2DS(val) irr::core::dimension2d<s32>(val[0], val[1])
#define MU_DIM2DU(val) irr::core::dimension2d<u32>(val[0], val[1])
void UM_DIM2DS(irr::core::dimension2d<int> base, M_DIM2DS t);
void UM_DIM2DU(irr::core::dimension2d<unsigned int> base, M_DIM2DU t);

#define M_DIM2US int*
#define MU_DIM2US(val) irr::core::dimension2d<u32>(val[0], val[1])
void UM_DIM2US(irr::core::dimension2d<unsigned int> base, M_DIM2US t);

#define M_DIM2DF float*
#define MU_DIM2DF(val) irr::core::dimension2d<float>(val[0], val[1])
void UM_DIM2DF(irr::core::dimension2d<float> base, M_DIM2DF t);

#define M_POS2DS int*
#define MU_POS2DS(val) irr::core::position2d<irr::s32>(val[0], val[1])
void UM_POS2DS(irr::core::position2d<int> base, M_POS2DS t);

#define M_POS2DF float*
#define MU_POS2DF(val) irr::core::position2d<float>(val[0], val[1])
void UM_POS2DF(irr::core::position2d<float> base, M_POS2DF t);

#define M_SCOLOR int*
#define MU_SCOLOR(val) irr::video::SColor(val[0], val[1], val[2], val[3])
void UM_SCOLOR(irr::video::SColor color, M_SCOLOR t);

#define M_SCOLORF float*
#define MU_SCOLORF(val) irr::video::SColorf(val[0], val[1], val[2], val[3])
void UM_SCOLORF(irr::video::SColorf color, M_SCOLORF t);

#define M_VECT3DF float*
#define MU_VECT3DF(val) irr::core::vector3df(val[0], val[1], val[2])
void UM_VECT3DF(irr::core::vector3df base, M_VECT3DF t);

#define M_MAT4 float*
irr::core::matrix4 MU_MAT4(M_MAT4 val);
void UM_MAT4(irr::core::matrix4 val, M_MAT4 t);

#define M_BOX3D float*
#define MU_BOX3D(val) irr::core::aabbox3d<float>(val[0], val[1], val[2], val[3], val[4], val[5])
void UM_BOX3D(irr::core::aabbox3d<float> base, M_BOX3D);

#define M_LINE3D float*
#define MU_LINE3D(val) irr::core::line3d<float>(val[0], val[1], val[2], val[3], val[4], val[5])
void UM_LINE3D(irr::core::line3d<float> base, M_LINE3D);

#define M_TRIANGLE3DF float*
irr::core::triangle3df MU_TRIANGLE3DF(float*);
void UM_TRIANGLE3DF (irr::core::triangle3d<float> base, M_TRIANGLE3DF );

#define M_RECT int*
#define MU_RECT(val) irr::core::rect<int>(val[0], val[1], val[2], val[3])
void UM_RECT(irr::core::rect<int> base, M_RECT);

#define M_STRING char*
M_STRING UM_STRING(const wchar_t* base);
wchar_t *MU_WCHAR(const M_STRING base);
M_STRING UM_STRING(const M_STRING base);

#define IRRSTRING irr::core::stringw
M_STRING IM_STRING(const IRRSTRING base);

#define M_PLANE3DF float*
#define MU_PLANE3DF(val) irr::core::plane3d<float>(irr::core::vector3df(val[0], val[1], val[2]), val[3])
void UM_PLANE3DF(irr::core::plane3d<float> base, M_PLANE3DF);

extern "C"
{
    EXPORT void freeUMMemory(IntPtr pointer, bool arrayType);
}

class VIReferenceCounted : public virtual irr::IReferenceCounted
{
public:
    virtual void dummy() {return;}

};

#endif
