using System;
using System.Runtime.InteropServices;
using System.Security;

namespace IrrlichtNET
{
    public class MeshWriter : NativeElement
    {
        public MeshWriter(IntPtr raw)
            : base(raw)
        {
        }

        public MeshWriterType GetMeshWriterType()
        {
            return MeshWriter_GetType(_raw);
        }

        public bool WriteMesh(IntPtr file, IntPtr mesh, MeshWriterFlags flags)
        {
            return MeshWriter_WriteMesh(_raw, file, mesh, flags);
        }

        #region Native Code
        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern MeshWriterType MeshWriter_GetType(IntPtr writer);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern bool MeshWriter_WriteMesh(IntPtr writer, IntPtr file, IntPtr mesh, MeshWriterFlags flags);
        #endregion
    }


    public enum MeshWriterType
    {
        //! Irrlicht Native mesh writer, for static .irrmesh files.
        EMWT_IRR_MESH = 0x6D727269, // MAKE_IRR_ID('i', 'r', 'r', 'm') from native irrlicht

        //! COLLADA mesh writer for .dae and .xml files
        EMWT_COLLADA = 0x6C6C6F63, // MAKE_IRR_ID('c', 'o', 'l', 'l'),

        //! STL mesh writer for .stl files
        EMWT_STL = 0x006C7473, // MAKE_IRR_ID('s', 't', 'l', 0),

        //! OBJ mesh writer for .obj files
        EMWT_OBJ = 0x006A626F, // MAKE_IRR_ID('o', 'b', 'j', 0)

        //! PLY mesh writer for .ply files
        EMWT_PLY = 0x00796C70 //MAKE_IRR_ID('p', 'l', 'y', 0)

    }

    // TODO FIXME: can multiple flags be combined when using an enum like this? If not, use an int.
    public enum MeshWriterFlags
    {
        //! no writer flags
        EMWF_NONE = 0,

        //! write lightmap textures out if possible
        EMWF_WRITE_LIGHTMAPS = 0x1,

        //! write in a way that does consume less disk space
        EMWF_WRITE_COMPRESSED = 0x2,

        //! write in binary format rather than text
        EMWF_WRITE_BINARY = 0x4,

        //! mirror geometry left/right and reverse winding order to preserving front-faces
        EMWF_WRITE_MIRRORED = 0x8
    }
}
