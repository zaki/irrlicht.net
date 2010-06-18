#include "main.h"

extern "C"
{
    EXPORT IntPtr               GuiElem_GetParent(IntPtr elem);
    EXPORT void                 GuiElem_GetRelativePosition(IntPtr elem, M_RECT pos);
    EXPORT void                 GuiElem_SetRelativePosition(IntPtr elem, M_RECT pos);
    EXPORT void                 GuiElem_GetAbsolutePosition(IntPtr elem, M_RECT pos);
    EXPORT void                 GuiElem_SetNotClipped(IntPtr elem, bool noClip);
    EXPORT bool                 GuiElem_GetNotClipped(IntPtr elem);
    EXPORT void                 GuiElem_SetMaxSize(IntPtr elem, M_DIM2DU size);
    EXPORT void                 GuiElem_SetMinSize(IntPtr elem, M_DIM2DU size);
    EXPORT void                 GuiElem_SetAlignment (IntPtr elem, int *align);
    EXPORT void                 GuiElem_UpdateAbsolutePosition(IntPtr elem);
    EXPORT IntPtr               GuiElem_GetElementFromPoint(IntPtr elem, M_POS2DS point);
    EXPORT void                 GuiElem_AddChild(IntPtr elem, IntPtr child);
    EXPORT void                 GuiElem_RemoveChild(IntPtr elem, IntPtr child);
    EXPORT void                 GuiElem_Remove(IntPtr elem);
    EXPORT void                 GuiElem_Draw(IntPtr elem);
    EXPORT void                 GuiElem_OnPostRender (IntPtr elem, u32 timeMs);
    EXPORT void                 GuiElem_Move(IntPtr elem, M_POS2DS absolutemovement);
    EXPORT bool                 GuiElem_IsVisible(IntPtr elem);
    EXPORT void                 GuiElem_SetVisible(IntPtr elem, bool visible);
    EXPORT bool                 GuiElem_IsEnabled(IntPtr elem);
    EXPORT void                 GuiElem_SetEnabled(IntPtr elem, bool enabled);
    EXPORT M_STRING             GuiElem_GetText(IntPtr elem);
    EXPORT void                 GuiElem_SetText(IntPtr elem, M_STRING text);
    EXPORT M_STRING             GuiElem_GetToolTipText(IntPtr elem);
    EXPORT void                 GuiElem_SetToolTipText( IntPtr elem, M_STRING text );
    EXPORT int                  GuiElem_GetID(IntPtr elem);
    EXPORT void                 GuiElem_SetID(IntPtr elem, int id);
    EXPORT bool                 GuiElem_OnEvent(IntPtr elem, IntPtr ev);
    EXPORT bool                 GuiElem_BringToFront(IntPtr elem, IntPtr element);
    EXPORT void                 GuiElem_GetChildren(IntPtr elem, IntPtr *list);
    EXPORT unsigned int         GuiElem_GetChildrenCount(IntPtr elem); //Only used by GUIElement.Children on C#
    EXPORT IntPtr               GuiElem_GetElementFromID(IntPtr elem, int id, bool searchchildren);
    EXPORT EGUI_ELEMENT_TYPE    GuiElem_GetType(IntPtr elem);


    // TODO:
    // EXPORT void     GuiElem_SetRelativePosition(IntPtr elem, M_POS2DS pos);
    // EXPORT void     GuiElem_SetRelativePositionProportional(IntPtr elem, M_RECT pos);
    // EXPORT void     GuiElem_GetAbsoluteClippingRect(IntPtr elem, M_RECT rect);
    // EXPORT bool     GuiElem_IsNotClipped(IntPtr elem); ---
    // EXPORT bool     GuiElem_IsPointInside(IntPtr elem, M_POS2DS point);
    // EXPORT bool     GuiElem_IsSubElement(IntPtr elem);
    // EXPORT void     GuiElem_SetSubElement(IntPtr elem, bool subElement);
    // EXPORT bool     GuiElem_IsTabStop(IntPtr elem);
    // EXPORT void     GuiElem_SetTabStop(IntPtr elem, bool enable);
    // EXPORT int      GuiElem_GetTabOrder(IntPtr elem);
    // EXPORT void     GuiElem_SetTabOrder(IntPtr elem, int index);
    // EXPORT bool     GuiElem_IsTabGroup(IntPtr elem);
    // EXPORT void     GuiElem_SetTabGroup(IntPtr elem, bool isGroup);
    // EXPORT bool     GuiElem_IsMyChild(IntPtr elem, IntPtr child);
    // EXPORT bool     GuiElem_GetNextElement(IntPtr elem, int startOrder, bool reverse, bool group, IntPtr first, IntPtr closest, bool includeInvisible);
    // EXPORT M_STRING GuiElem_GetTypeName(IntPtr elem);
}
