#include "main.h"

extern "C"
{
    typedef bool (STDCALL EVENTCALLBACK)(const IntPtr);

    EXPORT IntPtr CreateDevice(E_DRIVER_TYPE type, M_DIM2DS dim, int bits, bool full, bool stencil, bool vsync, bool antialias);
    EXPORT IntPtr CreateDeviceA(E_DRIVER_TYPE type, M_DIM2DS dim, int bits, bool full, bool stencil, bool vsync, bool antialias, IntPtr handle);

    EXPORT bool     Device_Run(IntPtr device);
    EXPORT IntPtr   Device_GetVideoDriver(IntPtr device);
    EXPORT IntPtr   Device_GetFileSystem(IntPtr device);
    EXPORT IntPtr   Device_GetGUIEnvironment(IntPtr device);
    EXPORT IntPtr   Device_GetSceneManager(IntPtr device);
    EXPORT IntPtr   Device_GetCursorControl(IntPtr device);
    EXPORT IntPtr   Device_GetLogger(IntPtr device);
    EXPORT IntPtr   Device_GetVideoModeList(IntPtr device);
    EXPORT IntPtr   Device_GetTimer(IntPtr device);
    EXPORT void     Device_SetWindowCaption(IntPtr device, M_STRING caption);
    EXPORT bool     Device_IsWindowActive(IntPtr device);
    EXPORT void     Device_Close(IntPtr device);
    EXPORT M_STRING Device_GetVersion(IntPtr device);
    EXPORT void     Device_SetCallback(IntPtr device, EVENTCALLBACK);
    EXPORT void     Device_SetResizeable(IntPtr device, bool resizeable);

    // TODO:
    // EXPORT void Device_Yield(IntPtr device);
    // EXPORT void Device_Sleep(IntPtr device, int timeMs, bool pauseTimer);
    // EXPORT IntPtr Device_GetOSOperator(IntPtr device);
    // EXPORT bool Device_IsWindowFocused(IntPtr device);
    // EXPORT bool Device_IsWindowMinimized(IntPtr device);
    // EXPORT bool Device_IsFullscreen(IntPtr device);
    // EXPORT ECOLOR_FORMAT Device_GetColorFormat(IntPtr device);
    // EXPORT void Device_PostEventFromUser(IntPtr device, SEVENT event);
    // EXPORT void Device_SetInputReceivingSceneManager(IntPtr device, IntPtr sceneManager);
    // EXPORT void Device_MinimizeWindow(IntPtr device);
    // EXPORT void Device_MaximizeWindow(IntPtr device);
    // EXPORT void Device_RestoreWindow(IntPtr device);
    // EXPORT void Device_ActivateJoysticks(IntPtr device, SJoystickInfo*joystickInfo);
    // EXPORT void Device_SetGammaRamp(IntPtr device, float red, float green, float blue, float relativebrightness, float relativecontrast);
    // EXPORT void Device_GetGammaRamp(IntPtr device, float* red, float* green, float* blue, float* relativebrightness, float* relativecontrast);
    // EXPORT E_DEVICE_TYPE Device_GetType(IntPtr device);
    // EXPORT bool Device_IsDriverSupported(IntPtr device, E_DRIVER_TYPE driver);
    

    EXPORT int  VideoModeList_GetVideoModeCount(IntPtr videomodelist);
    EXPORT void VideoModeList_GetVideoModeResolution(IntPtr videomodelist, int mode, M_DIM2DU res);
    EXPORT int  VideoModeList_GetVideoModeDepth(IntPtr videomodelist, int mode);
    EXPORT void VideoModeList_GetDesktopResolution(IntPtr videomodelist, M_DIM2DU res);
    EXPORT int  VideoModeList_GetDesktopDepth(IntPtr videomodelist);

    // TODO: 
    // EXPORT void VideoModeList_GetVideoModeResolution(IntPtr videomodelist, M_DIM2DU minSize, M_DIM2DU maxSize, M_DIM2DU res);
    

    EXPORT IntPtr   FileSystem_CreateMemoryReadFile(IntPtr system, IntPtr memory, int len, M_STRING fileName, bool deleteMemoryWhenDropped); // note: returned IntPtr will be opaque to caller since we don't export IReadFile interface
    EXPORT IntPtr   FileSystem_CreateAndWriteFile(IntPtr system, M_STRING filename, bool append);
    EXPORT void     FileSystem_AddZipFileArchive(IntPtr system,M_STRING filename, bool ignoreCase, bool ignorePaths);
    EXPORT void     FileSystem_AddFolderFileArchive(IntPtr system, M_STRING folder, bool ignoreCase, bool ignorePaths);
    EXPORT M_STRING FileSystem_GetWorkingDirectory(IntPtr system);
    EXPORT bool     FileSystem_ChangeWorkingDirectory(IntPtr system, M_STRING workingdirectory);
    EXPORT bool     FileSystem_ExistsFile(IntPtr system, M_STRING filename);
    EXPORT IntPtr   FileSystem_GetFileList(IntPtr system);

    // TODO: 
    // EXPORT IntPtr    FileSystem_CreateAndOpenFile(IntPtr system, M_STRING filename);
    // EXPORT IntPtr    FileSystem_CreateLimitReadFile(IntPtr system, M_STRING filename, IntPtr alreadyOpenedFile, long pos, long areaSize);
    // EXPORT IntPtr    FileSystem_CreateMemoryWriteFile(IntPtr system, IntPtr memory, int len, M_STRING fileName, bool deleteMemoryWhenDropped); // note: returned IntPtr will be opaque to caller since we don't export IReadFile interface
    // EXPORT bool      FileSystem_AddFileArchive(IntPtr system, M_STRING filename, bool ignoreCase, bool ignorePaths, E_FILE_ARCHIVE_TYPE archiveType);
    // EXPORT IntPtr    FileSystem_AddArchiveLoader(IntPtr system, IntPtr loader);
    // EXPORT int       FileSystem_GetFileArchiveCount(IntPtr system);
    // EXPORT bool      FileSystem_RemoveFileArchive_ByIndex(IntPtr system, int index);
    // EXPORT bool      FileSystem_RemoveFileArchive_ByPath(IntPtr system, M_STRING filename);
    // EXPORT bool      FileSystem_MoveFileArchive(IntPtr system, int source, int relative);
    // EXPORT IntPtr    FileSystem_GetFileArchive(IntPtr system, int index);
    // EXPORT void      FileSystem_AddPakFileArchive(IntPtr system, M_STRING folder, bool ignoreCase, bool ignorePaths);
    // EXPORT M_STRING  FileSystem_GetAbsolutePath(IntPtr system, M_STRING filename);
    // EXPORT M_STRING  FileSystem_GetFileDir(IntPtr system, M_STRING filename);
    // EXPORT M_STRING  FileSystem_GetFileBaseName(IntPtr system, M_STRING filename);
    // EXPORT M_STRING  FileSystem_FlattenFilename(IntPtr system, M_STRING directory, M_STRING root);
    // EXPORT IntPtr    FileSystem_CreateFileList(IntPtr system);
    // EXPORT IntPtr    FileSystem_CreateEmptyFileList(IntPtr system, M_STRING path, bool ignoreCase, bool ignorePaths);
    // EXPORT EFileSystemType FileSystem_SetFileListSystem(IntPtr system, EFileSystemType listType);
    // EXPORT IntPtr    FileSystem_CreateXMLReader_FromName(IntPtr system, M_STRING filename);
    // EXPORT IntPtr    FileSystem_CreateXMLReader_FromFile(IntPtr system, IntPtr file);
    // EXPORT IntPtr    FileSystem_CreateXMLReaderUTF8_FromName(IntPtr system, M_STRING filename);
    // EXPORT IntPtr    FileSystem_CreateXMLReaderUTF8_FromFile(IntPtr system, IntPtr file);
    // EXPORT IntPtr    FileSystem_CreateXMLWriter_FromName(IntPtr system, M_STRING filename);
    // EXPORT IntPtr    FileSystem_CreateXMLWriter_FromFile(IntPtr system, IntPtr file);


    EXPORT void CursorControl_SetVisible(IntPtr cc, bool visible);
    EXPORT bool CursorControl_IsVisible(IntPtr cc);
    EXPORT void CursorControl_SetPosition(IntPtr cc, int X, int Y);
    EXPORT void CursorControl_SetPositionA(IntPtr cc, float X, float Y);
    EXPORT void CursorControl_GetPosition(IntPtr cc, M_POS2DS pos);
    EXPORT void CursorControl_GetRelativePosition(IntPtr cc, M_POS2DF pos);
    
    // TODO: 
    // EXPORT void CursorControl_SetReferenceRect(IntPtr cc, M_POS2DS rect);


    EXPORT unsigned int Timer_GetRealTime(IntPtr timer);
    EXPORT unsigned int Timer_GetTime(IntPtr timer);
    EXPORT void Timer_SetTime(IntPtr timer, unsigned int time);
    EXPORT void Timer_Start(IntPtr timer);
    EXPORT void Timer_Stop(IntPtr timer);
    EXPORT void Timer_Tick(IntPtr timer);
    EXPORT float Timer_GetSpeed(IntPtr timer);
    EXPORT void Timer_SetSpeed(IntPtr timer, float speed);
    EXPORT bool Timer_IsStopped(IntPtr timer);
    


    EXPORT int FileList_GetFileCount(IntPtr list);
    EXPORT M_STRING FileList_GetFileName(IntPtr list, int index);
    EXPORT M_STRING FileList_GetFullFileName(IntPtr list, int index);
    EXPORT bool FileList_IsDirectory(IntPtr list, int index);

    // TODO: 
    // EXPORT unsigned int FileList_GetFileSize(IntPtr list, int index);
    // EXPORT unsigned int FileList_GetID(IntPtr list, int index);
    // EXPORT int   FileList_FindFile(IntPtr list, M_STRING filename, bool isFolder)
    // EXPORT void  FileList_GetPath(IntPtr list, M_STRING path);
    // EXPORT int   FileList_AddItem(IntPtr list, M_STRING fullPath, unsigned int size, bool isDirectory, unsigned int id);
    // EXPORT void  FileList_Sort(IntPtr list);


    EXPORT ELOG_LEVEL Logger_GetLogLevel(IntPtr logger);
    EXPORT void Logger_SetLogLevel(IntPtr logger, ELOG_LEVEL level);
    EXPORT void Logger_Log(IntPtr logger, M_STRING text, ELOG_LEVEL lev);
    EXPORT void Logger_LogA(IntPtr logger, M_STRING text, M_STRING hint, ELOG_LEVEL lev);

    // TODO: 
    // EXPORT void Logger_LogW(IntPtr logger, wchar_t* text, ELOG_LEVEL lev);
    // EXPORT void Logger_LogWA(IntPtr logger, wchar_t* text, wchar_t* hint, ELOG_LEVEL lev);
}
