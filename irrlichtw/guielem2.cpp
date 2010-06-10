#include "guielem2.h"

bool useAlphaChannel = false;
bool GUIButton_GetUseAlphaChannel(IntPtr button)
{
    _FIX_BOOL_MARSHAL_BUG(useAlphaChannel);
}

bool GUIButton_IsPressed(IntPtr button)
{
    _FIX_BOOL_MARSHAL_BUG(((IGUIButton*)button)->isPressed());
}

void GUIButton_SetImage(IntPtr button, IntPtr image, M_RECT pos)
{
    ((IGUIButton*)button)->setImage((ITexture*)image, MU_RECT(pos));
}

void GUIButton_SetImageA(IntPtr button, IntPtr image)
{
    ((IGUIButton*)button)->setImage((ITexture*)image);
}

void GUIButton_SetIsPushButton(IntPtr button, bool ispush)
{
    ((IGUIButton*)button)->setIsPushButton(ispush);
}

void GUIButton_SetOverrideFont(IntPtr button, IntPtr font)
{
    ((IGUIButton*)button)->setOverrideFont((IGUIFont*)font);
}

void GUIButton_SetPressed(IntPtr button, bool pressed)
{
    ((IGUIButton*)button)->setPressed(pressed);
}

void GUIButton_SetPressedImage(IntPtr button, IntPtr image, M_RECT pos)
{
    ((IGUIButton*)button)->setPressedImage((ITexture*)image, MU_RECT(pos));
}

void GUIButton_SetPressedImageA(IntPtr button, IntPtr image)
{
    ((IGUIButton*)button)->setPressedImage((ITexture*)image);
}

void GUIButton_SetUseAlphaChannel(IntPtr button, bool use)
{
    ((IGUIButton*)button)->setUseAlphaChannel(use);
    useAlphaChannel = use;
}


bool GUICheckBox_IsChecked(IntPtr checkbox)
{
    _FIX_BOOL_MARSHAL_BUG(((IGUICheckBox*)checkbox)->isChecked());
}

void GUICheckBox_SetChecked(IntPtr checkbox, bool ck)
{
    ((IGUICheckBox*)checkbox)->setChecked(ck);
}


int GUIComboBox_AddItem(IntPtr combo, M_STRING text)
{
    return ((IGUIComboBox*)combo)->addItem(MU_WCHAR(text));
}

void GUIComboBox_Clear(IntPtr combo)
{
    ((IGUIComboBox*)combo)->clear();
}

M_STRING GUIComboBox_GetItem(IntPtr combo, int index)
{
    return UM_STRING(((IGUIComboBox*)combo)->getItem(index));
}

int GUIComboBox_GetItemCount(IntPtr combo)
{
    return ((IGUIComboBox*)combo)->getItemCount();
}

int GUIComboBox_GetSelected(IntPtr combo)
{
    return ((IGUIComboBox*)combo)->getSelected();
}

void GUIComboBox_SetSelected(IntPtr combo, int index)
{
    ((IGUIComboBox*)combo)->setSelected(index);
}


int GUIContextMenu_AddItem(IntPtr menu, M_STRING text, int commandID, bool enabled, bool hasSubMenu)
{
    return ((IGUIContextMenu*)menu)->addItem(MU_WCHAR(text), commandID, enabled, hasSubMenu);
}

void GUIContextMenu_AddSeparator(IntPtr menu)
{
    ((IGUIContextMenu*)menu)->addSeparator();
}

int GUIContextMenu_GetItemCommandID(IntPtr menu, int id)
{
    return ((IGUIContextMenu*)menu)->getItemCommandId(id);
}

int GUIContextMenu_GetItemCount(IntPtr menu)
{
    return ((IGUIContextMenu*)menu)->getItemCount();
}

M_STRING GUIContextMenu_GetItemText(IntPtr menu, int index)
{
    return UM_STRING(((IGUIContextMenu*)menu)->getItemText(index));
}

int GUIContextMenu_GetSelectedItem(IntPtr menu)
{
    return ((IGUIContextMenu*)menu)->getSelectedItem();
}

IntPtr GUIContextMenu_GetSubMenu(IntPtr menu, int index)
{
    return ((IGUIContextMenu*)menu)->getSubMenu(index);
}

bool GUIContextMenu_IsItemEnabled(IntPtr menu, int id)
{
    _FIX_BOOL_MARSHAL_BUG(((IGUIContextMenu*)menu)->isItemEnabled(id));
}

void GUIContextMenu_RemoveAllItems(IntPtr menu)
{
    ((IGUIContextMenu*)menu)->removeAllItems();
}

void GUIContextMenu_RemoveItem(IntPtr menu, int item)
{
    ((IGUIContextMenu*)menu)->removeItem(item);
}

void GUIContextMenu_SetItemCommandID(IntPtr menu, int index, int id)
{
    ((IGUIContextMenu*)menu)->setItemCommandId(index, id);
}

