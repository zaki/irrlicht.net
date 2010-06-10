using System;
using System.Runtime.InteropServices;
using System.Security;

namespace IrrlichtNETCP
{
    public class GUIMeshViewer : GUIElement
    {
        public GUIMeshViewer(IntPtr raw)
            : base(raw)
        {
        }

        public Material Material
        {
            get
            {
                return (Material)NativeElement.GetObject(GUIMeshViewer_GetMaterial(_raw), typeof(Material));
            }
            set
            {
                GUIMeshViewer_SetMaterial(_raw, value.Raw);
            }
        }

        public AnimatedMesh Mesh
        {
            set
            {
                GUIMeshViewer_SetMesh(_raw, value.Raw);
            }
        }

        #region Native Invokes
        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr GUIMeshViewer_GetMaterial(IntPtr meshv);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void GUIMeshViewer_SetMaterial(IntPtr meshv, IntPtr mat);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void GUIMeshViewer_SetMesh(IntPtr meshv, IntPtr animatedmesh);
        #endregion
    }
}
