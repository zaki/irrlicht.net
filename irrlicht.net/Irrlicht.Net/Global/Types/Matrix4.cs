using System;

namespace IrrlichtNET
{
    public class Matrix4
    {
        public float[] M;

        public Matrix4()
        {
            MakeIdentity();
        }

        public Matrix4(float[] m)
        {
            M = m;
        }

        public static Matrix4 From(float[] m)
        {
            return new Matrix4(m);
        }

        public Vector3D Translation
        {
            get
            {
                return new Vector3D(M[12], M[13], M[14]);
            }
            set
            {
                M[12] = value.X;
                M[13] = value.Y;
                M[14] = value.Z;
            }
        }

        public Vector3D Scale
        {
            get
            {
                return new Vector3D(M[0], M[5], M[10]);
            }
            set
            {
                M[0] = value.X;
                M[5] = value.Y;
                M[10] = value.Z;
            }
        }

        public Vector3D RotationRadian
        {
            get
            {
                return RotationDegrees * NewMath.DEGTORAD;
            }
            set
            {
                double cr = Math.Cos(value.X);
                double sr = Math.Sin(value.X);
                double cp = Math.Cos(value.Y);
                double sp = Math.Sin(value.Y);
                double cy = Math.Cos(value.Z);
                double sy = Math.Sin(value.Z);

                M[0] = (float)(cp * cy);
                M[1] = (float)(cp * sy);
                M[2] = (float)(-sp);

                double srsp = sr * sp;
                double crsp = cr * sp;

                M[4] = (float)(srsp * cy - cr * sy);
                M[5] = (float)(srsp * sy + cr * cy);
                M[6] = (float)(sr * cp);

                M[8] = (float)(crsp * cy + sr * sy);
                M[9] = (float)(crsp * sy - sr * cy);
                M[10] = (float)(cr * cp);
            }
        }

        public Vector3D RotationDegrees
        {
            get
            {
                Matrix4 mat = this;

                double Y = -Math.Asin(mat.GetM(2, 0));
                double C = Math.Cos(Y);
                Y *= (180.0 / Math.PI);

                double rotx, roty, X, Z;

                if (Math.Abs(C) > 0.0005f)
                {
                    rotx = mat.GetM(2, 2) / C;
                    roty = mat.GetM(2, 1) / C;

                    X = Math.Atan2(roty, rotx) * (180.0 / Math.PI);

                    rotx = mat.GetM(0, 0) / C;
                    roty = mat.GetM(1, 0) / C;
                    Z = Math.Atan2(roty, rotx) * (180.0 / Math.PI);
                }
                else
                {
                    X = 0.0f;
                    rotx = mat.GetM(1, 1);
                    roty = -mat.GetM(0, 1);
                    Z = Math.Atan2(roty, rotx) * (180.0 / Math.PI);
                }

                // fix values that get below zero
                // before it would set (!) values to 360
                // that where above 360:
                if (X < 0.00) X += 360.00;
                if (Y < 0.00) Y += 360.00;
                if (Z < 0.00) Z += 360.00;

                return new Vector3D((float)X, (float)Y, (float)Z);
            }
            set
            {
                RotationRadian = value * NewMath.DEGTORAD;
            }
        }

        public Vector3D InverseRotationDegrees
        {
            set
            {
                InverseRotationRadians = value * NewMath.DEGTORAD;
            }
        }

        public Vector3D InverseRotationRadians
        {
            set
            {
                double cr = Math.Cos(value.X);
                double sr = Math.Sin(value.X);
                double cp = Math.Cos(value.Y);
                double sp = Math.Sin(value.Y);
                double cy = Math.Cos(value.Z);
                double sy = Math.Sin(value.Z);

                M[0] = (float)(cp * cy);
                M[4] = (float)(cp * sy);
                M[8] = (float)(-sp);

                double srsp = sr * sp;
                double crsp = cr * sp;

                M[1] = (float)(srsp * cy - cr * sy);
                M[5] = (float)(srsp * sy + cr * cy);
                M[9] = (float)(sr * cp);

                M[2] = (float)(crsp * cy + sr * sy);
                M[6] = (float)(crsp * sy - sr * cy);
                M[10] = (float)(cr * cp);
            }
        }

