using System;
using System.Collections.Generic;
using System.Reflection;
using System.Xml;
using IrrlichtNET;
using IrrlichtNET.Extensions;

namespace Collision
{
    public class Collision
    {
        private static IrrlichtDevice device = null;

        private static VideoDriver videoDriver = null;
        private static SceneManager sceneManager = null;
        private static GUIEnvironment guiEnvironment = null;

        private static BillboardSceneNode bill = null;
        private static SceneNode highlightedSceneNode = null;
        private static CameraSceneNode camera = null;
        private static Material material = new Material(true);

        public static void Main(string[] args)
        {
            device = new IrrlichtDevice(DriverType.OpenGL, new Dimension2D(640, 480), 32, false, true, false, false);
            if (device == null)
            {
                System.Console.WriteLine("Device could not be created. Exiting.");
                return;
            }

            device.WindowCaption = "Hello World - Collision Demo";

            videoDriver = device.VideoDriver;
            sceneManager = device.SceneManager;
            guiEnvironment = device.GUIEnvironment;

            device.FileSystem.AddZipFileArchive("../../irrlicht/media/map-20kdm2.pk3", true, true);
            AnimatedMesh q3levelMesh = sceneManager.GetMesh("20kdm2.bsp");
            SceneNode q3node = null;

            if (q3levelMesh != null && !q3levelMesh.Null())
            {
                q3node = sceneManager.AddOctTreeSceneNode(q3levelMesh.GetMesh(0), sceneManager.RootSceneNode, 0, 128);
            }

            TriangleSelector selector = null;
            if (q3node != null && !q3node.Null())
            {
                q3node.Position = new Vector3D(-1350, -130, -1400);
                selector = sceneManager.CreateOctTreeTriangleSelector(q3levelMesh.GetMesh(0), q3node, 128);
                q3node.TriangleSelector = selector;
            }

            camera = sceneManager.AddCameraSceneNodeFPS(sceneManager.RootSceneNode, 100, 0.3f, false);
            camera.Position = new Vector3D(50, 50, -60);
            camera.Target = new Vector3D(-70, 30, -60);

            if (selector != null && !selector.Null())
            {
                Animator anim = sceneManager.CreateCollisionResponseAnimator(selector, camera, new Vector3D(30, 50, 30), new Vector3D(0, -10, 0), new Vector3D(0, 30, 0), 0);
                selector.Drop();
                camera.AddAnimator(anim);
                anim.Drop();
            }

            device.CursorControl.Visible = false;

            bill = sceneManager.AddBillboardSceneNode(sceneManager.RootSceneNode, new Dimension2Df(20, 20), 0);
            bill.SetMaterialType(MaterialType.TransparentAddColor);
            bill.SetMaterialTexture(0, videoDriver.GetTexture("../../irrlicht/media/particle.bmp"));
            bill.SetMaterialFlag(MaterialFlag.Lighting, false);
            bill.SetMaterialFlag(MaterialFlag.ZBuffer, false);

            AnimatedMeshSceneNode node = null;

            // Add an MD2 node, which uses vertex-based animation.
	        node = sceneManager.AddAnimatedMeshSceneNode(sceneManager.GetMesh("../../irrlicht/media/faerie.md2"));
            node.Position = new Vector3D(-70, -15, -120);
            node.Scale = new Vector3D(2,2,2);
            node.SetMD2Animation(MD2Animation.Point);
            node.AnimationSpeed = 20;
            node.GetMaterial(0).Texture1 = videoDriver.GetTexture("../../irrlicht/media/faerie2.bmp");
            node.GetMaterial(0).NormalizeNormals = true;
            node.GetMaterial(0).Lighting = true;
            selector = sceneManager.CreateTriangleSelector(node.AnimatedMesh.GetMesh(0), node);
            node.TriangleSelector = selector;
            selector.Drop();

  	        node = sceneManager.AddAnimatedMeshSceneNode(sceneManager.GetMesh("../../irrlicht/media/dwarf.x"));
            node.Position = new Vector3D(-70, -66, 0);
            node.Rotation = new Vector3D(0, -90, 0);
            node.AnimationSpeed = 20;
            selector = sceneManager.CreateTriangleSelector(node.AnimatedMesh.GetMesh(0), node);
            node.TriangleSelector = selector;
            selector.Drop();

   	        node = sceneManager.AddAnimatedMeshSceneNode(sceneManager.GetMesh("../../irrlicht/media/ninja.b3d"));
            node.Scale = new Vector3D(10,10,10);
            node.Position = new Vector3D(-70, -66, -60);
            node.Rotation = new Vector3D(0, 90, 0);
            node.AnimationSpeed = 10;
            selector = sceneManager.CreateTriangleSelector(node.AnimatedMesh.GetMesh(0), node);
            node.TriangleSelector = selector;
            selector.Drop();

            LightSceneNode light = sceneManager.AddLightSceneNode(sceneManager.RootSceneNode, new Vector3D(-60, 100, 400), new Colorf(1, 1, 1, 1), 600, 0);
            material.Wireframe = true;

            device.OnEvent += new OnEventDelegate(device_OnEvent);

            while (device.Run())
            {
                RenderLoop();
            }

            device.Drop();
        }

        private static void RenderLoop()
        {
            Render();
            Update();
        }

        private static void Render()
        {
            uint time = device.Timer.Time;

            SceneCollisionManager collMan = sceneManager.CollisionManager;

            
            // Render scene
            device.VideoDriver.BeginScene(true, true, new Color(255, 120, 102, 136));
            sceneManager.DrawAll();

            if (highlightedSceneNode != null)
            {
                highlightedSceneNode.SetMaterialFlag(MaterialFlag.Lighting, true);
                highlightedSceneNode = null;
            }

            Line3D ray;
            ray.Start = camera.Position;
            ray.End = ray.Start + (camera.Target - ray.Start).Normalize() * 1000f;

            SceneNode selectedSceneNode = collMan.GetSceneNodeFromRay(ray, 1, false);
            

            if (selectedSceneNode != null && !selectedSceneNode.Null())
            {
                Vector3D intersection;
                Triangle3D hitTriangle;

                if (selectedSceneNode.TriangleSelector != null)
                {
                    collMan.GetCollisionPoint(ray, selectedSceneNode.TriangleSelector, out intersection, out hitTriangle);
                    bill.Position = intersection;

                    videoDriver.SetTransform(TransformationState.World, new Matrix4());
                    videoDriver.SetMaterial(material);
                    videoDriver.Draw3DTriangle(hitTriangle, new Color(0, 255, 0, 0));
                }
                if ((selectedSceneNode.ID & 2) == 2)
                {
                    highlightedSceneNode = selectedSceneNode;
                    highlightedSceneNode.SetMaterialFlag(MaterialFlag.Lighting, false);
                }
            }

            device.VideoDriver.EndScene();
        }

        private static void Update()
        {
            // Calculate next frame
        }

        #region Event Processing
        private static bool device_OnEvent(Event p_event)
        {
            if (p_event.Type == EventType.KeyInputEvent)
            {
                
            }

            if (p_event.Type == EventType.MouseInputEvent)
            {
                
            }

            return false;
        }
        #endregion
    }
}