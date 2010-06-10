using System;
using System.Runtime.InteropServices;
using System.Security;

namespace IrrlichtNETCP
{
    public partial class GUITabControl : GUIElement
    {
        public GUITabControl(IntPtr raw)
            : base(raw)
        {
        }

        public GUITab AddTab(string caption, int id)
        {
            return (GUITab)NativeElement.GetObject(GUITabControl_AddTab(_raw, caption, id),
                                                   typeof(GUITab));
        }

        public GUITab GetTab(int id)
        {
            return (GUITab)NativeElement.GetObject(GUITabControl_GetTab(_raw, id),
                                                   typeof(GUITab));
        }

        public int ActiveTab
        {
            get
            {
                return GUITabControl_GetActiveTab(_raw);
            }
            set
            {
                GUITabControl_SetActiveTab(_raw, value);
            }
        }

        public int TabCount
        {
            get
            {
                return GUITabControl_GetTabCount(_raw);
            }
        }

        #region Native Invokes
        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr GUITabControl_AddTab(IntPtr tabc, string caption, int id);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern int GUITabControl_GetActiveTab(IntPtr tabc);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr GUITabControl_GetTab(IntPtr tabc, int index);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern int GUITabControl_GetTabCount(IntPtr tabc);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern bool GUITabControl_SetActiveTab(IntPtr tabc, int index);
        #endregion
    }
}