        /// <summary> Set matrix to identity. </summary>
        public void MakeIdentity()
        {
            M = new float[] { 1f, 0f, 0f, 0f,
                              0f, 1f, 0f, 0f,
                              0f, 0f, 1f, 0f,
                              0f, 0f, 0f, 1f };
        }

        /// <summary> Direct accessing every row and colum of the matrix values </summary>
        public float GetM(int col, int row)
        {
            if (row < 0 || row >= 4)
                throw new ArgumentOutOfRangeException("row", "Invalid index for accessing matrix members");
            if (col < 0 || col >= 4)
                throw new ArgumentOutOfRangeException("col", "Invalid index for accessing matrix members");

            return M[row * 4 + col];
        }

        public void SetM(int col, int row, float m)
        {
            if (row < 0 || row >= 4)
                throw new ArgumentOutOfRangeException("row", "Invalid index for accessing matrix members");
            if (col < 0 || col >= 4)
                throw new ArgumentOutOfRangeException("col", "Invalid index for accessing matrix members");

            M[row * 4 + col] = m;
        }

        private float GetMInsecure(int col, int row)
        {
            return M[row * 4 + col];
        }

        private void SetMInsecure(int col, int row, float m)
        {
            M[row * 4 + col] = m;
        }

        /// <summary> Returns true if the matrix is the identity matrix. </summary>
        public bool IsIdentity()
        {
            for (int i = 0; i < 4; ++i)
                for (int j = 0; j < 4; ++j)
                    if (j != i)
                    {
                        if (GetM(i, j) < -0.0000001f ||
                            GetM(i, j) > 0.0000001f)
                            return false;
                    }
                    else
                    {
                        if (GetM(i, j) < 0.9999999f ||
                            GetM(i, j) > 1.0000001f)
                            return false;
                    }

            return true;
        }

        public Matrix4 GetTransposed()
        {
            float[] newM = new float[16];

            for (int r = 0; r < 4; ++r)
                for (int c = 0; c < 4; ++c)
                    newM[r * 4 + c] = GetMInsecure(c, r);

            return new Matrix4(newM);
        }

        public static Matrix4 operator *(Matrix4 a, Matrix4 b)
        {
            Matrix4 tmtrx = new Matrix4();

            tmtrx.M[0] = a.M[0] * b.M[0] + a.M[4] * b.M[1] + a.M[8] * b.M[2] + a.M[12] * b.M[3];
            tmtrx.M[1] = a.M[1] * b.M[0] + a.M[5] * b.M[1] + a.M[9] * b.M[2] + a.M[13] * b.M[3];
            tmtrx.M[2] = a.M[2] * b.M[0] + a.M[6] * b.M[1] + a.M[10] * b.M[2] + a.M[14] * b.M[3];
            tmtrx.M[3] = a.M[3] * b.M[0] + a.M[7] * b.M[1] + a.M[11] * b.M[2] + a.M[15] * b.M[3];

            tmtrx.M[4] = a.M[0] * b.M[4] + a.M[4] * b.M[5] + a.M[8] * b.M[6] + a.M[12] * b.M[7];
            tmtrx.M[5] = a.M[1] * b.M[4] + a.M[5] * b.M[5] + a.M[9] * b.M[6] + a.M[13] * b.M[7];
            tmtrx.M[6] = a.M[2] * b.M[4] + a.M[6] * b.M[5] + a.M[10] * b.M[6] + a.M[14] * b.M[7];
            tmtrx.M[7] = a.M[3] * b.M[4] + a.M[7] * b.M[5] + a.M[11] * b.M[6] + a.M[15] * b.M[7];

            tmtrx.M[8] = a.M[0] * b.M[8] + a.M[4] * b.M[9] + a.M[8] * b.M[10] + a.M[12] * b.M[11];
            tmtrx.M[9] = a.M[1] * b.M[8] + a.M[5] * b.M[9] + a.M[9] * b.M[10] + a.M[13] * b.M[11];
            tmtrx.M[10] = a.M[2] * b.M[8] + a.M[6] * b.M[9] + a.M[10] * b.M[10] + a.M[14] * b.M[11];
            tmtrx.M[11] = a.M[3] * b.M[8] + a.M[7] * b.M[9] + a.M[11] * b.M[10] + a.M[15] * b.M[11];

            tmtrx.M[12] = a.M[0] * b.M[12] + a.M[4] * b.M[13] + a.M[8] * b.M[14] + a.M[12] * b.M[15];
            tmtrx.M[13] = a.M[1] * b.M[12] + a.M[5] * b.M[13] + a.M[9] * b.M[14] + a.M[13] * b.M[15];
            tmtrx.M[14] = a.M[2] * b.M[12] + a.M[6] * b.M[13] + a.M[10] * b.M[14] + a.M[14] * b.M[15];
            tmtrx.M[15] = a.M[3] * b.M[12] + a.M[7] * b.M[13] + a.M[11] * b.M[14] + a.M[15] * b.M[15];

            return tmtrx;
        }

