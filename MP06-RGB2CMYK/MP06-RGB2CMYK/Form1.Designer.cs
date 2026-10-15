namespace MP06_RGB2CMYK
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
            this.picBoxC = new System.Windows.Forms.PictureBox();
            this.picBoxM = new System.Windows.Forms.PictureBox();
            this.picBoxY = new System.Windows.Forms.PictureBox();
            this.picBoxK = new System.Windows.Forms.PictureBox();
            this.lblHinhGocRGB = new System.Windows.Forms.Label();
            this.lblKenhMauCyan = new System.Windows.Forms.Label();
            this.lblKenhMauMagenta = new System.Windows.Forms.Label();
            this.lblKenhMauYellow = new System.Windows.Forms.Label();
            this.lblKenhMauBlack = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxHinhGoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxK)).BeginInit();
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
            // picBoxC
            // 
            this.picBoxC.Location = new System.Drawing.Point(12, 329);
            this.picBoxC.Name = "picBoxC";
            this.picBoxC.Size = new System.Drawing.Size(256, 256);
            this.picBoxC.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxC.TabIndex = 1;
            this.picBoxC.TabStop = false;
            // 
            // picBoxM
            // 
            this.picBoxM.Location = new System.Drawing.Point(287, 329);
            this.picBoxM.Name = "picBoxM";
            this.picBoxM.Size = new System.Drawing.Size(256, 256);
            this.picBoxM.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxM.TabIndex = 2;
            this.picBoxM.TabStop = false;
            this.picBoxM.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // picBoxY
            // 
            this.picBoxY.Location = new System.Drawing.Point(562, 329);
            this.picBoxY.Name = "picBoxY";
            this.picBoxY.Size = new System.Drawing.Size(256, 256);
            this.picBoxY.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxY.TabIndex = 3;
            this.picBoxY.TabStop = false;
            this.picBoxY.Click += new System.EventHandler(this.pictureBox4_Click);
            // 
            // picBoxK
            // 
            this.picBoxK.Location = new System.Drawing.Point(833, 329);
            this.picBoxK.Name = "picBoxK";
            this.picBoxK.Size = new System.Drawing.Size(256, 256);
            this.picBoxK.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxK.TabIndex = 4;
            this.picBoxK.TabStop = false;
            this.picBoxK.Click += new System.EventHandler(this.pictureBox5_Click);
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
            // lblKenhMauCyan
            // 
            this.lblKenhMauCyan.AutoSize = true;
            this.lblKenhMauCyan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKenhMauCyan.Location = new System.Drawing.Point(88, 311);
            this.lblKenhMauCyan.Name = "lblKenhMauCyan";
            this.lblKenhMauCyan.Size = new System.Drawing.Size(111, 15);
            this.lblKenhMauCyan.TabIndex = 6;
            this.lblKenhMauCyan.Text = "Kênh màu Cyan:";
            // 
            // lblKenhMauMagenta
            // 
            this.lblKenhMauMagenta.AutoSize = true;
            this.lblKenhMauMagenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKenhMauMagenta.Location = new System.Drawing.Point(355, 311);
            this.lblKenhMauMagenta.Name = "lblKenhMauMagenta";
            this.lblKenhMauMagenta.Size = new System.Drawing.Size(136, 15);
            this.lblKenhMauMagenta.TabIndex = 7;
            this.lblKenhMauMagenta.Text = "Kênh màu Magenta:";
            // 
            // lblKenhMauYellow
            // 
            this.lblKenhMauYellow.AutoSize = true;
            this.lblKenhMauYellow.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKenhMauYellow.Location = new System.Drawing.Point(638, 311);
            this.lblKenhMauYellow.Name = "lblKenhMauYellow";
            this.lblKenhMauYellow.Size = new System.Drawing.Size(122, 15);
            this.lblKenhMauYellow.TabIndex = 8;
            this.lblKenhMauYellow.Text = "Kênh màu Yellow:";
            // 
            // lblKenhMauBlack
            // 
            this.lblKenhMauBlack.AutoSize = true;
            this.lblKenhMauBlack.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKenhMauBlack.Location = new System.Drawing.Point(915, 311);
            this.lblKenhMauBlack.Name = "lblKenhMauBlack";
            this.lblKenhMauBlack.Size = new System.Drawing.Size(115, 15);
            this.lblKenhMauBlack.TabIndex = 9;
            this.lblKenhMauBlack.Text = "Kênh màu Black:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1101, 611);
            this.Controls.Add(this.lblKenhMauBlack);
            this.Controls.Add(this.lblKenhMauYellow);
            this.Controls.Add(this.lblKenhMauMagenta);
            this.Controls.Add(this.lblKenhMauCyan);
            this.Controls.Add(this.lblHinhGocRGB);
            this.Controls.Add(this.picBoxK);
            this.Controls.Add(this.picBoxY);
            this.Controls.Add(this.picBoxM);
            this.Controls.Add(this.picBoxC);
            this.Controls.Add(this.picBoxHinhGoc);
            this.Name = "Form1";
            this.Text = "Chuyển đổi không gian màu (Color space) RGB sang CMYK";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picBoxHinhGoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxK)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picBoxHinhGoc;
        private System.Windows.Forms.PictureBox picBoxC;
        private System.Windows.Forms.PictureBox picBoxM;
        private System.Windows.Forms.PictureBox picBoxY;
        private System.Windows.Forms.PictureBox picBoxK;
        private System.Windows.Forms.Label lblHinhGocRGB;
        private System.Windows.Forms.Label lblKenhMauCyan;
        private System.Windows.Forms.Label lblKenhMauMagenta;
        private System.Windows.Forms.Label lblKenhMauYellow;
        private System.Windows.Forms.Label lblKenhMauBlack;
    }
}

