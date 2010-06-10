using System;

namespace IrrlichtNETCP
{
    public struct Line3D
    {
        public Vector3D Start;
        public Vector3D End;

        public Line3D(Vector3D start, Vector3D end)
        {
            Start = new Vector3D();
            End = new Vector3D();
            Set(start, end);
        }
        public Line3D(float sX, float sY, float sZ, float eX, float eY, float eZ)
        {
            Start = new Vector3D();
            End = new Vector3D();
            Set(sX, sY, sZ, eX, eY, eZ);
        }

        public void Set(Vector3D start, Vector3D end)
        {
            Start = start;
            End = end;
        }
        public void Set(float sX, float sY, float sZ, float eX, float eY, float eZ)
        {
            Start = new Vector3D(sX, sY, sZ);
            End = new Vector3D(eX, eY, eZ);
        }

        public double LengthSQ { get { return Start.DistanceFromSQ(End); } }
        public double Length { get { return Start.DistanceFrom(End); } }

        public Vector3D Middle
        {
            get
            {
                return (Start + End) / 2;
            }
        }

        public Vector3D Vector
        {
            get
            {
                return (End - Start);
            }
        }

        public bool IsPointBetweenStartAndEnd(Vector3D point)
        {
            return point.IsBetweenPoints(Start, End);
        }

        public Vector3D GetClosestPoint(Vector3D point)
        {
            Vector3D c = point - Start;
            Vector3D v = End - Start;
            float d = v.Length;
            v = v / d;
            float t = v.DotProduct(c);

            if (t < 0.0f) return Start;
            if (t > d) return End;

            v = v * t;
            return Start + v;
        }

        public bool GetIntersectionWithSphere(Vector3D sorigin, float sradius, out double outdistance)
        {
            outdistance = 0.0;
            Vector3D q = sorigin - Start;
            double c = q.Length;
            Vector3D vv = Vector;
            vv.Normalize();
            double v = q.DotProduct(vv);
            double d = sradius * sradius - (c * c - v * v);

            if (d < 0.0)
                return false;

            outdistance = v - Math.Sqrt(d);
            return true;
        }

        public override bool Equals(object o)
        {
            if (o is Line3D)
                return GetHashCode() == o.GetHashCode();
            return base.Equals(o);
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        public static Line3D From(float xMin, float yMin, float zMin, float xMax, float yMax, float zMax)
        {
            Line3D line = new Line3D();
            line.Start = new Vector3D();
            line.End = new Vector3D();
            line.Start.Set(xMin, yMin, zMin);
            line.End.Set(xMax, yMax, zMax);
            return line;
        }

        public float[] ToUnmanaged()
        { return new float[] { Start.X, Start.Y, Start.Z, End.X, End.Y, End.Z }; }
        public static Line3D FromUnmanaged(float[] b)
        {
            return From(b[0], b[1], b[2], b[3], b[4], b[5]);
        }

        public static Line3D operator +(Line3D first, Vector3D point)
        {
            return new Line3D(first.Start + point, first.End + point);
        }
        public static Line3D operator -(Line3D first, Vector3D point)
        {
            return new Line3D(first.Start - point, first.End - point);
        }

        public static Line3D operator +(Vector3D point, Line3D first)
        {
            return new Line3D(first.Start + point, first.End + point);
        }
        public static Line3D operator -(Vector3D point, Line3D first)
        {
            return new Line3D(point - first.Start, point - first.End);
        }
        public static bool operator ==(Line3D first, Line3D other)
        {
            return (first.Start == other.Start && first.End == other.End) ||
                (first.End == other.Start && first.Start == other.End);
        }
        public static bool operator !=(Line3D first, Line3D other)
        {
            return !((first.Start == other.Start && first.End == other.End) ||
                (first.End == other.Start && first.Start == other.End));
        }

    }
}