        public static Matrix4 buildTextureTransform(float radians, Vector2D rotatecenter, Vector2D translate, Vector2D scale)
        {
            float c = NewMath.FCos(radians);
            float s = NewMath.FSin(radians);
            float[] M = new float[16];

            M[0] = (c * scale.X);
            M[1] = (s * scale.Y);
            M[2] = 0;
            M[3] = 0;

            M[4] = (-s * scale.X);
            M[5] = (c * scale.Y);
            M[6] = 0;
            M[7] = 0;

            M[8] = (c * scale.X * rotatecenter.X + -s * rotatecenter.Y + translate.X);
            M[9] = (s * scale.Y * rotatecenter.X + c * rotatecenter.Y + translate.Y);
            M[10] = 1;
            M[11] = 0;

            M[12] = 0;
            M[13] = 0;
            M[14] = 0;
            M[15] = 1;

            return Matrix4.From(M);
        }

        public void setTextureTranslate(float u, float v)
        {
            SetMInsecure(1, 0, u);
            SetMInsecure(1, 1, v);
        }

        public void BuildProjectionMatrixPerspectiveFovRH(float fieldOfViewRadians, float aspectRatio, float zNear, float zFar)
        {
            float h = (float)(Math.Cos(fieldOfViewRadians / 2) / Math.Sin(fieldOfViewRadians / 2));
            float w = h / aspectRatio;

            SetMInsecure(0, 0, 2 * zNear / w);
            SetMInsecure(1, 0, 0);
            SetMInsecure(2, 0, 0);
            SetMInsecure(3, 0, 0);

            SetMInsecure(0, 1, 0);
            SetMInsecure(1, 1, 2 * zNear / h);
            SetMInsecure(2, 1, 0);
            SetMInsecure(3, 1, 0);

            SetMInsecure(0, 2, 0);
            SetMInsecure(1, 2, 0);
            SetMInsecure(2, 2, zFar / (zFar - zNear));
            SetMInsecure(3, 2, -1);

            SetMInsecure(0, 3, 0);
            SetMInsecure(1, 3, 0);
            SetMInsecure(2, 3, zNear * zFar / (zNear - zFar));
            SetMInsecure(3, 3, 0);
        }

        /// <summary> Builds a left-handed perspective projection matrix based on a field of view</summary>
        public void BuildProjectionMatrixPerspectiveFovLH(float fieldOfViewRadians, float aspectRatio, float zNear, float zFar)
        {
            float h = (float)(Math.Cos(fieldOfViewRadians / 2) / Math.Sin(fieldOfViewRadians / 2));
            float w = h / aspectRatio;

            SetMInsecure(0, 0, 2 * zNear / w);
            SetMInsecure(1, 0, 0);
            SetMInsecure(2, 0, 0);
            SetMInsecure(3, 0, 0);

            SetMInsecure(0, 1, 0);
            SetMInsecure(1, 1, 2 * zNear / h);
            SetMInsecure(2, 1, 0);
            SetMInsecure(3, 1, 0);

            SetMInsecure(0, 2, 0);
            SetMInsecure(1, 2, 0);
            SetMInsecure(2, 2, zFar / (zFar - zNear));
            SetMInsecure(3, 2, 1);

            SetMInsecure(0, 3, 0);
            SetMInsecure(1, 3, 0);
            SetMInsecure(2, 3, zNear * zFar / (zNear - zFar));
            SetMInsecure(3, 3, 0);
        }

