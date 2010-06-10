#include "cd3d9driver.h"

CD3D9Driver* GetCD3D9DriverFromIntPtr(IntPtr videodriver)
{
    //return dynamic_cast<CD3D9Driver*>((IVideoDriver*)videodriver);
    return (CD3D9Driver*)((IVideoDriver*)videodriver);
}

IntPtr CD3D9Driver_GetD3DDevice9(IntPtr videodriver)
{
    CD3D9Driver* driver = GetCD3D9DriverFromIntPtr(videodriver);
    return driver == 0 ? NULL : (void*)driver->getExposedVideoData().D3D9.D3DDev9;
}
