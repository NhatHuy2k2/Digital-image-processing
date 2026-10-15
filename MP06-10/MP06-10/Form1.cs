using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MP06_10
{
    public partial class Form1 : Form
    {
        Bitmap HinhGoc;
        public Form1()
        {
            InitializeComponent();

            // Load hình .jpg từ file
            HinhGoc = new Bitmap(@"C:\Users\DELL\Pictures\Screenshots\Lena.png");

            // Cho hiển thị trên pictureBox
            picBoxHinhGoc.Image = HinhGoc;

            // Hiển thị các kênh CMYK được chuyển đổi từ RGB từ lúc khởi tạo chương trình
            // Gọi hàm chuyển đổi RGB sang CMYK
            
            List<Bitmap> CMYK = ChuyenDoiRGBSangCMYK(HinhGoc);

            // Hàm trên trả về 4 bitmap tương ứng từ 0-4 là C-M-Y-K
            picBox1.Image = CMYK[0];    // Kênh C
            picBox2.Image = CMYK[1];    // Kênh M
            picBox3.Image = CMYK[2];    // Kênh Y
            picBox4.Image = CMYK[3];    // Hình K
            
        }








        // Các hàm chuyển đổi không gian màu

        // 1. Hàm chuyển đổi RGB sang CMYK
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
        //-----------------------------------------------------------------------------------------------------------

        // 2. Hàm chuyển đổi RGB sang HSI
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
                    double t1 = ((R - G) + (R - B)) * 0.5;
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
                    Saturation.SetPixel(x, y, Color.FromArgb((byte)(S * 255), (byte)(S * 255), (byte)(S * 255)));
                    Intensity.SetPixel(x, y, Color.FromArgb((byte)I, (byte)I, (byte)I));

                    // còn giá trị gốc của kênh S chưa normalize mình có thể dùng để
                    // kết hợp với các kênh H & I để tạo thành hình HSI
                    // Thực ra hình HSI để hiển thị nhìn thấy, chứ tính toán xử lý thì vẫn phải dùng
                    // từng kênh riêng lẻ H-S-I với từng mục đích xử lý ảnh khác nhau
                    HSIImage.SetPixel(x, y, Color.FromArgb((byte)H, (byte)(S * 255), (byte)I));
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
        //-----------------------------------------------------------------------------------------------------------

        // 3. Hàm chuyển đổi RGB sang HSV
        public List<Bitmap> ChuyenDoiRGBSangHSV(Bitmap hinhgoc)
        {

            // Tạo mảng động List chứa các kết quả sau chuyển đổi
            List<Bitmap> HSV = new List<Bitmap>();

            // Tạo 3 kênh màu để chứa hình các kênh H-S-V
            Bitmap Hue = new Bitmap(hinhgoc.Width, hinhgoc.Height);
            Bitmap Saturation = new Bitmap(hinhgoc.Width, hinhgoc.Height);
            Bitmap Value = new Bitmap(hinhgoc.Width, hinhgoc.Height);

            // Đây là hình HSV (kết hợp cả 3 kênh H-S-V)
            Bitmap HSVImage = new Bitmap(hinhgoc.Width, hinhgoc.Height);

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
                                        // do quá trình tính toán các giá trị H-S-V kết quả trả về của các công thức đều là kiểu double (số thực).

                    // Công thức dựa vào sách Digital Image Processing trang 410
                    // t1 là phần tử số của công thức
                    double t1 = ((R - G) + (R - B)) * 0.5;
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

                    // Value là kênh mức xám của hình HSV
                    // Đơn giản là lấy max(R, G, B)
                    double V = Math.Max(R, Math.Max(G, B));

                    // Giờ thì mình cho hiển thị các kênh giá trị H-S-V tại các picBox
                    // Chú ý là phải ép kiểu của các giá trị H-S-V về kiểu byte để hình bitmap
                    // hiểu và hiển thị được.
                    Hue.SetPixel(x, y, Color.FromArgb((byte)H, (byte)H, (byte)H));

                    // Riêng giá trị S, hoặc mình có thể normalize như trên
                    // hoặc mình có thể normalize chỉ lúc hiển thị này
                    Saturation.SetPixel(x, y, Color.FromArgb((byte)(S * 255), (byte)(S * 255), (byte)(S * 255)));
                    Value.SetPixel(x, y, Color.FromArgb((byte)V, (byte)V, (byte)V));

                    // còn giá trị gốc của kênh S chưa normalize mình có thể dùng để
                    // kết hợp với các kênh H & V để tạo thành hình HSV
                    // Thực ra hình HSV để hiển thị nhìn thấy, chứ tính toán xử lý thì vẫn phải dùng
                    // từng kênh riêng lẻ H-S-V với từng mục đích xử lý ảnh khác nhau
                    HSVImage.SetPixel(x, y, Color.FromArgb((byte)H, (byte)(S * 255), (byte)V));
                }


            // Add các hình tương ứng các kênh màu vào list 
            // Do List là kiểu dữ liệu mảng (Array) không cần biết trước kích thước
            //nên mình có thể Add các element của List vào mà không cần quan tâm nó có 
            //bị tràn kích thước hay không (cái này là rất hay của C# so với C++)
            HSV.Add(Hue);
            HSV.Add(Saturation);
            HSV.Add(Value);
            HSV.Add(HSVImage);

            return HSV;   // Hàm trả về là một list 4 ảnh bitmap tương ứng 3 kênh H-S-V và hình HSV
        }
        //-----------------------------------------------------------------------------------------------------------

        // 4. Hàm chuyển đổi RGB sang XYZ
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
        //-----------------------------------------------------------------------------------------------------------

        // 5. Hàm chuyển đổi RGB sang YCrCb
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

                    double Y = 16 + (R * 65.738 + G * 129.057 + B * 25.064) / 256;
                    double Cr = 128 - (R * 37.945 + G * 74.494 - B * 112.439) / 256;
                    double Cb = 128 + (R * 112.439 - G * 94.154 - B * 18.285) / 256;

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
            cBoxColorspace.SelectedText = "CMYK";
        }

        private void picBoxH_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cBoxColorspace.SelectedIndex == 0)
            {
                // Hiển thị các kênh CMYK được chuyển đổi từ RGB
                // Gọi hàm chuyển đổi RGB sang CMYK
                List<Bitmap> CMYK = ChuyenDoiRGBSangCMYK(HinhGoc);

                // Hàm trên trả về 4 bitmap tương ứng từ 0-4 là C-M-Y-K
                picBox1.Image = CMYK[0];    // Kênh C
                picBox2.Image = CMYK[1];    // Kênh M
                picBox3.Image = CMYK[2];    // Kênh Y
                picBox4.Image = CMYK[3];    // Kênh K

                // Đổi tên label thành C, M, Y, K
                lbl1.Text = "C channel";
                lbl2.Text = "M channel";
                lbl3.Text = "Y channel";
                lbl4.Text = "K channel";
            }
            else if (cBoxColorspace.SelectedIndex == 1)
            {
                // Hiển thị các kênh HSI được chuyển đổi từ RGB
                // Gọi hàm chuyển đổi RGB sang HSI
                List<Bitmap> HSI = ChuyenDoiRGBSangHSI(HinhGoc);

                // Hàm trên trả về 4 bitmap tương ứng từ 0-3 là H-S-I và hình HSI
                picBox1.Image = HSI[0];    // Kênh H
                picBox2.Image = HSI[1];    // Kênh S
                picBox3.Image = HSI[2];    // Kênh I
                picBox4.Image = HSI[3];    // Hình HSI

                // Đổi tên label thành H, S, I, HSI
                lbl1.Text = "H channel";
                lbl2.Text = "S channel";
                lbl3.Text = "I channel";
                lbl4.Text = "HSI image";
            }
            else if (cBoxColorspace.SelectedIndex == 2)
            {
                // Hiển thị các kênh HSV được chuyển đổi từ RGB
                // Gọi hàm chuyển đổi RGB sang HSV
                List<Bitmap> HSV = ChuyenDoiRGBSangHSV(HinhGoc);

                // Hàm trên trả về 4 bitmap tương ứng từ 0-3 là H-S-V và hình HSV
                picBox1.Image = HSV[0];    // Kênh H
                picBox2.Image = HSV[1];    // Kênh S
                picBox3.Image = HSV[2];    // Kênh V
                picBox4.Image = HSV[3];    // Hình HSV

                // Đổi tên label thành H, S, V, HSV
                lbl1.Text = "H channel";
                lbl2.Text = "S channel";
                lbl3.Text = "V channel";
                lbl4.Text = "HSV image";
            }
            else if (cBoxColorspace.SelectedIndex == 3)
            {
                // Hiển thị các kênh XYZ được chuyển đổi từ RGB
                // Gọi hàm chuyển đổi RGB sang XYZ
                List<Bitmap> XYZ = ChuyenDoiRGBSangXYZ(HinhGoc);

                // Hàm trên trả về 4 bitmap tương ứng từ 0-3 là X-Y-Z và hình XYZ
                picBox1.Image = XYZ[0];    // Kênh X
                picBox2.Image = XYZ[1];    // Kênh Y
                picBox3.Image = XYZ[2];    // Kênh Z
                picBox4.Image = XYZ[3];    // Hình XYZ

                // Đổi tên label thành X, Y, Z, XYZ
                lbl1.Text = "X channel";
                lbl2.Text = "Y channel";
                lbl3.Text = "Z channel";
                lbl4.Text = "XYZ image";
            }
            else if (cBoxColorspace.SelectedIndex == 4)
            {
                // Hiển thị các kênh YCrCb được chuyển đổi từ RGB
                // Gọi hàm chuyển đổi RGB sang YCrCb
                List<Bitmap> YCrCb = ChuyenDoiRGBSangYCrCb(HinhGoc);

                // Hàm trên trả về 4 bitmap tương ứng từ 0-3 là Y-Cr-Cb và hình YCrCb
                picBox1.Image = YCrCb[0];    // Kênh Y
                picBox2.Image = YCrCb[1];    // Kênh Cr
                picBox3.Image = YCrCb[2];    // Kênh Cb
                picBox4.Image = YCrCb[3];    // Hình YCrCb

                // Đổi tên label thành Y, Cr, Cb, YCrCb
                lbl1.Text = "Y channel";
                lbl2.Text = "Cr channel";
                lbl3.Text = "Cb channel";
                lbl4.Text = "YCrCb image";
            }
        }

        private void lblHinhGocRGB_Click(object sender, EventArgs e)
        {

        }
    }
}






