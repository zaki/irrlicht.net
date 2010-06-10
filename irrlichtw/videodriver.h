#include "main.h"

extern "C"
{
    EXPORT bool             VideoDriver_BeginScene(IntPtr videodriver, bool backBuffer, bool zBuffer, M_SCOLOR color);
    EXPORT void             VideoDriver_EndScene(IntPtr videodriver);
    EXPORT void             VideoDriver_EndSceneA(IntPtr videodriver, IntPtr windowId, M_RECT viewRect);

    EXPORT IntPtr           VideoDriver_AddTexture(IntPtr videodriver, M_DIM2DU size, c8* name, ECOLOR_FORMAT fmt);
    EXPORT IntPtr           VideoDriver_AddTextureFromImage(IntPtr videodriver, c8 *name, IntPtr image);
    EXPORT void             VideoDriver_ClearZBuffer(IntPtr videodriver);
    EXPORT IntPtr           VideoDriver_CreateImageFromFile(IntPtr videodriver, M_STRING filename);
    EXPORT IntPtr           VideoDriver_CreateRenderTargetTexture(IntPtr videodriver, M_DIM2DU size);
    EXPORT IntPtr           VideoDriver_CreateScreenshot(IntPtr videodriver);
    EXPORT void             VideoDriver_DeleteAllDynamicLights(IntPtr videodriver);
    EXPORT void             VideoDriver_EnableClipPlane(IntPtr videodriver, int index, bool enable);
    EXPORT E_DRIVER_TYPE    VideoDriver_GetDriverType(IntPtr videodriver);
    EXPORT int              VideoDriver_GetFPS(IntPtr videodriver);
    EXPORT IntPtr           VideoDriver_GetGPUProgrammingServices(IntPtr videodriver);
    EXPORT int              VideoDriver_GetPrimitiveCountDrawn(IntPtr videodriver);
    EXPORT void             VideoDriver_GetScreenSize(IntPtr videodriver, M_DIM2DU size);
    EXPORT IntPtr           VideoDriver_GetTexture(IntPtr videodriver, c8 *name);
    EXPORT IntPtr           VideoDriver_GetTextureByIndex(IntPtr videodriver, int index);
    EXPORT int              VideoDriver_GetTextureCount(IntPtr videodriver);
    EXPORT bool             VideoDriver_GetTextureCreationFlag(IntPtr videodriver, E_TEXTURE_CREATION_FLAG flag);
    EXPORT void             VideoDriver_GetTransform(IntPtr videodriver, E_TRANSFORMATION_STATE state, M_MAT4 mat);
    EXPORT void             VideoDriver_GetViewPort(IntPtr videodriver, M_RECT viewport);
    EXPORT void             VideoDriver_MakeColorKeyTexture(IntPtr videodriver, IntPtr texture, M_POS2DS colorKeyPixelPos);
    EXPORT void             VideoDriver_MakeColorKeyTextureA(IntPtr videodriver, IntPtr texture, M_SCOLOR color);
    EXPORT void             VideoDriver_MakeNormalMapTexture(IntPtr videodriver, IntPtr texture, float amplitude);
    EXPORT bool             VideoDriver_QueryFeature(IntPtr videodriver, E_VIDEO_DRIVER_FEATURE feat);
    EXPORT void             VideoDriver_RemoveAllTextures(IntPtr videodriver);
    EXPORT void             VideoDriver_RemoveTexture(IntPtr videodriver, IntPtr texture);
    EXPORT void             VideoDriver_RenameTexture(IntPtr videodriver, IntPtr texture, c8* name);
    EXPORT bool             VideoDriver_SetClipPlane(IntPtr videodriver, int index, float* plane, bool enable);
    EXPORT void             VideoDriver_SetFog(IntPtr videodriver, M_SCOLOR color, E_FOG_TYPE linear, float start, float end, float density, bool pixel, bool range);
    EXPORT void             VideoDriver_SetMaterial(IntPtr videodriver, IntPtr material);
    EXPORT void             VideoDriver_SetRenderTarget(IntPtr videodriver, IntPtr texture, bool cBB, bool cZB, M_SCOLOR color);
    EXPORT void             VideoDriver_SetTextureFlag(IntPtr videodriver, E_TEXTURE_CREATION_FLAG flag, bool enabled);
    EXPORT void             VideoDriver_SetTransform(IntPtr videodriver, E_TRANSFORMATION_STATE state, M_MAT4 mat);
    EXPORT void             VideoDriver_SetViewPort(IntPtr videodriver, M_RECT viewport);
    EXPORT void             VideoDriver_WriteImageToFile(IntPtr videodriver, IntPtr image, M_STRING filename);


    EXPORT void VideoDriver_Draw2DImage(IntPtr videodriver, IntPtr texture, M_POS2DS destPos, M_RECT sourceRect, M_RECT clipRect, M_SCOLOR color, bool useAlphaChannelOfTexture);
    EXPORT void VideoDriver_Draw2DImageA(IntPtr videodriver, IntPtr texture, M_POS2DS destPos);
    EXPORT void VideoDriver_Draw2DImageB(IntPtr videodriver, IntPtr texture, M_POS2DS destPos, M_RECT sourceRect, M_SCOLOR color, bool useAlphaChannelOfTexture);
    EXPORT void VideoDriver_Draw2DImageC(IntPtr videodriver, IntPtr texture, M_RECT destPos, M_RECT sourceRect, M_RECT clipRect, M_SCOLOR color1, M_SCOLOR color2, M_SCOLOR color3, M_SCOLOR color4, bool useAlphaChannelOfTexture);
    EXPORT void VideoDriver_Draw2DImageD(IntPtr videodriver, IntPtr texture, M_RECT destPos, M_RECT sourceRect, M_SCOLOR color1, M_SCOLOR color2, M_SCOLOR color3, M_SCOLOR color4, bool useAlphaChannelOfTexture);
    EXPORT void VideoDriver_Draw2DLine(IntPtr videodriver, M_POS2DS start, M_POS2DS end, M_SCOLOR color);
    EXPORT void VideoDriver_Draw2DPolygon(IntPtr videodriver, M_POS2DS center, float radius, M_SCOLOR color, int vertexCount);
    EXPORT void VideoDriver_Draw2DRectangle(IntPtr videodriver, M_RECT pos, M_SCOLOR colorLeftUp, M_SCOLOR colorRightUp, M_SCOLOR colorLeftDown, M_SCOLOR colorRightDown);
    EXPORT void VideoDriver_Draw3DBox(IntPtr videodriver, M_BOX3D box, M_SCOLOR color);
    EXPORT void VideoDriver_Draw3DLine(IntPtr videodriver, M_VECT3DF start, M_VECT3DF end, M_SCOLOR color);
    EXPORT void VideoDriver_Draw3DTriangle(IntPtr videodriver, M_TRIANGLE3DF tri, M_SCOLOR color);
    EXPORT void VideoDriver_DrawIndexedTriangleList(IntPtr videodriver, IntPtr *vertices, int vertexCount, unsigned short *indexList, int triangleCount);
    EXPORT void VideoDriver_DrawIndexedTriangleListA(IntPtr videodriver, IntPtr *vertices, int vertexCount, unsigned short *indexList, int triangleCount);
    EXPORT void VideoDriver_DrawIndexedTriangleListT(IntPtr videodriver, IntPtr *vertices, int vertexCount, unsigned short *indexList, int triangleCount);
    EXPORT void VideoDriver_DrawIndexedTriangleFan(IntPtr videodriver, IntPtr *vertices, int vertexCount, unsigned short *indexList, int triangleCount);
    EXPORT void VideoDriver_DrawIndexedTriangleFanA(IntPtr videodriver, IntPtr *vertices, int vertexCount, unsigned short *indexList, int triangleCount);
    EXPORT void VideoDriver_DrawIndexedTriangleFanT(IntPtr videodriver, IntPtr *vertices, int vertexCount, unsigned short *indexList, int triangleCount);
    EXPORT void VideoDriver_DrawVertexPrimitiveList(IntPtr videodriver, IntPtr *vertices, int vertexCount, unsigned short *indexList, int triangleCount, E_VERTEX_TYPE vType, E_PRIMITIVE_TYPE pType, E_INDEX_TYPE iType);
    EXPORT void VideoDriver_DrawMeshBuffer(IntPtr videodriver, IntPtr meshbuffer);

    // TODO:
    // EXPORT void          VideoDriver_DisableFeature(IntPtr videodriver, E_VIDEO_DRIVER_FEATURE feature, bool flag);
	// EXPORT bool          VideoDriver_CheckDriverReset(IntPtr videodriver);
    // EXPORT int           VideoDriver_GetImageLoaderCount(IntPtr videodriver);
    // EXPORT IntPtr        VideoDriver_GetImageLoader(IntPtr videodriver, int n);
	// EXPORT int           VideoDriver_GetImageWriterCount(IntPtr videodriver);
	// EXPORT IntPtr        VideoDriver_GetImageWriter(IntPtr videodriver, int n);
    // EXPORT IntPtr        VideoDriver_GetTexture(IntPtr videodriver, IntPtr file);
    // EXPORT void          VideoDriver_RemoveHardwareBuffer(IntPtr videodriver, IntPtr mb);
	// EXPORT void          VideoDriver_RemoveAllHardwareBuffers(IntPtr videodriver);
    // EXPORT bool          VideoDriver_SetRenderTarget(IntPtr videodriver, E_RENDER_TARGET target, bool clearTarget=true, bool clearZBuffer, M_SCOLOR color);
    // EXPORT void          VideoDriver_Draw2DVertexPrimitiveList(IntPtr videodriver, IntPtr vertices, int vertexCount, IntPtr indexList, int primCount, E_VERTEX_TYPE vType, E_PRIMITIVE_TYPE pType, E_INDEX_TYPE iType);
    // EXPORT void          VideoDriver_Draw2DImageBatch(IntPtr videodriver, IntPtr texture, M_POS2DS pos, M_RECT sourceRects, int* indices, int kerningWidth, M_RECT clipRect, M_SCOLOR color, bool useAlphaChannelOfTexture);
	// EXPORT void          VideoDriver_Draw2DImageBatch(IntPtr videodriver, IntPtr texture, M_POS2DS positions, M_RECT sourceRects, M_RECT clipRect, M_SCOLOR color, bool useAlphaChannelOfTexture);
    // EXPORT void          VideoDriver_Draw2DRectangleOutline(IntPtr videodriver, M_RECT pos, M_SCOLOR color);
    // EXPORT void          VideoDriver_DrawPixel(IntPtr videodriver, int x, int y, M_SCOLOR color);
    // EXPORT void          VideoDriver_DrawStencilShadowVolume(IntPtr videodriver, M_VECT3DF triangles, int count, bool zfail);
	// EXPORT void          VideoDriver_DrawStencilShadow(IntPtr videodriver, bool clearStencilBuffer, M_SCOLOR leftUpEdge);
    // EXPORT ECOLOR_FORMAT VideoDriver_GetColorFormat(IntPtr videodriver);
    // EXPORT void          VideoDriver_GetCurrentRenderTargetSize(IntPtr videodriver, M_DIM2DS size);
    // EXPORT int           VideoDriver_AddDynamicLight(IntPtr videodriver, const SLight& light);     // TODO: Create structure for Lights
	// EXPORT int           VideoDriver_GetMaximalDynamicLightAmount(IntPtr videodriver);
	// EXPORT int           VideoDriver_GetDynamicLightCount(IntPtr videodriver);
	// EXPORT const SLight& VideoDriver_GetDynamicLight(IntPtr videodriver, int idx);  // TODO: Light structure
	// EXPORT void          VideoDriver_TurnLightOn(IntPtr videodriver, int lightIndex, bool turnOn);
	// EXPORT M_STRING      VideoDriver_GetName(IntPtr videodriver);
	// EXPORT void          VideoDriver_AddExternalImageLoader(IntPtr videodriver, IntPtr loader);
	// EXPORT void          VideoDriver_AddExternalImageWriter(IntPtr videodriver, IntPtr writer);
	// EXPORT int           VideoDriver_GetMaximalPrimitiveCount(IntPtr videodriver);
    // EXPORT IntPtr        VideoDriver_CreateImageFromFile(IntPtr videodriver, IntPtr file);
    // EXPORT bool          VideoDriver_WriteImageToFile(IntPtr videodriver, IntPtr image, IntPtr file, int param);
	// EXPORT IntPtr        VideoDriver_CreateImageFromData(IntPtr videodriver, ECOLOR_FORMAT format, M_DIM2DU size, IntPtr data, bool ownForeignMemory, bool deleteMemory);
	// EXPORT IntPtr        VideoDriver_CreateImage(IntPtr videodriver, ECOLOR_FORMAT format, M_DIM2DU size);
	// EXPORT IntPtr        VideoDriver_CreateImage(IntPtr videodriver, ECOLOR_FORMAT format, IntPtr imageToCopy);
	// EXPORT IntPtr        VideoDriver_CreateImage(IntPtr videodriver, IntPtr imageToCopy, M_POS2DS pos, M_DIM2DU size);
	// EXPORT IntPtr        VideoDriver_CreateImage(IntPtr videodriver, IntPtr texture, M_POS2DS pos, M_DIM2DU size);
	// EXPORT void          VideoDriver_OnResize(IntPtr videodriver, M_DIM2DU size);
	// EXPORT int           VideoDriver_AddMaterialRenderer(IntPtr videodriver, IntPtr renderer, M_STRING name);
	// EXPORT IntPtr        VideoDriver_GetMaterialRenderer(IntPtr videodriver, int idx);
	// EXPORT int           VideoDriver_GetMaterialRendererCount(IntPtr videodriver);
	// EXPORT M_STRING      VideoDriver_GetMaterialRendererName(IntPtr videodriver, int idx);
	// EXPORT void          VideoDriver_SetMaterialRendererName(IntPtr videodriver, int idx, M_STRING name);
	// EXPORT const SExposedVideoData& VideoDriver_GetExposedVideoData(IntPtr videodriver); // Create ExposedVideoData struct
    // EXPORT IntPtr        VideoDriver_GetMeshManipulator(IntPtr videodriver);
    // EXPORT IntPtr        VideoDriver_FindTexture(IntPtr videodriver, M_STRING filename);
    // EXPORT void          VideoDriver_SetMinHardwareBufferVertexCount(IntPtr videodriver, int count);
	// EXPORT SOverrideMaterial& VideoDriver_GetOverrideMaterial(IntPtr videodriver);       // Create OverrideMaterial stuct
	// EXPORT M_STRING      VideoDriver_GetVendorInfo(IntPtr videodriver);
	// EXPORT void          VideoDriver_SetAmbientLight(IntPtr videodriver, M_SCOLORF color);
	// EXPORT void          VideoDriver_SetAllowZWriteOnTransparent(IntPtr videodriver, bool flag);
}
