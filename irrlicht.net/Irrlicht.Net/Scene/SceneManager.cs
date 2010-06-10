using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Security;

namespace IrrlichtNETCP
{
    public partial class SceneManager : NativeElement
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="raw">An IntPtr</param>
        public SceneManager(IntPtr raw)
            : base(raw)
        {
        }

        ~SceneManager()
        {
            //lock (Elements) { if (Elements.ContainsKey(MeshManipulator.Raw)) { Elements.Remove(MeshManipulator.Raw); } }
        }

        /// <summary>
        /// Adds a simple animated mesh scene node to the scene
        /// </summary>
        /// <returns>An AnimatedMeshSceneNode </returns>
        /// <param name="mesh">The animated mesh of the node that can be obtained via GetMesh</param>
        public AnimatedMeshSceneNode AddAnimatedMeshSceneNode(AnimatedMesh mesh)
        {
            return (AnimatedMeshSceneNode)
                NativeElement.GetObject((SceneManager_AddAnimatedMeshSceneNode(_raw, mesh.Raw, IntPtr.Zero, -1)),
                                        typeof(AnimatedMeshSceneNode));
        }

        /// <summary>
        /// Adds a billboard (simple 2D texture which seems to be on a 3D box)
        /// </summary>
        /// <returns>The billboard</returns>
        /// <param name="parent">Parents from the node</param>
        /// <param name="size">Size of the billboard</param>
        /// <param name="id">ID (-1 for automatic ID assignation)</param>
        public BillboardSceneNode AddBillboardSceneNode(SceneNode parent, Dimension2Df size, int id)
        {
            IntPtr par = IntPtr.Zero;
            if (parent != null)
                par = parent.Raw;
            return (BillboardSceneNode)
                NativeElement.GetObject(SceneManager_AddBillboardSceneNode(_raw, par, size.ToUnmanaged(), id),
                                    typeof(BillboardSceneNode));
        }

        /// <summary>
        /// Adds a simple camera to the node
        /// </summary>
        /// <returns>The camera</returns>
        /// <param name="parent">The parents (null if no parent)</param>
        public CameraSceneNode AddCameraSceneNode(SceneNode parent)
        {
            IntPtr par = IntPtr.Zero;
            if (parent != null)
                par = parent.Raw;
            return (CameraSceneNode)
                NativeElement.GetObject(SceneManager_AddCameraSceneNode(_raw, par),
                                        typeof(CameraSceneNode));
        }

        /// <summary>
        /// Adds a FPS camera, look at controlled by mouse and movement by arrow keys
        /// </summary>
        /// <returns>The camera</returns>
        /// <param name="parent">Parent of the node</param>
        /// <param name="rotateSpeed">Rotation speed</param>
        /// <param name="moveSpeed">Movement speed</param>
        /// <param name="noVerticalMovement">Are vertical movements forbidden ?</param>
        public CameraSceneNode AddCameraSceneNodeFPS(SceneNode parent, float rotateSpeed, float moveSpeed, bool noVerticalMovement)
        {
            IntPtr par = IntPtr.Zero;
            if (parent != null)
                par = parent.Raw;
            return (CameraSceneNode)
                NativeElement.GetObject(SceneManager_AddCameraSceneNodeFPS(_raw, par, rotateSpeed, moveSpeed, -1, noVerticalMovement),
                                        typeof(CameraSceneNode));
        }

        /// <summary>
        /// Adds a FPS camera, look at controlled by mouse and movement by arrow keys
        /// </summary>
        /// <returns>The camera</returns>
        /// <param name="parent">Parent of the node</param>
        /// <param name="rotateSpeed">Rotation speed</param>
        /// <param name="moveSpeed">Movement speed</param>
        /// <param name="noVerticalMovement">Are vertical movements forbidden ?</param>
        /// <param name="map">KeyMap which defines all actions of the camera</param>
        public CameraSceneNode AddCameraSceneNodeFPS(SceneNode parent, float rotateSpeed, float moveSpeed, bool noVerticalMovement, KeyMap map)
        {
            IntPtr par = IntPtr.Zero;
            if (parent != null)
                par = parent.Raw;
            return (CameraSceneNode)
                NativeElement.GetObject(SceneManager_AddCameraSceneNodeFPSA(_raw, par, rotateSpeed, moveSpeed, -1, noVerticalMovement, map.Actions, map.Codes, map.Size),
                                        typeof(CameraSceneNode));
        }

        /// <summary>
        /// Adds a simple Maya camera scene node
        /// </summary>
        /// <returns>The camera</returns>
        /// <param name="parent">Parent from the node</param>
        /// <param name="rotateSpeed">Rotation speed</param>
        /// <param name="zoomSpeed">Zoom speed</param>
        /// <param name="transSpeed">Translation speed</param>
        /// <param name="id">ID of the node (-1 for an automatic assignation)</param>
        public CameraSceneNode AddCameraSceneNodeMaya(SceneNode parent, float rotateSpeed, float zoomSpeed, float transSpeed, int id)
        {
            IntPtr par = IntPtr.Zero;
            if (parent != null)
                par = parent.Raw;
            return (CameraSceneNode)
                NativeElement.GetObject(SceneManager_AddCameraSceneNodeMaya(_raw, par, rotateSpeed, zoomSpeed, transSpeed, id),
                                        typeof(CameraSceneNode));
        }

        /// <summary>
        /// Adds a dummy transformation scene node
        /// </summary>
        /// <returns>The node</returns>
        /// <param name="parent">Parent (null if no parent)</param>
        /// <param name="id">ID of the node (-1 for automatic assignation)</param>
        public SceneNode AddDummyTransformationSceneNode(SceneNode parent, int id)
        {
            IntPtr par = IntPtr.Zero;
            if (parent != null)
                par = parent.Raw;
            return (SceneNode)
                NativeElement.GetObject(SceneManager_AddDummyTransformationSceneNode(_raw, par, id),
                                        typeof(SceneNode));
        }

