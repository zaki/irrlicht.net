using IrrlichtNETCP;
using System;

namespace IrrlichtNETCP
{
    public struct Box3D
    {
        public Box3D(float xMin, float yMin, float zMin, float xMax, float yMax, float zMax)
        {
            MinEdge = new Vector3D();
            MaxEdge = new Vector3D();
            MinEdge.Set(xMin, yMin, zMin);
            MaxEdge.Set(xMax, yMax, zMax);
        }

        public Box3D(Vector3D min, Vector3D max)
        {
            MinEdge = min;
            MaxEdge = max;
        }

        public void Set(float xMin, float yMin, float zMin, float xMax, float yMax, float zMax)
        {
            MinEdge = new Vector3D();
            MaxEdge = new Vector3D();
            MinEdge.Set(xMin, yMin, zMin);
            MaxEdge.Set(xMax, yMax, zMax);
        }

        /// <summary>
        /// Adds a point to the bounding box, causing it to grow bigger,
        /// if point is outside of the box.
        /// </summary>
        /// <param name="x"> X Coordinate of the point to add to this box.</param>
        /// <param name="y"> Y Coordinate of the point to add to this box.</param>
        /// <param name="z"> Z Coordinate of the point to add to this box.</param>
        public void AddInternalPoint(float x, float y, float z)
        {
            if (x > MaxEdge.X) MaxEdge.X = x;
            if (y > MaxEdge.Y) MaxEdge.Y = y;
            if (z > MaxEdge.Z) MaxEdge.Z = z;

            if (x < MinEdge.X) MinEdge.X = x;
            if (y < MinEdge.Y) MinEdge.Y = y;
            if (z < MinEdge.Z) MinEdge.Z = z;
        }

        /// <summary>
        /// Adds a point to the bounding box, causing it to grow bigger,
        /// if point is outside of the box
        /// </summary>
        /// <param name="p"> Point to add into the box.</param>
        public void AddInternalPoint(Vector3D p)
        {
            AddInternalPoint(p.X, p.Y, p.Z);
        }

        /// <summary>
        /// Adds an other bounding box to the bounding box, causing it to grow bigger,
        /// if the box is outside of the box
        /// </summary>
        /// <param name="b"> Other bounding box to add into this box.</param>
        public void AddInternalBox(Box3D b)
        {
            AddInternalPoint(b.MaxEdge);
            AddInternalPoint(b.MinEdge);
        }

        static Random _chance = new Random();
        public Vector3D RandomPoint()
        {
            float xStart = Math.Min(MinEdge.X, MaxEdge.X);
            float xEnd = Math.Max(MinEdge.X, MaxEdge.X);

            float yStart = Math.Min(MinEdge.Y, MaxEdge.Y);
            float yEnd = Math.Max(MinEdge.Y, MaxEdge.Y);

            float zStart = Math.Min(MinEdge.Z, MaxEdge.Z);
            float zEnd = Math.Max(MinEdge.Z, MaxEdge.Z);

            double d1 = _chance.NextDouble();
            double d2 = _chance.NextDouble();
            double d3 = _chance.NextDouble();
            return new Vector3D((float)(xStart + d1 * (xEnd - xStart)),
                                (float)(yStart + d2 * (yEnd - yStart)),
                                (float)(zStart + d3 * (zEnd - zStart)));
        }

        /// <summary>
        /// Determinates if a point is within this box.
        /// </summary>
        /// <param name="p">: Point to check.</param>
        /// <returns> Returns true if the point is withing the box, and false if it is not.</returns>
        public bool IsPointInside(Vector3D p)
        {
            return (p.X >= MinEdge.X && p.X <= MaxEdge.X &&
                p.Y >= MinEdge.Y && p.Y <= MaxEdge.Y &&
                p.Z >= MinEdge.Z && p.Z <= MaxEdge.Z);
        }

        /// <summary>
        /// Determinates if a point is within this box and its borders.
        /// </summary>
        /// <param name="p"> Point to check.</param>
        /// <returns> Returns true if the point is withing the box, and false if it is not.</returns>
        public bool IsPointTotalInside(Vector3D p)
        {
            return (p.X > MinEdge.X && p.X < MaxEdge.X &&
                p.Y > MinEdge.Y && p.Y < MaxEdge.Y &&
                p.Z > MinEdge.Z && p.Z < MaxEdge.Z);
        }

        /// <summary>
        /// Determinates if the box intersects with an other box.
        /// </summary>
        /// <param name="other">Other box to check a intersection with.</param>
        /// <returns> Returns true if there is a intersection with the other box,
        /// otherwise false.</returns>
        public bool IntersectsWithBox(Box3D other)
        {
            return (MinEdge.X <= other.MaxEdge.X &&
                MinEdge.Y <= other.MaxEdge.Y &&
                MinEdge.Z <= other.MaxEdge.Z &&
                MaxEdge.X >= other.MinEdge.X &&
                MaxEdge.Y >= other.MinEdge.Y &&
                MaxEdge.Z >= other.MinEdge.Z);
        }

