using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MP06_RGB2CMYK
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

            // Hiển thị các kênh màu CMYK được chuyển đổi từ RGB
            // Gọi hàm chuyển đổi RGB sang CMYK
            List<Bitmap> CMYK = ChuyenDoiRGBSangCMYK(HinhGoc);

            // Hàm trên trả về 4 màu tương ứng từ 0-3 là C-M-Y-K
            picBoxC.Image = CMYK[0];    // Kênh màu Cyan
            picBoxM.Image = CMYK[1];    // Kênh màu Magenta
            picBoxY.Image = CMYK[2];    // Kênh màu Yellow
            picBoxK.Image = CMYK[3];    // Kênh màu Black
        }





       
        public List<Bitmap> ChuyenDoiRGBSangCMYK(Bitmap hinhgoc)
        {
            /*-------------------------------------------------------------------------------------------------------
             Các em lưu ý việc tính chuyển đổi hệ màu RGB sang CMYK và ngược lại đơn giản là
             sự pha trộn màu của các kênh tương ứng, các em không phải dùng công thức tính
             gì cho nặng chương trình tính toán cũng như làm suy giảm giá trị màu sau mỗi lần chuyển đổi, cụ thể:

                - Màu Cyan (xanh dương) là kết hợp giữa Green và Blue, nên set kênh Red = 0
                - Màu Magenta (tím) là kết hợp giữa Red và Blue, nên set kênh Green = 0
                - Màu Yellow (vàng) là kết hợp giữa Red và Green, nên set kênh Blue = 0
                - Màu Black (đen) đơn giản là lấy MIN(R, G, B)
            --------------------------------------------------------------------------------------------------------*/

            // Tạo một list để chứa 4 kênh ảnh tương ứng C-M-Y-K
            // Trong C#.Net kiểu List là một mảng không phải khai báo trước kích thước
            List<Bitmap> CMYK = new List<Bitmap>();

            // Tiếp theo là mình tạo ra 4 hình Bitmap, có kích thước bằng với hình gốc để sau này việc tính toán
            //chuyển đổi kênh màu được thực hiện đúng cho từng pixel.

            // Mỗi kênh trong không gian màu CMYK được hiển thị bởi một hình Bitmap
            Bitmap Cyan = new Bitmap(hinhgoc.Width, hinhgoc.Height); 
            Bitmap Magenta = new Bitmap(hinhgoc.Width, hinhgoc.Height); 
            Bitmap Yellow = new Bitmap(hinhgoc.Width, hinhgoc.Height); 
            Bitmap Black = new Bitmap(hinhgoc.Width, hinhgoc.Height);

            // Tiến hành quét ảnh gốc bằng 2 vòng for, quét từ trên xuống dưới, từ trái qua phải, 
            //lần lượt từng cột cho đến cột cuối cùng bên phải
            for (int x = 0; x < hinhgoc.Width; x++)
                for (int y = 0; y < hinhgoc.Height; y++)
                {
                    // Tại mỗi điểm ảnh, tiến hành lấy thông tin tại điểm ảnh đó. Do là ảnh gốc RGB nên mỗi
                    //pixel sẽ chứa thông tin của 3 kênh màu R, G, B tương ứng
                    Color color = hinhgoc.GetPixel(x, y);
                    byte R = color.R; // Lưu ý: mỗi kênh màu được biểu diễn bởi 8 bits, tương ứng là 1 byte.                    
                    byte G = color.G; //Do vậy mình sẽ dùng kiểu dữ liệu là byte để chứa thông tin của từng kênh màu R-G-B
                    byte B = color.B;


                    //Màu Cyan (xanh dương) là kết hợp giữa Green và Blue, vậy nên mình set kênh Red = 0
                    Cyan.SetPixel(x, y, Color.FromArgb(0, G, B));

                    //Màu Magenta (tím) là kết hợp giữa Red và Blue, vậy nên mình set kênh Green = 0
                    Magenta.SetPixel(x, y, Color.FromArgb(R, 0, B));

                    //Màu Yellow (vàng) là kết hợp giữa Red và Green, vậy nên mình set kênh Blue = 0
                    Yellow.SetPixel(x, y, Color.FromArgb(R, G, 0));

                    //Màu Black (đen) đơn giản là lấy MIN(R, G, B)
                    byte K = Math.Min(R, Math.Min(G, B));// Do hàm Min chỉ có 2 đối số đầu vào nên phải thực hiện 2 lần
                    Black.SetPixel(x, y, Color.FromArgb(K, K, K));
                }

            // Add các hình tương ứng các kênh màu vào list 
            // Do List là kiểu dữ liệu mảng (Array) không cần biết trước kích thước
            //nên mình có thể Add các element của List vào mà không cần quan tâm nó có 
            //bị tràn kích thước hay không (cái này là rất hay của C# so với C++)
            CMYK.Add(Cyan);
            CMYK.Add(Magenta);
            CMYK.Add(Yellow);
            CMYK.Add(Black);

            return CMYK;   // Hàm trả về là một list 4 ảnh bitmap tương ứng 4 kênh màu C-M-Y-K
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
    }
}
