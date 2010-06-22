#include "scenemanager.h"
#include "CGUITTFont.h"

irr::scene::ISceneManager *GetSceneFromIntPtr(IntPtr object)
{
    return (irr::scene::ISceneManager*)object;
}

IntPtr SceneManager_AddAnimatedMeshSceneNode(IntPtr scenemanager, IntPtr mesh, IntPtr parent, int id)
{
    return GetSceneFromIntPtr(scenemanager)->addAnimatedMeshSceneNode((IAnimatedMesh*) mesh, (ISceneNode *)(parent), id);
}

IntPtr SceneManager_AddBillboardSceneNode(IntPtr scenemanager, IntPtr parent, M_DIM2DF size, int id)
{
    return GetSceneFromIntPtr(scenemanager)->addBillboardSceneNode((ISceneNode *)(parent), MU_DIM2DF(size), vector3df(0, 0, 0), id);
}

IntPtr SceneManager_AddCameraSceneNode(IntPtr scenemanager, IntPtr parent)
{
    return GetSceneFromIntPtr(scenemanager)->addCameraSceneNode((ISceneNode *)(parent));
}

IntPtr SceneManager_AddCameraSceneNodeFPS(IntPtr scenemanager, IntPtr parent, float rotateS, float moveS, int id, bool novertical)
{
    return GetSceneFromIntPtr(scenemanager)->addCameraSceneNodeFPS((ISceneNode *)(parent), rotateS, moveS, id, 0, 0, novertical);
}

IntPtr SceneManager_AddCameraSceneNodeFPSA(IntPtr scenemanager, IntPtr parent, float rotateS, float moveS, int id, bool novertical, int *actionsmap, int *keymap, const int keymapsize)
{
    SKeyMap map[EKA_COUNT];
    for(int i = 0; i < keymapsize; i++)
    {
        map[i].Action = (EKEY_ACTION)actionsmap[i];
        map[i].KeyCode = (EKEY_CODE)keymap[i];
    }
    return GetSceneFromIntPtr(scenemanager)->addCameraSceneNodeFPS((ISceneNode *)(parent), rotateS, moveS, id, map, keymapsize, novertical);
}

IntPtr SceneManager_AddCameraSceneNodeMaya(IntPtr scenemanager, IntPtr parent, float rotateS, float zoomS, float transS, int id)
{
    return GetSceneFromIntPtr(scenemanager)->addCameraSceneNodeMaya((ISceneNode *)(parent), rotateS, zoomS, transS, id);
}

IntPtr SceneManager_AddDummyTransformationSceneNode(IntPtr scenemanager, IntPtr parent, int id)
{
    return GetSceneFromIntPtr(scenemanager)->addDummyTransformationSceneNode((ISceneNode*)parent, id);
}

IntPtr SceneManager_AddEmptySceneNode(IntPtr scenemanager, IntPtr parent, int id)
{
    return GetSceneFromIntPtr(scenemanager)->addEmptySceneNode((ISceneNode*) parent, id);
}

IntPtr SceneManager_AddHillPlaneMesh(IntPtr scenemanager, M_STRING name, M_DIM2DF tileSize, M_DIM2US tileCount, float hillHeight, M_DIM2DF countHills, M_DIM2DF textureRepeatCount)
{
    return GetSceneFromIntPtr(scenemanager)->addHillPlaneMesh(name, MU_DIM2DF(tileSize), MU_DIM2US(tileCount), 0, hillHeight, MU_DIM2DF(countHills), MU_DIM2DF(textureRepeatCount));
}

IntPtr SceneManager_AddLightSceneNode(IntPtr scenemanager, IntPtr parent, M_VECT3DF position, M_SCOLORF color, float radius, int id)
{
    return GetSceneFromIntPtr(scenemanager)->addLightSceneNode((ISceneNode*) parent, MU_VECT3DF(position), MU_SCOLORF(color), radius, id);
}

IntPtr SceneManager_AddMeshSceneNode(IntPtr scenemanager, IntPtr mesh, IntPtr parent, int id)
{
    return GetSceneFromIntPtr(scenemanager)->addMeshSceneNode((IMesh *)mesh, (ISceneNode *) parent, id);
}

IntPtr SceneManager_AddOctTreeSceneNode(IntPtr scenemanager, IntPtr mesh, IntPtr parent, int id, int minimalPolysPerNode)
{
    return GetSceneFromIntPtr(scenemanager)->addOctreeSceneNode((IMesh *)mesh, (ISceneNode*) parent, id, minimalPolysPerNode);
}

