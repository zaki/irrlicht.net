using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Text;
using System.IO;
using System.Security;

namespace IrrlichtNETCP
{
    /// <summary>
    /// Delegate called each time the engine wants to define a shader constant.
    /// </summary>
    /// <param name="services">Used to define constant and work with shader.</param>
    /// <param name="userData">Userdata int which can be specified when creating the shader.</param>
    public delegate void OnShaderConstantSetDelegate(MaterialRendererServices services, int userData);

    public class GPUProgrammingServices : NativeElement
    {
        /// <summary>
        /// You must NOT use this delegate since it is a native delegate. Use OnShaderConstantSetDelegate instead !
        /// </summary>
        /// <param name="services">(DON'T USE) Memory address of services</param>
        /// <param name="userData">(DON'T USE) User Data</param>
        public delegate void OnNativeSCSD(IntPtr services, int userData);

        public GPUProgrammingServices(IntPtr raw)
            : base(raw)
        {
        }

        /// <summary>
        /// Adds a new material renderer to the VideoDriver, based on a high level shading language. Currently only HLSL/D3D9 and GLSL/OpenGL is supported.
        /// </summary>
        /// <param name="vsprogram">String containing the source of the vertex shader program. This can be "" if no vertex program should be used. </param>
        /// <param name="ventrypoint">Name of the function of the vertexShaderProgram </param>
        /// <param name="vsCompileTarget">Vertex shader version where the high level shader should be compiled to. </param>
        /// <param name="psprogram">String containing the source of the pixel shader program. This can be "" if no pixel shader should be used.</param>
        /// <param name="psEntryPoint">Entry name of the function of the pixelShaderEntryPointName </param>
        /// <param name="psCompileTarget">Pixel shader version where the high level shader should be compiled to. </param>
        /// <param name="callback">Delegate in which you can set the needed vertex and pixel shader program constants.</param>
        /// <param name="baseMat">Base material which renderstates will be used to shade the material. </param>
        /// <param name="userData">An user data int. This int can be set to any value and will be set as parameter in the callback method when calling OnSetConstants(). In this way it is easily possible to use the same delegate method for multiple materials and distinguish between them during the call.</param>
        /// <returns>The Material to use with SetMaterial (with a C-style explicit cast). -1 if failed</returns>
        public int AddHighLevelShaderMaterial(string vsprogram, string ventrypoint, VertexShaderType vsCompileTarget, string psprogram, string psEntryPoint, PixelShaderType psCompileTarget, OnShaderConstantSetDelegate callback, MaterialType baseMat, int userData)
        {
            //WORKAROUND : Bug found by DeusXL, little workaround I don't like at all but needed !
            string vsfilename = System.IO.Path.GetTempFileName();
            StreamWriter vssw = new StreamWriter(vsfilename, false);
            string psfilename = System.IO.Path.GetTempFileName();
            StreamWriter pssw = new StreamWriter(psfilename, false);
            vssw.WriteLine(vsprogram);
            pssw.WriteLine(psprogram);
            vssw.Close();
            pssw.Close();
            int ret = AddHighLevelShaderMaterialFromFiles(vsfilename, ventrypoint, vsCompileTarget, psfilename, psEntryPoint, psCompileTarget, callback, baseMat, userData);
            try { File.Delete(vsfilename); File.Delete(psfilename); }
            catch (Exception) { }
            return ret;
        }

        /// <summary>
        /// Adds a new material renderer to the VideoDriver, based on a high level shading language. Currently only HLSL/D3D9 and GLSL/OpenGL is supported.
        /// </summary>
        /// <param name="program">String containing the path to the vertex shader program. This can be "" (empty string) if no vertex program should be used. </param>
        /// <param name="ventrypoint">Name of the function of the vertexShaderProgram </param>
        /// <param name="vsCompileTarget">Vertex shader version where the high level shader should be compiled to. </param>
        /// <param name="pixelShaderProgram">String containing the path to the pixel shader program. This can be "" (empty string) if no pixel shader should be used.</param>
        /// <param name="psEntryPoint">Entry name of the function of the pixelShaderEntryPointName </param>
        /// <param name="psCompileTarget">Pixel shader version where the high level shader should be compiled to. </param>
        /// <param name="callback">Delegate in which you can set the needed vertex and pixel shader program constants.</param>
        /// <param name="baseMat">Base material which renderstates will be used to shade the material. </param>
        /// <param name="userData">An user data int. This int can be set to any value and will be set as parameter in the callback method when calling OnSetConstants(). In this way it is easily possible to use the same delegate method for multiple materials and distinguish between them during the call.</param>
        /// <returns>The Material to use with SetMaterial (with a C-style explicit cast). -1 if failed</returns>
        public int AddHighLevelShaderMaterialFromFiles(string program, string ventrypoint, VertexShaderType vsCompileTarget, string pixelShaderProgram, string psEntryPoint, PixelShaderType psCompileTarget, OnShaderConstantSetDelegate callback, MaterialType baseMat, int userData)
        {
            return GPU_AddHighLevelShaderMaterialFromFiles(_raw, program, ventrypoint, vsCompileTarget, pixelShaderProgram, psEntryPoint, psCompileTarget, new ShaderConstantCallback(callback).OnNativeShaderConstant, baseMat, userData);
        }

