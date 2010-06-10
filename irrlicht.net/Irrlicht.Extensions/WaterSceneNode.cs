using System;
using IrrlichtNETCP;
using IrrlichtNETCP.Inheritable;
//Made by DeusXL, A lot of thanks to peter for giving the HLSL translation on the forum !
namespace IrrlichtNETCP.Extensions
{
    public class WaterSceneNode : ISceneNode
    {
        static int _current = 0;

        VideoDriver _driver;
        SceneManager _scene;
        SceneNode _waternode;
        Texture _rt;
        CameraSceneNode _fixedcam;

        public WaterSceneNode(SceneNode parent, SceneManager mgr, Dimension2Df tileSize, Dimension2D tileCount) :
            this(parent, mgr, tileSize, tileCount, new Dimension2D(256, 256), -1)
        { }

        public WaterSceneNode(SceneNode parent, SceneManager mgr, Dimension2Df tileSize, Dimension2D tileCount, Dimension2D precision) :
            this(parent, mgr, tileSize, tileCount, precision, -1)
        { }

        public WaterSceneNode(SceneNode parent, SceneManager mgr, Dimension2Df tileSize,
                              Dimension2D tileCount, Dimension2D precision, int id) :
            base(parent, mgr, id)
        {
            _scene = mgr;
            _driver = mgr.VideoDriver;

            AnimatedMesh wmesh = _scene.AddHillPlaneMesh("watermesh" + _current,
                tileSize,
                tileCount, 0,
                new Dimension2Df(0, 0),
                new Dimension2Df(1, 1));
            _current++;

            int dmat = (int)MaterialType.Reflection2Layer;
            if (_driver.DriverType == DriverType.OpenGL)
                dmat = _driver.GPUProgrammingServices.AddHighLevelShaderMaterial(
                 WATER_VERTEX_GLSL, "main", VertexShaderType._1_1, WATER_FRAGMENT_GLSL,
                 "main", PixelShaderType._1_1, OnShaderSet, MaterialType.TransparentAlphaChannel, 0);
            else
                dmat = _driver.GPUProgrammingServices.AddHighLevelShaderMaterial(
                 WATER_HLSL, "vertexMain", VertexShaderType._2_0, WATER_HLSL,
                 "pixelMain", PixelShaderType._2_0, OnShaderSet, MaterialType.TransparentAlphaChannel, 2);

            if (_driver.DriverType == DriverType.OpenGL)
                ClampShader = _driver.GPUProgrammingServices.AddHighLevelShaderMaterial(
                 CLAMP_VERTEX_GLSL, "main", VertexShaderType._1_1, CLAMP_FRAGMENT_GLSL,
                 "main", PixelShaderType._1_1, OnShaderSet, MaterialType.TransparentAlphaChannel, 1);
            else
                ClampShader = _driver.GPUProgrammingServices.AddHighLevelShaderMaterial(
                 CLAMP_HLSL, "vertexMain", VertexShaderType._2_0, CLAMP_HLSL,
                 "pixelMain", PixelShaderType._2_0, OnShaderSet, MaterialType.TransparentAlphaChannel, 3);

            _waternode = _scene.AddMeshSceneNode(wmesh.GetMesh(0), this, -1);
            _waternode.SetMaterialType(dmat);
            _waternode.SetMaterialFlag(MaterialFlag.BackFaceCulling, false);
            _waternode.SetMaterialFlag(MaterialFlag.Lighting, false);
            _waternode.SetMaterialFlag(MaterialFlag.FogEnable, false);

            _rt = _driver.CreateRenderTargetTexture(precision);
            _waternode.SetMaterialTexture(0, _rt);

            CameraSceneNode oldcam = _scene.ActiveCamera;
            _fixedcam = _scene.AddCameraSceneNode(null);
            if (oldcam != null)
                _scene.ActiveCamera = oldcam;
        }

        public SceneNode WaterNode
        {
            get
            {
                return _waternode;
            }
        }

        public override Box3D BoundingBox
        {
            get
            {
                return WaterNode.BoundingBox;
            }
        }

