namespace Emgu_Cam
{
    partial class frmMain
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnWebcam = new System.Windows.Forms.Button();
            this.lblFPS = new System.Windows.Forms.Label();
            this.pnlCapture = new System.Windows.Forms.Panel();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // btnWebcam
            // 
            this.btnWebcam.Location = new System.Drawing.Point(581, 371);
            this.btnWebcam.Name = "btnWebcam";
            this.btnWebcam.Size = new System.Drawing.Size(130, 33);
            this.btnWebcam.TabIndex = 1;
            this.btnWebcam.Text = "Start Capture";
            this.btnWebcam.UseVisualStyleBackColor = true;
            this.btnWebcam.Click += new System.EventHandler(this.btnWebcam_Click);
            // 
            // lblFPS
            // 
            this.lblFPS.AutoSize = true;
            this.lblFPS.Location = new System.Drawing.Point(12, 371);
            this.lblFPS.Name = "lblFPS";
            this.lblFPS.Size = new System.Drawing.Size(33, 13);
            this.lblFPS.TabIndex = 3;
            this.lblFPS.Text = "FPS: ";
            // 
            // pnlCapture
            // 
            this.pnlCapture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCapture.Location = new System.Drawing.Point(12, 12);
            this.pnlCapture.Name = "pnlCapture";
            this.pnlCapture.Size = new System.Drawing.Size(699, 353);
            this.pnlCapture.TabIndex = 4;
            this.pnlCapture.Resize += new System.EventHandler(this.pnlCapture_Resize);
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 407);
            this.Controls.Add(this.pnlCapture);
            this.Controls.Add(this.lblFPS);
            this.Controls.Add(this.btnWebcam);
            this.Name = "frmMain";
            this.Text = "CamTracker";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnWebcam;
        private System.Windows.Forms.Label lblFPS;
        private System.Windows.Forms.Panel pnlCapture;
        private System.Windows.Forms.Timer timer;
    }
}

