namespace IrrlichtNET
{
    public struct Dimension2D
    {
        public Dimension2D(int w, int h)
        {
            Width = w;
            Height = h;
        }
        /// <summary>
        /// Makes a sqare with Width and Height q
        /// </summary>
        /// <param name="q">Width and Height will be q</param>
        public Dimension2D(int q)
        {
            Width = q;
            Height = q;
        }
        public int Width;
        public int Height;

        public void Set(int w, int h)
        {
            Width = w;
            Height = h;
        }

        public static Dimension2D From(int w, int h)
        {
            Dimension2D d;
            d.Width = w;
            d.Height = h;
            return d;
        }

        public int[] ToUnmanaged() { return new int[] { Width, Height }; }
        public static Dimension2D FromUnmanaged(int[] un) { return From(un[0], un[1]); }
        public override string ToString()
        {
            return "\"Type = " + GetType() + "; Width = " + Width + "; Height = " + Height + "\"";
        }
        public override bool Equals(object o)
        {
            if (o is Dimension2D)
                return GetHashCode() == o.GetHashCode();
            return base.Equals(o);
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }
        public static bool operator ==(Dimension2D first, Dimension2D other)
        {
            return first.Equals(other);
        }
        public static bool operator !=(Dimension2D first, Dimension2D other)
        {
            return !first.Equals(other);
        }
        public static Dimension2D operator -(Dimension2D first, Dimension2D other)
        {
            return new Dimension2D(first.Width - other.Width, first.Height - other.Height);
        }
        public static Dimension2D operator +(Dimension2D first, Dimension2D other)
        {
            return new Dimension2D(first.Width + other.Width, first.Height + other.Height);
        }

        public static Dimension2D operator *(Dimension2D first, Dimension2D other)
        {
            return new Dimension2D(first.Width * other.Width, first.Height * other.Height);
        }

        public static Dimension2D operator /(Dimension2D first, Dimension2D other)
        {
            return new Dimension2D((int)(first.Width / other.Width), (int)(first.Height / other.Height));
        }
        public static Dimension2D operator /(Dimension2D first, float scalar)
        {
            return new Dimension2D((int)(first.Width / scalar), (int)(first.Height / scalar));

        }
        public static Dimension2D operator *(Dimension2D first, float scalar)
        {
            return new Dimension2D((int)(first.Width * scalar), (int)(first.Height * scalar));

        }
        public static Dimension2D operator /(float scalar, Dimension2D first)
        {
            return new Dimension2D((int)(scalar / first.Width), (int)(scalar / first.Height));

        }
        public static Dimension2D operator *(float scalar, Dimension2D first)
        {
            return new Dimension2D((int)(first.Width * scalar), (int)(first.Height * scalar));

        }
        public static Dimension2D operator -(Dimension2D first)
        {
            return new Dimension2D(-first.Width, -first.Height);
        }
        public static implicit operator Dimension2D(Position2D first)
        {
            return new Dimension2D(first.X, first.Y);
        }
        public static explicit operator Dimension2D(Position2Df first)
        {
            return new Dimension2D((int)first.X, (int)first.Y);
        }
        public static explicit operator Dimension2D(Vector2D first)
        {
            return new Dimension2D((int)first.X, (int)first.Y);

        }
        public static explicit operator Dimension2D(Dimension2Df first)
        {
            return new Dimension2D((int)first.Width, (int)first.Height);
        }
        public System.Drawing.Size dotNETSize
        {
            get { return new System.Drawing.Size(Width, Height); }
            set { Width = value.Width; Height = value.Height; }
        }
        public static Dimension2D Empty = new Dimension2D(0, 0);
        public bool IsEmpty
        {
            get { return this == Empty; }
        }
        public int Area
        {
            get { return Width * Height; }
        }
        #region "Premade Dimensions"
        public static Dimension2D Q16 = new Dimension2D(16, 16);
        public static Dimension2D Q32 = new Dimension2D(32, 32);
        public static Dimension2D Q64 = new Dimension2D(64, 64);
        public static Dimension2D Q128 = new Dimension2D(128, 128);
        public static Dimension2D Q256 = new Dimension2D(256, 256);
        public static Dimension2D Q512 = new Dimension2D(512, 512);
        public static Dimension2D Q1024 = new Dimension2D(1024, 1024);
        public static Dimension2D Q2048 = new Dimension2D(2048, 2048);
        public static Dimension2D QVGA = new Dimension2D(320, 240);
        public static Dimension2D VGA = new Dimension2D(640, 480);
        public static Dimension2D SVGA = new Dimension2D(800, 600);
        public static Dimension2D XGA = new Dimension2D(1024, 768);
        #endregion
    }

