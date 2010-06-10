// BoneSceneNode.cs created with MonoDevelop
// User: lester at 13:13 2.11.2007
//
//
//

using System;
using System.Runtime.InteropServices;
using System.Security;

namespace IrrlichtNETCP
{
    public enum AnimationMode
    {
        Automatic,
        Animated,
        Unanimated,
        Count //Do not use
    }

    public enum SkinningSpace
    {
        Local,
        Global,
        Count //Do not use
    }

    public class BoneSceneNode : SceneNode
    {

        public BoneSceneNode(IntPtr raw)
            : base(raw)
        {
        }

        /// <value>
        /// Gets and sets the animation mode of the bone.
        /// </value>
        public AnimationMode AnimationMode
        {
            get
            {
                return BoneSceneNode_GetAnimationMode(_raw);
            }
            set
            {
                BoneSceneNode_SetAnimationMode(_raw, value);
            }
        }

        /// <value>
        /// Returns the index of the bone.
        /// </value>
        public uint Index
        {
            get
            {
                return BoneSceneNode_GetBoneIndex(_raw);
            }
        }

        /// <value>
        /// Returns the name of the bone
        /// </value>
        override public string Name
        {
            get
            {
                return BoneSceneNode_GetBoneName(_raw);
            }
        }

        /// <value>
        /// How the relative transformation of the bone is used.
        /// </value>
        public SkinningSpace SkinningSpace
        {
            get
            {
                return BoneSceneNode_GetSkinningSpace(_raw);
            }
            set
            {
                BoneSceneNode_SetSkinningSpace(_raw, value);
            }
        }

        public int ScaleHint
        {
            get
            {
                return BoneSceneNode_GetScaleHint(_raw);
            }
            set
            {
                BoneSceneNode_SetScaleHint(_raw, value);
            }
        }

        public int RotationHint
        {
            get
            {
                return BoneSceneNode_GetRotationHint(_raw);
            }
            set
            {
                BoneSceneNode_SetRotationHint(_raw, value);
            }
        }

        public int PositionHint
        {
            get
            {
                return BoneSceneNode_GetPositionHint(_raw);
            }
            set
            {
                BoneSceneNode_SetPositionHint(_raw, value);
            }
        }
        /// <summary>
        /// updates the absolute position based on the relative and the parents position
        /// </summary>
        public void UpdateAbsolutePositionOfAllChildren() // Whew, what are they smoking?
        {
            BoneSceneNode_UAPOAC(_raw);
        }

        #region Native imports
        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern AnimationMode BoneSceneNode_GetAnimationMode(IntPtr bone);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern uint BoneSceneNode_GetBoneIndex(IntPtr bone);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern string BoneSceneNode_GetBoneName(IntPtr bone);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void BoneSceneNode_SetAnimationMode(IntPtr bone, AnimationMode mode);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern SkinningSpace BoneSceneNode_GetSkinningSpace(IntPtr bone);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void BoneSceneNode_SetSkinningSpace(IntPtr bone, SkinningSpace space);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void BoneSceneNode_UAPOAC(IntPtr bone);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern int BoneSceneNode_GetScaleHint(IntPtr bone);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern int BoneSceneNode_GetRotationHint(IntPtr bone);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern int BoneSceneNode_GetPositionHint(IntPtr bone);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void BoneSceneNode_SetScaleHint(IntPtr bone, int hint);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void BoneSceneNode_SetRotationHint(IntPtr bone, int hint);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void BoneSceneNode_SetPositionHint(IntPtr bone, int hint);

        #endregion
    }
}
