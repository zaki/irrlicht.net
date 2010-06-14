using System;
using System.Text;
using System.Runtime.InteropServices;
using System.Security;

namespace IrrlichtNET.Inheritable
{
    //I know this is not an interface but for naming purpose, I must name it ISceneNode...
    public abstract class ISceneNode : SceneNode
    {
        public ISceneNode(IntPtr raw)
            : base(raw)
        {
        }

        public ISceneNode(SceneNode parent, SceneManager mgr, int id)
        {
            antigc1 = OnCallbackFloat;
            antigc2 = OnCallbackInt;
            antigc3 = OnCallbackIntPtr;
            antigc4 = OnCallbackVoid;

            Initialize(
                CSN_CREATE(parent == null ? mgr.RootSceneNode.Raw : parent.Raw,
                           mgr.Raw,
                           id,
                           antigc4,
                           antigc2,
                           antigc3,
                           antigc1));
        }

        private delegate void CSN_CALLBACK_VOID(CSN_VOID_METHOD method, IntPtr arg1, int arg2, uint arg3, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] float[] arg4);
        private delegate int CSN_CALLBACK_INT(CSN_INT_METHOD method, IntPtr arg1, int arg2);
        private delegate IntPtr CSN_CALLBACK_INTPTR(CSN_INTPTR_METHOD method, IntPtr arg1, int arg2);
        private delegate void CSN_CALLBACK_FLOAT(CSN_FLOAT_METHOD method);

        private CSN_CALLBACK_FLOAT antigc1;
        private CSN_CALLBACK_INT antigc2;
        private CSN_CALLBACK_INTPTR antigc3;
        private CSN_CALLBACK_VOID antigc4;

