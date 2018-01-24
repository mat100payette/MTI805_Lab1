using System;
using System.Drawing;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.UI;
using Emgu.CV.Structure;
using System.Drawing.Drawing2D;

namespace Emgu_Cam
{
    public partial class frmMain : Form
    {
        private VideoCapture capture = null;
        private ImageBox viewer = null;
        private bool capturing = false;
        private CascadeClassifier faceCascade = null;
        private CascadeClassifier handCascade = null;
        private Pen facePen = new Pen(Color.DarkSlateBlue, 2);
        private Pen handPen = new Pen(Color.Firebrick, 2);

        public frmMain()
        {
            InitializeComponent();

            InitCapture();

            faceCascade = new CascadeClassifier(Environment.CurrentDirectory + "/haarcascade_frontalface_default.xml");
            handCascade = new CascadeClassifier(Environment.CurrentDirectory + "/haarcascade_hand.xml");
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

                    Image<Gray, byte> imgGray = new Image<Gray, byte>(img.Bitmap);
                    Rectangle[] faces = faceCascade.DetectMultiScale(imgGray);

                        foreach (Rectangle face in faces)
                            img.Draw(face, new Bgr(255, 100, 100), 2);

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

