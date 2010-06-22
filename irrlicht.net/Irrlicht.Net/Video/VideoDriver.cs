using System;
using System.Runtime.InteropServices;
using System.Security;

namespace IrrlichtNET
{
    public class VideoDriver : NativeElement
    {
        public VideoDriver(IntPtr raw)
            : base(raw)
        {
        }

        /// <summary>
        /// Begin the scene
        /// </summary>
        /// <param name="back">Should the back buffer be cleared ?</param>
        /// <param name="z">Should the Z buffer be cleared ? (useless on 2D-only applications)</param>
        /// <param name="col">Color of the backbuffer</param>
        /// <returns>False if failed</returns>
        public bool BeginScene(bool back, bool z, Color col)
        {
            return VideoDriver_BeginScene(_raw, back, z, col.ToUnmanaged());
        }

        /// <summary>
        /// Ends the scene
        /// </summary>
        public void EndScene()
        {
            VideoDriver_EndScene(_raw);
        }

        /// <summary>
        /// Ends the scene
        /// </summary>
        public void EndScene(IntPtr windowHandle, Rect sourceRect)
        {
            VideoDriver_EndSceneA(_raw, windowHandle.ToInt32(), sourceRect.ToUnmanaged());
        }

        /// <summary>
        /// Creates an empty texture
        /// </summary>
        /// <param name="size">Size of the teture</param>
        /// <param name="name">Name of the texture on the texture pool</param>
        /// <param name="fmt">Pixel format</param>
        /// <returns>The created texture</returns>
        public Texture AddTexture(Dimension2D size, string name, ColorFormat fmt)
        {
            return (Texture)
                NativeElement.GetObject(VideoDriver_AddTexture(_raw, size.ToUnmanaged(), name, fmt),
                                        typeof(Texture));
        }

        public Image CreateImageFromFile(string filename)
        {
            return (Image)
                NativeElement.GetObject(VideoDriver_CreateImageFromFile(_raw, filename),
                                        typeof(Image));
        }

        /// <summary>
        /// Creates an texture from the Image
        /// </summary>
        /// <param name="name">Name of the texture on the texture pool</param>
        /// <param name="img">The image from what the texture to be created</param>
        /// <returns>The created texture</returns>
        public Texture AddTexture(string name, Image img)
        {
            return (Texture)
                NativeElement.GetObject(VideoDriver_AddTextureFromImage(_raw, name, img.Raw),
                                        typeof(Texture));
        }

        /// <summary>
        /// Retrieves the texture
        /// </summary>
        /// <param name="name">Path to the texture</param>
        /// <returns>The texture</returns>
        public Texture GetTexture(string name)
        {
            return (Texture)
                NativeElement.GetObject(VideoDriver_GetTexture(_raw, name),
                                        typeof(Texture));
        }

        /// <summary>
        /// Creates an 1bit alpha channel of the texture based on a pixel position color
        /// </summary>
        /// <param name="texture">Input texture that will be modified</param>
        /// <param name="colorKeyPixelPos">Position of the pixel with the color key</param>
        public void MakeColorKeyTexture(Texture texture, Position2D colorKeyPixelPos)
        {
            VideoDriver_MakeColorKeyTexture(_raw, texture.Raw, colorKeyPixelPos.ToUnmanaged());
        }

        /// <summary>
        /// Creates an 1bit alpha channel of the texture based on a color
        /// </summary>
        /// <param name="texture">Input texture that will be modified</param>
        /// <param name="color">Color</param>
        public void MakeColorKeyTexture(Texture texture, Color color)
        {
            VideoDriver_MakeColorKeyTextureA(_raw, texture.Raw, color.ToUnmanaged());
        }

        /// <summary>
        /// Creates a normal map from heightmap texture
        /// </summary>
        /// <param name="texture">Input texture that will be modified</param>
        /// <param name="amplitude">Constant value which by the height information is multiplied</param>
        public void MakeNormalMapTexture(Texture texture, float amplitude)
        {
            VideoDriver_MakeNormalMapTexture(_raw, texture.Raw, amplitude);
        }

        public Texture CreateRenderTargetTexture(Dimension2D size)
        {
            return (Texture)
                NativeElement.GetObject(VideoDriver_CreateRenderTargetTexture(_raw, size.ToUnmanaged()),
                                        typeof(Texture));
        }

        public void ClearZBuffer()
        {
            VideoDriver_ClearZBuffer(_raw);
        }

