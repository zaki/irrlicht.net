#include "customscenenodes.h"

//Hehe, I'm so clever and so lazy !
#define VOID_S(a,b) case a: b; break;
#define RETURN_S(a,b) case a: return b;
#define FLOAT_S(a,b,c) case a: c(b, arg1); break;
#define FLOAT_S2(a,b) c_float(a); return b(tempFloats);
class CustomSceneNode : public ISceneNode
{
protected:
    CSN_CALLBACK_VOID c_void;
    CSN_CALLBACK_INT c_int;
    CSN_CALLBACK_INTPTR c_intptr;
    CSN_CALLBACK_FLOAT c_float;

public:
    CustomSceneNode(ISceneNode* parent, ISceneManager* mgr, s32 id, CSN_CALLBACK_VOID _void, CSN_CALLBACK_INT _int, CSN_CALLBACK_INTPTR _intptr, CSN_CALLBACK_FLOAT _float) :
      ISceneNode(parent, mgr, id), c_void(_void), c_int(_int), c_intptr(_intptr), c_float(_float)
      {
      }

      float *tempFloats;
      virtual vector3df getAbsolutePosition()
      {
          FLOAT_S2(GET_ABSOLUTE_POSITION, MU_VECT3DF)
      }
      virtual vector3df getPosition()
      {
          FLOAT_S2(GET_POSITION, MU_VECT3DF)
      }
      virtual vector3df getScale()
      {
          FLOAT_S2(GET_SCALE, MU_VECT3DF)
      }
      virtual vector3df getRotation()
      {
          FLOAT_S2(GET_ROTATION, MU_VECT3DF)
      }
      virtual matrix4 getAbsoluteTransformation()
      {
          FLOAT_S2(GET_ABSOLUTE_TRANSFORMATION, MU_MAT4)
      }
      virtual matrix4 getRelativeTransformation()
      {
          FLOAT_S2(GET_R_TRANSFORMATION, MU_MAT4)
      }
      core::aabbox3d<f32> Box;
      virtual const aabbox3d<f32>& getBoundingBox() const
      {
          c_float(GET_BOUNDING_BOX);
          return Box;
      }
      virtual void updBB()
      {
          Box.reset(0.0f, 0.0f, 0.0f);
          Box.addInternalBox(MU_BOX3D(tempFloats));
      }
      virtual aabbox3d<f32> getTransformedBoundingBox()
      {
          FLOAT_S2(GET_TRANSFORMED_BOUNDING_BOX, MU_BOX3D)
      }

      virtual int getID()
      {
          return c_int(GET_ID, 0, 0);
      }
      virtual unsigned int getMaterialCount()
      {
          return (unsigned int)c_int(GET_MATERIAL_COUNT, 0, 0);
      }
      virtual bool isVisible()
      {
          return c_int(IS_VISIBLE, 0, 0) == 0 ? false : true;
      }
      virtual bool removeChild(ISceneNode *child)
      {
          return c_int(REMOVE_CHILD, child, 0) == 0 ? false : true;
      }

      virtual ISceneNode* getParent()
      {
          return ((ISceneNode*)c_intptr(GET_PARENT, 0, 0));
      }
      virtual SMaterial& getMaterial(unsigned int id)
      {
          return *((SMaterial*)c_intptr(GET_MATERIAL, 0, (int)id));
      }
      virtual ITriangleSelector* getTriangleSelector()
      {
          return ((ITriangleSelector*)c_intptr(GET_TRIANGLE_SELECTOR, 0, 0));
      }

