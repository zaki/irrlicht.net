using System;

namespace IrrlichtNETCP
{
    public struct Vector3D
    {
        public Vector3D(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public float X, Y, Z;

        public float LengthSQ { get { return NewMath.Sqr(X) + NewMath.Sqr(Y) + NewMath.Sqr(Z); } set { SetLength((float)Math.Sqrt(value)); } }
        public float Length { get { return (float)Math.Sqrt(LengthSQ); } set { SetLength(value); } }
        public Vector3D Normalize()
        {
            float len = Length;
            if (len == 0)
                return this;
            X /= len;
            Y /= len;
            Z /= len;
            return this;
        }

        public double DistanceFromSQ(Vector3D what)
        {
            return (NewMath.Sqr(X - what.X) + NewMath.Sqr(Y - what.Y) + +NewMath.Sqr(Z - what.Z));
        }
        public double DistanceFrom(Vector3D what)
        {
            return Math.Sqrt(DistanceFromSQ(what));
        }

        public void Set(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public float DotProduct(Vector3D other)
        {
            return X * other.X + Y * other.Y + Z * other.Z;
        }

        public Vector3D CrossProduct(Vector3D p)
        {
            return new Vector3D(Y * p.Z - Z * p.Y, Z * p.X - X * p.Z, X * p.Y - Y * p.X);
        }

        public Vector3D HorizontalAngle
        {
            get
            {
                Vector3D angle = new Vector3D();

                angle.Y = (float)Math.Atan2(X, Z);
                angle.Y *= NewMath.RADTODEG;

                if (angle.Y < 0.0f) angle.Y += 360.0f;
                if (angle.Y >= 360.0f) angle.Y -= 360.0f;

                float z1 = (float)Math.Sqrt(X * X + Z * Z);

                angle.X = (float)Math.Atan2(z1, Y);
                angle.X *= NewMath.RADTODEG;
                angle.X -= 90.0f;

                if (angle.X < 0.0f) angle.X += 360.0f;
                if (angle.X >= 360.0f) angle.X -= 360.0f;

                return angle;
            }
        }

        public bool IsBetweenPoints(Vector3D begin, Vector3D end)
        {
            float f = ((end - begin).LengthSQ);
            return DistanceFromSQ(begin) < f &&
                   DistanceFromSQ(end) < f;
        }

        public void SetLength(float newlength)
        {
            Normalize();
            this = this * newlength;
        }

        public static Vector3D operator +(Vector3D first, Vector3D other)
        {
            return new Vector3D(first.X + other.X, first.Y + other.Y, first.Z + other.Z);
        }

        public static Vector3D operator -(Vector3D first, Vector3D other)
        {
            return new Vector3D(first.X - other.X, first.Y - other.Y, first.Z - other.Z);
        }

        public static Vector3D operator -(Vector3D first)
        {
            return new Vector3D(-first.X, -first.Y, -first.Z);
        }

        public static Vector3D operator *(Vector3D first, float other)
        {
            return new Vector3D(first.X * other, first.Y * other, first.Z * other);
        }

        public static Vector3D operator /(Vector3D first, float other)
        {
            return new Vector3D(first.X / other, first.Y / other, first.Z / other);
        }

        public static Vector3D operator *(Vector3D first, Vector3D other)
        {
            return new Vector3D(first.X * other.X, first.Y * other.Y, first.Z * other.Z);
        }

        public static Vector3D operator /(Vector3D first, Vector3D other)
        {
            return new Vector3D(first.X / other.X, first.Y / other.Y, first.Z / other.Z);
        }

        public static Vector3D operator *(float other, Vector3D first)
        {
            return new Vector3D(first.X * other, first.Y * other, first.Z * other);
        }

        public static Vector3D operator /(float other, Vector3D first)
        {
            return new Vector3D(first.X / other, first.Y / other, first.Z / other);
        }

        public static bool operator ==(Vector3D first, Vector3D other)
        {
            return first.X == other.X && first.Y == other.Y && first.Z == other.Z;
        }

        public static bool operator !=(Vector3D first, Vector3D other)
        {
            return first.X != other.X || first.Y != other.Y || first.Z != other.Z;
        }

        public static bool operator <=(Vector3D first, Vector3D other)
        {
            return first.X <= other.X && first.Y <= other.Y && first.Z <= other.Z;
        }
        public static bool operator >=(Vector3D first, Vector3D other)
        {
            return first.X >= other.X && first.Y >= other.Y && first.Z >= other.Z;
        }
        public static bool operator <(Vector3D first, Vector3D other)
        {
            return first.X < other.X && first.Y < other.Y && first.Z < other.Z;
        }
        public static bool operator >(Vector3D first, Vector3D other)
        {
            return first.X > other.X && first.Y > other.Y && first.Z > other.Z;
        }

        public Vector3D Invert()
        {
            X *= -1.0f;
            Y *= -1.0f;
            Z *= -1.0f;
            return this;
        }

        public void RotateXZBy(double degrees, Vector3D center)
        {
            degrees *= Math.PI / 180.0;
            float cs = NewMath.FCos(degrees);
            float sn = NewMath.FSin(degrees);
            X -= center.X;
            Z -= center.Z;
            Set(X * cs - Z * sn, Y, X * sn + Z * cs);
            X += center.X;
            Z += center.Z;
        }

        public void RotateXYBy(double degrees, Vector3D center)
        {
            degrees *= Math.PI / 180.0;
            float cs = NewMath.FCos(degrees);
            float sn = NewMath.FSin(degrees);
            X -= center.X;
            Y -= center.Y;
            Set(X * cs - Y * sn, X * sn + Y * cs, Z);
            X += center.X;
            Y += center.Y;
        }

        public void RotateYZBy(double degrees, Vector3D center)
        {
            degrees *= Math.PI / 180.0;
            float cs = NewMath.FCos(degrees);
            float sn = NewMath.FSin(degrees);
            Z -= center.Z;
            Y -= center.Y;
            Set(X, Y * cs - Z * sn, Y * sn + Z * cs);
            Z += center.Z;
            Y += center.Y;
        }

        public Vector3D GetInterpolated(Vector3D other, float d)
        {
            float inv = 1.0f - d;
            return new Vector3D(other.X * inv + X * d,
                            other.Y * inv + Y * d,
                            other.Z * inv + Z * d);
        }
        public Vector3D GetInterpolated_Quadratic(Vector3D v2, Vector3D v3, float d)
        {
            float inv = 1.0f - d;
            float mul0 = inv * inv;
            float mul1 = (float)2.0 * d * inv;
            float mul2 = d * d;

            return new Vector3D(X * mul0 + v2.X * mul1 + v3.X * mul2,
                    Y * mul0 + v2.Y * mul1 + v3.Y * mul2,
                    Z * mul0 + v2.Z * mul1 + v3.Z * mul2);

        }

        public override bool Equals(object o)
        {
            if (o is Vector3D)
                return ((Vector3D)o).X == X && ((Vector3D)o).Y == Y && ((Vector3D)o).Z == Z;
            return base.Equals(o);
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        public static Vector3D From(float x, float y, float z)
        {
            Vector3D v;
            v.X = x;
            v.Y = y;
            v.Z = z;
            return v;
        }

        public float[] ToUnmanaged() { return new float[] { X, Y, Z }; }
        public static Vector3D FromUnmanaged(float[] un) { return From(un[0], un[1], un[2]); }
        public float[] ToShader() { return ToUnmanaged(); }
        public override string ToString()
        {
            return "\"Type = " + GetType() + "; X = " + X + "; Y = " + Y + "; Z = " + Z + "\"";
        }
    }
}
