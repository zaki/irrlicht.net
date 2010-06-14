using System;
using System.Runtime.InteropServices;
using System.Security;

namespace IrrlichtNET
{
    public class Image : NativeElement
    {
        public Image(IntPtr raw)
            : base(raw)
        {
        }
    }
}
