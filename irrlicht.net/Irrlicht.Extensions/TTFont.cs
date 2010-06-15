// @author lester

using System;
using System.Runtime.InteropServices;
using IrrlichtNET;

namespace IrrlichtNET.Extensions
{

    public class TTFace : GUIFont
    {
        public TTFace()
            : base(TTFace_Create())
        {
        }

        public TTFace(IntPtr raw)
            : base(raw)
        {
        }

        public void Load(string name)
        {
            TTFace_Load(_raw, name);
        }

        [DllImport(Native.Dll)]
        static extern void TTFace_Load(IntPtr face, string name);
        [DllImport(Native.Dll)]
        static extern IntPtr TTFace_Create();
    }

    public class TTFont : GUIFont
    {

        public TTFont(IntPtr raw)
            : base(raw)
        {
        }

        public TTFont(VideoDriver driver)
            : base(driver.Raw)
        {
            Initialize(TTFont_Create(driver.Raw));
        }

        public int Attach(TTFace face, uint size)
        {
            return (int)TTFont_Attach(_raw, face.Raw, size);
        }

        public bool Antialias
        {
            get
            {
                return antialias;
            }
            set
            {
                antialias = value;
                TTFont_SetAntialias(_raw, value);
            }
        }

        public bool Transparent
        {
            get
            {
                return transparent;
            }
            set
            {
                transparent = value;
                TTFont_SetTransparency(_raw, value);
            }
        }


        [DllImport(Native.Dll)]
        static extern IntPtr TTFont_Create(IntPtr driver);
        [DllImport(Native.Dll)]
        static extern int TTFont_Attach(IntPtr font, IntPtr face, uint size);
        [DllImport(Native.Dll)]
        static extern void TTFont_SetAntialias(IntPtr font, bool alias);
        [DllImport(Native.Dll)]
        static extern void TTFont_SetTransparency(IntPtr font, bool trans);

        private bool antialias = false;
        private bool transparent = false;

    }

}
