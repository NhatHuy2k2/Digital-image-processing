using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace MP05_BieuDoHistogramAnhXam
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Load hình .jpg từ file
            Bitmap HinhGoc = new Bitmap(@"C:\Users\DELL\Pictures\Screenshots\bird_small.jpg");

            // Cho hiển thị trên pictureBox
            picBoxHinhGoc.Image = HinhGoc;

            // Tính hình mức xám theo phương pháp Luminance và cho hiển thị
            Bitmap HinhMucXam = RGBtoGray_Luminance(HinhGoc);
            picBoxHinhXam.Image = HinhMucXam;

            // Tính histogram
            double[] histogram = TinhHistogram(HinhMucXam);

            // Chuyển đổi kiểu dữ liệu
            PointPairList points = ChuyenDoiHistogram(histogram);

            // Vẽ biểu đồ histogram và cho hiển thị
            zGHistogram.GraphPane = BieuDoHistogram(points);
            zGHistogram.Refresh();
        }

        /// <summary>
        /// Hàm xử lý hình ảnh sang thang xám (Grayscale) bằng thuật toán Luminance
        /// </summary>
        /// <param name="HinhGoc"></param>
        /// <returns></returns>
        public Bitmap RGBtoGray_Luminance(Bitmap HinhGoc)
        {
            // Tạo biến lưu trữ ảnh thang xám
            Bitmap HinhMucXam = new Bitmap(HinhGoc.Width, HinhGoc.Height);

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
                    HinhMucXam.SetPixel(x, y, Color.FromArgb(gray_val, gray_val, gray_val));
                }
            return HinhMucXam; 
        }

        // Tính histogram của ảnh xám
        public double[] TinhHistogram(Bitmap HinhMucXam)
        {
            // Mỗi pixel mức xám có giá trị từ 0 - 255, do vậy ta khai báo một mảng
            //có 256 phần tử dùng để chứa số đếm của các pixels có cùng mức xám trong ảnh
            // Chúng ta nên dùng kiểu double vì tổng số đếm có thể rất lớn, phụ thuộc 
            //kích thước của ảnh
            double[] histogram = new double[256];

            for (int x = 0; x< HinhMucXam.Width; x++)
                for (int y= 0; y < HinhMucXam.Height; y++)
                {
                    Color color = HinhMucXam.GetPixel(x, y);
                    byte gray = color.R; //  Trong hình mức xám giá trị kênh R cũng giống G hoặc B

                    // Giá trị gray tính ra cũng chính là phần tử thứ gray trong mảng histogram
                    //đã khai báo. Sẽ tăng số đếm của phần tử thứ gray lên 1
                    histogram[gray]++;

                }
            return histogram;
        }

        public PointPairList ChuyenDoiHistogram(double[] histogram)
        {
            // PointPairList là kiểu dữ liệu của ZedGraph để vẽ biểu đồ
            PointPairList points = new PointPairList();

            for (int i =0; i < histogram.Length; i++)
            {
                // i tương ứng trục nằm ngang, từ 0 đến 255
                // histogram[i] tương ứng trục đứng, là số pixels của mức xám
                points.Add(i, histogram[i]);
            }
            return points;
        }

        // Thiết lập một biểu đồ trong ZedGraph
        public GraphPane BieuDoHistogram(PointPairList histogram)
        {
            // GraphPane là đối tượng biểu đồ trong ZedGraph.
            GraphPane gp = new GraphPane();

            gp.Title.Text = @"Biểu đồ Histogram"; // Tên của biểu đồ
            gp.Rect = new Rectangle(0, 0, 700, 500); // Khung chứa biểu đồ

            // Thiết lập trục ngang
            gp.XAxis.Title.Text = @"Giá trị mức xám của các điểm ảnh";
            gp.XAxis.Scale.Min = 0; // nhỏ nhất là 0
            gp.XAxis.Scale.Max = 255;// lớn nhất là 255
            gp.XAxis.Scale.MajorStep = 5;// mỗi bước chính là 5
            gp.XAxis.Scale.MinorStep = 1;// mỗi bước trong một bước chính là 1

            // Tương tự, thiết lập cho trục đứng
            gp.YAxis.Title.Text = @"Số điểm ảnh có cùng mức xám";
            gp.YAxis.Scale.Min = 0; // nhỏ nhất là 0
            gp.YAxis.Scale.Max = 15000;// lớn nhất là 15000
            gp.YAxis.Scale.MajorStep = 5;// mỗi bước chính là 5
            gp.YAxis.Scale.MinorStep = 1;// mỗi bước trong một bước chính là 1

            // Dùng biểu đồ dạng bar để biểu diễn histogram
            gp.AddBar("Histogram", histogram, Color.Black);

            return gp;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void picBoxHinhGoc_Click(object sender, EventArgs e)
        {

        }

        private void lblhinhxam_Click(object sender, EventArgs e)
        {

        }

        private void zGHistogram_Load(object sender, EventArgs e)
        {

        }
    }
}