void GUIContextMenu_SetItemEnabled(IntPtr menu, int index, bool enabled)
{
    ((IGUIContextMenu*)menu)->setItemEnabled(index, enabled);
}

void GUIContextMenu_SetItemText(IntPtr menu, int index, M_STRING text)
{
    ((IGUIContextMenu*)menu)->setItemText(index, MU_WCHAR(text));
}


void GUIEditBox_EnableOverrideColor(IntPtr edit, bool enabled)
{
    ((IGUIEditBox*)edit)->enableOverrideColor(enabled);
}

int GUIEditBox_GetMax(IntPtr edit)
{
    return ((IGUIEditBox*)edit)->getMax();
}

void GUIEditBox_SetMax(IntPtr edit, int max)
{
    ((IGUIEditBox*)edit)->setMax(max);
}

void GUIEditBox_SetOverrideColor(IntPtr edit, M_SCOLOR color)
{
    ((IGUIEditBox*)edit)->setOverrideColor(MU_SCOLOR(color));
}

void GUIEditBox_SetOverrideFont(IntPtr edit, IntPtr font)
{
    ((IGUIEditBox*)edit)->setOverrideFont((IGUIFont*)font);
}

bool GUIEditBox_GetPassword(IntPtr edit)
{
    _FIX_BOOL_MARSHAL_BUG(((IGUIEditBox*)edit)->isPasswordBox());
}

void GUIEditBox_SetPassword(IntPtr edit, bool on_off)
{
    ((IGUIEditBox*)edit)->setPasswordBox(on_off);
}

M_STRING GUIFileOpenDialog_GetFilename(IntPtr dialog)
{
    return UM_STRING(((IGUIFileOpenDialog*)dialog)->getFileName());
}


void GUIImage_SetImage(IntPtr image, IntPtr texture)
{
    ((IGUIImage*)image)->setImage((ITexture*)texture);
}

void GUIImage_SetUseAlphaChannel(IntPtr image, bool use)
{
    ((IGUIImage*)image)->setUseAlphaChannel(use);
}

void GUIFont_Draw(IntPtr font, M_STRING text, M_RECT pos, M_SCOLOR color, bool hcenter, bool vcenter, M_RECT clip)
{
    ((IGUIFont*)font)->draw(MU_WCHAR(text), MU_RECT(pos), MU_SCOLOR(color), hcenter, vcenter, clip ? &(MU_RECT(clip)) : 0);
}

int GUIFont_GetCharacterFromPos(IntPtr font, M_STRING text, int pixel_x)
{
    return ((IGUIFont*)font)->getCharacterFromPos(MU_WCHAR(text), pixel_x);
}

void GUIFont_GetDimension(IntPtr font, M_STRING text, M_DIM2DU dim)
{
    UM_DIM2DU(((IGUIFont*)font)->getDimension(MU_WCHAR(text)), dim);
}


void GUIFader_FadeIn(IntPtr fader, unsigned int time)
{
    ((IGUIInOutFader*)fader)->fadeIn(time);
}

void GUIFader_FadeOut(IntPtr fader, unsigned int time)
{
    ((IGUIInOutFader*)fader)->fadeOut(time);
}

void GUIFader_GetColor(IntPtr fader, M_SCOLOR color)
{
    UM_SCOLOR(((IGUIInOutFader*)fader)->getColor(), color);
}

bool GUIFader_IsReady(IntPtr fader)
{
    _FIX_BOOL_MARSHAL_BUG(((IGUIInOutFader*)fader)->isReady());
}

void GUIFader_SetColor(IntPtr fader, M_SCOLOR color)
{
    ((IGUIInOutFader*)fader)->setColor(MU_SCOLOR(color));
}


int GUIListBox_AddItem(IntPtr listb, M_STRING text, int icon)
{
    return ((IGUIListBox*)listb)->addItem(MU_WCHAR(text), icon);
}

int GUIListBox_AddItemA(IntPtr listb, M_STRING text)
{
    return ((IGUIListBox*)listb)->addItem(MU_WCHAR(text));
}

void GUIListBox_Clear(IntPtr listb)
{
    ((IGUIListBox*)listb)->clear();
}

int GUIListBox_GetItemCount(IntPtr listb)
{
    return ((IGUIListBox*)listb)->getItemCount();
}

M_STRING GUIListBox_GetListItem(IntPtr listb, int id)
{
    return UM_STRING(((IGUIListBox*)listb)->getListItem(id));
}

int GUIListBox_GetSelected(IntPtr listb)
{
    return ((IGUIListBox*)listb)->getSelected();
}

/* Irrlicht 1.4 adding */

float GUISpinBox_GetMax (IntPtr spin)
{
    return ((IGUISpinBox*)spin)->getMax();
}

float GUISpinBox_GetMin(IntPtr spin)
{
    return ((IGUISpinBox*)spin)->getMin();
}

float GUISpinBox_GetStepSize (IntPtr spin)
{
    return ((IGUISpinBox*)spin)->getStepSize();
}

float GUISpinBox_GetValue (IntPtr spin)
{
    return ((IGUISpinBox*)spin)->getValue();
}

