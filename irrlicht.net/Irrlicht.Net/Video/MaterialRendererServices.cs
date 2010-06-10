using System;
using System.Text;
using System.Runtime.InteropServices;
using System.Security;

namespace IrrlichtNETCP
{
    public class MaterialRendererServices : NativeElement
    {
        public MaterialRendererServices(IntPtr raw)
            : base(raw)
        {
        }

        public void SetBasicRenderStates(Material material, Material lastmaterial, bool resetAllRenderstates)
        {
            MaterialRendererServices_SetBasicRenderStates(_raw, material.Raw, lastmaterial.Raw, resetAllRenderstates);
        }

        public void SetPixelShaderConstant(float[] data, int startRegister, int constantAmount)
        {
            MaterialRendererServices_SetPixelShaderConstant(_raw, data, startRegister, constantAmount);
        }

        public void SetPixelShaderConstant(string name, float[] floats, int count)
        {
            MaterialRendererServices_SetPixelShaderConstantA(_raw, name, floats, count);
        }

        public void SetVertexShaderConstant(float[] data, int startRegister, int constantAmount)
        {
            MaterialRendererServices_SetVertexShaderConstant(_raw, data, startRegister, constantAmount);
        }

        public void SetVertexShaderConstant(string name, float[] floats, int count)
        {
            MaterialRendererServices_SetVertexShaderConstantA(_raw, name, floats, count);
        }

        public void SetPixelShaderConstant(float[] data, int startRegister)
        {
            MaterialRendererServices_SetPixelShaderConstant(_raw, data, startRegister, data.Length);
        }

        public void SetPixelShaderConstant(string name, float[] floats)
        {
            SetPixelShaderConstant(name, floats, floats.Length);
        }

        public void SetPixelShaderConstant(string name, float fl)
        {
            SetPixelShaderConstant(name, new float[] { fl });
        }

        public void SetVertexShaderConstant(float[] data, int startRegister)
        {
            MaterialRendererServices_SetVertexShaderConstant(_raw, data, startRegister, data.Length);
        }

        public void SetVertexShaderConstant(string name, float[] floats)
        {
            SetVertexShaderConstant(name, floats, floats.Length);
        }

        public void SetVertexShaderConstant(string name, float fl)
        {
            SetVertexShaderConstant(name, new float[] { fl });
        }

        public VideoDriver VideoDriver
        {
            get
            {
                return (VideoDriver)
                    NativeElement.GetObject(MaterialRendererServices_GetVideoDriver(_raw), typeof(VideoDriver));
            }
        }

        #region Native Invokes
        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr MaterialRendererServices_GetVideoDriver(IntPtr mrs);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void MaterialRendererServices_SetBasicRenderStates(IntPtr mrs, IntPtr material, IntPtr lastmaterial, bool resetAllRenderStates);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void MaterialRendererServices_SetPixelShaderConstant(IntPtr mrs, float[] data, int startRegister, int constantAmount);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void MaterialRendererServices_SetPixelShaderConstantA(IntPtr mrs, string name, float[] floats, int count);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void MaterialRendererServices_SetVertexShaderConstant(IntPtr mrs, float[] data, int startRegister, int constantAmount);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void MaterialRendererServices_SetVertexShaderConstantA(IntPtr mrs, string name, float[] floats, int count);
        #endregion
    }
}
