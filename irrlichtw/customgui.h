#include "main.h"

extern "C"
{
    typedef enum _CGE_VOID_METHOD
    {
        ADD_CHILD = 0,
        DRAW,
        MOVE,
        ON_POST_RENDER,
        REMOVE,
        REMOVE_CHILD,
        SET_ALIGNMENT,
        SET_ENABLED,
        SET_ID,
        SET_MAX_SIZE,
        SET_MIN_SIZE,
        SET_NOT_CLIPPED,
        SET_RELATIVE_POSITION,
        SET_SUBELEMENT,
        SET_TAB_GROUP,
        SET_TAB_ORDER,
        SET_TAB_STOP,
        SET_TEXT,
        SET_TOOL_TIP_TEXT,
        SET_VISIBLE,
        UPDATE_ABSOLUTE_POSITION
    } CGE_VOID_METHOD;

    typedef enum _CGE_INT_METHOD
    {
        ON_EVENT = 0,
        IS_ENABLED,
        GET_ID,
        GET_NOCLIP,
        GET_TYPE,
        GET_VISIBLE,
        IS_SUBELEMENT
    } CGE_INT_METHOD;

    typedef enum _CGE_INTPTR_METHOD
    {
        GET_PARENT = 0,
        GET_TEXT
    } CGE_INTPTR_METHOD;

    typedef void (STDCALL CGE_CALLBACK_VOID)(CGE_VOID_METHOD method, IntPtr arg1, int arg2, unsigned int arg3, int *arg4);
    typedef int (STDCALL CGE_CALLBACK_INT)(CGE_INT_METHOD method, IntPtr arg1, int arg2, unsigned int arg3, int *arg4);
    typedef IntPtr (STDCALL CGE_CALLBACK_INTPTR) (CGE_INTPTR_METHOD method, IntPtr arg1, int arg2);
    EXPORT void CGE_PVOID_METHODS(IntPtr cge, CGE_VOID_METHOD method, IntPtr arg1, int arg2, unsigned int arg3, int *arg4);
    EXPORT int CGE_PINT_METHODS(IntPtr cge, CGE_INT_METHOD method, IntPtr arg1, int arg2, unsigned int arg3, int *arg4);
    EXPORT IntPtr CGE_PINTPTR_METHODS(IntPtr cge, CGE_INTPTR_METHOD method, IntPtr arg1, int arg2);

    EXPORT IntPtr CGE_CREATE(IntPtr guienv, IntPtr parent, s32 id, M_RECT rect, CGE_CALLBACK_VOID _void, CGE_CALLBACK_INT _int, CGE_CALLBACK_INTPTR _intptr);
}
