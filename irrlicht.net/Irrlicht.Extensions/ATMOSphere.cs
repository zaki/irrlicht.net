//
// Author: Jonas Abramavicius aka Pazystamo
// Unfinished version
// 2006 06 01
//
// updated code by lug
//
// translated to c# for irrlicht.netcp by lester


using System;
using IrrlichtNET.Inheritable;

namespace IrrlichtNET.Extensions
{


    public class ATMOSphere : ISceneNode
    {

        public ATMOSphere(Timer _timer, SceneNode parent, SceneManager mgr, int id)
            : base(parent, mgr, id)
        {

            smgr = mgr;
            driver = smgr.VideoDriver;
            timer = _timer;
            currentTime = timer.RealTime;
            startTime = timer.RealTime;
            dTime = 0.0f;
            rad = 0.017453292519943295769236907684886f;
            sun_angle = new double[2];
            Ndate = new ushort[5];
            J1minute = 1.0f / 1440.0f;
            sun_interpolation_speed = 30.0f;
            dayspeed = 60.0f;
            vieta = new double[4];
            J = DateToJulian(2006, 2, 27, 7, 50);
            J1 = J;
            counter_time = 0.0f;
            uvX = 0.0f;
            time_int_step = 0.0f;

        }

        public void SetStartTime(ushort y, ushort m, ushort d, ushort h, ushort min)
        {
            J = DateToJulian(y, m, d, h, min);
            J1 = J;
        }


        public double DateToJulian(ushort y, ushort m, ushort d, ushort h, ushort min)
        {
            double hh = h * 60 + min;
            double dd = d + (hh / 1440.0f);
            if (m < 3)
            {
                m += 12;
                y -= 1;
            }
            double c = 2 - Math.Floor(y / 100.0f) + Math.Floor(y / 400.0f);
            double dt = Math.Floor(1461.0f * (y + 4716.0f) / 4) + Math.Floor(153.0 * (m + 1) / 5) + dd + c - 1524.5f;
            return dt;
        }

        public void JulianToDate(double x)
        {
            double p = Math.Floor(x + 0.5f);
            double s1 = p + 68569;

            double n = Math.Floor(4 * s1 / 146097);
            double s2 = s1 - Math.Floor((146097 * n + 3) / 4);

            double i = Math.Floor(4000 * (s2 + 1) / 1461001);
            double s3 = s2 - Math.Floor(1461 * i / 4) + 31;

            double q = Math.Floor(80 * s3 / 2447);
            double e = s3 - Math.Floor(2447 * q / 80);
            double s4 = Math.Floor(q / 11);

            double m = q + 2 - 12 * s4;
            double y = 100 * (n - 49) + i + s4;
            double d = e + x - p + 0.5;


            double h = (((d - Math.Truncate(d)) * 1440) / 60);

            d = Math.Floor(d);
            double min = Math.Floor((h - Math.Truncate(h)) * 60);

            h = Math.Floor(h);

            //Console.WriteLine(String.Format("update time: {0} {1} {2} {3} {4}",y,m,d,h,min));
            //printf("update time:%4.0f %2.0f %2.0f %2.0f %2.0f\n",y,m,d,h,min);
            Ndate[0] = (ushort)y;
            Ndate[1] = (ushort)m;
            Ndate[2] = (ushort)d;
            Ndate[3] = (ushort)h;
            Ndate[4] = (ushort)min;
        }


        double round360(double angle)
        {
            if (angle > 360)
            {
                while (angle > 360)
                {
                    angle -= 360;
                }
            }

            return angle;
        }

        public SceneNode Sun
        {
            get
            {
                return sun;
            }
        }

        public double Speed
        {
            get
            {
                return dayspeed;
            }
            set
            {
                dayspeed = value;
            }
        }

        public Texture SkyTexture
        {
            set
            {

                dangus = value;
            }
        }

        public Texture StarsTexture
        {
            set
            {
                stars = new Texture[6];
                for (int i = 0; i < 6; i++)
                {
                    stars[i] = value;

                }
            }
        }

        public Texture SunTexture
        {
            set
            {
                suntex = value;
            }
        }

        public Texture LensTexture
        {
            set
            {
                lens.SetMaterialTexture(0, value);
            }
        }

        public SceneNode CreateLensflare(Texture tex)
        {
            lens = new LensflareSceneNode(sun, smgr, -1);
            lens.Material.Texture1 = tex;
            return lens;
        }

