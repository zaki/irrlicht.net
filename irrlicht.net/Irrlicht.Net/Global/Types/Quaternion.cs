using System;


namespace IrrlichtNETCP
{
    public class Quaternion
    {
        float m_x;
        float m_y;
        float m_z;
        float m_w;

        #region Constructors
        //! Default Constructor
        public Quaternion()
        {
            m_x = m_y = m_z = m_w = 0;
        }
        //! Constructor
        public Quaternion(float X, float Y, float Z, float W)
        {
            m_x = X;
            m_y = Y;
            m_z = Z;
            m_w = W;
        }
        //! Constructor which converts euler angles to a Quaternion
        public Quaternion(float x, float y, float z)
        {
            double angle;

            angle = x * 0.5;
            double sr = (float)Math.Sin(angle);
            double cr = (float)Math.Cos(angle);

            angle = y * 0.5;
            double sp = (float)Math.Sin(angle);
            double cp = (float)Math.Cos(angle);

            angle = z * 0.5;
            double sy = (float)Math.Sin(angle);
            double cy = (float)Math.Cos(angle);

            double cpcy = cp * cy;
            double spcy = sp * cy;
            double cpsy = cp * sy;
            double spsy = sp * sy;

            m_x = (float)(sr * cpcy - cr * spsy);
            m_y = (float)(cr * spcy + sr * cpsy);
            m_z = (float)(cr * cpsy - sr * spcy);
            m_w = (float)(cr * cpcy + sr * spsy);

            Normalize();
        }
        //! Constructor which converts a matrix to a Quaternion
        public Quaternion(Matrix4 mat)
        {
            this.FromMatrix(mat);
        }
        // Copy constructor (had to do this because we cannot overload operator "=" in C#
        public Quaternion(Quaternion other)
        {
            m_x = other.X;
            m_y = other.Y;
            m_z = other.Z;
            m_w = other.W;
        }
        #endregion
        #region Operators
        //! equal operator
        public static bool operator ==(Quaternion lhs, Quaternion rhs)
        {
            if (lhs.X != rhs.X)
                return false;
            if (lhs.Y != rhs.Y)
                return false;
            if (lhs.Z != rhs.Z)
                return false;
            if (lhs.W != rhs.W)
                return false;

            return true;
        }
        //! inequality operator
        public static bool operator !=(Quaternion lhs, Quaternion rhs)
        {
            if (lhs.X != rhs.X)
                return true;
            if (lhs.Y != rhs.Y)
                return true;
            if (lhs.Z != rhs.Z)
                return true;
            if (lhs.W != rhs.W)
                return true;

            return false;
        }
        //! Sum operator
        public static Quaternion operator +(Quaternion lhs, Quaternion rhs)
        {
            return new Quaternion(lhs.X + rhs.X, lhs.Y + rhs.Y, lhs.Z + rhs.Z, lhs.W + rhs.W);
        }
        //! multiplication by a quaternion operator
        public static Quaternion operator *(Quaternion lhs, Quaternion rhs)
        {
            Quaternion tmp = new Quaternion();

            tmp.W = (rhs.W * lhs.W) - (rhs.X * lhs.X) - (rhs.Y * lhs.Y) - (rhs.Z * lhs.Z);
            tmp.X = (rhs.W * lhs.X) + (rhs.X * lhs.W) + (rhs.Y * lhs.Z) - (rhs.Z * lhs.Y);
            tmp.Y = (rhs.W * lhs.Y) + (rhs.Y * lhs.W) + (rhs.Z * lhs.X) - (rhs.X * lhs.Z);
            tmp.Z = (rhs.W * lhs.Z) + (rhs.Z * lhs.W) + (rhs.X * lhs.Y) - (rhs.Y * lhs.X);

            return tmp;
        }
        //! left multiplication by a float operator
        public static Quaternion operator *(float lhs, Quaternion rhs)
        {
            return new Quaternion(lhs * rhs.X, lhs * rhs.Y, lhs * rhs.Z, lhs * rhs.W);
        }
        //! right multiplication by a float operator
        public static Quaternion operator *(Quaternion rhs, float lhs)
        {
            return new Quaternion(lhs * rhs.X, lhs * rhs.Y, lhs * rhs.Z, lhs * rhs.W);
        }
        //! multiplication operator by a vector
        public static Vector3D operator *(Vector3D lhs, Quaternion rhs)
        {
            Vector3D uv, uuv;
            Vector3D qvec = new Vector3D(rhs.X, rhs.Y, rhs.Z);
            uv = qvec.CrossProduct(lhs);
            uuv = qvec.CrossProduct(uv);
            uv *= (2.0f * rhs.W);
            uuv *= 2.0f;

            return lhs + uv + uuv;
        }
        // override Equals
        public override bool Equals(object o)
        {
            if (o is Quaternion)
                return GetHashCode() == o.GetHashCode();
            return base.Equals(o);
        }
        // needed from Equals override
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }
        // ToString override
        public override string ToString()
        {
            return "\"Type = " + GetType() + "; X = " + X + "; Y = " + Y + "; Z = " + Z + "; W = " + W + "\"";
        }
        //! multiplication operator
        //public static Quaternion operator *= (float lhs, Quaternion rhs);
        //! multiplication operator
        //public static Quaternion operator *=( Quaternion& other);
        //! assignment operator
        //public static bool operator = (Quaternion lhs, Quaternion rhs)
        //{
        //    lhs.X = rhs.X;
        //    lhs.Y = rhs.Y;
        //    lhs.Z = rhs.Z;
        //    lhs.W = rhs.W;
        //    return lhs;
        //}

