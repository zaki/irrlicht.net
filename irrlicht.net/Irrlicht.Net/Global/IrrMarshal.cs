// IrrMarshall.cs
//
//  Copyright (C) 2008 [name of author]
//
// This program is free software; you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation; either version 2 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program; if not, write to the Free Software
// Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA 02111-1307 USA
//
//

using System;
using System.Runtime.InteropServices;
using System.Security;

namespace IrrlichtNET
{

    public class IrrStringMarshal
    {
        public static string IntPtrToString(IntPtr pointer)
        {
            string value;

            try
            {
                value = Marshal.PtrToStringAnsi(pointer);
            }
            catch (Exception)
            {
#if _DEBUG
                System.Diagnostics.Debug.WriteLine("Retrieval from wrapper failed");
                System.Diagnostics.Debug.WriteLine("Exception: " + e.Message);
#endif
                return "Error!";
            }
            try
            {
                //New method used to free memory allocated in C++ wrapper
                freeUMMemory(pointer, true);
            }
            catch (Exception)
            {
#if _DEBUG
                System.Diagnostics.Debug.WriteLine("Freeing of unmanaged memory failed!");
                System.Diagnostics.Debug.WriteLine("Memory leak caused!");
                System.Diagnostics.Debug.WriteLine("Exception: " + e.Message);
#endif
            }
            return value;
        }

        #region Native Invokes
        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void freeUMMemory(IntPtr pointer, bool arrayType);
        #endregion
    }
}