        /// <summary> Builds a right-handed perspective projection matrix.</summary>
        public void BuildProjectionMatrixPerspectiveRH(float widthOfViewVolume, float heightOfViewVolume, float zNear, float zFar)
        {
            SetMInsecure(0, 0, 2 * zNear / widthOfViewVolume);
            SetMInsecure(1, 0, 0);
            SetMInsecure(2, 0, 0);
            SetMInsecure(3, 0, 0);

            SetMInsecure(0, 1, 0);
            SetMInsecure(1, 1, 2 * zNear / heightOfViewVolume);
            SetMInsecure(2, 1, 0);
            SetMInsecure(3, 1, 0);

            SetMInsecure(0, 2, 0);
            SetMInsecure(1, 2, 0);
            SetMInsecure(2, 2, zFar / (zNear - zFar));
            SetMInsecure(3, 2, -1);

            SetMInsecure(0, 3, 0);
            SetMInsecure(1, 3, 0);
            SetMInsecure(2, 3, zNear * zFar / (zNear - zFar));
            SetMInsecure(3, 3, 0);
        }

        /// <summary> Builds a left-handed perspective projection matrix.</summary>
        public void BuildProjectionMatrixPerspectiveLH(float widthOfViewVolume, float heightOfViewVolume, float zNear, float zFar)
        {
            SetMInsecure(0, 0, 2 * zNear / widthOfViewVolume);
            SetMInsecure(1, 0, 0);
            SetMInsecure(2, 0, 0);
            SetMInsecure(3, 0, 0);

            SetMInsecure(0, 1, 0);
            SetMInsecure(1, 1, 2 * zNear / heightOfViewVolume);
            SetMInsecure(2, 1, 0);
            SetMInsecure(3, 1, 0);

            SetMInsecure(0, 2, 0);
            SetMInsecure(1, 2, 0);
            SetMInsecure(2, 2, zFar / (zNear - zFar));
            SetMInsecure(3, 2, 1);

            SetMInsecure(0, 3, 0);
            SetMInsecure(1, 3, 0);
            SetMInsecure(2, 3, zNear * zFar / (zNear - zFar));
            SetMInsecure(3, 3, 0);
        }

        /// <summary> Builds a left-handed orthogonal projection matrix.</summary>
        public void BuildProjectionMatrixOrthoLH(float widthOfViewVolume, float heightOfViewVolume, float zNear, float zFar)
        {
            SetMInsecure(0, 0, 2 / widthOfViewVolume);
            SetMInsecure(1, 0, 0);
            SetMInsecure(2, 0, 0);
            SetMInsecure(3, 0, 0);

            SetMInsecure(0, 1, 0);
            SetMInsecure(1, 1, 2 / heightOfViewVolume);
            SetMInsecure(2, 1, 0);
            SetMInsecure(3, 1, 0);

            SetMInsecure(0, 2, 0);
            SetMInsecure(1, 2, 0);
            SetMInsecure(2, 2, 1 / (zFar - zNear));
            SetMInsecure(3, 2, 0);

            SetMInsecure(0, 3, 0);
            SetMInsecure(1, 3, 0);
            SetMInsecure(2, 3, zNear / (zNear - zFar));
            SetMInsecure(3, 3, 1);
        }

        /// <summary> Builds a right-handed orthogonal projection matrix.</summary>
        public void BuildProjectionMatrixOrthoRH(float widthOfViewVolume, float heightOfViewVolume, float zNear, float zFar)
        {
            SetMInsecure(0, 0, 2 / widthOfViewVolume);
            SetMInsecure(1, 0, 0);
            SetMInsecure(2, 0, 0);
            SetMInsecure(3, 0, 0);

            SetMInsecure(0, 1, 0);
            SetMInsecure(1, 1, 2 / heightOfViewVolume);
            SetMInsecure(2, 1, 0);
            SetMInsecure(3, 1, 0);

            SetMInsecure(0, 2, 0);
            SetMInsecure(1, 2, 0);
            SetMInsecure(2, 2, 1 / (zNear - zFar));
            SetMInsecure(3, 2, 0);

            SetMInsecure(0, 3, 0);
            SetMInsecure(1, 3, 0);
            SetMInsecure(2, 3, zNear / (zNear - zFar));
            SetMInsecure(3, 3, -1);
        }

