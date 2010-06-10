#include "main.h"

extern "C"
{
    EXPORT IntPtr GuiEnv_AddButton(IntPtr guienv, M_RECT rectangle, IntPtr parent, int id, M_STRING text);
    EXPORT IntPtr GuiEnv_AddCheckBox(IntPtr guienv, bool checked, M_RECT rectangle, IntPtr parent, int id, M_STRING text);
    EXPORT IntPtr GuiEnv_AddComboBox(IntPtr guienv, M_RECT rectangle, IntPtr parent, int id);
    EXPORT IntPtr GuiEnv_AddContextMenu(IntPtr guienv, M_RECT rectangle, IntPtr parent, int id);
    EXPORT IntPtr GuiEnv_AddEditBox(IntPtr guienv, M_STRING text, M_RECT rectangle, bool border, IntPtr parent, int id);
    EXPORT IntPtr GuiEnv_AddFileOpenDialog(IntPtr guienv, M_STRING title, bool model, IntPtr parent, int id);
    EXPORT IntPtr GuiEnv_AddImage(IntPtr guienv, M_RECT rectangle, IntPtr parent, int id, M_STRING text);
    EXPORT IntPtr GuiEnv_AddImageA(IntPtr guienv, IntPtr image, M_POS2DS pos, bool useAlphaChannel, IntPtr parent, int id, M_STRING text);
    EXPORT IntPtr GuiEnv_AddInOutFader(IntPtr guienv, M_RECT rectangle, IntPtr parent, int id);
    EXPORT IntPtr GuiEnv_AddListBox(IntPtr guienv, M_RECT rectangle, IntPtr parent, int id, bool drawBackground);
    EXPORT IntPtr GuiEnv_AddMenu(IntPtr guienv, IntPtr parent, int id);
    EXPORT IntPtr GuiEnv_AddMeshViewer(IntPtr guienv, M_RECT rectangle, IntPtr parent, int id, M_STRING text);
    EXPORT IntPtr GuiEnv_AddMessageBox(IntPtr guienv, M_STRING caption, M_STRING text, bool modal, EMESSAGE_BOX_FLAG flags, IntPtr parent, int id);
    EXPORT IntPtr GuiEnv_AddScrollBar(IntPtr guienv, bool horizontal, M_RECT rectangle, IntPtr parent, int id);
    EXPORT IntPtr GuiEnv_AddProgressBar(IntPtr guienv, bool horizontal, M_RECT rectangle, IntPtr parent, int id);
    EXPORT IntPtr GuiEnv_AddStaticText(IntPtr guienv, M_STRING text, M_RECT rectangle, bool border, bool wordWrap, IntPtr parent, int id, bool fillBack);
    EXPORT IntPtr GuiEnv_AddTab(IntPtr guienv, M_RECT rectangle, IntPtr parent, int id);
    EXPORT IntPtr GuiEnv_AddTabControl(IntPtr guienv, M_RECT rectangle, IntPtr parent, bool fillbackGround, bool border, int id);
    EXPORT IntPtr GuiEnv_AddToolBar(IntPtr guienv, IntPtr parent, int id);
    EXPORT IntPtr GuiEnv_AddWindow(IntPtr guienv, M_RECT rectangle, bool modal, M_STRING text, IntPtr parent, int id);
    /* 1.4 */
    EXPORT IntPtr GuiEnv_AddColorSelectDialog (IntPtr guienv, M_STRING title, bool modal, IntPtr parent, int id);
    EXPORT IntPtr GuiEnv_AddSpinBox (IntPtr guienv, M_STRING text, M_RECT rectangle, bool border, IntPtr parent, int id);

    EXPORT IntPtr GuiEnv_CreateSkin(IntPtr guienv, EGUI_SKIN_TYPE type);
    EXPORT void GuiEnv_DrawAll(IntPtr guienv);
    EXPORT void GuiEnv_Clear(IntPtr guienv);
    EXPORT IntPtr GuiEnv_GetFont(IntPtr guienv, M_STRING filename);
    EXPORT IntPtr GuiEnv_GetRootGUIElement(IntPtr guienv);
    EXPORT IntPtr GuiEnv_GetSkin(IntPtr guienv);
    EXPORT IntPtr GuiEnv_GetVideoDriver(IntPtr guienv);
    EXPORT bool GuiEnv_HasFocus(IntPtr guienv, IntPtr element);
    EXPORT bool GuiEnv_LoadGUI(IntPtr guienv, M_STRING filename);
    EXPORT bool GuiEnv_SaveGUI(IntPtr guienv, M_STRING filename);
    EXPORT bool GuiEnv_PostEventFromUser(IntPtr guienv, IntPtr event);
    EXPORT void GuiEnv_RemoveFocus(IntPtr guienv, IntPtr element);
    EXPORT void GuiEnv_SetFocus(IntPtr guienv, IntPtr element);
    EXPORT void GuiEnv_SetSkin(IntPtr guienv, IntPtr skin);
    EXPORT IntPtr GuiEnv_GetBuiltInFont(IntPtr guienv);

    EXPORT void GuiSkin_GetColor(IntPtr gskin, EGUI_DEFAULT_COLOR which, M_SCOLOR color);
    EXPORT M_STRING GuiSkin_GetDefaultText(IntPtr gskin, EGUI_DEFAULT_TEXT which);
    EXPORT IntPtr GuiSkin_GetFont(IntPtr gskin);
    EXPORT int GuiSkin_GetSize(IntPtr gskin, EGUI_DEFAULT_SIZE which);
    EXPORT void GuiSkin_SetColor(IntPtr gskin, EGUI_DEFAULT_COLOR which, M_SCOLOR color);
    EXPORT void GuiSkin_SetDefaultText(IntPtr gskin, EGUI_DEFAULT_TEXT which, M_STRING text);
    EXPORT void GuiSkin_SetFont(IntPtr gskin, IntPtr font);
    EXPORT void GuiSkin_SetSize(IntPtr gskin, EGUI_DEFAULT_SIZE which, int size);
}