        /// <summary>
        /// Adds an empty scene node, not rendered and not displayed but which exists
        /// </summary>
        /// <returns>This quite useful scene node</returns>
        /// <param name="parent">Parent from the node</param>
        /// <param name="id">ID (-1 for automatic assignation)</param>
        public SceneNode AddEmptySceneNode(SceneNode parent, int id)
        {
            IntPtr par = IntPtr.Zero;
            if (parent != null)
                par = parent.Raw;
            return (SceneNode)
                NativeElement.GetObject(SceneManager_AddEmptySceneNode(_raw, par, id),
                                        typeof(SceneNode));
        }

        /// <summary>
        /// Creates a hill plane mesh (used for instance for any water)
        /// </summary>
        /// <returns>The mesh</returns>
        /// <param name="name">Name of this mesh</param>
        /// <param name="tileSize">Size of each tile from the mesh</param>
        /// <param name="tileCount">Number of tiles</param>
        /// <param name="hillHeight">Height of each hills</param>
        /// <param name="countHills">Number of hills</param>
        /// <param name="textureRepeatCount">Texture repeatition count</param>
        public AnimatedMesh AddHillPlaneMesh(string name, Dimension2Df tileSize, Dimension2D tileCount, float hillHeight, Dimension2Df countHills, Dimension2Df textureRepeatCount)
        {
            return (AnimatedMesh)
                NativeElement.GetObject(SceneManager_AddHillPlaneMesh(_raw, name, tileSize.ToUnmanaged(), tileCount.ToUnmanaged(), hillHeight, countHills.ToUnmanaged(), textureRepeatCount.ToUnmanaged()),
                                        typeof(AnimatedMesh));
        }

        /// <summary>
        /// Adds a light scene node to the scene
        /// </summary>
        /// <returns>The light</returns>
        /// <param name="parent">Parent from the node</param>
        /// <param name="position">Initial position of the light</param>
        /// <param name="color">Floating color of the light</param>
        /// <param name="radius">Radius of the light</param>
        /// <param name="id">ID (-1 for automatic assignation)</param>
        public LightSceneNode AddLightSceneNode(SceneNode parent, Vector3D position, Colorf color, float radius, int id)
        {
            IntPtr par = IntPtr.Zero;
            if (parent != null)
                par = parent.Raw;
            return (LightSceneNode)
                NativeElement.GetObject(SceneManager_AddLightSceneNode(_raw, par, position.ToUnmanaged(), color.ToUnmanaged(), radius, id),
                                        typeof(LightSceneNode));
        }

        /// <summary>
        /// Adds a basic and not-moving scene node based on a simple mesh
        /// </summary>
        /// <returns>Your scene node</returns>
        /// <param name="mesh">A static mesh often obtained via GetMesh(0)</param>
        /// <param name="parent">Parent of the node</param>
        /// <param name="id">ID of the node (-1 for automatic assignation)</param>
        public MeshSceneNode AddMeshSceneNode(Mesh mesh, SceneNode parent, int id)
        {
            IntPtr par = IntPtr.Zero;
            if (parent != null)
                par = parent.Raw;
            return (MeshSceneNode)
                NativeElement.GetObject(SceneManager_AddMeshSceneNode(_raw, mesh.Raw, par, id),
                                        typeof(MeshSceneNode));
        }

        /// <summary>
        /// Adds an oct tree scene node
        /// </summary>
        /// <returns>The oct tree</returns>
        /// <param name="mesh">The mesh it is based on</param>
        /// <param name="parent">Its parent</param>
        /// <param name="id">ID (-1 for automatic assign.)</param>
        /// <param name="minimalPolysPerNode">The minimal polys per node (ideal : 128)</param>
        public SceneNode AddOctTreeSceneNode(Mesh mesh, SceneNode parent, int id, int minimalPolysPerNode)
        {
            IntPtr par = IntPtr.Zero;
            if (parent != null)
                par = parent.Raw;
            return (SceneNode)
                NativeElement.GetObject(SceneManager_AddOctTreeSceneNode(_raw, mesh.Raw, par, id, minimalPolysPerNode),
                                        typeof(SceneNode));
        }

        /// <summary>
        /// Adds a scene node for rendering using an octtree to the scene graph
        /// </summary>
        /// <returns>The oct tree</returns>
        /// <param name="mesh">The mesh the oct tree is based on. If this animated mesh has more than one frame, the first one is used</param>
        /// <param name="parent">Its parent</param>
        /// <param name="id">ID of the node (-1 for automatic assign.)</param>
        /// <param name="minimalPolysPerNode">Specifies the minimal polygons per node. Idea = 128</param>
        public SceneNode AddOctTreeSceneNode(AnimatedMesh mesh, SceneNode parent, int id, int minimalPolysPerNode)
        {
            IntPtr par = IntPtr.Zero;
            if (parent != null)
                par = parent.Raw;
            return (SceneNode)
                NativeElement.GetObject(SceneManager_AddOctTreeSceneNodeA(_raw, mesh.Raw, par, id, minimalPolysPerNode),
                                        typeof(SceneNode));
        }

        /// <summary>
        /// Adds a simple particle scene node
        /// </summary>
        /// <returns>The particle scene node</returns>
        /// <param name="defaultEmitter">Creates a basic emitter. If disabled you'll need to use ParticleSystemSceneNode.Emitter</param>
        /// <param name="parent">A  SceneNode</param>
        /// <param name="id">An int</param>
        public ParticleSystemSceneNode AddParticleSystemSceneNode(bool defaultEmitter, SceneNode parent, int id)
        {
            IntPtr par = IntPtr.Zero;
            if (parent != null)
                par = parent.Raw;
            return (ParticleSystemSceneNode)
                NativeElement.GetObject(SceneManager_AddParticleSystemSceneNode(_raw, defaultEmitter, par, id),
                                        typeof(ParticleSystemSceneNode));
        }

