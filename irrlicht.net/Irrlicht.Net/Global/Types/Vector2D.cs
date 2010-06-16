using System;

namespace IrrlichtNET
{
    public struct Vector2D
    {
        public Vector2D(float x, float y)
        {
            X = x;
            Y = y;
        }

        public float X, Y;
        public float LengthSQ { get { return NewMath.Sqr(X) + NewMath.Sqr(Y); } set { SetLength((float)Math.Sqrt(value)); } }
        public float Length { get { return (float)Math.Sqrt(LengthSQ); } set { SetLength(value); } }
        public void Set(float nx, float ny) { X = nx; Y = ny; }
        public void Set(Vector2D p) { X = p.X; Y = p.Y; }

        public Vector2D Normalize()
        {
            float len = Length;
            if (len == 0) return this;
            X /= len;
            Y /= len;
            return this;
        }

        public void SetLength(float newlength)
        {
            Normalize();
            this = this * newlength;
        }

        public float DotProduct(Vector2D other)
        {
            return X * other.X + Y * other.Y;
        }

        public double GetDistanceFrom(Vector2D other)
        {
            double vx = X - other.X; double vy = Y - other.Y;
            return Math.Sqrt(vx * vx + vy * vy);
        }

        /// <summary>
        /// Returns squared distance from an other point.
        /// Here, the vector is interpreted as point in 3 dimensional space.
        /// </summary>
        public float GetDistanceFromSQ(Vector2D other)
        {
            float vx = X - other.X; float vy = Y - other.Y;
            return (vx * vx + vy * vy);
        }

        /// <summary>
        /// Returns if the point represented by this vector is between to points
        ///</summary>
        ///<param name="begin">Start point of line</param>
        ///<param name="end">End point of line</param>
        ///<returns> True if between points, false if not. </returns>
        public bool IsBetweenPoints(Vector2D begin, Vector2D end)
        {
            float f = (end - begin).LengthSQ;
            return GetDistanceFromSQ(begin) < f && GetDistanceFromSQ(end) < f;
        }

        public static Vector2D operator +(Vector2D first, Vector2D other)
        {
            return new Vector2D(first.X + other.X, first.Y + other.Y);
        }

        public static Vector2D operator -(Vector2D first, Vector2D other)
        {
            return new Vector2D(first.X - other.X, first.Y - other.Y);
        }
        public static Vector2D operator *(Vector2D first, Vector2D other)
        {
            return new Vector2D(first.X * other.X, first.Y * other.Y);
        }

        public static Vector2D operator /(Vector2D first, Vector2D other)
        {
            return new Vector2D(first.X / other.X, first.Y / other.Y);
        }
        public static Vector2D operator *(Vector2D first, float other)
        {
            return new Vector2D(first.X * other, first.Y * other);
        }

        public static Vector2D operator /(Vector2D first, float other)
        {
            return new Vector2D(first.X / other, first.Y / other);
        }
        public static Vector2D operator *(float first, Vector2D other)
        {
            return new Vector2D(first * other.X, first * other.Y);
        }

        public static Vector2D operator /(float first, Vector2D other)
        {
            return new Vector2D(first / other.X, first / other.Y);
        }

        public static bool operator ==(Vector2D first, Vector2D other)
        {
            return first.X == other.X && first.Y == other.Y;
        }

        public static bool operator !=(Vector2D first, Vector2D other)
        {
            return first.X != other.X || first.Y != other.Y;
        }
        public static bool operator <=(Vector2D first, Vector2D other)
        {
            return first.X <= other.X && first.Y <= other.Y;
        }
        public static bool operator >=(Vector2D first, Vector2D other)
        {
            return first.X >= other.X && first.Y >= other.Y;
        }
        public static bool operator <(Vector2D first, Vector2D other)
        {
            return first.X < other.X && first.Y < other.Y;
        }
        public static bool operator >(Vector2D first, Vector2D other)
        {
            return first.X > other.X && first.Y > other.Y;
        }

        public override bool Equals(object o)
        {
            if (o is Vector2D)
                return ((Vector2D)o).X == X && ((Vector2D)o).Y == Y;
            return base.Equals(o);
        }