        /// <summary>
        /// Adds a new material renderer to the VideoDriver, using pixel and/or vertex shaders to render geometry. Note that it is a good idea to call VideoDriver.QueryFeature() before to check if the VideoDriver supports the vertex and/or pixel shader version your are using.
        /// </summary>
        /// <param name="vsprogram">String containing the source of the vertex shader program. This can be "" (empty string) if no vertex program should be used. For DX8 programs, the will always input registers look like this: v0: position, v1: normal, v2: color, v3: texture cooridnates, v4: texture coordinates 2 if available. For DX9 programs, you can manually set the registers using the dcl_ statements.</param>
        /// <param name="psprogram">String containing the source of the pixel shader program. This can be "" (empty string) if you don't want to use a pixel shader. </param>
        /// <param name="callback">Delegate in which you can set the needed vertex and pixel shader program constants.</param>
        /// <param name="baseMat">Base material which renderstates will be used to shade the material. </param>
        /// <param name="userData">An user data int. This int can be set to any value and will be set as parameter in the callback method when calling OnSetConstants(). In this way it is easily possible to use the same callback method for multiple materials and distinguish between them during the call. </param>
        /// <returns>The Material to use with SetMaterial (with a C-style explicit cast). -1 if failed</returns>
        public int AddShaderMaterial(string vsprogram, string psprogram, OnShaderConstantSetDelegate callback, MaterialType baseMat, int userData)
        {
            return GPU_AddShaderMaterial(_raw, vsprogram, psprogram, new ShaderConstantCallback(callback).OnNativeShaderConstant, baseMat, userData);
        }

        /// <summary>
        /// Adds a new material renderer to the VideoDriver, using pixel and/or vertex shaders to render geometry. Note that it is a good idea to call VideoDriver.QueryFeature() before to check if the VideoDriver supports the vertex and/or pixel shader version your are using.
        /// </summary>
        /// <param name="vsprogram">String containing the path to the vertex shader program. This can be "" (empty string) if no vertex program should be used. For DX8 programs, the will always input registers look like this: v0: position, v1: normal, v2: color, v3: texture cooridnates, v4: texture coordinates 2 if available. For DX9 programs, you can manually set the registers using the dcl_ statements.</param>
        /// <param name="psprogram">String containing the path to the pixel shader program. This can be "" (empty string) if you don't want to use a pixel shader. </param>
        /// <param name="callback">Delegate in which you can set the needed vertex and pixel shader program constants.</param>
        /// <param name="baseMat">Base material which renderstates will be used to shade the material. </param>
        /// <param name="userData">An user data int. This int can be set to any value and will be set as parameter in the callback method when calling OnSetConstants(). In this way it is easily possible to use the same callback method for multiple materials and distinguish between them during the call. </param>
        /// <returns>The Material to use with SetMaterial (with a C-style explicit cast). -1 if failed</returns>
        public int AddShaderMaterialFromFiles(string vsprogram, string psprogram, OnShaderConstantSetDelegate callback, MaterialType baseMat, int userData)
        {
            return GPU_AddShaderMaterialFromFiles(_raw, vsprogram, psprogram, new ShaderConstantCallback(callback).OnNativeShaderConstant, baseMat, userData);
        }

        #region Native Invokes
        //For now it is disabled and replaced by a workaround (see above)
        // [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        //static extern int GPU_AddHighLevelShaderMaterial(IntPtr gpu, string program, string ventrypoint, VertexShaderType vsCompileTarget, string pixelShaderProgram, string psEntryPoint, PixelShaderType psCompileTarget, OnNativeSCSD callback, MaterialType baseMat, int userData);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern int GPU_AddHighLevelShaderMaterialFromFiles(IntPtr gpu, string file, string ventrypoint, VertexShaderType vsCompileTarget, string psfile, string psEntryPoint, PixelShaderType psCompileTarget, OnNativeSCSD callback, MaterialType baseMat, int userData);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern int GPU_AddShaderMaterial(IntPtr gpu, string vsprogram, string psprogram, OnNativeSCSD callback, MaterialType baseMat, int userData);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern int GPU_AddShaderMaterialFromFiles(IntPtr gpu, string vsprogram, string psprogram, OnNativeSCSD callback, MaterialType baseMat, int userData);
        #endregion
    }

    class ShaderConstantCallback
    {
        /// <summary>
        /// This list is used to keep the callback from the terrible Garbage Collector's recycle bin.
        /// Indeed, it has often the bad idea to delete the poor callbacks because they are so-called useless
        /// whereas our brave callbacks remains on the C++ Code. This causes a terrible exception on the engine
        /// and no one on earth wants Irrlicht to crash, that's why we have a basic ArrayList which will just
        /// contain every callback (task that should not be
        /// </summary>
        static ArrayList scclist = new ArrayList();

        public ShaderConstantCallback(OnShaderConstantSetDelegate del)
        {
            scclist.Add(this);
            _deleg = del;
            OnNativeShaderConstant = Callback;
        }
        public GPUProgrammingServices.OnNativeSCSD OnNativeShaderConstant;

        protected void Callback(IntPtr services, int userData)
        {
            if (_deleg != null)
            {
                MaterialRendererServices serv = (MaterialRendererServices)
                    NativeElement.GetObject(services, typeof(MaterialRendererServices));
                _deleg(serv, userData);
            }
        }

        OnShaderConstantSetDelegate _deleg = null;
    }

    public enum PixelShaderType
    {
        _1_1,
        _1_2,
        _1_3,
        _1_4,
        _2_0,
        _2_a,
        _2_b,
        _3_0
    }

    public enum VertexShaderType
    {
        _1_1,
        _2_0,
        _2_a,
        _3_0
    }
}
