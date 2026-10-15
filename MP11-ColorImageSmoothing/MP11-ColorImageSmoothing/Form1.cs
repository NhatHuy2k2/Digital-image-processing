using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MP11_ColorImageSmoothing
{
    public partial class Form1 : Form
    {
        Bitmap HinhGoc;
        int maskSize = 3;
        string MaskSizelbl;
        public Form1()
        {
            InitializeComponent();

            // Load hình .jpg từ file
            HinhGoc = new Bitmap(@"C:\Users\DELL\Pictures\Screenshots\Lena.png");

            // Cho hiển thị trên pictureBox
            picBoxHinhGoc.Image = HinhGoc;

            
            // Trả ảnh đã làm mượt bằng các hàm bên dưới
            picBoxSmoothedImage.Image = ColorImageSmoothing(HinhGoc, maskSize);    
        }







        // Viết hàm làm mượt ảnh màu RGB với mặt nạ size bất kỳ
        public Bitmap ColorImageSmoothing(Bitmap hinhgoc, int maskSize)
        {
            int Edge = (maskSize - 1)/2;
            // Tạo sẵn một hình bitmap để chứa ảnh được làm mượt
            Bitmap SmoothedImage = new Bitmap(hinhgoc.Width, hinhgoc.Height);
            int Rs = 0, Gs = 0, Bs = 0;
            // Tiến hành quét các điểm ảnh trong hình gốc RGB
            // Chú ý với mặt nạ 3x3, để dễ lập trình thì viền ngoài của ảnh có thể bỏ qua
            // Do vậy mình chỉ quét từ x = 1 đến x = width - 1 và từ y = 1 đến y = height - 1     
            for (int x = Edge; x < hinhgoc.Width - Edge; x++)
                for (int y = Edge; y < hinhgoc.Height - Edge; y++)
                {
                    // Các biến này dùng để chứa giá trị cộng dồn của các điểm ảnh 
                    // nằm trong mặt nạ. Do vậy nó phải được khai báo kiểu Int để
                    // có thể chứa được giá trị cộng dồn của các pixel
                    

                    // Tiến hành quét các điểm trong mặt nạ 
                    for (int i = x - Edge; i <= x + Edge; i++)
                        for (int j = y - Edge; j <= y + Edge; j++)
                        {
                            // Lấy thông tin màu R-G-B tại điểm ảnh trong mặt nạ
                            // tại vị trí (i,j)
                            Color color = hinhgoc.GetPixel(i, j);
                            byte R = color.R;
                            byte G = color.G;
                            byte B = color.B;

                            // Cộng dồn tất cả điểm ảnh đó cho mỗi kênh R-G-B tương ứng 
                            Rs += R;
                            Gs += G;
                            Bs += B;
                        }
                    
                    // Kết thúc quét và cộng dồn điểm ảnh trong mặt nạ thì mình
                    // tính trung bình cộng cho mỗi kênh theo công thức 6.6-1 trong sách.
                    byte K = (byte)(maskSize * maskSize);
                    Rs = (int)(Rs / K);
                    Gs = (int)(Gs / K);
                    Bs = (int)(Bs / K);

                    // Set điểm ảnh đã làm mượt (làm mờ) vào ảnh bitmap
                    SmoothedImage.SetPixel(x, y, Color.FromArgb(Rs, Gs, Bs));
                    Rs = 0; Gs = 0; Bs = 0;
                }        
            return SmoothedImage;   // Trả ảnh đã làm mượt về 
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

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            maskSize = 2 * trackBar1.Value + 1;
            MaskSizelbl = maskSize.ToString();
            lbl_MaskSize.Text = MaskSizelbl + 'x' + MaskSizelbl;
            picBoxSmoothedImage.Image = ColorImageSmoothing(HinhGoc, maskSize);
        }
    }
}






