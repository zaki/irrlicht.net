using System;
using System.Runtime.InteropServices;
using System.Security;

namespace IrrlichtNET
{
    public class GUICheckBox : GUIElement
    {
        public GUICheckBox(IntPtr raw)
            : base(raw)
        {
        }

        public bool Checked
        {
            get
            {
                return GUICheckBox_IsChecked(_raw);
            }
            set
            {
                GUICheckBox_SetChecked(_raw, value);
            }
        }

        #region Native Invokes
        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern bool GUICheckBox_IsChecked(IntPtr checkbox);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void GUICheckBox_SetChecked(IntPtr checkbox, bool ck);
        #endregion
    }

}