        /// <summary>
        /// Adds a simple skybox. A skybox is a basic cube rendered before everything and used to simulate an external environment with only textures.
        /// </summary>
        /// <returns>The skybox scene node (it should NOT be used since the skybox may not be moved nor rotated)</returns>
        /// <param name="parent">Its parent (should be set to null)</param>
        /// <param name="textureList">List of 6 Textures that constitute the skybox, order : top, bottom, left, right, front, back</param>
        /// <param name="id">ID of the node, -1 for automatic assign.</param>
        public SceneNode AddSkyBoxSceneNode(SceneNode parent, Texture[] textureList, int id)
        {
            IntPtr par = IntPtr.Zero;
            if (parent != null)
                par = parent.Raw;
            IntPtr top, bottom, left, right, front, back;
            top = textureList[0].Raw;
            bottom = textureList[1].Raw;
            right = textureList[2].Raw;
            left = textureList[3].Raw;
            front = textureList[4].Raw;
            back = textureList[5].Raw;
            return (SceneNode)
                NativeElement.GetObject(SceneManager_AddSkyBoxSceneNode(_raw, top, bottom, left, right, front, back, par, id),
                                        typeof(SceneNode));
        }

        /// <summary>
        /// Adds a static terrain mesh
        /// </summary>
        /// <returns>The static mesh</returns>
        /// <param name="name">Name of this mesh</param>
        /// <param name="texture">Image of the texture. Please notice that it is an Image, not a Texture, and it is supposed to be hardware-created</param>
        /// <param name="heightmap">Image of the heigthmap</param>
        /// <param name="stretchSize">How big a pixel on the image is rendered on the terrain</param>
        /// <param name="maxHeight">Maximal height</param>
        /// <param name="defaultVertexBlockSize">Should be (64,64)</param>
        public Mesh AddTerrainMesh(string name, Image texture, Image heightmap, Dimension2D stretchSize, float maxHeight, Dimension2D defaultVertexBlockSize)
        {
            return (Mesh)
                NativeElement.GetObject(SceneManager_AddTerrainMesh(_raw, name, texture.Raw, heightmap.Raw, stretchSize.ToUnmanaged(), maxHeight, defaultVertexBlockSize.ToUnmanaged()),
                                        typeof(Mesh));
        }

        /// <summary>
        /// Adds a heightmap-based terrain on the scene
        /// </summary>
        /// <returns>The terrain node</returns>
        /// <param name="heightMap">Relative or non-relative path to the heightmap.</param>
        /// <param name="parent">Parent from the terrain</param>
        /// <param name="id">ID (-1 for automatic assign.)</param>
        /// <param name="position">Position of the node</param>
        /// <param name="rotation">Rotation of the node</param>
        /// <param name="scale">Scale of the node</param>
        /// <param name="vertexColor">Default color of all the vertices used if no texture is assigned to the node.</param>
        /// <param name="maxLOD">Maximal LOD, set 5 or change it ONLY IF YOU KNOW WHAT YOU ARE DOING</param>
        /// <param name="patchSize">PatchSize, should be 17 and you mustn't change it unless you know what you're doing</param>
        public TerrainSceneNode AddTerrainSceneNode(string heightMap, SceneNode parent, int id, Vector3D position, Vector3D rotation, Vector3D scale, Color vertexColor, int maxLOD, TerrainPatchSize patchSize, int smoothFactor)
        {
            IntPtr par = IntPtr.Zero;
            if (parent != null)
                par = parent.Raw;
            return (TerrainSceneNode)
                NativeElement.GetObject(SceneManager_AddTerrainSceneNode(_raw, heightMap, par, id, position.ToUnmanaged(), rotation.ToUnmanaged(), scale.ToUnmanaged(), vertexColor.ToUnmanaged(), maxLOD, patchSize, smoothFactor),
                                        typeof(TerrainSceneNode));
        }

        /// <summary>
        /// Adds a simple cube
        /// </summary>
        /// <returns>This cube scene node</returns>
        /// <param name="size">Size</param>
        /// <param name="parent">Parent</param>
        /// <param name="id">ID of the node (-1 for automatic assign.)</param>
        public SceneNode AddCubeSceneNode(float size, SceneNode parent, int id)
        {
            IntPtr par = IntPtr.Zero;
            if (parent != null)
                par = parent.Raw;
            return (SceneNode)
                NativeElement.GetObject(SceneManager_AddCubeSceneNode(_raw, size, par, id),
                                        typeof(SceneNode));
        }

        /// <summary>
        /// Adds a skydome scene node to the scene graph.
        /// A skydome is a large (half-) sphere with a panoramic texture on the inside and is drawn around the camera position.
        /// </summary>
        /// <param name="texture">Texture for the dome. </param>
        /// <param name="horiRes">Number of vertices of a horizontal layer of the sphere. </param>
        /// <param name="vertRes">Number of vertices of a vertical layer of the sphere. </param>
        /// <param name="texturePercentage">How much of the height of the texture is used. Should be between 0 and 1. </param>
        /// <param name="spherePercentage">How much of the sphere is drawn. Value should be between 0 and 2, where 1 is an exact half-sphere and 2 is a full sphere. </param>
        /// <param name="parent">Parent scene node of the dome. A dome usually has no parent, so this should be null. Note: If a parent is set, the dome will not change how it is drawn.</param>
        /// <returns>The scene node</returns>
        public SceneNode AddSkyDomeSceneNode(Texture texture, uint horiRes, uint vertRes, double texturePercentage, double spherePercentage, double radius, SceneNode parent)
        {
            IntPtr par = IntPtr.Zero;
            if (parent != null)
                par = parent.Raw;
            return (SceneNode)
                NativeElement.GetObject(SceneManager_AddSkyDomeSceneNode(_raw, texture.Raw, horiRes, vertRes, texturePercentage, spherePercentage, radius, par),
                                        typeof(SceneNode));
        }

