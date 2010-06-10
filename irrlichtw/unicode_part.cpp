#include "unicode_part.h"
#include "CGUITTFont.h"
extern IrrlichtDevice *GetDeviceFromIntPtr(IntPtr object);
extern IGUIElement *GetElem(IntPtr elem);
extern IGUIEnvironment *GetGui(IntPtr guienv);
extern ISceneManager *GetSceneFromIntPtr(IntPtr object);
void Device_SetWindowCaptionW(IntPtr device, wchar_t* caption)
{
    GetDeviceFromIntPtr(device)->setWindowCaption((caption));
}
void GuiElem_SetToolTipTextW( IntPtr elem, wchar_t* text )
{
    GetElem(elem)->setToolTipText((text));
}

void GuiElem_SetTextW(IntPtr elem, wchar_t* text)
{
    GetElem(elem)->setText((text));
}

int GUIComboBox_AddItemW(IntPtr combo, wchar_t* text)
{
    return ((IGUIComboBox*)combo)->addItem((text));
}

int GUIContextMenu_AddItemW(IntPtr menu, wchar_t* text, int commandID, bool enabled, bool hasSubMenu)
{
    return ((IGUIContextMenu*)menu)->addItem((text), commandID, enabled, hasSubMenu);
}

void GUIContextMenu_SetItemTextW(IntPtr menu, int index, wchar_t* text)
{
    ((IGUIContextMenu*)menu)->setItemText(index, (text));
}

void GUIFont_DrawW(IntPtr font, wchar_t* text, M_RECT pos, M_SCOLOR color, bool hcenter, bool vcenter, M_RECT clip)
{
    ((IGUIFont*)font)->draw((text), MU_RECT(pos), MU_SCOLOR(color), hcenter, vcenter, clip ? &(MU_RECT(clip)) : 0);
}

int GUIFont_GetCharacterFromPosW(IntPtr font, wchar_t* text, int pixel_x)
{
    return ((IGUIFont*)font)->getCharacterFromPos((text), pixel_x);
}

void GUIFont_GetDimensionW(IntPtr font, wchar_t* text, M_DIM2DU dim)
{
    UM_DIM2DU(((IGUIFont*)font)->getDimension((text)), dim);
}

int GUIListBox_AddItemW(IntPtr listb, wchar_t* text, int icon)
{
    return ((IGUIListBox*)listb)->addItem((text), icon);
}

int GUIListBox_AddItemAW(IntPtr listb, wchar_t* text)
{
    return ((IGUIListBox*)listb)->addItem((text));
}

IntPtr GUITabControl_AddTabW(IntPtr tabc, wchar_t* caption, int id)
{
    return ((IGUITabControl*)tabc)->addTab((caption), id);
}

IntPtr GUIToolBar_AddButtonW(IntPtr toolbar, int id, wchar_t* text, wchar_t* tooltip, IntPtr img, IntPtr pressedimg, bool isPushButton, bool useAlphaChannel)
{
    return ((IGUIToolBar*)toolbar)->addButton(id, (text), (tooltip), (ITexture*)img, (ITexture*)pressedimg, isPushButton, useAlphaChannel);
}

IntPtr GuiEnv_AddButtonW(IntPtr guienv, M_RECT rectangle, IntPtr parent, int id, wchar_t* text)
{
    return GetGui(guienv)->addButton(MU_RECT(rectangle), (IGUIElement*)parent, id, (text));
}

IntPtr GuiEnv_AddCheckBoxW(IntPtr guienv, bool checked, M_RECT rectangle, IntPtr parent, int id, wchar_t* text)
{
    return GetGui(guienv)->addCheckBox(checked, MU_RECT(rectangle), (IGUIElement*)parent, id, (text));
}

IntPtr GuiEnv_AddEditBoxW(IntPtr guienv, wchar_t* text, M_RECT rectangle, bool border, IntPtr parent, int id)
{
    return GetGui(guienv)->addEditBox((text), MU_RECT(rectangle), border, (IGUIElement*)parent, id);
}