        public void Update()
        {
            if (!Visible || !_scene.ActiveCamera.ViewFrustum.BoundingBox.IntersectsWithBox(TransformedBoundingBox))
                return;
            foreach (TerrainSceneNode terr in clampList)
                if (terr != null)
                    terr.SetMaterialType(ClampShader);

            _waternode.Visible = false;
            CameraSceneNode camera = _scene.ActiveCamera;

            _scene.ActiveCamera = _fixedcam;
            _fixedcam.FarValue = camera.FarValue;
            if (camera.Position.Y >= Position.Y)
            {
                _fixedcam.Position = new Vector3D(camera.Position.X,
                                                 2 * Position.Y - camera.Position.Y,
                                                 camera.Position.Z);
                Vector3D target = ((camera.Target - camera.Position).Normalize());
                target.Y *= -1;
                _fixedcam.Target = _fixedcam.Position + target * 20000;
                _fixedcam.UpVector = camera.UpVector;
            }
            else
            {
                _fixedcam.Position = camera.Position;

                Vector3D target = ((camera.Target - camera.Position).Normalize()) * 200000;
                _fixedcam.Target = _fixedcam.Position + target;
                _fixedcam.UpVector = camera.UpVector;
            }
            _driver.SetRenderTarget(_rt, true, true, Color.TransparentGray);
            try
            {
                _scene.DrawAll();
            }
            catch (AccessViolationException)
            {
#if !QUIET
                System.Console.WriteLine("Unable to update water reflection this round due to an access violation");
#endif
            }

            foreach (TerrainSceneNode terr in clampList)
                if (terr != null)
                    terr.SetMaterialType(MaterialType.DetailMap);
            _driver.SetRenderTarget(null, true, true, Color.Gray);
            _scene.ActiveCamera = camera;
            _waternode.Visible = true;
        }
        static int ClampShader;
        System.Collections.ArrayList clampList = new System.Collections.ArrayList();
        public void ApplyClampingOnTerrain(TerrainSceneNode terrain)
        {
            clampList.Add(terrain);
        }

        public Colorf AddedColor = Colorf.From(1f, 0.01f, 0.01f, 0.11f);
        public Colorf MultiColor = Colorf.From(1f, 0.74f, 0.74f, 0.82f);
        public float WaveHeight = 3f;
        public float WaveLength = 50f;
        public float WaveSpeed = 10f;
        public float WaveDisplacement = 7f;
        public float WaveRepetition = 5f;
        public float RefractionFactor = 0.8f;
        void OnShaderSet(MaterialRendererServices services, int userData)
        {
            if (userData == 2 || userData == 3) //All DirectX Shaders
            {
                Matrix4 worldViewProj;
                worldViewProj = _driver.GetTransform(TransformationState.Projection);
                worldViewProj *= _driver.GetTransform(TransformationState.View);
                worldViewProj *= _driver.GetTransform(TransformationState.World);
                services.SetVertexShaderConstant("mWorldViewProj", worldViewProj.ToShader());
            }
            if (userData == 1 || userData == 3) //Clamp Shaders
            {
                if (userData == 1) //OpenGL Clamp Shader
                {
                    services.SetPixelShaderConstant("DiffuseMap", 0f);
                    services.SetPixelShaderConstant("DetailMap", 1f);
                }
                services.SetPixelShaderConstant("WaterPositionY", WaterNode.Position.Y);
                return;
            }
            //Water Shaders
            float time = (float)((DateTime.Now.TimeOfDay.TotalMilliseconds));
            services.SetVertexShaderConstant("Time", time);
            services.SetVertexShaderConstant("WaveHeight", WaveHeight);
            services.SetVertexShaderConstant("WaveLength", WaveLength);
            services.SetVertexShaderConstant("WaveSpeed", WaveSpeed);

            services.SetPixelShaderConstant("AddedColor", AddedColor.ToShader());
            services.SetPixelShaderConstant("MultiColor", MultiColor.ToShader());
            services.SetPixelShaderConstant("WaveDisplacement", WaveDisplacement);
            services.SetPixelShaderConstant("WaveRepetition", WaveRepetition);
            services.SetPixelShaderConstant("RefractionFactor", RefractionFactor);
            services.SetPixelShaderConstant("UnderWater", IsUnderwater(_scene.ActiveCamera) ? 1.0f : 0.0f);
        }

        public bool IsUnderwater(SceneNode node)
        {
            return node.AbsolutePosition.Y < AbsolutePosition.Y;
        }