        /// <summary>
        /// Adds a sphere scene node for test purposes to the scene.
        /// It is a simple sphere.
        /// </summary>
        /// <param name="radius">Radius of the sphere. </param>
        /// <param name="polycount">Polycount of the sphere. </param>
        /// <param name="parent">Parent of the scene node. Can be null if no parent. </param>
        /// <returns>Scene node of the sphere</returns>
        public SceneNode AddSphereSceneNode(float radius, int polycount, SceneNode parent)
        {
            IntPtr par = IntPtr.Zero;
            if (parent != null)
                par = parent.Raw;
            return (SceneNode)
                NativeElement.GetObject(SceneManager_AddSphereSceneNode(_raw, radius, polycount, par),
                                        typeof(SceneNode));
        }


        /// <summary>
        /// Adds a 3D rendered text scene node to the scene
        /// </summary>
        /// <returns>The Node</returns>
        /// <param name="font">Font</param>
        /// <param name="text">Text (can be changed later)</param>
        /// <param name="color">Color</param>
        /// <param name="parent">Its parent</param>
        public TextSceneNode AddTextSceneNode(GUIFont font, string text, Color color, SceneNode parent)
        {
            IntPtr par = IntPtr.Zero;
            if (parent != null)
                par = parent.Raw;
            return (TextSceneNode)
                NativeElement.GetObject(SceneManager_AddTextSceneNode(_raw, font.Raw, text, color.ToUnmanaged(), par),
                                        typeof(TextSceneNode));
        }

        /// <summary>
        /// Adds 3d TextSceneNode2. to view a Text in real 3D Space
        /// in fact it is a combination of Billboard and TextSceneNode
        /// </summary>
        /// <returns>The Node</returns>
        /// <param name="font">Font</param>
        /// <param name="text">Text (can be changed later)</param>
        /// <param name="shade_top">Color of the top shade</param>
        /// <param name="shade_down">Color of the bottom shade</param>
        /// <param name="parent">Its parent</param>
        public TextSceneNode AddBillboardTextSceneNode(GUIFont font, string text, SceneNode parent, Dimension2Df size, Vector3D position, int id, Color shade_top, Color shade_down)
        {
            IntPtr par = IntPtr.Zero;
            if (parent != null)
                par = parent.Raw;
            return (TextSceneNode)
                NativeElement.GetObject(SceneManager_AddTextSceneNode2(_raw, font.Raw, text, par, size.ToUnmanaged(), position.ToUnmanaged(),
                                                                id, shade_top.ToUnmanaged(), shade_down.ToUnmanaged()),
                                        typeof(TextSceneNode));
        }

        /// <summary>
        /// Registers a node for rendering it at a specific time.
        /// </summary>
        /// <param name="node">Node to register for drawing. Usually scene nodes would set 'this' as parameter here because they want to be drawn. </param>
        /// <param name="pass">Specifies when the mode wants to be drawn in relation to the other nodes. For example, if the node is a shadow, it usually wants to be drawn after all other nodes and will use Shadow for this.</param>
        public void RegisterNodeForRendering(SceneNode node, SceneNodeRenderPass pass)
        {
            SceneManager_RegisterNodeForRendering(_raw, node.Raw, pass);
        }

        /// <summary>
        /// Registers a node for rendering it at a specific time.
        /// </summary>
        /// <param name="node">Node to register for drawing. Usually scene nodes would set 'this' as parameter here because they want to be drawn. </param>
        public void RegisterNodeForRendering(SceneNode node)
        {
            RegisterNodeForRendering(node, SceneNodeRenderPass.Automatic);
        }

        /// <summary>
        /// Adds a node to the deletion queue (it will be deleted immediately when it is secure)
        /// </summary>
        /// <param name="node">A  SceneNode</param>
        public void AddToDeletionQueue(SceneNode node)
        {
            System.Diagnostics.Debug.WriteLine("Add to deletionqueue for: " + node.Raw + " Elements remaining: " + NativeElement.Elements.Count);
            RemoveFromElements(node);
            SceneManager_AddToDeletionQueue(_raw, node.Raw);
        }

        private void RemoveFromElements(SceneNode node)
        {
            if (NativeElement.Elements.ContainsKey(node.Raw))
            {
                NativeElement.Elements.Remove(node.Raw);
            }
            else
            {
                //throw new Exception("Element was stale!!!!");
            }

            foreach (SceneNode cnode in node.Children)
            {
                System.Diagnostics.Debug.WriteLine("Deleting child nodes for: " + node.Raw + " Elements remaining: " + NativeElement.Elements.Count);
                RemoveFromElements(cnode);
            }
        }

        /// <summary>
        /// Adds a water surface based on a hill mesh (use AddHillPlaneMesh). Looks good when material is TransparentReflection
        /// </summary>
        /// <returns>The water to surf on</returns>
        /// <param name="hillMesh">Hill mesh the water is based on</param>
        /// <param name="waveH">Height of waves</param>
        /// <param name="waveS">Speed of waves</param>
        /// <param name="waveL">Length of waves</param>
        /// <param name="parent">Parent of the node</param>
        /// <param name="id">ID (-1 for automatic assign.)</param>
        public SceneNode AddWaterSurfaceSceneNode(Mesh hillMesh, float waveH, float waveS, float waveL, SceneNode parent, int id)
        {
            IntPtr par = IntPtr.Zero;
            if (parent != null)
                par = parent.Raw;
            return (SceneNode)
                NativeElement.GetObject(SceneManager_AddWaterSurfaceSceneNode(_raw, hillMesh.Raw, waveH, waveS, waveL, par, id),
                                        typeof(SceneNode));
        }

        /// <summary>
        /// Creates a simple animator for collision detection
        /// </summary>
        /// <returns>An Animator</returns>
        /// <param name="world">"World", meaning the triangle selector of the terrain/map</param>
        /// <param name="node">Node. Notice that this node MUST BE THE ONE THE ANIMATOR IS ADDED</param>
        /// <param name="ellipsoidRadius">Ellipsoid radius. Usually it's the difference between the node's skybox's max edge and its center</param>
        /// <param name="gravityPerSecond">How much gravity (don't try (0, -100000, 0), even on Jupiter you wouldn't have such gravity)</param>
        /// <param name="ellipsoidTranslation">By default (0, 0, 0), meaning the center of the scene node. You can modify it if needed</param>
        /// <param name="slidingValue">Sliding value, usually 0.0005f</param>
        public Animator CreateCollisionResponseAnimator(TriangleSelector world, SceneNode node, Vector3D ellipsoidRadius, Vector3D gravityPerSecond, Vector3D ellipsoidTranslation, float slidingValue)
        {
            return (Animator)
                NativeElement.GetObject(SceneManager_CreateCollisionResponseAnimator(_raw, world.Raw, node.Raw, ellipsoidRadius.ToUnmanaged(), gravityPerSecond.ToUnmanaged(), ellipsoidTranslation.ToUnmanaged(), slidingValue),
                                        typeof(Animator));
        }

