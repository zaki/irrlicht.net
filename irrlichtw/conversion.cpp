#include "conversion.h"
#include <iostream>

void freeUMMemory(IntPtr pointer, bool arrayType)
{
    if (arrayType)
        delete[] pointer;
    else
        delete pointer;
}

int Pointer_GetReferenceCount(IntPtr pointer)
{
    irr::IReferenceCounted* tmpPtr = NULL;

    if(pointer)
    {
#ifdef VIREFERENCECOUNTED
        tmpPtr = (irr::IReferenceCounted *)(VIReferenceCounted*)pointer;
#else
        tmpPtr = (irr::IReferenceCounted *)pointer;
#endif
        return tmpPtr->getReferenceCount();
    }
    else
    {
        return -123456;
    }
}

void Pointer_SafeRelease(IntPtr pointer)
{
    irr::IReferenceCounted* tmpPtr = NULL;

    if(pointer)
    {
#ifdef VIREFERENCECOUNTED
        tmpPtr = (irr::IReferenceCounted *)(VIReferenceCounted*)pointer;
#else
        tmpPtr = (irr::IReferenceCounted *)pointer;
#endif
        tmpPtr->drop();
    }
}

void Pointer_SafeRelease_AEO(IntPtr pointer)
{
    irr::IReferenceCounted* tmpPtr = NULL;

    if(pointer)
    {
        tmpPtr = (irr::IReferenceCounted *)(irr::io::IAttributeExchangingObject*)pointer;
        tmpPtr->drop();
    }
}

void Pointer_SafeRelease_TS(IntPtr pointer)
{
    irr::IReferenceCounted* tmpPtr = NULL;

    if(pointer)
    {
        tmpPtr = (irr::IReferenceCounted *)(irr::scene::ITriangleSelector*)pointer;
        tmpPtr->drop();
    }
}

#ifdef _DEBUG
static _CrtMemState memstate0,memstate1, memstateDiff;
static _CrtMemState *pCurMemState=&memstate0, *pOldMemState=&memstate1;

void Memory_SwapStates()
{
    _CrtMemState* temp = pOldMemState;
    pOldMemState = pCurMemState;
    pCurMemState = temp;
}

void Memory_Checkpoint()
{
    Memory_SwapStates();
    _CrtMemCheckpoint(pCurMemState);
}

void Memory_Stats()
{
    _CrtMemDumpStatistics(pCurMemState);
}

bool Memory_Diff()
{
    int result;
    if(result=_CrtMemDifference(&memstateDiff, pOldMemState, pCurMemState))
    {
        _CrtMemDumpStatistics(&memstateDiff);
    }
    return result?true:false;
}

#endif

#ifdef _MSC_VER
#ifndef WIN64
bool fixmarshal(bool val)
{
    __asm mov eax, 100;
    return val;
}
#else
bool fixmarshal(bool val)
{
    return val;
}
#endif
#endif

//Converts from irr::core::stringw to managed string --> getToolTipText
M_STRING IM_STRING(const IRRSTRING base)
{
    const wchar_t* b = base.c_str();
    return UM_STRING(b);
}

wchar_t *MU_WCHAR(const M_STRING base)
{
    std::string b(base);
    wchar_t *str = new wchar_t[b.length()+1];
    size_t size;
#ifdef _MSC_VER
    mbstowcs_s(&size, str, b.length() + 1, b.c_str(), b.length());
#else
    size = mbstowcs(str, b.c_str(), b.length());
#endif
    str[b.length()] = '\0';
    return str;
}


M_STRING UM_STRING(const wchar_t* base)
{
    std::wstring b(base);
    // Damn I'm so dumb !
    // We should allocate a b.length() * sizeof (wchar_t) bytes
    // because a wchar_t can be twice bigger than char,
    // so one character in wchar_t may need two bytes of char
    // Probably thats why this caused troubles on vista,
    // because M$ has finally switched to the full multibyte encoding.
#ifdef DEBUG
    std::cerr << "Size of wchar_t string " << b.length() << std::endl;
#endif
    M_STRING str = new char[(b.length()+ 2)*sizeof(wchar_t) ];
    size_t size;
#ifdef _MSC_VER // we are on windows
    // I don't know the syntax of this function
    // so I assume it works
    errno_t errValue;
    errValue = wcstombs_s(&size, str, (b.length()+1) * sizeof(wchar_t), b.c_str(),sizeof(wchar_t)*(b.length()+1));
#ifdef DEBUG
    std::cerr << "Done conversion!" << std::endl;
    std::cerr << "#converted chars: " << size << std::endl;
    std::cerr << "converted String: " << str << std::endl;
    std::cerr << "Error value: " << errValue << std::endl;
#endif
    if (errValue == 42) //returned value for char that could not be converted
        str = "Unknown wide-char!";

    //wcstombs_s(&size, str, b.length()*sizeof(wchar_t), b.c_str(), b.length()*sizeof(wchar_t));
#else // we are on linux
    size = wcstombs(str, b.c_str(), b.length()*sizeof(wchar_t));
#endif /*_MSC_VER*/
    str[size] = '\0';
#ifdef DEBUG
    std::cerr << " Added null-termination!" << std::endl;
    std::cerr << " Final string: " << str << std::endl;
#endif

    return str;
}