IntPtr SceneManager_AddOctTreeSceneNodeA(IntPtr scenemanager, IntPtr animatedmesh, IntPtr parent, int id, int minimalPolysPerNode)
{
    return GetSceneFromIntPtr(scenemanager)->addOctreeSceneNode((IAnimatedMesh*)animatedmesh, (ISceneNode*)parent, id, minimalPolysPerNode);
}

IntPtr SceneManager_AddParticleSystemSceneNode(IntPtr scenemanager, bool defaultEmitter, IntPtr parent, int id)
{
    return GetSceneFromIntPtr(scenemanager)->addParticleSystemSceneNode(defaultEmitter, (ISceneNode*) parent, id);
}

IntPtr SceneManager_AddSkyBoxSceneNode(IntPtr scenemanager, IntPtr top, IntPtr bottom, IntPtr lef, IntPtr right, IntPtr front, IntPtr back, IntPtr parent, int id)
{
    return GetSceneFromIntPtr(scenemanager)->addSkyBoxSceneNode((ITexture*) top, (ITexture*)bottom, (ITexture*)lef, (ITexture*)right, (ITexture*) front, (ITexture*)back, (ISceneNode*)parent, id);
}

IntPtr SceneManager_AddTerrainMesh(IntPtr scenemanager, M_STRING meshname, IntPtr texture, IntPtr heightmap, M_DIM2DF stretchSize, float maxHeight, M_DIM2DS defaultVertexBlockSize)
{
    return GetSceneFromIntPtr(scenemanager)->addTerrainMesh(meshname, (IImage*)texture, (IImage*) heightmap, MU_DIM2DF(stretchSize), maxHeight, MU_DIM2DU(defaultVertexBlockSize));
}

IntPtr SceneManager_AddTerrainSceneNode(IntPtr scenemanager, M_STRING heightMap, IntPtr parent, int id, M_VECT3DF position, M_VECT3DF rotation, M_VECT3DF scale, M_SCOLOR vertexColor,int maxLOD, E_TERRAIN_PATCH_SIZE patchSize, int smoothFactor)
{

    return GetSceneFromIntPtr(scenemanager)->addTerrainSceneNode(heightMap, (ISceneNode*)parent, id, MU_VECT3DF(position), MU_VECT3DF(rotation), MU_VECT3DF(scale), MU_SCOLOR(vertexColor), maxLOD, patchSize, smoothFactor);
}

IntPtr SceneManager_AddCubeSceneNode(IntPtr scenemanager, float size, IntPtr parent, int id)
{
    return GetSceneFromIntPtr(scenemanager)->addCubeSceneNode(size, (ISceneNode*)parent, id);
}

IntPtr SceneManager_AddSkyDomeSceneNode(IntPtr scenemanager, IntPtr texture, unsigned int  horiRes, unsigned int  vertRes, double  texturePercentage, double  spherePercentage, double radius, IntPtr parent)
{
    return GetSceneFromIntPtr(scenemanager)->addSkyDomeSceneNode((ITexture*)texture, horiRes, vertRes, (irr::f32)texturePercentage, (irr::f32)spherePercentage, (irr::f32)radius, (ISceneNode*)parent);
}

IntPtr SceneManager_AddSphereSceneNode(IntPtr scenemanager, float radius, int polycount, IntPtr parent)
{
    return GetSceneFromIntPtr(scenemanager)->addSphereSceneNode(radius, polycount, (ISceneNode*)parent);
}

IntPtr SceneManager_AddTextSceneNode(IntPtr scenemanager, IntPtr font, M_STRING text, M_SCOLOR color, IntPtr parent)
{
    return GetSceneFromIntPtr(scenemanager)->addTextSceneNode((IGUIFont*) font, MU_WCHAR(text), MU_SCOLOR(color), (ISceneNode*) parent);
}

IntPtr SceneManager_AddTextSceneNode2(IntPtr scenemanager, IntPtr font, M_STRING text, IntPtr parent,  M_DIM2DF size, M_VECT3DF pos, int ID,
                                      M_SCOLOR shade_top, M_SCOLOR shade_down)
{
    if (((IGUIFont*)font)->getType() == EGFT_BITMAP)
    {
        return GetSceneFromIntPtr(scenemanager)->addBillboardTextSceneNode((IGUIFont *)font, MU_WCHAR(text), (ISceneNode *)parent, MU_DIM2DF(size), MU_VECT3DF(pos), ID, MU_SCOLOR(shade_top), MU_SCOLOR(shade_down));
    } else {
        return ((CGUITTFont*)font)->createBillboard(MU_WCHAR(text),
            MU_DIM2DF(size),
            (ISceneManager*)scenemanager,
            (ISceneNode*)parent,
            ID
            );

    }
}

