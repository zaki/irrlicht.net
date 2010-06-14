using System;
using System.Runtime.InteropServices;
using System.Security;

namespace IrrlichtNET
{
    public class GUIComboBox : GUIElement
    {
        public GUIComboBox(IntPtr raw)
            : base(raw)
        {
        }

        public int AddItem(string text)
        {
            return GUIComboBox_AddItem(_raw, text);
        }

        public void Clear()
        {
            GUIComboBox_Clear(_raw);
        }

        public string GetItem(int index)
        {
            try
            {
                return GUIComboBox_GetItem(_raw, index);
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
                return GUIComboBox_GetItemCount(_raw);
            }
        }

        public int Selected
        {
            get
            {
                return GUIComboBox_GetSelected(_raw);
            }
            set
            {
                GUIComboBox_SetSelected(_raw, value);
            }
        }

        #region Native Invokes
        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern int GUIComboBox_AddItem(IntPtr combo, string text);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void GUIComboBox_Clear(IntPtr combo);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern string GUIComboBox_GetItem(IntPtr combo, int index);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern int GUIComboBox_GetItemCount(IntPtr combo);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern int GUIComboBox_GetSelected(IntPtr combo);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void GUIComboBox_SetSelected(IntPtr combo, int index);
        #endregion
    }
}
