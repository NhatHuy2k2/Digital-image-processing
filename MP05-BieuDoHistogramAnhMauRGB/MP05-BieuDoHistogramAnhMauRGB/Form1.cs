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

namespace MP05_BieuDoHistogramAnhMauRGB
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

            // Tính histogram
            double[,] histogram = TinhHistogram(HinhGoc);

            // Chuyển đổi kiểu dữ liệu
            List<PointPairList> points = ChuyenDoiHistogram(histogram);

            // Vẽ biểu đồ histogram và cho hiển thị
            zGHistogram.GraphPane = BieuDoHistogram(points);
            zGHistogram.Refresh();
        }





        // Tính histogram của ảnh màu RGB
        public double[,] TinhHistogram(Bitmap bmp)
        {
            // Chúng ta dùng mảng 2 chiều đê chứa thông tin histogram
            //cho các kênh R, G, B
            // 3 : là số kênh màu cần lưu
            // 256: là cần 256 vị trí tương ứng giá trị màu từ 0 đến 255
            double[,] histogram = new double[3, 256];

            for (int x = 0; x < bmp.Width; x++)
                for (int y = 0; y < bmp.Height; y++)
                {
                    Color color = bmp.GetPixel(x, y);
                    byte R = color.R;
                    byte G = color.G;
                    byte B = color.B;
                    
                    histogram[0, R]++; // Histogram của kênh màu R
                    histogram[1, G]++; // Histogram của kênh màu G
                    histogram[2, B]++; // Histogram của kênh màu B
                }
            return histogram;   // Trả mảng 2 chiều chứa thông tin histogram của R-G-B
        }





        List<PointPairList> ChuyenDoiHistogram(double[,] histogram)
        {
            // PointPairList là kiểu dữ liệu của ZedGraph để vẽ biểu đồ
            // Dùng một mảng không cần khai báo trước số lượng phần tử
            //để chứa các chuyển đổi
            List<PointPairList> points = new List<PointPairList>();
            PointPairList redPoints = new PointPairList(); // Chuyển đổi histogram của kênh R.
            PointPairList greenPoints = new PointPairList(); // Chuyển đổi histogram của kênh G.
            PointPairList bluePoints = new PointPairList(); // Chuyển đổi histogram của kênh B.

            for (int i = 0; i < 256; i++)
            {
                // i tương ứng trục nằm ngang, từ 0 đến 255
                // histogram[i] tương ứng trục đứng, là số pixels của mức xám
                redPoints.Add(i, histogram[0, i]); // Chuyển đổi cho kênh R
                greenPoints.Add(i, histogram[1, i]); // Chuyển đổi cho kênh G
                bluePoints.Add(i, histogram[2, i]); // Chuyển đổi cho kênh B
            }

            // Sau khi kết thúc vòng for thì thông tin histogram của các kênh R G B đã được 
            //chuyển đổi thành công, giờ Add các kênh vào mảng points để trả về cho hàm.
            points.Add(redPoints);
            points.Add(greenPoints);
            points.Add(bluePoints);

            return points;
        }




        // Thiết lập một biểu đồ trong ZedGraph
        public GraphPane BieuDoHistogram(List<PointPairList> histogram)
        {
            // GraphPane là đối tượng biểu đồ trong ZedGraph.
            GraphPane gp = new GraphPane();

            gp.Title.Text = @"Biểu đồ Histogram"; // Tên của biểu đồ
            gp.Rect = new Rectangle(0, 0, 500, 260); // Khung chứa biểu đồ

            // Thiết lập trục ngang
            gp.XAxis.Title.Text = @"Giá trị màu của các điểm ảnh";
            gp.XAxis.Scale.Min = 0; // nhỏ nhất là 0
            gp.XAxis.Scale.Max = 255;// lớn nhất là 255
            gp.XAxis.Scale.MajorStep = 5;// mỗi bước chính là 5
            gp.XAxis.Scale.MinorStep = 1;// mỗi bước trong một bước chính là 1

            // Tương tự, thiết lập cho trục đứng
            gp.YAxis.Title.Text = @"Số điểm ảnh có cùng giá trị màu";
            gp.YAxis.Scale.Min = 0; // nhỏ nhất là 0
            gp.YAxis.Scale.Max = 15000;// lớn nhất là 15000
            gp.YAxis.Scale.MajorStep = 5;// mỗi bước chính là 5
            gp.YAxis.Scale.MinorStep = 1;// mỗi bước trong một bước chính là 1

            // Dùng biểu đồ dạng bar để biểu diễn histogram
            gp.AddBar("Histogram's Red", histogram[0], Color.Red);
            gp.AddBar("Histogram's Green", histogram[1], Color.Green);
            gp.AddBar("Histogram's Blue", histogram[2], Color.Blue);

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

        private void picBoxHinhGoc_Click_1(object sender, EventArgs e)
        {

        }
    }
}
