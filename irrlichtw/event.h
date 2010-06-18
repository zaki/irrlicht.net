#include "main.h"
extern "C"
{
    EXPORT IntPtr       Event_Create() { return new SEvent(); }
    EXPORT EEVENT_TYPE  Event_GetType(IntPtr event);
    EXPORT void         Event_SetType (IntPtr event, int evtype);

    // EXPORT IntPtr Event_GUI_GetElement(IntPtr event);

    EXPORT EMOUSE_INPUT_EVENT   Event_GetMouseInputEvent(IntPtr event);
    EXPORT EGUI_EVENT_TYPE      Event_GetGUIEventType(IntPtr event);

    // GUI EVENT
    EXPORT IntPtr Event_GetCaller(IntPtr event);

    // MOUSE AND KEYBOARD INPUT EVENT
    EXPORT float    Event_GetMouseWheelDelta(IntPtr event);
    EXPORT void     Event_GetMousePosition(IntPtr event, M_POS2DS pos);

    EXPORT EKEY_CODE Event_GetKey(IntPtr event);
    EXPORT char Event_GetKeyChar(IntPtr event);
    EXPORT bool Event_GetKeyPressedDown(IntPtr event);

    EXPORT bool Event_GetKeyShift(IntPtr event);
    EXPORT bool Event_GetKeyControl(IntPtr event);

    // LOG EVENT
    EXPORT M_STRING Event_GetLogString(IntPtr event);
    
    // USER EVENT
    EXPORT int      Event_GetUserDataI (IntPtr event, unsigned int num);
    EXPORT void     Event_SetUserDataI (IntPtr event, char num, int data);
    
    // JOYSTICK EVENT
    // EXPORT int*  Event_GetAxis(IntPtr event);
    // EXPORT int   Event_GetPOV(IntPtr event);
    // EXPORT int   Event_GetJoystick(IntPtr event);
    // EXPORT bool  Event_IsButtonPressed(IntPtr event, int button);
    
    EXPORT void Event_Release(IntPtr event);
}
