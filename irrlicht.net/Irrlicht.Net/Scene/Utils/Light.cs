namespace IrrlichtNET
{
    public struct Light
    {
        public Colorf AmbientColor;
        public Colorf DiffuseColor;
        public Colorf SpecularColor;
        public Vector3D Position;
        public float Radius;
        public LightType Type;
        public bool CastShadows;
        public Vector3D Attenuation;
        public Vector3D Direction;
        public float Falloff;
        public float InnerCone;
        public float OuterCone;
    }

    public enum LightType
    {
        Point,
        Spot,
        Directional
    }
}
