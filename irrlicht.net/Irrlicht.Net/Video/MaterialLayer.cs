// TextureLayer.cs created with MonoDevelop
// User: lester at 21:42 06.10.2007
//
//
//

using System;
using System.Runtime.InteropServices;
using System.Security;

namespace IrrlichtNET
{

    public class MaterialLayer : NativeElement
    {
        public MaterialLayer(IntPtr raw)
            : base(raw)
        {
        }

        public MaterialLayer()
            : base()
        {
        }

        //public override void Dispose()
        //{
        //    if (Elements.ContainsKey(Raw))
        //        Elements.Remove(Raw);
        //    MaterialLayer_Release(_raw);
        //    //base.Dispose();
        //}

        public bool TrilinearFilter
        {
            get
            {
                return MaterialLayer_GetTrilinearFilter(_raw);
            }
            set
            {
                MaterialLayer_SetTrilinearFilter(_raw, value);
            }
        }

        public bool AnisotropicFilter
        {
            get
            {
                return MaterialLayer_GetAnisotropicFilter(_raw);
            }
            set
            {
                MaterialLayer_SetAnisotropicFilter(_raw, value);
            }
        }

        public bool BilinearFilter
        {
            get
            {
                return MaterialLayer_GetBilinearFilter(_raw);
            }
            set
            {
                MaterialLayer_SetBilinearFilter(_raw, value);
            }
        }

        public Texture Texture
        {
            get
            {
                return (Texture)NativeElement.GetObject(MaterialLayer_GetTexture(_raw), typeof(Texture));
            }
            set
            {
                MaterialLayer_SetTexture(_raw, value.Raw);
            }
        }

        public Matrix4 TextureMatrix
        {
            get
            {
                float[] mat = new float[16];
                MaterialLayer_GetTransform(_raw, mat);
                return Matrix4.FromUnmanaged(mat);
            }

            set
            {
                Matrix4 mat = value;
                MaterialLayer_SetTransform(_raw, mat.ToUnmanaged());
            }
        }

        #region Native Imports
        // [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        //static extern IntPtr MaterialLayer_Create();

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern bool MaterialLayer_GetAnisotropicFilter(IntPtr material);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern bool MaterialLayer_GetBilinearFilter(IntPtr material);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern bool MaterialLayer_GetTrilinearFilter(IntPtr material);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void MaterialLayer_SetAnisotropicFilter(IntPtr material, bool val);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void MaterialLayer_SetBilinearFilter(IntPtr material, bool val);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void MaterialLayer_SetTrilinearFilter(IntPtr material, bool val);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void MaterialLayer_SetTexture(IntPtr material, IntPtr text);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr MaterialLayer_GetTexture(IntPtr material);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void MaterialLayer_GetTransform(IntPtr texture, [MarshalAs(UnmanagedType.LPArray)] float[] TxT);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void MaterialLayer_SetTransform(IntPtr texture, float[] TxT);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void MaterialLayer_Release(IntPtr materiallayer);

        #endregion

    }
}