        /// <summary>
        /// Creates an animator that will delete the node after X miliseconds
        /// </summary>
        /// <returns>The animator</returns>
        /// <param name="timeMS">Number of miliseconds</param>
        public Animator CreateDeleteAnimator(uint timeMS)
        {
            return (Animator)
                NativeElement.GetObject(SceneManager_CreateDeleteAnimator(_raw, timeMS),
                                        typeof(Animator));
        }

        /// <summary>
        /// Creates an animator that will fly around a center
        /// </summary>
        /// <returns>An Animator</returns>
        /// <param name="center">Center</param>
        /// <param name="radius">Radius</param>
        /// <param name="speed">Speed</param>
        public Animator CreateFlyCircleAnimator(Vector3D center, float radius, float speed)
        {
            return (Animator)
                NativeElement.GetObject(SceneManager_CreateFlyCircleAnimator(_raw, center.ToUnmanaged(), radius, speed),
                                        typeof(Animator));
        }

        /// <summary>
        /// Creates an animator that will fly from one point to... another one !
        /// </summary>
        /// <returns>An Animator</returns>
        /// <param name="start">Start</param>
        /// <param name="end">End</param>
        /// <param name="time">Time needed</param>
        /// <param name="loop">May the movement be looped ?</param>
        public Animator CreateFlyStraightAnimator(Vector3D start, Vector3D end, uint time, bool loop)
        {
            return (Animator)
                NativeElement.GetObject(SceneManager_CreateFlyStraightAnimator(_raw, start.ToUnmanaged(), end.ToUnmanaged(), time, loop),
                                        typeof(Animator));
        }

        /// <summary>
        /// Creates an animator that will switch every [timePerFrame] miliseconds the textures of the node.
        /// </summary>
        /// <param name="textures">List of textures</param>
        /// <param name="timePerFrame">Time (miliseconds) between each switch</param>
        /// <param name="loop">Does the animation loop ?</param>
        /// <returns>An animator to be added with SceneNode.AddAnimator</returns>
        public Animator CreateTextureAnimator(Texture[] textures, int timePerFrame, bool loop)
        {
            IntPtr[] array = new IntPtr[textures.Length];
            for (int i = 0; i < textures.Length; i++)
                array[i] = textures[i].Raw;
            return (Animator)
                NativeElement.GetObject(SceneManager_CreateTextureAnimator(_raw, array, array.Length, timePerFrame, loop),
                                        typeof(Animator));
        }

        /// <summary>
        /// A meta triangle selector is nothing more than a collection of one or more triangle selectors providing together the interface of one triangle selector. In this way, collision tests can be done with different triangle soups in one pass.
        /// </summary>
        /// <returns>A TriangleSelector</returns>
        public MetaTriangleSelector CreateMetaTriangleSelector()
        {
            return (MetaTriangleSelector)
                NativeElement.GetObject(SceneManager_CreateMetaTriangleSelector(_raw),
                                        typeof(MetaTriangleSelector));
        }

        public void Clear()
        {
            SceneManager_Clear(_raw);
        }

        public Animator CreateFollowSplineAnimator(int startTime, Vector3D[] points, float speed, float tightness)
        {
            float[] Xs = new float[points.Length];
            float[] Ys = new float[points.Length];
            float[] Zs = new float[points.Length];
            for (int i = 0; i < points.Length; i++)
            {
                float[] array = points[i].ToUnmanaged();
                Xs[i] = array[0];
                Ys[i] = array[1];
                Zs[i] = array[2];
            }
            return (Animator)
                NativeElement.GetObject(SceneManager_CreateFollowSplineAnimator(_raw, startTime, Xs, Ys, Zs, points.Length, speed, tightness),
                                        typeof(Animator));
        }

        /// <summary>
        /// Creates an optimized collision detector based on OctTrees
        /// </summary>
        /// <returns>A TriangleSelector</returns>
        /// <param name="mesh">Mesh from your node</param>
        /// <param name="node">Node</param>
        /// <param name="minimalPolysPerNode">Specifies the minimal polygons contained a octree node. If a node gets less polys the this value, it will not be splitted into smaller nodes.</param>
        public TriangleSelector CreateOctTreeTriangleSelector(Mesh mesh, SceneNode node, int minimalPolysPerNode)
        {
            return (TriangleSelector)
                NativeElement.GetObject(SceneManager_CreateOctTreeTriangleSelector(_raw, mesh.Raw, node.Raw, minimalPolysPerNode),
                                        typeof(TriangleSelector));
        }

        /// <summary>
        /// Creates a simple animator that will rotate.
        /// </summary>
        /// <returns>An Animator</returns>
        /// <param name="rotation">Rotation</param>
        public Animator CreateRotationAnimator(Vector3D rotation)
        {
            return (Animator)
                NativeElement.GetObject(SceneManager_CreateRotationAnimator(_raw, rotation.ToUnmanaged()),
                                        typeof(Animator));
        }

        /// <summary>
        /// Creates an optimized-for-terrain triangle selector
        /// </summary>
        /// <returns>A TriangleSelector</returns>
        /// <param name="terrain">Terrain whose the mesh is used</param>
        /// <param name="LOD">Level of Detail, 0 is for the maximal</param>
        public TriangleSelector CreateTerrainTriangleSelector(TerrainSceneNode terrain, int LOD)
        {
            return (TriangleSelector)
                NativeElement.GetObject(SceneManager_CreateTerrainTriangleSelector(_raw, terrain.Raw, LOD),
                                        typeof(TriangleSelector));
        }

