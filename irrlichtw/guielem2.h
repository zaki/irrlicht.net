#include "main.h"

extern "C"
{
    EXPORT void GUIButton_SetOverrideFont(IntPtr button, IntPtr font);
    EXPORT void GUIButton_SetImage(IntPtr button, IntPtr image, M_RECT pos);
    EXPORT void GUIButton_SetImageA(IntPtr button, IntPtr image);
    EXPORT void GUIButton_SetPressedImage(IntPtr button, IntPtr image, M_RECT pos);
    EXPORT void GUIButton_SetPressedImageA(IntPtr button, IntPtr image);
    EXPORT bool GUIButton_GetUseAlphaChannel(IntPtr button);
    EXPORT bool GUIButton_IsPressed(IntPtr button);
    EXPORT void GUIButton_SetIsPushButton(IntPtr button, bool ispush);
    EXPORT void GUIButton_SetPressed(IntPtr button, bool pressed);
    EXPORT void GUIButton_SetUseAlphaChannel(IntPtr button, bool use);

    // TODO: 
    // EXPORT void GUIButton_SetSpriteBank(IntPtr button, IntPtr bank);
	// EXPORT void GUIButton_SetSprite(IntPtr button, EGUI_BUTTON_STATE state, int index, M_SCOLOR color, bool loop);
    // EXPORT bool GUIButton_IsPushButton();
	// EXPORT void GUIButton_SetDrawBorder(bool border);
	// EXPORT bool GUIButton_IsDrawingBorder();
	// EXPORT void GUIButton_SetScaleImage(bool scaleImage);
	// EXPORT bool GUIButton_IsScalingImage();


    EXPORT bool GUICheckBox_IsChecked(IntPtr checkbox);
    EXPORT void GUICheckBox_SetChecked(IntPtr checkbox, bool ck);


    EXPORT int GUIComboBox_AddItem(IntPtr combo, M_STRING text);
    EXPORT void GUIComboBox_Clear(IntPtr combo);
    EXPORT M_STRING GUIComboBox_GetItem(IntPtr combo, int index);
    EXPORT int GUIComboBox_GetItemCount(IntPtr combo);
    EXPORT int GUIComboBox_GetSelected(IntPtr combo);
    EXPORT void GUIComboBox_SetSelected(IntPtr combo, int index);

    // TODO:
    // EXPORT int GUIComboBox_GetItemData(IntPtr combo, int index); 
    // EXPORT int GUIComboBox_GetIndexForItemData(IntPtr combo, int data); 
    // EXPORT int GUIComboBox_RemoveItem(IntPtr combo, int index);
    // EXPORT int GUIComboBox_SetTextAlignment(IntPtr combo, EGUI_ALIGNMENT horizontal, EGUI_ALIGNMENT vertical); 


    EXPORT int GUIContextMenu_AddItem(IntPtr menu, M_STRING text, int commandID, bool enabled, bool hasSubMenu);
    EXPORT void GUIContextMenu_AddSeparator(IntPtr menu);
    EXPORT int GUIContextMenu_GetItemCommandID(IntPtr menu, int id);
    EXPORT int GUIContextMenu_GetItemCount(IntPtr menu);
    EXPORT M_STRING GUIContextMenu_GetItemText(IntPtr menu, int index);
    EXPORT int GUIContextMenu_GetSelectedItem(IntPtr menu);
    EXPORT IntPtr GUIContextMenu_GetSubMenu(IntPtr menu, int index);
    EXPORT bool GUIContextMenu_IsItemEnabled(IntPtr menu, int id);
    EXPORT void GUIContextMenu_RemoveAllItems(IntPtr menu);
    EXPORT void GUIContextMenu_RemoveItem(IntPtr menu, int item);
    EXPORT void GUIContextMenu_SetItemCommandID(IntPtr menu, int index, int id);
    EXPORT void GUIContextMenu_SetItemEnabled(IntPtr menu, int index, bool enabled);
    EXPORT void GUIContextMenu_SetItemText(IntPtr menu, int index, M_STRING text);

    // TODO:
    // EXPORT void GUIContextMenu_SetItemChecked(IntPtr menu, int index, bool enabled);
    // EXPORT bool GUIContextMenu_IsItemChecked(IntPtr menu, int index);


    EXPORT void GUIEditBox_EnableOverrideColor(IntPtr edit, bool enabled);
    EXPORT int  GUIEditBox_GetMax(IntPtr edit);
    EXPORT void GUIEditBox_SetMax(IntPtr edit, int max);
    EXPORT void GUIEditBox_SetOverrideColor(IntPtr edit, M_SCOLOR color);
    EXPORT void GUIEditBox_SetOverrideFont(IntPtr edit, IntPtr font);
    EXPORT void GUIEditBox_SetPassword(IntPtr edit, bool on_off);
    EXPORT bool GUIEditBox_GetPassword(IntPtr edit);

    // TODO:
    // EXPORT void GUIEditBox_SetDrawBorder(IntPtr edit, bool border);
	// EXPORT void GUIEditBox_SetTextAlignment(IntPtr edit, EGUI_ALIGNMENT horizontal, EGUI_ALIGNMENT vertical);
	// EXPORT void GUIEditBox_SetWordWrap(IntPtr edit, bool enable);
	// EXPORT bool GUIEditBox_IsWordWrapEnabled(IntPtr edit);
	// EXPORT void GUIEditBox_SetMultiLine(IntPtr edit, bool;
	// EXPORT bool GUIEditBox_IsMultiLineEnabled(IntPtr edit);
	// EXPORT void GUIEditBox_SetAutoScroll(IntPtr edit, bool;
	// EXPORT bool GUIEditBox_IsAutoScrollEnabled(IntPtr edit);
    // EXPORT void GUIEditBox_GetTextDimension(IntPtr edit, M_DIM2DU dim);


    EXPORT M_STRING GUIFileOpenDialog_GetFilename(IntPtr dialog);
    // TODO:
    // EXPORT M_STRING GUIFileOpenDialog_GetDirectoryName(IntPtr dialog);


    EXPORT void GUIFont_Draw(IntPtr font, M_STRING text, M_RECT pos, M_SCOLOR color, bool hcenter, bool vcenter, M_RECT clip);
    EXPORT int  GUIFont_GetCharacterFromPos(IntPtr font, M_STRING text, int pixel_x);
    EXPORT void GUIFont_GetDimension(IntPtr font, M_STRING text, M_DIM2DU dim);

    // TODO:
	// EXPORT EGUI_FONT_TYPE    GUIFont_GetType(IntPtr font);
	// EXPORT void              GUIFont_SetKerningWidth (IntPtr font, int kerning);
	// EXPORT void              GUIFont_SetKerningHeight (IntPtr font, int kerning);
	// EXPORT int               GUIFont_GetKerningWidth(IntPtr font, M_STRING thisLetter, M_STRING previousLetter);
	// EXPORT int               GUIFont_GetKerningHeight(IntPtr font);
	// EXPORT void              GUIFont_SetInvisibleCharacters(IntPtr font, M_STRING s);


    EXPORT void GUIImage_SetImage(IntPtr image, IntPtr texture);
    EXPORT void GUIImage_SetUseAlphaChannel(IntPtr image, bool use);

    // TODO: 
    // EXPORT void GUIImage_SetColor(IntPtr image, M_SCOLOR color);
    // EXPORT void GUIImage_SetScaleImage(IntPtr image, bool scale);
    // EXPORT bool GUIImage_IsImageScaled(IntPtr image);
    // EXPORT bool GUIImage_IsAlphaChannelUsed(IntPtr image);


    // TODO:
    // EXPORT void GUIImageList_Draw(IntPtr image, int index, M_POS2DS destPos, M_RECT clip);
    // EXPORT int  GUIImageList_GetImageCount(IntPtr image);
    // EXPORT void GUIImageList_GetImageSize(IntPtr image, M_DIM2DS size);


    EXPORT void GUIFader_FadeIn(IntPtr fader, unsigned int time);
    EXPORT void GUIFader_FadeOut(IntPtr fader, unsigned int time);
    EXPORT void GUIFader_GetColor(IntPtr fader, M_SCOLOR color);
    EXPORT bool GUIFader_IsReady(IntPtr fader);
    EXPORT void GUIFader_SetColor(IntPtr fader, M_SCOLOR color);

    // TODO:
    // EXPORT void GUIFader_SetColor(IntPtr fader, M_SCOLOR source, M_SCOLOR dest);


    EXPORT int GUIListBox_AddItem(IntPtr listb, M_STRING text, int icon);
    EXPORT int GUIListBox_AddItemA(IntPtr listb, M_STRING text);
    EXPORT void GUIListBox_Clear(IntPtr listb);
    EXPORT int GUIListBox_GetItemCount(IntPtr listb);
    EXPORT M_STRING GUIListBox_GetListItem(IntPtr listb, int id);
    EXPORT int GUIListBox_GetSelected(IntPtr listb);
    EXPORT void GUIListBox_SetSelected(IntPtr listb, int sel);

    // TODO:
    // EXPORT void GUIListBox_SetSelected(IntPtr listb, M_STRING item);
	// EXPORT void GUIListBox_SetAutoScrollEnabled(IntPtr listb, bool scroll);
	// EXPORT bool GUIListBox_IsAutoScrollEnabled(IntPtr listb);
	// EXPORT void GUIListBox_SetItemOverrideColor(IntPtr listb, int index, M_SCOLOR color);
	// EXPORT void GUIListBox_SetItemOverrideColor(IntPtr listb, int index, EGUI_LISTBOX_COLOR colorType, M_SCOLOR color);
	// EXPORT void GUIListBox_ClearItemOverrideColor(IntPtr listb, int index);
	// EXPORT void GUIListBox_ClearItemOverrideColor(IntPtr listb, int index, EGUI_LISTBOX_COLOR colorType);
	// EXPORT bool GUIListBox_HasItemOverrideColor(IntPtr listb, int index, EGUI_LISTBOX_COLOR colorType);
	// EXPORT void GUIListBox_GetItemOverrideColor(IntPtr listb, int index, EGUI_LISTBOX_COLOR colorType, M_SCOLOR color);
	// EXPORT void GUIListBox_GetItemDefaultColor(IntPtr listb, EGUI_LISTBOX_COLOR colorType, M_SCOLOR color);
	// EXPORT void GUIListBox_SetItem(IntPtr listb, int index, M_STRING text, int icon);
	// EXPORT int  GUIListBox_InsertItem(IntPtr listb, int index, M_STRING text, s32 icon);
	// EXPORT void GUIListBox_SwapItems(IntPtr listb, int index1, int index2);
	// EXPORT void GUIListBox_SetItemHeight(IntPtr listb, int height);
	// EXPORT void GUIListBox_SetDrawBackground(IntPtr listb, bool draw);
    // EXPORT void GUIListBox_RemoveItem(IntPtr listb, int index);
	// EXPORT int  GUIListBox_GetIcon(IntPtr listb, int index);
	// EXPORT void GUIListBox_SetSpriteBank(IntPtr listb, IntPtr bank);


    EXPORT float GUISpinBox_GetMax (IntPtr spin);
    EXPORT float GUISpinBox_GetMin(IntPtr spin);
    EXPORT float GUISpinBox_GetStepSize (IntPtr spin);
    EXPORT float GUISpinBox_GetValue (IntPtr spin);
    EXPORT IntPtr GUISpinBox_GetEditBox (IntPtr spin);
    EXPORT void GUISpinBox_SetRange (IntPtr spin, int min, int max);
    EXPORT void GUISpinBox_SetStepSize (IntPtr spin, float step);
    EXPORT void GUISpinBox_SetValue (IntPtr spin, float value);
    EXPORT void GUISpinBox_SetDecimalPlaces (IntPtr spin, int places);


    EXPORT IntPtr GUIMeshViewer_GetMaterial(IntPtr meshv);
    EXPORT void GUIMeshViewer_SetMaterial(IntPtr meshv, IntPtr mat);
    EXPORT void GUIMeshViewer_SetMesh(IntPtr meshv, IntPtr animatedmesh);

    // TODO: 
    // EXPORT IntPtr GUIMeshViewer_GetMesh(IntPtr meshv);


    EXPORT IntPtr GUIWindow_GetCloseButton(IntPtr window);
    EXPORT IntPtr GUIWindow_GetMaximizeButton(IntPtr window);
    EXPORT IntPtr GUIWindow_GetMinimizeButton(IntPtr window);

    // TODO:
    //	EXPORT bool GUIWindow_IsDraggable(IntPtr window);
	//	EXPORT void GUIWindow_SetDraggable(IntPtr window, bool draggable);
	//	EXPORT void GUIWindow_SetDrawBackground(IntPtr window, bool draw);
	//	EXPORT bool GUIWindow_GetDrawBackground(IntPtr window);
	//	EXPORT void GUIWindow_SetDrawTitlebar(IntPtr window, bool draw);
	//	EXPORT bool GUIWindow_GetDrawTitlebar(IntPtr window);


    EXPORT int GUIScrollBar_GetPos(IntPtr sb);
    EXPORT void GUIScrollBar_SetMax(IntPtr sb, int max);
    EXPORT void GUIScrollBar_SetPos(IntPtr sb, int pos);

    // TODO:
    //	EXPORT int  GUIScrollBar_GetMax(IntPtr sb);
	//	EXPORT void GUIScrollBar_SetMin(IntPtr sb, int max);
	//	EXPORT int  GUIScrollBar_GetMin(IntPtr sb);
	//	EXPORT int  GUIScrollBar_GetSmallStep(IntPtr sb);
	//	EXPORT void GUIScrollBar_SetSmallStep(IntPtr sb, int step);
	//	EXPORT int  GUIScrollBar_GetLargeStep(IntPtr sb);
	//	EXPORT void GUIScrollBar_SetLargeStep(IntPtr sb, int step);


    EXPORT void GUIStaticText_EnableOverrideColor(IntPtr st, bool enabled);
    EXPORT int  GUIStaticText_GetTextHeight(IntPtr st);
    EXPORT void GUIStaticText_SetOverrideColor(IntPtr st, M_SCOLOR color);
    EXPORT void GUIStaticText_SetOverrideFont(IntPtr st, IntPtr font);
    EXPORT void GUIStaticText_SetWordWrap(IntPtr st, bool enabled);

    // TODO:
	//	EXPORT IntPtr   GUIStaticText_GetOverrideFont(IntPtr st);
	//	EXPORT void     GUIStaticText_GetOverrideColor(IntPtr st, M_SCOLOR color);
	//	EXPORT bool     GUIStaticText_IsOverrideColorEnabled(IntPtr st);
	//	EXPORT void     GUIStaticText_SetBackgroundColor(IntPtr st, M_SCOLOR color);
	//	EXPORT void     GUIStaticText_SetDrawBackground(IntPtr st, bool draw);
	//	EXPORT void     GUIStaticText_SetDrawBorder(IntPtr st, bool draw);
	//	EXPORT void     GUIStaticText_SetTextAlignment(IntPtr st, EGUI_ALIGNMENT horizontal, EGUI_ALIGNMENT vertical);
	//	EXPORT bool     GUIStaticText_IsWordWrapEnabled(IntPtr st);
	//	EXPORT int      GUIStaticText_GetTextWidth(IntPtr st);


    EXPORT int  GUITab_GetNumber(IntPtr tab);
    EXPORT void GUITab_SetBackgroundColor(IntPtr tab, M_SCOLOR color);
    EXPORT void GUITab_SetDrawBackground(IntPtr tab, bool draw);

    // TODO:
	//	EXPORT bool GUITab_IsDrawingBackground(IntPtr tab);
	//	EXPORT void GUITab_GetBackgroundColor(IntPtr tab, M_SCOLOR color);
	//	EXPORT void GUITab_SetTextColor(IntPtr tab, M_SCOLOR color);
	//	EXPORT void GUITab_GetTextColor(IntPtr tab, M_SCOLOR color);


    EXPORT IntPtr GUITabControl_AddTab(IntPtr tabc, M_STRING caption, int id);
    EXPORT int    GUITabControl_GetActiveTab(IntPtr tabc);
    EXPORT IntPtr GUITabControl_GetTab(IntPtr tabc, int index);
    EXPORT int    GUITabControl_GetTabCount(IntPtr tabc);
    EXPORT bool   GUITabControl_SetActiveTab(IntPtr tabc, int index);

    // TODO: 
	//	EXPORT bool             GUITabControl_SetActiveTab(IntPtr tabc, Int Ptr tab);
	//	EXPORT void             GUITabControl_SetTabHeight(IntPtr tabc, int height);
	//	EXPORT int              GUITabControl_GetTabHeight(IntPtr tabc);
	//	EXPORT void             GUITabControl_SetTabMaxWidth(IntPtr tabc, int width);
	//	EXPORT int              GUITabControl_GetTabMaxWidth(IntPtr tabc);
	//	EXPORT void             GUITabControl_SetTabVerticalAlignment(IntPtr tabc, gui::EGUI_ALIGNMENT alignment);
	//	EXPORT EGUI_ALIGNMENT   GUITabControl_GetTabVerticalAlignment(IntPtr tabc);
	//	EXPORT void             GUITabControl_SetTabExtraWidth(IntPtr tabc, int extraWidth);
	//	EXPORT int              GUITabControl_GetTabExtraWidth(IntPtr tabc);


    EXPORT IntPtr GUIToolBar_AddButton(IntPtr toolbar, int id, M_STRING text, M_STRING tooltip, IntPtr img, IntPtr pressedimg, bool isPushButton, bool useAlphaChannel);

    // TODO:
    // ======================== IGUISkin ========================
	// EXPORT void      GUISkin_GetColor(IntPtr skin, EGUI_DEFAULT_COLOR color, M_SCOLOR color);
	// EXPORT void      GUISkin_SetColor(IntPtr skin, EGUI_DEFAULT_COLOR which, M_SCOLOR newColor);
	// EXPORT int       GUISkin_GetSize(IntPtr skin, EGUI_DEFAULT_SIZE size);
	// EXPORT M_STRING  GUISkin_GetDefaultText(IntPtr skin, EGUI_DEFAULT_TEXT text);
	// EXPORT void      GUISkin_SetDefaultText(IntPtr skin, EGUI_DEFAULT_TEXT which, M_STRING newText);
	// EXPORT void      GUISkin_SetSize(IntPtr skin, EGUI_DEFAULT_SIZE which, int size);
	// EXPORT IntPtr    GUISkin_GetFont(IntPtr skin, EGUI_DEFAULT_FONT which);
	// EXPORT void      GUISkin_SetFont(vIGUIFont* font, EGUI_DEFAULT_FONT which);
	// EXPORT IntPtr    GUISkin_GetSpriteBank(IntPtr skin);
	// EXPORT void      GUISkin_SetSpriteBank(IntPtr skin, IntPtr bank);
	// EXPORT u32       GUISkin_GetIcon(IntPtr skin, EGUI_DEFAULT_ICON icon);
	// EXPORT void      GUISkin_SetIcon(IntPtr skin, EGUI_DEFAULT_ICON icon, int index);
	// EXPORT void      GUISkin_Draw3DButtonPaneStandard(IntPtr skin, IntPtr element, M_RECT rect, M_RECT clip);
	// EXPORT void      GUISkin_Draw3DButtonPanePressed(IntPtr skin, IntPtr element, M_RECT rect, M_RECT clip);
	// EXPORT void      GUISkin_Draw3DSunkenPane(IntPtr skin, IntPtr element, M_SCOLOR, bool flat, bool fillBackGround, const M_RECT rect, M_RECT clip);
	// EXPORT void      GUISkin_Draw3DWindowBackground(IntPtr skin, IntPtr element, bool drawTitleBar, M_SCOLOR titleBarColor, M_RECT rect, M_RECT clip, M_RECT retval);
	// EXPORT void      GUISkin_Draw3DMenuPane(IntPtr skin, IntPtr element, M_RECT rect, M_RECT clip);
	// EXPORT void      GUISkin_Draw3DToolBar(IntPtr skin, IntPtr element, M_RECT rect, M_RECT clip);
	// EXPORT void      GUISkin_Draw3DTabButton(IntPtr skin, IntPtr element, bool active, M_RECT rect, M_RECT clip, gui::EGUI_ALIGNMENT alignment);
	// EXPORT void      GUISkin_Draw3DTabBody(IntPtr skin, IntPtr element, bool border, bool background, M_RECT rect, M_RECT clip, int tabHeight, EGUI_ALIGNMENT alignment);
	// EXPORT void      GUISkin_DrawIcon(IntPtr skin, IntPtr element, EGUI_DEFAULT_ICON icon, M_POS2DS position, int starttime, int currenttime, bool loop, M_RECT clip);
	// EXPORT void      GUISkin_Draw2DRectangle(IntPtr skin, IntPtr element, M_SCOLOR color, M_RECT pos, M_RECT clip);
	// EXPORT EGUI_SKIN_TYPE GUISkin_GetType(IntPtr skin)

    // ======================== IGUISpriteBank ========================
	// EXPORT void     GUISpriteBank_GetPositions(IntPtr bank, M_RECT retval); // return is core::array<core::rect<s32>>
	// EXPORT void     GUISpriteBank_GetSprites(IntPtr bank);  // return is core::array< SGUISprite >&
	// EXPORT int      GUISpriteBank_GetTextureCount(IntPtr bank,);
	// EXPORT IntPtr   GUISpriteBank_GetTexture(IntPtr bank, int index);
	// EXPORT void     GUISpriteBank_AddTexture(IntPtr bank, IntPtr texture);
	// EXPORT void     GUISpriteBank_SetTexture(IntPtr bank, int index, IntPtr texture);
	// EXPORT void     GUISpriteBank_Draw2DSprite(IntPtr bank, int index, M_POS2DS pos, M_RECT clip, M_SCOLOR color, int starttime, int currenttime, bool loop, bool center);
	// EXPORT void     GUISpriteBank_Draw2DSpriteBatch(IntPtr bank, int* indices, int* pos, M_RECT clip, M_SCOLOR color, int starttime, int currenttime, bool loop, bool center);

    // ======================== IGUITable ========================
	// EXPORT void      GUITable_AddColumn(IntPtr table, M_STRING caption, int columnIndex);
	// EXPORT void      GUITable_RemoveColumn(IntPtr table, int columnIndex);
	// EXPORT int       GUITable_GetColumnCount(IntPtr table);
	// EXPORT bool      GUITable_SetActiveColumn(IntPtr table, int idx, bool doOrder);
	// EXPORT int       GUITable_GetActiveColumn(IntPtr table);
	// EXPORT EGUI_ORDERING_MODE GUITable_GetActiveColumnOrdering(IntPtr table);
	// EXPORT void      GUITable_SetColumnWidth(IntPtr table, int columnIndex, int width);
	// EXPORT void      GUITable_SetResizableColumns(IntPtr table, bool resizable);
	// EXPORT bool      GUITable_HasResizableColumns(IntPtr table);
	// EXPORT void      GUITable_SetColumnOrdering(IntPtr table, int columnIndex, EGUI_COLUMN_ORDERING mode);
	// EXPORT int       GUITable_GetSelected(IntPtr table);
	// EXPORT void      GUITable_SetSelected(IntPtr table, int index);
	// EXPORT int       GUITable_GetRowCount(IntPtr table);
	// EXPORT int       GUITable_AddRow(IntPtr table, int rowIndex);
	// EXPORT void      GUITable_RemoveRow(IntPtr table, int rowIndex);
	// EXPORT void      GUITable_ClearRows(IntPtr table);
	// EXPORT void      GUITable_SwapRows(IntPtr table, int rowIndexA, int rowIndexB);
	// EXPORT void      GUITable_OrderRows(IntPtr table, int columnIndex, EGUI_ORDERING_MODE mode);
	// EXPORT void      GUITable_SetCellText(IntPtr table, int rowIndex, int columnIndex, M_STRING text);
	// EXPORT void      GUITable_SetCellText(IntPtr table, int rowIndex, int columnIndex, M_STRING text, M_SCOLOR color);
	// EXPORT void      GUITable_SetCellData(IntPtr table, int rowIndex, int columnIndex, IntPtr data);
	// EXPORT void      GUITable_SetCellColor(IntPtr table, int rowIndex, int columnIndex, M_SCOLOR color);
	// EXPORT M_STRING  GUITable_GetCellText(IntPtr table, int rowIndex, int columnIndex);
	// EXPORT IntPtr    GUITable_GetCellData(IntPtr table, int rowIndex, int columnIndex);
	// EXPORT void      GUITable_Clear(IntPtr table);
	// EXPORT void      GUITable_SetDrawFlags(IntPtr table, int flags);
	// EXPORT int       GUITable_GetDrawFlags(IntPtr table);

    // ======================== IGUITreeViewNode ========================
	// EXPORT IntPtr   GUITreeViewNode_GetOwner(IntPtr node);
	// EXPORT IntPtr   GUITreeViewNode_GetParent(IntPtr node);
	// EXPORT M_STRING GUITreeViewNode_GetText(IntPtr node);
	// EXPORT void     GUITreeViewNode_SetText(IntPtr node,  M_STRING text);
	// EXPORT M_STRING GUITreeViewNode_GetIcon(IntPtr node);
	// EXPORT void     GUITreeViewNode_SetIcon(IntPtr node, M_STRING icon);
	// EXPORT int      GUITreeViewNode_GetImageIndex(IntPtr node);
	// EXPORT void     GUITreeViewNode_SetImageIndex(IntPtr node, int imageIndex);
	// EXPORT int      GUITreeViewNode_GetSelectedImageIndex(IntPtr node);
	// EXPORT void     GUITreeViewNode_SetSelectedImageIndex(IntPtr node, int imageIndex );
	// EXPORT IntPtr   GUITreeViewNode_GetData(IntPtr node);
	// EXPORT void     GUITreeViewNode_SetData(IntPtr node, IntPtr data );
	// EXPORT IntPtr   GUITreeViewNode_GetData2(IntPtr node); // returns IReferenceCounted*
	// EXPORT void     GUITreeViewNode_SetData2(IntPtr node, IntPtr data ); // IReferenceCounted *
	// EXPORT int      GUITreeViewNode_GetChildCount(IntPtr node);
	// EXPORT void     GUITreeViewNode_ClearChilds(IntPtr node);
	// EXPORT bool     GUITreeViewNode_HasChilds(IntPtr node);
	// EXPORT IntPtr   GUITreeViewNode_AddChildBack(IntPtr node, M_STRING text, M_STRING icon, int imageIndex, int selectedImageIndex, IntPtr data, IntPtr data2); // data2 is IReferenceCounted*
	// EXPORT IntPtr   GUITreeViewNode_AddChildFront(IntPtr node, M_STRING text, M_STRING icon,int imageIndex, int selectedImageIndex, IntPtr data, IntPtr data2); // data2 is IReferenceCounted*
	// EXPORT IntPtr   GUITreeViewNode_InsertChildAfter(IntPtr node, IntPtr other, M_STRING text, M_STRING icon, int imageIndex, int selectedImageIndex, IntPtr data, IntPtr data2);
	// EXPORT IntPtr   GUITreeViewNode_InsertChildBefore(IntPtr node, IntPtr other, M_STRING text,M_STRING icon, int imageIndex, int selectedImageIndex, IntPtr data, IntPtr data2);
	// EXPORT IntPtr   GUITreeViewNode_GetFirstChild(IntPtr node);
	// EXPORT IntPtr   GUITreeViewNode_GetLastChild(IntPtr node);
	// EXPORT IntPtr   GUITreeViewNode_GetPrevSibling(IntPtr node);
	// EXPORT IntPtr   GUITreeViewNode_GetNextSibling(IntPtr node);
	// EXPORT IntPtr   GUITreeViewNode_GetNextVisible(IntPtr node);
	// EXPORT bool     GUITreeViewNode_DeleteChild(IntPtr node, IntPtr child);
	// EXPORT bool     GUITreeViewNode_MoveChildUp(IntPtr node, IntPtr child);
	// EXPORT bool     GUITreeViewNode_MoveChildDown(IntPtr node, IntPtr child);
	// EXPORT bool     GUITreeViewNode_GetExpanded(IntPtr node);
	// EXPORT void     GUITreeViewNode_SetExpanded(IntPtr node, bool expanded);
	// EXPORT bool     GUITreeViewNode_GetSelected(IntPtr node);
	// EXPORT void     GUITreeViewNode_SetSelected(IntPtr node, bool selected);
	// EXPORT bool     GUITreeViewNode_IsRoot(IntPtr node);
	// EXPORT int      GUITreeViewNode_GetLevel(IntPtr node);
	// EXPORT bool     GUITreeViewNode_IsVisible(IntPtr node);

    // ======================== IGUITreeView ========================
	// EXPORT IntPtr GUITreeView_GetRoot(IntPtr tree);
	// EXPORT IntPtr GUITreeView_GetSelected(IntPtr tree);
	// EXPORT bool   GUITreeView_GetLinesVisible(IntPtr tree);
	// EXPORT void   GUITreeView_SetLinesVisible(IntPtr tree, bool visible);
	// EXPORT void   GUITreeView_SetIconFont(IntPtr tree, IntPtr font);
	// EXPORT void   GUITreeView_SetImageList(IntPtr tree, IntPtr imageList);
	// EXPORT IntPtr GUITreeView_GetImageList(IntPtr tree);
	// EXPORT void   GUITreeView_SetImageLeftOfIcon(IntPtr tree, bool bLeftOf);
	// EXPORT bool   GUITreeView_GetImageLeftOfIcon(IntPtr tree);
	// EXPORT IntPtr GUITreeView_GetLastEventNode(IntPtr tree);
}
