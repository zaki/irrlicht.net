#include "guielem.h"

irr::gui::IGUIElement *GetElem(IntPtr elem)
{
    return (irr::gui::IGUIElement*)elem;
}

void GuiElem_AddChild(IntPtr elem, IntPtr child)
{
    GetElem(elem)->addChild(GetElem(child));
}

bool GuiElem_BringToFront(IntPtr elem, IntPtr element)
{
    _FIX_BOOL_MARSHAL_BUG(GetElem(elem)->bringToFront(GetElem(element)));
}

void GuiElem_Draw(IntPtr elem)
{
    GetElem(elem)->draw();
}

M_STRING GuiElem_GetToolTipText(IntPtr elem)
{
    return UM_STRING(GetElem(elem)->getText());
}

void GuiElem_SetToolTipText( IntPtr elem, M_STRING text )
{
    GetElem(elem)->setToolTipText(MU_WCHAR(text));
}

void GuiElem_GetAbsolutePosition(IntPtr elem, M_RECT pos)
{
    UM_RECT(GetElem(elem)->getAbsolutePosition(), pos);
}

void GuiElem_GetChildren(IntPtr elem, IntPtr *list)
{
    IGUIElement *element = GetElem(elem);
    //u32 size = element->getChildren().getSize();
    core::list<IGUIElement*>::ConstIterator it = element->getChildren().begin();
    int c = 0;
    for (; it != element->getChildren().end(); ++it)
    {
        list[c] = (*it);
        c++;
    }
}

//Only used by GUIElement.Children on C#
unsigned int GuiElem_GetChildrenCount(IntPtr elem)
{
    return GetElem(elem)->getChildren().getSize();
}

IntPtr GuiElem_GetElementFromID(IntPtr elem, int id, bool searchchildren)
{
    return GetElem(elem)->getElementFromId(id, searchchildren);
}

IntPtr GuiElem_GetElementFromPoint(IntPtr elem, M_POS2DS point)
{
    return GetElem(elem)->getElementFromPoint(MU_POS2DS(point));
}

int GuiElem_GetID(IntPtr elem)
{
    return GetElem(elem)->getID();
}

IntPtr GuiElem_GetParent(IntPtr elem)
{
    return GetElem(elem)->getParent();
}

void GuiElem_GetRelativePosition(IntPtr elem, M_RECT pos)
{
    UM_RECT(GetElem(elem)->getRelativePosition(), pos);
}

IntPtr GuiElem_GetText(IntPtr elem)
{
    setlocale(LC_ALL, "Japanese");
    return UM_STRING(GetElem(elem)->getText());
}

EGUI_ELEMENT_TYPE GuiElem_GetType(IntPtr elem)
{
    return GetElem(elem)->getType();
}

bool GuiElem_IsEnabled(IntPtr elem)
{
    _FIX_BOOL_MARSHAL_BUG(GetElem(elem)->isEnabled());
}

bool GuiElem_IsVisible(IntPtr elem)
{
    _FIX_BOOL_MARSHAL_BUG(GetElem(elem)->isVisible());
}

void GuiElem_Move(IntPtr elem, M_POS2DS absolutemovement)
{
    GetElem(elem)->move(MU_POS2DS(absolutemovement));
}

bool GuiElem_OnEvent(IntPtr elem, IntPtr ev)
{
    _FIX_BOOL_MARSHAL_BUG(GetElem(elem)->OnEvent(*((SEvent*)ev)));
}

void GuiElem_Remove(IntPtr elem)
{
    GetElem(elem)->remove();
}

void GuiElem_RemoveChild(IntPtr elem, IntPtr child)
{
    GetElem(elem)->removeChild(GetElem(child));
}

void GuiElem_SetEnabled(IntPtr elem, bool enabled)
{
    GetElem(elem)->setEnabled(enabled);
}

void GuiElem_SetID(IntPtr elem, int id)
{
    GetElem(elem)->setID(id);
}

void GuiElem_SetRelativePosition(IntPtr elem, M_RECT pos)
{
    GetElem(elem)->setRelativePosition(MU_RECT(pos));
}

void GuiElem_SetText(IntPtr elem, M_STRING text)
{
    GetElem(elem)->setText(MU_WCHAR(text));
}

void GuiElem_SetVisible(IntPtr elem, bool visible)
{
    GetElem(elem)->setVisible(visible);
}

void GuiElem_UpdateAbsolutePosition(IntPtr elem)
{
    GetElem(elem)->updateAbsolutePosition();
}

void GuiElem_OnPostRender (IntPtr elem, u32 timeMs)
{
    GetElem(elem)->OnPostRender(timeMs);
}

void GuiElem_SetAlignment (IntPtr elem, int *align)
{
    GetElem(elem)->setAlignment((EGUI_ALIGNMENT)align[0],
        (EGUI_ALIGNMENT)align[1],
        (EGUI_ALIGNMENT)align[2],
        (EGUI_ALIGNMENT)align[3]);
}

void GuiElem_SetMaxSize (IntPtr elem, M_DIM2DU size)
{
    GetElem(elem)->setMaxSize(MU_DIM2DU(size));
}

void GuiElem_SetMinSize (IntPtr elem, M_DIM2DU size)
{
    GetElem(elem)->setMinSize(MU_DIM2DU(size));
}

void GuiElem_SetNotClipped (IntPtr elem, bool noClip)
{
    GetElem(elem)->setNotClipped(noClip);
}

bool GuiElem_GetNotClipped (IntPtr elem)
{
    _FIX_BOOL_MARSHAL_BUG(GetElem(elem)->isNotClipped());
}