        public void Draw2DImage(Texture image, Position2D destPos, Rect sourceRect, Rect clipRect, Color color, bool useAlpha)
        {
            VideoDriver_Draw2DImage(_raw, image.Raw, destPos.ToUnmanaged(), sourceRect.ToUnmanaged(), clipRect.ToUnmanaged(), color.ToUnmanaged(), useAlpha);
        }

        public void Draw2DImage(Texture image, Position2D destPos, Rect sourceRect, Color color, bool useAlpha)
        {
            VideoDriver_Draw2DImageB(_raw, image.Raw, destPos.ToUnmanaged(), sourceRect.ToUnmanaged(), color.ToUnmanaged(), useAlpha);
        }

        public void Draw2DImage(Texture image, Rect destRect, Rect sourceRect, Color[] color, bool useAlpha)
        {
            VideoDriver_Draw2DImageD(_raw, image.Raw, destRect.ToUnmanaged(), sourceRect.ToUnmanaged(), color[0].ToUnmanaged(), color[1].ToUnmanaged(), color[2].ToUnmanaged(), color[3].ToUnmanaged(), useAlpha);
        }

        public void Draw2DImage(Texture image, Rect destRect, Rect sourceRect, Color color, bool useAlpha)
        {
            VideoDriver_Draw2DImageD(_raw, image.Raw, destRect.ToUnmanaged(), sourceRect.ToUnmanaged(), color.ToUnmanaged(), color.ToUnmanaged(), color.ToUnmanaged(), color.ToUnmanaged(), useAlpha);
        }

        public void Draw2DImage(Texture image, Rect destRect, Rect sourceRect, Rect clipRect, Color[] color, bool useAlpha)
        {
            VideoDriver_Draw2DImageC(_raw, image.Raw, destRect.ToUnmanaged(), sourceRect.ToUnmanaged(), clipRect.ToUnmanaged(), color[0].ToUnmanaged(), color[1].ToUnmanaged(), color[2].ToUnmanaged(), color[3].ToUnmanaged(), useAlpha);
        }

        public void Draw2DImage(Texture image, Rect destRect, Rect sourceRect, Rect clipRect, Color color, bool useAlpha)
        {
            VideoDriver_Draw2DImageC(_raw, image.Raw, destRect.ToUnmanaged(), sourceRect.ToUnmanaged(), clipRect.ToUnmanaged(), color.ToUnmanaged(), color.ToUnmanaged(), color.ToUnmanaged(), color.ToUnmanaged(), useAlpha);
        }

        public void Draw2DImage(Texture image, Position2D destPos)
        {
            VideoDriver_Draw2DImageA(_raw, image.Raw, destPos.ToUnmanaged());
        }

        public void Draw2DImage(Texture image, Position2D destPos, Color color, bool useAlphaChannel)
        {
            Draw2DImage(image, destPos, new Rect(new Position2D(0, 0), image.OriginalSize), color, useAlphaChannel);
        }

        public void Draw2DImage(Texture image, Position2D destPos, bool useAlphaChannel)
        {
            Draw2DImage(image, destPos, Color.White, useAlphaChannel);
        }

        public void Draw2DLine(Position2D start, Position2D end, Color color)
        {
            VideoDriver_Draw2DLine(_raw, start.ToUnmanaged(), end.ToUnmanaged(), color.ToUnmanaged());
        }

        public void Draw2DPolygon(Position2D center, float radius, Color color, int vertexCount)
        {
            VideoDriver_Draw2DPolygon(_raw, center.ToUnmanaged(), radius, color.ToUnmanaged(), vertexCount);
        }

        public void Draw2DRectangle(Rect rectangle, Color leftUp, Color rightUp, Color leftDown, Color rightDown)
        {
            VideoDriver_Draw2DRectangle(_raw, rectangle.ToUnmanaged(), leftUp.ToUnmanaged(), rightUp.ToUnmanaged(), leftDown.ToUnmanaged(), rightDown.ToUnmanaged());
        }

        public void Draw2DRectangle(Rect rectangle, Color color)
        {
            Draw2DRectangle(rectangle, color, color, color, color);
        }

        public void Draw3DBox(Box3D box, Color color)
        {
            VideoDriver_Draw3DBox(_raw, box.ToUnmanaged(), color.ToUnmanaged());
        }

        public void Draw3DLine(Vector3D start, Vector3D end, Color color)
        {
            VideoDriver_Draw3DLine(_raw, start.ToUnmanaged(), end.ToUnmanaged(), color.ToUnmanaged());
        }

        public void DrawMeshBuffer(MeshBuffer buffer)
        {
            VideoDriver_DrawMeshBuffer(_raw, buffer.Raw);
        }