        public void prep_interpolation(double Jdate, double time)
        {
            Matrix4 mat = new Matrix4();
            Vector3D kampas = new Vector3D();
            saule(52.0f, -5.0f, Jdate);
            kampas.X = (float)-sun_angle[1];//heigh
            kampas.Y = (float)sun_angle[0];//0.0f;-
            kampas.Z = 0.0f;
            mat.RotationDegrees = kampas;
            vieta[0] = 0.0f;
            vieta[1] = 0.0f;
            vieta[2] = 1000.0f;
            vieta[3] = 0.0f;
            double[] temp = new double[4];
            temp[0] = vieta[0];
            temp[1] = vieta[1];
            temp[2] = vieta[2];
            temp[3] = vieta[3];

            vieta[0] = mat.M[0] * temp[0] + mat.M[4] * temp[1] + mat.M[8] * temp[2] + mat.M[12] * temp[3];
            vieta[1] = mat.M[1] * temp[0] + mat.M[5] * temp[1] + mat.M[9] * temp[2] + mat.M[13] * temp[3];
            vieta[2] = mat.M[2] * temp[0] + mat.M[6] * temp[1] + mat.M[10] * temp[2] + mat.M[14] * temp[3];
            vieta[3] = mat.M[3] * temp[0] + mat.M[7] * temp[1] + mat.M[11] * temp[2] + mat.M[15] * temp[3];

            sun_pos_from.X = (float)vieta[0];
            sun_pos_from.Y = (float)vieta[1];
            sun_pos_from.Z = (float)vieta[2];
            sun_angle_from = sun_angle[1];
            saule(52.0f, -5.0f, Jdate + time);//52.0 -5.0 kaunas 54.54 -23.54
            kampas.X = (float)-sun_angle[1];//heigh
            kampas.Y = (float)sun_angle[0];//0.0f;-
            kampas.Z = 0.0f;


            Matrix4 mat2 = new Matrix4();
            mat2.RotationDegrees = kampas;
            vieta[0] = 0.0f;
            vieta[1] = 0.0f;
            vieta[2] = 1000.0f;
            vieta[3] = 0.0f;


            sun_angle_to = sun_angle[1];

            temp[0] = vieta[0];
            temp[1] = vieta[1];
            temp[2] = vieta[2];
            temp[3] = vieta[3];

            vieta[0] = mat2.M[0] * temp[0] + mat2.M[4] * temp[1] + mat2.M[8] * temp[2] + mat2.M[12] * temp[3];
            vieta[1] = mat2.M[1] * temp[0] + mat2.M[5] * temp[1] + mat2.M[9] * temp[2] + mat2.M[13] * temp[3];
            vieta[2] = mat2.M[2] * temp[0] + mat2.M[6] * temp[1] + mat2.M[10] * temp[2] + mat2.M[14] * temp[3];
            vieta[3] = mat2.M[3] * temp[0] + mat2.M[7] * temp[1] + mat2.M[11] * temp[2] + mat2.M[15] * temp[3];

            sun_pos_to.X = (float)vieta[0];
            sun_pos_to.Y = (float)vieta[1];
            sun_pos_to.Z = (float)vieta[2];

        }

