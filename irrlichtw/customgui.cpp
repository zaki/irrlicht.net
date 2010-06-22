#include "customgui.h"

#define VOID_S(a,b) case a: b; break;
#define RETURN_S(a,b) case a: return b;

using namespace irr;
using namespace gui;
using namespace core;

class CustomGuiElement : public irr::gui::IGUIElement
{
protected:
    CGE_CALLBACK_VOID c_void;
    CGE_CALLBACK_INT c_int;
    CGE_CALLBACK_INTPTR c_intptr;

public:
    CustomGuiElement (IGUIEnvironment *gui, IGUIElement *parent, irr::s32 id,
        M_RECT rect,
        CGE_CALLBACK_VOID _void,
        CGE_CALLBACK_INT _int,
        CGE_CALLBACK_INTPTR _intptr)    :
    irr::gui::IGUIElement (EGUIET_ELEMENT, gui, parent, id, MU_RECT(rect)),
        c_void(_void), c_int(_int), c_intptr(_intptr)
    {
    }

    void CGE_PVOID_METHODS(CGE_VOID_METHOD method, IntPtr arg1, int arg2, unsigned int arg3, int *arg4)
    {
        switch (method)
        {
            VOID_S(ADD_CHILD, IGUIElement::addChild((IGUIElement*)arg1))
            VOID_S(DRAW, IGUIElement::draw())
            VOID_S(ON_POST_RENDER, IGUIElement::OnPostRender(arg3))
            VOID_S(MOVE, IGUIElement::move(MU_POS2DS(arg4)))
            VOID_S(REMOVE, IGUIElement::remove())
            VOID_S(REMOVE_CHILD, IGUIElement::removeChild((IGUIElement*)arg1))
            VOID_S(SET_ENABLED, IGUIElement::setEnabled(arg2!=0));
            VOID_S(SET_ID, IGUIElement::setID(arg2))
            VOID_S(SET_MAX_SIZE, IGUIElement::setMaxSize(MU_DIM2DU(arg4)))
            VOID_S(SET_MIN_SIZE, IGUIElement::setMinSize(MU_DIM2DU(arg4)))
            VOID_S(SET_NOT_CLIPPED, IGUIElement::setNotClipped(arg2!=0))
            VOID_S(SET_VISIBLE, IGUIElement::setVisible(arg2!=0))
            VOID_S(UPDATE_ABSOLUTE_POSITION, IGUIElement::updateAbsolutePosition())
        }
    }

    int CGE_PINT_METHODS (CGE_INT_METHOD method, IntPtr arg1, int arg2, unsigned int arg3, int *arg4)
    {
        switch (method)
        {
            RETURN_S(ON_EVENT, IGUIElement::OnEvent(*(SEvent*)arg1))
            RETURN_S(IS_ENABLED, IGUIElement::isEnabled())
            RETURN_S(GET_ID, IGUIElement::getID())
            RETURN_S(GET_NOCLIP, IGUIElement::isNotClipped())
            RETURN_S(GET_TYPE, IGUIElement::getType())
            RETURN_S(GET_VISIBLE, IGUIElement::isVisible())
        }
        return 0;
    }

    IntPtr CGE_PINTPTR_METHODS (CGE_INTPTR_METHOD method, IntPtr arg1, int arg2)
    {
        switch (method)
        {
            RETURN_S(GET_PARENT, IGUIElement::getParent())
            RETURN_S(GET_TEXT, UM_STRING(IGUIElement::getText()))
        }
        return 0;
    }

    /* Virtual callback dispatch */
    virtual void draw ()
    {
        c_void (DRAW, NULL, 0, 0, NULL);
    }

    virtual void addChild(IGUIElement *child)
    {
        c_void (ADD_CHILD, child, 0, 0, NULL);
    }

    virtual void OnPostRender(irr::u32 timeMs)
    {
        c_void (ON_POST_RENDER, NULL, 0, timeMs, NULL);
    }

    virtual void move (core::position2d<s32> absoluteMovement)
    {
        int *pos = new int[2];
        UM_POS2DS(absoluteMovement, pos);
        c_void (MOVE, NULL, 2, 0, pos);
    }

    virtual void remove ()
    {
        c_void (REMOVE, NULL, 0, 0, NULL);
    }