        public void Draw3DLine(Line3D line, Color color)
        {
            Draw3DLine(line.Start, line.End, color);
        }

        public void Draw3DTriangle(Triangle3D tri, Color col)
        {
            VideoDriver_Draw3DTriangle(_raw, tri.ToUnmanaged(), col.ToUnmanaged());
        }

        public void DrawIndexedTriangleList(Vertex3D[] vertices, int vertexCount, ushort[] indexList, int triangleCount)
        {
            IntPtr[] rawlist = new IntPtr[vertexCount];
            for (int i = 0; i < vertexCount; i++)
                rawlist[i] = vertices[i].Raw;
            VideoDriver_DrawIndexedTriangleList(_raw, rawlist, vertexCount, indexList, triangleCount);
        }

        public void DrawIndexedTriangleList(Vertex3D[] vertices, ushort[] indexList)
        {
            DrawIndexedTriangleList(vertices, vertices.Length, indexList, vertices.Length / 3);
        }

        public void DrawIndexedTriangleList(Vertex3D[] vertices)
        {
            ushort[] indexList = new ushort[vertices.Length];
            for (ushort i = 0; i < vertices.Length; i++)
                indexList[i] = i;
            DrawIndexedTriangleList(vertices, indexList);
        }

        public void DrawIndexedTriangleFan(Vertex3D[] vertices, int vertexCount, ushort[] indexFan, int triangleCount)
        {
            IntPtr[] rawFan = new IntPtr[vertexCount];
            for (int i = 0; i < vertexCount; i++)
                rawFan[i] = vertices[i].Raw;
            VideoDriver_DrawIndexedTriangleFan(_raw, rawFan, vertexCount, indexFan, triangleCount);
        }

        public void DrawIndexedTriangleFan(Vertex3D[] vertices, ushort[] indexFan)
        {
            DrawIndexedTriangleFan(vertices, vertices.Length, indexFan, vertices.Length / 3);
        }

        public void DrawIndexedTriangleFan(Vertex3D[] vertices)
        {
            ushort[] indexFan = new ushort[vertices.Length];
            for (ushort i = 0; i < vertices.Length; i++)
                indexFan[i] = i;
            DrawIndexedTriangleFan(vertices, indexFan);
        }

        public void DrawIndexedTriangleFan(Vertex3DT2[] vertices, int vertexCount, ushort[] indexFan, int triangleCount)
        {
            IntPtr[] rawFan = new IntPtr[vertexCount];
            for (int i = 0; i < vertexCount; i++)
                rawFan[i] = vertices[i].Raw;
            VideoDriver_DrawIndexedTriangleFanA(_raw, rawFan, vertexCount, indexFan, triangleCount);
        }

        public void DrawIndexedTriangleFan(Vertex3DT2[] vertices, ushort[] indexFan)
        {
            DrawIndexedTriangleFan(vertices, vertices.Length, indexFan, vertices.Length / 3);
        }

        public void DrawIndexedTriangleFan(Vertex3DT2[] vertices)
        {
            ushort[] indexFan = new ushort[vertices.Length];
            for (ushort i = 0; i < vertices.Length; i++)
                indexFan[i] = i;
            DrawIndexedTriangleFan(vertices, indexFan);
        }

        public void DrawIndexedTriangleList(Vertex3DT2[] vertices, int vertexCount, ushort[] indexList, int triangleCount)
        {
            IntPtr[] rawlist = new IntPtr[vertexCount];
            for (int i = 0; i < rawlist.Length; i++)
                rawlist[i] = vertices[i].Raw;
            VideoDriver_DrawIndexedTriangleListA(_raw, rawlist, vertexCount, indexList, triangleCount);
        }

        public void DrawIndexedTriangleList(Vertex3DT2[] vertices, ushort[] indexList)
        {
            DrawIndexedTriangleList(vertices, vertices.Length, indexList, vertices.Length / 3);
        }

        public void DrawIndexedTriangleList(Vertex3DT2[] vertices)
        {
            ushort[] indexList = new ushort[vertices.Length];
            for (ushort i = 0; i < vertices.Length; i++)
                indexList[i] = i;
            DrawIndexedTriangleList(vertices, indexList);
        }

        public void DrawVertexPrimitiveList(Vertex3DT2[] vertices, int vertexCount, ushort[] indexList, int triangleCount, PrimitiveType pType)
        {
            IntPtr[] rawlist = new IntPtr[vertexCount];
            for (int i = 0; i < rawlist.Length; i++)
                rawlist[i] = vertices[i].Raw;
            VideoDriver_DrawVertexPrimitiveList(_raw, rawlist, vertexCount, indexList, triangleCount, VertexType.T2Coords, pType);
        }

