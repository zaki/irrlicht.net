#include "scenenode.h"

ISceneNode *GetSceneNodeFromIntPtr(IntPtr scenenode)
{
    return (ISceneNode*)scenenode;
}

void SceneNode_AddAnimator(IntPtr scenenode, IntPtr animator)
{
    GetSceneNodeFromIntPtr(scenenode)->addAnimator((ISceneNodeAnimator*) animator);
}

void SceneNode_AddChild(IntPtr scenenode, IntPtr childnode)
{
    GetSceneNodeFromIntPtr(scenenode)->addChild(GetSceneNodeFromIntPtr(childnode));
}

void SceneNode_GetAbsolutePosition(IntPtr scenenode, M_VECT3DF toR)
{
    UM_VECT3DF(GetSceneNodeFromIntPtr(scenenode)->getAbsolutePosition(), toR);
}

void SceneNode_GetAbsoluteTransformation(IntPtr scenenode, M_MAT4 toR)
{
    return UM_MAT4(GetSceneNodeFromIntPtr(scenenode)->getAbsoluteTransformation(), toR);
}

E_CULLING_TYPE SceneNode_GetAutomaticCulling(IntPtr scenenode)
{
    return GetSceneNodeFromIntPtr(scenenode)->getAutomaticCulling();
}

void SceneNode_GetBoundingBox(IntPtr scenenode, M_BOX3D toR)
{
    UM_BOX3D(GetSceneNodeFromIntPtr(scenenode)->getBoundingBox(), toR);
}

void SceneNode_GetChildren(IntPtr scenenode, IntPtr *list)
{
    ISceneNode *node = GetSceneNodeFromIntPtr(scenenode);
    //u32 size = node->getChildren().getSize();
    core::list<ISceneNode*>::ConstIterator it = node->getChildren().begin();
    int c = 0;
    for (; it != node->getChildren().end(); ++it)
    {
        list[c] = (*it);
        c++;
    }
}

//This feature is used because .NET's managed arrays need to be initialized BEFORE
//They are sent to an Unmanaged code
unsigned int SceneNode_GetChildrenCount(IntPtr scenenode)
{
    return GetSceneNodeFromIntPtr(scenenode)->getChildren().getSize();
}

int SceneNode_GetID(IntPtr scenenode)
{
    return GetSceneNodeFromIntPtr(scenenode)->getID();
}

unsigned int SceneNode_GetMaterialCount(IntPtr scenenode)
{
    return GetSceneNodeFromIntPtr(scenenode)->getMaterialCount();
}

IntPtr SceneNode_GetMaterial(IntPtr scenenode, int i)
{
    return &GetSceneNodeFromIntPtr(scenenode)->getMaterial(i);
}

M_STRING SceneNode_GetName(IntPtr scenenode)
{
    return UM_STRING(GetSceneNodeFromIntPtr(scenenode)->getName());
}

IntPtr SceneNode_GetParent(IntPtr scenenode)
{
    return GetSceneNodeFromIntPtr(scenenode)->getParent();
}

void SceneNode_GetPosition(IntPtr scenenode, M_VECT3DF toR)
{
    UM_VECT3DF(GetSceneNodeFromIntPtr(scenenode)->getPosition(), toR);
}

void SceneNode_GetRelativeTransformation(IntPtr scenenode, M_MAT4 toR)
{
    UM_MAT4(GetSceneNodeFromIntPtr(scenenode)->getRelativeTransformation(), toR);
}

void SceneNode_GetRotation(IntPtr scenenode, M_VECT3DF toR)
{
    UM_VECT3DF(GetSceneNodeFromIntPtr(scenenode)->getRotation(), toR);
}

void SceneNode_GetScale(IntPtr scenenode, M_VECT3DF toR)
{
    UM_VECT3DF(GetSceneNodeFromIntPtr(scenenode)->getScale(), toR);
}

void SceneNode_GetTransformedBoundingBox(IntPtr scenenode, M_BOX3D toR)
{
    UM_BOX3D(GetSceneNodeFromIntPtr(scenenode)->getTransformedBoundingBox(), toR);
}

IntPtr SceneNode_GetTriangleSelector(IntPtr scenenode)
{
    return GetSceneNodeFromIntPtr(scenenode)->getTriangleSelector();
}

