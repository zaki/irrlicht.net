using System;

namespace IrrlichtNETCP
{
    public struct Rect
    {
        public Position2D UpperLeftCorner, LowerRightCorner;

        public Rect(Position2D upperLeft, Position2D lowerRight)
        {
            UpperLeftCorner = new Position2D();
            LowerRightCorner = new Position2D();
            Set(upperLeft, lowerRight);
        }

        public Rect(int x1, int y1, int x2, int y2)
        {
            UpperLeftCorner = new Position2D(x1, y1);
            LowerRightCorner = new Position2D(x2, y2);
        }

        public Rect(Position2D pos, Dimension2D size)
        {
            UpperLeftCorner = new Position2D();
            LowerRightCorner = new Position2D();
            Set(pos, size);
        }

        public void Set(Position2D upperLeft, Position2D lowerRight)
        {
            UpperLeftCorner = upperLeft;
            LowerRightCorner = lowerRight;
        }
        public void Set(int x1, int y1, int x2, int y2)
        {
            UpperLeftCorner = new Position2D(x1, y1);
            LowerRightCorner = new Position2D(x2, y2);
        }
        public void Set(Position2D pos, Dimension2D size)
        {
            UpperLeftCorner = pos;
            LowerRightCorner = new Position2D(pos.X + size.Width, pos.Y + size.Height);
        }

        public static Rect operator +(Rect r, Position2D pos)
        {
            r.UpperLeftCorner += pos;
            r.LowerRightCorner += pos;
            return r;
        }
        public static Rect operator +(Position2D pos, Rect r)
        {
            r.UpperLeftCorner += pos;
            r.LowerRightCorner += pos;
            return r;
        }
        public static Rect operator -(Rect r, Position2D pos)
        {
            r.UpperLeftCorner -= pos;
            r.LowerRightCorner -= pos;
            return r;
        }
        public static Rect operator -(Position2D pos, Rect r)
        {
            r.UpperLeftCorner -= pos;
            r.LowerRightCorner -= pos;
            return r;
        }
        public static bool operator ==(Rect first, Rect other)
        {
            return first.Equals(other);
        }
        public static bool operator !=(Rect first, Rect other)
        {
            return !first.Equals(other);
        }
        public override bool Equals(object o)
        {
            if (o is Rect)
                return GetHashCode() == o.GetHashCode();
            return base.Equals(o);
        }

        public override string ToString()
        {
            return "\"Type = " + GetType() + "; X1 = " + UpperLeftCorner.X + "; Y1 = " + UpperLeftCorner.Y + "; X2 = " + LowerRightCorner.X + "; Y2 = " + LowerRightCorner.Y + "\"";
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }
        public Dimension2D Size
        {
            get { return new Dimension2D(Width, Height); }
            set { Width = value.Width; Height = value.Height; }
        }
        public int Area
        {
            get { return Size.Area; }
        }
        public static bool operator <(Rect first, Rect other)
        {
            return first.Area < other.Area;
        }
        public static bool operator >(Rect first, Rect other)
        {
            return first.Area > other.Area;
        }
        public static bool operator <=(Rect first, Rect other)
        {
            return first.Area <= other.Area;
        }
        public static bool operator >=(Rect first, Rect other)
        {
            return first.Area >= other.Area;
        }
        /// <summary>
        /// Returns if a 2d point is within this rectangle.
        /// </summary>
        /// <param name="pos"> Position to test if it lies within this rectangle.</param>
        /// <returns> Returns true if the position is within the rectangle, false if not.</returns>
        public bool IsPointInside(Position2D pos)
        {
            return UpperLeftCorner.X <= pos.X && UpperLeftCorner.Y <= pos.Y &&
                LowerRightCorner.X >= pos.X && LowerRightCorner.Y >= pos.Y;
        }

        /// <summary>
        /// Returns if the rectangle collides with an other rectangle.
        /// </summary>
        public bool IsRectCollided(Rect other)
        {
            return (LowerRightCorner.Y > other.UpperLeftCorner.Y &&
                UpperLeftCorner.Y < other.LowerRightCorner.Y &&
                LowerRightCorner.X > other.UpperLeftCorner.X &&
                UpperLeftCorner.X < other.LowerRightCorner.X);
        }