M_STRING UM_STRING(const M_STRING base)
{
    return const_cast<M_STRING>(base);
}
/*
M_STRING UM_STRING(const M_STRING base)
{
std::string* newstr = new std::string(base);
return const_cast<M_STRING>(newstr->c_str());
}
*/

void UM_DIM2DS(irr::core::dimension2d<int> base, M_DIM2DS t)
{
    t[0] = base.Width;
    t[1] = base.Height;
}

void UM_DIM2DU(irr::core::dimension2d<unsigned int> base, M_DIM2DU t)
{
    t[0] = base.Width;
    t[1] = base.Height;
}

void UM_DIM2US(irr::core::dimension2d<uint> base, M_DIM2US t)
{
    t[0] = base.Width;
    t[1] = base.Height;
}

void UM_DIM2DF(irr::core::dimension2d<float> base, M_DIM2DF t)
{
    t[0] = base.Width;
    t[1] = base.Height;
}

void UM_POS2DS(irr::core::position2d<int> base, M_POS2DS t)
{
    t[0] = base.X;
    t[1] = base.Y;
}

void UM_POS2DF(irr::core::position2d<float> base, M_POS2DF t)
{
    t[0] = base.X;
    t[1] = base.Y;
}

void UM_SCOLOR(irr::video::SColor color, M_SCOLOR t)
{
    t[0] = color.getAlpha();
    t[1] = color.getRed();
    t[2] = color.getGreen();
    t[3] = color.getBlue();
}

void UM_SCOLORF(irr::video::SColorf color, M_SCOLORF t)
{
    t[0] = color.a;
    t[1] = color.r;
    t[2] = color.g;
    t[3] = color.b;
}

void UM_VECT3DF(irr::core::vector3df base, M_VECT3DF t)
{
    t[0] = base.X;
    t[1] = base.Y;
    t[2] = base.Z;
}

irr::core::matrix4 MU_MAT4(M_MAT4 val)
{
    irr::core::matrix4 mat;
    for(int row = 0; row < 4; row++)
        for(int col = 0; col < 4; col++)
            mat[col * 4 + row] = val[col * 4 + row];
    return mat;
}

void UM_MAT4(irr::core::matrix4 val, M_MAT4 mat)
{
    for(int row = 0; row < 4; row++)
        for(int col = 0; col < 4; col++)
            mat[col * 4 + row] = val[col * 4 + row];
}

void UM_BOX3D(irr::core::aabbox3d<float> base, M_BOX3D t)
{
    t[0] = base.MinEdge.X;
    t[1] = base.MinEdge.Y;
    t[2] = base.MinEdge.Z;
    t[3] = base.MaxEdge.X;
    t[4] = base.MaxEdge.Y;
    t[5] = base.MaxEdge.Z;
}

void UM_RECT(irr::core::rect<int> base, M_RECT t)
{
    t[0] = base.UpperLeftCorner.X;
    t[1] = base.UpperLeftCorner.Y;
    t[2] = base.LowerRightCorner.X;
    t[3] = base.LowerRightCorner.Y;
}

irr::core::triangle3df MU_TRIANGLE3DF(float *val)
{
    irr::core::triangle3df tri;
    tri.set(irr::core::vector3df(val[0], val[1], val[2]),
        irr::core::vector3df(val[3], val[4], val[5]),
        irr::core::vector3df(val[6], val[7], val[8]));
    return tri;
}

void UM_TRIANGLE3DF(irr::core::triangle3d<float> base, M_TRIANGLE3DF t)
{
    t[0] = base.pointA.X;
    t[1] = base.pointA.Y;
    t[2] = base.pointA.Z;
    t[3] = base.pointB.X;
    t[4] = base.pointB.Y;
    t[5] = base.pointB.Z;
    t[6] = base.pointC.X;
    t[7] = base.pointC.Y;
    t[8] = base.pointC.Z;
}

void UM_LINE3D(irr::core::line3d<float> base, M_LINE3D t)
{
    t[0] = base.start.X;
    t[1] = base.start.Y;
    t[2] = base.start.Z;
    t[3] = base.end.X;
    t[4] = base.end.Y;
    t[5] = base.end.Z;
}

void UM_PLANE3DF(irr::core::plane3d<float> base, M_PLANE3DF t)
{
    t[0] = base.D;
    t[1] = base.Normal.X;
    t[2] = base.Normal.Y;
    t[3] = base.Normal.Z;
}