        public void DrawVertexPrimitiveList(Vertex3DT2[] vertices, ushort[] indexList, int triangleCount, PrimitiveType pType)
        {
            DrawVertexPrimitiveList(vertices, vertices.Length, indexList, triangleCount, pType);
        }

        public void DrawVertexPrimitiveList(Vertex3DT2[] vertices, ushort[] indexList, PrimitiveType pType)
        {
            DrawVertexPrimitiveList(vertices, indexList, vertices.Length / 3, pType);
        }

        public void DrawVertexPrimitiveList(Vertex3DT2[] vertices, PrimitiveType pType)
        {
            ushort[] indexList = new ushort[vertices.Length];
            for (ushort i = 0; i < vertices.Length; i++)
                indexList[i] = i;
            DrawVertexPrimitiveList(vertices, indexList, pType);
        }

        /*
         * Tangents
         */
        public void DrawIndexedTriangleFan(Vertex3DTangents[] vertices, int vertexCount, ushort[] indexFan, int triangleCount)
        {
            IntPtr[] rawFan = new IntPtr[vertexCount];
            for (int i = 0; i < vertexCount; i++)
                rawFan[i] = vertices[i].Raw;
            VideoDriver_DrawIndexedTriangleFanT(_raw, rawFan, vertexCount, indexFan, triangleCount);
        }

        public void DrawIndexedTriangleFan(Vertex3DTangents[] vertices, ushort[] indexFan)
        {
            DrawIndexedTriangleFan(vertices, vertices.Length, indexFan, vertices.Length / 3);
        }

        public void DrawIndexedTriangleFan(Vertex3DTangents[] vertices)
        {
            ushort[] indexFan = new ushort[vertices.Length];
            for (ushort i = 0; i < vertices.Length; i++)
                indexFan[i] = i;
            DrawIndexedTriangleFan(vertices, indexFan);
        }

        public void DrawIndexedTriangleList(Vertex3DTangents[] vertices, int vertexCount, ushort[] indexList, int triangleCount)
        {
            IntPtr[] rawlist = new IntPtr[vertexCount];
            for (int i = 0; i < rawlist.Length; i++)
                rawlist[i] = vertices[i].Raw;
            VideoDriver_DrawIndexedTriangleListT(_raw, rawlist, vertexCount, indexList, triangleCount);
        }

        public void DrawIndexedTriangleList(Vertex3DTangents[] vertices, ushort[] indexList)
        {
            DrawIndexedTriangleList(vertices, vertices.Length, indexList, vertices.Length / 3);
        }

        public void DrawIndexedTriangleList(Vertex3DTangents[] vertices)
        {
            ushort[] indexList = new ushort[vertices.Length];
            for (ushort i = 0; i < vertices.Length; i++)
                indexList[i] = i;
            DrawIndexedTriangleList(vertices, indexList);
        }

        public void DrawVertexPrimitiveList(Vertex3DTangents[] vertices, int vertexCount, ushort[] indexList, int triangleCount, PrimitiveType pType)
        {
            IntPtr[] rawlist = new IntPtr[vertexCount];
            for (int i = 0; i < rawlist.Length; i++)
                rawlist[i] = vertices[i].Raw;
            VideoDriver_DrawVertexPrimitiveList(_raw, rawlist, vertexCount, indexList, triangleCount, VertexType.Tangents, pType);
        }

        public void DrawVertexPrimitiveList(Vertex3DTangents[] vertices, ushort[] indexList, int triangleCount, PrimitiveType pType)
        {
            DrawVertexPrimitiveList(vertices, vertices.Length, indexList, triangleCount, pType);
        }

        public void DrawVertexPrimitiveList(Vertex3DTangents[] vertices, ushort[] indexList, PrimitiveType pType)
        {
            DrawVertexPrimitiveList(vertices, indexList, vertices.Length / 3, pType);
        }

        public void DrawVertexPrimitiveList(Vertex3DTangents[] vertices, PrimitiveType pType)
        {
            ushort[] indexList = new ushort[vertices.Length];
            for (ushort i = 0; i < vertices.Length; i++)
                indexList[i] = i;
            DrawVertexPrimitiveList(vertices, indexList, pType);
        }

        /*
         *
         */

