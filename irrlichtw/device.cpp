#include "device.h"
#include <iostream>

IrrlichtDevice *GetDeviceFromIntPtr(IntPtr object)
{
    return (IrrlichtDevice*) object;
}

class EventReceiver : public IEventReceiver
{
public:

    EventReceiver()
    {
        IsCallbackDefined = false;
    }

    virtual bool OnEvent(const SEvent& ev)
    {
        SEvent temp = ev;
        if(IsCallbackDefined)
            return _callback((void *)&temp);
        return false;
    }

    void setCallback(EVENTCALLBACK call)
    {
        IsCallbackDefined = true;
        _callback = call;
    }
protected:
    bool IsCallbackDefined;
    EVENTCALLBACK _callback;
};

IntPtr CreateDevice(E_DRIVER_TYPE type, M_DIM2DS dim, int bits, bool full, bool stencil, bool vsync, bool antialias)
{
    SIrrlichtCreationParameters params;
    params.AntiAlias = antialias;
    params.Bits = bits;
    params.Fullscreen = full;
    params.Stencilbuffer = stencil;
    params.Vsync = vsync;
    params.WindowSize = MU_DIM2DS(dim);
    params.DriverType = type;
    params.EventReceiver = new EventReceiver();
    return createDeviceEx(params);
}

IntPtr CreateDeviceA(E_DRIVER_TYPE type, M_DIM2DS dim, int bits, bool full, bool stencil, bool vsync, bool antialias, IntPtr handle)
{
    SIrrlichtCreationParameters params;
    params.AntiAlias = antialias;
    params.Bits = bits;
    params.Fullscreen = full;
    params.Stencilbuffer = stencil;
    params.Vsync = vsync;
    params.WindowSize = MU_DIM2DS(dim);
    params.DriverType = type;
    params.WindowId = handle;
    params.EventReceiver = new EventReceiver();
    return createDeviceEx(params);
}

void Device_SetWindowCaption(IntPtr device, M_STRING caption)
{
    GetDeviceFromIntPtr(device)->setWindowCaption(MU_WCHAR(caption));
}

IntPtr Device_GetSceneManager(IntPtr device)
{
    return GetDeviceFromIntPtr(device)->getSceneManager();
}

IntPtr Device_GetVideoDriver(IntPtr device)
{
    return GetDeviceFromIntPtr(device)->getVideoDriver();
}

bool Device_Run(IntPtr device)
{
    _FIX_BOOL_MARSHAL_BUG(GetDeviceFromIntPtr(device)->run());
}

void Device_Drop(IntPtr device)
{
    GetDeviceFromIntPtr(device)->drop();
}

void Device_Close(IntPtr device)
{
    GetDeviceFromIntPtr(device)->closeDevice();
}

IntPtr Device_GetCursorControl(IntPtr device)
{
    return  GetDeviceFromIntPtr(device)->getCursorControl();
}

IntPtr Device_GetFileSystem(IntPtr device)
{
    return  GetDeviceFromIntPtr(device)->getFileSystem();
}

IntPtr Device_GetGUIEnvironment(IntPtr device)
{
    return  GetDeviceFromIntPtr(device)->getGUIEnvironment();
}

IntPtr Device_GetTimer(IntPtr device)
{
    return  GetDeviceFromIntPtr(device)->getTimer();
}

IntPtr Device_GetVideoModeList(IntPtr device)
{
    return  GetDeviceFromIntPtr(device)->getVideoModeList();
}

M_STRING Device_GetVersion(IntPtr device)
{
    return  UM_STRING(GetDeviceFromIntPtr(device)->getVersion());
}

bool Device_IsWindowActive(IntPtr device)
{
    _FIX_BOOL_MARSHAL_BUG(GetDeviceFromIntPtr(device)->isWindowActive());
}

void Device_SetResizeable(IntPtr device, bool resizeable)
{
    GetDeviceFromIntPtr(device)->setResizable(resizeable);
}

void Device_SetCallback(IntPtr device, EVENTCALLBACK call)
{
    ((EventReceiver*)GetDeviceFromIntPtr(device)->getEventReceiver())->setCallback(call);
}



int VideoModeList_GetDesktopDepth(IntPtr videomodelist)
{
    return ((IVideoModeList*)videomodelist)->getDesktopDepth();
}

void VideoModeList_GetDesktopResolution(IntPtr videomodelist, M_DIM2DU res)
{
    UM_DIM2DU(((IVideoModeList*)videomodelist)->getDesktopResolution(), res);
}

int VideoModeList_GetVideoModeCount(IntPtr videomodelist)
{
    return ((IVideoModeList*)videomodelist)->getVideoModeCount();
}

int VideoModeList_GetVideoModeDepth(IntPtr videomodelist, int mode)
{
    return ((IVideoModeList*)videomodelist)->getVideoModeDepth(mode);
}

void VideoModeList_GetVideoModeResolution(IntPtr videomodelist, int mode, M_DIM2DU res)
{
    UM_DIM2DU(((IVideoModeList*)videomodelist)->getVideoModeResolution(mode), res);
}

