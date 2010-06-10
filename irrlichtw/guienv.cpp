#include "guienv.h"

IGUIEnvironment *GetGui(IntPtr guienv)
{
    return ((IGUIEnvironment*)guienv);
}

IntPtr GuiEnv_AddButton(IntPtr guienv, M_RECT rectangle, IntPtr parent, int id, M_STRING text)
{
    return GetGui(guienv)->addButton(MU_RECT(rectangle), (IGUIElement*)parent, id, MU_WCHAR(text));
}

IntPtr GuiEnv_AddCheckBox(IntPtr guienv, bool checked, M_RECT rectangle, IntPtr parent, int id, M_STRING text)
{
    return GetGui(guienv)->addCheckBox(checked, MU_RECT(rectangle), (IGUIElement*)parent, id, MU_WCHAR(text));
}

IntPtr GuiEnv_AddComboBox(IntPtr guienv, M_RECT rectangle, IntPtr parent, int id)
{
    return GetGui(guienv)->addComboBox(MU_RECT(rectangle), (IGUIElement*)parent, id);
}

IntPtr GuiEnv_AddContextMenu(IntPtr guienv, M_RECT rectangle, IntPtr parent, int id)
{
    return GetGui(guienv)->addContextMenu(MU_RECT(rectangle), (IGUIElement*)parent, id);
}

IntPtr GuiEnv_AddEditBox(IntPtr guienv, M_STRING text, M_RECT rectangle, bool border, IntPtr parent, int id)
{
    return GetGui(guienv)->addEditBox(MU_WCHAR(text), MU_RECT(rectangle), border, (IGUIElement*)parent, id);
}

IntPtr GuiEnv_AddFileOpenDialog(IntPtr guienv, M_STRING title, bool model, IntPtr parent, int id)
{
    return GetGui(guienv)->addFileOpenDialog(MU_WCHAR(title), model, (IGUIElement*)parent, id);
}
IntPtr GuiEnv_AddImage(IntPtr guienv, M_RECT rectangle, IntPtr parent, int id, M_STRING text)
{
    return GetGui(guienv)->addImage(MU_RECT(rectangle), (IGUIElement*)parent, id, MU_WCHAR(text));
}

IntPtr GuiEnv_GetBuiltInFont(IntPtr guienv)
{
    return GetGui(guienv)->getBuiltInFont();
}

IntPtr GuiEnv_AddImageA(IntPtr guienv, IntPtr image, M_POS2DS pos, bool useAlphaChannel, IntPtr parent, int id, M_STRING text)
{
    return GetGui(guienv)->addImage((ITexture*)image, MU_POS2DS(pos), useAlphaChannel, (IGUIElement*)parent, id, MU_WCHAR(text));
}

IntPtr GuiEnv_AddInOutFader(IntPtr guienv, M_RECT rectangle, IntPtr parent, int id)
{
    if(rectangle != NULL)
        return GetGui(guienv)->addInOutFader(&MU_RECT(rectangle), (IGUIElement*)parent, id);
    else
        return GetGui(guienv)->addInOutFader(NULL, (IGUIElement*)parent, id);
}

IntPtr GuiEnv_AddListBox(IntPtr guienv, M_RECT rectangle, IntPtr parent, int id, bool drawBackground)
{
    return GetGui(guienv)->addListBox(MU_RECT(rectangle), (IGUIElement*)parent, id, drawBackground);
}

IntPtr GuiEnv_AddMenu(IntPtr guienv, IntPtr parent, int id)
{
    return GetGui(guienv)->addMenu((IGUIElement*)parent, id);
}

IntPtr GuiEnv_AddMeshViewer(IntPtr guienv, M_RECT rectangle, IntPtr parent, int id, M_STRING text)
{
    return GetGui(guienv)->addMeshViewer(MU_RECT(rectangle), (IGUIElement*)parent, id, MU_WCHAR(text));
}

IntPtr GuiEnv_AddMessageBox(IntPtr guienv, M_STRING caption, M_STRING text, bool modal, EMESSAGE_BOX_FLAG flags, IntPtr parent, int id)
{
    return GetGui(guienv)->addMessageBox(MU_WCHAR(caption), MU_WCHAR(text), modal, flags, (IGUIElement*)parent, id);
}

IntPtr GuiEnv_AddScrollBar(IntPtr guienv, bool horizontal, M_RECT rectangle, IntPtr parent, int id)
{
    return GetGui(guienv)->addScrollBar(horizontal, MU_RECT(rectangle), (IGUIElement*)parent, id);
}

IntPtr GuiEnv_AddStaticText(IntPtr guienv, M_STRING text, M_RECT rectangle, bool border, bool wordWrap, IntPtr parent, int id, bool fillBack)
{
    return GetGui(guienv)->addStaticText(MU_WCHAR(text), MU_RECT(rectangle), border, wordWrap, (IGUIElement*)parent, id, fillBack);
}

IntPtr GuiEnv_AddTab(IntPtr guienv, M_RECT rectangle, IntPtr parent, int id)
{
    return GetGui(guienv)->addTab(MU_RECT(rectangle), (IGUIElement*)parent, id);
}