        public void DrawVertexPrimitiveList(Vertex3D[] vertices, int vertexCount, ushort[] indexList, int triangleCount, PrimitiveType pType)
        {
            IntPtr[] rawlist = new IntPtr[vertexCount];
            for (int i = 0; i < rawlist.Length; i++)
                rawlist[i] = vertices[i].Raw;
            VideoDriver_DrawVertexPrimitiveList(_raw, rawlist, vertexCount, indexList, triangleCount, VertexType.Standard, pType);
        }

        public void DrawVertexPrimitiveList(Vertex3D[] vertices, ushort[] indexList, int triangleCount, PrimitiveType pType)
        {
            DrawVertexPrimitiveList(vertices, vertices.Length, indexList, triangleCount, pType);
        }

        public void DrawVertexPrimitiveList(Vertex3D[] vertices, ushort[] indexList, PrimitiveType pType)
        {
            DrawVertexPrimitiveList(vertices, indexList, vertices.Length / 3, pType);
        }

        public void DrawVertexPrimitiveList(Vertex3D[] vertices, PrimitiveType pType)
        {
            ushort[] indexList = new ushort[vertices.Length];
            for (ushort i = 0; i < vertices.Length; i++)
                indexList[i] = i;
            DrawVertexPrimitiveList(vertices, indexList, pType);
        }

        public bool GetTextureCreationFlag(TextureCreationFlag flag)
        {
            return VideoDriver_GetTextureCreationFlag(_raw, flag);
        }

        public Matrix4 GetTransform(TransformationState state)
        {
            float[] mat = new float[16];
            VideoDriver_GetTransform(_raw, state, mat);
            return Matrix4.FromUnmanaged(mat);
        }

        public void SetTransform(TransformationState state, Matrix4 mat)
        {
            VideoDriver_SetTransform(_raw, state, mat.ToUnmanaged());
        }

        public bool QueryFeature(VideoDriverFeature feat)
        {
            return VideoDriver_QueryFeature(_raw, feat);
        }

        public void RemoveAllTextures()
        {
            VideoDriver_RemoveAllTextures(_raw);
        }

        public void RemoveTexture(Texture text)
        {
            VideoDriver_RemoveTexture(_raw, text.Raw);
        }

        public void RenameTexture(Texture text, string name)
        {
            VideoDriver_RenameTexture(_raw, text.Raw, name);
        }

        public void SetFog(Color color, FogType fogType, float start, float end, float density, bool pixelFog, bool rangeFog)
        {
            VideoDriver_SetFog(_raw, color.ToUnmanaged(), fogType, start, end, density, pixelFog, rangeFog);
        }

        public void SetMaterial(Material mat)
        {
            VideoDriver_SetMaterial(_raw, mat.Raw);
        }

        public void DeleteAllDynamicLights()
        {
            VideoDriver_DeleteAllDynamicLights(_raw);
        }

        public void SetRenderTarget(Texture target, bool clearBackBuffer, bool clearZBuffer, Color color)
        {
            VideoDriver_SetRenderTarget(_raw, GetPtr(target), clearBackBuffer, clearZBuffer, color.ToUnmanaged());
        }

        public void SetTextureFlag(TextureCreationFlag flag, bool enabled)
        {
            VideoDriver_SetTextureFlag(_raw, flag, enabled);
        }

        public Image CreateScreenShot()
        {
            return (Image)NativeElement.GetObject(VideoDriver_CreateScreenshot(_raw), typeof(Image));
        }

        public void WriteImageIntoFile(Image img, string filename)
        {
            string tempfilename = System.IO.Path.GetExtension(filename);
            tempfilename = filename.Substring(0, filename.Length - tempfilename.Length) + ".bmp";
            VideoDriver_WriteImageToFile(_raw, img.Raw, tempfilename);

            if (tempfilename == filename)
                return;

            System.Drawing.Imaging.ImageFormat fmt;
            switch (System.IO.Path.GetExtension(filename).ToLower())
            {
                case ".jpg":
                case ".jpeg":
                    fmt = System.Drawing.Imaging.ImageFormat.Jpeg;
                    break;

                case ".png":
                    fmt = System.Drawing.Imaging.ImageFormat.Png;
                    break;

                case ".gif":
                    fmt = System.Drawing.Imaging.ImageFormat.Gif;
                    break;

                case ".ico":
                    fmt = System.Drawing.Imaging.ImageFormat.Icon;
                    break;

                case ".tiff":
                    fmt = System.Drawing.Imaging.ImageFormat.Tiff;
                    break;

                case ".wmf":
                    fmt = System.Drawing.Imaging.ImageFormat.Wmf;
                    break;

                default:
                case ".bmp":
                    fmt = System.Drawing.Imaging.ImageFormat.Bmp;
                    break;
            }
            System.Drawing.Bitmap timg = new System.Drawing.Bitmap(tempfilename);
            timg.Save(filename, fmt);
            timg.Dispose();

            System.IO.File.Delete(tempfilename);
        }