        /// <summary>
        /// Creates a basic triangle selector based on a mesh
        /// </summary>
        /// <returns>A TriangleSelector</returns>
        /// <param name="mesh">The MESH !</param>
        /// <param name="node">Scene node, you NEED TO ADD THIS SELECTOR WITH SceneNode.TriangleSelector !</param>
        public TriangleSelector CreateTriangleSelector(Mesh mesh, SceneNode node)
        {
            return (TriangleSelector)
                NativeElement.GetObject(SceneManager_CreateTriangleSelector(_raw, mesh.Raw, node.Raw),
                                        typeof(TriangleSelector));
        }

        /// <summary>
        /// Creates the basic boundingbox-based triangle selector. Useful for a basic collision detection that doesn't need polygon precision
        /// </summary>
        /// <returns>A TriangleSelector</returns>
        /// <param name="node">The node it is taken from</param>
        public TriangleSelector CreateTriangleSelectorFromBoundingBox(SceneNode node)
        {
            return (TriangleSelector)
                NativeElement.GetObject(SceneManager_CreateTriangleSelectorFromBoundingBox(_raw, node.Raw),
                                        typeof(TriangleSelector));
        }

        /// <summary>
        /// Draws the whole scene. MUST be called between Driver.BeginScene and Driver.EndScene
        /// </summary>
        public void DrawAll()
        {
            SceneManager_DrawAll(_raw);
        }

        /// <summary>
        /// Retrieves the mesh from a file
        /// </summary>
        /// <returns>The mesh.</returns>
        /// <param name="name">Path to the mesh file.</param>
        public AnimatedMesh GetMesh(string name)
        {
            return (AnimatedMesh)
                NativeElement.GetObject(SceneManager_GetMesh(_raw, name),
                                        typeof(AnimatedMesh));
        }

        /// <summary>
        /// Retrieves the mesh from an IReadFile interface (can also be in-memory)
        /// </summary>
        /// <returns>The mesh.</returns>
        /// <param name="name">The (opaque) IReadFile pointer.</param>
        public AnimatedMesh GetMeshFromReadFile(IntPtr readFile)
        {
            return (AnimatedMesh)
                NativeElement.GetObject(SceneManager_GetMeshFromReadFile(_raw, readFile),
                                        typeof(AnimatedMesh));
        }

        /// <summary>
        /// Retrieves a Scene node by id.
        /// </summary>
        /// <returns>The Scene Node.</returns>
        /// <param name="id">The ID of the node.</param>
        public SceneNode GetSceneNodeFromID(int id)
        {
            return (SceneNode)
                NativeElement.GetObject(SceneManager_GetSceneNodeFromID(_raw, id),
                                        typeof(SceneNode));
        }

        /// <summary>
        /// Retrieves a scene node from its name.
        /// </summary>
        /// <returns>The node</returns>
        /// <param name="name">The name of the node</param>
        public SceneNode GetSceneNodeFromName(string name)
        {
            return (SceneNode)
                NativeElement.GetObject(SceneManager_GetSceneNodeFromName(_raw, name),
                                        typeof(SceneNode));
        }

        /// <summary>
        /// Returns the first scene node with the specified type.
        /// </summary>
        /// <param name="type">
        /// A SceneNodeType used for searching <see cref="SceneNodeType"/>
        /// </param>
        /// <param name="start">
        /// A first scene node searching should start from <see cref="SceneNode"/>
        /// </param>
        /// <returns>
        /// A closest scenenode if any <see cref="SceneNode"/>
        /// </returns>
        public SceneNode GetSceneNodeFromType(SceneNodeType type, SceneNode start)
        {
            return (SceneNode)
                NativeElement.GetObject(SceneManager_GetSceneNodeFromType(_raw,
                                                                          start == null ?
                                                                          IntPtr.Zero :
                                                                          start.Raw,
                                                                          (int)type),
                                        typeof(SceneNode));
        }

        /// <summary>
        /// Saves the current scene into a file.
        /// </summary>
        /// <param name="filename">File where the scene is saved into. </param>
        public void SaveScene(string filename)
        {
            SceneManager_SaveScene(_raw, filename);
        }

        public void SetAmbientLight(Colorf color)
        {

            SceneManager_SetAmbientLight(_raw, color.ToUnmanaged());
        }

        /// <summary>
        /// Loads a scene. Note that the current scene is not cleared before.
        /// </summary>
        /// <param name="filename">File where the scene is going to be saved into.</param>
        public void LoadScene(string filename)
        {
            SceneManager_LoadScene(_raw, filename, IntPtr.Zero);
        }

        /// <summary>
        /// Loads a scene. Note that the current scene is not cleared before.
        /// </summary>
        /// <param name="filename">File where the scene is going to be saved into.</param>
        public void LoadScene(string filename, SceneNode parent)
        {
            SceneManager_LoadScene(_raw, filename, parent.Raw);
        }

        public MeshWriter CreateMeshWriter(MeshWriterType type)
        {
            return (MeshWriter)
                NativeElement.GetObject(SceneManager_CreateMeshWriter(_raw, type),
                    typeof(MeshWriter));
        }

        /// <summary>
        /// Gets or sets the current active camera
        /// </summary>
        public CameraSceneNode ActiveCamera
        {
            get
            {
                return (CameraSceneNode)
                    NativeElement.GetObject(SceneManager_GetActiveCamera(_raw),
                                            typeof(CameraSceneNode));
            }
            set
            {
                SceneManager_SetActiveCamera(_raw, value.Raw);
            }
        }

        /// <summary>
        /// Gets an item for easy manipulating/getting informations on a mesh
        /// </summary>
        public MeshManipulator MeshManipulator
        {
            get
            {
                return (MeshManipulator)
                    NativeElement.GetObject(SceneManager_GetMeshManipulator(_raw),
                                            typeof(MeshManipulator));
            }
        }