IntPtr SceneManager_AddWaterSurfaceSceneNode(IntPtr scenemanager, IntPtr mesh, float waveHeight, float waveSpeed, float waveLength, IntPtr parent, int ID)
{
    return GetSceneFromIntPtr(scenemanager)->addWaterSurfaceSceneNode((IMesh*)mesh, waveHeight, waveSpeed, waveLength, (ISceneNode*)parent, ID);
}

void SceneManager_AddToDeletionQueue(IntPtr scenemanager, IntPtr node)
{
    GetSceneFromIntPtr(scenemanager)->addToDeletionQueue((ISceneNode*)node);
}


void SceneManager_Clear(IntPtr scenemanager)
{
    GetSceneFromIntPtr(scenemanager)->clear();
}

IntPtr SceneManager_GetGUIEnv (IntPtr scenemanager)
{
    return GetSceneFromIntPtr(scenemanager)->getGUIEnvironment();
}

IntPtr SceneManager_CreateCollisionResponseAnimator(IntPtr scenemanager, IntPtr world, IntPtr sceneNode,M_VECT3DF ellipsoidRadius, M_VECT3DF gravityPerSecond,M_VECT3DF ellipsoidTranslation, float slidingValue)
{
    return GetSceneFromIntPtr(scenemanager)->createCollisionResponseAnimator((ITriangleSelector*) world, (ISceneNode*) sceneNode, MU_VECT3DF(ellipsoidRadius), MU_VECT3DF(gravityPerSecond), MU_VECT3DF(ellipsoidTranslation), slidingValue);
}

IntPtr SceneManager_CreateDeleteAnimator(IntPtr scenemanager, unsigned int timeMS)
{
    return GetSceneFromIntPtr(scenemanager)->createDeleteAnimator(timeMS);
}

void SceneManager_RegisterNodeForRendering(IntPtr scenemanager, IntPtr node, E_SCENE_NODE_RENDER_PASS pass)
{
    GetSceneFromIntPtr(scenemanager)->registerNodeForRendering((ISceneNode*)node, pass);
}

IntPtr SceneManager_CreateFlyCircleAnimator(IntPtr scenemanager, M_VECT3DF center, float radius, float speed)
{
    return GetSceneFromIntPtr(scenemanager)->createFlyCircleAnimator(MU_VECT3DF(center), radius, speed);
}

IntPtr SceneManager_CreateFlyStraightAnimator(IntPtr scenemanager, M_VECT3DF startPoint, M_VECT3DF endPoint, unsigned int time, bool loop)
{
    return GetSceneFromIntPtr(scenemanager)->createFlyStraightAnimator(MU_VECT3DF(startPoint), MU_VECT3DF(endPoint), time, loop);
}

IntPtr SceneManager_CreateMetaTriangleSelector(IntPtr scenemanager)
{
    return GetSceneFromIntPtr(scenemanager)->createMetaTriangleSelector();
}

IntPtr SceneManager_CreateOctTreeTriangleSelector(IntPtr scenemanager, IntPtr mesh, IntPtr node, int minimalPolysPerNode)
{
    return GetSceneFromIntPtr(scenemanager)->createOctreeTriangleSelector((IMesh*)mesh, (ISceneNode*)node, minimalPolysPerNode);
}

IntPtr SceneManager_CreateRotationAnimator(IntPtr scenemanager, M_VECT3DF rotation)
{
    return GetSceneFromIntPtr(scenemanager)->createRotationAnimator(MU_VECT3DF(rotation));
}

IntPtr SceneManager_CreateTriangleSelector(IntPtr scenemanager,IntPtr mesh, IntPtr node)
{
    return GetSceneFromIntPtr(scenemanager)->createTriangleSelector((IMesh*)mesh, (ITerrainSceneNode*)node);
}

IntPtr SceneManager_CreateTerrainTriangleSelector(IntPtr scenemanager, IntPtr node, int LOD)
{
    return GetSceneFromIntPtr(scenemanager)->createTerrainTriangleSelector((ITerrainSceneNode*)node, LOD);
}

IntPtr SceneManager_CreateTriangleSelectorFromBoundingBox(IntPtr scenemanager, IntPtr node)
{
    return GetSceneFromIntPtr(scenemanager)->createTriangleSelectorFromBoundingBox((ISceneNode*)node);
}