ESCENE_NODE_TYPE SceneNode_GetType(IntPtr scenenode)
{
    return GetSceneNodeFromIntPtr(scenenode)->getType();
}

irr::s32 SceneNode_GetDebugDataVisible(IntPtr scenenode)
{
    return (GetSceneNodeFromIntPtr(scenenode)->isDebugDataVisible());
}

bool SceneNode_IsDebugObject(IntPtr scenenode)
{
    _FIX_BOOL_MARSHAL_BUG(GetSceneNodeFromIntPtr(scenenode)->isDebugObject());
}

bool SceneNode_IsVisible(IntPtr scenenode)
{
    _FIX_BOOL_MARSHAL_BUG(GetSceneNodeFromIntPtr(scenenode)->isVisible());
}

void SceneNode_OnAnimate(IntPtr scenenode, unsigned int timeMS)
{
    GetSceneNodeFromIntPtr(scenenode)->OnAnimate(timeMS);
}

void SceneNode_OnRegisterSceneNode(IntPtr scenenode)
{
    GetSceneNodeFromIntPtr(scenenode)->OnRegisterSceneNode();
}

void SceneNode_Remove(IntPtr scenenode)
{
    GetSceneNodeFromIntPtr(scenenode)->remove();
}

void SceneNode_RemoveAll(IntPtr scenenode)
{
    GetSceneNodeFromIntPtr(scenenode)->removeAll();
}

void SceneNode_RemoveAnimator(IntPtr scenenode, IntPtr animator)
{
    GetSceneNodeFromIntPtr(scenenode)->removeAnimator((ISceneNodeAnimator*) animator);
}

void SceneNode_RemoveAnimators(IntPtr scenenode)
{
    GetSceneNodeFromIntPtr(scenenode)->removeAnimators();
}

bool SceneNode_RemoveChild(IntPtr scenenode, IntPtr childscenenode)
{
    _FIX_BOOL_MARSHAL_BUG(GetSceneNodeFromIntPtr(scenenode)->removeChild(GetSceneNodeFromIntPtr(childscenenode)));
}

void SceneNode_Render(IntPtr scenenode)
{
    GetSceneNodeFromIntPtr(scenenode)->render();
}

void SceneNode_SetAutomaticCulling(IntPtr scenenode, E_CULLING_TYPE enabled)
{
    GetSceneNodeFromIntPtr(scenenode)->setAutomaticCulling(enabled);
}

void SceneNode_SetDebugDataVisible(IntPtr scenenode, E_DEBUG_SCENE_TYPE visible)
{
    //GetSceneNodeFromIntPtr(scenenode)->setDebugDataVisible(visible ? EDS_FULL : EDS_OFF);
    GetSceneNodeFromIntPtr(scenenode)->setDebugDataVisible((irr::s32)visible);
}

void SceneNode_SetID(IntPtr scenenode, int id)
{
    GetSceneNodeFromIntPtr(scenenode)->setID(id);
}

void SceneNode_SetIsDebugObject(IntPtr scenenode, bool debugObject)
{
    GetSceneNodeFromIntPtr(scenenode)->setIsDebugObject(debugObject);
}

void SceneNode_SetMaterialFlag(IntPtr scenenode, E_MATERIAL_FLAG flag, bool newvalue)
{
    GetSceneNodeFromIntPtr(scenenode)->setMaterialFlag(flag, newvalue);
}

void SceneNode_SetMaterialTexture(IntPtr scenenode, int layer, IntPtr texture)
{
    GetSceneNodeFromIntPtr(scenenode)->setMaterialTexture(layer, (ITexture*) texture);
}

void SceneNode_SetMaterialType(IntPtr scenenode, E_MATERIAL_TYPE newtype)
{
    GetSceneNodeFromIntPtr(scenenode)->setMaterialType(newtype);
}

void SceneNode_SetName(IntPtr scenenode, M_STRING name)
{
    GetSceneNodeFromIntPtr(scenenode)->setName(name);
}

void SceneNode_SetParent(IntPtr scenenode, IntPtr parent)
{
    GetSceneNodeFromIntPtr(scenenode)->setParent(GetSceneNodeFromIntPtr(parent));
}

void SceneNode_SetPosition(IntPtr scenenode, M_VECT3DF pos)
{
    GetSceneNodeFromIntPtr(scenenode)->setPosition(MU_VECT3DF(pos));
}