        public void saule(double pl, double lw, double J)
        {

            //double J=2453097;
            double M = 357.5291f + 0.98560028 * (J - 2451545);//degree
            M = round360(M);//degree
            double Mrad = M * rad;//radian
            double C = 1.9148f * Math.Sin(Mrad) + 0.02f * Math.Sin(2 * Mrad) + 0.0003f * Math.Sin(3 * Mrad);//degree
            //printf("C %3.4f\n",C);
            C = round360(C);//degree
            //            double Crad=C*rad;//radian
            double lemda = M + 102.9372f + C + 180.0f;//degree
            lemda = round360(lemda);//degree
            double lemdarad = lemda * rad;//radian
            double alfa = lemda - 2.468f * Math.Sin(2 * lemdarad) + 0.053f * Math.Sin(4 * lemdarad) - 0.0014f * Math.Sin(6 * lemdarad);//degree
            alfa = round360(alfa);//degree
            double sigma = 22.8008f * Math.Sin(lemdarad) + 0.5999f * Math.Sin(lemdarad) * Math.Sin(lemdarad) * Math.Sin(lemdarad)
            + 0.0493f * Math.Sin(lemdarad) * Math.Sin(lemdarad) * Math.Sin(lemdarad) * Math.Sin(lemdarad) * Math.Sin(lemdarad);//degree
            sigma = round360(sigma);//degree
            double sigmarad = sigma * rad;//radian
            double zv = 280.16f + 360.9856235f * (J - 2451545.0f) - lw;//degree
            zv = round360(zv);//degree
            double H = zv - alfa;//degree
            H = round360(H);//degree
            double Hrad = H * rad;//radian

            double A = Math.Atan2(Math.Sin(Hrad), Math.Cos(Hrad) * Math.Sin(pl * rad) - Math.Tan(sigmarad) * Math.Cos(pl * rad)) / rad;
            double h = Math.Asin(Math.Sin(pl * rad) * Math.Sin(sigmarad) + Math.Cos(pl * rad) * Math.Cos(sigmarad) * Math.Cos(Hrad)) / rad;
            //A from 0..180,-180..0
            //printf("M %3.4f C %3.4f lemda %3.4f alfa %3.4f sigma %3.4f\n",M,C,lemda,alfa,sigma);
            //printf("zv %3.4f H %3.4f A %3.4f h %3.15f\n",zv,H,A,h);
            sun_angle[0] = A;
            sun_angle[1] = h;//height

        }

        Vector3D getInterpolated3df(Vector3D from, Vector3D to, float d)
        {
            float inv = 1.0f - d;
            Vector3D rez;
            rez.X = from.X * inv + to.X * d;
            rez.Y = from.Y * inv + to.Y * d;
            rez.Z = from.Z * inv + to.Z * d;
            return rez;
        }

        public void Update(double realtime)
        {
            currentTime = realtime;
            dTime = currentTime - startTime;
            J = J + ((dayspeed / 86400) / 1000.0) * dTime;
            if (time_int_step == 0.0f)
            {//calculate sun interpolation positions
                prep_interpolation(J, sun_interpolation_speed * J1minute);
                //JulianToDate(J);
                counter_time = 0.0f;
            }//1440

            counter_time += J - J1;//1440

            time_int_step = counter_time / (sun_interpolation_speed * J1minute);//(1.0f/(sun_interpolation_speed*(1.0f/1440.0f)))*dTime;

            Vector3D sun_place = getInterpolated3df(sun_pos_from, sun_pos_to, (float)time_int_step);

            J1 = J;
            CameraSceneNode cam = smgr.ActiveCamera;
            Vector3D cameraPos = cam.AbsolutePosition;
            Vector3D vt;//billboard position
            vt.X = sun_place.X + cameraPos.X;
            vt.Y = sun_place.Y + cameraPos.Y;
            vt.Z = sun_place.Z + cameraPos.Z;

            sun.Position = vt;
            if (sun.Position.Z < cam.AbsolutePosition.Z)
            {
                sun.Visible = false;
            }
            else
            {
                sun.Visible = true;
            }
            //---sun movement end
            double inv = 1.0f - time_int_step;
            uvX = (float)((sun_angle_from * inv + sun_angle_to * time_int_step) + 90.0f) / 180;
            if (time_int_step >= 1.0f || time_int_step <= -1.0f) { time_int_step = 0.0f; }
            Color sp = dangus.GetPixel((int)Math.Round(128 * uvX), 123);
            smgr.SetAmbientLight(Colorf.From(sp.A / 255f,
                                            sp.R / 255f,
                                            sp.G / 255f,
                                            sp.B / 255f));
            AmbientLight = Colorf.From(sp.A / 255f,
                                             sp.R / 255f,
                                             sp.G / 255f,
                                             sp.B / 255f);
            //driver->setAmbientLight(video::SColor(255,sp.getRed(),sp.getGreen(),sp.getBlue()));
            sky.UV = uvX;

            startTime = currentTime;
        }

        public Colorf AmbientLight;


        public void CreateSkyPalette()
        {

            smgr.AddSkyBoxSceneNode(this, stars, -1);

            sky = new ATMOSkySceneNode(dangus, smgr.RootSceneNode, smgr, 80, 0);
            sky.Material.MaterialType = MaterialType.TransparentAlphaChannel;
            sky.Material.MaterialTypeParam = 0.01f;

            sun = smgr.AddBillboardSceneNode(this, new Dimension2Df(150, 150), -1);
            sun.GetMaterial(0).Lighting = false;
            sun.GetMaterial(0).Texture1 = suntex;
            sun.GetMaterial(0).MaterialTypeParam = 0.01f;
            sun.GetMaterial(0).MaterialType = MaterialType.TransparentAlphaChannel;

        }

