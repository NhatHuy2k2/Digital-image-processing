namespace MP05_BieuDoHistogramAnhXam
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.zGHistogram = new ZedGraph.ZedGraphControl();
            this.picBoxHinhGoc = new System.Windows.Forms.PictureBox();
            this.picBoxHinhXam = new System.Windows.Forms.PictureBox();
            this.lblhinhgocRGB = new System.Windows.Forms.Label();
            this.lblhinhxam = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxHinhGoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxHinhXam)).BeginInit();
            this.SuspendLayout();
            // 
            // zGHistogram
            // 
            this.zGHistogram.Location = new System.Drawing.Point(372, 54);
            this.zGHistogram.Name = "zGHistogram";
            this.zGHistogram.ScrollGrace = 0D;
            this.zGHistogram.ScrollMaxX = 0D;
            this.zGHistogram.ScrollMaxY = 0D;
            this.zGHistogram.ScrollMaxY2 = 0D;
            this.zGHistogram.ScrollMinX = 0D;
            this.zGHistogram.ScrollMinY = 0D;
            this.zGHistogram.ScrollMinY2 = 0D;
            this.zGHistogram.Size = new System.Drawing.Size(700, 500);
            this.zGHistogram.TabIndex = 0;
            this.zGHistogram.Load += new System.EventHandler(this.zGHistogram_Load);
            // 
            // picBoxHinhGoc
            // 
            this.picBoxHinhGoc.Location = new System.Drawing.Point(12, 25);
            this.picBoxHinhGoc.Name = "picBoxHinhGoc";
            this.picBoxHinhGoc.Size = new System.Drawing.Size(341, 260);
            this.picBoxHinhGoc.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxHinhGoc.TabIndex = 1;
            this.picBoxHinhGoc.TabStop = false;
            this.picBoxHinhGoc.Click += new System.EventHandler(this.picBoxHinhGoc_Click);
            // 
            // picBoxHinhXam
            // 
            this.picBoxHinhXam.Location = new System.Drawing.Point(12, 322);
            this.picBoxHinhXam.Name = "picBoxHinhXam";
            this.picBoxHinhXam.Size = new System.Drawing.Size(341, 260);
            this.picBoxHinhXam.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxHinhXam.TabIndex = 2;
            this.picBoxHinhXam.TabStop = false;
            // 
            // lblhinhgocRGB
            // 
            this.lblhinhgocRGB.AutoSize = true;
            this.lblhinhgocRGB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblhinhgocRGB.Location = new System.Drawing.Point(148, 9);
            this.lblhinhgocRGB.Name = "lblhinhgocRGB";
            this.lblhinhgocRGB.Size = new System.Drawing.Size(68, 15);
            this.lblhinhgocRGB.TabIndex = 3;
            this.lblhinhgocRGB.Text = "Hình gốc:";
            // 
            // lblhinhxam
            // 
            this.lblhinhxam.AutoSize = true;
            this.lblhinhxam.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblhinhxam.Location = new System.Drawing.Point(131, 304);
            this.lblhinhxam.Name = "lblhinhxam";
            this.lblhinhxam.Size = new System.Drawing.Size(103, 15);
            this.lblhinhxam.TabIndex = 4;
            this.lblhinhxam.Text = "Hình mức xám:";
            this.lblhinhxam.Click += new System.EventHandler(this.lblhinhxam_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 603);
            this.Controls.Add(this.lblhinhxam);
            this.Controls.Add(this.lblhinhgocRGB);
            this.Controls.Add(this.picBoxHinhXam);
            this.Controls.Add(this.picBoxHinhGoc);
            this.Controls.Add(this.zGHistogram);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picBoxHinhGoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxHinhXam)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ZedGraph.ZedGraphControl zGHistogram;
        private System.Windows.Forms.PictureBox picBoxHinhGoc;
        private System.Windows.Forms.PictureBox picBoxHinhXam;
        private System.Windows.Forms.Label lblhinhgocRGB;
        private System.Windows.Forms.Label lblhinhxam;
    }
}

