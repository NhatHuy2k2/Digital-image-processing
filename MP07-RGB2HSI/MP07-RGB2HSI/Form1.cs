using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MP07_RGB2HSI
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

            // Hiển thị các kênh HSI được chuyển đổi từ RGB
            // Gọi hàm chuyển đổi RGB sang HSI
            List<Bitmap> HSI = ChuyenDoiRGBSangHSI(HinhGoc);

            // Hàm trên trả về 4 bitmap tương ứng từ 0-3 là H-S-I và hình HSI
            picBoxH.Image = HSI[0];    // Kênh Hue
            picBoxS.Image = HSI[1];    // Kênh Saturation
            picBoxI.Image = HSI[2];    // Kênh Intensity
            picBoxHSI.Image = HSI[3];    // Hình HSI
        }







        // Viết hàm chuyển đổi RGB sang HSI
        public List<Bitmap> ChuyenDoiRGBSangHSI(Bitmap hinhgoc)
        {

            // Tạo mảng động List chứa các kết quả sau chuyển đổi
            List<Bitmap> HSI = new List<Bitmap>();

            // Tạo 3 kênh màu để chứa hình các kênh H-S-I
            Bitmap Hue = new Bitmap(hinhgoc.Width, hinhgoc.Height);
            Bitmap Saturation = new Bitmap(hinhgoc.Width, hinhgoc.Height);
            Bitmap Intensity = new Bitmap(hinhgoc.Width, hinhgoc.Height);

            // Đây là hình HSI (kết hợp cả 3 kênh H-S-I)
            Bitmap HSIImage = new Bitmap(hinhgoc.Width, hinhgoc.Height);

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
                    double B = color.B; // Tuy nhiên, ở phần tính H-S-I này thì phải dùng kiểu double 
                                      // do quá trình tính toán các giá trị H-S-I kết quả trả về của các công thức đều là kiểu double (số thực).

                    // Công thức dựa vào sách Digital Image Processing trang 410
                    // t1 là phần tử số của công thức
                    double t1 = ((R - G) + (R - B))*0.5;
                    // t2 là phần mẫu số của công thức tính góc theta
                    double t2 = Math.Sqrt((R - G) * (R - G) + (R - B) * (G - B));
                    // Chú ý là kết quả trả về của hàm tính Acos trong C#.NET là radian
                    double theta = Math.Acos(t1 / t2);

                    // Công thức tính giá trị Hue
                    double H = 0;

                    // Nếu mà Blue <= Green thì Hue = theta
                    if (B <= G)
                        H = theta;
                    else // Còn nếu Blue > Green thì Hue = 360 - theta (2pi - theta)
                        H = 2 * Math.PI - theta;
                    // Chuyển đổi H từ radian sang độ
                    H = H * 180 / Math.PI;

                    // Đây là công thức tính giá trị kênh Saturation
                    double S = 1 - 3 * Math.Min(R, Math.Min(G, B)) / (R + G + B);

                    // Do giá trị tính ra của S sẽ nằm trong khoảng [0,1]
                    // Để mà bitmap có thể hiển thị được thì mình cần phải convert S sang
                    // khoảng giá trị [0, 255]. Công thức dưới đây giúp chuyển đổi 
                    // từ rank [0, 1] sang rank [0, 255]
                    //double S_255 = S * 255;

                    // Đây là công thức tính giá trị kênh Intensity
                    // Đơn giản như khi tính chuyển đổi RGB sang Grayscale theo phương pháp Average
                    double I = (R + G + B) / 3;

                    // Giờ thì mình cho hiển thị các kênh giá trị H-S-I tại các picBox
                    // Chú ý là phải ép kiểu của các giá trị H-S-I về kiểu byte để hình bitmap
                    // hiểu và hiển thị được.
                    Hue.SetPixel(x, y, Color.FromArgb((byte)H, (byte)H, (byte)H));

                    // Riêng giá trị S, hoặc mình có thể normalize như trên
                    // hoặc mình có thể normalize chỉ lúc hiển thị này
                    Saturation.SetPixel(x, y, Color.FromArgb((byte)(S*255), (byte)(S*255), (byte)(S*255)));
                    Intensity.SetPixel(x, y, Color.FromArgb((byte)I, (byte)I, (byte)I));

                    // còn giá trị gốc của kênh S chưa normalize mình có thể dùng để
                    // kết hợp với các kênh H & I để tạo thành hình HSI
                    // Thực ra hình HSI để hiển thị nhìn thấy, chứ tính toán xử lý thì vẫn phải dùng
                    // từng kênh riêng lẻ H-S-I với từng mục đích xử lý ảnh khác nhau
                    HSIImage.SetPixel(x, y, Color.FromArgb((byte)H, (byte)(S*255), (byte)I));
                }


            // Add các hình tương ứng các kênh màu vào list 
            // Do List là kiểu dữ liệu mảng (Array) không cần biết trước kích thước
            //nên mình có thể Add các element của List vào mà không cần quan tâm nó có 
            //bị tràn kích thước hay không (cái này là rất hay của C# so với C++)
            HSI.Add(Hue);
            HSI.Add(Saturation);
            HSI.Add(Intensity);
            HSI.Add(HSIImage);

            return HSI;   // Hàm trả về là một list 4 ảnh bitmap tương ứng 3 kênh H-S-I và hình HSI
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





   
