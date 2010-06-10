#include "main.h"

extern "C"
{
    EXPORT EMESH_WRITER_TYPE MeshWriter_GetType(IntPtr writer);
    EXPORT bool MeshWriter_WriteMesh(IntPtr writer, IntPtr file, IntPtr mesh, E_MESH_WRITER_FLAGS flags);
}