        public Texture GetTextureByIndex(int index)
        {
            return (Texture)
                NativeElement.GetObject(VideoDriver_GetTextureByIndex(_raw, index), typeof(Texture));
        }

        public bool SetClipPlane(int index, Plane3Df plane, bool enable)
        {
            return VideoDriver_SetClipPlane(_raw, index, plane.ToUnmanaged(), enable);
        }

        public void EnableClipPlane(int index, bool enable)
        {
            VideoDriver_EnableClipPlane(_raw, index, enable);
        }

        /// <summary>
        /// Retrieves the FPS (Frame Per Second) Number
        /// Be careful because on the application's start it is set to 0.
        /// </summary>
        public int FPS
        {
            get
            {
                return VideoDriver_GetFPS(_raw);
            }
        }

        public Dimension2D ScreenSize
        {
            get
            {
                int[] size = new int[2];
                VideoDriver_GetScreenSize(_raw, size);
                return Dimension2D.FromUnmanaged(size);
            }
        }

        public Rect ViewPort
        {
            get
            {
                int[] viewport = new int[4];
                VideoDriver_GetViewPort(_raw, viewport);
                return Rect.FromUnmanaged(viewport);
            }
            set
            {
                VideoDriver_SetViewPort(_raw, value.ToUnmanaged());
            }
        }

        public DriverType DriverType
        {
            get { return VideoDriver_GetDriverType(_raw); }
        }

        public string Name
        {
            get { return this.DriverType.ToString(); }
        }

        public override string ToString()
        {
            return Name;
        }

        public GPUProgrammingServices GPUProgrammingServices
        {
            get
            {
                return (GPUProgrammingServices)
                    NativeElement.GetObject(VideoDriver_GetGPUProgrammingServices(_raw),
                                            typeof(GPUProgrammingServices));
            }
        }

        public int TextureCount
        {
            get
            {
                return VideoDriver_GetTextureCount(_raw);
            }
        }

        public int PrimitiveCountDrawn
        {
            get
            {
                return VideoDriver_GetPrimitiveCountDrawn(_raw);
            }
        }

        public uint AdapterVendorId
        {
            get
            {
                return CD3D9Driver_GetAdapterVendorId(_raw);
            }
        }

        public uint AdapterDeviceId
        {
            get
            {
                return CD3D9Driver_GetAdapterDeviceId(_raw);
            }
        }

        public uint AdapterSubSysId
        {
            get
            {
                return CD3D9Driver_GetAdapterSubSysId(_raw);
            }
        }

        public uint AdapterRevision
        {
            get
            {
                return CD3D9Driver_GetAdapterRevision(_raw);
            }
        }

        public int AdapterMaxTextureWidth
        {
            get
            {
                return CD3D9Driver_GetAdapterMaxTextureWidth(_raw);
            }
        }

        public int AdapterMaxTextureHeight
        {
            get
            {
                return CD3D9Driver_GetAdapterMaxTextureHeight(_raw);
            }
        }

        public int AdapterMaxActiveLights
        {
            get
            {
                return CD3D9Driver_GetAdapterMaxActiveLights(_raw);
            }
        }

        public int AdapterVertexShaderVersion
        {
            get
            {
                return CD3D9Driver_GetAdapterVertexShaderVersion(_raw);
            }
        }

        public int AdapterPixelShaderVersion
        {
            get
            {
                return CD3D9Driver_GetAdapterPixelShaderVersion(_raw);
            }
        }
        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern uint CD3D9Driver_GetAdapterVendorId(IntPtr videodriver);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern uint CD3D9Driver_GetAdapterDeviceId(IntPtr videodriver);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern uint CD3D9Driver_GetAdapterSubSysId(IntPtr videodriver);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern uint CD3D9Driver_GetAdapterRevision(IntPtr videodriver);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern int CD3D9Driver_GetAdapterMaxTextureWidth(IntPtr videodriver);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern int CD3D9Driver_GetAdapterMaxTextureHeight(IntPtr videodriver);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern int CD3D9Driver_GetAdapterMaxActiveLights(IntPtr videodriver);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern int CD3D9Driver_GetAdapterVertexShaderVersion(IntPtr videodriver);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern int CD3D9Driver_GetAdapterPixelShaderVersion(IntPtr videodriver);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr CD3D9Driver_GetAdapterDevice(IntPtr videodriver);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr CD3D9Driver_GetD3DDevice9(IntPtr videodriver);

