using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MP14_EdgeDetectionForGrayImage
{
    public partial class Form1 : Form
    {
        Bitmap HinhGoc;
        Bitmap GrayscaleImg;
        int threshold;
        string thresholdLbl;
        public Form1()
        {
            InitializeComponent();

            // Load hình .jpg từ file
            HinhGoc = new Bitmap(@"C:\Users\DELL\Pictures\Screenshots\Lenu.jpg");

            // Cho hiển thị trên pictureBox
            picBoxHinhGoc.Image = HinhGoc;



        }

        // 1. Hàm tính toán
        //----------------------------------------------------------------------------------------------------------//
        //----------------------------------------Bắt đầu viết các hàm tính toán------------------------------------//
        //----------------------------------------------------------------------------------------------------------//

        //________________________________________!!!Viết hàm chuyển hình sang ảnh mức xám!!!______________________________________//
        // 1.1. Phương pháp Average
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
        // 1.2. Phương pháp lightness
        public Bitmap RGBtoGray_Lightness(Bitmap originimage)
        {
            // Tạo biến Bitmap lưu trữ hình ảnh thang màu xám
            Bitmap grayimage = new Bitmap(originimage.Width, originimage.Height);

            // Quét lấy giá trị điểm ảnh
            for (int x = 0; x < originimage.Width; x++)
                for (int y = 0; y < originimage.Height; y++)
                {
                    // Lấy điểm ảnh tại tọa độ (x, y)
                    Color pixel = originimage.GetPixel(x, y);

                    // Tạo biến bitmap lưu trữ giá trị kênh Red, Green, và Blue tại điểm ảnh (x, y)
                    Byte red_val = pixel.R;
                    Byte green_val = pixel.G;
                    Byte blue_val = pixel.B;

                    // Tính toán giá trị pixel cho thang xám bằng PP Lightness (lưu ý ép kiểu khi tính trung bình)
                    Byte max_val = Math.Max(red_val, Math.Max(green_val, blue_val));
                    Byte min_val = Math.Min(red_val, Math.Min(green_val, blue_val));
                    Byte gray_val = (byte)((max_val + min_val) / 2);

                    // Set giá trị thang xám vừa tính vào điểm ảnh (x, y) của biến bitmap ảnh thang xám đã tạo
                    grayimage.SetPixel(x, y, Color.FromArgb(gray_val, gray_val, gray_val));
                }
            return grayimage;
        }



        // 1.3. Phương pháp Luminance
        public Bitmap RGBtoGray_Luminance(Bitmap HinhGoc)
        {
            // Tạo biến lưu trữ ảnh thang xám
            Bitmap grayimage = new Bitmap(HinhGoc.Width, HinhGoc.Height);

            // Quét lấy giá trị điểm ảnh
            for (int x = 0; x < HinhGoc.Width; x++)
                for (int y = 0; y < HinhGoc.Height; y++)
                {
                    // Lấy giá trị tại điểm ảnh (x, y)
                    Color pixel = HinhGoc.GetPixel(x, y);

                    // Tạo các biến lưu trữ giá trị các kênh Red, Green, và Blue tại điểm ảnh (x, y)
                    byte red_val = pixel.R;
                    byte green_val = pixel.G;
                    byte blue_val = pixel.B;

                    // Tính toán giá trị điểm ảnh (x, y) cho thang màu xám bằng PP Luminance (lưu ý ép kiểu khi gán cho biến)
                    byte gray_val = (byte)((0.2126 * red_val) + (0.7152 * green_val) + (0.0722 * blue_val));

                    // Set giá trị của thang xám cho điểm ảnh tương ứng (x, y)
                    grayimage.SetPixel(x, y, Color.FromArgb(gray_val, gray_val, gray_val));
                }
            return grayimage;
        }
        //________________________________________!!!Viết hàm nhận dạng đường biên!!!______________________________________//
        public Bitmap EdgeDetection(Bitmap grayimage, int threshold)
        {
            // Tạo biến lưu trữ kết quả giá trị đạo hàm bậc 1 và module vector gradient
            int Gradient;
            int gx = 0, gy = 0;
            // Tạo ma trận con (region of interest) kích thước 3x3
            int[,] ROI = new int[3, 3];
            int[,] Sobel_y =
            {
                {-1, -2, -1},
                {0,  0,  0},
                {1,  2,  1}
            };
            int[,] Sobel_x =
            {
                {-1,  0, 1},
                {-2,  0, 2},
                {-1,  0, 1}
            };
                
            Bitmap EdgeDetectedImage = new Bitmap(grayimage.Width, grayimage.Height);
            // Tiến hành quét các điểm ảnh trong hình gốc RGB
            // Chú ý với mặt nạ 3x3, để dễ lập trình thì viền ngoài của ảnh có thể bỏ qua
            // Do vậy mình chỉ quét từ x = 1 đến x = width - 1 và từ y = 1 đến y = height - 1     
            for (int x = 1; x < grayimage.Width - 1; x++)
                for (int y = 1; y < grayimage.Height - 1; y++)
                {

                    // Tiến hành quét các điểm trong mặt nạ 
                    for (int i = x - 1; i <= x + 1; i++)
                        for (int j = y - 1; j <= y + 1; j++)
                        {
                            // Lấy thông tin màu R-G-B tại các điểm nằm xung quanh điểm ảnh đang chọn
                            // tại vị trí (i,j)
                            Color color = grayimage.GetPixel(i, j);
                            int gray_val = color.R; // Lấy gray value của kênh nào cũng được
                            ROI[i - x + 1, j - y + 1] = gray_val;
                            // Tiến hành nhân tích chập ma trận vừa tạo với mask
                            gx += ROI[i - x + 1, j - y + 1] * Sobel_x[i - x + 1, j - y + 1];
                            gy += ROI[i - x + 1, j - y + 1] * Sobel_y[i - x + 1, j - y + 1];
                        }
                    Gradient = Math.Abs(gx) + Math.Abs(gy);
                   
                    // Reset các giá trị đạo hàm bậc 1
                    gx = 0; gy = 0;
                    
                    if (Gradient <= threshold)
                    {
                        EdgeDetectedImage.SetPixel(x, y, Color.FromArgb(0, 0, 0));
                    }
                    else
                    {
                        EdgeDetectedImage.SetPixel(x, y, Color.FromArgb(255, 255, 255));
                    }
                }
            return EdgeDetectedImage;   // Trả ảnh đã làm mượt về 
        }
        //----------------------------------------------------------------------------------------------------------//
        //------------------------------------------Kết thúc các hàm tính toán--------------------------------------//
        //----------------------------------------------------------------------------------------------------------//


        // 2. Hàm tương tác
        //______________________________!!!Hàm cho phép người dùng chọn ảnh!!!______________________________________//
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openImgFile = new OpenFileDialog();

            // Lọc các file có đuôi phù hợp để hiển thị ảnh
            openImgFile.Filter = "Image files (*.png;*.jpg;*.bmp;*.gif)|*.png;*.jpg;*.bmp;*.gif|All files (*.*)|*.*";
            if (openImgFile.ShowDialog() == DialogResult.OK) // Thực thi khi người dùng chọn ảnh    
            {
                HinhGoc = new Bitmap(openImgFile.FileName);
                picBoxHinhGoc.Image = HinhGoc;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
       
        // Lấy giá trị ngưỡng và hiển thị lên label
        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            threshold = trackBarThreshold.Value * 10;
            thresholdLbl = threshold.ToString();
            lblThreshold.Text = thresholdLbl;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void averageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GrayscaleImg = RGBtoGray_AVG(HinhGoc);
            txtBox_GrayMethod.Text = "Average";
        }

        private void lightnessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GrayscaleImg = RGBtoGray_Lightness(HinhGoc);
            txtBox_GrayMethod.Text = "Lightness";
        }

        private void luminanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GrayscaleImg = RGBtoGray_Luminance(HinhGoc);
            txtBox_GrayMethod.Text = "Luminance";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                picBoxSegmentedImage.Image = EdgeDetection(GrayscaleImg, threshold);
            }
            catch 
            {
                MessageBox.Show("Chưa chọn grayscale method", "( ´･･)ﾉ(._.`)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            trackBarThreshold.Value = 0;
            txtBox_GrayMethod.Text = "";
            GrayscaleImg = null;
            picBoxSegmentedImage.Image = null;
        }
    }
}