        private void OnCallbackVoid(CSN_VOID_METHOD method, IntPtr arg1, int arg2, uint arg3, float[] arg4)
        {
            switch (method)
            {
                case CSN_VOID_METHOD.ADD_ANIMATOR:
                    AddAnimator((Animator)NativeElement.GetObject(arg1, typeof(Animator)));
                    break;
                case CSN_VOID_METHOD.ADD_CHILD:
                    AddChild((SceneNode)NativeElement.GetObject(arg1, typeof(SceneNode)));
                    break;
                case CSN_VOID_METHOD.ON_ANIMATE:
                    OnAnimate(arg3);
                    break;
                case CSN_VOID_METHOD.ON_REGISTER_SCENE_NODE:
                    OnRegisterSceneNode();
                    break;
                case CSN_VOID_METHOD.REMOVE:
                    Remove();
                    break;
                case CSN_VOID_METHOD.REMOVE_ALL:
                    RemoveAll();
                    break;
                case CSN_VOID_METHOD.REMOVE_ANIMATOR:
                    RemoveAnimator((Animator)NativeElement.GetObject(arg1, typeof(Animator)));
                    break;
                case CSN_VOID_METHOD.REMOVE_ANIMATORS:
                    RemoveAnimators();
                    break;
                case CSN_VOID_METHOD.RENDER:
                    Render();
                    break;
                case CSN_VOID_METHOD.SET_ID:
                    ID = arg2;
                    break;
                case CSN_VOID_METHOD.SET_PARENT:
                    Parent = (SceneNode)NativeElement.GetObject(arg1, typeof(SceneNode));
                    break;
                case CSN_VOID_METHOD.SET_POSITION:
                    Position = Vector3D.FromUnmanaged(arg4);
                    break;
                case CSN_VOID_METHOD.SET_SCALE:
                    Scale = Vector3D.FromUnmanaged(arg4);
                    break;
                case CSN_VOID_METHOD.SET_ROTATION:
                    Rotation = Vector3D.FromUnmanaged(arg4);
                    break;
                case CSN_VOID_METHOD.SET_TRIANGLE_SELECTOR:
                    TriangleSelector = (TriangleSelector)NativeElement.GetObject(arg1, typeof(TriangleSelector));
                    break;
                case CSN_VOID_METHOD.SET_VISIBLE:
                    Visible = arg2 == 0 ? false : true;
                    break;
                case CSN_VOID_METHOD.UPDATE_ABSOLUTE_POSITION:
                    UpdateAbsolutePosition();
                    break;
            }
        }
        private int OnCallbackInt(CSN_INT_METHOD method, IntPtr arg1, int arg2)
        {
            switch (method)
            {
                case CSN_INT_METHOD.GET_ID:
                    return ID;
                case CSN_INT_METHOD.GET_MATERIAL_COUNT:
                    return (int)MaterialCount;
                case CSN_INT_METHOD.IS_VISIBLE:
                    return Visible ? 1 : 0;
                case CSN_INT_METHOD.REMOVE_CHILD:
                    RemoveChild((SceneNode)NativeElement.GetObject(arg1, typeof(SceneNode)));
                    return 1;
            }
            return 0;
        }
        private IntPtr OnCallbackIntPtr(CSN_INTPTR_METHOD method, IntPtr arg1, int arg2)
        {
            switch (method)
            {
                case CSN_INTPTR_METHOD.GET_MATERIAL:
                    return GetMaterial(arg2).Raw;
                case CSN_INTPTR_METHOD.GET_PARENT:
                    return Parent.Raw;
                case CSN_INTPTR_METHOD.GET_TRIANGLE_SELECTOR:
                    return TriangleSelector.Raw;
            }
            return IntPtr.Zero;
        }
        private void OnCallbackFloat(CSN_FLOAT_METHOD method)
        {
            switch (method)
            {
                case CSN_FLOAT_METHOD.GET_ABSOLUTE_POSITION:
                    CSN_SET_TEMP_FLOATS(_raw, AbsolutePosition.ToUnmanaged());
                    break;
                case CSN_FLOAT_METHOD.GET_ABSOLUTE_TRANSFORMATION:
                    CSN_SET_TEMP_FLOATS(_raw, AbsoluteTransformation.ToUnmanaged());
                    break;
                case CSN_FLOAT_METHOD.GET_BOUNDING_BOX:
                    CSN_SET_TEMP_FLOATS(_raw, BoundingBox.ToUnmanaged());
                    CSN_PVOID_METHODS(_raw, CSN_VOID_METHOD.MANUAL_UPDATE_BOUNDINGBOX, IntPtr.Zero, 0, 0, null);
                    break;
                case CSN_FLOAT_METHOD.GET_POSITION:
                    CSN_SET_TEMP_FLOATS(_raw, Position.ToUnmanaged());
                    break;
                case CSN_FLOAT_METHOD.GET_R_TRANSFORMATION:
                    CSN_SET_TEMP_FLOATS(_raw, RelativeTransformation.ToUnmanaged());
                    break;
                case CSN_FLOAT_METHOD.GET_ROTATION:
                    CSN_SET_TEMP_FLOATS(_raw, Rotation.ToUnmanaged());
                    break;
                case CSN_FLOAT_METHOD.GET_SCALE:
                    CSN_SET_TEMP_FLOATS(_raw, Scale.ToUnmanaged());
                    break;
                case CSN_FLOAT_METHOD.GET_TRANSFORMED_BOUNDING_BOX:
                    CSN_SET_TEMP_FLOATS(_raw, TransformedBoundingBox.ToUnmanaged());
                    break;
            }
        }

        #region Managed => Native
        public override Vector3D AbsolutePosition
        {
            get
            {
                return Vector3D.FromUnmanaged(GetFloats(CSN_FLOAT_METHOD.GET_ABSOLUTE_POSITION));
            }
        }

        public override Matrix4 AbsoluteTransformation
        {
            get
            {
                return Matrix4.FromUnmanaged(GetFloats(CSN_FLOAT_METHOD.GET_ABSOLUTE_TRANSFORMATION));
            }
        }

        public override void AddAnimator(Animator animator)
        {
            CSN_PVOID_METHODS(_raw, CSN_VOID_METHOD.ADD_ANIMATOR, animator.Raw, 0, 0, null);
        }

        public override void AddChild(SceneNode child)
        {
            CSN_PVOID_METHODS(_raw, CSN_VOID_METHOD.ADD_CHILD, child.Raw, 0, 0, null);
        }

        public override Box3D BoundingBox
        {
            get
            {
                return new Box3D();
            }
        }

        public override Material GetMaterial(int i)
        {
            return (Material)
                NativeElement.GetObject(
                    CSN_PINTPTR_METHODS(_raw, CSN_INTPTR_METHOD.GET_MATERIAL, IntPtr.Zero, i), typeof(Material));
        }

