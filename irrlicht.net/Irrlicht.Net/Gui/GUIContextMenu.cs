using System;
using System.Runtime.InteropServices;
using System.Security;

namespace IrrlichtNET
{
    public class GUIContextMenu : GUIElement
    {
        public GUIContextMenu(IntPtr raw)
            : base(raw)
        {
        }

        public int AddItem(string text, int command, bool enabled, bool hasSubMenu)
        {
            return GUIContextMenu_AddItem(_raw, text, command, enabled, hasSubMenu);
        }

        public void AddSeparator()
        {
            GUIContextMenu_AddSeparator(_raw);
        }

        public int GetItemCommandID(int id)
        {
            return GUIContextMenu_GetItemCommandID(_raw, id);
        }

        public string GetItemText(int id)
        {
            try
            {
                return GUIContextMenu_GetItemText(_raw, id);
            }
            catch (Exception)
            {
                return "";
            }
        }

        public GUIContextMenu GetSubMenu(int id)
        {
            return (GUIContextMenu)NativeElement.GetObject(GUIContextMenu_GetSubMenu(_raw, id),
                                                           typeof(GUIContextMenu));
        }

        public bool IsItemEnabled(int id)
        {
            return GUIContextMenu_IsItemEnabled(_raw, id);
        }

        public void RemoveAllItems()
        {
            GUIContextMenu_RemoveAllItems(_raw);
        }

        public void RemoveItem(int item)
        {
            GUIContextMenu_RemoveItem(_raw, item);
        }

        public void SetItemCommandID(int index, int id)
        {
            GUIContextMenu_SetItemCommandID(_raw, index, id);
        }

        public void SetItemEnabled(int index, bool enabled)
        {
            GUIContextMenu_SetItemEnabled(_raw, index, enabled);
        }

        public void SetItemText(int index, string text)
        {
            GUIContextMenu_SetItemText(_raw, index, text);
        }

        public int ItemCount
        {
            get
            {
                return GUIContextMenu_GetItemCount(_raw);
            }
        }

        public int SelectedItem
        {
            get
            {
                return GUIContextMenu_GetSelectedItem(_raw);
            }
        }

        #region Native Invokes
        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern int GUIContextMenu_AddItem(IntPtr menu, string text, int commandID, bool enabled, bool hasSubMenu);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void GUIContextMenu_AddSeparator(IntPtr menu);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern int GUIContextMenu_GetItemCommandID(IntPtr menu, int id);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern int GUIContextMenu_GetItemCount(IntPtr menu);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern string GUIContextMenu_GetItemText(IntPtr menu, int index);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern int GUIContextMenu_GetSelectedItem(IntPtr menu);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr GUIContextMenu_GetSubMenu(IntPtr menu, int index);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern bool GUIContextMenu_IsItemEnabled(IntPtr menu, int id);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void GUIContextMenu_RemoveAllItems(IntPtr menu);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void GUIContextMenu_RemoveItem(IntPtr menu, int item);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void GUIContextMenu_SetItemCommandID(IntPtr menu, int index, int id);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void GUIContextMenu_SetItemEnabled(IntPtr menu, int index, bool enabled);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void GUIContextMenu_SetItemText(IntPtr menu, int index, string text);
        #endregion
    }
}
