using System;
using System.Runtime.InteropServices;
using IrrlichtNETCP;
using System.Security;

namespace IrrlichtNETCP
{
    public class Animator : NativeElement
    {
        public Animator(IntPtr raw)
            : base(raw)
        {
        }

        public Animator() : base() { }
    }

    namespace Inheritable
    {
        public class IAnimator : Animator
        {
            private delegate void OnNativeAffectAnimator(IntPtr animator, IntPtr node, uint timeMS);
            static OnNativeAffectAnimator antigccallback;
            static IAnimator()
            {
                antigccallback = OnNativeCallback;
            }
            static void OnNativeCallback(IntPtr animator, IntPtr node, uint timeMS)
            {
                IAnimator anim = (IAnimator)NativeElement.GetObject(animator, typeof(IAnimator));
                SceneNode scenenode = (SceneNode)NativeElement.GetObject(node, typeof(SceneNode));
                anim.AnimateNode(scenenode, timeMS);
            }

            public IAnimator()
            {
                Initialize(IAnimator_Create(antigccallback));
            }

            public virtual void AnimateNode(SceneNode node, uint timeMS)
            {
            }

            #region Native Methods
            [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
            static extern IntPtr IAnimator_Create(OnNativeAffectAnimator callback);
            #endregion
        }
    }
}
