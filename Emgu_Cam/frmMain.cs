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
                Mat matImg = capture.QueryFrame();

                Image<Gray, byte> img = new Image<Gray, byte>(matImg.Bitmap);
                Rectangle[] faces = faceCascade.DetectMultiScale(img);
                Rectangle[] hands = handCascade.DetectMultiScale(img);

                using (Graphics gr = Graphics.FromImage(matImg.Bitmap))
                {
                    gr.SmoothingMode = SmoothingMode.AntiAlias;

                    foreach (Rectangle face in faces)
                        gr.DrawRectangle(facePen, new Rectangle(face.X, face.Y, face.Width, face.Height));

                    foreach (Rectangle hand in hands)
                        gr.DrawRectangle(handPen, new Rectangle(hand.X, hand.Y, hand.Width, hand.Height));
                }

                viewer.Image = matImg;
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

