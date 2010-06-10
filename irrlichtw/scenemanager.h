#include "main.h"


extern "C"
{
    EXPORT IntPtr SceneManager_CreateNewSceneManager (IntPtr mgr, bool clone);
    EXPORT IntPtr SceneManager_GetMesh(IntPtr scenemanager, M_STRING meshname);
    EXPORT IntPtr SceneManager_GetMeshFromReadFile(IntPtr scenemanager, IntPtr readFile);
    EXPORT IntPtr SceneManager_GetMeshCache (IntPtr scenemanager);
    EXPORT IntPtr SceneManager_GetVideoDriver(IntPtr scenemanager);
    EXPORT IntPtr SceneManager_GetGUIEnv (IntPtr scenemanager);


    EXPORT IntPtr SceneManager_AddAnimatedMeshSceneNode(IntPtr scenemanager, IntPtr mesh, IntPtr parent, int id);
    EXPORT IntPtr SceneManager_AddBillboardSceneNode(IntPtr scenemanager, IntPtr parent, M_DIM2DF size, int id);
    EXPORT IntPtr SceneManager_AddCameraSceneNode(IntPtr scenemanager, IntPtr parent);
    EXPORT IntPtr SceneManager_AddCameraSceneNodeFPS(IntPtr scenemanager, IntPtr parent, float rotateS, float moveS, int id, bool novertical);
    EXPORT IntPtr SceneManager_AddCameraSceneNodeFPSA(IntPtr scenemanager, IntPtr parent, float rotateS, float moveS, int id, bool novertical, int *actionsmap, int *keymap, const int keymapsize);
    EXPORT IntPtr SceneManager_AddCameraSceneNodeMaya(IntPtr scenemanager, IntPtr parent, float rotateS, float zoomS, float transS, int id);
    EXPORT IntPtr SceneManager_AddCubeSceneNode(IntPtr scenemanager, float size, IntPtr parent, int id);
    EXPORT IntPtr SceneManager_AddDummyTransformationSceneNode(IntPtr scenemanager, IntPtr parent, int id);
    EXPORT IntPtr SceneManager_AddEmptySceneNode(IntPtr scenemanager, IntPtr parent, int id);
    EXPORT IntPtr SceneManager_AddHillPlaneMesh(IntPtr scenemanager, M_STRING name, M_DIM2DF tileSize, M_DIM2DS tileCount, float hillHeight, M_DIM2DF countHills, M_DIM2DF textureRepeatCount);
    EXPORT IntPtr SceneManager_AddLightSceneNode(IntPtr scenemanager, IntPtr parent, M_VECT3DF position, M_SCOLORF color, float radius, int id);
    EXPORT IntPtr SceneManager_AddMeshSceneNode(IntPtr scenemanager, IntPtr mesh, IntPtr parent, int id);
    EXPORT IntPtr SceneManager_AddOctTreeSceneNode(IntPtr scenemanager, IntPtr mesh, IntPtr parent, int id, int minimalPolysPerNode);
    EXPORT IntPtr SceneManager_AddOctTreeSceneNodeA(IntPtr scenemanager, IntPtr animatedmesh, IntPtr parent, int id, int minimalPolysPerNode);
    EXPORT IntPtr SceneManager_AddParticleSystemSceneNode(IntPtr scenemanager, bool defaultEmitter, IntPtr parent, int id);
    EXPORT IntPtr SceneManager_AddSkyBoxSceneNode(IntPtr scenemanager, IntPtr top, IntPtr bottom, IntPtr left, IntPtr right, IntPtr front, IntPtr back, IntPtr parent, int id);
    EXPORT IntPtr SceneManager_AddSkyDomeSceneNode(IntPtr scenemanager, IntPtr texture, unsigned int  horiRes, unsigned int  vertRes, double  texturePercentage, double  spherePercentage, IntPtr parent);
    EXPORT IntPtr SceneManager_AddSphereSceneNode(IntPtr scenemanager, float radius, int polycount, IntPtr parent);
    EXPORT IntPtr SceneManager_AddTerrainMesh(IntPtr scenemanager, M_STRING meshname, IntPtr texture, IntPtr heightmap, M_DIM2DF stretchSize, float maxHeight, M_DIM2DS defaultVertexBlockSize);
    EXPORT IntPtr SceneManager_AddTerrainSceneNode(IntPtr scenemanager, M_STRING heightMap, IntPtr parent, int id, M_VECT3DF position, M_VECT3DF rotation, M_VECT3DF scale, M_SCOLOR vertexColor,int maxLOD, E_TERRAIN_PATCH_SIZE patchSize, int smoothFactor);
    EXPORT IntPtr SceneManager_AddTextSceneNode(IntPtr scenemanager, IntPtr font, M_STRING text, M_SCOLOR color, IntPtr parent);
    EXPORT IntPtr SceneManager_AddTextSceneNode2(IntPtr scenemanager, IntPtr font, M_STRING text, IntPtr parent, M_DIM2DF size, M_VECT3DF pos, int ID, M_SCOLOR shade_top, M_SCOLOR shade_down);
    EXPORT IntPtr SceneManager_AddWaterSurfaceSceneNode(IntPtr scenemanager, IntPtr mesh, float waveHeight, float waveSpeed, float waveLength, IntPtr parent, int ID);

    EXPORT IntPtr SceneManager_GetRootSceneNode(IntPtr scenemanager);
    EXPORT IntPtr SceneManager_GetSceneNodeFromID(IntPtr scenemanager, int id);
    EXPORT IntPtr SceneManager_GetSceneNodeFromName(IntPtr scenemanager, M_STRING name);
    EXPORT IntPtr SceneManager_GetActiveCamera(IntPtr scenemanager);
    EXPORT void SceneManager_SetActiveCamera(IntPtr scenemanager, IntPtr camerascenenode);
    EXPORT void SceneManager_GetShadowColor(IntPtr scenemanager, M_SCOLOR color);
    EXPORT void SceneManager_SetShadowColor(IntPtr scenemanager, M_SCOLOR color);
    EXPORT void SceneManager_RegisterNodeForRendering(IntPtr scenemanager, IntPtr node, E_SCENE_NODE_RENDER_PASS pass);
    EXPORT void SceneManager_DrawAll(IntPtr scenemanager);

    EXPORT IntPtr SceneManager_CreateCollisionResponseAnimator(IntPtr scenemanager, IntPtr world, IntPtr sceneNode,M_VECT3DF ellipsoidRadius, M_VECT3DF gravityPerSecond,M_VECT3DF ellipsoidTranslation, float slidingValue);
    EXPORT IntPtr SceneManager_CreateDeleteAnimator(IntPtr scenemanager, unsigned int timeMS);
    EXPORT IntPtr SceneManager_CreateFlyCircleAnimator(IntPtr scenemanager, M_VECT3DF center, float radius, float speed);
    EXPORT IntPtr SceneManager_CreateFlyStraightAnimator(IntPtr scenemanager, M_VECT3DF startPoint, M_VECT3DF endPoint, unsigned int time, bool loop);
    EXPORT IntPtr SceneManager_CreateFollowSplineAnimator(IntPtr scenemanager, int starttime, float *Xs, float *Ys, float *Zs, int arraysize, float speed, float tightness);
    EXPORT IntPtr SceneManager_CreateMetaTriangleSelector(IntPtr scenemanager);
    EXPORT IntPtr SceneManager_CreateOctTreeTriangleSelector(IntPtr scenemanager, IntPtr mesh, IntPtr node, int minimalPolysPerNode);
    EXPORT IntPtr SceneManager_CreateRotationAnimator(IntPtr scenemanager, M_VECT3DF rotation);
    EXPORT IntPtr SceneManager_CreateTerrainTriangleSelector(IntPtr scenemanager, IntPtr node, int LOD);
    EXPORT IntPtr SceneManager_CreateTriangleSelector(IntPtr scenemanager, IntPtr mesh, IntPtr node);
    EXPORT IntPtr SceneManager_CreateTriangleSelectorFromBoundingBox(IntPtr scenemanager, IntPtr node);
    EXPORT IntPtr SceneManager_CreateTextureAnimator(IntPtr scenemanager, IntPtr *textures, int arraysize, int time, bool loop);

    EXPORT void SceneManager_SetAmbientLight(IntPtr scenemanager, M_SCOLORF ambient);
    EXPORT IntPtr SceneManager_GetSceneCollisionManager(IntPtr scenemanager);
    EXPORT IntPtr SceneManager_GetMeshManipulator(IntPtr scenemanager);
    EXPORT void SceneManager_AddToDeletionQueue(IntPtr scenemanager, IntPtr node);
    EXPORT bool SceneManager_PostEventFromUser (IntPtr mgr, IntPtr event);
    EXPORT void SceneManager_Clear(IntPtr scenemanager);
    EXPORT E_SCENE_NODE_RENDER_PASS SceneManager_GetSceneNodeRenderPass(IntPtr scenemanager);
    EXPORT void SceneManager_SaveScene(IntPtr scenemanager, M_STRING filename);
    EXPORT void SceneManager_LoadScene(IntPtr scenemanager, M_STRING filename);                 // Removed final parent parameter
    EXPORT IntPtr SceneManager_CreateMeshWriter(IntPtr scenemanager, EMESH_WRITER_TYPE type);
    EXPORT IntPtr SceneManager_GetSceneNodeFromType(IntPtr mgr, IntPtr snode, int type);
    
    // TODO:
    // EXPORT IntPtr    SceneManager_GetFileSystem(IntPtr scenemanager);
    // EXPORT IntPtr    SceneManager_AddTerrainSceneNode_FromReadFile(IntPtr scenemanager, IntPtr heightMap, IntPtr parent, int id, M_VECT3DF position, M_VECT3DF rotation, M_VECT3DF scale, M_SCOLOR vertexColor,int maxLOD, E_TERRAIN_PATCH_SIZE patchSize, int smoothFactor);
    // EXPORT IntPtr    SceneManager_AddQuake3SceneNode(IntPtr scenemanager, IntPtr meshBuffer, IntPtr shader, IntPtr parent, int id);
    // EXPORT IntPtr    SceneManager_AddArrowMesh(IntPtr scenemanager, IntPtr name, M_SCOLOR vtxColor0, M_SCOLOR vtxColor1, int tesselationCylinder, int tesselationCone, float height, float cylinderHeight, float width0, float width1);
	// EXPORT IntPtr    SceneManager_AddSphereMesh(IntPtr scenemanager, M_STRING name, float radius, int polyCountX, int polyCountY);
	// EXPORT IntPtr    SceneManager_AddVolumeLightMesh(IntPtr scenemanager, M_STRING name, int SubdivideU, int SubdivideV,M_SCOLOR FootColor, M_SCOLOR TailColor);
    // EXPORT void      SceneManager_GetSceneNodesFromType(IntPtr scenemanager, ESCENE_NODE_TYPE type, IntPtr* outNodes, IntPtr start);
    // EXPORT IntPtr    SceneManager_CreateTriangleSelector_AnimatedMesh(IntPtr scenemanager, IntPtr mesh, IntPtr node);
    // EXPORT void      SceneManager_AddExternalMeshLoader(IntPtr scenemanager, IntPtr externalLoader);
    // EXPORT IntPtr    SceneManager_GetDefaultSceneNodeFactory(IntPtr scenemanager);
    // EXPORT void      SceneManager_RegisterSceneNodeFactory(Intptr scenemanager, IntPtr factoryToAdd);
    // EXPORT int       SceneManagar_GetRegisteredSceneNodeFactoryCount(IntPtr scenemanager);
    // EXPORT IntPtr    SceneManager_GetSceneNodeFactory(IntPtr scenemanager, int index);
	// EXPORT IntPtr    SceneManager_GetDefaultSceneNodeAnimatorFactory(IntPtr scenemanager);
	// EXPORT void      SceneManager_RegisterSceneNodeAnimatorFactory(IntPtr scenemanager, IntPtr factoryToAdd);
	// EXPORT int       SceneManager_GetRegisteredSceneNodeAnimatorFactoryCount(IntPtr scenemanager);
	// EXPORT IntPtr    SceneManager_GetSceneNodeAnimatorFactory(IntPtr scenemanager, int index);
    // EXPORT M_SCOLORF SceneManager_GetAmbientLight(IntPtr scenemanager);
	// EXPORT M_STRING  SceneManager_GetSceneNodeTypeName(IntPtr scenemanager, ESCENE_NODE_TYPE type);
	// EXPORT M_STRING  SceneManager_GetAnimatorTypeName(IntPtr scenemanager, ESCENE_NODE_ANIMATOR_TYPE type);
	// EXPORT IntPtr    SceneManager_AddSceneNode(IntPtr scenemanager, M_STRING sceneNodeTypeName, IntPtr parent);
	// EXPORT IntPtr    SceneManager_CreateNewSceneManager(IntPtr scenemanager, bool cloneContent);
    // EXPORT void SceneManager_SaveScene(IntPtr scenemanager, IntPtr file, IntPtr userDataSerializer);
    // EXPORT void SceneManager_LoadScene(IntPtr scenemanager, IntPtr file, IntPtr userDataSerializer);
    // EXPORT IntPtr    SceneManager_CreateSkinnedMesh(IntPtr scenemanager);
    // EXPORT void      SceneManager_SetLightManager(IntPtr scenemanager, IntPtr lightManager);
	// EXPORT IntPtr    SceneManager_GetGeometryCreator(IntPtr scenemanager);
	// EXPORT bool      SceneManager_IsCulled(IntPtr scenemanager, IntPtr node);


    EXPORT bool SceneCollisionManager_GetCollisionPoint(IntPtr SCM, M_LINE3D ray, IntPtr selector, M_VECT3DF collisionpoint, M_TRIANGLE3DF outtriangle);
    EXPORT void SceneCollisionManager_GetCollisionResultPoint(IntPtr SCM, IntPtr selector, M_VECT3DF ellipsoidPosition, M_VECT3DF ellipsoidRadius, M_VECT3DF ellipsoidDirectionAndSpeed, M_TRIANGLE3DF outTriangle, bool *outFalling, float slidingSpeed, M_VECT3DF gravity, M_VECT3DF outCol);
    EXPORT void SceneCollisionManager_GetRayFromScreenCoordinates(IntPtr SCM, M_POS2DS pos, IntPtr camera, M_LINE3D outRay);
    EXPORT IntPtr SceneCollisionManager_GetSceneNodeFromCameraBB(IntPtr SCM, IntPtr camera, int idBitMask, bool noDebug);
    EXPORT IntPtr SceneCollisionManager_GetSceneNodeFromRayBB(IntPtr SCM, M_LINE3D ray, int idBitMask, bool noDebug);
    EXPORT IntPtr SceneCollisionManager_GetSceneNodeFromScreenCoordinatesBB(IntPtr SCM, M_POS2DS pos, int idBitMask, bool noDebug);
    EXPORT void SceneCollisionManager_GetScreenCoordinatesFrom3DPosition(IntPtr SCM, M_VECT3DF pos, IntPtr camera, M_POS2DS sc);

    // TODO:
   	// EXPORT IntPtr SceneManager_GetSceneNodeAndCollisionPointFromRay(IntPtr scenemanager, M_LINE3D ray, M_VECT3DF outCollisionPoint, M_TRIANGLE3DF outTriangle, int idBitMask, IntPtr collisionRootNode, bool noDebugObjects);


    EXPORT void MetaTriangleSelector_AddTriangleSelector(IntPtr mts, IntPtr toadd);
    EXPORT void MetaTriangleSelector_RemoveAllTriangleSelectors(IntPtr mts);
    EXPORT void MetaTriangleSelector_RemoveTriangleSelector(IntPtr mts, IntPtr toadd);
}