void SceneNode_SetRotation(IntPtr scenenode, M_VECT3DF rot)
{
    GetSceneNodeFromIntPtr(scenenode)->setRotation(MU_VECT3DF(rot));
}

void SceneNode_SetScale(IntPtr scenenode, M_VECT3DF scale)
{
    GetSceneNodeFromIntPtr(scenenode)->setScale(MU_VECT3DF(scale));
}

void SceneNode_SetTriangleSelector(IntPtr scenenode, IntPtr triangleselector)
{
    GetSceneNodeFromIntPtr(scenenode)->setTriangleSelector((ITriangleSelector *) triangleselector);
}

void SceneNode_SetVisible(IntPtr scenenode, bool visible)
{
    GetSceneNodeFromIntPtr(scenenode)->setVisible(visible);
}

void SceneNode_UpdateAbsolutePosition(IntPtr scenenode)
{
    GetSceneNodeFromIntPtr(scenenode)->updateAbsolutePosition();
}

//Other scene nodes

void MeshSceneNode_SetMesh(IntPtr meshnode, IntPtr mesh)
{
    ((IMeshSceneNode*)meshnode)->setMesh((IMesh *)mesh);
}

IntPtr MeshSceneNode_GetMesh(IntPtr meshnode)
{
    return ((IMeshSceneNode*)meshnode)->getMesh();
}

void MeshSceneNode_SetReadOnlyMaterials(IntPtr meshnode, bool readonly)
{
    ((IMeshSceneNode*)meshnode)->setReadOnlyMaterials(readonly);
    ((IMeshSceneNode*)meshnode)->clone();
}

bool MeshSceneNode_IsReadOnlyMaterials(IntPtr meshnode)
{
    _FIX_BOOL_MARSHAL_BUG(((IMeshSceneNode*)meshnode)->isReadOnlyMaterials());
}

void MeshSceneNode_DropAllMeshBuffers(IntPtr meshnode)
{
    int mbcount = ((IMeshSceneNode*)meshnode)->getMesh()->getMeshBufferCount();
    for (int i=0;i<mbcount;i++)
    {
        ((IMeshSceneNode*)meshnode)->getMesh()->getMeshBuffer((unsigned int)mbcount)->drop();
    }
}

void BillboardSceneNode_GetSize(IntPtr billboard, M_DIM2DF dim)
{
    UM_DIM2DF(((IBillboardSceneNode*)billboard)->getSize(), dim);
}

void BillboardSceneNode_SetSize(IntPtr billboard, M_DIM2DF size)
{
    ((IBillboardSceneNode*)billboard)->setSize(MU_DIM2DF(size));
}


void TextSceneNode_SetText(IntPtr text, M_STRING ctext)
{
    ((ITextSceneNode*)text)->setText(MU_WCHAR(ctext));
}

void TextSceneNode_SetTextColor(IntPtr text, M_SCOLOR color)
{
    ((ITextSceneNode*)text)->setTextColor(MU_SCOLOR(color));
}

void TerrainSceneNode_GetBoundingBox(IntPtr terrain, int patchX, int patchZ, M_BOX3D box)
{
    UM_BOX3D(((ITerrainSceneNode*)terrain)->getBoundingBox(patchX, patchZ), box);
}

void TerrainSceneNode_GetBoundingBoxA(IntPtr terrain, M_BOX3D box)
{
    UM_BOX3D(((ITerrainSceneNode*)terrain)->getBoundingBox(), box);
}

int TerrainSceneNode_GetIndexCount(IntPtr terrain)
{
    return ((ITerrainSceneNode*)terrain)->getIndexCount();
}

IntPtr TerrainSceneNode_GetMesh(IntPtr terrain)
{
    return ((ITerrainSceneNode*)terrain)->getMesh();
}

float TerrainSceneNode_GetHeight(IntPtr terrain, float x, float z)
{
    return ((ITerrainSceneNode*)terrain)->getHeight(x, z);
}

void TerrainSceneNode_GetTerrainCenter(IntPtr terrain, M_VECT3DF center)
{
    UM_VECT3DF(((ITerrainSceneNode*)terrain)->getTerrainCenter(), center);
}

void TerrainSceneNode_OverrideLODDistance(IntPtr terrain, int lod, double newDistance)
{
    ((ITerrainSceneNode*)terrain)->overrideLODDistance(lod, newDistance);
}