IntPtr GUISpinBox_GetEditBox (IntPtr spin)
{
    return (IntPtr)((IGUISpinBox*)spin)->getEditBox();
}

void GUISpinBox_SetRange (IntPtr spin, int min, int max)
{
    ((IGUISpinBox*)spin)->setRange((irr::f32)min, (irr::f32)max);
}

void GUISpinBox_SetStepSize (IntPtr spin, float step)
{
    ((IGUISpinBox*)spin)->setStepSize (step);
}

void GUISpinBox_SetValue (IntPtr spin, float value)
{
    ((IGUISpinBox*)spin)->setValue (value);
}

void GUISpinBox_SetDecimalPlaces (IntPtr spin, int places)
{
    ((IGUISpinBox*)spin)->setDecimalPlaces (places);
}

/**/

void GUIListBox_SetSelected(IntPtr listb, int sel)
{
    ((IGUIListBox*)listb)->setSelected(sel);
}


IntPtr GUIMeshViewer_GetMaterial(IntPtr meshv)
{
    return (IntPtr)&((IGUIMeshViewer*)meshv)->getMaterial();
}

void GUIMeshViewer_SetMaterial(IntPtr meshv, IntPtr mat)
{
    ((IGUIMeshViewer*)meshv)->setMaterial(*((SMaterial*)mat));
}

void GUIMeshViewer_SetMesh(IntPtr meshv, IntPtr animatedmesh)
{
    ((IGUIMeshViewer*)meshv)->setMesh((IAnimatedMesh*)animatedmesh);
}


IntPtr GUIWindow_GetCloseButton(IntPtr window)
{
    return ((IGUIWindow*)window)->getCloseButton();
}

IntPtr GUIWindow_GetMaximizeButton(IntPtr window)
{
    return ((IGUIWindow*)window)->getMaximizeButton();
}

IntPtr GUIWindow_GetMinimizeButton(IntPtr window)
{
    return ((IGUIWindow*)window)->getMinimizeButton();
}


int GUIScrollBar_GetPos(IntPtr sb)
{
    return ((IGUIScrollBar*)sb)->getPos();
}

void GUIScrollBar_SetMax(IntPtr sb, int max)
{
    ((IGUIScrollBar*)sb)->setMax(max);
}

void GUIScrollBar_SetPos(IntPtr sb, int pos)
{
    ((IGUIScrollBar*)sb)->setPos(pos);
}

void GUIStaticText_EnableOverrideColor(IntPtr st, bool enabled)
{
    ((IGUIStaticText*)st)->enableOverrideColor(enabled);
}

int GUIStaticText_GetTextHeight(IntPtr st)
{
    return ((IGUIStaticText*)st)->getTextHeight();
}

void GUIStaticText_SetOverrideColor(IntPtr st, M_SCOLOR color)
{
    ((IGUIStaticText*)st)->setOverrideColor(MU_SCOLOR(color));
}

void GUIStaticText_SetOverrideFont(IntPtr st, IntPtr font)
{
    ((IGUIStaticText*)st)->setOverrideFont((IGUIFont*)font);
}

void GUIStaticText_SetWordWrap(IntPtr st, bool enabled)
{
    ((IGUIStaticText*)st)->setWordWrap(enabled);
}


int GUITab_GetNumber(IntPtr tab)
{
    return ((IGUITab*)tab)->getNumber();
}

void GUITab_SetBackgroundColor(IntPtr tab, M_SCOLOR color)
{
    ((IGUITab*)tab)->setBackgroundColor(MU_SCOLOR(color));
}

void GUITab_SetDrawBackground(IntPtr tab, bool draw)
{
    ((IGUITab*)tab)->setDrawBackground(draw);
}


IntPtr GUITabControl_AddTab(IntPtr tabc, M_STRING caption, int id)
{
    return ((IGUITabControl*)tabc)->addTab(MU_WCHAR(caption), id);
}

int GUITabControl_GetActiveTab(IntPtr tabc)
{
    return ((IGUITabControl*)tabc)->getActiveTab();
}

IntPtr GUITabControl_GetTab(IntPtr tabc, int index)
{
    return ((IGUITabControl*)tabc)->getTab(index);
}

int GUITabControl_GetTabCount(IntPtr tabc)
{
    return ((IGUITabControl*)tabc)->getTabCount();
}

bool GUITabControl_SetActiveTab(IntPtr tabc, int index)
{
    _FIX_BOOL_MARSHAL_BUG(((IGUITabControl*)tabc)->setActiveTab(index));
}


IntPtr GUIToolBar_AddButton(IntPtr toolbar, int id, M_STRING text, M_STRING tooltip, IntPtr img, IntPtr pressedimg, bool isPushButton, bool useAlphaChannel)
{
    return ((IGUIToolBar*)toolbar)->addButton(id, MU_WCHAR(text), MU_WCHAR(tooltip), (ITexture*)img, (ITexture*)pressedimg, isPushButton, useAlphaChannel);
}
