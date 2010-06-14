using System;
using System.Runtime.InteropServices;
using System.Security;

namespace IrrlichtNET
{
    public partial class GUIListBox : GUIElement
    {
        public GUIListBox(IntPtr raw)
            : base(raw)
        {
        }

        public int AddItem(string text, int icon)
        {
            return GUIListBox_AddItem(_raw, text, icon);
        }

        public int AddItem(string text)
        {
            return GUIListBox_AddItemA(_raw, text);
        }

        public void Clear()
        {
            GUIListBox_Clear(_raw);
        }

        public string GetListItem(int id)
        {
            try
            {
                return GUIListBox_GetListItem(_raw, id);
            }
            catch (Exception)
            {
                return "";
            }
        }

        public int ItemCount
        {
            get
            {
                return GUIListBox_GetItemCount(_raw);
            }
        }

        public int Selected
        {
            get
            {
                return GUIListBox_GetSelected(_raw);
            }
            set
            {
                GUIListBox_SetSelected(_raw, value);
            }
        }

        #region Native Invokes
        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern int GUIListBox_AddItem(IntPtr listb, string text, int icon);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern int GUIListBox_AddItemA(IntPtr listb, string text);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void GUIListBox_Clear(IntPtr listb);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern int GUIListBox_GetItemCount(IntPtr listb);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern string GUIListBox_GetListItem(IntPtr listb, int id);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern int GUIListBox_GetSelected(IntPtr listb);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void GUIListBox_SetSelected(IntPtr listb, int sel);
        #endregion
    }
}
