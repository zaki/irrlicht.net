using System;
using System.Runtime.InteropServices;
using System.Security;

namespace IrrlichtNETCP
{
    public class BillboardSceneNode : SceneNode
    {
        public BillboardSceneNode(IntPtr raw)
            : base(raw)
        {
        }

        public Dimension2Df Size
        {
            get
            {
                float[] size = new float[2];
                BillboardSceneNode_GetSize(_raw, size);
                return Dimension2Df.FromUnmanaged(size);
            }
            set
            {
                BillboardSceneNode_SetSize(_raw, value.ToUnmanaged());
            }
        }

        #region Native Invokes
        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void BillboardSceneNode_GetSize(IntPtr billboard, [MarshalAs(UnmanagedType.LPArray)] float[] dim);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void BillboardSceneNode_SetSize(IntPtr billboard, float[] size);
        #endregion
    }

}