        #region .NET Wrapper Native Code
        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern bool VideoDriver_BeginScene(IntPtr raw, bool back, bool z, int[] color);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void VideoDriver_EndScene(IntPtr raw);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void VideoDriver_EndSceneA(IntPtr raw, int window, int[] sourceRect);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr VideoDriver_AddTexture(IntPtr raw, int[] size, string name, ColorFormat fmt);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr VideoDriver_GetTexture(IntPtr raw, string name);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern int VideoDriver_GetFPS(IntPtr raw);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void VideoDriver_MakeColorKeyTexture(IntPtr videodriver, IntPtr texture, int[] colorKeyPixelPos);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void VideoDriver_MakeColorKeyTextureA(IntPtr videodriver, IntPtr texture, int[] color);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void VideoDriver_MakeNormalMapTexture(IntPtr videodriver, IntPtr texture, float amplitude);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void VideoDriver_ClearZBuffer(IntPtr videodriver);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr VideoDriver_CreateImageFromFile(IntPtr videodriver, string filename);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr VideoDriver_AddTextureFromImage(IntPtr raw, string name, IntPtr image);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr VideoDriver_CreateRenderTargetTexture(IntPtr videodriver, int[] size);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void VideoDriver_Draw2DImage(IntPtr videodriver, IntPtr texture, int[] destPos, int[] sourceRect, int[] clipRect, int[] color, bool useAlphaChannelOfTexture);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void VideoDriver_Draw2DImageA(IntPtr videodriver, IntPtr texture, int[] destPos);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void VideoDriver_Draw2DImageB(IntPtr videodriver, IntPtr texture, int[] destPos, int[] sourceRect, int[] color, bool useAlphaChannelOfTexture);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void VideoDriver_Draw2DImageC(IntPtr videodriver, IntPtr texture, int[] destPos, int[] sourceRect, int[] clipRect, int[] color1, int[] color2, int[] color3, int[] color4, bool useAlphaChannelOfTexture);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void VideoDriver_Draw2DImageD(IntPtr videodriver, IntPtr texture, int[] destPos, int[] sourceRect, int[] color1, int[] color2, int[] color3, int[] color4, bool useAlphaChannelOfTexture);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void VideoDriver_Draw2DLine(IntPtr videodriver, int[] start, int[] end, int[] color);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void VideoDriver_DrawMeshBuffer(IntPtr videodriver, IntPtr meshbuffer);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void VideoDriver_Draw2DPolygon(IntPtr videodriver, int[] center, float radius, int[] color, int vertexCount);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void VideoDriver_Draw2DRectangle(IntPtr videodriver, int[] pos, int[] colorLeftUp, int[] colorRightUp, int[] colorLeftDown, int[] colorRightDown);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void VideoDriver_Draw3DBox(IntPtr videodriver, float[] box, int[] color);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void VideoDriver_Draw3DLine(IntPtr videodriver, float[] start, float[] end, int[] color);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void VideoDriver_Draw3DTriangle(IntPtr videodriver, float[] tri, int[] color);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void VideoDriver_GetScreenSize(IntPtr videodriver, [MarshalAs(UnmanagedType.LPArray)] int[] size);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void VideoDriver_DrawIndexedTriangleList(IntPtr driver, IntPtr[] vertices, int vertexCount, ushort[] indexList, int triangleCount);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void VideoDriver_DrawIndexedTriangleListA(IntPtr driver, IntPtr[] vertices, int vertexCount, ushort[] indexList, int triangleCount);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void VideoDriver_DrawIndexedTriangleListT(IntPtr driver, IntPtr[] vertices, int vertexCount, ushort[] indexList, int triangleCount);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void VideoDriver_DrawIndexedTriangleFanA(IntPtr driver, IntPtr[] vertices, int vertexCount, ushort[] indexList, int triangleCount);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void VideoDriver_DrawIndexedTriangleFanT(IntPtr driver, IntPtr[] vertices, int vertexCount, ushort[] indexList, int triangleCount);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void VideoDriver_DrawIndexedTriangleFan(IntPtr driver, IntPtr[] vertices, int vertexCount, ushort[] indexList, int triangleCount);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void VideoDriver_DrawVertexPrimitiveList(IntPtr videodriver, IntPtr[] vertices, int vertexCount, ushort[] indexList, int triangleCount, VertexType vType, PrimitiveType pType);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern DriverType VideoDriver_GetDriverType(IntPtr videodriver);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern bool VideoDriver_GetTextureCreationFlag(IntPtr videodriver, TextureCreationFlag flag);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void VideoDriver_GetViewPort(IntPtr videodriver, [MarshalAs(UnmanagedType.LPArray)] int[] viewport);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void VideoDriver_GetTransform(IntPtr videodriver, TransformationState state, [MarshalAs(UnmanagedType.LPArray)] float[] mat);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void VideoDriver_SetTransform(IntPtr videodriver, TransformationState state, float[] mat);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern bool VideoDriver_QueryFeature(IntPtr videodriver, VideoDriverFeature feat);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void VideoDriver_RemoveAllTextures(IntPtr videodriver);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void VideoDriver_RemoveTexture(IntPtr videodriver, IntPtr texture);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void VideoDriver_RenameTexture(IntPtr videodriver, IntPtr texture, string name);

