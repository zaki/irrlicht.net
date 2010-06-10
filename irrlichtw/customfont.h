#if COMPILE_WITH_FREETYPE || !WIN32
//
// C++ Interface: customfont
//
// Description: header
//
//
// Author: lester <lester.dev@gmail.com>, (C) 2007
//
// Copyright: See COPYING file that comes with this distribution
//
//
#ifndef GUICUSTOMFONT_H
#define GUICUSTOMFONT_H

#include "main.h"
#include "CGUITTFont.h"

/**
@author lester <lester.dev@gmail.com>
*/
extern "C"
{
    EXPORT IntPtr TTFont_Create(IntPtr driver);
    EXPORT int TTFont_Attach(IntPtr font, IntPtr face, u32 size);
    EXPORT void TTFont_SetTransparency(IntPtr font, bool trans);
    EXPORT void TTFont_SetAntialias(IntPtr font, bool alias);

    EXPORT IntPtr TTFace_Create();
    EXPORT void TTFace_Load(IntPtr face, M_STRING fontname);
}


#endif
#endif
