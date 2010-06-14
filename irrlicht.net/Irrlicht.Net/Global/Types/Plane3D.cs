using System;

namespace IrrlichtNET
{
    public struct Plane3Df
    {
        public float D;
        public Vector3D Normal;

        public Plane3Df(float px, float py, float pz, float nx, float ny, float nz)
        {
            Normal = new Vector3D(nx, ny, nz);
            D = 0.0f;
            RecalculateD(new Vector3D(px, py, pz));
        }

        public Plane3Df(Vector3D mpoint, Vector3D normal)
        {
            Normal = normal;
            D = 0.0f;
            RecalculateD(mpoint);
        }

        public Plane3Df(Vector3D point1, Vector3D point2, Vector3D point3)
        {
            Normal = new Vector3D();
            D = 0.0f;
            SetPlane(point1, point2, point3);
        }

        public Plane3Df(float d, Vector3D normal)
        {
            Normal = normal;
            D = d;
        }

        public float[] ToUnmanaged() { return new float[] { Normal.X, Normal.Y, Normal.Z, D }; }

        public void RecalculateD(Vector3D mpoint)
        {
            D = -mpoint.DotProduct(Normal);
        }

        public void SetPlane(Vector3D point1, Vector3D point2, Vector3D point3)
        {
            Normal = (point2 - point1).CrossProduct(point3 - point1);
            Normal.Normalize();
            RecalculateD(point1);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return (this == (Plane3Df)obj);

        }

        public override int GetHashCode()
        {
            return (D.GetHashCode() ^ Normal.GetHashCode());
        }

        public static bool operator ==(Plane3Df x, Plane3Df y)
        {
            return (Equals(x.D, y.D) && x.Normal == y.Normal);
        }

        public static bool operator !=(Plane3Df x, Plane3Df y)
        {
            return (!(x == y));
        }

        public bool GetIntersectionWithLine(Vector3D linePoint, Vector3D lineVector, out Vector3D outIntersection)
        {
            outIntersection = new Vector3D();

            float t2 = Normal.DotProduct(lineVector);

            if (t2 == 0)
                return (false);

            float t = -(Normal.DotProduct(linePoint) + D) / t2;
            outIntersection = linePoint + (lineVector * t);
            return (true);
        }

        float GetKnownIntersectionWithLine(Vector3D linePoint1, Vector3D linePoint2)
        {
            Vector3D vect = linePoint2 - linePoint1;
            float t2 = (float)Normal.DotProduct(vect);
            return (-((Normal.DotProduct(linePoint1) + D) / t2));
        }

        Vector3D GetMemberPoint()
        {
            return (Normal * -D);
        }
    }
}