        /// <summary> Builds a left-handed look-at matrix.</summary>
        public void BuildCameraLookAtMatrixLH(Vector3D position, Vector3D target, Vector3D upVector)
        {
            Vector3D zaxis = target - position;
            zaxis.Normalize();

            Vector3D xaxis = upVector.CrossProduct(zaxis);
            xaxis.Normalize();

            Vector3D yaxis = zaxis.CrossProduct(xaxis);

            SetMInsecure(0, 0, xaxis.X);
            SetMInsecure(1, 0, yaxis.X);
            SetMInsecure(2, 0, zaxis.X);
            SetMInsecure(3, 0, 0);

            SetMInsecure(0, 1, xaxis.Y);
            SetMInsecure(1, 1, yaxis.Y);
            SetMInsecure(2, 1, zaxis.Y);
            SetMInsecure(3, 1, 0);

            SetMInsecure(0, 2, xaxis.Z);
            SetMInsecure(1, 2, yaxis.Z);
            SetMInsecure(2, 2, zaxis.Z);
            SetMInsecure(3, 2, 0);

            SetMInsecure(0, 3, -xaxis.DotProduct(position));
            SetMInsecure(1, 3, -yaxis.DotProduct(position));
            SetMInsecure(2, 3, -zaxis.DotProduct(position));
            SetMInsecure(3, 3, 1.0f);
        }

        /// <summary> Builds a right-handed look-at matrix.</summary>
        public void BuildCameraLookAtMatrixRH(Vector3D position, Vector3D target, Vector3D upVector)
        {
            Vector3D zaxis = position - target;
            zaxis.Normalize();

            Vector3D xaxis = upVector.CrossProduct(zaxis);
            xaxis.Normalize();

            Vector3D yaxis = zaxis.CrossProduct(xaxis);

            SetMInsecure(0, 0, xaxis.X);
            SetMInsecure(1, 0, yaxis.X);
            SetMInsecure(2, 0, zaxis.X);
            SetMInsecure(3, 0, 0);

            SetMInsecure(0, 1, xaxis.Y);
            SetMInsecure(1, 1, yaxis.Y);
            SetMInsecure(2, 1, zaxis.Y);
            SetMInsecure(3, 1, 0);

            SetMInsecure(0, 2, xaxis.Z);
            SetMInsecure(1, 2, yaxis.Z);
            SetMInsecure(2, 2, zaxis.Z);
            SetMInsecure(3, 2, 0);

            SetMInsecure(0, 3, -xaxis.DotProduct(position));
            SetMInsecure(1, 3, -yaxis.DotProduct(position));
            SetMInsecure(2, 3, -zaxis.DotProduct(position));
            SetMInsecure(3, 3, 1.0f);
        }

        public void MakeInverse()
        {
            Matrix4 temp;
            if (GetInverse(out temp))
                this.M = temp.M;
        }

