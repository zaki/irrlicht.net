using System;
using System.Runtime.InteropServices;
using System.Security;

namespace IrrlichtNET
{
    public class MeshSceneNode : SceneNode
    {
        public MeshSceneNode(IntPtr raw)
            : base(raw)
        {

        }

        public void SetMesh(Mesh pMesh)
        {
            MeshSceneNode_SetMesh(_raw, pMesh.Raw);
        }

        public Mesh GetMesh()
        {
            return (Mesh)
                    NativeElement.GetObject(MeshSceneNode_GetMesh(_raw),
                                            typeof(Mesh));
        }

        public void SetReadOnlyMaterials(bool pReadOnly)
        {
            MeshSceneNode_SetReadOnlyMaterials(_raw, pReadOnly);
        }

        public bool IsReadOnlyMaterials()
        {
            return MeshSceneNode_SetReadOnlyMaterials(_raw);
        }
        public void DropAllMeshBuffers()
        {
            MeshSceneNode_DropAllMeshBuffers(_raw);
        }

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr MeshSceneNode_GetMesh(IntPtr meshscenenode);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void MeshSceneNode_SetMesh(IntPtr meshscenenode, IntPtr mesh);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void MeshSceneNode_SetReadOnlyMaterials(IntPtr meshscenenode, bool pReadOnly);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern bool MeshSceneNode_SetReadOnlyMaterials(IntPtr meshscenenode);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void MeshSceneNode_DropAllMeshBuffers(IntPtr meshscenenode);

    }
    /*
    EXPORT void MeshSceneNode_SetMesh(IntPtr meshnode, IntPtr mesh);
    EXPORT IntPtr MeshSceneNode_GetMesh(IntPtr meshnode);
    EXPORT void MeshSceneNode_SetReadOnlyMaterials(IntPtr meshnode, bool readonly);
    EXPORT bool MeshSceneNode_IsReadOnlyMaterials(IntPtr meshnode);
    */



}
