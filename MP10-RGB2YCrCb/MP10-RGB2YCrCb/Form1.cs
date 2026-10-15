using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MP10_RGB2YCrCb
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Load hình .jpg từ file
            Bitmap HinhGoc = new Bitmap(@"C:\Users\DELL\Pictures\Screenshots\Lena.png");

            // Cho hiển thị trên pictureBox
            picBoxHinhGoc.Image = HinhGoc;

            // Hiển thị các kênh YCrCb được chuyển đổi từ RGB
            // Gọi hàm chuyển đổi RGB sang YCrCb
            List<Bitmap> YCrCb = ChuyenDoiRGBSangYCrCb(HinhGoc);

            // Hàm trên trả về 4 bitmap tương ứng từ 0-3 là Y-Cr-Cb và hình YCrCb
            picBoxY.Image = YCrCb[0];    // Kênh Y
            picBoxCr.Image = YCrCb[1];    // Kênh Cr
            picBoxCb.Image = YCrCb[2];    // Kênh Cb
            picBoxYCrCb.Image = YCrCb[3];    // Hình YCrCb
        }







        // Viết hàm chuyển đổi RGB sang YCrCb
        public List<Bitmap> ChuyenDoiRGBSangYCrCb(Bitmap hinhgoc)
        {

            // Tạo mảng động List chứa các kết quả sau chuyển đổi
            List<Bitmap> YCrCb = new List<Bitmap>();

            // Tạo 3 kênh màu để chứa hình các kênh Y-Cr-Cb
            Bitmap Y_bmp = new Bitmap(hinhgoc.Width, hinhgoc.Height);
            Bitmap Cr_bmp = new Bitmap(hinhgoc.Width, hinhgoc.Height);
            Bitmap Cb_bmp = new Bitmap(hinhgoc.Width, hinhgoc.Height);

            // Đây là hình YCrCb (kết hợp cả 3 kênh Y-Cr-Cb)
            Bitmap YCrCbImage = new Bitmap(hinhgoc.Width, hinhgoc.Height);

            // Tiến hành quét ảnh gốc bằng 2 vòng for, quét từ trên xuống dưới, từ trái qua phải, 
            //lần lượt từng cột cho đến cột cuối cùng bên phải
            for (int x = 0; x < hinhgoc.Width; x++)
                for (int y = 0; y < hinhgoc.Height; y++)
                {
                    // Tại mỗi điểm ảnh, tiến hành lấy thông tin tại điểm ảnh đó. Do là ảnh gốc RGB nên mỗi
                    //pixel sẽ chứa thông tin của 3 kênh màu R, G, B tương ứng
                    Color color = hinhgoc.GetPixel(x, y);
                    double R = color.R; // Lưu ý: Ở những video trước thì thầy đề nghị các em dùng kiểu byte
                    double G = color.G; // cho các giá trị R-G-B
                    double B = color.B; // Tuy nhiên, ở phần tính Y-Cr-Cb này thì phải dùng kiểu double 
                                        // do quá trình tính toán các giá trị Y-Cr-Cb kết quả trả về của các công thức đều là kiểu double (số thực).

                    // Công thức dựa vào sách Digital Image Processing
                    
                    double Y  = 16  + (R * 65.738  + G * 129.057 + B * 25.064)  / 256;
                    double Cr = 128 - (R * 37.945  + G * 74.494  - B * 112.439) / 256;
                    double Cb = 128 + (R * 112.439 - G * 94.154  - B * 18.285)  / 256;

                    // Đặt các giá trị Y-Cr-Cb vừa tính được vào từng điểm ảnh trên bitmap tương ứng từng kênh
                    Y_bmp.SetPixel(x, y, Color.FromArgb((byte)Y, (byte)Y, (byte)Y));
                    Cr_bmp.SetPixel(x, y, Color.FromArgb((byte)Cr, (byte)Cr, (byte)Cr));
                    Cb_bmp.SetPixel(x, y, Color.FromArgb((byte)Cb, (byte)Cb, (byte)Cb));
                    // Đặt các giá trị Y-Cr-Cb vào các kênh R-G-B của hình YCrCbImage
                    YCrCbImage.SetPixel(x, y, Color.FromArgb((byte)Y, (byte)Cr, (byte)Cb));
                }


            // Add các hình tương ứng các kênh màu vào list 
            // Do List là kiểu dữ liệu mảng (Array) không cần biết trước kích thước
            //nên mình có thể Add các element của List vào mà không cần quan tâm nó có 
            //bị tràn kích thước hay không (cái này là rất hay của C# so với C++)
            YCrCb.Add(Y_bmp);
            YCrCb.Add(Cr_bmp);
            YCrCb.Add(Cb_bmp);
            YCrCb.Add(YCrCbImage);

            return YCrCb;   // Hàm trả về là một list 4 ảnh bitmap tương ứng 3 kênh Y-Cr-Cb và hình YCrCb
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
    }
}






