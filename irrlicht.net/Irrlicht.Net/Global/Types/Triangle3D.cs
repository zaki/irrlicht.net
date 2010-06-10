using System;
using System.Text;

namespace IrrlichtNETCP
{
    public struct Triangle3D
    {
        public Vector3D PointA, PointB, PointC;

        public Triangle3D(Vector3D A, Vector3D B, Vector3D C)
        {
            PointA = A;
            PointB = B;
            PointC = C;
        }
        public Triangle3D(float AX, float AY, float AZ, float BX, float BY, float BZ, float CX, float CY, float CZ)
            : this(new Vector3D(AX, AY, AZ), new Vector3D(BX, BY, BZ), new Vector3D(CX, CY, CZ))
        {
        }

        public float[] ToUnmanaged()
        {
            return new float[]
                { PointA.X, PointA.Y, PointA.Z,
                  PointB.X, PointB.Y, PointB.Z,
                  PointC.X, PointC.Y, PointC.Z };
        }

        public static Triangle3D FromUnmanaged(float[] un)
        {
            return new Triangle3D(un[0], un[1], un[2],
                                  un[3], un[4], un[5],
                                  un[6], un[7], un[8]);
        }

        /// <summary>
        /// Returns an intersection with a 3d line.
        /// </summary>
        /// <param name="line">Line to intersect with.</param>
        /// <param name="outIntersection">Place to store the intersection point, if there is one.</param>
        /// <returns>Returns true if there was an intersection, false if there was not.</returns>
        public bool GetIntersectionWithLimitedLine(Line3D line, out Vector3D outIntersection)
        {
            return GetIntersectionWithLine(line.Start, line.Vector, out outIntersection) &&
                   outIntersection.IsBetweenPoints(line.Start, line.End);
        }

        /// <summary>
        /// Returns an intersection with a 3d line.
        /// Please note that also points are returned as intersection, which
        /// are on the line, but not between the start and end point of the line.
        /// If you want the returned point be between start and end, please
        /// use getIntersectionWithLimitedLine().
        /// </summary>
        /// <param name="linePoint">Vector of the line to intersect with.</param>
        /// <param name="lineVect">Point of the line to intersect with.</param>
        /// <param name="outIntersection">Place to store the intersection point, if there is one.</param>
        /// <returns>Returns true if there was an intersection, false if there was not.</returns>
        bool GetIntersectionWithLine(Vector3D linePoint, Vector3D lineVect, out Vector3D outIntersection)
        {
            if (GetIntersectionOfPlaneWithLine(linePoint, lineVect, out outIntersection))
                return IsPointInside(outIntersection);

            return false;
        }

        /// <summary>
        /// Calculates the intersection between a 3d line and
        /// the plane the triangle is on.
        /// </summary>
        /// <param name="linePoint">Vector of the line to intersect with</param>
        /// <param name="lineVect">Point of the line to intersect with.</param>
        /// <param name="intersection">Place to store the intersection point, if there is one.</param>
        /// <returns>Returns true if there was an intersection, false if there was not.</returns>
        public bool GetIntersectionOfPlaneWithLine(Vector3D linePoint,
                                                   Vector3D lineVect,
                                                   out Vector3D intersection)
        {
            Vector3D normal = Normal.Normalize();

            //float t2 = Normal.DotProduct(lineVect);

            float t2 = normal.DotProduct(lineVect); //corrected line

            intersection = new Vector3D();
            if (NewMath.IsZero(t2))
                return false;
            float d = PointA.DotProduct(normal);
            //float t = -(Normal.DotProduct(linePoint) - d) / t2;

            float t = -(normal.DotProduct(linePoint) - d) / t2; //corrected line
            intersection = linePoint + (lineVect * t);
            return true;
        }

        /// <summary>
        /// Retrieves the normal
        /// Note : this normal is not normalized.
        /// </summary>
        public Vector3D Normal
        {
            get
            {
                return (PointB - PointA).CrossProduct(PointC - PointA);
            }
        }


        //! Returns if a point is inside the triangle
        //! \param p: Point to test. Assumes that this point is already on the plane
        //! of the triangle.
        //! \return Returns true if the point is inside the triangle, otherwise false.
        bool IsPointInside(Vector3D p)
        {
            return (IsOnSameSide(p, PointA, PointB, PointC) &&
                    IsOnSameSide(p, PointB, PointA, PointC) &&
                    IsOnSameSide(p, PointC, PointA, PointB));
        }

        public bool IsOnSameSide(Vector3D p1, Vector3D p2, Vector3D a, Vector3D b)
        {
            Vector3D bminusa = b - a;
            Vector3D cp1 = bminusa.CrossProduct(p1 - a);
            Vector3D cp2 = bminusa.CrossProduct(p2 - a);
            return (cp1.DotProduct(cp2) >= NewMath.ROUNDING_ERROR);
        }

        public override string ToString()
        {
            return GetType() + "; A = " + PointA + "; B = " + PointB + "; C = " + PointC;
        }
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }
        public override bool Equals(object obj)
        {
            if (obj is Triangle3D)
                return obj.GetHashCode() == GetHashCode();
            return base.Equals(obj);
        }
    }
}