        //! add operator
        #endregion
        #region Static Methods
        //! sets new Quaternion
        public static Quaternion From(float x, float y, float z, float w)
        {
            return new Quaternion(x, y, z, w);
        }
        //! sets new Quaternion based on euler angles
        public static Quaternion FromEulerAngles(float x, float y, float z)
        {
            Quaternion t_tmp = new Quaternion();
            //TODO Duplicated code (Method Set(x,y,z))
            double angle;

            angle = x * 0.5;
            double sr = (float)Math.Sin(angle);
            double cr = (float)Math.Cos(angle);

            angle = y * 0.5;
            double sp = (float)Math.Sin(angle);
            double cp = (float)Math.Cos(angle);

            angle = z * 0.5;
            double sy = (float)Math.Sin(angle);
            double cy = (float)Math.Cos(angle);

            double cpcy = cp * cy;
            double spcy = sp * cy;
            double cpsy = cp * sy;
            double spsy = sp * sy;

            t_tmp.X = (float)(sr * cpcy - cr * spsy);
            t_tmp.Y = (float)(cr * spcy + sr * cpsy);
            t_tmp.Z = (float)(cr * cpsy - sr * spcy);
            t_tmp.W = (float)(cr * cpcy + sr * spsy);

            t_tmp.Normalize();
            return t_tmp;
        }
        #endregion
        #region Non-Static Methods
        //! Quaternion creation from matrix
        public Quaternion FromMatrix(Matrix4 m)
        {
            float diag = m.GetM(0, 0) + m.GetM(1, 1) + m.GetM(2, 2) + 1;
            float scale = 0.0f;

            if (diag > 0.0f)
            {
                scale = (float)Math.Sqrt(diag) * 2.0f; // get scale from diagonal

                // TODO: speed this up
                m_x = (m.GetM(2, 1) - m.GetM(1, 2)) / scale;
                m_y = (m.GetM(0, 2) - m.GetM(2, 0)) / scale;
                m_z = (m.GetM(1, 0) - m.GetM(0, 1)) / scale;
                m_w = 0.25f * scale;
            }
            else
            {
                if (m.GetM(0, 0) > m.GetM(1, 1) && m.GetM(0, 0) > m.GetM(2, 2))
                {
                    // 1st element of diag is greatest value
                    // find scale according to 1st element, and double it
                    scale = (float)Math.Sqrt(1.0f + m.GetM(0, 0) - m.GetM(1, 1) - m.GetM(2, 2)) * 2.0f;

                    // TODO: speed this up
                    m_x = 0.25f * scale;
                    m_y = (m.GetM(0, 1) + m.GetM(1, 0)) / scale;
                    m_z = (m.GetM(2, 0) + m.GetM(0, 2)) / scale;
                    m_w = (m.GetM(2, 1) - m.GetM(1, 2)) / scale;
                }
                else if (m.GetM(1, 1) > m.GetM(2, 2))
                {
                    // 2nd element of diag is greatest value
                    // find scale according to 2nd element, and double it
                    scale = (float)Math.Sqrt(1.0f + m.GetM(1, 1) - m.GetM(0, 0) - m.GetM(2, 2)) * 2.0f;

                    // TODO: speed this up
                    m_x = (m.GetM(0, 1) + m.GetM(1, 0)) / scale;
                    m_y = 0.25f * scale;
                    m_z = (m.GetM(1, 2) + m.GetM(2, 1)) / scale;
                    m_w = (m.GetM(0, 2) - m.GetM(2, 0)) / scale;
                }
                else
                {
                    // 3rd element of diag is greatest value
                    // find scale according to 3rd element, and double it
                    scale = (float)Math.Sqrt(1.0f + m.GetM(2, 2) - m.GetM(0, 0) - m.GetM(1, 1)) * 2.0f;

                    // TODO: speed this up
                    m_x = (m.GetM(0, 2) + m.GetM(2, 0)) / scale;
                    m_y = (m.GetM(1, 2) + m.GetM(2, 1)) / scale;
                    m_z = 0.25f * scale;
                    m_w = (m.GetM(1, 0) - m.GetM(0, 1)) / scale;
                }
            }

            Normalize();
            return this;
        }
        //! calculates the dot product
        public float GetDotProduct(Quaternion q2)
        {
            return (m_x * q2.X) + (m_y * q2.Y) + (m_z * q2.Z) + (m_w * q2.W);
        }
        //! normalizes the Quaternion
        public Quaternion Normalize()
        {
            float n = m_x * m_x + m_y * m_y + m_z * m_z + m_w * m_w;

            if (n == 1)
                return this;

            n = 1.0f / (float)Math.Sqrt(n);
            m_x *= n;
            m_y *= n;
            m_z *= n;
            m_w *= n;

            return this;
        }
        //! Creates a matrix from this Quaternion
        public Matrix4 Matrix
        {
            get
            {
                Matrix4 m = new Matrix4();

                Vector3D frame_x = new Vector3D(
                          1.0f - 2.0f * m_y * m_y - 2.0f * m_z * m_z,
                          2.0f * m_x * m_y + 2.0f * m_z * m_w,
                          2.0f * m_x * m_z - 2.0f * m_y * m_w).Normalize();
                m.M[0] = frame_x.X;
                m.M[1] = frame_x.Y;
                m.M[2] = frame_x.Z;
                m.M[3] = 0.0f;

                Vector3D frame_y = new Vector3D(
                         2.0f * m_x * m_y - 2.0f * m_z * m_w,
                         1.0f - 2.0f * m_x * m_x - 2.0f * m_z * m_z,
                         2.0f * m_z * m_y + 2.0f * m_x * m_w).Normalize();
                m.M[4] = frame_y.X;
                m.M[5] = frame_y.Y;
                m.M[6] = frame_y.Z;
                m.M[7] = 0.0f;

                Vector3D frame_z = new Vector3D(
                         2.0f * m_x * m_z + 2.0f * m_y * m_w,
                         2.0f * m_z * m_y - 2.0f * m_x * m_w,
                         1.0f - 2.0f * m_x * m_x - 2.0f * m_y * m_y).Normalize();
                m.M[8] = frame_z.X;
                m.M[9] = frame_z.Y;
                m.M[10] = frame_z.Z;
                m.M[11] = 0.0f;

                m.M[12] = 0.0f;
                m.M[13] = 0.0f;
                m.M[14] = 0.0f;
                m.M[15] = 1.0f;

                return m;
            }
            //set {}
        }
        //Set from x,y,z,w
        public void Set(float x, float y, float z, float w)
        {
            m_x = x;
            m_y = y;
            m_z = z;
            m_w = w;
        }
        //Set from euler angles
        public void Set(float x, float y, float z)
        {
            double angle;

            angle = x * 0.5;
            double sr = (float)Math.Sin(angle);
            double cr = (float)Math.Cos(angle);

            angle = y * 0.5;
            double sp = (float)Math.Sin(angle);
            double cp = (float)Math.Cos(angle);

            angle = z * 0.5;
            double sy = (float)Math.Sin(angle);
            double cy = (float)Math.Cos(angle);

            double cpcy = cp * cy;
            double spcy = sp * cy;
            double cpsy = cp * sy;
            double spsy = sp * sy;

            m_x = (float)(sr * cpcy - cr * spsy);
            m_y = (float)(cr * spcy + sr * cpsy);
            m_z = (float)(cr * cpsy - sr * spcy);
            m_w = (float)(cr * cpcy + sr * spsy);

            Normalize();
        }
        //! Inverts this Quaternion
        public void makeInverse()
        {
            m_x = -m_x;
            m_y = -m_y;
            m_z = -m_z;
        }
        //! Interpolates the Quaternion between to Quaternions based on time
        public Quaternion Slerp(Quaternion q1, Quaternion q2, float time)
        {
            float angle = q1.GetDotProduct(q2);

            if (angle < 0.0f)
            {
                q1 *= -1.0f;
                angle *= -1.0f;
            }

            float scale;
            float invscale;

            if ((angle + 1.0f) > 0.05f)
            {
                if ((1.0f - angle) >= 0.05f)  // spherical interpolation
                {
                    float theta = (float)Math.Acos(angle);
                    float invsintheta = 1.0f / (float)Math.Sin(theta);
                    scale = (float)Math.Sin(theta * (1.0f - time)) * invsintheta;
                    invscale = (float)Math.Sin(theta * time) * invsintheta;
                }
                else // linear interploation
                {
                    scale = 1.0f - time;
                    invscale = time;
                }
            }
            else
            {
                q2 = new Quaternion(-q1.Y, q1.X, -q1.W, q1.Z);
                scale = (float)Math.Sin(Math.PI * (0.5f - time));
                invscale = (float)Math.Sin(Math.PI * time);
            }

            Quaternion t_tmp = (q1 * scale) + (q2 * invscale);
            this.m_x = t_tmp.X;
            this.m_y = t_tmp.Y;
            this.m_z = t_tmp.Z;
            this.m_w = t_tmp.W;
            return this;
        }
        //! axis must be unit length
        //! The Quaternion representing the rotation is
        //!  q = cos(A/2)+sin(A/2)*(x*i+y*j+z*k)
        public void fromAngleAxis(float angle, Vector3D axis)
        {
            float fHalfAngle = 0.5f * angle;
            float fSin = (float)Math.Sin(fHalfAngle);
            m_w = (float)Math.Cos(fHalfAngle);
            m_x = fSin * axis.X;
            m_y = fSin * axis.Y;
            m_z = fSin * axis.Z;
        }
        /// <summary>
        /// Returns an Euler Angles vector. Angles in radiants
        /// </summary>
        /// <param name="euler">vector to put the result into</param>
        /// <returns></returns>
        public Vector3D toEuler(out Vector3D euler)
        {
            double sqw = m_w * m_w;
            double sqx = m_x * m_x;
            double sqy = m_y * m_y;
            double sqz = m_z * m_z;

            // heading = rotation about z-axis
            euler.Z = (float)(Math.Atan2(2.0 * (m_x * m_y + m_z * m_w), (sqx - sqy - sqz + sqw)));

            // bank = rotation about x-axis
            euler.X = (float)(Math.Atan2(2.0 * (m_y * m_z + m_x * m_w), (-sqx - sqy + sqz + sqw)));

            // attitude = rotation about y-axis
            euler.Y = (float)(Math.Asin(-2.0 * (m_x * m_z - m_y * m_w)));
            return euler;
        }
        #endregion
        #region Properties
        public float X
        {
            get { return m_x; }
            set { m_x = value; }
        }
        public float Y
        {
            get { return m_y; }
            set { m_y = value; }
        }
        public float Z
        {
            get { return m_z; }
            set { m_z = value; }
        }
        public float W
        {
            get { return m_w; }
            set { m_w = value; }
        }
        #endregion
    }
}