        #region Shaders
        static string WATER_VERTEX_GLSL =
                        "uniform float Time;\n" +
                        "uniform float WaveHeight, WaveLength, WaveSpeed;\n" +
                        "varying vec4 waterpos;\n" +
                        "varying float addition;\n" +
                        "void main()\n" +
                        "{\n" +
                        "    waterpos = ftransform();\n" +
                        "    addition = (sin((gl_Vertex.x/WaveLength) + (Time * WaveSpeed / 10000.0))) +\n" +
                        "              (cos((gl_Vertex.z/WaveLength) + (Time * WaveSpeed / 10000.0)));\n" +
                        "    waterpos.y += addition * WaveHeight;\n" +
                        "    gl_Position = waterpos;\n" +
                        "}\n";
        static string WATER_FRAGMENT_GLSL =
                        "uniform sampler2D ReflectionTexture;\n" +
                        "uniform vec4 AddedColor, MultiColor;\n" +
                        "uniform float UnderWater, WaveDisplacement, WaveRepetition, RefractionFactor;\n" +
                        "varying vec4 waterpos;\n" +
                        "varying float addition;\n" +
                        "void main()\n" +
                        "{\n" +
                        "    vec4 projCoord = waterpos / waterpos.w;\n" +
                        "    projCoord += vec4(1.0);\n" +
                        "    projCoord *= 0.5;\n" +
                        "    projCoord.x += sin(addition * WaveRepetition) * (WaveDisplacement / 1000.0);\n" +
                        "    projCoord.y += cos(addition * WaveRepetition) * (WaveDisplacement / 1000.0);\n" +
                        "    projCoord = clamp(projCoord, 0.001, 0.999);\n" +
                        "    if(UnderWater == 0.0)\n" +
                        "        projCoord.y = 1.0 - projCoord.y;\n" +
                        "    vec4 refTex = texture2D(ReflectionTexture, vec2(projCoord));\n" +
                        "    refTex = (refTex + AddedColor) * MultiColor;\n" +
                        "    gl_FragColor = refTex;\n" +
                        "    if(UnderWater == 1.0)\n" +
                        "   {\n" +
                        "        gl_FragColor *= (MultiColor / 1.1);\n" +
                        "       gl_FragColor.a = 0.7;" +
                        "   }\n" +
                        "   else\n" +
                        "       gl_FragColor.a = RefractionFactor;" +
                        "}\n";
        static string WATER_HLSL =
                        "uniform float Time;\n" +
                        "float4x4 mWorldViewProj;\n" +
                        "float WaveHeight;\n" +
                        "float WaveLength;\n" +
                        "float WaveSpeed;\n" +
                        "float4 AddedColor;\n" +
                        "float4 MultiColor;\n" +
                        "float UnderWater;\n" +
                        "float WaveDisplacement;\n" +
                        "float WaveRepetition;\n" +
                        "float RefractionFactor;\n" +
                        "struct VS_OUTPUT\n" +
                        "{\n" +
                        "    float4 Position : POSITION;\n" +
                        "    float4 TexCoord : TEXCOORD0;\n" +
                        "    float  Addition : TEXCOORD1;\n" +
                        "};\n" +
                        "VS_OUTPUT vertexMain( float4 vPosition : POSITION,\n" +
                        "                      float2 texCoord : TEXCOORD0 )\n" +
                        "{\n" +
                        "    VS_OUTPUT Output;\n" +
                        "   Output.Position = mul( vPosition, mWorldViewProj );\n" +
                        "   Output.Addition = ( sin( ( vPosition.x / WaveLength ) + ( Time * WaveSpeed / 10000.0 ) ) ) +\n" +
                        "                 ( cos( ( vPosition.z / WaveLength ) + ( Time * WaveSpeed / 10000.0 ) ) );\n" +
                        "   Output.TexCoord = Output.Position;\n" +
                        "   Output.TexCoord.y += Output.Addition * WaveHeight;\n" +
                        "   return Output;\n" +
                        "}\n" +
                        "struct PS_OUTPUT\n" +
                        "{\n" +
                        "    float4 RGBColor : COLOR0;\n" +
                        "};\n" +
                        "texture ReflectionTexture;\n" +
                        "sampler MySampler = sampler_state\n" +
                        "{\n" +
                        "    Texture = ReflectionTexture;\n" +
                        "    AddressU = CLAMP;\n" +
                        "    AddressV = CLAMP;\n" +
                        "};\n" +
                        "PS_OUTPUT pixelMain( VS_OUTPUT In )\n" +
                        "{\n" +
                        "   PS_OUTPUT Output;\n" +
                        "   float4 projCoord = In.TexCoord / In.TexCoord.w;\n" +
                        "   projCoord += float4( 1.0, 1.0, 1.0, 1.0 );\n" +
                        "   projCoord *= 0.5;\n" +
                        "   projCoord.x += sin( In.Addition * WaveRepetition ) * ( WaveDisplacement / 1000.0 );\n" +
                        "   projCoord.y += cos( In.Addition * WaveRepetition ) * ( WaveDisplacement / 1000.0 );\n" +
                        "   projCoord = clamp( projCoord, 0.001, 0.999 );\n" +
                        "   if( UnderWater == 1.0 )\n" +
                        "      projCoord.y = 1.0 - projCoord.y;\n" +
                        "   float4 refTex = tex2D( MySampler, projCoord );\n" +
                        "   refTex = (refTex + AddedColor) * MultiColor;\n" +
                        "   Output.RGBColor = refTex;\n" +
                        "   if( UnderWater == 1.0 )\n" +
                        "      Output.RGBColor *= (MultiColor / 1.1); \n" +
                        "   Output.RGBColor.a = RefractionFactor;\n" +
                        "   return Output;\n" +
                        "}";
        static string CLAMP_VERTEX_GLSL =
                        "varying float cutoff;\n" +
                        "void main()\n" +
                        "{\n" +
                        "    cutoff = gl_Vertex.y;\n" +
                        "    gl_Position = ftransform();\n" +
                        "    gl_TexCoord[0] = gl_MultiTexCoord0;\n" +
                        "}\n";
        static string CLAMP_FRAGMENT_GLSL =
                        "uniform sampler2D DiffuseMap, DetailMap;\n" +
                        "uniform float WaterPositionY;\n" +
                        "varying float cutoff;\n" +
                        "void main()\n" +
                        "{\n" +
                        "    vec4 color = texture2D(DiffuseMap, gl_TexCoord[0].st) * 2.0 *\n" +
                        "                texture2D(DetailMap, vec2(gl_TexCoord[0].s * 20.0, gl_TexCoord[0].t * 20.0));\n" +
                        "    if(cutoff <= (WaterPositionY - 10.0))\n" +
                        "        color.a = 0.0;\n" +
                        "    else\n" +
                        "        color.a = 1.0;\n" +
                        "    gl_FragColor = color; \n" +
                        "}\n";

