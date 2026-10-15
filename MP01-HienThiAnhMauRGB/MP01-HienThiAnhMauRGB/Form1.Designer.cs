namespace MP01_HienThiAnhMauRGB
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
            this.lblHinhHienThi = new System.Windows.Forms.Label();
            this.ImgBox_HinhHienThi = new Emgu.CV.UI.ImageBox();
            ((System.ComponentModel.ISupportInitialize)(this.ImgBox_HinhHienThi)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHinhHienThi
            // 
            this.lblHinhHienThi.AutoSize = true;
            this.lblHinhHienThi.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lblHinhHienThi.Location = new System.Drawing.Point(497, 30);
            this.lblHinhHienThi.Name = "lblHinhHienThi";
            this.lblHinhHienThi.Size = new System.Drawing.Size(125, 25);
            this.lblHinhHienThi.TabIndex = 0;
            this.lblHinhHienThi.Text = "Hình hiển thị:";
            // 
            // ImgBox_HinhHienThi
            // 
            this.ImgBox_HinhHienThi.Location = new System.Drawing.Point(120, 58);
            this.ImgBox_HinhHienThi.Name = "ImgBox_HinhHienThi";
            this.ImgBox_HinhHienThi.Size = new System.Drawing.Size(800, 612);
            this.ImgBox_HinhHienThi.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ImgBox_HinhHienThi.TabIndex = 2;
            this.ImgBox_HinhHienThi.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1084, 749);
            this.Controls.Add(this.ImgBox_HinhHienThi);
            this.Controls.Add(this.lblHinhHienThi);
            this.Name = "Form1";
            this.Text = "Hiển thị hình JPG";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ImgBox_HinhHienThi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHinhHienThi;
        private Emgu.CV.UI.ImageBox ImgBox_HinhHienThi;
    }
}