        public bool GetInverse(out Matrix4 outM)
        {
            outM = new Matrix4();

            float d = (GetMInsecure(0, 0) * GetMInsecure(1, 1) - GetMInsecure(1, 0) * GetMInsecure(0, 1)) * (GetMInsecure(2, 2) * GetMInsecure(3, 3) - GetMInsecure(3, 2) * GetMInsecure(2, 3)) - (GetMInsecure(0, 0) * GetMInsecure(2, 1) - GetMInsecure(2, 0) * GetMInsecure(0, 1)) * (GetMInsecure(1, 2) * GetMInsecure(3, 3) - GetMInsecure(3, 2) * GetMInsecure(1, 3))
                    + (GetMInsecure(0, 0) * GetMInsecure(3, 1) - GetMInsecure(3, 0) * GetMInsecure(0, 1)) * (GetMInsecure(1, 2) * GetMInsecure(2, 3) - GetMInsecure(2, 2) * GetMInsecure(1, 3)) + (GetMInsecure(1, 0) * GetMInsecure(2, 1) - GetMInsecure(2, 0) * GetMInsecure(1, 1)) * (GetMInsecure(0, 2) * GetMInsecure(3, 3) - GetMInsecure(3, 2) * GetMInsecure(0, 3))
                    - (GetMInsecure(1, 0) * GetMInsecure(3, 1) - GetMInsecure(3, 0) * GetMInsecure(1, 1)) * (GetMInsecure(0, 2) * GetMInsecure(2, 3) - GetMInsecure(2, 2) * GetMInsecure(0, 3)) + (GetMInsecure(2, 0) * GetMInsecure(3, 1) - GetMInsecure(3, 0) * GetMInsecure(2, 1)) * (GetMInsecure(0, 2) * GetMInsecure(1, 3) - GetMInsecure(1, 2) * GetMInsecure(0, 3));

            if (d == 0f)
                return false;

            d = 1f / d;

            outM.SetMInsecure(0, 0, d * (GetMInsecure(1, 1) * (GetMInsecure(2, 2) * GetMInsecure(3, 3) - GetMInsecure(3, 2) * GetMInsecure(2, 3)) + GetMInsecure(2, 1) * (GetMInsecure(3, 2) * GetMInsecure(1, 3) - GetMInsecure(1, 2) * GetMInsecure(3, 3)) + GetMInsecure(3, 1) * (GetMInsecure(1, 2) * GetMInsecure(2, 3) - GetMInsecure(2, 2) * GetMInsecure(1, 3))));
            outM.SetMInsecure(1, 0, d * (GetMInsecure(1, 2) * (GetMInsecure(2, 0) * GetMInsecure(3, 3) - GetMInsecure(3, 0) * GetMInsecure(2, 3)) + GetMInsecure(2, 2) * (GetMInsecure(3, 0) * GetMInsecure(1, 3) - GetMInsecure(1, 0) * GetMInsecure(3, 3)) + GetMInsecure(3, 2) * (GetMInsecure(1, 0) * GetMInsecure(2, 3) - GetMInsecure(2, 0) * GetMInsecure(1, 3))));
            outM.SetMInsecure(2, 0, d * (GetMInsecure(1, 3) * (GetMInsecure(2, 0) * GetMInsecure(3, 1) - GetMInsecure(3, 0) * GetMInsecure(2, 1)) + GetMInsecure(2, 3) * (GetMInsecure(3, 0) * GetMInsecure(1, 1) - GetMInsecure(1, 0) * GetMInsecure(3, 1)) + GetMInsecure(3, 3) * (GetMInsecure(1, 0) * GetMInsecure(2, 1) - GetMInsecure(2, 0) * GetMInsecure(1, 1))));
            outM.SetMInsecure(3, 0, d * (GetMInsecure(1, 0) * (GetMInsecure(3, 1) * GetMInsecure(2, 2) - GetMInsecure(2, 1) * GetMInsecure(3, 2)) + GetMInsecure(2, 0) * (GetMInsecure(1, 1) * GetMInsecure(3, 2) - GetMInsecure(3, 1) * GetMInsecure(1, 2)) + GetMInsecure(3, 0) * (GetMInsecure(2, 1) * GetMInsecure(1, 2) - GetMInsecure(1, 1) * GetMInsecure(2, 2))));
            outM.SetMInsecure(0, 1, d * (GetMInsecure(2, 1) * (GetMInsecure(0, 2) * GetMInsecure(3, 3) - GetMInsecure(3, 2) * GetMInsecure(0, 3)) + GetMInsecure(3, 1) * (GetMInsecure(2, 2) * GetMInsecure(0, 3) - GetMInsecure(0, 2) * GetMInsecure(2, 3)) + GetMInsecure(0, 1) * (GetMInsecure(3, 2) * GetMInsecure(2, 3) - GetMInsecure(2, 2) * GetMInsecure(3, 3))));
            outM.SetMInsecure(1, 1, d * (GetMInsecure(2, 2) * (GetMInsecure(0, 0) * GetMInsecure(3, 3) - GetMInsecure(3, 0) * GetMInsecure(0, 3)) + GetMInsecure(3, 2) * (GetMInsecure(2, 0) * GetMInsecure(0, 3) - GetMInsecure(0, 0) * GetMInsecure(2, 3)) + GetMInsecure(0, 2) * (GetMInsecure(3, 0) * GetMInsecure(2, 3) - GetMInsecure(2, 0) * GetMInsecure(3, 3))));
            outM.SetMInsecure(2, 1, d * (GetMInsecure(2, 3) * (GetMInsecure(0, 0) * GetMInsecure(3, 1) - GetMInsecure(3, 0) * GetMInsecure(0, 1)) + GetMInsecure(3, 3) * (GetMInsecure(2, 0) * GetMInsecure(0, 1) - GetMInsecure(0, 0) * GetMInsecure(2, 1)) + GetMInsecure(0, 3) * (GetMInsecure(3, 0) * GetMInsecure(2, 1) - GetMInsecure(2, 0) * GetMInsecure(3, 1))));
            outM.SetMInsecure(3, 1, d * (GetMInsecure(2, 0) * (GetMInsecure(3, 1) * GetMInsecure(0, 2) - GetMInsecure(0, 1) * GetMInsecure(3, 2)) + GetMInsecure(3, 0) * (GetMInsecure(0, 1) * GetMInsecure(2, 2) - GetMInsecure(2, 1) * GetMInsecure(0, 2)) + GetMInsecure(0, 0) * (GetMInsecure(2, 1) * GetMInsecure(3, 2) - GetMInsecure(3, 1) * GetMInsecure(2, 2))));
            outM.SetMInsecure(0, 2, d * (GetMInsecure(3, 1) * (GetMInsecure(0, 2) * GetMInsecure(1, 3) - GetMInsecure(1, 2) * GetMInsecure(0, 3)) + GetMInsecure(0, 1) * (GetMInsecure(1, 2) * GetMInsecure(3, 3) - GetMInsecure(3, 2) * GetMInsecure(1, 3)) + GetMInsecure(1, 1) * (GetMInsecure(3, 2) * GetMInsecure(0, 3) - GetMInsecure(0, 2) * GetMInsecure(3, 3))));
            outM.SetMInsecure(1, 2, d * (GetMInsecure(3, 2) * (GetMInsecure(0, 0) * GetMInsecure(1, 3) - GetMInsecure(1, 0) * GetMInsecure(0, 3)) + GetMInsecure(0, 2) * (GetMInsecure(1, 0) * GetMInsecure(3, 3) - GetMInsecure(3, 0) * GetMInsecure(1, 3)) + GetMInsecure(1, 2) * (GetMInsecure(3, 0) * GetMInsecure(0, 3) - GetMInsecure(0, 0) * GetMInsecure(3, 3))));
            outM.SetMInsecure(2, 2, d * (GetMInsecure(3, 3) * (GetMInsecure(0, 0) * GetMInsecure(1, 1) - GetMInsecure(1, 0) * GetMInsecure(0, 1)) + GetMInsecure(0, 3) * (GetMInsecure(1, 0) * GetMInsecure(3, 1) - GetMInsecure(3, 0) * GetMInsecure(1, 1)) + GetMInsecure(1, 3) * (GetMInsecure(3, 0) * GetMInsecure(0, 1) - GetMInsecure(0, 0) * GetMInsecure(3, 1))));
            outM.SetMInsecure(3, 2, d * (GetMInsecure(3, 0) * (GetMInsecure(1, 1) * GetMInsecure(0, 2) - GetMInsecure(0, 1) * GetMInsecure(1, 2)) + GetMInsecure(0, 0) * (GetMInsecure(3, 1) * GetMInsecure(1, 2) - GetMInsecure(1, 1) * GetMInsecure(3, 2)) + GetMInsecure(1, 0) * (GetMInsecure(0, 1) * GetMInsecure(3, 2) - GetMInsecure(3, 1) * GetMInsecure(0, 2))));
            outM.SetMInsecure(0, 3, d * (GetMInsecure(0, 1) * (GetMInsecure(2, 2) * GetMInsecure(1, 3) - GetMInsecure(1, 2) * GetMInsecure(2, 3)) + GetMInsecure(1, 1) * (GetMInsecure(0, 2) * GetMInsecure(2, 3) - GetMInsecure(2, 2) * GetMInsecure(0, 3)) + GetMInsecure(2, 1) * (GetMInsecure(1, 2) * GetMInsecure(0, 3) - GetMInsecure(0, 2) * GetMInsecure(1, 3))));
            outM.SetMInsecure(1, 3, d * (GetMInsecure(0, 2) * (GetMInsecure(2, 0) * GetMInsecure(1, 3) - GetMInsecure(1, 0) * GetMInsecure(2, 3)) + GetMInsecure(1, 2) * (GetMInsecure(0, 0) * GetMInsecure(2, 3) - GetMInsecure(2, 0) * GetMInsecure(0, 3)) + GetMInsecure(2, 2) * (GetMInsecure(1, 0) * GetMInsecure(0, 3) - GetMInsecure(0, 0) * GetMInsecure(1, 3))));
            outM.SetMInsecure(2, 3, d * (GetMInsecure(0, 3) * (GetMInsecure(2, 0) * GetMInsecure(1, 1) - GetMInsecure(1, 0) * GetMInsecure(2, 1)) + GetMInsecure(1, 3) * (GetMInsecure(0, 0) * GetMInsecure(2, 1) - GetMInsecure(2, 0) * GetMInsecure(0, 1)) + GetMInsecure(2, 3) * (GetMInsecure(1, 0) * GetMInsecure(0, 1) - GetMInsecure(0, 0) * GetMInsecure(1, 1))));
            outM.SetMInsecure(3, 3, d * (GetMInsecure(0, 0) * (GetMInsecure(1, 1) * GetMInsecure(2, 2) - GetMInsecure(2, 1) * GetMInsecure(1, 2)) + GetMInsecure(1, 0) * (GetMInsecure(2, 1) * GetMInsecure(0, 2) - GetMInsecure(0, 1) * GetMInsecure(2, 2)) + GetMInsecure(2, 0) * (GetMInsecure(0, 1) * GetMInsecure(1, 2) - GetMInsecure(1, 1) * GetMInsecure(0, 2))));

            return true;
        }

