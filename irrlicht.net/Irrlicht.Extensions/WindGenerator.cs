using System;
using IrrlichtNET;
using IrrlichtNET.Inheritable;

namespace IrrlichtNET.Extensions
{
    public class WindGenerator
    {
        public WindGenerator()
        {
        }

        public static WindGenerator CreateWindGenerator(float strength, float regularity)
        {
            WindGenerator wind = new WindGenerator();
            wind.Strength = strength;
            wind.Regularity = regularity;
            return wind;
        }

        float _strength;
        public float Strength { get { return _strength; } set { _strength = value; } }
        float _regularity;
        public float Regularity { get { return _regularity; } set { _regularity = value; } }

        public Vector2D Wind(Vector3D position, uint timeMs)
        {
            float seed = (timeMs + position.X * 7 * fcos(timeMs / 120000.0f) + position.Z * 7 * fsin(timeMs / 120000.0f)) / 1000.0f;
            float dir = 2 * NewMath.PI * noise(seed / Regularity);
            float amp = Strength * fsin(seed);

            return new Vector2D(amp * fcos(dir), amp * fsin(dir));
        }

        #region Private Methods
        float rndGenerator(int x)
        {
            x = (x << 13) ^ x;
            return (1f - ((x * (x * x * 15731 + 789221) + 1376312589) & 0x7fffffff) / 1073741824.0f);
        }

        float fcos(float f)
        {
            return NewMath.FCos(f);
        }

        float fsin(float f)
        {
            return NewMath.FSin(f);
        }

        float cosInterpolater(float a, float b, float x)
        {
            float ft = x * NewMath.PI;
            float f = (1 - (fcos(ft))) * .5f;
            return a * (1 - f) + b * f;
        }

        float windSmoother(int x)
        {
            return rndGenerator(x) / 2 + rndGenerator(x - 1) / 4 + rndGenerator(x + 1) / 4;
        }

        float noiseInterpolate(float x)
        {
            int intX = (int)(x);
            float fracX = x - intX;

            float v1 = windSmoother(intX);
            float v2 = windSmoother(intX + 1);

            return cosInterpolater(v1, v2, fracX);
        }

        float noise(float x)
        {
            float total = 0;
            float p = 0.50f;
            const int n = 4;
            float frequency = 1;
            float amplitude = 1;

            for (int i = 0; i < n; i++)
            {
                total += noiseInterpolate(x * frequency) * amplitude;

                frequency = frequency + frequency;
                amplitude *= p;
            }
            return total;
        }
        #endregion
    }
}
