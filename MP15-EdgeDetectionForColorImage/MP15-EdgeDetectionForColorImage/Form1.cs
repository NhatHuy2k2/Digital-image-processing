using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MP15_EdgeDetectionForColorImage
{
    public partial class Form1 : Form
    {
        Bitmap HinhGoc;
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

        
        //________________________________________!!!Viết hàm nhận dạng đường biên!!!______________________________________//
        public Bitmap EdgeDetection(Bitmap image, int threshold)
        {
            // Tạo biến lưu trữ kết quả giá trị đạo hàm bậc 1 và module vector gradient
            double Gxx, Gyy, Gxy, theta, F0;
            int gx_R = 0, gy_R = 0, gx_G = 0, gy_G = 0, gx_B = 0, gy_B = 0;
            // Tạo ma trận con (region of interest) kích thước 3x3
            int[,] ROI_R = new int[3, 3], ROI_G = new int[3, 3], ROI_B = new int[3, 3];
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

            Bitmap EdgeDetectedImage = new Bitmap(image.Width, image.Height);
            // Tiến hành quét các điểm ảnh trong hình gốc RGB
            // Chú ý với mặt nạ 3x3, để dễ lập trình thì viền ngoài của ảnh có thể bỏ qua
            // Do vậy mình chỉ quét từ x = 1 đến x = width - 1 và từ y = 1 đến y = height - 1     
            for (int x = 1; x < image.Width - 1; x++)
                for (int y = 1; y < image.Height - 1; y++)
                {

                    // Tiến hành quét các điểm trong mặt nạ 
                    for (int i = x - 1; i <= x + 1; i++)
                        for (int j = y - 1; j <= y + 1; j++)
                        {
                            // Lấy thông tin màu R-G-B tại các điểm nằm xung quanh điểm ảnh đang chọn
                            // tại vị trí (i,j)
                            Color color = image.GetPixel(i, j);
                            int red_val = color.R;
                            int green_val = color.G;
                            int blue_val = color.B;
                            ROI_R[i - x + 1, j - y + 1] = red_val;
                            ROI_G[i - x + 1, j - y + 1] = green_val;
                            ROI_B[i - x + 1, j - y + 1] = blue_val;
                            // Tiến hành nhân tích chập ma trận vừa tạo với mask
                            // Đạo hàm riêng theo phương x, y trên kênh đỏ
                            gx_R += ROI_R[i - x + 1, j - y + 1] * Sobel_x[i - x + 1, j - y + 1];
                            gy_R += ROI_R[i - x + 1, j - y + 1] * Sobel_y[i - x + 1, j - y + 1];
                            // Đạo hàm riêng theo phương x, y trên kênh xanh lá
                            gx_G += ROI_G[i - x + 1, j - y + 1] * Sobel_x[i - x + 1, j - y + 1];
                            gy_G += ROI_G[i - x + 1, j - y + 1] * Sobel_y[i - x + 1, j - y + 1];
                            // Đạo hàm riêng theo phương x, y trên kênh xanh nước biển
                            gx_B += ROI_B[i - x + 1, j - y + 1] * Sobel_x[i - x + 1, j - y + 1];
                            gy_B += ROI_B[i - x + 1, j - y + 1] * Sobel_y[i - x + 1, j - y + 1];
                        }
                    Gxx = Math.Pow(gx_R, 2) + Math.Pow(gx_G, 2) + Math.Pow(gx_B, 2);
                    Gyy = Math.Pow(gy_R, 2) + Math.Pow(gy_G, 2) + Math.Pow(gy_B, 2);
                    Gxy = gx_R * gy_R + gx_G * gy_G + gx_B * gy_B;

                    theta = Math.Atan2(2 * Gxy, Gxx - Gyy) / 2;
                    F0 = Math.Sqrt((Gxx + Gyy + (Gxx - Gyy) * Math.Cos(2 * theta) + 2 * Gxy * Math.Sin(2 * theta))/2);
                    // Reset các giá trị đạo hàm bậc 1
                    gx_R = 0; gy_R = 0; gx_G = 0; gy_G = 0; gx_B = 0; gy_B = 0;

                    if (F0 <= threshold)
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

        private void btn_Initiate_Click(object sender, EventArgs e)
        {
            picBoxSegmentedImage.Image = EdgeDetection(HinhGoc, threshold);
        }

        private void btn_Reset_Click(object sender, EventArgs e)
        {
            trackBarThreshold.Value = 0;
            picBoxSegmentedImage.Image = null;
        }
    }
}






