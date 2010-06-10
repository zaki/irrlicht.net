#include "main.h"
extern "C"
{
    EXPORT void Device_SetWindowCaptionW(IntPtr device, wchar_t* caption);
    EXPORT void GuiElem_SetToolTipTextW( IntPtr elem, wchar_t* text );
    EXPORT void GuiElem_SetTextW(IntPtr elem, wchar_t* text);
    EXPORT int GUIComboBox_AddItemW(IntPtr combo, wchar_t* text);
    EXPORT int GUIContextMenu_AddItemW(IntPtr menu, wchar_t* text, int commandID, bool enabled, bool hasSubMenu);
    EXPORT void GUIContextMenu_SetItemTextW(IntPtr menu, int index, wchar_t* text);
    EXPORT void GUIFont_DrawW(IntPtr font, wchar_t* text, M_RECT pos, M_SCOLOR color, bool hcenter, bool vcenter, M_RECT clip);
    EXPORT int GUIFont_GetCharacterFromPosW(IntPtr font, wchar_t* text, int pixel_x);
    EXPORT void GUIFont_GetDimensionW(IntPtr font, wchar_t* text, M_DIM2DU dim);
    EXPORT int GUIListBox_AddItemW(IntPtr listb, wchar_t* text, int icon);
    EXPORT int GUIListBox_AddItemAW(IntPtr listb, wchar_t* text);
    EXPORT IntPtr GUITabControl_AddTabW(IntPtr tabc, wchar_t* caption, int id);
    EXPORT IntPtr GUIToolBar_AddButtonW(IntPtr toolbar, int id, wchar_t* text, wchar_t* tooltip, IntPtr img, IntPtr pressedimg, bool isPushButton, bool useAlphaChannel);
    EXPORT IntPtr GuiEnv_AddButtonW(IntPtr guienv, M_RECT rectangle, IntPtr parent, int id, wchar_t* text);
    EXPORT IntPtr GuiEnv_AddCheckBoxW(IntPtr guienv, bool checked, M_RECT rectangle, IntPtr parent, int id, wchar_t* text);
    EXPORT IntPtr GuiEnv_AddEditBoxW(IntPtr guienv, wchar_t* text, M_RECT rectangle, bool border, IntPtr parent, int id);
    EXPORT IntPtr GuiEnv_AddFileOpenDialogW(IntPtr guienv, wchar_t* title, bool model, IntPtr parent, int id);
    EXPORT IntPtr GuiEnv_AddImageW(IntPtr guienv, M_RECT rectangle, IntPtr parent, int id, wchar_t* text);
    EXPORT IntPtr GuiEnv_AddImageAW(IntPtr guienv, IntPtr image, M_POS2DS pos, bool useAlphaChannel, IntPtr parent, int id, wchar_t* text);
    EXPORT IntPtr GuiEnv_AddMeshViewerW(IntPtr guienv, M_RECT rectangle, IntPtr parent, int id, wchar_t* text);
    EXPORT IntPtr GuiEnv_AddMessageBoxW(IntPtr guienv, wchar_t* caption, wchar_t* text, bool modal, EMESSAGE_BOX_FLAG flags, IntPtr parent, int id);
    EXPORT IntPtr GuiEnv_AddStaticTextW(IntPtr guienv, wchar_t* text, M_RECT rectangle, bool border, bool wordWrap, IntPtr parent, int id, bool fillBack);
    EXPORT IntPtr GuiEnv_AddWindowW(IntPtr guienv, M_RECT rectangle, bool modal, wchar_t* text, IntPtr parent, int id);
    EXPORT IntPtr GuiEnv_AddColorSelectDialogW(IntPtr guienv, wchar_t* title, bool modal, IntPtr parent, int id);
    EXPORT IntPtr GuiEnv_AddSpinBoxW(IntPtr guienv, wchar_t* text, M_RECT rectangle, bool border, IntPtr parent, int id);
    EXPORT IntPtr SceneManager_AddTextSceneNodeW(IntPtr scenemanager, IntPtr font, wchar_t* text, M_SCOLOR color, IntPtr parent);
    EXPORT IntPtr SceneManager_AddTextSceneNode2W(IntPtr scenemanager, IntPtr font, wchar_t* text, IntPtr parent,  M_DIM2DF size, M_VECT3DF pos, int ID, M_SCOLOR shade_top, M_SCOLOR shade_down);
    EXPORT void TextSceneNode_SetTextW(IntPtr text, wchar_t* ctext);
}