        public LensflareSceneNode Lens
        {
            get
            {
                return lens;
            }
        }


        SceneManager smgr;
        VideoDriver driver;

        BillboardSceneNode sun;
        ATMOSkySceneNode sky;
        LensflareSceneNode lens;
        Timer timer;

        double currentTime, startTime, dTime;
        double dayspeed;

        double time_int_step;
        double counter_time;
        double J1minute;

        double J;
        double J1;


        double[] sun_angle;
        double[] vieta;
        float sun_interpolation_speed;

        Vector3D sun_pos_from, sun_pos_to;

        double sun_angle_from, sun_angle_to;

        Texture[] stars;
        Texture suntex;
        float uvX;
        Texture dangus;
        double rad;

        ushort[] Ndate;

    }


    public class ATMOSkySceneNode : ISceneNode
    {
        public ATMOSkySceneNode(Texture tex, SceneNode parent, SceneManager mgr, int faces, int id)
            : base(parent, mgr, id)
        {
            smgr = mgr;
            AutomaticCulling = CullingType.Off;
            material = new Material();
            material.Lighting = false;
            material.ZBuffer = 0;
            material.Texture1 = tex;

            face = faces;
            vertices = new Vertex3D[face + 1];
            indices = new ushort[face * 3];

            double angle = 0.0f;
            double angle2 = 360.0f / face;
            vert = 0;                          //vertice nr
            int nr = -3;                     //indices nr

            vertices[0] = new Vertex3D(Vector3D.From(0.0f, 100.0f, 0.0f),
                                       Vector3D.From(0.0568988f, 0.688538f, -0.722965f),
                                       Color.White,
                                       Vector2D.From(0.0f, 0.1f)
                                      );

            for (ushort n = 1; n < face + 1; n++)
            {
                vert++;
                nr += 3;
                double x = Math.Cos(angle * 0.017453292519943295769236907684886f) * 100;
                double z = Math.Sin(angle * 0.017453292519943295769236907684886f) * 100;

                vertices[vert] = new Vertex3D(Vector3D.From((float)x, -5.0f, (float)z),
                                       Vector3D.From(0.0568988f, 0.688538f, -0.722965f),
                                       Color.White,
                                       Vector2D.From(0.0f, 0.9f)
                                      );

                angle = angle + angle2;
                indices[nr] = 0;
                indices[nr + 1] = (ushort)vert;
                indices[nr + 2] = (ushort)(vert + 1);
            }
            indices[nr + 2] = 1;

        }


        public override void OnRegisterSceneNode()
        {
            if (Visible)
                smgr.RegisterNodeForRendering(this, SceneNodeRenderPass.SkyBox);

            base.OnRegisterSceneNode();
        }

        public override void Render()
        {
            VideoDriver driver = smgr.VideoDriver;
            CameraSceneNode camera = smgr.ActiveCamera;

            if (driver.Raw == IntPtr.Zero || camera.Raw == IntPtr.Zero)
                return;

            Matrix4 mat = new Matrix4();
            mat.Translation = camera.AbsolutePosition;

            driver.SetTransform(TransformationState.World, mat);
            driver.SetMaterial(material);
            for (int i = 1; i < face + 1; i++)
            {
                vertices[i].TCoords = Vector2D.From(uvX, 0.98f);
            }

            vertices[0].TCoords = Vector2D.From(uvX, 0.01f);
            driver.DrawIndexedTriangleList(vertices, vert + 1, indices, face);

        }


        public override Box3D BoundingBox
        {
            get
            {
                return box;
            }
        }


        public override uint MaterialCount
        {
            get
            {
                return 1;
            }
        }

        public Material Material
        {
            get
            {
                return material;
            }
            set
            {
                material = value;
            }
        }

        public override Material GetMaterial(int i)
        {
            return Material;
        }

        public float UV
        {
            get
            {
                return uvX;
            }
            set
            {
                uvX = value;
            }
        }

        Box3D box = new Box3D();
        Vertex3D[] vertices;
        Material material;
        ushort[] indices;
        int vert;
        int face;
        float uvX;
        SceneManager smgr;

    }

}
