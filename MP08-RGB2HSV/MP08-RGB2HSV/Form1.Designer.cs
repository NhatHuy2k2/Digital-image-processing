namespace MP08_RGB2HSV
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
            this.picBoxV = new System.Windows.Forms.PictureBox();
            this.picBoxHSV = new System.Windows.Forms.PictureBox();
            this.lblHinhGocRGB = new System.Windows.Forms.Label();
            this.lblHue = new System.Windows.Forms.Label();
            this.lblSaturation = new System.Windows.Forms.Label();
            this.lblValue = new System.Windows.Forms.Label();
            this.lblHSV = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxHinhGoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxHSV)).BeginInit();
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
            // picBoxV
            // 
            this.picBoxV.Location = new System.Drawing.Point(562, 329);
            this.picBoxV.Name = "picBoxV";
            this.picBoxV.Size = new System.Drawing.Size(256, 256);
            this.picBoxV.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxV.TabIndex = 3;
            this.picBoxV.TabStop = false;
            this.picBoxV.Click += new System.EventHandler(this.pictureBox4_Click);
            // 
            // picBoxHSV
            // 
            this.picBoxHSV.Location = new System.Drawing.Point(833, 329);
            this.picBoxHSV.Name = "picBoxHSV";
            this.picBoxHSV.Size = new System.Drawing.Size(256, 256);
            this.picBoxHSV.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxHSV.TabIndex = 4;
            this.picBoxHSV.TabStop = false;
            this.picBoxHSV.Click += new System.EventHandler(this.pictureBox5_Click);
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
            // lblValue
            // 
            this.lblValue.AutoSize = true;
            this.lblValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValue.Location = new System.Drawing.Point(638, 311);
            this.lblValue.Name = "lblValue";
            this.lblValue.Size = new System.Drawing.Size(84, 15);
            this.lblValue.TabIndex = 8;
            this.lblValue.Text = "Kênh Value:";
            // 
            // lblHSV
            // 
            this.lblHSV.AutoSize = true;
            this.lblHSV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHSV.Location = new System.Drawing.Point(915, 311);
            this.lblHSV.Name = "lblHSV";
            this.lblHSV.Size = new System.Drawing.Size(72, 15);
            this.lblHSV.TabIndex = 9;
            this.lblHSV.Text = "Hình HSV:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1101, 611);
            this.Controls.Add(this.lblHSV);
            this.Controls.Add(this.lblValue);
            this.Controls.Add(this.lblSaturation);
            this.Controls.Add(this.lblHue);
            this.Controls.Add(this.lblHinhGocRGB);
            this.Controls.Add(this.picBoxHSV);
            this.Controls.Add(this.picBoxV);
            this.Controls.Add(this.picBoxS);
            this.Controls.Add(this.picBoxH);
            this.Controls.Add(this.picBoxHinhGoc);
            this.Name = "Form1";
            this.Text = "Chuyển đổi không gian màu (Color space) RGB sang HSV";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picBoxHinhGoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxHSV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picBoxHinhGoc;
        private System.Windows.Forms.PictureBox picBoxH;
        private System.Windows.Forms.PictureBox picBoxS;
        private System.Windows.Forms.PictureBox picBoxV;
        private System.Windows.Forms.PictureBox picBoxHSV;
        private System.Windows.Forms.Label lblHinhGocRGB;
        private System.Windows.Forms.Label lblHue;
        private System.Windows.Forms.Label lblSaturation;
        private System.Windows.Forms.Label lblValue;
        private System.Windows.Forms.Label lblHSV;
    }
}

