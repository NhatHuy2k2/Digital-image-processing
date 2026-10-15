namespace MP07_RGB2HSI
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
            this.picBoxHinhGoc = new System.Windows.Forms.PictureBox();
            this.picBoxH = new System.Windows.Forms.PictureBox();
            this.picBoxS = new System.Windows.Forms.PictureBox();
            this.picBoxI = new System.Windows.Forms.PictureBox();
            this.picBoxHSI = new System.Windows.Forms.PictureBox();
            this.lblHinhGocRGB = new System.Windows.Forms.Label();
            this.lblHue = new System.Windows.Forms.Label();
            this.lblSaturation = new System.Windows.Forms.Label();
            this.lblIntensity = new System.Windows.Forms.Label();
            this.lblHSI = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxHinhGoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxHSI)).BeginInit();
            this.SuspendLayout();
            // 
            // picBoxHinhGoc
            // 
            this.picBoxHinhGoc.Location = new System.Drawing.Point(12, 34);
            this.picBoxHinhGoc.Name = "picBoxHinhGoc";
            this.picBoxHinhGoc.Size = new System.Drawing.Size(256, 256);
            this.picBoxHinhGoc.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxHinhGoc.TabIndex = 0;
            this.picBoxHinhGoc.TabStop = false;
            this.picBoxHinhGoc.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // picBoxH
            // 
            this.picBoxH.Location = new System.Drawing.Point(12, 329);
            this.picBoxH.Name = "picBoxH";
            this.picBoxH.Size = new System.Drawing.Size(256, 256);
            this.picBoxH.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxH.TabIndex = 1;
            this.picBoxH.TabStop = false;
            this.picBoxH.Click += new System.EventHandler(this.picBoxH_Click);
            // 
            // picBoxS
            // 
            this.picBoxS.Location = new System.Drawing.Point(287, 329);
            this.picBoxS.Name = "picBoxS";
            this.picBoxS.Size = new System.Drawing.Size(256, 256);
            this.picBoxS.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxS.TabIndex = 2;
            this.picBoxS.TabStop = false;
            this.picBoxS.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // picBoxI
            // 
            this.picBoxI.Location = new System.Drawing.Point(562, 329);
            this.picBoxI.Name = "picBoxI";
            this.picBoxI.Size = new System.Drawing.Size(256, 256);
            this.picBoxI.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxI.TabIndex = 3;
            this.picBoxI.TabStop = false;
            this.picBoxI.Click += new System.EventHandler(this.pictureBox4_Click);
            // 
            // picBoxHSI
            // 
            this.picBoxHSI.Location = new System.Drawing.Point(833, 329);
            this.picBoxHSI.Name = "picBoxHSI";
            this.picBoxHSI.Size = new System.Drawing.Size(256, 256);
            this.picBoxHSI.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxHSI.TabIndex = 4;
            this.picBoxHSI.TabStop = false;
            this.picBoxHSI.Click += new System.EventHandler(this.pictureBox5_Click);
            // 
            // lblHinhGocRGB
            // 
            this.lblHinhGocRGB.AutoSize = true;
            this.lblHinhGocRGB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHinhGocRGB.Location = new System.Drawing.Point(88, 16);
            this.lblHinhGocRGB.Name = "lblHinhGocRGB";
            this.lblHinhGocRGB.Size = new System.Drawing.Size(101, 15);
            this.lblHinhGocRGB.TabIndex = 5;
            this.lblHinhGocRGB.Text = "Hình RGB gốc:";
            // 
            // lblHue
            // 
            this.lblHue.AutoSize = true;
            this.lblHue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHue.Location = new System.Drawing.Point(88, 311);
            this.lblHue.Name = "lblHue";
            this.lblHue.Size = new System.Drawing.Size(74, 15);
            this.lblHue.TabIndex = 6;
            this.lblHue.Text = "Kênh Hue:";
            // 
            // lblSaturation
            // 
            this.lblSaturation.AutoSize = true;
            this.lblSaturation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSaturation.Location = new System.Drawing.Point(355, 311);
            this.lblSaturation.Name = "lblSaturation";
            this.lblSaturation.Size = new System.Drawing.Size(114, 15);
            this.lblSaturation.TabIndex = 7;
            this.lblSaturation.Text = "Kênh Saturation:";
            // 
            // lblIntensity
            // 
            this.lblIntensity.AutoSize = true;
            this.lblIntensity.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIntensity.Location = new System.Drawing.Point(638, 311);
            this.lblIntensity.Name = "lblIntensity";
            this.lblIntensity.Size = new System.Drawing.Size(101, 15);
            this.lblIntensity.TabIndex = 8;
            this.lblIntensity.Text = "Kênh Intensity:";
            // 
            // lblHSI
            // 
            this.lblHSI.AutoSize = true;
            this.lblHSI.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHSI.Location = new System.Drawing.Point(915, 311);
            this.lblHSI.Name = "lblHSI";
            this.lblHSI.Size = new System.Drawing.Size(68, 15);
            this.lblHSI.TabIndex = 9;
            this.lblHSI.Text = "Hình HSI:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1101, 611);
            this.Controls.Add(this.lblHSI);
            this.Controls.Add(this.lblIntensity);
            this.Controls.Add(this.lblSaturation);
            this.Controls.Add(this.lblHue);
            this.Controls.Add(this.lblHinhGocRGB);
            this.Controls.Add(this.picBoxHSI);
            this.Controls.Add(this.picBoxI);
            this.Controls.Add(this.picBoxS);
            this.Controls.Add(this.picBoxH);
            this.Controls.Add(this.picBoxHinhGoc);
            this.Name = "Form1";
            this.Text = "Chuyển đổi không gian màu (Color space) RGB sang HSI";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picBoxHinhGoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxHSI)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picBoxHinhGoc;
        private System.Windows.Forms.PictureBox picBoxH;
        private System.Windows.Forms.PictureBox picBoxS;
        private System.Windows.Forms.PictureBox picBoxI;
        private System.Windows.Forms.PictureBox picBoxHSI;
        private System.Windows.Forms.Label lblHinhGocRGB;
        private System.Windows.Forms.Label lblHue;
        private System.Windows.Forms.Label lblSaturation;
        private System.Windows.Forms.Label lblIntensity;
        private System.Windows.Forms.Label lblHSI;
    }
}