      virtual void addAnimator(ISceneNodeAnimator* anim)
      {
          c_void(ADD_ANIMATOR, anim, 0, 0, 0);
      }
      virtual void addChild(ISceneNode *child)
      {
          c_void(ADD_CHILD, child, 0, 0, 0);
      }
      virtual void OnAnimate(unsigned int timeMS)
      {
          c_void(ON_ANIMATE, 0, 0, timeMS, 0);
      }
      virtual void OnRegisterSceneNode()
      {
          c_void(ON_REGISTER_SCENE_NODE, 0, 0, 0, 0);
      }
      virtual void remove()
      {
          c_void(REMOVE, 0, 0, 0, 0);
      }
      virtual void removeAll()
      {
          c_void(REMOVE_ALL, 0, 0, 0, 0);
      }
      virtual void removeAnimator(ISceneNodeAnimator *anim)
      {
          c_void(REMOVE_ANIMATOR, anim, 0, 0, 0);
      }
      virtual void removeAnimators()
      {
          c_void(REMOVE_ANIMATORS, 0, 0, 0, 0);
      }
      virtual void render()
      {
          c_void(RENDER, 0, 0, 0, 0);
      }
      virtual void setID(int id)
      {
          c_void(SET_ID, 0, id, 0, 0);
      }
      virtual void setParent(ISceneNode* newParent)
      {
          c_void(SET_PARENT, newParent, 0, 0, 0);
      }
      virtual void setPosition(vector3df position)
      {
          float *pos = new float[3];
          UM_VECT3DF(position, pos);
          c_void(SET_POSITION, 0, 3, 0, pos);
      }
      virtual void setRotation(vector3df position)
      {
          float *pos = new float[3];
          UM_VECT3DF(position, pos);
          c_void(SET_ROTATION, 0, 3, 0, pos);
      }
      virtual void setScale(vector3df position)
      {
          float *pos = new float[3];
          UM_VECT3DF(position, pos);
          c_void(SET_SCALE, 0, 3, 0, pos);
      }
      virtual void setTriangleSelector(ITriangleSelector* selector)
      {
          c_void(SET_TRIANGLE_SELECTOR, selector, 0, 0, 0);
      }
      virtual void setVisible(bool visible)
      {
          c_void(SET_VISIBLE,0, visible ? 1 : 0, 0, 0);
      }
      virtual void updateAbsolutePosition()
      {
          c_void(UPDATE_ABSOLUTE_POSITION, 0, 0, 0, 0);
      }

      void CSN_PVOID_METHODS(CSN_VOID_METHOD method, IntPtr arg1, int arg2, unsigned int arg3, float *arg4)
      {
          switch(method)
          {
          case RENDER: return;
              VOID_S(ADD_ANIMATOR, ISceneNode::addAnimator((ISceneNodeAnimator*)arg1))
              VOID_S(ADD_CHILD, ISceneNode::addChild((ISceneNode*)arg1))
              VOID_S(ON_ANIMATE, ISceneNode::OnAnimate(arg3))
              VOID_S(ON_REGISTER_SCENE_NODE, ISceneNode::OnRegisterSceneNode())
              VOID_S(REMOVE, ISceneNode::remove())
              VOID_S(REMOVE_ALL, ISceneNode::removeAll())
              VOID_S(REMOVE_ANIMATOR, ISceneNode::removeAnimator((ISceneNodeAnimator*)arg1))
              VOID_S(REMOVE_ANIMATORS, ISceneNode::removeAnimators())
              VOID_S(SET_ID, ISceneNode::setID(arg2))
              VOID_S(SET_PARENT, ISceneNode::setParent((ISceneNode*)arg1))
              VOID_S(SET_POSITION, ISceneNode::setPosition(MU_VECT3DF(arg4)))
              VOID_S(SET_ROTATION, ISceneNode::setRotation(MU_VECT3DF(arg4)))
              VOID_S(SET_SCALE, ISceneNode::setScale(MU_VECT3DF(arg4)))
              VOID_S(SET_TRIANGLE_SELECTOR, ISceneNode::setTriangleSelector((ITriangleSelector*)arg1))
              VOID_S(SET_VISIBLE, ISceneNode::setVisible(arg2 == 0 ? false : true))
              VOID_S(UPDATE_ABSOLUTE_POSITION, ISceneNode::updateAbsolutePosition())
              VOID_S(MANUAL_UPDATE_BOUNDINGBOX, updBB())
          }
      }

