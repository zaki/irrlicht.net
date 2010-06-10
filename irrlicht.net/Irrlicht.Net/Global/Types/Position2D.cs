using System;
using System.Drawing;
namespace IrrlichtNETCP
{

    public struct Position2D
    {
        public int X, Y;
        public Position2D(int x, int y)
        {
            X = Y = 0;
            Set(x, y);
        }

        public void Set(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return GetType() + "; X = " + X + "; Y = " + Y;
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        public override bool Equals(object o)
        {
            if (o is Position2D)
                return GetHashCode() == o.GetHashCode();
            return base.Equals(o);
        }
        public static Position2D From(int X, int Y)
        {
            Position2D toR = new Position2D();
            toR.Set(X, Y);
            return toR;
        }
        public static bool operator ==(Position2D first, Position2D other)
        {
            return first.Equals(other);
        }
        public static bool operator !=(Position2D first, Position2D other)
        {
            return !first.Equals(other);
        }
        public static Position2D operator -(Position2D first, Position2D other)
        {
            return new Position2D(first.X - other.X, first.Y - other.Y);
        }
        public static Position2D operator +(Position2D first, Position2D other)
        {
            return new Position2D(first.X + other.X, first.Y + other.Y);
        }
        public static Position2D operator *(Position2D first, Position2D other)
        {
            return new Position2D(first.X * other.X, first.Y * other.Y);
        }
        public static Position2D operator /(Position2D first, Position2D other)
        {
            return new Position2D((int)(first.X / other.X), (int)(first.Y / other.Y));
        }
        public static Position2D operator /(Position2D first, float scalar)
        {
            return new Position2D((int)(first.X / scalar), (int)(first.Y / scalar));
        }
        public static Position2D operator *(Position2D first, float scalar)
        {
            return new Position2D((int)(first.X * scalar), (int)(first.Y * scalar));
        }
        public static Position2D operator /(float scalar, Position2D first)
        {
            return new Position2D((int)(scalar / first.X), (int)(scalar / first.Y));
        }
        public static Position2D operator *(float scalar, Position2D first)
        {
            return new Position2D((int)(first.X * scalar), (int)(first.Y * scalar));
        }
        public static Position2D operator -(Position2D first)
        {
            return new Position2D(-first.X, -first.Y);
        }
        public static implicit operator Position2D(Dimension2D first)
        {
            return new Position2D(first.Width, first.Height);
        }
        public static explicit operator Position2D(Position2Df first)
        {
            return new Position2D((int)first.X, (int)first.Y);
        }
        public static explicit operator Position2D(Vector2D first)
        {
            return new Position2D((int)first.X, (int)first.Y);
        }
        public static explicit operator Position2D(Dimension2Df first)
        {
            return new Position2D((int)first.Width, (int)first.Height);
        }
        public Point dotNETPoint
        {
            get { return new Point(X, Y); }
            set { X = value.X; Y = value.Y; }
        }
        public static Position2D Empty = new Position2D(0, 0);
        public bool IsEmpty
        {
            get { return this == Empty; }
        }


        public int[] ToUnmanaged() { return new int[] { X, Y }; }
        public static Position2D FromUnmanaged(int[] un) { return From(un[0], un[1]); }


    }


    public struct Position2Df
    {
        public float X, Y;
        public Position2Df(float x, float y)
        {
            X = Y = 0f;
            Set(x, y);
        }

        public void Set(float x, float y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return GetType() + "; X = " + X + "; Y = " + Y;
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        public override bool Equals(object o)
        {
            if (o is Position2Df)
                return GetHashCode() == o.GetHashCode();
            return base.Equals(o);
        }

        public static Position2Df From(float X, float Y)
        {
            Position2Df toR = new Position2Df();
            toR.Set(X, Y);
            return toR;
        }
        public static bool operator ==(Position2Df first, Position2Df other)
        {
            return first.Equals(other);
        }
        public static bool operator !=(Position2Df first, Position2Df other)
        {
            return !first.Equals(other);
        }
        public static Position2Df operator -(Position2Df first, Position2Df other)
        {
            return new Position2Df(first.X - other.X, first.Y - other.Y);
        }
        public static Position2Df operator +(Position2Df first, Position2Df other)
        {
            return new Position2Df(first.X + other.X, first.Y + other.Y);
        }
        public static Position2Df operator *(Position2Df first, Position2Df other)
        {
            return new Position2Df(first.X * other.X, first.Y * other.Y);
        }
        public static Position2Df operator /(Position2Df first, Position2Df other)
        {
            return new Position2Df((first.X / other.X), (first.Y / other.Y));
        }
        public static Position2Df operator *(Position2Df first, float scalar)
        {
            return new Position2Df((first.X * scalar), (first.Y * scalar));
        }
        public static Position2Df operator /(Position2Df first, float scalar)
        {
            return new Position2Df((first.X / scalar), (first.Y / scalar));
        }
        public static Position2Df operator *(float scalar, Position2Df first)
        {
            return new Position2Df((first.X * scalar), (first.Y * scalar));
        }
        public static Position2Df operator /(float scalar, Position2Df first)
        {
            return new Position2Df((scalar / first.X), (scalar / first.Y));
        }
        public static Position2Df operator -(Position2Df first)
        {
            return new Position2Df(-first.X, -first.Y);
        }
        public static implicit operator Position2Df(Dimension2D first)
        {
            return new Position2Df(first.Width, first.Height);
        }
        public static implicit operator Position2Df(Position2D first)
        {
            return new Position2Df(first.X, first.Y);
        }
        public static implicit operator Position2Df(Vector2D first)
        {
            return new Position2Df(first.X, first.Y);
        }
        public static implicit operator Position2Df(Dimension2Df first)
        {
            return new Position2Df(first.Width, first.Height);
        }
        public PointF dotNETPointf
        {
            get { return new PointF(X, Y); }
            set { X = value.X; Y = value.Y; }
        }
        public static Position2Df Empty = new Position2Df(0, 0);
        public bool IsEmpty
        {
            get { return this == Empty; }
        }
        public float[] ToUnmanaged() { return new float[] { X, Y }; }
        public static Position2Df FromUnmanaged(float[] un) { return From(un[0], un[1]); }
    }
}