    public struct Dimension2Df
    {
        public Dimension2Df(float w, float h)
        {
            Width = w;
            Height = h;
        }
        /// <summary>
        /// Makes a sqare with Width and Height q
        /// </summary>
        /// <param name="q">Width and Height will be q</param>
        public Dimension2Df(float q)
        {
            Width = q;
            Height = q;
        }
        public float Width;
        public float Height;

        public void Set(float w, float h)
        {
            Width = w;
            Height = h;
        }

        public static Dimension2Df From(float w, float h)
        {
            Dimension2Df d;
            d.Width = w;
            d.Height = h;
            return d;
        }

        public float[] ToUnmanaged() { return new float[] { Width, Height }; }
        public static Dimension2Df FromUnmanaged(float[] un) { return From(un[0], un[1]); }
        public override string ToString()
        {
            return "\"Type = " + GetType() + "; Width = " + Width + "; Height = " + Height + "\"";
        }
        public override bool Equals(object o)
        {
            if (o is Dimension2Df)
                return GetHashCode() == o.GetHashCode();
            return base.Equals(o);
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }
        public static bool operator ==(Dimension2Df first, Dimension2Df other)
        {
            return first.Equals(other);
        }
        public static bool operator !=(Dimension2Df first, Dimension2Df other)
        {
            return !first.Equals(other);
        }
        public static Dimension2Df operator -(Dimension2Df first, Dimension2Df other)
        {
            return new Dimension2Df(first.Width - other.Width, first.Height - other.Height);
        }
        public static Dimension2Df operator +(Dimension2Df first, Dimension2Df other)
        {
            return new Dimension2Df(first.Width + other.Width, first.Height + other.Height);
        }

        public static Dimension2Df operator *(Dimension2Df first, Dimension2Df other)
        {
            return new Dimension2Df(first.Width * other.Width, first.Height * other.Height);
        }

        public static Dimension2Df operator /(Dimension2Df first, Dimension2Df other)
        {
            return new Dimension2Df(first.Width / other.Width, first.Height / other.Height);
        }
        public static Dimension2Df operator /(Dimension2Df first, float scalar)
        {
            return new Dimension2Df(first.Width / scalar, first.Height / scalar);

        }
        public static Dimension2Df operator *(Dimension2Df first, float scalar)
        {
            return new Dimension2Df(first.Width * scalar, first.Height * scalar);

        }
        public static Dimension2Df operator /(float scalar, Dimension2Df first)
        {
            return new Dimension2Df(scalar / first.Width, scalar / first.Height);

        }
        public static Dimension2Df operator *(float scalar, Dimension2Df first)
        {
            return new Dimension2Df(first.Width * scalar, first.Height * scalar);

        }
        public static Dimension2Df operator -(Dimension2Df first)
        {
            return new Dimension2Df(-first.Width, -first.Height);
        }
        public static implicit operator Dimension2Df(Position2D first)
        {
            return new Dimension2Df(first.X, first.Y);
        }
        public static implicit operator Dimension2Df(Position2Df first)
        {
            return new Dimension2Df(first.X, first.Y);
        }
        public static implicit operator Dimension2Df(Vector2D first)
        {
            return new Dimension2Df(first.X, first.Y);

        }
        public static implicit operator Dimension2Df(Dimension2D first)
        {
            return new Dimension2Df(first.Width, first.Height);
        }
        public System.Drawing.SizeF dotNETSizeF
        {
            get { return new System.Drawing.SizeF(Width, Height); }
            set { Width = value.Width; Height = value.Height; }
        }
        public static Dimension2Df Empty = new Dimension2Df(0, 0);
        public bool IsEmpty
        {
            get { return this == Empty; }
        }
        public float Area
        {
            get { return Width * Height; }
        }
    }
}
