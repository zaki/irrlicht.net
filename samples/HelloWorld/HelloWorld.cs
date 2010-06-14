using System;
using System.Collections.Generic;
using System.Reflection;
using System.Xml;
using IrrlichtNET;
using IrrlichtNET.Extensions;

namespace HelloWorld
{
    public class HelloWorld
    {
        private static IrrlichtDevice device = null;

        private static VideoDriver videoDriver = null;
        private static SceneManager sceneManager = null;
        private static GUIEnvironment guiEnvironment = null;

        public static void Main(string[] args)
        {
            device = new IrrlichtDevice(DriverType.OpenGL, new Dimension2D(640, 480), 32, false, true, false, false);
            if (device == null)
            {
                System.Console.WriteLine("Device could not be created. Exiting.");
                return;
            }

            device.WindowCaption = "Hello World - Irrlicht.Net Demo";

            videoDriver = device.VideoDriver;
            sceneManager = device.SceneManager;
            guiEnvironment = device.GUIEnvironment;

            guiEnvironment.AddStaticTextW("Hello World! This is the Irrlicht.Net demo application", new Rect(10, 10, 590, 32), true, false, guiEnvironment.RootElement, -1, false);

            AnimatedMesh mesh = sceneManager.GetMesh("../../irrlicht/media/sydney.md2");
            if (mesh == null)
            {
                System.Console.WriteLine("Meshfile could not be loaded");
                return;
            }
            AnimatedMeshSceneNode node = sceneManager.AddAnimatedMeshSceneNode(mesh);
            if (node != null)
            {
                node.SetMaterialFlag(MaterialFlag.Lighting, false);
                node.SetMD2Animation(MD2Animation.Stand);
                node.SetMaterialTexture(0, videoDriver.GetTexture("../../irrlicht/media/sydney.bmp"));
            }

            CameraSceneNode camera = sceneManager.AddCameraSceneNode(sceneManager.RootSceneNode);
            camera.Position = new Vector3D(0, 30, -40);
            camera.Target = new Vector3D(0, 5, 0);

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
            device.WindowCaptionW = "Hello World - Irrlicht.Net Demo - FPS: " + videoDriver.FPS;
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
                
            }

            if (p_event.Type == EventType.MouseInputEvent)
            {
                
            }

            return false;
        }
        #endregion
    }
}