    virtual void removeChild (IGUIElement *child)
    {
        c_void (REMOVE_CHILD, child, 0, 0, NULL);
    }

    virtual void setAlignment (EGUI_ALIGNMENT left, EGUI_ALIGNMENT right, EGUI_ALIGNMENT top, EGUI_ALIGNMENT bottom)
    {
        int *align = new int[4];
        align[0] = left;
        align[1] = right;
        align[2] = top;
        align[3] = bottom;
        c_void (SET_ALIGNMENT, NULL, 0, 0, align);
    }

    virtual void setEnabled (bool enabled)
    {
        c_void (SET_ENABLED, NULL, enabled, 0, NULL);
    }

    virtual bool isEnabled () const
    {
        int r = c_int (IS_ENABLED, NULL, 0, 0, NULL);
        return (r != 0);
    }

    virtual void setID(s32 id)
    {
        c_void (SET_ID, NULL, id, 0, NULL);
    }

    virtual s32 getID () const
    {
        return c_int(GET_ID, NULL, 0, 0, NULL);
    }

    virtual void setMaxSize(core::dimension2di size)
    {
        int *dim = new int[2];
        UM_DIM2DS(size, dim);
        c_void (SET_MAX_SIZE, NULL, 0, 0, dim);
    }

    virtual void setMinSize(core::dimension2di size)
    {
        int *dim = new int[2];
        UM_DIM2DS(size, dim);
        c_void (SET_MIN_SIZE, NULL, 0, 0, dim);
    }

    virtual void setNotClipped (bool noClip)
    {
        c_void(SET_NOT_CLIPPED, NULL, noClip, 0, NULL);
    }

    virtual bool OnEvent (const SEvent &event)
    {
        int r = c_int(ON_EVENT, (void *)&event, 0, 0, NULL);
        return (r != 0);
    }

    virtual bool isNotClipped () const
    {
        int r = c_int(GET_NOCLIP, NULL, 0, 0, NULL);
        return (r != 0);
    }

    virtual EGUI_ELEMENT_TYPE getType () const
    {
        return (EGUI_ELEMENT_TYPE)c_int(GET_TYPE, NULL, 0, 0, NULL);
    }

    virtual void updateAbsoutePosition ()
    {
        c_void (UPDATE_ABSOLUTE_POSITION, NULL, 0, 0, NULL);
    }

    virtual void setVisible (bool visible)
    {
        c_void (SET_VISIBLE, NULL, visible, 0, NULL);
    }

    virtual bool isVisible () const
    {
        int r = c_int (GET_VISIBLE, NULL, 0, 0, NULL);
        return (r != 0);
    }

    virtual IGUIElement *getParent () const
    {
        return (IGUIElement *)c_intptr (GET_PARENT, NULL, 0);
    }

    virtual void setText (const wchar_t *text)
    {
        c_void(SET_TEXT, UM_STRING(text), 0, 0, NULL);
    }

    virtual const wchar_t *getText () const
    {
        return MU_WCHAR((const char*)c_intptr(GET_TEXT, NULL, 0));
    }

};

void CGE_PVOID_METHODS(IntPtr cge, CGE_VOID_METHOD method, IntPtr arg1, int arg2, unsigned int arg3, int *arg4)
{
    ((CustomGuiElement *)cge)->CGE_PVOID_METHODS(method, arg1, arg2, arg3, arg4);
}

int CGE_PINT_METHODS(IntPtr cge, CGE_INT_METHOD method, IntPtr arg1, int arg2, unsigned int arg3, int *arg4)
{
    return ((CustomGuiElement *)cge)->CGE_PINT_METHODS(method, arg1, arg2, arg3, arg4);
}

IntPtr CGE_PINTPTR_METHODS(IntPtr cge, CGE_INTPTR_METHOD method, IntPtr arg1, int arg2)
{
    return ((CustomGuiElement *)cge)->CGE_PINTPTR_METHODS(method, arg1, arg2);
}

IntPtr CGE_CREATE(IntPtr guienv, IntPtr parent, s32 id, M_RECT rect, CGE_CALLBACK_VOID _void,
                  CGE_CALLBACK_INT _int, CGE_CALLBACK_INTPTR _intptr)
{
    CustomGuiElement *element = new CustomGuiElement((IGUIEnvironment*)guienv, (IGUIElement*)parent, id, rect, _void, _int, _intptr);
    return element;
}
