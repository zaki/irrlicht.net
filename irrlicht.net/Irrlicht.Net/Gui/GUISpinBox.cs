
using System;
using System.Runtime.InteropServices;
using System.Security;

namespace IrrlichtNET
{


    public class GUISpinBox : GUIElement
    {

        public GUISpinBox(IntPtr raw)
            : base(raw)
        {
        }

        public float Max
        {
            get { return GUISpinBox_GetMax(_raw); }
        }

        public float Min
        {
            get { return GUISpinBox_GetMin(_raw); }
        }

        public void SetRange(int min, int max)
        {
            GUISpinBox_SetRange(_raw, min, max);
        }

        /// <value>
        /// Step size by which values are changed when pressing the spinbuttons.
        /// </value>
        public float StepSize
        {
            get { return GUISpinBox_GetStepSize(_raw); }
            set { GUISpinBox_SetStepSize(_raw, value); }
        }

        public float Value
        {
            get { return GUISpinBox_GetValue(_raw); }
            set { GUISpinBox_SetValue(_raw, value); }
        }

        /// <value>
        /// Sets the number of decimal places to display.
        /// </value>
        public int DecimalPlaces
        {
            set { GUISpinBox_SetDecimalPlaces(_raw, value); }
        }

        public GUIEditBox EditBox
        {
            get
            {
                return (GUIEditBox)NativeElement.GetObject(
                                        GUISpinBox_GetEditBox(_raw),
                                        typeof(GUIEditBox));
            }
        }


        #region Native
        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern float GUISpinBox_GetMax(IntPtr spin);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern float GUISpinBox_GetMin(IntPtr spin);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern float GUISpinBox_GetStepSize(IntPtr spin);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern float GUISpinBox_GetValue(IntPtr spin);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void GUISpinBox_SetValue(IntPtr spin, float val);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr GUISpinBox_GetEditBox(IntPtr spin);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void GUISpinBox_SetRange(IntPtr spin, int min, int max);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void GUISpinBox_SetStepSize(IntPtr spin, float step);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void GUISpinBox_SetDecimalPlaces(IntPtr spin, int places);

        #endregion

    }
}