        static string CLAMP_HLSL =
                        "uniform float Time;\n" +
                        "float4x4 mWorldViewProj;\n" +
                        "float WaterPositionY;\n" +
                        "struct VS_OUTPUT\n" +
                        "{\n" +
                        "    float4 Position : POSITION;\n" +
                        "    float4 Diffuse : COLOR0;\n" +
                        "    float2 TexCoord : TEXCOORD0;\n" +
                        "    float2 TexCoord1 : TEXCOORD1;\n" +
                        "};\n" +
                        "VS_OUTPUT vertexMain( in float4 vPosition : POSITION,\n" +
                        "                      in float3 vNormal : NORMAL,\n" +
                        "                      float2 texCoord : TEXCOORD0,\n" +
                        "                      float2 texCoord1 : TEXCOORD1)\n" +
                        "{\n" +
                        "    VS_OUTPUT Output;\n" +
                        "    Output.Position = mul(vPosition, mWorldViewProj);\n" +
                        "    Output.Diffuse = vPosition;\n" +
                        "    Output.TexCoord = texCoord;\n" +
                        "    Output.TexCoord1 = texCoord1;\n" +
                        "    return Output;\n" +
                        "}\n" +
                        "struct PS_OUTPUT\n" +
                        "{\n" +
                        "    float4 RGBColor : COLOR0;\n" +
                        "};\n" +
                        "sampler2D DiffuseMap;\n" +
                        "sampler2D DetailMap;\n" +
                        "PS_OUTPUT pixelMain( float2 TexCoord : TEXCOORD0,\n" +
                        "                     float2 TexCoord1 : TEXCOORD1,\n" +
                        "                     float4 Position : POSITION,\n" +
                        "                     float4 Diffuse : COLOR0 )\n" +
                        "{\n" +
                        "    PS_OUTPUT Output;\n" +
                        "    float4 color = tex2D(DiffuseMap, TexCoord) * 2.0f *\n" +
                        "                   tex2D(DetailMap, float2(TexCoord1.x * 20.0f, TexCoord1.y * 20.0f));\n" +
                        "    if(Diffuse.y <= WaterPositionY)\n" +
                        "        color.a = 0.0;\n" +
                        "    else\n" +
                        "        color.a = 1.0;\n" +
                        "    Output.RGBColor = color;\n" +
                        "    return Output;\n" +
                        "}";
        #endregion
    }
}