        /// <summary>
        /// Gets an object used to get informations on collisions
        /// </summary>
        public SceneCollisionManager CollisionManager
        {
            get
            {
                return (SceneCollisionManager)
                    NativeElement.GetObject(SceneManager_GetSceneCollisionManager(_raw),
                                            typeof(SceneCollisionManager));
            }
        }

        /// <summary>
        /// Gets or sets the shadow color (default must be something like (100, 100, 100))
        /// </summary>
        public Color ShadowColor
        {
            get
            {
                int[] color = new int[4];
                SceneManager_GetShadowColor(_raw, color);
                return Color.FromUnmanaged(color);
            }
            set
            {
                SceneManager_SetShadowColor(_raw, value.ToUnmanaged());
            }
        }

        /// <summary>
        /// Gets the current scene node render pass. Generally useless.
        /// </summary>
        public SceneNodeRenderPass SceneNodeRenderPass
        {
            get
            {
                return SceneManager_GetSceneNodeRenderPass(_raw);
            }
        }



        /// <summary>
        /// Gets the current video driver.
        /// </summary>
        public VideoDriver VideoDriver
        {
            get
            {
                return (VideoDriver)
                    NativeElement.GetObject(SceneManager_GetVideoDriver(_raw),
                                            typeof(VideoDriver));
            }
        }

        /// <summary>
        /// Gets the root scene node. And empty node with position = rotation = (0, 0, 0) and scale = (1, 1, 1)
        /// Moreover, all node that do not have any parent is a child from the the root scene node.
        /// </summary>
        public SceneNode RootSceneNode
        {
            get
            {
                return (SceneNode)
                    NativeElement.GetObject(SceneManager_GetRootSceneNode(_raw),
                                            typeof(SceneNode));
            }
        }

        /// <summary>
        /// Creates a new scene manager.
        /// </summary>
        /// <param name="copycontent">
        /// Should the content to be copied to the new location,
        /// or keeped as a reference <see cref="System.Boolean"/>
        /// </param>
        /// <returns>
        /// A new SceneManager object <see cref="SceneManager"/>
        /// </returns>
        public SceneManager CreateNewSceneManager(bool copycontent)
        {
            return (SceneManager)NativeElement.GetObject(SceneManager_CreateNewSceneManager(_raw, copycontent),
                                                         typeof(SceneManager));
        }

        /// <summary>
        /// Posts an input event to the environment. Usefull for new created SceneManagers
        /// </summary>
        /// <param name="ev">
        /// An event struct from the EventReceiver <see cref="Event"/>
        /// </param>
        /// <returns>
        /// A result of the scenemanager's internal routine <see cref="System.Boolean"/>
        /// </returns>
        public bool PostEventFromUser(Event ev)
        {
            if (ev == null) return false;
            return SceneManager_PostEventFromUser(_raw, ev.Raw);
        }

        /// <value>
        /// Returns an interface to the mesh cache which is shared beween all existing scene managers.
        /// </value>
        public MeshCache MeshCache
        {
            get
            {
                return (MeshCache)
                    NativeElement.GetObject(SceneManager_GetMeshCache(_raw),
                                      typeof(MeshCache));
            }
        }

        public GUIEnvironment GUIEnvironment
        {
            get
            {
                return (GUIEnvironment)
                    NativeElement.GetObject(SceneManager_GetGUIEnv(_raw),
                                      typeof(GUIEnvironment));
            }
        }

