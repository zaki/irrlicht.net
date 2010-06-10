#include "main.h"
extern "C"
{
    typedef enum
    {
        ADD_ANIMATOR = 0,
        ADD_CHILD,
        ON_ANIMATE,
        ON_REGISTER_SCENE_NODE,
        REMOVE,
        REMOVE_ALL,
        REMOVE_ANIMATOR,
        REMOVE_ANIMATORS,
        RENDER,
        SET_ID,
        SET_PARENT,
        SET_POSITION,
        SET_ROTATION,
        SET_SCALE,
        SET_TRIANGLE_SELECTOR,
        SET_VISIBLE,
        UPDATE_ABSOLUTE_POSITION,
        MANUAL_UPDATE_BOUNDINGBOX
    } CSN_VOID_METHOD;

    typedef enum
    {
        GET_ABSOLUTE_POSITION = 0,
        GET_ABSOLUTE_TRANSFORMATION,
        GET_BOUNDING_BOX,
        GET_POSITION,
        GET_R_TRANSFORMATION,
        GET_ROTATION,
        GET_SCALE,
        GET_TRANSFORMED_BOUNDING_BOX
    } CSN_FLOAT_METHOD;

    typedef enum
    {
        GET_ID,
        GET_MATERIAL_COUNT,
        IS_VISIBLE,
        REMOVE_CHILD
    } CSN_INT_METHOD;

    typedef enum
    {
        GET_MATERIAL,
        GET_TRIANGLE_SELECTOR,
        GET_PARENT
    } CSN_INTPTR_METHOD;

    typedef void (STDCALL CSN_CALLBACK_VOID)(CSN_VOID_METHOD method, IntPtr arg1, int arg2, unsigned int arg3, float *arg4);
    typedef int (STDCALL CSN_CALLBACK_INT)(CSN_INT_METHOD method, IntPtr arg1, int arg2);
    typedef IntPtr (STDCALL CSN_CALLBACK_INTPTR)(CSN_INTPTR_METHOD method, IntPtr arg1, int arg2);
    typedef void (STDCALL CSN_CALLBACK_FLOAT)(CSN_FLOAT_METHOD method);
    EXPORT void CSN_PVOID_METHODS(IntPtr csn, CSN_VOID_METHOD method, IntPtr arg1, int arg2, unsigned int arg3, float *arg4);
    EXPORT int CSN_PINT_METHODS(IntPtr csn, CSN_INT_METHOD method, IntPtr arg1, int arg2);
    EXPORT IntPtr CSN_PINTPTR_METHODS(IntPtr csn, CSN_INTPTR_METHOD method, IntPtr arg1, int arg2);
    EXPORT void CSN_PFLOAT_METHODS(IntPtr csn, CSN_FLOAT_METHOD method, float* arg1);
    EXPORT void CSN_SET_TEMP_FLOATS(IntPtr csn, float* temp);
    EXPORT IntPtr CSN_CREATE(IntPtr parent, IntPtr mgr, s32 id, CSN_CALLBACK_VOID _void, CSN_CALLBACK_INT _int, CSN_CALLBACK_INTPTR _intptr, CSN_CALLBACK_FLOAT _float);
}
