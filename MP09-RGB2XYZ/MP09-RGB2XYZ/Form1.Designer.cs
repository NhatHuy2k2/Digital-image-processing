namespace MP09_RGB2XYZ
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
            this.picBoxX = new System.Windows.Forms.PictureBox();
            this.picBoxY = new System.Windows.Forms.PictureBox();
            this.picBoxZ = new System.Windows.Forms.PictureBox();
            this.picBoxXYZ = new System.Windows.Forms.PictureBox();
            this.lblHinhGocRGB = new System.Windows.Forms.Label();
            this.lblX = new System.Windows.Forms.Label();
            this.lblY = new System.Windows.Forms.Label();
            this.lblZ = new System.Windows.Forms.Label();
            this.lblXYZ = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxHinhGoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxXYZ)).BeginInit();
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
            // picBoxX
            // 
            this.picBoxX.Location = new System.Drawing.Point(12, 329);
            this.picBoxX.Name = "picBoxX";
            this.picBoxX.Size = new System.Drawing.Size(256, 256);
            this.picBoxX.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxX.TabIndex = 1;
            this.picBoxX.TabStop = false;
            this.picBoxX.Click += new System.EventHandler(this.picBoxH_Click);
            // 
            // picBoxY
            // 
            this.picBoxY.Location = new System.Drawing.Point(287, 329);
            this.picBoxY.Name = "picBoxY";
            this.picBoxY.Size = new System.Drawing.Size(256, 256);
            this.picBoxY.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxY.TabIndex = 2;
            this.picBoxY.TabStop = false;
            this.picBoxY.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // picBoxZ
            // 
            this.picBoxZ.Location = new System.Drawing.Point(562, 329);
            this.picBoxZ.Name = "picBoxZ";
            this.picBoxZ.Size = new System.Drawing.Size(256, 256);
            this.picBoxZ.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxZ.TabIndex = 3;
            this.picBoxZ.TabStop = false;
            this.picBoxZ.Click += new System.EventHandler(this.pictureBox4_Click);
            // 
            // picBoxXYZ
            // 
            this.picBoxXYZ.Location = new System.Drawing.Point(833, 329);
            this.picBoxXYZ.Name = "picBoxXYZ";
            this.picBoxXYZ.Size = new System.Drawing.Size(256, 256);
            this.picBoxXYZ.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxXYZ.TabIndex = 4;
            this.picBoxXYZ.TabStop = false;
            this.picBoxXYZ.Click += new System.EventHandler(this.pictureBox5_Click);
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
            // lblX
            // 
            this.lblX.AutoSize = true;
            this.lblX.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblX.Location = new System.Drawing.Point(105, 311);
            this.lblX.Name = "lblX";
            this.lblX.Size = new System.Drawing.Size(57, 15);
            this.lblX.TabIndex = 6;
            this.lblX.Text = "Kênh X:";
            // 
            // lblY
            // 
            this.lblY.AutoSize = true;
            this.lblY.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblY.Location = new System.Drawing.Point(392, 311);
            this.lblY.Name = "lblY";
            this.lblY.Size = new System.Drawing.Size(56, 15);
            this.lblY.TabIndex = 7;
            this.lblY.Text = "Kênh Y:";
            // 
            // lblZ
            // 
            this.lblZ.AutoSize = true;
            this.lblZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblZ.Location = new System.Drawing.Point(670, 311);
            this.lblZ.Name = "lblZ";
            this.lblZ.Size = new System.Drawing.Size(56, 15);
            this.lblZ.TabIndex = 8;
            this.lblZ.Text = "Kênh Z:";
            // 
            // lblXYZ
            // 
            this.lblXYZ.AutoSize = true;
            this.lblXYZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblXYZ.Location = new System.Drawing.Point(930, 311);
            this.lblXYZ.Name = "lblXYZ";
            this.lblXYZ.Size = new System.Drawing.Size(70, 15);
            this.lblXYZ.TabIndex = 9;
            this.lblXYZ.Text = "Hình XYZ:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1101, 611);
            this.Controls.Add(this.lblXYZ);
            this.Controls.Add(this.lblZ);
            this.Controls.Add(this.lblY);
            this.Controls.Add(this.lblX);
            this.Controls.Add(this.lblHinhGocRGB);
            this.Controls.Add(this.picBoxXYZ);
            this.Controls.Add(this.picBoxZ);
            this.Controls.Add(this.picBoxY);
            this.Controls.Add(this.picBoxX);
            this.Controls.Add(this.picBoxHinhGoc);
            this.Name = "Form1";
            this.Text = "Chuyển đổi không gian màu (Color space) RGB sang XYZ";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picBoxHinhGoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxXYZ)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picBoxHinhGoc;
        private System.Windows.Forms.PictureBox picBoxX;
        private System.Windows.Forms.PictureBox picBoxY;
        private System.Windows.Forms.PictureBox picBoxZ;
        private System.Windows.Forms.PictureBox picBoxXYZ;
        private System.Windows.Forms.Label lblHinhGocRGB;
        private System.Windows.Forms.Label lblX;
        private System.Windows.Forms.Label lblY;
        private System.Windows.Forms.Label lblZ;
        private System.Windows.Forms.Label lblXYZ;
    }
}

