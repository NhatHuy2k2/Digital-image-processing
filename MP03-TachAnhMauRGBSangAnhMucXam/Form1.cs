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

namespace MP3_ChuyenhinhanhGrayscale_Average
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // Tạo biến lưu trữ đường dẫn file ảnh, tạo biến bitmap lưu trữ ảnh và hiển thị
            string file_path = @"C:\Users\Admin\Desktop\MAVI_VS\bird_small.jpg";
            Bitmap origin_image = new Bitmap(file_path);

            // Hiển thị ảnh màu gốc từ đường dẫn
            imBox_origin.Image = new Image<Bgr, Byte>(origin_image);

            // Hiển thị các ảnh thang xám được xử lý bằng các thuật toán
                // Bằng thuật toán Average
            imBox_AVG.Image = new Image<Bgr, Byte>(RGBtoGray_AVG(origin_image));

                // Bằng thuật toán Lightness
            imBox_Lightness.Image = new Image<Bgr, Byte>(RGBtoGray_Lightness(origin_image));

                // Bằng thuật toán Luminance
            imBox_Luminance.Image = new Image<Bgr, Byte>(RGBtoGray_Luminance(origin_image));
        }

        /// <summary>
        /// Hàm xử lý hình ảnh sang thang xám (Grayscale) bằng thuật toán Average
        /// </summary>
        /// <param name="originimage"></param>
        /// <returns></returns>
        public Bitmap RGBtoGray_AVG(Bitmap originimage)
        {
            // Tạo biến bitmap lưu trữ hình ảnh kênh màu xám
            Bitmap grayimage = new Bitmap(originimage.Width, originimage.Height);

            // Quét ảnh gốc để lấy giá trị điểm ảnh
            for (int x = 0; x < originimage.Width; x++)
                for (int y = 0; y < originimage.Height; y++)
                {
                    // Lấy giá trị tại điểm ảnh có tọa độ (x, y)
                    Color pixel = originimage.GetPixel(x, y);

                    // Lấy giá trị điểm ảnh tại từng kênh
                    Byte red_val = pixel.R;
                    Byte green_val = pixel.G;
                    Byte blue_val = pixel.B;

                    // Tính giá trị của thang xám tại pixel tương ứng bằng PP Average
                    Byte gray_val = (byte)((red_val + green_val + blue_val) / 3);

                    // Set giá trị tại pixel tương ứng trên biến bitmap xám đã tạo;
                    grayimage.SetPixel(x, y, Color.FromArgb(gray_val, gray_val, gray_val));
                }
            return grayimage;
        }

        /// <summary>
        /// Hàm xử lý hình ảnh sang thang xám (Grayscale) bằng thuật toán Lightness
        /// </summary>
        /// <param name="originimage"></param>
        /// <returns></returns>
        public Bitmap RGBtoGray_Lightness(Bitmap originimage) 
        {
            // Tạo biến Bitmap lưu trữ hình ảnh thang màu xám
            Bitmap grayimage = new Bitmap(originimage.Width, originimage.Height);

            // Quét lấy giá trị điểm ảnh
            for(int x = 0; x < originimage.Width; x++)
                for(int y = 0; y < originimage.Height; y++)
                {
                    // Lấy điểm ảnh tại tọa độ (x, y)
                    Color pixel = originimage.GetPixel(x, y);

                    // Tạo biến bitmap lưu trữ giá trị kênh Red, Green, và Blue tại điểm ảnh (x, y)
                    Byte red_val   = pixel.R;
                    Byte green_val = pixel.G;
                    Byte blue_val  = pixel.B;

                    // Tính toán giá trị pixel cho thang xám bằng PP Lightness (lưu ý ép kiểu khi tính trung bình)
                    Byte max_val  = Math.Max(red_val, Math.Max(green_val, blue_val));
                    Byte min_val  = Math.Min(red_val, Math.Min(green_val, blue_val));
                    Byte gray_val = (byte)((max_val + min_val)/2);

                    // Set giá trị thang xám vừa tính vào điểm ảnh (x, y) của biến bitmap ảnh thang xám đã tạo
                    grayimage.SetPixel(x, y, Color.FromArgb(gray_val, gray_val, gray_val));
                }
            return grayimage;
        }

        /// <summary>
        /// Hàm xử lý hình ảnh sang thang xám (Grayscale) bằng thuật toán Luminance
        /// </summary>
        /// <param name="originimage"></param>
        /// <returns></returns>
        public Bitmap RGBtoGray_Luminance(Bitmap originimage) 
        {
            // Tạo biến lưu trữ ảnh thang xám
            Bitmap grayimage = new Bitmap(originimage.Width, originimage.Height);

            // Quét lấy giá trị điểm ảnh
            for(int x = 0; x < originimage.Width; x++)
                for(int y = 0; y < originimage.Height; y++) 
                {
                    // Lấy giá trị tại điểm ảnh (x, y)
                    Color pixel = originimage.GetPixel(x, y);

                    // Tạo các biến lưu trữ giá trị các kênh Red, Green, và Blue tại điểm ảnh (x, y)
                    Byte red_val   = pixel.R;
                    Byte green_val = pixel.G;
                    Byte blue_val  = pixel.B;

                    // Tính toán giá trị điểm ảnh (x, y) cho thang màu xám bằng PP Luminance (lưu ý ép kiểu khi gán cho biến)
                    Byte gray_val = (byte)((0.2126 * red_val) + (0.7152 * green_val) + (0.0722 * blue_val));

                    // Set giá trị của thang xám cho điểm ảnh tương ứng (x, y)
                    grayimage.SetPixel(x, y, Color.FromArgb(gray_val, gray_val, gray_val));
                }
            return grayimage;
        }

        private void imageBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