IntPtr GuiEnv_AddFileOpenDialogW(IntPtr guienv, wchar_t* title, bool model, IntPtr parent, int id)
{
    return GetGui(guienv)->addFileOpenDialog((title), model, (IGUIElement*)parent, id);
}

IntPtr GuiEnv_AddImageW(IntPtr guienv, M_RECT rectangle, IntPtr parent, int id, wchar_t* text)
{
    return GetGui(guienv)->addImage(MU_RECT(rectangle), (IGUIElement*)parent, id, (text));
}

IntPtr GuiEnv_AddImageAW(IntPtr guienv, IntPtr image, M_POS2DS pos, bool useAlphaChannel, IntPtr parent, int id, wchar_t* text)
{
    return GetGui(guienv)->addImage((ITexture*)image, MU_POS2DS(pos), useAlphaChannel, (IGUIElement*)parent, id, (text));
}

IntPtr GuiEnv_AddMeshViewerW(IntPtr guienv, M_RECT rectangle, IntPtr parent, int id, wchar_t* text)
{
    return GetGui(guienv)->addMeshViewer(MU_RECT(rectangle), (IGUIElement*)parent, id, (text));
}

IntPtr GuiEnv_AddMessageBoxW(IntPtr guienv, wchar_t* caption, wchar_t* text, bool modal, EMESSAGE_BOX_FLAG flags, IntPtr parent, int id)
{
    return GetGui(guienv)->addMessageBox((caption), (text), modal, flags, (IGUIElement*)parent, id);
}

IntPtr GuiEnv_AddStaticTextW(IntPtr guienv, wchar_t* text, M_RECT rectangle, bool border, bool wordWrap, IntPtr parent, int id, bool fillBack)
{
    return GetGui(guienv)->addStaticText((text), MU_RECT(rectangle), border, wordWrap, (IGUIElement*)parent, id, fillBack);
}

IntPtr GuiEnv_AddWindowW(IntPtr guienv, M_RECT rectangle, bool modal, wchar_t* text, IntPtr parent, int id)
{
    return GetGui(guienv)->addWindow(MU_RECT(rectangle), modal, (text), (IGUIElement*)parent, id);
}

IntPtr GuiEnv_AddColorSelectDialogW(IntPtr guienv, wchar_t* title, bool modal, IntPtr parent, int id)
{
    return GetGui(guienv)->addColorSelectDialog ((title), modal, (IGUIElement*)parent, id);
}

IntPtr GuiEnv_AddSpinBoxW(IntPtr guienv, wchar_t* text, M_RECT rectangle, bool border, IntPtr parent, int id)
{
    return GetGui(guienv)->addSpinBox ((text), MU_RECT(rectangle), border, (IGUIElement*)parent, id);
}

IntPtr SceneManager_AddTextSceneNodeW(IntPtr scenemanager, IntPtr font, wchar_t* text, M_SCOLOR color, IntPtr parent)
{
    return GetSceneFromIntPtr(scenemanager)->addTextSceneNode((IGUIFont*) font, (text), MU_SCOLOR(color), (ISceneNode*) parent);
}

IntPtr SceneManager_AddTextSceneNode2W(IntPtr scenemanager, IntPtr font, wchar_t* text, IntPtr parent,  M_DIM2DF size, M_VECT3DF pos, int ID,                                                                                                            M_SCOLOR shade_top, M_SCOLOR shade_down)
{
    if (((IGUIFont*)font)->getType() == EGFT_BITMAP)
    {
        return GetSceneFromIntPtr(scenemanager)->addBillboardTextSceneNode((IGUIFont *)font, (text), (ISceneNode *)parent, MU_DIM2DF(size), MU_VECT3DF(pos), ID, MU_SCOLOR(shade_top), MU_SCOLOR(shade_down));
    } else {
        return ((CGUITTFont*)font)->createBillboard((text),                                                    MU_DIM2DF(size),                                                    (ISceneManager*)scenemanager,                                                    (ISceneNode*)parent,                                                    ID
            );

    }
}
void TextSceneNode_SetTextW(IntPtr text, wchar_t* ctext)
{
    ((ITextSceneNode*)text)->setText((ctext));
}