        [Obsolete("This has been moved to SceneManager")]
        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void VideoDriver_SetAmbientLight(IntPtr videodriver, float[] ambient);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void VideoDriver_SetFog(IntPtr videodriver, int[] color, FogType fogType, float start, float end, float density, bool pixel, bool range);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void VideoDriver_SetMaterial(IntPtr videodriver, IntPtr material);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void VideoDriver_SetRenderTarget(IntPtr videodriver, IntPtr texture, bool cBB, bool cZB, int[] color);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void VideoDriver_SetTextureFlag(IntPtr videodriver, TextureCreationFlag flag, bool enabled);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void VideoDriver_SetViewPort(IntPtr videodriver, int[] viewport);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr VideoDriver_GetGPUProgrammingServices(IntPtr videodriver);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void VideoDriver_DeleteAllDynamicLights(IntPtr videodriver);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr VideoDriver_CreateScreenshot(IntPtr videodriver);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern void VideoDriver_WriteImageToFile(IntPtr videodriver, IntPtr image, string filename);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern int VideoDriver_GetTextureCount(IntPtr videodriver);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern IntPtr VideoDriver_GetTextureByIndex(IntPtr videodriver, int index);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern int VideoDriver_GetPrimitiveCountDrawn(IntPtr videodriver);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern bool VideoDriver_SetClipPlane(IntPtr videodriver, int index, float[] plane, bool enable);

        [DllImport(Native.Dll), SuppressUnmanagedCodeSecurity]
        static extern int VideoDriver_EnableClipPlane(IntPtr videodriver, int index, bool enable);

        #endregion
    }

    public enum TextureCreationFlag
    {
        Always16Bit = 0x00000001,
        Always32Bit = 0x00000002,
        OptimizedForQuality = 0x00000004,
        OptimizedForSpeed = 0x00000008,
        CreateMipMaps = 0x00000010,
        NoAlphaChannel = 0x00000020,
        AllowNonPower2 = 0x00000040
    }

    public enum VideoDriverFeature
    {
        RenderToTarget = 0,
        HardwareTL,
        MultiTexture,
        BilnearFilter,
        MipMap,
        MipAutoUpdate,
        StencilBuffer,
        VertexShader_1_1,
        VertexShader_2_0,
        VertexShader_3_0,
        PixelShader_1_1,
        PixelShader_1_2,
        PixelShader_1_3,
        PixelShader_1_4,
        PixelShader_2_0,
        PixelShader_3_0,
        ARB_VertexProgram_1,
        ARB_FragmentProgram_1,
        ARB_GLSL,
        HLSL,
        TextureNSQUARE,
        TextureNPOT,
        FrameBufferObject,
        VertexBufferObject,
        AlphaToCoverage,
        ColorMask,
        MultipleRenderTargets,
        MultipleRenderTargetBlend,
        MultipleRenderTargetMask,
        MultipleRenderTargetBlendFunc,
        GeometryShaders,
        Count
    }

    public enum TransformationState
    {
        View,
        World,
        Projection,
        Texture1,
        Texture2,
        Texture3,
        Texture4,
        Count // Don't use
    }

    public enum PrimitiveType
    {
        Points = 0,
        LineStrip,
        LineLoop,
        Lines,
        TriangleStrip,
        TriangleFan,
        Triangles,
        QuadStrip,
        Quads,
        Polygon,
        PointSprites
    }

    public enum FogType
    {
        Exponential = 0,
        Linear,
        Exponential2
    }
}
