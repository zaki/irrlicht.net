using System;
using System.Runtime.InteropServices;
using System.Security;

namespace IrrlichtNETCP
{
    public class Image : NativeElement
    {
        public Image(IntPtr raw)
            : base(raw)
        {
        }
    }
}
