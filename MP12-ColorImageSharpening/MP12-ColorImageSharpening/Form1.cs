using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MP12_ColorImageSharpening
{
    public partial class Form1 : Form
    {
        Bitmap HinhGoc;
        int[,] Mask0 =
                {
                    {0, 1, 0},
                    {1, -4, 1},
                    {0, 1, 0}
                };            
        int[,] Mask1 =
                {
                    {1,  1, 1},
                    {1, -8, 1},
                    {1,  1, 1}
                };
    
        public Form1()
        {
            InitializeComponent();
            // Load hình .jpg từ file
            HinhGoc = new Bitmap(@"C:\Users\DELL\Pictures\Screenshots\Lenu.jpg");

            // Cho hiển thị trên pictureBox
            picBoxHinhGoc.Image = HinhGoc;
        }






            
        // Viết hàm làm nét ảnh màu RGB
        public Bitmap ColorImageSharpening(Bitmap hinhgoc, int Mask_index)
        {
            // Tạo biến lưu trữ kết quả giá trị đã thực hiện làm nét
            int Red_sharpened = 0, Green_sharpened = 0, Blue_sharpened = 0;
            int Red_Laplacian = 0, Green_Laplacian = 0, Blue_Laplacian = 0;
            // Tạo các ma trận con (region of interest) cho từng kênh R, G, B
            int[,] ROI_R = new int[3, 3];
            int[,] ROI_G = new int[3, 3];
            int[,] ROI_B = new int[3, 3];
            int[,] Mask = new int[3, 3];
            if (Mask_index == 0)
            {
                int[,] Mask0 =
                    {
                        {0, 1, 0},
                        {1, -4, 1},
                        {0, 1, 0}
                    };
                Mask = Mask0;
            }
            else if (Mask_index == 1)
            {
                int[,] Mask1 =
                        {
                        {1,  1, 1},
                        {1, -8, 1},
                        {1,  1, 1}
                    };
                Mask = Mask1;
            }



            Bitmap SharpenedImage = new Bitmap(hinhgoc.Width, hinhgoc.Height);

            // Tiến hành quét các điểm ảnh trong hình gốc RGB
            // Chú ý với mặt nạ 3x3, để dễ lập trình thì viền ngoài của ảnh có thể bỏ qua
            // Do vậy mình chỉ quét từ x = 1 đến x = width - 1 và từ y = 1 đến y = height - 1     
            for (int x = 1; x < hinhgoc.Width - 1; x++)
                for (int y = 1; y < hinhgoc.Height - 1; y++)
                {

                    // Tiến hành quét các điểm trong mặt nạ 
                    for (int i = x - 1; i <= x + 1; i++)
                        for (int j = y - 1; j <= y + 1; j++)
                        {
                            // Lấy thông tin màu R-G-B tại các điểm nằm xung quanh điểm ảnh đang chọn
                            // tại vị trí (i,j)
                            Color color = hinhgoc.GetPixel(i, j);
                            int R = color.R;
                            int G = color.G;
                            int B = color.B;


                            ROI_R[j - y + 1, i - x + 1] = R;
                            ROI_G[j - y + 1, i - x + 1] = G;
                            ROI_B[j - y + 1, i - x + 1] = B;
                            // Tiến hành nhân tích chập ma trận vừa tạo với mask
                            Red_Laplacian += ROI_R[j - y + 1, i - x + 1] * Mask[j - y + 1, i - x + 1];
                            Green_Laplacian += ROI_G[j - y + 1, i - x + 1] * Mask[j - y + 1, i - x + 1];
                            Blue_Laplacian += ROI_B[j - y + 1, i - x + 1] * Mask[j - y + 1, i - x + 1];
                           
                        }
                    
                    Red_sharpened = ROI_R[1, 1] + (-1) * Red_Laplacian;
                    Green_sharpened = ROI_G[1, 1] + (-1) * Green_Laplacian;
                    Blue_sharpened = ROI_B[1, 1] + (-1) * Blue_Laplacian;
                    Red_Laplacian = 0; Green_Laplacian = 0; Blue_Laplacian = 0;

                    if (Red_sharpened < 0)
                    {
                        Red_sharpened = 0;
                    }
                    else if (Red_sharpened > 255)
                    {
                        Red_sharpened = 255;
                    }

                    if (Green_sharpened < 0)
                    {
                        Green_sharpened = 0;
                    }
                    else if (Green_sharpened > 255)
                    {
                        Green_sharpened = 255;
                    }

                    if (Blue_sharpened < 0)
                    {
                        Blue_sharpened = 0;
                    }
                    else if (Blue_sharpened > 255)
                    {
                        Blue_sharpened = 255;
                    }



                    // Set điểm ảnh đã làm mượt (làm mờ) vào ảnh bitmap
                    SharpenedImage.SetPixel(x, y, Color.FromArgb((byte)Red_sharpened, (byte)Green_sharpened, (byte)Blue_sharpened));

                }
            return SharpenedImage;   // Trả ảnh đã làm mượt về 
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }
        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void picBoxH_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxMask_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboBoxMask.SelectedIndex == 0)
            {
                picBoxSharpeneddImage.Image = ColorImageSharpening(HinhGoc, 0);
            }
            else if (comboBoxMask.SelectedIndex == 1)
            {
                picBoxSharpeneddImage.Image = ColorImageSharpening(HinhGoc, 1);
            }
            
        }
    }
}