        public override int ID
        {
            get
            {
                return CSN_PINT_METHODS(_raw, CSN_INT_METHOD.GET_ID, IntPtr.Zero, 0);
            }
            set
            {
                CSN_PVOID_METHODS(_raw, CSN_VOID_METHOD.SET_ID, IntPtr.Zero, value, 0, null);
            }
        }

        public override uint MaterialCount
        {
            get
            {
                return (uint)CSN_PINT_METHODS(_raw, CSN_INT_METHOD.GET_MATERIAL_COUNT, IntPtr.Zero, 0);
            }
        }

        public override void OnAnimate(uint timeMS)
        {
            CSN_PVOID_METHODS(_raw, CSN_VOID_METHOD.ON_ANIMATE, IntPtr.Zero, 0, timeMS, null);
        }

        public override void OnRegisterSceneNode()
        {
            CSN_PVOID_METHODS(_raw, CSN_VOID_METHOD.ON_REGISTER_SCENE_NODE, IntPtr.Zero, 0, 0, null);
        }

        public override SceneNode Parent
        {
            get
            {
                return (SceneNode)
                    NativeElement.GetObject(
                        CSN_PINTPTR_METHODS(_raw, CSN_INTPTR_METHOD.GET_PARENT, IntPtr.Zero, 0), typeof(SceneNode));
            }
            set
            {
                CSN_PVOID_METHODS(_raw, CSN_VOID_METHOD.SET_PARENT, value == null ? IntPtr.Zero : value.Raw, 0, 0, null);
            }
        }

        public override Vector3D Position
        {
            get
            {
                return Vector3D.FromUnmanaged(GetFloats(CSN_FLOAT_METHOD.GET_POSITION));
            }
            set
            {
                CSN_PVOID_METHODS(_raw, CSN_VOID_METHOD.SET_POSITION, IntPtr.Zero, 0, 0, value.ToUnmanaged());
            }
        }
        public override Vector3D Scale
        {
            get
            {
                return Vector3D.FromUnmanaged(GetFloats(CSN_FLOAT_METHOD.GET_SCALE));
            }
            set
            {
                CSN_PVOID_METHODS(_raw, CSN_VOID_METHOD.SET_SCALE, IntPtr.Zero, 0, 0, value.ToUnmanaged());
            }
        }
        public override Vector3D Rotation
        {
            get
            {
                return Vector3D.FromUnmanaged(GetFloats(CSN_FLOAT_METHOD.GET_ROTATION));
            }
            set
            {
                CSN_PVOID_METHODS(_raw, CSN_VOID_METHOD.SET_ROTATION, IntPtr.Zero, 0, 0, value.ToUnmanaged());
            }
        }

        public override Matrix4 RelativeTransformation
        {
            get
            {
                return Matrix4.FromUnmanaged(GetFloats(CSN_FLOAT_METHOD.GET_R_TRANSFORMATION));
            }
        }

        public override void Remove()
        {
            CSN_PVOID_METHODS(_raw, CSN_VOID_METHOD.REMOVE, IntPtr.Zero, 0, 0, null);
        }

        public override void RemoveAll()
        {
            CSN_PVOID_METHODS(_raw, CSN_VOID_METHOD.REMOVE_ALL, IntPtr.Zero, 0, 0, null);
        }

        public override void RemoveAnimator(Animator anim)
        {
            CSN_PVOID_METHODS(_raw, CSN_VOID_METHOD.REMOVE_ANIMATOR, anim.Raw, 0, 0, null);
        }

        public override void RemoveAnimators()
        {
            CSN_PVOID_METHODS(_raw, CSN_VOID_METHOD.REMOVE_ANIMATORS, IntPtr.Zero, 0, 0, null);
        }

        public override void RemoveChild(SceneNode child)
        {
            CSN_PINT_METHODS(_raw, CSN_INT_METHOD.REMOVE_CHILD, child.Raw, 0);
        }

        public override void Render()
        {
            CSN_PVOID_METHODS(_raw, CSN_VOID_METHOD.RENDER, IntPtr.Zero, 0, 0, null);
        }

        public override Box3D TransformedBoundingBox
        {
            get
            {
                return Box3D.FromUnmanaged(GetFloats(CSN_FLOAT_METHOD.GET_TRANSFORMED_BOUNDING_BOX));
            }
        }

