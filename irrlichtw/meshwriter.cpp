#include "meshwriter.h"

IMeshWriter *GetWriterFromIntPtr(IntPtr writer)
{
    return (IMeshWriter*)writer;
}

EMESH_WRITER_TYPE MeshWriter_GetType(IntPtr writer)
{
    return GetWriterFromIntPtr(writer)->getType();
}

bool MeshWriter_WriteMesh(IntPtr writer, IntPtr file, IntPtr mesh, E_MESH_WRITER_FLAGS flags)
{
    return GetWriterFromIntPtr(writer)->writeMesh((IWriteFile*)file, (IMesh*)mesh, flags);
}