        public Vector3D RotateVect(ref Vector3D vect)
        {
            Vector3D tmp = new Vector3D(vect.X, vect.Y, vect.Z);
            vect.X = tmp.X * M[0] + tmp.Y * M[4] + tmp.Z * M[8];
            vect.Y = tmp.X * M[1] + tmp.Y * M[5] + tmp.Z * M[9];
            vect.Z = tmp.X * M[2] + tmp.Y * M[6] + tmp.Z * M[10];
            return vect;
        }

        public Vector3D TransformVect(ref Vector3D vect)
        {
            float[] vector = { 0, 0, 0 };

            vector[0] = vect.X * M[0] + vect.Y * M[4] + vect.Z * M[8] + M[12];
            vector[1] = vect.X * M[1] + vect.Y * M[5] + vect.Z * M[9] + M[13];
            vector[2] = vect.X * M[2] + vect.Y * M[6] + vect.Z * M[10] + M[14];

            vect.X = vector[0];
            vect.Y = vector[1];
            vect.Z = vector[2];
            return vect;
        }

        public float[] ToUnmanaged() { return M; }
        public static Matrix4 FromUnmanaged(float[] m) { return From(m); }
        public float[] ToShader() { return M; }

        public override string ToString()
        {
            string t = GetType().ToString();
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    t += "; (" + i + "," + j + ") = " + GetM(i, j);
            return t;
        }
        public override bool Equals(object o)
        {
            if (o is Matrix4)
                return GetHashCode() == o.GetHashCode();
            return base.Equals(o);
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        public static Matrix4 Identity { get { Matrix4 mat = new Matrix4(); return mat; } }
    }
}
