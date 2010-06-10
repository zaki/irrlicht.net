using System;

namespace IrrlichtNETCP
{
    public struct Color
    {
        public Color(int a, int r, int g, int b)
        {
            A = a;
            R = r;
            G = g;
            B = b;
        }

        public int A, R, G, B;
        public void Set(int a, int r, int g, int b)
        {
            A = a;
            R = r;
            G = g;
            B = b;
        }

        public static Color From(int a, int r, int g, int b)
        {
            Color c;
            c.A = a;
            c.R = r;
            c.G = g;
            c.B = b;
            return c;
        }

        public int NativeColor
        {
            get
            {
                return ((A & 0xff) << 24) |
                       ((R & 0xff) << 16) |
                       ((G & 0xff) << 8) |
                        (B & 0xff);
            }
            set
            {
                A = (value >> 24) & 0xff;
                R = (value >> 16) & 0xff;
                G = (value >> 8) & 0xff;
                B = (value) & 0xff;
            }
        }

        /// <summary>
        /// Gets and Sets an standard .NET color from the current Irrlicht color.
        /// </summary>
        /// <returns>The .NET color</returns>
        /// <value> The .NET color</value>
        public System.Drawing.Color dotNETColor
        {
            get { return System.Drawing.Color.FromArgb(A, R, G, B); }
            set { A = value.A; R = value.R; G = value.G; B = value.G; }
        }

        /// <summary>
        /// Makes an Irrlicht color from a standard .NET color.
        /// </summary>
        /// <param name="bcl">The standard .NET color</param>
        /// <returns>The Irrlicht color</returns>
        public static Color FromBCL(System.Drawing.Color bcl)
        {
            return new Color(bcl.A, bcl.R, bcl.G, bcl.B);
        }

        public int[] ToUnmanaged() { return new int[] { A, R, G, B }; }
        public float[] ToShader() { return new float[] { (float)R / 255f, (float)G / 255f, (float)B / 255f, (float)A / 255f }; }
        public static Color FromUnmanaged(int[] un) { return From(un[0], un[1], un[2], un[3]); }
        public override string ToString()
        {
            return "\"Type = " + GetType() + "; A = " + A + "; R = " + R + "; G = " + G + "; B = " + B + "\"";
        }
        public override bool Equals(object o)
        {
            if (o is Color)
                return GetHashCode() == o.GetHashCode();
            return base.Equals(o);
        }

        public static bool operator ==(Color first, Color other)
        {
            return first.Equals(other);
        }

        public static bool operator !=(Color first, Color other)
        {
            return !first.Equals(other);
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        public uint getLuminance()
        {
            return (uint)(0.3f * R + 0.59f * G + 0.11f * B);
        }

        public static explicit operator Color(Colorf c)
        {
            return new Color((int)(c.A * 255f), (int)(c.R * 255f), (int)(c.G * 255f), (int)(c.B * 255f));
        }
        #region Premade Colors
        public static Color Red = new Color(255, 255, 0, 0);
        public static Color Green = new Color(255, 0, 255, 0);
        public static Color Blue = new Color(255, 0, 0, 255);
        public static Color Black = new Color(255, 0, 0, 0);
        public static Color White = new Color(255, 255, 255, 255);
        public static Color Yellow = new Color(255, 255, 255, 0);
        public static Color Purple = new Color(255, 255, 0, 255);
        public static Color Gray = new Color(255, 100, 100, 100);
        public static Color TransparentRed = new Color(0, 255, 0, 0);
        public static Color TransparentGreen = new Color(0, 0, 255, 0);
        public static Color TransparentBlue = new Color(0, 0, 0, 255);
        public static Color TransparentBlack = new Color(0, 0, 0, 0);
        public static Color TransparentWhite = new Color(0, 255, 255, 255);
        public static Color TransparentYellow = new Color(0, 255, 255, 0);
        public static Color TransparentPurple = new Color(0, 255, 0, 255);
        public static Color TransparentGray = new Color(0, 100, 100, 100);
        #endregion
    }

