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

        private enum GuiIds {
            GUI_ID_QUIT_BUTTON = 101,
	        GUI_ID_NEW_WINDOW_BUTTON,
	        GUI_ID_FILE_OPEN_BUTTON,
	        GUI_ID_TRANSPARENCY_SCROLL_BAR
        }

        private static GUIListBox listBox = null;
        private static int counter = 0;

        public static void Main(string[] args)
        {
            device = new IrrlichtDevice(DriverType.OpenGL, new Dimension2D(640, 480), 32, false, true, false, false);
            if (device == null)
            {
                System.Console.WriteLine("Device could not be created. Exiting.");
                return;
            }

            device.WindowCaption = "Hello World - User Interface Demo";
            device.Resizeable = true;

            videoDriver = device.VideoDriver;
            sceneManager = device.SceneManager;
            guiEnvironment = device.GUIEnvironment;

            GUISkin skin = guiEnvironment.Skin;
            GUIFont font = guiEnvironment.GetFont("../../irrlicht/media/fonthaettenschweiler.bmp");
            if (!font.Null())
                skin.Font = font;

            GUIButton button1 = guiEnvironment.AddButtonW(new Rect(10, 240, 110, 240 + 32), guiEnvironment.RootElement, (int)GuiIds.GUI_ID_QUIT_BUTTON, "Quit");
            button1.ToolTipTextW = "Exits Program";
            GUIButton button2 = guiEnvironment.AddButtonW(new Rect(10, 280, 110, 280 + 32), guiEnvironment.RootElement, (int)GuiIds.GUI_ID_NEW_WINDOW_BUTTON, "New Window");
            button2.ToolTipTextW = "Launches a new Window";
            GUIButton button3 = guiEnvironment.AddButtonW(new Rect(10, 320, 110, 320 + 32), guiEnvironment.RootElement, (int)GuiIds.GUI_ID_FILE_OPEN_BUTTON, "File Open");
            button3.ToolTipTextW = "Opens a file";

            guiEnvironment.AddStaticTextW("Transparency Control:", new Rect(150, 20, 350, 40), true, false, guiEnvironment.RootElement, -1, false);
            GUIScrollBar scrollBar = guiEnvironment.AddScrollBar(true, new Rect(150, 45, 350, 60), guiEnvironment.RootElement, (int)GuiIds.GUI_ID_TRANSPARENCY_SCROLL_BAR);
            scrollBar.Max = 255;

            scrollBar.Pos = guiEnvironment.Skin.GetColor(GuiDefaultColor.Window).A;

            guiEnvironment.AddStaticTextW("Logging ListBox:", new Rect(50, 110, 250, 130), true, false, guiEnvironment.RootElement, -1, false);
            listBox = guiEnvironment.AddListBox(new Rect(50, 140, 250, 210), guiEnvironment.RootElement, -1, true);
            guiEnvironment.AddEditBoxW("Editable Text", new Rect(350, 80, 550, 100), true, guiEnvironment.RootElement, -1);

            guiEnvironment.AddImage(videoDriver.GetTexture("../../irrlicht/media/irrlichtlogo2.png"), new Position2D(10, 10), true, guiEnvironment.RootElement, -1, "");

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
            // Render scene
            device.VideoDriver.BeginScene(true, true, Color.Blue);
            
            device.SceneManager.DrawAll();
            device.WindowCaptionW = "Hello World - User Interface Demo - FPS: " + videoDriver.FPS;
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
            if (p_event.Type == EventType.GUIEvent)
            {
                int id = p_event.Caller.ID;
                switch (p_event.GUIEvent)
                {
                    case GUIEventType.ScrollBarChanged:
                        if (id == (int)GuiIds.GUI_ID_TRANSPARENCY_SCROLL_BAR)
                        {
                            int pos = ((GUIScrollBar)p_event.Caller).Pos;
                            for (int i = 0; i < (int)GuiDefaultColor.Count; i++)
                            {
                                Color col = guiEnvironment.Skin.GetColor((GuiDefaultColor)i);
                                col.A = pos;
                                guiEnvironment.Skin.SetColor((GuiDefaultColor)i, col);
                            }
                        }
                    break;
                    case GUIEventType.ButtonClicked:
                        switch (id)
                        {
                            case (int)GuiIds.GUI_ID_QUIT_BUTTON:
                                device.Close();
                                return true;
                            break;
                            case (int)GuiIds.GUI_ID_NEW_WINDOW_BUTTON:
                                listBox.AddItemW("Window created");
                                counter += 30;
                                if (counter > 200)
                                {
                                    counter = 0;
                                }

                                GUIWindow window = guiEnvironment.AddWindowW(new Rect(100 + counter, 100 + counter, 300 + counter, 200 + counter), false, "Test window", guiEnvironment.RootElement, -1);
                                guiEnvironment.AddStaticTextW("Please close me", new Rect(35, 35, 140, 50), true, false, window, -1, true);
                                return (true);
                            break;
                            case (int)GuiIds.GUI_ID_FILE_OPEN_BUTTON:
                                listBox.AddItemW("File open");
                                guiEnvironment.AddFileOpenDialog("Please choose a file", true, guiEnvironment.RootElement, -1);
                                return (true);
                        }
                    break;
                }
            }
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