      int CSN_PINT_METHODS(CSN_INT_METHOD method, IntPtr arg1, int arg2)
      {
          switch(method)
          {
              RETURN_S(GET_ID, ISceneNode::getID())
              RETURN_S(GET_MATERIAL_COUNT, (int)ISceneNode::getMaterialCount())
              RETURN_S(IS_VISIBLE, ISceneNode::isVisible() ? 1 : 0)
              RETURN_S(REMOVE_CHILD, ISceneNode::removeChild((ISceneNode*)arg1) ? 1 : 0)
          }
          return 0;
      }

      IntPtr CSN_PINTPTR_METHODS(CSN_INTPTR_METHOD method, IntPtr arg1, int arg2)
      {
          switch(method)
          {
              RETURN_S(GET_MATERIAL, &ISceneNode::getMaterial(arg2))
              RETURN_S(GET_TRIANGLE_SELECTOR, ISceneNode::getTriangleSelector())
              RETURN_S(GET_PARENT, ISceneNode::getParent())
          }
          return 0;
      }

      void CSN_PFLOAT_METHODS(CSN_FLOAT_METHOD method, float* arg1)
      {
          switch(method)
          {
          case GET_BOUNDING_BOX: return;
              FLOAT_S(GET_ABSOLUTE_POSITION, ISceneNode::getAbsolutePosition(), UM_VECT3DF)
              FLOAT_S(GET_ABSOLUTE_TRANSFORMATION, ISceneNode::getAbsoluteTransformation(), UM_MAT4)
              FLOAT_S(GET_POSITION, ISceneNode::getPosition(), UM_VECT3DF)
              FLOAT_S(GET_R_TRANSFORMATION, ISceneNode::getRelativeTransformation(), UM_MAT4)
              FLOAT_S(GET_ROTATION, ISceneNode::getRotation(), UM_VECT3DF)
              FLOAT_S(GET_SCALE, ISceneNode::getScale(), UM_VECT3DF)
              FLOAT_S(GET_TRANSFORMED_BOUNDING_BOX, ISceneNode::getTransformedBoundingBox(), UM_BOX3D)
          }
      }
};

void CSN_PVOID_METHODS(IntPtr csn, CSN_VOID_METHOD method, IntPtr arg1, int arg2, unsigned int arg3, float *arg4)
{
    ((CustomSceneNode*)csn)->CSN_PVOID_METHODS(method, arg1, arg2, arg3, arg4);
}

int CSN_PINT_METHODS(IntPtr csn, CSN_INT_METHOD method, IntPtr arg1, int arg2)
{
    return ((CustomSceneNode*)csn)->CSN_PINT_METHODS(method, arg1, arg2);
}

IntPtr CSN_PINTPTR_METHODS(IntPtr csn, CSN_INTPTR_METHOD method, IntPtr arg1, int arg2)
{
    return ((CustomSceneNode*)csn)->CSN_PINTPTR_METHODS(method, arg1, arg2);
}

void CSN_PFLOAT_METHODS(IntPtr csn, CSN_FLOAT_METHOD method, float* arg1)
{
    ((CustomSceneNode*)csn)->CSN_PFLOAT_METHODS(method, arg1);
}


IntPtr CSN_CREATE(IntPtr parent, IntPtr mgr, s32 id, CSN_CALLBACK_VOID _void, CSN_CALLBACK_INT _int, CSN_CALLBACK_INTPTR _intptr, CSN_CALLBACK_FLOAT _float)
{
    CustomSceneNode *node = new CustomSceneNode((ISceneNode*)parent, (ISceneManager*)mgr,
        id, _void, _int, _intptr, _float);
    return node;
}

void CSN_SET_TEMP_FLOATS(IntPtr csn, float* temp)
{
    ((CustomSceneNode*)csn)->tempFloats = temp;
}

/* I'm even cleverer :) */
#undef VOID_S
#undef RETURN_S
#undef FLOAT_S
#undef FLOAT_S2
