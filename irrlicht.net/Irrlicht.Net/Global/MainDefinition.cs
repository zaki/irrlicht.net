namespace IrrlichtNET
{
    public class Native
    {
#if DEBUG
        public const string Dll = @"IrrlichtWd";
#else
        public const string Dll = @"IrrlichtW";
#endif
    }

    public enum DriverType
    {
        Null,
        Software,
        Software2,
        Direct3D8,
        Direct3D9,
        OpenGL
    }

    public enum ColorFormat
    {
        A1R5G5B5,
        R5G6B5,
        R8G8B8,
        A8R8G8B8,
        R16F,
        G16R16F,
        A16B16G16R16F,
        R32F,
        G32R32F,
        A32B32G32R32F,
        Unknown
    }

    public enum MaterialType
    {
        Solid,
        Solid2Layer,
        Lightmap,
        LightmapAdd,
        LightmapM2,
        LightmapM4,
        LightmapLighting,
        LightmapLightingM2,
        LightmapLightingM4,
        DetailMap,
        SphereMap,
        Reflection2Layer,
        TransparentAddColor,
        TransparentAlphaChannel,
        TransparentAlphaChannelRef,
        TransparentVertexAlpha,
        TransparentReflection2Layer,
        NormalMapSolid,
        NormalMapTransparentAddColor,
        NormalMapTransparentVertexAlpha,
        ParallaxMapSolid,
        ParallaxMapTransparentAddColor,
        ParallaxMapTransparentVertexAlpha,
        OneTextureBlend,
    }

    public enum MaterialFlag
    {
        Wireframe = 0x1,
        PointCloud = 0x2,
        GouraudShading = 0x4,
        Lighting = 0x8,
        ZBuffer = 0x10,
        ZWriteEnable = 0x20,
        BackFaceCulling = 0x40,
        FrontFaceCulling = 0x80,
        BilinearFilter = 0x100,
        TrilinearFilter = 0x200,
        AnisotropicFilter = 0x400,
        FogEnable = 0x800,
        NormalizeNormals = 0x1000,
        TextureWrap = 0x2000,
        AntiAliasing = 0x4000,
        ColorMask = 0x8000,
        ColorMaterial = 0x10000,
        MaterialFlagCount = 17 //Do not use
    }

    public enum SceneNodeRenderPass
    {
        None = 0,
        Camera = 1,
        Light = 2,
        SkyBox = 4,
        Automatic = 24,
        Solid = 8,
        Shadow = 64,
        Transparent = 16,
        TransparentEffect = 32,
        Shader0,
        Shader1,
        Shader2,
        Shader3,
        Shader4,
        Shader5,
        Shader6,
        Shader7,
        Shader8,
        Shader9,
        Shader10,
        Count = 20 //Do not use
    }

    public enum SceneNodeType
    {
        Cube = ('c' | 'u' << 8 | 'b' << 16 | 'e' << 24),
        Sphere = ('s' | 'p' << 8 | 'h' << 16 | 'r' << 24),
        Text = ('t' | 'e' << 8 | 'x' << 16 | 't' << 24),
        WaterSurface = ('w' | 'a' << 8 | 't' << 16 | 'r' << 24),
        Terrain = ('t' | 'e' << 8 | 'r' << 16 | 'r' << 24),
        SkyBox = ('s' | 'k' << 8 | 'y' << 16 | '_' << 24),
        ShadowVolume = ('s' | 'h' << 8 | 'd' << 16 | 'w' << 24),
        OctTree = ('o' | 'c' << 8 | 't' << 16 | 'r' << 24),
        Mesh = ('m' | 'e' << 8 | 's' << 16 | 'h' << 24),
        Light = ('l' | 'g' << 8 | 'h' << 16 | 't' << 24),
        Empty = ('e' | 'm' << 8 | 't' << 16 | 'y' << 24),
        DummyTransformation = ('d' | 'm' << 8 | 'm' << 16 | 'y' << 24),
        Camera = ('c' | 'a' << 8 | 'm' << 16 | '_' << 24),
        CameraMaya = ('c' | 'a' << 8 | 'm' << 16 | 'M' << 24),
        CameraFPS = ('c' | 'a' << 8 | 'm' << 16 | 'F' << 24),
        Billboard = ('b' | 'i' << 8 | 'l' << 16 | 'l' << 24),
        AnimatedMesh = ('a' | 'm' << 8 | 's' << 16 | 'h' << 24),
        ParticleSystem = ('p' | 't' << 8 | 'c' << 16 | 'l' << 24),
        MD3SceneNode = ('m' | 'd' << 8 | '3' << 16 | '_' << 24),
        Unknown = ('u' | 'n' << 8 | 'k' << 16 | 'n' << 24),
        Count
    }

    public enum TerrainPatchSize
    {
        TPS9 = 9,
        TPS17 = 17,
        TPS33 = 33,
        TPS65 = 65,
        TPS129 = 129
    }
}