        /// <summary>
        /// Clips this rectangle with another one.
        /// </summary>
        public void ClipAgainst(Rect other)
        {
            if (other.LowerRightCorner.X < LowerRightCorner.X)
                LowerRightCorner.X = other.LowerRightCorner.X;
            if (other.LowerRightCorner.Y < LowerRightCorner.Y)
                LowerRightCorner.Y = other.LowerRightCorner.Y;

            if (other.UpperLeftCorner.X > UpperLeftCorner.X)
                UpperLeftCorner.X = other.UpperLeftCorner.X;
            if (other.UpperLeftCorner.Y > UpperLeftCorner.Y)
                UpperLeftCorner.Y = other.UpperLeftCorner.Y;

            // correct possible invalid rect resulting from clipping
            if (UpperLeftCorner.Y > LowerRightCorner.Y)
                UpperLeftCorner.Y = LowerRightCorner.Y;
            if (UpperLeftCorner.X > LowerRightCorner.X)
                UpperLeftCorner.X = LowerRightCorner.X;
        }
        public bool ConstrainTo(Rect other)
        {
            if (other.Width < Width || other.Height < Height)
                return false;
            int diff = other.LowerRightCorner.X - LowerRightCorner.X;
            if (diff < 0)
            {
                LowerRightCorner.X += diff;
                UpperLeftCorner.X += diff;
            }
            diff = other.LowerRightCorner.Y - LowerRightCorner.Y;
            if (diff < 0)
            {
                LowerRightCorner.Y += diff;
                UpperLeftCorner.Y += diff;
            }

            diff = UpperLeftCorner.X - other.UpperLeftCorner.X;
            if (diff < 0)
            {
                LowerRightCorner.X -= diff;
                UpperLeftCorner.X -= diff;
            }
            diff = UpperLeftCorner.Y - other.UpperLeftCorner.Y;
            if (diff < 0)
            {
                LowerRightCorner.Y -= diff;
                UpperLeftCorner.Y -= diff;
            }
            return true;
        }
        public int Width
        {
            get
            {
                return LowerRightCorner.X - UpperLeftCorner.X;
            }
            set
            {
                LowerRightCorner.X = UpperLeftCorner.X + value;
            }
        }

        public int Height
        {
            get
            {
                return LowerRightCorner.Y - UpperLeftCorner.Y;
            }
            set
            {
                LowerRightCorner.Y = UpperLeftCorner.Y + value;
            }
        }

        /// <summary>
        /// If the lower right corner of the rect is smaller then the upper left,
        /// the points are swapped.
        /// </summary>
        public void Repair()
        {
            if (LowerRightCorner.X < UpperLeftCorner.X)
            {
                int t = LowerRightCorner.X;
                LowerRightCorner.X = UpperLeftCorner.X;
                UpperLeftCorner.X = t;
            }

            if (LowerRightCorner.Y < UpperLeftCorner.Y)
            {
                int t = LowerRightCorner.Y;
                LowerRightCorner.Y = UpperLeftCorner.Y;
                UpperLeftCorner.Y = t;
            }
        }

        /// <summary>
        /// Returns if the rect is valid to draw. It could be invalid, if
        /// The UpperLeftCorner is lower or more right than the LowerRightCorner,
        /// or if the area described by the rect is 0.
        /// </summary>
        public bool Valid
        {
            get
            {
                int xd = LowerRightCorner.X - UpperLeftCorner.X;
                int yd = LowerRightCorner.Y - UpperLeftCorner.Y;

                return !(xd <= 0 || yd <= 0 || (xd == 0 && yd == 0));
            }
        }

        public Position2D Center
        {
            get
            {
                return new Position2D((UpperLeftCorner.X + LowerRightCorner.X) / 2,
                                      (UpperLeftCorner.Y + LowerRightCorner.Y) / 2);
            }
        }
        public void AddInternalPoint(Position2D pos)
        {
            AddInternalPoint(pos.X, pos.Y);
        }
        public void AddInternalPoint(int x, int y)
        {
            if (x > LowerRightCorner.X) LowerRightCorner.X = x;
            if (y > LowerRightCorner.Y) LowerRightCorner.Y = y;

            if (x < UpperLeftCorner.X) UpperLeftCorner.X = x;
            if (y < UpperLeftCorner.Y) UpperLeftCorner.Y = y;
        }

        public static Rect From(Position2D upperL, Position2D lowerR)
        {
            Rect toR = new Rect();
            toR.Set(upperL, lowerR);
            return toR;
        }

        public System.Drawing.Rectangle dotNETRect
        {
            get { return new System.Drawing.Rectangle(X, Y, Width, Height); }
            set
            {
                UpperLeftCorner.X = value.X;
                UpperLeftCorner.Y = value.Y;
                Width = value.Width;
                Height = value.Height;

            }
        }
        /// <summary>
        /// Returns a always Valid Version of the Rect
        /// </summary>
        public Rect ValidRect
        {
            get
            {
                Rect R = this;
                R.Repair();
                return R;
            }
        }
        public int X
        {
            get { return UpperLeftCorner.X; }
            set
            {
                LowerRightCorner.X = value + Width;
                UpperLeftCorner.X = value;
            }
        }
        public int Y
        {
            get { return UpperLeftCorner.Y; }
            set
            {
                LowerRightCorner.Y = value + Width;
                UpperLeftCorner.Y = value;
            }
        }

        /// <summary>
        /// Makes an Irrlicht rectangle from the standard .NET rectangle.
        /// </summary>
        /// <returns>The Irrlicht rectangle</returns>
        public static Rect FromBCL(System.Drawing.Rectangle bcl)
        {
            return new Rect(new Position2D(bcl.X, bcl.Y),
                            new Dimension2D(bcl.Width, bcl.Height));
        }

        public int[] ToUnmanaged() { return new int[] { UpperLeftCorner.X, UpperLeftCorner.Y, LowerRightCorner.X, LowerRightCorner.Y }; }
        public static Rect FromUnmanaged(int[] un) { return From(Position2D.From(un[0], un[1]), Position2D.From(un[2], un[3])); }
    }
}
