#if COMPILE_WITH_FREETYPE || !WIN32
//
// C++ Implementation: customfont
//
// Description: funcitons to support truetype fonts
//    based on IrrlichtML. Look at the irrlicht forums
//    for details. You need properly patched libIrrlicht.a
//
//
// Author: lester <lester.dev@gmail.com>, (C) 2007
//
// Copyright: See COPYING file that comes with this distribution
//
//

#include "customfont.h"

CGUITTFace * getFace(IntPtr obj)
{
    return (CGUITTFace *)obj;
}

CGUITTFont * getFont(IntPtr obj)
{
    return (CGUITTFont *)obj;
}

IntPtr TTFont_Create(IntPtr driver)
{
    return new CGUITTFont((IVideoDriver *)driver);
}

int TTFont_Attach(IntPtr font, IntPtr face, u32 size)
{
    return getFont(font)->attach(getFace(face), size);
}

void TTFont_SetTransparency(IntPtr font, bool trans)
{
    getFont(font)->TransParency = trans;
}

void TTFont_SetAntialias(IntPtr font, bool alias)
{
    getFont(font)->AntiAlias = alias;
}

IntPtr TTFace_Create()
{
    return new CGUITTFace();
}

void TTFace_Load(IntPtr face, M_STRING fontname)
{
    getFace(face)->load(UM_STRING(fontname));
}

#endif