IntPtr SceneManager_CreateFollowSplineAnimator(IntPtr scenemanager, int starttime, float *Xs, float *Ys, float *Zs, int arraysize, float speed, float tightness)
{
    array<vector3df> list;
    for(int i = 0; i < arraysize; i++)
        list.push_back(vector3df(Xs[i], Ys[i], Zs[i]));
    return GetSceneFromIntPtr(scenemanager)->createFollowSplineAnimator(starttime, list, speed, tightness);
}

IntPtr SceneManager_CreateTextureAnimator(IntPtr scenemanager, IntPtr *textures, int arraysize, int time, bool loop)
{
    array<ITexture*> texturelist;
    for(int i = 0; i < arraysize; i++)
        texturelist.push_back((ITexture*)textures[i]);
    return GetSceneFromIntPtr(scenemanager)->createTextureAnimator(texturelist, time, loop);
}

void SceneManager_DrawAll(IntPtr scenemanager)
{
    GetSceneFromIntPtr(scenemanager)->drawAll();
}


IntPtr SceneManager_GetActiveCamera(IntPtr scenemanager)
{
    return GetSceneFromIntPtr(scenemanager)->getActiveCamera();
}

IntPtr SceneManager_GetMesh(IntPtr scenemanager, M_STRING meshname)
{
    return GetSceneFromIntPtr(scenemanager)->getMesh(meshname);
}

IntPtr SceneManager_GetMeshFromReadFile(IntPtr scenemanager, IntPtr readFile)
{
    return GetSceneFromIntPtr(scenemanager)->getMesh((irr::io::IReadFile*)readFile);
}

IntPtr SceneManager_GetMeshManipulator(IntPtr scenemanager)
{
    return GetSceneFromIntPtr(scenemanager)->getMeshManipulator();
}

IntPtr SceneManager_GetSceneCollisionManager(IntPtr scenemanager)
{
    return GetSceneFromIntPtr(scenemanager)->getSceneCollisionManager();
}

IntPtr SceneManager_GetRootSceneNode(IntPtr scenemanager)
{
    return GetSceneFromIntPtr(scenemanager)->getRootSceneNode();
}

IntPtr SceneManager_GetSceneNodeFromID(IntPtr scenemanager, int id)
{
    return GetSceneFromIntPtr(scenemanager)->getSceneNodeFromId(id);
}

IntPtr SceneManager_GetSceneNodeFromName(IntPtr scenemanager, M_STRING name)
{
    return GetSceneFromIntPtr(scenemanager)->getSceneNodeFromName(name);
}

E_SCENE_NODE_RENDER_PASS SceneManager_GetSceneNodeRenderPass(IntPtr scenemanager)
{
    return GetSceneFromIntPtr(scenemanager)->getSceneNodeRenderPass();
}

void SceneManager_GetShadowColor(IntPtr scenemanager, M_SCOLOR toR)
{
    UM_SCOLOR(GetSceneFromIntPtr(scenemanager)->getShadowColor(), toR);
}

IntPtr SceneManager_GetVideoDriver(IntPtr scenemanager)
{
    return GetSceneFromIntPtr(scenemanager)->getVideoDriver();
}

void SceneManager_SetActiveCamera(IntPtr scenemanager, IntPtr camerascenenode)
{
    GetSceneFromIntPtr(scenemanager)->setActiveCamera((ICameraSceneNode*) camerascenenode);
}

void SceneManager_SetAmbientLight(IntPtr scenemanager, M_SCOLORF color)
{
    GetSceneFromIntPtr(scenemanager)->setAmbientLight(MU_SCOLORF(color));
}

void SceneManager_SetShadowColor(IntPtr scenemanager, M_SCOLOR color)
{
    GetSceneFromIntPtr(scenemanager)->setShadowColor(MU_SCOLOR(color));
}

void SceneManager_SaveScene(IntPtr scenemanager, M_STRING filename)
{
    GetSceneFromIntPtr(scenemanager)->saveScene(filename);
}

IntPtr SceneManager_CreateMeshWriter(IntPtr scenemanager, EMESH_WRITER_TYPE type)
{
    return GetSceneFromIntPtr(scenemanager)->createMeshWriter(type);
}


/* Mesh Cache */

IntPtr SceneManager_GetMeshCache (IntPtr scenemanager)
{
    return GetSceneFromIntPtr(scenemanager)->getMeshCache();
}


bool SceneCollisionManager_GetCollisionPoint(IntPtr SCM, M_LINE3D ray, IntPtr selector, M_VECT3DF collisionpoint, M_TRIANGLE3DF outtriangle)
{
    triangle3df outtri;
    vector3df outCol;
    ISceneNode* outNode;
    bool tor = ((ISceneCollisionManager*)SCM)->getCollisionPoint(MU_LINE3D(ray), ((ITriangleSelector*)selector), outCol, outtri, (const ISceneNode*&)outNode);
    UM_TRIANGLE3DF(outtri, outtriangle);
    UM_VECT3DF(outCol, collisionpoint);
    _FIX_BOOL_MARSHAL_BUG(tor);
}

