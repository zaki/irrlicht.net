using System;
using System.Collections.Generic;
using System.Reflection;
using System.Xml;
using IrrlichtNET;
using IrrlichtNET.Extensions;

namespace TwoDGraphics
{
    public class TwoDGraphics
    {
        private static IrrlichtDevice device = null;

        private static VideoDriver videoDriver = null;
        private static SceneManager sceneManager = null;
        private static GUIEnvironment guiEnvironment = null;

        private static Rect imp1 = new Rect(349, 15, 385, 78);
        private static Rect imp2 = new Rect(387, 15, 423, 78);
        private static Texture images = null;
        private static GUIFont font = null;
        private static GUIFont font2 = null;

        public static void Main(string[] args)
        {
            device = new IrrlichtDevice(DriverType.OpenGL, new Dimension2D(640, 480), 32, false, true, false, false);
            if (device == null)
            {
                System.Console.WriteLine("Device could not be created. Exiting.");
                return;
            }

            device.WindowCaption = "Hello World - 2D Graphics Demo";

            videoDriver = device.VideoDriver;
            sceneManager = device.SceneManager;
            guiEnvironment = device.GUIEnvironment;

            images = videoDriver.GetTexture("../../irrlicht/media/2ddemo.png");
            videoDriver.MakeColorKeyTexture(images, new Position2D(0, 0));

            font = guiEnvironment.BuiltInFont;
            font2 = guiEnvironment.GetFont("../../irrlicht/media/fonthaettenschweiler.bmp");

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
            
            // Render scene
            device.VideoDriver.BeginScene(true, true, new Color(255, 120, 102, 136));

            videoDriver.Draw2DImage(images, new Position2D(50, 50), new Rect(0, 0, 342, 224), new Color(255, 255, 255, 255), true);
            videoDriver.Draw2DImage(images, new Position2D(164, 125), ((time/500)%2 == 0 ? imp1 : imp2), new Color(255, 255, 255, 255), true);
            videoDriver.Draw2DImage(images, new Position2D(270, 105), ((time / 500) % 2 == 0 ? imp1 : imp2), new Color(255, (int)time%255, 255, 255), true);

            if (font != null)
                font.DrawW("This demo shows that Irrlicht is also capable of drawing 2D graphics.", new Rect(130, 10, 300, 50), new Color(255, 255, 255, 255), false, false);

            if (font2 != null)
                font2.DrawW("Also mixing with 3d graphics is possible.", new Rect(130, 20, 300, 60), new Color(255, (int)time % 255, (int)time % 255, 255), false, false);

            videoDriver.Draw2DImage(images, new Position2D(10, 10), new Rect(354, 87, 442, 118), new Color(255, 255, 255, 255), true);

            device.WindowCaptionW = "Hello World - 2D Graphics Demo - FPS: " + videoDriver.FPS;

            Position2D m = device.CursorControl.Position;
            videoDriver.Draw2DRectangle(new Rect(m.X-20, m.Y-20, m.X+20, m.Y+20), new Color(100, 255, 255, 255));

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