#if COMPILE_WITH_FREETYPE || !WIN32

#ifndef __C_GUI_TTFONT_H_INCLUDED__
#define __C_GUI_TTFONT_H_INCLUDED__

//If on Windows you have to have vendor directory being checked-out from the
//svn repository for compiling with freetype, the include-path is set correctly
//by the project settings,
//Or remove from the preprocessor's configuration COMPILE_WITH_FREETYPE
#include "ft2build.h"
#include <freetype/freetype.h>
// >> Add by uirou for multibyte language start
#ifdef USE_ICONV
#include <langinfo.h>
#include <iconv.h>
#endif
// << Add by uirou for multibyte language end

namespace irr
{
    namespace gui
    {
#ifdef VIREFERENCECOUNTED
        class CGUITTFace : public virtual IReferenceCounted
#else
        class CGUITTFace : public IReferenceCounted
#endif
        {
        public:
            CGUITTFace();
            virtual ~CGUITTFace();
            bool loaded;
            FT_Library    library;
            FT_Face        face;
            // >> Add by uirou for multibyte language start
#ifdef USE_ICONV
            iconv_t cd;
#endif
            // << Add by uirou for multibyte language end
            bool load(const c8* filename);
#ifdef VIREFERENCECOUNTED
            virtual void dummy() {return;}
#endif
        };

        class CGUITTGlyph : public /* virtual */ IReferenceCounted // intentionally not virtual because these objects are not C++ constructed but are byte-wise memory-initialized
        {
        public:
            bool cached;
            video::IVideoDriver* Driver;
            CGUITTGlyph();
            virtual ~CGUITTGlyph();
            // >> Add solehome's code for memory access error begin
            void init();
            // << Add solehome's code for memory access error end
            void cache(u32 idx);
#ifdef VIREFERENCECOUNTED
            virtual void dummy() {return;}
#endif
            FT_Face *face;
            u32 size;
            u32 top;
            u32 left;
            u32 texw;
            u32 texh;
            u32 imgw;
            u32 imgh;
            video::ITexture *tex;
            u32 top16;
            u32 left16;
            u32 texw16;
            u32 texh16;
            u32 imgw16;
            u32 imgh16;
            video::ITexture *tex16;
            s32 offset;
            u8 *image;
        };
        class CGUITTFont : public IGUIFont
        {
        public:
            u32 size;

            //! constructor
            CGUITTFont(video::IVideoDriver* Driver);

            //! destructor
            virtual ~CGUITTFont();

            //! loads a truetype font file
            bool attach(CGUITTFace *Face,u32 size);

            //! draws an text and clips it to the specified rectangle if wanted
            virtual void draw(const core::stringw& text, const core::rect<s32>& position, video::SColor color, bool hcenter=false, bool vcenter=false, const core::rect<s32>* clip=0);

            //! returns the dimension of a text
            virtual core::dimension2d<u32> getDimension(const wchar_t* text) const;

            //! Calculates the index of the character in the text which is on a specific position.
            virtual s32 getCharacterFromPos(const wchar_t* text, s32 pixel_x) const;

            // >> Add for Ver.1.3 begin
            //! set an Pixel Offset on Drawing ( scale position on width )
            virtual void setKerningWidth (s32 kerning);
            virtual void setKerningHeight (s32 kerning);

            //! set an Pixel Offset on Drawing ( scale position on width )
            virtual s32 getKerningWidth(const wchar_t* thisLetter=0, const wchar_t* previousLetter=0) const;
            virtual s32 getKerningHeight() const;
            // << Add for Ver.1.3 end

            scene::ISceneNode *createBillboard(const wchar_t* text, core::dimension2d<f32> size, scene::ISceneManager *scene,scene::ISceneNode *parent,s32 id);

            virtual void setInvisibleCharacters(const wchar_t *);

            bool AntiAlias;
            bool TransParency;
            bool attached;
        private:
            s32 getWidthFromCharacter(wchar_t c) const;
            u32 getGlyphByChar(wchar_t c);
            video::IVideoDriver* Driver;
            core::array< CGUITTGlyph > Glyphs;
            CGUITTFace *tt_face;
            // >> Add for Ver.1.3 begin
            s32 GlobalKerningWidth, GlobalKerningHeight;
            // << Add for Ver.1.3 end

            core::stringw Invisible;
        };

    } // end namespace gui
} // end namespace irr

#endif


#endif
