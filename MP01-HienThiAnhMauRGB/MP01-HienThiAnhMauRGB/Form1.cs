using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.Util;

namespace MP01_HienThiAnhMauRGB
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Image<Bgr, byte> hinhhienthi = new Image<Bgr, byte>(@"C:\Users\DELL\Pictures\Screenshots\Small_bird.jpg");
            ImgBox_HinhHienThi.Image = hinhhienthi;
        }

        private void imageBox2_Click(object sender, EventArgs e)
        {

        }

        private void imgBox_HinhHienThi_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void picBox_GREEN_Click(object sender, EventArgs e)
        {

        }

        private void picBox_BLUE_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
