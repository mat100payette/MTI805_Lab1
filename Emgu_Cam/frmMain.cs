using System;
using System.Drawing;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.UI;
using Emgu.CV.Structure;
using Emgu.CV.Util;

namespace Emgu_Cam
{
    public partial class frmMain : Form
    {
        private VideoCapture capture = null;
        private ImageBox viewer = null;
        private bool capturing = false;
        private CascadeClassifier faceCascade = null;
        private Bgr rectColor = new Bgr(255, 100, 120);


        public frmMain()
        {
            InitializeComponent();

            InitCapture();

            faceCascade = new CascadeClassifier(Environment.CurrentDirectory + "/haarcascade_frontalface_default.xml");
        }

        private void InitCapture()
        {
            int margin = 10;
            viewer = new ImageBox();
            viewer.Location = new Point(margin, margin);
            viewer.Width = pnlCapture.Width;
            viewer.Height = pnlCapture.Height;
            pnlCapture.Controls.Add(viewer);
            viewer.SendToBack();

            capture = new VideoCapture();

            Refresh();
        }

        private void CaptureCam()
        {
            if (viewer != null)
            {
                using (Image<Bgr, byte> img = capture.QueryFrame().ToImage<Bgr, byte>())
                {
                    Bitmap bm = img.Bitmap;

                    using (Image<Gray, byte> imgGray = new Image<Gray, byte>(bm))
                    {
                        Rectangle[] faces = faceCascade.DetectMultiScale(imgGray);

                        foreach (Rectangle face in faces)
                            img.Draw(face, rectColor, 2);

                        Graphics gra = Graphics.FromImage(bm);
                        gra.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceOver;
                        Bitmap bm2 = img.SmoothGaussian(3).Canny(80, 160).Bitmap;
                        bm2.MakeTransparent(Color.Black);

                        gra.DrawImage(bm2, new Point(0, 0));

                    }

                    viewer.Image = img;
                }
            }
        }

        private void btnWebcam_Click(object sender, EventArgs e)
        {
            if (capturing)
            {
                timer.Stop();
                capture.Stop();
                viewer.Image = null;
                btnWebcam.Text = "Start Capture";
            }
            else
            {
                capture.Start();
                timer.Start();
                btnWebcam.Text = "Stop Capture";
            }
            capturing = !capturing;
        }

        private void pnlCapture_Resize(object sender, EventArgs e)
        {
            viewer.Width = pnlCapture.Width;
            viewer.Height = pnlCapture.Height;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            CaptureCam();
        }
    }
}