        /// <summary>
        /// Stores all 8 edges of the box into a array
        /// </summary>
        /// <param name="edges">Aray of 8 edges</param>
        public void GetEdges(out Vector3D[] edges)
        {
            edges = new Vector3D[8];
            Vector3D middle = (MinEdge + MaxEdge) / 2;
            Vector3D diag = middle - MaxEdge;

            /*
             Edges are stored in this way:
             Hey, am I an ascii artist, or what? :) niko.
               /1--------/3
              / |       / |
             /  |      /  |
             5---------7  |
             |  0- - - | -2
             | /       |  /
             |/        | /
             4---------6/
             */

            edges[0].Set(middle.X + diag.X, middle.Y + diag.Y, middle.Z + diag.Z);
            edges[1].Set(middle.X + diag.X, middle.Y - diag.Y, middle.Z + diag.Z);
            edges[2].Set(middle.X + diag.X, middle.Y + diag.Y, middle.Z - diag.Z);
            edges[3].Set(middle.X + diag.X, middle.Y - diag.Y, middle.Z - diag.Z);
            edges[4].Set(middle.X - diag.X, middle.Y + diag.Y, middle.Z + diag.Z);
            edges[5].Set(middle.X - diag.X, middle.Y - diag.Y, middle.Z + diag.Z);
            edges[6].Set(middle.X - diag.X, middle.Y + diag.Y, middle.Z - diag.Z);
            edges[7].Set(middle.X - diag.X, middle.Y - diag.Y, middle.Z - diag.Z);
        }

        /// <summary>
        /// Checks an intersection with some line
        /// </summary>
        /// <param name="LineToCol">
        /// A line to be checked <see cref="Line3D"/>
        /// </param>
        /// <returns>
        /// A result of the collision <see cref="System.Boolean"/>
        /// </returns>
        public bool IntersectsWithLimitedLine(Line3D lineToCol)
        {

            Vector3D lineVector = lineToCol.Vector.Normalize();
            float halfLength = (float)(lineToCol.Length * 0.5);
            Vector3D t = Center - lineToCol.Middle;
            Vector3D e = (MaxEdge - MinEdge); e = e * (float)(0.5);

            if ((Math.Abs(t.X) > e.X + halfLength * Math.Abs(lineVector.X)) ||
                (Math.Abs(t.Y) > e.Y + halfLength * Math.Abs(lineVector.Y)) ||
                (Math.Abs(t.Z) > e.Z + halfLength * Math.Abs(lineVector.Z)))
                return false;

            float r = e.Y * (float)Math.Abs(lineVector.Z) + e.Z * Math.Abs(lineVector.Y);
            if (Math.Abs(t.Y * lineVector.Z - t.Z * lineVector.Y) > r)
                return false;

            r = e.X * (float)Math.Abs(lineVector.Z) + e.Z * Math.Abs(lineVector.X);
            if (Math.Abs(t.Z * lineVector.X - t.X * lineVector.Z) > r)
                return false;

            r = e.X * (float)Math.Abs(lineVector.Y) + e.Y * Math.Abs(lineVector.X);
            if (Math.Abs(t.X * lineVector.Y - t.Y * lineVector.X) > r)
                return false;

            return true;

        }

        /// <summary>
        /// returns center of the bounding box
        /// </summary>
        public Vector3D Center
        {
            get
            {
                return (MinEdge + MaxEdge) / 2;
            }
        }

        public Vector3D MinEdge;
        public Vector3D MaxEdge;

        public static Box3D From(float xMin, float yMin, float zMin, float xMax, float yMax, float zMax)
        {
            Box3D box;
            box.MinEdge = new Vector3D();
            box.MaxEdge = new Vector3D();
            box.MinEdge.Set(xMin, yMin, zMin);
            box.MaxEdge.Set(xMax, yMax, zMax);
            return box;
        }

        public float[] ToUnmanaged()
        { return new float[] { MinEdge.X, MinEdge.Y, MinEdge.Z, MaxEdge.X, MaxEdge.Y, MaxEdge.Z }; }
        public static Box3D FromUnmanaged(float[] b)
        {
            return From(b[0], b[1], b[2], b[3], b[4], b[5]);
        }
        public override string ToString()
        {
            return "\"Type = " + GetType() + "; MinEdge = " + MinEdge + "; MaxEdge = " + MaxEdge + "\"";
        }
        public override bool Equals(object o)
        {
            if (o is Box3D)
                return GetHashCode() == o.GetHashCode();
            return base.Equals(o);
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }
    }
}