        public void Invert()
        {
            X *= -1.0f;
            Y *= -1.0f;
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        public void RotateBy(double degrees, Vector2D center)
        {
            degrees *= Math.PI / 180.0;
            float cs = NewMath.FCos(degrees);
            float sn = NewMath.FSin(degrees);
            X -= center.X;
            Y -= center.Y;

            Set(X * cs - Y * sn, X * sn + Y * cs);

            X += center.X;
            Y += center.Y;
        }

        //! Calculates the angle of this vector in grad in the trigonometric sense.
        //! This method has been suggested by Pr3t3nd3r.
        //! \return Returns a value between 0 and 360.
        public double GetAngleTrig()
        {
            if (X == 0.0)
                return Y < 0.0 ? 270.0 : 90.0;
            else
                if (Y == 0)
                    return X < 0.0 ? 180.0 : 0.0;

            if (Y > 0.0)
                if (X > 0.0)
                    return Math.Atan(Y / X) * Math.PI;
                else
                    return 180.0 - Math.Atan(Y / -X) * Math.PI;
            else
                if (X > 0.0)
                    return 360.0 - Math.Atan(-Y / X) * Math.PI;
                else
                    return 180.0 + Math.Atan(-Y / -X) * Math.PI;
        }

        //! Calculates the angle of this vector in grad in the counter trigonometric sense.
        //! \return Returns a value between 0 and 360.
        public double GetAngle()
        {
            if (Y == 0.0)  // corrected thanks to a suggestion by Jox
                return X < 0.0 ? 180.0 : 0.0;
            else if (X == 0.0)
                return Y < 0.0 ? 90.0 : 270.0;

            double tmp = Y / Math.Sqrt(X * X + Y * Y);
            tmp = Math.Atan(Math.Sqrt(1 - tmp * tmp) / tmp) * Math.PI;

            if (X > 0.0 && Y > 0.0)
                return tmp + 270;
            else
                if (X > 0.0 && Y < 0.0)
                    return tmp + 90;
                else
                    if (X < 0.0 && Y < 0.0)
                        return 90 - tmp;
                    else
                        if (X < 0.0 && Y > 0.0)
                            return 270 - tmp;

            return tmp;
        }

        //! Calculates the angle between this vector and another one in grad.
        //! \return Returns a value between 0 and 90.
        public double GetAngleWith(Vector2D b)
        {
            double tmp = X * b.X + Y * b.Y;

            if (tmp == 0.0)
                return 90.0;

            tmp = tmp / Math.Sqrt((X * X + Y * Y) * (b.X * b.X + b.Y * b.Y));
            if (tmp < 0.0) tmp = -tmp;

            return Math.Atan(Math.Sqrt(1 - tmp * tmp) / tmp) * Math.PI;
        }

        //! Returns interpolated vector.
        /** \param other: other vector to interpolate between
        \param d: value between 0.0f and 1.0f. */
        public Vector2D GetInterpolated(Vector2D other, float d)
        {
            float inv = 1.0f - d;
            return new Vector2D(other.X * inv + X * d,
                            other.Y * inv + Y * d);
        }
        public Vector2D GetInterpolated_Quadratic(Vector2D v2, Vector2D v3, float d)
        {
            float inv = 1.0f - d;
            float mul0 = inv * inv;
            float mul1 = 2.0f * d * inv;
            float mul2 = d * d;
            return new Vector2D(X * mul0 + v2.X * mul1 + v3.X * mul2,
                Y * mul0 + v2.Y * mul1 + v3.Y * mul2);
        }

        //! sets this vector to the interpolated vector between a and b.
        public void Interpolate(Vector2D a, Vector2D b, float t)
        {
            X = b.X + ((a.X - b.X) * t);
            Y = b.Y + ((a.Y - b.Y) * t);
        }
        public float[] ToUnmanaged() { return new float[] { X, Y }; }
        public static Vector2D FromUnmanaged(float[] un) { return From(un[0], un[1]); }

        public static Vector2D From(float x, float y)
        {
            Vector2D vect = new Vector2D();
            vect.X = x;
            vect.Y = y;
            return vect;
        }
        public static implicit operator Vector2D(Position2D other)
        {
            return new Vector2D(other.X, other.Y);
        }
        public static implicit operator Vector2D(Position2Df other)
        {
            return new Vector2D(other.X, other.Y);
        }
        public static implicit operator Vector2D(Dimension2D other)
        {
            return new Vector2D(other.Width, other.Height);
        }
        public static implicit operator Vector2D(Dimension2Df other)
        {
            return new Vector2D(other.Width, other.Height);
        }

    }
}