        //Please DO NOT change any of these name, they're copy-pasted from the C/C++
        //source code AND NEEDS TO BE.
        #region .NET Wrapper Native Code
        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr SceneManager_AddAnimatedMeshSceneNode(IntPtr scenemanager, IntPtr mesh, IntPtr parent, int id);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr SceneManager_AddBillboardSceneNode(IntPtr scenemanager, IntPtr parent, float[] size, int id);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr SceneManager_AddCameraSceneNode(IntPtr scenemanager, IntPtr parent);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr SceneManager_AddCameraSceneNodeFPS(IntPtr scenemanager, IntPtr parent, float rotateS, float moveS, int id, bool novertical); //TODO: Keymapping

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr SceneManager_AddCameraSceneNodeFPSA(IntPtr scenemanager, IntPtr parent, float rotateS, float moveS, int id, bool novertical, int[] actionsmap, int[] keymap, int keymapsize);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr SceneManager_AddCameraSceneNodeMaya(IntPtr scenemanager, IntPtr parent, float rotateS, float zoomS, float transS, int id);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr SceneManager_AddDummyTransformationSceneNode(IntPtr scenemanager, IntPtr parent, int id);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr SceneManager_AddEmptySceneNode(IntPtr scenemanager, IntPtr parent, int id);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr SceneManager_AddHillPlaneMesh(IntPtr scenemanager, string name, float[] tileSize, int[] tileCount, float hillHeight, float[] countHills, float[] textureRepeatCount);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr SceneManager_AddLightSceneNode(IntPtr scenemanager, IntPtr parent, float[] position, float[] color, float radius, int id);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr SceneManager_SetAmbientLight(IntPtr scenemanager, float[] color);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr SceneManager_AddMeshSceneNode(IntPtr scenemanager, IntPtr mesh, IntPtr parent, int id);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr SceneManager_AddOctTreeSceneNode(IntPtr scenemanager, IntPtr mesh, IntPtr parent, int id, int minimalPolysPerNode);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr SceneManager_AddOctTreeSceneNodeA(IntPtr scenemanager, IntPtr animatedmesh, IntPtr parent, int id, int minimalPolysPerNode);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr SceneManager_AddParticleSystemSceneNode(IntPtr scenemanager, bool defaultEmitter, IntPtr parent, int id);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr SceneManager_AddSkyBoxSceneNode(IntPtr scenemanager, IntPtr top, IntPtr bottom, IntPtr lef, IntPtr right, IntPtr front, IntPtr back, IntPtr parent, int id);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr SceneManager_AddTerrainMesh(IntPtr scenemanager, string meshname, IntPtr texture, IntPtr heightmap, int[] stretchSize, float maxHeight, int[] defaultVertexBlockSize);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr SceneManager_AddTerrainSceneNode(IntPtr scenemanager, string TreeXML, IntPtr parent, int id, float[] position, float[] rotation, float[] scale, int[] vertexColor, int maxLOD, TerrainPatchSize patchSize, int smoothFactor);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr SceneManager_AddCubeSceneNode(IntPtr scenemanager, float size, IntPtr parent, int id);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr SceneManager_AddSkyDomeSceneNode(IntPtr scenemanager, IntPtr texture, uint horiRes, uint vertRes, double texturePercentage, double spherePercentage, double radius, IntPtr parent);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr SceneManager_AddSphereSceneNode(IntPtr scenemanager, float radius, int polycount, IntPtr parent);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr SceneManager_AddTextSceneNode(IntPtr scenemanager, IntPtr font, string text, int[] color, IntPtr parent);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr SceneManager_AddTextSceneNode2(IntPtr scenemanager, IntPtr font, string text, IntPtr parent, float[] size, float[] pos, int ID, int[] shade_top, int[] shade_down);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void SceneManager_AddToDeletionQueue(IntPtr scenemanager, IntPtr node);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void SceneManager_RegisterNodeForRendering(IntPtr scenemanager, IntPtr node, SceneNodeRenderPass pass);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr SceneManager_AddWaterSurfaceSceneNode(IntPtr scenemanager, IntPtr mesh, float waveHeight, float waveSpeed, float waveLength, IntPtr parent, int ID);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr SceneManager_CreateCollisionResponseAnimator(IntPtr scenemanager, IntPtr world, IntPtr sceneNode, float[] ellipsoidRadius, float[] gravityPerSecond, float[] ellipsoidTranslation, float slidingValue);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr SceneManager_CreateDeleteAnimator(IntPtr scenemanager, uint timeMS);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr SceneManager_CreateTextureAnimator(IntPtr scenemanager, IntPtr[] textures, int arraysize, int time, bool loop);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr SceneManager_CreateFlyCircleAnimator(IntPtr scenemanager, float[] center, float radius, float speed);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr SceneManager_CreateFlyStraightAnimator(IntPtr scenemanager, float[] startPoint, float[] endPoint, uint time, bool loop);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr SceneManager_CreateMetaTriangleSelector(IntPtr scenemanager);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr SceneManager_CreateOctTreeTriangleSelector(IntPtr scenemanager, IntPtr mesh, IntPtr node, int minimalPolysPerNode);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr SceneManager_CreateFollowSplineAnimator(IntPtr scenemanager, int starttime, float[] Xs, float[] Ys, float[] Zs, int arraysize, float speed, float tightness);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr SceneManager_CreateRotationAnimator(IntPtr scenemanager, float[] rotation);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr SceneManager_CreateTerrainTriangleSelector(IntPtr scenemanager, IntPtr node, int LOD);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr SceneManager_CreateTriangleSelector(IntPtr scenemanager, IntPtr mesh, IntPtr node);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr SceneManager_CreateTriangleSelectorFromBoundingBox(IntPtr scenemanager, IntPtr node);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void SceneManager_DrawAll(IntPtr scenemanager);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr SceneManager_GetActiveCamera(IntPtr scenemanager);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr SceneManager_GetMesh(IntPtr scenemanager, string meshname);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr SceneManager_GetMeshFromReadFile(IntPtr scenemanager, IntPtr opaqueFilePointer);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr SceneManager_GetMeshManipulator(IntPtr scenemanager);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr SceneManager_GetSceneCollisionManager(IntPtr scenemanager);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr SceneManager_GetSceneNodeFromID(IntPtr scenemanager, int id);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr SceneManager_GetSceneNodeFromName(IntPtr scenemanager, string name);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr SceneManager_GetSceneNodeFromType(IntPtr mgr, IntPtr snode, int type);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr SceneManager_GetRootSceneNode(IntPtr scenemanager);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern SceneNodeRenderPass SceneManager_GetSceneNodeRenderPass(IntPtr scenemanager);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void SceneManager_GetShadowColor(IntPtr scenemanager, [MarshalAs(UnmanagedType.LPArray)] int[] toR);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr SceneManager_GetVideoDriver(IntPtr scenemanager);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void SceneManager_SetActiveCamera(IntPtr scenemanager, IntPtr camerascenenode);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void SceneManager_SetShadowColor(IntPtr scenemanager, int[] color);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void SceneManager_SaveScene(IntPtr scenemanager, string filename);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void SceneManager_LoadScene(IntPtr scenemanager, string filename, IntPtr parent);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr SceneManager_CreateMeshWriter(IntPtr scenemanager, MeshWriterType type);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void SceneManager_Clear(IntPtr scenemanager);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr SceneManager_CreateNewSceneManager(IntPtr scenemanager, bool copycontent);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern bool SceneManager_PostEventFromUser(IntPtr scenemanager, IntPtr eventptr);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr SceneManager_GetMeshCache(IntPtr scenemanager);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr SceneManager_GetGUIEnv(IntPtr scenemanager);
        #endregion
    }

    public class KeyMap
    {
        Hashtable map = new Hashtable();
        public void AssignAction(KeyAction action, KeyCode code)
        {
            if (map.ContainsKey(action))
                map[action] = code;
            else
                map.Add(action, code);
        }
        public int Size { get { return map.Count; } }
        public int[] Actions
        {
            get
            {
                int[] tor = new int[Size];
                int i = 0;
                foreach (KeyAction action in map.Keys)
                {
                    tor[i] = (int)action;
                    i++;
                }
                return tor;
            }
        }
        public int[] Codes
        {
            get
            {
                int[] tor = new int[Size];
                int i = 0;
                foreach (KeyCode action in map.Values)
                {
                    tor[i] = (int)action;
                    i++;
                }
                return tor;
            }
        }
    }
    public enum KeyAction
    {
        MoveForward,
        MoveBackward,
        StrafeLeft,
        StrafeRight,
        JumpUp,
        Crouch
    }
}