        public override TriangleSelector TriangleSelector
        {
            get
            {
                return (TriangleSelector)
                    NativeElement.GetObject(CSN_PINTPTR_METHODS(_raw, CSN_INTPTR_METHOD.GET_TRIANGLE_SELECTOR, IntPtr.Zero, 0),
                        typeof(TriangleSelector));
            }
            set
            {
                CSN_PVOID_METHODS(_raw, CSN_VOID_METHOD.SET_TRIANGLE_SELECTOR, value == null ? IntPtr.Zero : value.Raw, 0, 0, null);
            }
        }

        public override void UpdateAbsolutePosition()
        {
            CSN_PVOID_METHODS(_raw, CSN_VOID_METHOD.UPDATE_ABSOLUTE_POSITION, IntPtr.Zero, 0, 0, null);
        }

        public override bool Visible
        {
            get
            {
                return CSN_PINT_METHODS(_raw, CSN_INT_METHOD.IS_VISIBLE, IntPtr.Zero, 0) == 0 ? false : true;
            }
            set
            {
                CSN_PVOID_METHODS(_raw, CSN_VOID_METHOD.SET_VISIBLE, IntPtr.Zero, value ? 1 : 0, 0, null);
            }
        }
        #endregion

        #region Native Code
        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void CSN_PVOID_METHODS(IntPtr csn, CSN_VOID_METHOD method, IntPtr arg1, int arg2, uint arg3, float[] arg4);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern int CSN_PINT_METHODS(IntPtr csn, CSN_INT_METHOD method, IntPtr arg1, int arg2);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr CSN_PINTPTR_METHODS(IntPtr csn, CSN_INTPTR_METHOD method, IntPtr arg1, int arg2);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void CSN_PFLOAT_METHODS(IntPtr csn, CSN_FLOAT_METHOD method, [MarshalAs(UnmanagedType.LPArray)] float[] arg1);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr CSN_CREATE(IntPtr parent, IntPtr mgr, int id, CSN_CALLBACK_VOID _void, CSN_CALLBACK_INT _int, CSN_CALLBACK_INTPTR _intptr, CSN_CALLBACK_FLOAT _float);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void CSN_SET_TEMP_FLOATS(IntPtr csn, float[] temp);

        private float[] GetFloats(CSN_FLOAT_METHOD method)
        {
            float[] tor;
            switch (method)
            {
                case CSN_FLOAT_METHOD.GET_ABSOLUTE_POSITION:
                case CSN_FLOAT_METHOD.GET_POSITION:
                case CSN_FLOAT_METHOD.GET_ROTATION:
                case CSN_FLOAT_METHOD.GET_SCALE:
                    tor = new float[3];
                    break;

                case CSN_FLOAT_METHOD.GET_TRANSFORMED_BOUNDING_BOX:
                    tor = new float[6];
                    break;

                default:
                    tor = new float[16];
                    break;
            }
            CSN_PFLOAT_METHODS(_raw, method, tor);
            return tor;
        }
        #endregion
    }

    internal enum CSN_VOID_METHOD
    {
        ADD_ANIMATOR = 0,
        ADD_CHILD,
        ON_ANIMATE,
        ON_REGISTER_SCENE_NODE,
        REMOVE,
        REMOVE_ALL,
        REMOVE_ANIMATOR,
        REMOVE_ANIMATORS,
        RENDER,
        SET_ID,
        SET_PARENT,
        SET_POSITION,
        SET_ROTATION,
        SET_SCALE,
        SET_TRIANGLE_SELECTOR,
        SET_VISIBLE,
        UPDATE_ABSOLUTE_POSITION,
        MANUAL_UPDATE_BOUNDINGBOX
    };

    internal enum CSN_FLOAT_METHOD
    {
        GET_ABSOLUTE_POSITION = 0,
        GET_ABSOLUTE_TRANSFORMATION,
        GET_BOUNDING_BOX,
        GET_POSITION,
        GET_R_TRANSFORMATION,
        GET_ROTATION,
        GET_SCALE,
        GET_TRANSFORMED_BOUNDING_BOX
    };

    internal enum CSN_INT_METHOD
    {
        GET_ID,
        GET_MATERIAL_COUNT,
        IS_VISIBLE,
        REMOVE_CHILD
    };

    internal enum CSN_INTPTR_METHOD
    {
        GET_MATERIAL,
        GET_TRIANGLE_SELECTOR,
        GET_PARENT
    };
}