void FileSystem_AddFolderFileArchive(IntPtr system,M_STRING folder, bool ignoreCase, bool ignorePaths)
{
    ((IFileSystem*)system)->addFolderFileArchive(folder, ignoreCase, ignorePaths);
}

void FileSystem_AddZipFileArchive(IntPtr system,M_STRING filename, bool ignoreCase, bool ignorePaths)
{
    ((IFileSystem*)system)->addZipFileArchive(filename, ignoreCase, ignorePaths);
}

bool FileSystem_ChangeWorkingDirectory(IntPtr system, M_STRING workingdirectory)
{
    _FIX_BOOL_MARSHAL_BUG(((IFileSystem*)system)->changeWorkingDirectoryTo(workingdirectory));
}

IntPtr FileSystem_GetFileList(IntPtr system)
{
    return ((IFileSystem*)system)->createFileList();
}

bool FileSystem_ExistsFile(IntPtr system, M_STRING filename)
{
    _FIX_BOOL_MARSHAL_BUG(((IFileSystem*)system)->existFile(filename));
}

M_STRING FileSystem_GetWorkingDirectory(IntPtr system)
{
    return UM_STRING(((IFileSystem*)system)->getWorkingDirectory().c_str());
}

IntPtr FileSystem_CreateAndWriteFile(IntPtr system, M_STRING filename, bool append)
{
    return ((IFileSystem*)system)->createAndWriteFile(filename, append);
}


IntPtr FileSystem_CreateMemoryReadFile(IntPtr system, IntPtr memory, int len, M_STRING fileName, bool deleteMemoryWhenDropped)
{
    return ((IFileSystem*)system)->createMemoryReadFile(memory, len, fileName, deleteMemoryWhenDropped);
}

void CursorControl_GetPosition(IntPtr cc, M_POS2DS pos)
{
    UM_POS2DS(((ICursorControl*)cc)->getPosition(), pos);
}

void CursorControl_GetRelativePosition(IntPtr cc, M_POS2DF pos)
{
    UM_POS2DF(((ICursorControl*)cc)->getRelativePosition(), pos);
}

bool CursorControl_IsVisible(IntPtr cc)
{
    _FIX_BOOL_MARSHAL_BUG(((ICursorControl*)cc)->isVisible());
}

void CursorControl_SetPosition(IntPtr cc, int X, int Y)
{
    ((ICursorControl*)cc)->setPosition(X, Y);
}

void CursorControl_SetPositionA(IntPtr cc, float X, float Y)
{
    ((ICursorControl*)cc)->setPosition(X, Y);
}

void CursorControl_SetVisible(IntPtr cc, bool visible)
{
    ((ICursorControl*)cc)->setVisible(visible);
}



unsigned int Timer_GetRealTime(IntPtr timer)
{
    return ((ITimer*)timer)->getRealTime();
}

float Timer_GetSpeed(IntPtr timer)
{
    return ((ITimer*)timer)->getSpeed();
}

unsigned int Timer_GetTime(IntPtr timer)
{
    return ((ITimer*)timer)->getTime();
}

bool Timer_IsStopped(IntPtr timer)
{
    _FIX_BOOL_MARSHAL_BUG(((ITimer*)timer)->isStopped());
}

void Timer_SetSpeed(IntPtr timer, float speed)
{
    ((ITimer*)timer)->setSpeed(speed);
}

void Timer_SetTime(IntPtr timer, unsigned int time)
{
    ((ITimer*)timer)->setTime(time);
}

void Timer_Start(IntPtr timer)
{
    ((ITimer*)timer)->start();
}

void Timer_Stop(IntPtr timer)
{
    ((ITimer*)timer)->stop();
}

void Timer_Tick(IntPtr timer)
{
    ((ITimer*)timer)->tick();
}



int FileList_GetFileCount(IntPtr list)
{
    return ((IFileList*)list)->getFileCount();
}

M_STRING FileList_GetFileName(IntPtr list, int index)
{
    return UM_STRING(((IFileList*)list)->getFileName(index).c_str());
}

M_STRING FileList_GetFullFileName(IntPtr list, int index)
{
    return (M_STRING)((IFileList*)list)->getFullFileName(index).c_str();
}

bool FileList_IsDirectory(IntPtr list, int index)
{
    _FIX_BOOL_MARSHAL_BUG(((IFileList*)list)->isDirectory(index));
}

IntPtr Device_GetLogger(IntPtr device)
{
    return ((IrrlichtDevice*)device)->getLogger();
}

ELOG_LEVEL Logger_GetLogLevel(IntPtr logger)
{
    return ((ILogger*)logger)->getLogLevel();
}

void Logger_Log(IntPtr logger, M_STRING text, ELOG_LEVEL lev)
{
    ((ILogger*)logger)->log(text, lev);
}

void Logger_LogA(IntPtr logger, M_STRING text, M_STRING hint, ELOG_LEVEL lev)
{
    ((ILogger*)logger)->log(text, hint, lev);
}

void Logger_SetLogLevel(IntPtr logger, ELOG_LEVEL level)
{
    ((ILogger*)logger)->setLogLevel(level);
}