    public struct Colorf
    {
        public Colorf(float a, float r, float g, float b)
        {
            A = a;
            R = r;
            G = g;
            B = b;
        }

        public float A, R, G, B;
        public void Set(float a, float r, float g, float b)
        {
            A = a;
            R = r;
            G = g;
            B = b;
        }

        public static Colorf From(float a, float r, float g, float b)
        {
            Colorf c;
            c.A = a;
            c.R = r;
            c.G = g;
            c.B = b;
            return c;
        }

        /// <summary>
        /// Gets an standard .NET color from the current Irrlicht color.
        /// </summary>
        /// <returns>The .NET color</returns>
        /// <value>The .NET color</value>
        public System.Drawing.Color dotNETColor
        {
            get { return System.Drawing.Color.FromArgb((int)(A * 255f), (int)(R * 255f), (int)(G * 255f), (int)(B * 255f)); }
            set { A = value.A / 255f; R = value.R / 255f; G = value.G / 255f; B = value.G / 255f; }

        }

        /// <summary>
        /// Makes an Irrlicht color from a standard .NET color.
        /// </summary>
        /// <param name="bcl">The standard .NET color</param>
        /// <returns>The Irrlicht color</returns>
        public static Colorf FromBCL(System.Drawing.Color bcl)
        {
            return new Colorf((float)bcl.A / 255f, (float)bcl.R / 255f, (float)bcl.G / 255f, (float)bcl.B / 255f);
        }

        public float[] ToUnmanaged() { return new float[] { R, G, B, A }; }
        public float[] ToShader() { return new float[] { R, G, B, A }; }
        public static Colorf FromUnmanaged(float[] un) { return From(un[0], un[1], un[2], un[3]); }
        public override string ToString()
        {
            return "\"Type = " + GetType() + "; A = " + A + "; R = " + R + "; G = " + G + "; B = " + B + "\"";
        }
        public override bool Equals(object o)
        {
            if (o is Colorf)
                return GetHashCode() == o.GetHashCode();
            return base.Equals(o);
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        public uint Luminance
        {
            get
            {
                return (uint)(0.3f * R * 255f + 0.59f * G * 255f + 0.11f * B * 255f);
            }
        }
        public static explicit operator Colorf(Color c)
        {
            return new Colorf(c.A / 255f, c.R / 255f, c.G / 255f, c.B / 255f);
        }
        #region Premade Colors
        public static Colorf Red = new Colorf(1.0f, 1.0f, 0.0f, 0.0f);
        public static Colorf Green = new Colorf(1.0f, 0.0f, 1.0f, 0.0f);
        public static Colorf Blue = new Colorf(1.0f, 0.0f, 0.0f, 1.0f);
        public static Colorf Black = new Colorf(1.0f, 0.0f, 0.0f, 0.0f);
        public static Colorf White = new Colorf(1.0f, 1.0f, 1.0f, 1.0f);
        public static Colorf Yellow = new Colorf(1.0f, 1.0f, 1.0f, 0.0f);
        public static Colorf Purple = new Colorf(1.0f, 1.0f, 0.0f, 1.0f);
        public static Colorf Gray = new Colorf(1.0f, 0.39f, 0.39f, 0.39f);
        public static Colorf TransparentRed = new Colorf(0.0f, 1.0f, 0.0f, 0.0f);
        public static Colorf TransparentGreen = new Colorf(0.0f, 0.0f, 1.0f, 0.0f);
        public static Colorf TransparentBlue = new Colorf(0.0f, 0.0f, 0.0f, 1.0f);
        public static Colorf TransparentBlack = new Colorf(0.0f, 0.0f, 0.0f, 0.0f);
        public static Colorf TransparentWhite = new Colorf(0.0f, 1.0f, 1.0f, 1.0f);
        public static Colorf TransparentYellow = new Colorf(0.0f, 1.0f, 1.0f, 0.0f);
        public static Colorf TransparentPurple = new Colorf(0.0f, 1.0f, 0, 1.0f);
        public static Colorf TransparentGray = new Colorf(0.0f, 0.39f, 0.39f, 0.39f);
        #endregion
    }
}
