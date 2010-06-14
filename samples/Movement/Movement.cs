using System;
using System.Collections.Generic;
using System.Reflection;
using System.Xml;
using IrrlichtNET;
using IrrlichtNET.Extensions;

namespace Movement
{
    public class Movement
    {
        private static IrrlichtDevice device = null;

        private static VideoDriver videoDriver = null;
        private static SceneManager sceneManager = null;
        private static GUIEnvironment guiEnvironment = null;

        private static SceneNode node = null;

        public static void Main(string[] args)
        {
            device = new IrrlichtDevice(DriverType.OpenGL, new Dimension2D(640, 480), 32, false, true, false, false);
            if (device == null)
            {
                System.Console.WriteLine("Device could not be created. Exiting.");
                return;
            }

            device.WindowCaption = "Movement - Irrlicht.Net Demo";

            videoDriver = device.VideoDriver;
            sceneManager = device.SceneManager;
            guiEnvironment = device.GUIEnvironment;

            node = sceneManager.AddSphereSceneNode(1.0f, 32, sceneManager.RootSceneNode);
            node.Position = new Vector3D(0.0f, 0.0f, 30.0f);
            node.SetMaterialFlag(MaterialFlag.Lighting, false);
            node.SetMaterialTexture(0, videoDriver.GetTexture("../../irrlicht/media/wall.bmp"));

            SceneNode n = sceneManager.AddCubeSceneNode(1.0f, sceneManager.RootSceneNode, -1);
            n.SetMaterialTexture(0, videoDriver.GetTexture("../../irrlicht/media/t351sml.jpg"));
            n.SetMaterialFlag(MaterialFlag.Lighting, false);
            Animator anim = sceneManager.CreateFlyCircleAnimator(new Vector3D(0.0f, 0.0f, 30.0f), 20.0f, 0.01f);
            n.AddAnimator(anim);
            anim.Drop();

            AnimatedMesh mesh = sceneManager.GetMesh("../../irrlicht/media/sydney.md2");
            if (mesh == null)
            {
                System.Console.WriteLine("Meshfile could not be loaded");
                return;
            }
            AnimatedMeshSceneNode anode = sceneManager.AddAnimatedMeshSceneNode(mesh);
            if (anode != null)
            {
                anode.SetMaterialFlag(MaterialFlag.Lighting, false);
                anode.SetMD2Animation(MD2Animation.Stand);
                anode.SetMaterialTexture(0, videoDriver.GetTexture("../../irrlicht/media/sydney.bmp"));
                anode.SetFrameLoop(160, 180);
                anode.AnimationSpeed = 30;
                anode.Rotation = new Vector3D(0, 180, 0);
            }

            Animator anims = sceneManager.CreateFlyStraightAnimator(new Vector3D(100, 0, 60), new Vector3D(-100, 0, 60), 5000, true);
            anode.AddAnimator(anims);
            anims.Drop();

            CameraSceneNode camera = sceneManager.AddCameraSceneNodeFPS(sceneManager.RootSceneNode, 100, 100, false);
            camera.Position = new Vector3D(0, 30, -40);
            camera.Target = new Vector3D(0, 5, 0);

            device.CursorControl.Visible = true;

            device.OnEvent += new OnEventDelegate(device_OnEvent);

            while (device.Run())
            {
                RenderLoop();
            }
        }

        private static void RenderLoop()
        {
            Render();
            Update();
        }

        private static void Render()
        {
            // Render scene
            device.VideoDriver.BeginScene(true, true, Color.Blue);
            
            device.SceneManager.DrawAll();
            device.WindowCaptionW = "Movement - Irrlicht.Net Demo - FPS: " + videoDriver.FPS;
            device.GUIEnvironment.DrawAll();

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
                switch (p_event.KeyCode)
                {
                    case KeyCode.Key_W:
                    case KeyCode.Key_S:
                        Vector3D v = node.Position;
                        v.X += p_event.KeyCode == KeyCode.Key_W ? 2.0f : -2.0f;
                        node.Position = v;
                        return true;
                }
            }

            if (p_event.Type == EventType.MouseInputEvent)
            {
                
            }

            return false;
        }
        #endregion
    }
}