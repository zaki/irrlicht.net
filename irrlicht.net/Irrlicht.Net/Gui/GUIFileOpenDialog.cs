using System;
using System.Runtime.InteropServices;
using System.Security;

namespace IrrlichtNETCP
{
    public class GUIFileOpenDialog : GUIElement
    {
        public GUIFileOpenDialog(IntPtr raw)
            : base(raw)
        {
        }

        public string Filename
        {
            get
            {
                try
                {
                    return GUIFileOpenDialog_GetFilename(_raw);
                }
                catch (Exception)
                {
                    return "";
                }
            }
        }

        #region Native Invokes
        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern string GUIFileOpenDialog_GetFilename(IntPtr dialog);
        #endregion
    }
}