void TerrainSceneNode_ScaleTexture(IntPtr terrain, float scale, float scale2)
{
    ((ITerrainSceneNode*)terrain)->scaleTexture(scale, scale2);
}

void TerrainSceneNode_SetCameraMovementDelta(IntPtr terrain, float delta)
{
    ((ITerrainSceneNode*)terrain)->setCameraMovementDelta(delta);
}

void TerrainSceneNode_SetCameraRotationDelta(IntPtr terrain, float delta)
{
    ((ITerrainSceneNode*)terrain)->setCameraRotationDelta(delta);
}

void TerrainSceneNode_SetDynamicSelectorUpdate(IntPtr terrain, bool bVal)
{
    ((ITerrainSceneNode*)terrain)->setDynamicSelectorUpdate(bVal);
}

void TerrainSceneNode_SetLODOfPatch(IntPtr terrain, int patchX, int patchZ, int LOD)
{
    ((ITerrainSceneNode*)terrain)->setLODOfPatch(patchX, patchZ, LOD);
}

void TerrainSceneNode_GetMeshBufferForLOD(IntPtr terrain, IDynamicMeshBuffer *mb, int lod)
{
    // TODO: FIX!  Commented out by Teravus.   SMeshBufferLightMap can't be turned into an IDynamicMeshBuffer
    ((ITerrainSceneNode*)terrain)->getMeshBufferForLOD((IDynamicMeshBuffer&)*mb, lod);
}

void LightSceneNode_GetLight(IntPtr light, M_SCOLORF ambient,
                             M_SCOLORF diffuse,
                             M_SCOLORF specular,
                             M_VECT3DF pos,
                             M_VECT3DF dir,
                             M_VECT3DF attenuation,
                             float *falloff,
                             float *innercone,
                             float *outercone,
                             float *radius,
                             bool *castshadows,
                             E_LIGHT_TYPE* type)
{
    SLight slight = ((ILightSceneNode*)light)->getLightData();
    UM_SCOLORF(slight.AmbientColor, ambient);
    UM_SCOLORF(slight.DiffuseColor, diffuse);
    UM_SCOLORF(slight.SpecularColor, specular);
    UM_VECT3DF(slight.Position, pos);
    UM_VECT3DF(slight.Direction, dir);
    UM_VECT3DF(slight.Attenuation, attenuation);
    *falloff = slight.Falloff;
    *innercone = slight.InnerCone;
    *outercone = slight.OuterCone;
    *radius = slight.Radius;
    *castshadows = slight.CastShadows;
    *type = slight.Type;
}

void LightSceneNode_SetLight(IntPtr light, M_SCOLORF ambient,
                             M_SCOLORF diffuse,
                             M_SCOLORF specular,
                             M_VECT3DF pos,
                             M_VECT3DF dir,
                             M_VECT3DF attenuation,
                             float falloff,
                             float innercone,
                             float outercone,
                             float radius,
                             bool castshadows,
                             E_LIGHT_TYPE type)
{
    SLight slight = ((ILightSceneNode*)light)->getLightData();
    slight.AmbientColor = MU_SCOLORF(ambient);
    slight.DiffuseColor = MU_SCOLORF(diffuse);
    slight.SpecularColor = MU_SCOLORF(specular);
    slight.Position = MU_VECT3DF(pos);
    slight.Direction = MU_VECT3DF(dir);
    slight.Attenuation = MU_VECT3DF (attenuation);
    slight.Falloff = falloff;
    slight.InnerCone = innercone;
    slight.OuterCone = outercone;
    slight.Radius = radius;
    slight.CastShadows = castshadows;
    slight.Type = type;
    ((ILightSceneNode*)light)->getLightData() = slight;
}

class ManagedAnimator : ISceneNodeAnimator
{
protected:
    ANIMATOR_AFFECT _call;
public:
    ManagedAnimator(ANIMATOR_AFFECT call)
    {
        _call = call;
    }

    virtual void animateNode(ISceneNode *node, unsigned int timeMS)
    {
        _call(this, node, timeMS);
    }
    virtual ISceneNodeAnimator* createClone(ISceneNode* node, ISceneManager* newManager=0)
    {
        return 0;
    }
};

IntPtr IAnimator_Create(ANIMATOR_AFFECT callback)
{
    return new ManagedAnimator(callback);
}


