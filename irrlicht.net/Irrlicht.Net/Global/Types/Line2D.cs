using System;

namespace IrrlichtNETCP
{
    public struct Line2D
    {
        public Vector2D Start;
        public Vector2D End;

        public Line2D(Vector2D start, Vector2D end)
        {
            Start = new Vector2D();
            End = new Vector2D();
            Set(start, end);
        }
        public Line2D(float sX, float sY, float eX, float eY)
        {
            Start = new Vector2D();
            End = new Vector2D();
            Set(sX, sY, eX, eY);
        }

        public void Set(Vector2D start, Vector2D end)
        {
            Start = start;
            End = end;
        }
        public void Set(float sX, float sY, float eX, float eY)
        {
            Start = new Vector2D(sX, sY);
            End = new Vector2D(eX, eY);
        }

        public double LengthSQ { get { return Start.GetDistanceFromSQ(End); } }
        public double Length { get { return Start.GetDistanceFrom(End); } }

        public Vector2D Middle
        {
            get
            {
                return (Start + End) / 2;
            }
        }

        public Vector2D Vector
        {
            get
            {
                return (End - Start);
            }
        }

        static double ROUNDING_ERROR_32 = 0.000001f;

        public bool intersectWith(Line2D l, Vector2D o)
        {
            bool found = false;

            float a1, a2, b1, b2;

            // calculate slopes, deal with infinity
            if (End.X - Start.X == 0)
                b1 = (float)1e+10;
            else
                b1 = (End.Y - Start.Y) / (End.X - Start.X);

            if (l.End.X - l.Start.X == 0)
                b2 = (float)1e+10;
            else
                b2 = (l.End.Y - l.Start.Y) / (l.End.X - l.Start.X);

            // calculate position
            a1 = Start.Y - b1 * Start.X;
            a2 = l.Start.Y - b2 * l.Start.X;
            o.X = -(a1 - a2) / (b1 - b2);
            o.Y = a1 + b1 * o.X;

            // did the lines cross?
            if ((Start.X - o.X) * (o.X - End.X) >= -ROUNDING_ERROR_32 &&
                (l.Start.X - o.X) * (o.X - l.End.X) >= -ROUNDING_ERROR_32 &&
                (Start.Y - o.Y) * (o.Y - End.Y) >= -ROUNDING_ERROR_32 &&
                (l.Start.Y - o.Y) * (o.Y - l.End.Y) >= -ROUNDING_ERROR_32)
            {
                found = true;
            }
            return found;
        }

        public Vector2D UnitVector
        {
            get
            {
                float len = (float)(1.0 / Length);
                return new Vector2D((End.X - Start.X) * len, (End.Y - Start.Y) * len);

            }
        }
        public double GetAngleWith(Line2D l)
        {
            Vector2D vect = Vector;
            Vector2D vect2 = l.Vector;
            return vect.GetAngleWith(vect2);
        }
        public float GetPointOrientation(Vector2D point)
        {
            return ((End.X - Start.X) * (point.Y - Start.Y) - (point.X - Start.X) * (End.Y - Start.Y));


        }
        public bool IsPointOnLine(Vector2D point)
        {
            float d = GetPointOrientation(point);
            return (d == 0 && point.IsBetweenPoints(Start, End));

        }
        public bool IsPointBetweenStartAndEnd(Vector2D point)
        {
            return point.IsBetweenPoints(Start, End);
        }

        public Vector2D GetClosestPoint(Vector2D point)
        {
            Vector2D c = point - Start;
            Vector2D v = End - Start;
            float d = v.Length;
            v = v / d;
            float t = v.DotProduct(c);

            if (t < 0.0f) return Start;
            if (t > d) return End;

            v = v * t;
            return Start + v;
        }
        // Does this still work? (GetIntersectionWithSphere)
        public bool GetIntersectionWithCircle(Vector2D sorigin, float sradius, out double outdistance)
        {
            outdistance = 0.0;
            Vector2D q = sorigin - Start;
            double c = q.Length;
            Vector2D vv = Vector;
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
            if (o is Line2D)
                return GetHashCode() == o.GetHashCode();
            return base.Equals(o);
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        public static Line2D From(float xMin, float yMin, float xMax, float yMax)
        {
            Line2D line = new Line2D();
            line.Start = new Vector2D();
            line.End = new Vector2D();
            line.Start.Set(xMin, yMin);
            line.End.Set(xMax, yMax);
            return line;
        }

        public float[] ToUnmanaged()
        { return new float[] { Start.X, Start.Y, End.X, End.Y }; }
        public static Line2D FromUnmanaged(float[] b)
        {
            return From(b[0], b[1], b[2], b[3]);
        }

        public static Line2D operator +(Line2D first, Vector2D point)
        {
            return new Line2D(first.Start + point, first.End + point);
        }
        public static Line2D operator -(Line2D first, Vector2D point)
        {
            return new Line2D(first.Start - point, first.End - point);
        }

        public static Line2D operator +(Vector2D point, Line2D first)
        {
            return new Line2D(first.Start + point, first.End + point);
        }
        public static Line2D operator -(Vector2D point, Line2D first)
        {
            return new Line2D(point - first.Start, point - first.End);
        }
        public static bool operator ==(Line2D first, Line2D other)
        {
            return (first.Start == other.Start && first.End == other.End) ||
                (first.End == other.Start && first.Start == other.End);
        }
        public static bool operator !=(Line2D first, Line2D other)
        {
            return !((first.Start == other.Start && first.End == other.End) ||
                (first.End == other.Start && first.Start == other.End));
        }

    }
}
