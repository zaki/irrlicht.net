#include "event.h"
#include <iostream>

SEvent *GetEventFromIntPtr(IntPtr event)
{
    return ((SEvent*)event);
}

EEVENT_TYPE Event_GetType(IntPtr event)
{
    return GetEventFromIntPtr(event)->EventType;
}

EMOUSE_INPUT_EVENT Event_GetMouseInputEvent(IntPtr event)
{
    return GetEventFromIntPtr(event)->MouseInput.Event;
}

EGUI_EVENT_TYPE Event_GetGUIEventType(IntPtr event)
{
    return GetEventFromIntPtr(event)->GUIEvent.EventType;
}

float Event_GetMouseWheelDelta(IntPtr event)
{
    return GetEventFromIntPtr(event)->MouseInput.Wheel;
}

void Event_GetMousePosition(IntPtr event, M_POS2DS pos)
{
    (pos)[0] = GetEventFromIntPtr(event)->MouseInput.X;
    (pos)[1] = GetEventFromIntPtr(event)->MouseInput.Y;
}

EKEY_CODE Event_GetKey(IntPtr event)
{
    return GetEventFromIntPtr(event)->KeyInput.Key;
}

bool Event_GetKeyPressedDown(IntPtr event)
{
    _FIX_BOOL_MARSHAL_BUG(GetEventFromIntPtr(event)->KeyInput.PressedDown);
}

bool Event_GetKeyShift(IntPtr event)
{
    _FIX_BOOL_MARSHAL_BUG(GetEventFromIntPtr(event)->KeyInput.Shift);
}

bool Event_GetKeyControl(IntPtr event)
{
    _FIX_BOOL_MARSHAL_BUG(GetEventFromIntPtr(event)->KeyInput.Control);
}

char Event_GetKeyChar(IntPtr event)
{
    return (char)GetEventFromIntPtr(event)->KeyInput.Char;
}

M_STRING Event_GetLogString(IntPtr ev)
{
    return UM_STRING(GetEventFromIntPtr(ev)->LogEvent.Text);
}

IntPtr Event_GetCaller(IntPtr event)
{
    return GetEventFromIntPtr(event)->GUIEvent.Caller;
}

void Event_SetType (IntPtr event, int evtype)
{
    GetEventFromIntPtr(event)->EventType = (irr::EEVENT_TYPE)evtype;
}

int Event_GetUserDataI (IntPtr event, char num)
{
    return num?
        (GetEventFromIntPtr(event)->UserEvent.UserData2) :
    (GetEventFromIntPtr(event)->UserEvent.UserData1) ;
}

void Event_SetUserDataI (IntPtr event, char num, int data)
{
    num?
        GetEventFromIntPtr(event)->UserEvent.UserData2 = data:
    GetEventFromIntPtr(event)->UserEvent.UserData1 = data;
}

void Event_Release (IntPtr event)
{
    if (event == 0)
        return;
    delete GetEventFromIntPtr(event);
}
