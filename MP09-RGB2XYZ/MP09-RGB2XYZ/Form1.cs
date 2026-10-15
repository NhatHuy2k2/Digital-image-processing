using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MP09_RGB2XYZ
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

            // Hiển thị các kênh XYZ được chuyển đổi từ RGB
            // Gọi hàm chuyển đổi RGB sang XYZ
            List<Bitmap> XYZ = ChuyenDoiRGBSangXYZ(HinhGoc);

            // Hàm trên trả về 4 bitmap tương ứng từ 0-3 là X-Y-Z và hình XYZ
            picBoxX.Image = XYZ[0];    // Kênh X
            picBoxY.Image = XYZ[1];    // Kênh Y
            picBoxZ.Image = XYZ[2];    // Kênh Z
            picBoxXYZ.Image = XYZ[3];    // Hình XYZ
        }







        // Viết hàm chuyển đổi RGB sang XYZ
        public List<Bitmap> ChuyenDoiRGBSangXYZ(Bitmap hinhgoc)
        {

            // Tạo mảng động List chứa các kết quả sau chuyển đổi
            List<Bitmap> XYZ = new List<Bitmap>();

            // Tạo 3 kênh màu để chứa hình các kênh X-Y-Z
            Bitmap X_bmp = new Bitmap(hinhgoc.Width, hinhgoc.Height);
            Bitmap Y_bmp = new Bitmap(hinhgoc.Width, hinhgoc.Height);
            Bitmap Z_bmp = new Bitmap(hinhgoc.Width, hinhgoc.Height);

            // Đây là hình XYZ (kết hợp cả 3 kênh X-Y-Z)
            Bitmap XYZImage = new Bitmap(hinhgoc.Width, hinhgoc.Height);

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
                    double B = color.B; // Tuy nhiên, ở phần tính X-Y-Z này thì phải dùng kiểu double 
                                        // do quá trình tính toán các giá trị X-Y-Z kết quả trả về của các công thức đều là kiểu double (số thực).

                    // Công thức dựa vào sách Digital Image Processing
                    /*
                      _   _       _                                 _  _   _
                     |  X  |     |  0.4124564   0.3575761  0.1804375 ||  R  |
                     |  Y  |  =  |  0.2126729   0.7151522  0.0721750 ||  G  |
                     |_ Z _|     |_ 0.0193339   0.1191920  0.9503041_||_ B _|
                     */
                    double X = R * 0.4124564 + G * 0.3575761 + B * 0.1804375;
                    double Y = R * 0.2126729 + G * 0.7151522 + B * 0.0721750;
                    double Z = R * 0.0193339 + G * 0.1191920 + B * 0.9503041;

                    // Đặt các giá trị X-Y-Z vừa tính được vào từng điểm ảnh trên bitmap tương ứng từng kênh
                    X_bmp.SetPixel(x, y, Color.FromArgb((byte)X, (byte)X, (byte)X));
                    Y_bmp.SetPixel(x, y, Color.FromArgb((byte)Y, (byte)Y, (byte)Y));
                    Z_bmp.SetPixel(x, y, Color.FromArgb((byte)Z, (byte)Z, (byte)Z));
                    // Đặt các giá trị X-Y-Z vào các kênh R-G-B của hình XYZImage
                    XYZImage.SetPixel(x, y, Color.FromArgb((byte)X, (byte)Y, (byte)Z));
                }


            // Add các hình tương ứng các kênh màu vào list 
            // Do List là kiểu dữ liệu mảng (Array) không cần biết trước kích thước
            //nên mình có thể Add các element của List vào mà không cần quan tâm nó có 
            //bị tràn kích thước hay không (cái này là rất hay của C# so với C++)
            XYZ.Add(X_bmp);
            XYZ.Add(Y_bmp);
            XYZ.Add(Z_bmp);
            XYZ.Add(XYZImage);

            return XYZ;   // Hàm trả về là một list 4 ảnh bitmap tương ứng 3 kênh X-Y-Z và hình XYZ
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






