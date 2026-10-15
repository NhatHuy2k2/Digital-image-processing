namespace MP10_RGB2YCrCb
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
            this.picBoxY = new System.Windows.Forms.PictureBox();
            this.picBoxCr = new System.Windows.Forms.PictureBox();
            this.picBoxCb = new System.Windows.Forms.PictureBox();
            this.picBoxYCrCb = new System.Windows.Forms.PictureBox();
            this.lblHinhGocRGB = new System.Windows.Forms.Label();
            this.lblY = new System.Windows.Forms.Label();
            this.lblCr = new System.Windows.Forms.Label();
            this.lblCb = new System.Windows.Forms.Label();
            this.lblYCrCb = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxHinhGoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxCr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxCb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxYCrCb)).BeginInit();
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
            // picBoxY
            // 
            this.picBoxY.Location = new System.Drawing.Point(12, 329);
            this.picBoxY.Name = "picBoxY";
            this.picBoxY.Size = new System.Drawing.Size(256, 256);
            this.picBoxY.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxY.TabIndex = 1;
            this.picBoxY.TabStop = false;
            this.picBoxY.Click += new System.EventHandler(this.picBoxH_Click);
            // 
            // picBoxCr
            // 
            this.picBoxCr.Location = new System.Drawing.Point(287, 329);
            this.picBoxCr.Name = "picBoxCr";
            this.picBoxCr.Size = new System.Drawing.Size(256, 256);
            this.picBoxCr.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxCr.TabIndex = 2;
            this.picBoxCr.TabStop = false;
            this.picBoxCr.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // picBoxCb
            // 
            this.picBoxCb.Location = new System.Drawing.Point(562, 329);
            this.picBoxCb.Name = "picBoxCb";
            this.picBoxCb.Size = new System.Drawing.Size(256, 256);
            this.picBoxCb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxCb.TabIndex = 3;
            this.picBoxCb.TabStop = false;
            this.picBoxCb.Click += new System.EventHandler(this.pictureBox4_Click);
            // 
            // picBoxYCrCb
            // 
            this.picBoxYCrCb.Location = new System.Drawing.Point(833, 329);
            this.picBoxYCrCb.Name = "picBoxYCrCb";
            this.picBoxYCrCb.Size = new System.Drawing.Size(256, 256);
            this.picBoxYCrCb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxYCrCb.TabIndex = 4;
            this.picBoxYCrCb.TabStop = false;
            this.picBoxYCrCb.Click += new System.EventHandler(this.pictureBox5_Click);
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
            // lblY
            // 
            this.lblY.AutoSize = true;
            this.lblY.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblY.Location = new System.Drawing.Point(109, 311);
            this.lblY.Name = "lblY";
            this.lblY.Size = new System.Drawing.Size(56, 15);
            this.lblY.TabIndex = 6;
            this.lblY.Text = "Kênh Y:";
            // 
            // lblCr
            // 
            this.lblCr.AutoSize = true;
            this.lblCr.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCr.Location = new System.Drawing.Point(389, 311);
            this.lblCr.Name = "lblCr";
            this.lblCr.Size = new System.Drawing.Size(62, 15);
            this.lblCr.TabIndex = 7;
            this.lblCr.Text = "Kênh Cr:";
            // 
            // lblCb
            // 
            this.lblCb.AutoSize = true;
            this.lblCb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCb.Location = new System.Drawing.Point(657, 311);
            this.lblCb.Name = "lblCb";
            this.lblCb.Size = new System.Drawing.Size(65, 15);
            this.lblCb.TabIndex = 8;
            this.lblCb.Text = "Kênh Cb:";
            // 
            // lblYCrCb
            // 
            this.lblYCrCb.AutoSize = true;
            this.lblYCrCb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYCrCb.Location = new System.Drawing.Point(925, 311);
            this.lblYCrCb.Name = "lblYCrCb";
            this.lblYCrCb.Size = new System.Drawing.Size(84, 15);
            this.lblYCrCb.TabIndex = 9;
            this.lblYCrCb.Text = "Hình YCrCb:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1101, 611);
            this.Controls.Add(this.lblYCrCb);
            this.Controls.Add(this.lblCb);
            this.Controls.Add(this.lblCr);
            this.Controls.Add(this.lblY);
            this.Controls.Add(this.lblHinhGocRGB);
            this.Controls.Add(this.picBoxYCrCb);
            this.Controls.Add(this.picBoxCb);
            this.Controls.Add(this.picBoxCr);
            this.Controls.Add(this.picBoxY);
            this.Controls.Add(this.picBoxHinhGoc);
            this.Name = "Form1";
            this.Text = "Chuyển đổi không gian màu (Color space) RGB sang YCrCb";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picBoxHinhGoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxCr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxCb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxYCrCb)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picBoxHinhGoc;
        private System.Windows.Forms.PictureBox picBoxY;
        private System.Windows.Forms.PictureBox picBoxCr;
        private System.Windows.Forms.PictureBox picBoxCb;
        private System.Windows.Forms.PictureBox picBoxYCrCb;
        private System.Windows.Forms.Label lblHinhGocRGB;
        private System.Windows.Forms.Label lblY;
        private System.Windows.Forms.Label lblCr;
        private System.Windows.Forms.Label lblCb;
        private System.Windows.Forms.Label lblYCrCb;
    }
}

