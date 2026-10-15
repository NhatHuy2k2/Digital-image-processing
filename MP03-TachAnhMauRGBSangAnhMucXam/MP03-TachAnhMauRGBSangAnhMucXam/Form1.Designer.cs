namespace MP03_TachAnhMauRGBSangAnhMucXam
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
            this.imBox_HinhGoc = new Emgu.CV.UI.ImageBox();
            this.lblHinhGoc = new System.Windows.Forms.Label();
            this.lblHinhGrayScaleLightness = new System.Windows.Forms.Label();
            this.imBox_Lightness = new Emgu.CV.UI.ImageBox();
            this.lblHinhGrayscaleAVG = new System.Windows.Forms.Label();
            this.imBox_AVG = new Emgu.CV.UI.ImageBox();
            this.lblHinhGrayscaleLuminance = new System.Windows.Forms.Label();
            this.imBox_Luminance = new Emgu.CV.UI.ImageBox();
            ((System.ComponentModel.ISupportInitialize)(this.imBox_HinhGoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imBox_Lightness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imBox_AVG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imBox_Luminance)).BeginInit();
            this.SuspendLayout();
            // 
            // imBox_HinhGoc
            // 
            this.imBox_HinhGoc.Location = new System.Drawing.Point(39, 41);
            this.imBox_HinhGoc.Name = "imBox_HinhGoc";
            this.imBox_HinhGoc.Size = new System.Drawing.Size(256, 256);
            this.imBox_HinhGoc.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imBox_HinhGoc.TabIndex = 2;
            this.imBox_HinhGoc.TabStop = false;
            // 
            // lblHinhGoc
            // 
            this.lblHinhGoc.AutoSize = true;
            this.lblHinhGoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHinhGoc.Location = new System.Drawing.Point(124, 25);
            this.lblHinhGoc.Name = "lblHinhGoc";
            this.lblHinhGoc.Size = new System.Drawing.Size(79, 13);
            this.lblHinhGoc.TabIndex = 3;
            this.lblHinhGoc.Text = "Hình gốc RGB:";
            this.lblHinhGoc.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // lblHinhGrayScaleLightness
            // 
            this.lblHinhGrayScaleLightness.AutoSize = true;
            this.lblHinhGrayScaleLightness.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHinhGrayScaleLightness.Location = new System.Drawing.Point(392, 25);
            this.lblHinhGrayScaleLightness.Name = "lblHinhGrayScaleLightness";
            this.lblHinhGrayScaleLightness.Size = new System.Drawing.Size(122, 13);
            this.lblHinhGrayScaleLightness.TabIndex = 5;
            this.lblHinhGrayScaleLightness.Text = "Ảnh mức xám Lightness:";
            // 
            // imBox_Lightness
            // 
            this.imBox_Lightness.Location = new System.Drawing.Point(325, 41);
            this.imBox_Lightness.Name = "imBox_Lightness";
            this.imBox_Lightness.Size = new System.Drawing.Size(256, 256);
            this.imBox_Lightness.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imBox_Lightness.TabIndex = 4;
            this.imBox_Lightness.TabStop = false;
            // 
            // lblHinhGrayscaleAVG
            // 
            this.lblHinhGrayscaleAVG.AutoSize = true;
            this.lblHinhGrayscaleAVG.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHinhGrayscaleAVG.Location = new System.Drawing.Point(110, 313);
            this.lblHinhGrayscaleAVG.Name = "lblHinhGrayscaleAVG";
            this.lblHinhGrayscaleAVG.Size = new System.Drawing.Size(117, 13);
            this.lblHinhGrayscaleAVG.TabIndex = 7;
            this.lblHinhGrayscaleAVG.Text = "Ảnh mức xám Average:";
            // 
            // imBox_AVG
            // 
            this.imBox_AVG.Location = new System.Drawing.Point(39, 329);
            this.imBox_AVG.Name = "imBox_AVG";
            this.imBox_AVG.Size = new System.Drawing.Size(256, 256);
            this.imBox_AVG.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imBox_AVG.TabIndex = 6;
            this.imBox_AVG.TabStop = false;
            // 
            // lblHinhGrayscaleLuminance
            // 
            this.lblHinhGrayscaleLuminance.AutoSize = true;
            this.lblHinhGrayscaleLuminance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHinhGrayscaleLuminance.Location = new System.Drawing.Point(385, 313);
            this.lblHinhGrayscaleLuminance.Name = "lblHinhGrayscaleLuminance";
            this.lblHinhGrayscaleLuminance.Size = new System.Drawing.Size(129, 13);
            this.lblHinhGrayscaleLuminance.TabIndex = 9;
            this.lblHinhGrayscaleLuminance.Text = "Ảnh mức xám Luminance:";
            // 
            // imBox_Luminance
            // 
            this.imBox_Luminance.Location = new System.Drawing.Point(325, 329);
            this.imBox_Luminance.Name = "imBox_Luminance";
            this.imBox_Luminance.Size = new System.Drawing.Size(256, 256);
            this.imBox_Luminance.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imBox_Luminance.TabIndex = 8;
            this.imBox_Luminance.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 598);
            this.Controls.Add(this.lblHinhGrayscaleLuminance);
            this.Controls.Add(this.imBox_Luminance);
            this.Controls.Add(this.lblHinhGrayscaleAVG);
            this.Controls.Add(this.imBox_AVG);
            this.Controls.Add(this.lblHinhGrayScaleLightness);
            this.Controls.Add(this.imBox_Lightness);
            this.Controls.Add(this.lblHinhGoc);
            this.Controls.Add(this.imBox_HinhGoc);
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chuyển đổi ảnh màu RGB sang ảnh mức xám Grayscale";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imBox_HinhGoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imBox_Lightness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imBox_AVG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imBox_Luminance)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Emgu.CV.UI.ImageBox imBox_HinhGoc;
        private System.Windows.Forms.Label lblHinhGoc;
        private System.Windows.Forms.Label lblHinhGrayScaleLightness;
        private Emgu.CV.UI.ImageBox imBox_Lightness;
        private System.Windows.Forms.Label lblHinhGrayscaleAVG;
        private Emgu.CV.UI.ImageBox imBox_AVG;
        private System.Windows.Forms.Label lblHinhGrayscaleLuminance;
        private Emgu.CV.UI.ImageBox imBox_Luminance;
    }
}

