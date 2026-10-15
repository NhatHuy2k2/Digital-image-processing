namespace MP12_ColorImageSharpening
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
            this.picBoxSharpeneddImage = new System.Windows.Forms.PictureBox();
            this.lblHinhGocRGB = new System.Windows.Forms.Label();
            this.lblY = new System.Windows.Forms.Label();
            this.comboBoxMask = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxHinhGoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxSharpeneddImage)).BeginInit();
            this.SuspendLayout();
            // 
            // picBoxHinhGoc
            // 
            this.picBoxHinhGoc.Location = new System.Drawing.Point(12, 56);
            this.picBoxHinhGoc.Name = "picBoxHinhGoc";
            this.picBoxHinhGoc.Size = new System.Drawing.Size(512, 512);
            this.picBoxHinhGoc.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxHinhGoc.TabIndex = 0;
            this.picBoxHinhGoc.TabStop = false;
            this.picBoxHinhGoc.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // picBoxSharpeneddImage
            // 
            this.picBoxSharpeneddImage.Location = new System.Drawing.Point(541, 56);
            this.picBoxSharpeneddImage.Name = "picBoxSharpeneddImage";
            this.picBoxSharpeneddImage.Size = new System.Drawing.Size(512, 512);
            this.picBoxSharpeneddImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxSharpeneddImage.TabIndex = 1;
            this.picBoxSharpeneddImage.TabStop = false;
            this.picBoxSharpeneddImage.Click += new System.EventHandler(this.picBoxH_Click);
            // 
            // lblHinhGocRGB
            // 
            this.lblHinhGocRGB.AutoSize = true;
            this.lblHinhGocRGB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHinhGocRGB.Location = new System.Drawing.Point(205, 38);
            this.lblHinhGocRGB.Name = "lblHinhGocRGB";
            this.lblHinhGocRGB.Size = new System.Drawing.Size(101, 15);
            this.lblHinhGocRGB.TabIndex = 5;
            this.lblHinhGocRGB.Text = "Hình RGB gốc:";
            // 
            // lblY
            // 
            this.lblY.AutoSize = true;
            this.lblY.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblY.Location = new System.Drawing.Point(729, 38);
            this.lblY.Name = "lblY";
            this.lblY.Size = new System.Drawing.Size(148, 15);
            this.lblY.TabIndex = 6;
            this.lblY.Text = "Hình đã được làm nét:";
            // 
            // comboBoxMask
            // 
            this.comboBoxMask.FormattingEnabled = true;
            this.comboBoxMask.Items.AddRange(new object[] {
            "Mask 1",
            "Mask 2"});
            this.comboBoxMask.Location = new System.Drawing.Point(732, 574);
            this.comboBoxMask.Name = "comboBoxMask";
            this.comboBoxMask.Size = new System.Drawing.Size(134, 21);
            this.comboBoxMask.TabIndex = 7;
            this.comboBoxMask.SelectedIndexChanged += new System.EventHandler(this.comboBoxMask_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1096, 662);
            this.Controls.Add(this.comboBoxMask);
            this.Controls.Add(this.lblY);
            this.Controls.Add(this.lblHinhGocRGB);
            this.Controls.Add(this.picBoxSharpeneddImage);
            this.Controls.Add(this.picBoxHinhGoc);
            this.Name = "Form1";
            this.Text = "Color image sharpening - Làm nét ảnh màu";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picBoxHinhGoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxSharpeneddImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picBoxHinhGoc;
        private System.Windows.Forms.PictureBox picBoxSharpeneddImage;
        private System.Windows.Forms.Label lblHinhGocRGB;
        private System.Windows.Forms.Label lblY;
        private System.Windows.Forms.ComboBox comboBoxMask;
    }
}

