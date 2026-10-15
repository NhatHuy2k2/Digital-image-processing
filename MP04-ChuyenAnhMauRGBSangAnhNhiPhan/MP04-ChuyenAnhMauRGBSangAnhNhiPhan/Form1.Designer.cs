namespace MP04_ChuyenAnhMauRGBSangAnhNhiPhan
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
            this.lblHinhGoc = new System.Windows.Forms.Label();
            this.imBox_HinhGoc = new Emgu.CV.UI.ImageBox();
            this.imBox_AVG = new Emgu.CV.UI.ImageBox();
            this.lblAnhMucXamAverage = new System.Windows.Forms.Label();
            this.imBox_Lightness = new Emgu.CV.UI.ImageBox();
            this.imBox_Luminance = new Emgu.CV.UI.ImageBox();
            this.lblAnhMucXamLightness = new System.Windows.Forms.Label();
            this.lblAnhMucXamLuminance = new System.Windows.Forms.Label();
            this.imBox_HinhNhiPhan = new Emgu.CV.UI.ImageBox();
            this.lblHinhNhiPhan = new System.Windows.Forms.Label();
            this.hScrollBarHinhNhiPhan = new System.Windows.Forms.HScrollBar();
            this.lblThreshold = new System.Windows.Forms.Label();
            this.lblnguong = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imBox_HinhGoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imBox_AVG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imBox_Lightness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imBox_Luminance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imBox_HinhNhiPhan)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHinhGoc
            // 
            this.lblHinhGoc.AutoSize = true;
            this.lblHinhGoc.Location = new System.Drawing.Point(128, 25);
            this.lblHinhGoc.Name = "lblHinhGoc";
            this.lblHinhGoc.Size = new System.Drawing.Size(79, 13);
            this.lblHinhGoc.TabIndex = 0;
            this.lblHinhGoc.Text = "Hình gốc RGB:";
            // 
            // imBox_HinhGoc
            // 
            this.imBox_HinhGoc.Location = new System.Drawing.Point(39, 41);
            this.imBox_HinhGoc.Name = "imBox_HinhGoc";
            this.imBox_HinhGoc.Size = new System.Drawing.Size(256, 256);
            this.imBox_HinhGoc.TabIndex = 2;
            this.imBox_HinhGoc.TabStop = false;
            // 
            // imBox_AVG
            // 
            this.imBox_AVG.Location = new System.Drawing.Point(39, 329);
            this.imBox_AVG.Name = "imBox_AVG";
            this.imBox_AVG.Size = new System.Drawing.Size(256, 256);
            this.imBox_AVG.TabIndex = 4;
            this.imBox_AVG.TabStop = false;
            // 
            // lblAnhMucXamAverage
            // 
            this.lblAnhMucXamAverage.AutoSize = true;
            this.lblAnhMucXamAverage.Location = new System.Drawing.Point(116, 313);
            this.lblAnhMucXamAverage.Name = "lblAnhMucXamAverage";
            this.lblAnhMucXamAverage.Size = new System.Drawing.Size(117, 13);
            this.lblAnhMucXamAverage.TabIndex = 3;
            this.lblAnhMucXamAverage.Text = "Ảnh mức xám Average:";
            // 
            // imBox_Lightness
            // 
            this.imBox_Lightness.Location = new System.Drawing.Point(325, 41);
            this.imBox_Lightness.Name = "imBox_Lightness";
            this.imBox_Lightness.Size = new System.Drawing.Size(256, 256);
            this.imBox_Lightness.TabIndex = 5;
            this.imBox_Lightness.TabStop = false;
            this.imBox_Lightness.Click += new System.EventHandler(this.imBox_Luminance_Click);
            // 
            // imBox_Luminance
            // 
            this.imBox_Luminance.Location = new System.Drawing.Point(325, 329);
            this.imBox_Luminance.Name = "imBox_Luminance";
            this.imBox_Luminance.Size = new System.Drawing.Size(256, 256);
            this.imBox_Luminance.TabIndex = 6;
            this.imBox_Luminance.TabStop = false;
            // 
            // lblAnhMucXamLightness
            // 
            this.lblAnhMucXamLightness.AutoSize = true;
            this.lblAnhMucXamLightness.Location = new System.Drawing.Point(392, 25);
            this.lblAnhMucXamLightness.Name = "lblAnhMucXamLightness";
            this.lblAnhMucXamLightness.Size = new System.Drawing.Size(122, 13);
            this.lblAnhMucXamLightness.TabIndex = 7;
            this.lblAnhMucXamLightness.Text = "Ảnh mức xám Lightness:";
            // 
            // lblAnhMucXamLuminance
            // 
            this.lblAnhMucXamLuminance.AutoSize = true;
            this.lblAnhMucXamLuminance.Location = new System.Drawing.Point(392, 313);
            this.lblAnhMucXamLuminance.Name = "lblAnhMucXamLuminance";
            this.lblAnhMucXamLuminance.Size = new System.Drawing.Size(129, 13);
            this.lblAnhMucXamLuminance.TabIndex = 8;
            this.lblAnhMucXamLuminance.Text = "Ảnh mức xám Luminance:";
            // 
            // imBox_HinhNhiPhan
            // 
            this.imBox_HinhNhiPhan.Location = new System.Drawing.Point(611, 41);
            this.imBox_HinhNhiPhan.Name = "imBox_HinhNhiPhan";
            this.imBox_HinhNhiPhan.Size = new System.Drawing.Size(256, 256);
            this.imBox_HinhNhiPhan.TabIndex = 9;
            this.imBox_HinhNhiPhan.TabStop = false;
            // 
            // lblHinhNhiPhan
            // 
            this.lblHinhNhiPhan.AutoSize = true;
            this.lblHinhNhiPhan.Location = new System.Drawing.Point(712, 25);
            this.lblHinhNhiPhan.Name = "lblHinhNhiPhan";
            this.lblHinhNhiPhan.Size = new System.Drawing.Size(73, 13);
            this.lblHinhNhiPhan.TabIndex = 10;
            this.lblHinhNhiPhan.Text = "Ảnh nhị phân:";
            // 
            // hScrollBarHinhNhiPhan
            // 
            this.hScrollBarHinhNhiPhan.Cursor = System.Windows.Forms.Cursors.Default;
            this.hScrollBarHinhNhiPhan.Location = new System.Drawing.Point(611, 300);
            this.hScrollBarHinhNhiPhan.Maximum = 255;
            this.hScrollBarHinhNhiPhan.Name = "hScrollBarHinhNhiPhan";
            this.hScrollBarHinhNhiPhan.Size = new System.Drawing.Size(256, 20);
            this.hScrollBarHinhNhiPhan.TabIndex = 11;
            this.hScrollBarHinhNhiPhan.Value = 100;
            this.hScrollBarHinhNhiPhan.ValueChanged += new System.EventHandler(this.hScrollBarHinhNhiPhan_ValueChanged);
            // 
            // lblThreshold
            // 
            this.lblThreshold.AutoSize = true;
            this.lblThreshold.Location = new System.Drawing.Point(693, 329);
            this.lblThreshold.Name = "lblThreshold";
            this.lblThreshold.Size = new System.Drawing.Size(48, 13);
            this.lblThreshold.TabIndex = 12;
            this.lblThreshold.Text = "Ngưỡng:";
            this.lblThreshold.Click += new System.EventHandler(this.label1_Click_2);
            // 
            // lblnguong
            // 
            this.lblnguong.AutoSize = true;
            this.lblnguong.Location = new System.Drawing.Point(747, 329);
            this.lblnguong.Name = "lblnguong";
            this.lblnguong.Size = new System.Drawing.Size(25, 13);
            this.lblnguong.TabIndex = 13;
            this.lblnguong.Text = "100";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(912, 598);
            this.Controls.Add(this.lblnguong);
            this.Controls.Add(this.lblThreshold);
            this.Controls.Add(this.hScrollBarHinhNhiPhan);
            this.Controls.Add(this.lblHinhNhiPhan);
            this.Controls.Add(this.imBox_HinhNhiPhan);
            this.Controls.Add(this.lblAnhMucXamLuminance);
            this.Controls.Add(this.lblAnhMucXamLightness);
            this.Controls.Add(this.imBox_Luminance);
            this.Controls.Add(this.imBox_Lightness);
            this.Controls.Add(this.imBox_AVG);
            this.Controls.Add(this.lblAnhMucXamAverage);
            this.Controls.Add(this.imBox_HinhGoc);
            this.Controls.Add(this.lblHinhGoc);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.imBox_HinhGoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imBox_AVG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imBox_Lightness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imBox_Luminance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imBox_HinhNhiPhan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHinhGoc;
        private Emgu.CV.UI.ImageBox imBox_HinhGoc;
        private Emgu.CV.UI.ImageBox imBox_AVG;
        private System.Windows.Forms.Label lblAnhMucXamAverage;
        private Emgu.CV.UI.ImageBox imBox_Lightness;
        private Emgu.CV.UI.ImageBox imBox_Luminance;
        private System.Windows.Forms.Label lblAnhMucXamLightness;
        private System.Windows.Forms.Label lblAnhMucXamLuminance;
        private Emgu.CV.UI.ImageBox imBox_HinhNhiPhan;
        private System.Windows.Forms.Label lblHinhNhiPhan;
        private System.Windows.Forms.HScrollBar hScrollBarHinhNhiPhan;
        private System.Windows.Forms.Label lblThreshold;
        private System.Windows.Forms.Label lblnguong;
    }
}