void SceneCollisionManager_GetCollisionResultPoint(IntPtr SCM, IntPtr selector, M_VECT3DF ellipsoidPosition, M_VECT3DF ellipsoidRadius, M_VECT3DF ellipsoidDirectionAndSpeed, M_TRIANGLE3DF outTriangle, M_VECT3DF hitPosition, bool &outFalling, float slidingSpeed, M_VECT3DF gravity, M_VECT3DF outCol)
{
    irr::core::triangle3df outtri;
    irr::core::vector3df outhitpos;
    ISceneNode* outNode;
    UM_VECT3DF(((ISceneCollisionManager*)SCM)->getCollisionResultPosition(
        (ITriangleSelector*)selector,
        (const irr::core::vector3df&)MU_VECT3DF(ellipsoidPosition),
        (const irr::core::vector3df&)MU_VECT3DF(ellipsoidRadius),
        (const irr::core::vector3df&)MU_VECT3DF(ellipsoidDirectionAndSpeed),
        outtri,
        outhitpos,
        outFalling,
        (const ISceneNode*&)outNode,
        slidingSpeed,
        (const irr::core::vector3df&)MU_VECT3DF(gravity)),
        outCol);
}

void SceneCollisionManager_GetRayFromScreenCoordinates(IntPtr SCM, M_POS2DS pos, IntPtr camera, M_LINE3D outRay)
{
    UM_LINE3D(((ISceneCollisionManager*)SCM)->getRayFromScreenCoordinates(MU_POS2DS(pos), ((ICameraSceneNode*)camera)), outRay);
}

IntPtr SceneCollisionManager_GetSceneNodeFromCameraBB(IntPtr SCM, IntPtr camera, int idBitMask, bool noDebug)
{
    return ((ISceneCollisionManager*)SCM)->getSceneNodeFromCameraBB((ICameraSceneNode*)camera, idBitMask, noDebug);
}

IntPtr SceneCollisionManager_GetSceneNodeFromRayBB(IntPtr SCM, M_LINE3D ray, int idBitMask, bool noDebug)
{
    return ((ISceneCollisionManager*)SCM)->getSceneNodeFromRayBB(MU_LINE3D(ray), idBitMask, noDebug);
}

IntPtr SceneCollisionManager_GetSceneNodeFromScreenCoordinatesBB(IntPtr SCM, M_POS2DS pos, int idBitMask, bool noDebug)
{
    return ((ISceneCollisionManager*)SCM)->getSceneNodeFromScreenCoordinatesBB(MU_POS2DS(pos), idBitMask, noDebug);
}

void SceneCollisionManager_GetScreenCoordinatesFrom3DPosition(IntPtr SCM, M_VECT3DF pos, IntPtr camera, M_POS2DS sc)
{
    UM_POS2DS(((ISceneCollisionManager*)SCM)->getScreenCoordinatesFrom3DPosition(MU_VECT3DF(pos), (ICameraSceneNode*)camera), sc);
}


void MetaTriangleSelector_AddTriangleSelector(IntPtr mts, IntPtr toadd)
{
    ((IMetaTriangleSelector*)mts)->addTriangleSelector((ITriangleSelector*)toadd);
}

void MetaTriangleSelector_RemoveAllTriangleSelectors(IntPtr mts)
{
    ((IMetaTriangleSelector*)mts)->removeAllTriangleSelectors();
}

void MetaTriangleSelector_RemoveTriangleSelector(IntPtr mts, IntPtr toadd)
{
    ((IMetaTriangleSelector*)mts)->removeTriangleSelector((ITriangleSelector*)toadd);
}

IntPtr SceneManager_CreateNewSceneManager (IntPtr mgr, bool clone)
{
    return GetSceneFromIntPtr(mgr)->createNewSceneManager (clone);
}

bool SceneManager_PostEventFromUser (IntPtr mgr, IntPtr event)
{
    _FIX_BOOL_MARSHAL_BUG(GetSceneFromIntPtr(mgr)->postEventFromUser (*(SEvent*)event));
}

IntPtr SceneManager_GetSceneNodeFromType (IntPtr mgr, IntPtr snode, int type)
{
    return (GetSceneFromIntPtr(mgr)->getSceneNodeFromType((ESCENE_NODE_TYPE)type, (ISceneNode*)snode));
}
