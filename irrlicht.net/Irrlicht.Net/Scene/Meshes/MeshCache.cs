using System;
using System.Runtime.InteropServices;
using System.Security;

namespace IrrlichtNETCP
{


    public class MeshCache : NativeElement
    {

        public MeshCache(IntPtr raw)
            : base(raw)
        {
        }

        public void AddMesh(string filename, AnimatedMesh mesh)
        {
            MeshCache_AddMesh(_raw, filename, mesh.Raw);
        }

        public void Clear()
        {
            MeshCache_Clear(_raw);
        }

        public void ClearUnusedMeshes()
        {
            MeshCache_ClearUnusedMeshes(_raw);
        }

        public AnimatedMesh GetMeshByFilename(string filename)
        {
            return (AnimatedMesh)NativeElement.GetObject(MeshCache_GetMeshByFilename(_raw, filename),
                                                          typeof(AnimatedMesh));
        }

        public AnimatedMesh GetMeshByIndex(uint index)
        {
            return (AnimatedMesh)NativeElement.GetObject(MeshCache_GetMeshByIndex(_raw, index),
                                                          typeof(AnimatedMesh));
        }

        public uint GetMeshCount()
        {
            return MeshCache_GetMeshCount(_raw);
        }

        public string GetMeshFilename(Mesh mesh)
        {
            return MeshCache_GetMeshFilename(_raw, mesh.Raw);
        }

        public string GetMeshFilename(AnimatedMesh mesh)
        {
            return MeshCache_GetMeshFilenameA(_raw, mesh.Raw);
        }

        public string GetMeshFilename(uint index)
        {
            return MeshCache_GetMeshFilenameN(_raw, index);
        }

        public int GetMeshIndex(Mesh mesh)
        {
            return MeshCache_GetMeshIndex(_raw, mesh.Raw);
        }

        public int GetMeshIndex(AnimatedMesh mesh)
        {
            return MeshCache_GetMeshIndexA(_raw, mesh.Raw);
        }

        public bool IsMeshLoaded(string filename)
        {
            return MeshCache_IsMeshLoaded(_raw, filename);
        }

        public void RemoveMesh(Mesh mesh)
        {
            MeshCache_RemoveMesh(_raw, mesh.Raw);
        }

        public void RemoveMesh(AnimatedMesh mesh)
        {
            MeshCache_RemoveMeshA(_raw, mesh.Raw);
        }

        public bool SetMeshFilename(Mesh mesh, string filename)
        {
            return MeshCache_SetMeshFilename(_raw, mesh.Raw, filename);
        }

        public bool SetMeshFilename(AnimatedMesh mesh, string filename)
        {
            return MeshCache_SetMeshFilenameA(_raw, mesh.Raw, filename);
        }

        public bool SetMeshFilename(uint index, string filename)
        {
            return MeshCache_SetMeshFilenameN(_raw, index, filename);
        }

        #region native imports
        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void MeshCache_AddMesh(IntPtr mc, string filename, IntPtr mesh);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void MeshCache_Clear(IntPtr mc);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void MeshCache_ClearUnusedMeshes(IntPtr mc);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr MeshCache_GetMeshByFilename(IntPtr mc, string filename);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr MeshCache_GetMeshByIndex(IntPtr mc, uint index);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern uint MeshCache_GetMeshCount(IntPtr mc);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern string MeshCache_GetMeshFilename(IntPtr mc, IntPtr mesh);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern string MeshCache_GetMeshFilenameA(IntPtr mc, IntPtr mesh);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern string MeshCache_GetMeshFilenameN(IntPtr mc, uint index);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern int MeshCache_GetMeshIndex(IntPtr mc, IntPtr mesh);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern int MeshCache_GetMeshIndexA(IntPtr mc, IntPtr mesh);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern bool MeshCache_IsMeshLoaded(IntPtr mc, string filename);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void MeshCache_RemoveMesh(IntPtr mc, IntPtr mesh);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void MeshCache_RemoveMeshA(IntPtr mc, IntPtr mesh);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern bool MeshCache_SetMeshFilename(IntPtr mc, IntPtr mesh, string filename);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern bool MeshCache_SetMeshFilenameA(IntPtr mc, IntPtr mesh, string filename);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern bool MeshCache_SetMeshFilenameN(IntPtr mc, uint index, string filename);
        #endregion

    }
}