IntPtr GuiEnv_AddTabControl(IntPtr guienv, M_RECT rectangle, IntPtr parent, bool fillbackGround, bool border, int id)
{
    return GetGui(guienv)->addTabControl(MU_RECT(rectangle), (IGUIElement*)parent, fillbackGround, border, id);
}

IntPtr GuiEnv_AddToolBar(IntPtr guienv, IntPtr parent, int id)
{
    return GetGui(guienv)->addToolBar((IGUIElement*)parent, id);
}

IntPtr GuiEnv_AddWindow(IntPtr guienv, M_RECT rectangle, bool modal, M_STRING text, IntPtr parent, int id)
{
    return GetGui(guienv)->addWindow(MU_RECT(rectangle), modal, MU_WCHAR(text), (IGUIElement*)parent, id);
}

/*
* Irrlicht 1.4 adding
*/

IntPtr GuiEnv_AddColorSelectDialog (IntPtr guienv, M_STRING title, bool modal, IntPtr parent, int id)
{
    return GetGui(guienv)->addColorSelectDialog (MU_WCHAR(title), modal, (IGUIElement*)parent, id);
}

IntPtr GuiEnv_AddSpinBox (IntPtr guienv, M_STRING text, M_RECT rectangle, bool border, IntPtr parent, int id)
{
    return GetGui(guienv)->addSpinBox (MU_WCHAR(text), MU_RECT(rectangle), border, (IGUIElement*)parent, id);
}

IntPtr GuiEnv_CreateSkin(IntPtr guienv, EGUI_SKIN_TYPE type)
{
    return GetGui(guienv)->createSkin(type);
}

void GuiEnv_DrawAll(IntPtr guienv)
{
    GetGui(guienv)->drawAll();
}

IntPtr GuiEnv_GetFont(IntPtr guienv, M_STRING filename)
{
    return GetGui(guienv)->getFont(filename);
}

void GuiEnv_Clear(IntPtr guienv)
{
    GetGui(guienv)->clear();
}

IntPtr GuiEnv_GetRootGUIElement(IntPtr guienv)
{
    return GetGui(guienv)->getRootGUIElement();
}

IntPtr GuiEnv_GetSkin(IntPtr guienv)
{
    return GetGui(guienv)->getSkin();
}

IntPtr GuiEnv_GetVideoDriver(IntPtr guienv)
{
    return GetGui(guienv)->getVideoDriver();
}

bool GuiEnv_HasFocus(IntPtr guienv, IntPtr element)
{
    _FIX_BOOL_MARSHAL_BUG(GetGui(guienv)->hasFocus((IGUIElement*)element));
}

bool GuiEnv_LoadGUI(IntPtr guienv, M_STRING filename)
{
    _FIX_BOOL_MARSHAL_BUG(GetGui(guienv)->loadGUI(filename));
}

bool GuiEnv_SaveGUI(IntPtr guienv, M_STRING filename)
{
    _FIX_BOOL_MARSHAL_BUG(GetGui(guienv)->saveGUI(filename));
}

bool GuiEnv_PostEventFromUser(IntPtr guienv, IntPtr event)
{
    _FIX_BOOL_MARSHAL_BUG(GetGui(guienv)->postEventFromUser(*((SEvent*)event)));
}

void GuiEnv_RemoveFocus(IntPtr guienv, IntPtr element)
{
    GetGui(guienv)->removeFocus((IGUIElement*)element);
}

void GuiEnv_SetFocus(IntPtr guienv, IntPtr element)
{
    GetGui(guienv)->setFocus((IGUIElement*)element);
}

void GuiEnv_SetSkin(IntPtr guienv, IntPtr skin)
{
    GetGui(guienv)->setSkin((IGUISkin*) skin);
}


void GuiSkin_GetColor(IntPtr gskin, EGUI_DEFAULT_COLOR which, M_SCOLOR color)
{
    UM_SCOLOR(((IGUISkin*)gskin)->getColor(which), color);
}

M_STRING GuiSkin_GetDefaultText(IntPtr gskin, EGUI_DEFAULT_TEXT which)
{
    return UM_STRING(((IGUISkin*)gskin)->getDefaultText(which));
}

IntPtr GuiSkin_GetFont(IntPtr gskin)
{
    return ((IGUISkin*)gskin)->getFont();
}

int GuiSkin_GetSize(IntPtr gskin, EGUI_DEFAULT_SIZE which)
{
    return ((IGUISkin*)gskin)->getSize(which);
}

void GuiSkin_SetColor(IntPtr gskin, EGUI_DEFAULT_COLOR which, M_SCOLOR color)
{
    ((IGUISkin*)gskin)->setColor(which, MU_SCOLOR(color));
}

void GuiSkin_SetDefaultText(IntPtr gskin, EGUI_DEFAULT_TEXT which, M_STRING text)
{
    ((IGUISkin*)gskin)->setDefaultText(which, MU_WCHAR(text));
}

void GuiSkin_SetFont(IntPtr gskin, IntPtr font)
{
    ((IGUISkin*)gskin)->setFont((IGUIFont*)font);
}

void GuiSkin_SetSize(IntPtr gskin, EGUI_DEFAULT_SIZE which, int size)
{
    ((IGUISkin*)gskin)->setSize(which, size);
}
