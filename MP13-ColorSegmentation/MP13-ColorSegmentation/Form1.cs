using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MP13_ColorSegmentation
{
    public partial class Form1 : Form
    {
        Bitmap HinhGoc;
        double[] AvgVector = new double[3];
        int x1, x2, y1, y2;
        double threshold;
        string thresholdLbl;
        double[] Status = new double[6];
        Rectangle Rect; // Hình chữ nhật quanh vùng được chọn làm nền
        Point XY1; // Điểm bắt đầu
        Point XY2; // Điểm kết thúc
        Boolean MouseDown; // Kiểm tra chuột còn nhấn giữ hay không
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

        //______________________________!!!Viết hàm tính vector trung bình màu!!!___________________________________//
        public double[] AvgColorVector(Bitmap hinhgoc, int x1, int y1, int x2, int y2)
        {
            double[] AvgColorVector = { 0, 0, 0 }; 
            // Kích thước của vùng ảnh được chọn, thêm trị tuyệt đối trong công thức để đảm bảo kết quả luôn dương
            double size = Math.Abs((x2 - x1 + 1) * (y2 - y1 + 1));

            for (int x = x1; x <= x2; x++)
                for (int y = y1; y <= y2; y++)
                {
                    
                    // Lấy thông tin màu R-G-B tại tất cả các điểm ảnh trong vùng được chọn
                    Color color = hinhgoc.GetPixel(x, y);   
                    // Cộng dồn tất cả điểm ảnh đó cho mỗi kênh R-G-B tương ứng 
                    AvgColorVector[0] += color.R;
                    AvgColorVector[1] += color.G;
                    AvgColorVector[2] += color.B;
                }

            // Kết thúc quét và tính trung bình cộng cho mỗi kênh màu
            AvgColorVector[0] /= size;
            AvgColorVector[1] /= size;
            AvgColorVector[2] /= size;

           
            return AvgColorVector;   // Trả vector trung bình màu
        }
        //----------------------------------------------------------------------------------------------------------//
        //----------------------------------------------------------------------------------------------------------//
        //----------------------------------------------------------------------------------------------------------//

        //________________________________________!!!Viết hàm phân đoạn ảnh!!!______________________________________//
        public Bitmap ColorSegmentation(Bitmap hinhgoc, double[] AvgColorVector, double threshold)
        {
            // Tạo sẵn một hình bitmap để chứa ảnh đã phân đoạn
            Bitmap SegmentedImage = new Bitmap(hinhgoc.Width, hinhgoc.Height);
            // Tạo biến lưu khoảng cách giữa điểm ảnh đang quét và vector trung bình màu
            double EucledianDistance;
            // Tạo biến lưu các giá trị RGB của vector trung bình màu
            double Ra = AvgColorVector[0];
            double Ga = AvgColorVector[1];
            double Ba = AvgColorVector[2];
            // Tiến hành quét các điểm ảnh trong hình gốc RGB   
            for (int x = 0; x < hinhgoc.Width; x++)
                for (int y = 0; y < hinhgoc.Height; y++)
                {
                    // Lấy thông tin màu R-G-B tại điểm ảnh trong mặt nạ
                    // tại vị trí (x, y)
                    Color color = hinhgoc.GetPixel(x, y);
                    double R = color.R;
                    double G = color.G;
                    double B = color.B;

                    // Tính Eucledian distance giữa điểm ảnh đang xét và vector trung bình màu
                    EucledianDistance = Math.Sqrt((Ra - R) * (Ra - R) + (Ga - G) * (Ga - G) + (Ba - B) * (Ba - B));
                    // So sánh với giá trị ngưỡng 
                    // Nếu lớn hơn giữ nguyên,
                    // nếu nhỏ hơn cho điểm ảnh đó bằng (255, 255, 255)
                    if (EucledianDistance <= threshold)
                        SegmentedImage.SetPixel(x, y, Color.FromArgb(255, 255, 255)); 
                    else
                        SegmentedImage.SetPixel(x, y, Color.FromArgb((byte)R, (byte)G, (byte)B));
                }
            return SegmentedImage;   // Trả ảnh đã làm mượt về 
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

        //______________________________!!!Hàm cho phép người dùng chọn vùng nền bằng chuột!!!____________________________//
        private void picBoxHinhGoc_MouseDown(object sender, MouseEventArgs e)
        {
            MouseDown = true;
            XY1 = e.Location;
        }
        private void picBoxHinhGoc_MouseMove(object sender, MouseEventArgs e)
        {
            if (MouseDown == true)
                XY2 = e.Location;
                Refresh();
        }
        private void picBoxHinhGoc_MouseUp(object sender, MouseEventArgs e)
        {
            if (MouseDown == true)
                XY2 = e.Location;
            MouseDown = false;

            // Đưa điểm đầu và điểm cuối của hình chữ nhật vào các biến x1, x2, y1, y2 để thực hiện tính toán
            txtBoxX1.Text = Math.Min(XY1.X, XY2.X).ToString();
            x1 = Math.Min(XY1.X, XY2.X);
            txtBoxY1.Text = Math.Min(XY1.Y, XY2.Y).ToString();
            y1 = Math.Min(XY1.Y, XY2.Y);
            txtBoxX2.Text = Math.Max(XY1.X, XY2.X).ToString();
            x2 = Math.Max(XY1.X, XY2.X);
            txtBoxY2.Text = Math.Max(XY1.Y, XY2.Y).ToString();
            y2 = Math.Max(XY1.Y, XY2.Y);
        }
        //______________________________!!!Hàm vẽ hình chữ nhật quanh vùng nền!!!______________________________________//
        private void picBoxHinhGoc_Paint(object sender, PaintEventArgs e)
        {
            if (Rect != null)
            {
                e.Graphics.DrawRectangle(Pens.Black, GetRect());
            }
        }
        private Rectangle GetRect()
        {
            Rect = new Rectangle();
            Rect.X = Math.Min(XY1.X, XY2.X);
            Rect.Y = Math.Min(XY1.Y, XY2.Y);
            Rect.Width = Math.Abs(XY2.X - XY1.X);
            Rect.Height = Math.Abs(XY2.Y - XY1.Y);
            return Rect;
        }



        private void Form1_Load(object sender, EventArgs e)
        {

        }
        // Lấy tọa độ 2 điểm đầu, cuối của vùng ảnh chọn làm nền
        private void txtBoxX1_TextChanged(object sender, EventArgs e)
        {
            if(txtBoxX1.Text!= "")
                x1 = Convert.ToInt16(txtBoxX1.Text);
            Status[0] = 16.666;
            progressBar1.Value = (int)(Status[0] + Status[1] + Status[2] + Status[3] + Status[4] + Status[5]);
        }

        private void txtBoxY1_TextChanged(object sender, EventArgs e)
        {
            if (txtBoxY1.Text != "")
                y1 = Convert.ToInt16(txtBoxY1.Text);
            Status[1] = 16.666;
            progressBar1.Value = (int)(Status[0] + Status[1] + Status[2] + Status[3] + Status[4] + Status[5]);
        }

        private void txtBoxX2_TextChanged(object sender, EventArgs e)
        {
            if (txtBoxX2.Text != "")
                x2 = Convert.ToInt16(txtBoxX2.Text);
            Status[2] = 16.666;
            progressBar1.Value = (int)(Status[0] + Status[1] + Status[2] + Status[3] + Status[4] + Status[5]);
        }

        private void txtBoxY2_TextChanged(object sender, EventArgs e)
        {
            if (txtBoxY2.Text != "")
                y2 = Convert.ToInt16(txtBoxY2.Text);
            Status[3] = 16.666;
            progressBar1.Value = (int)(Status[0] + Status[1] + Status[2] + Status[3] + Status[4] + Status[5]);
        }

        // Lấy giá trị ngưỡng và hiển thị lên label
        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            threshold = trackBarThreshold.Value;
            thresholdLbl = threshold.ToString();
            lblThreshold.Text = thresholdLbl;
            Status[4] = 16.666;
            progressBar1.Value = (int)(Status[0] + Status[1] + Status[2] + Status[3] + Status[4] + Status[5]);
        }



        // Ấn nút khởi tạo để bắt đầu tính toán và xuất hình phân đoạn
        private void buttonInitiate_Click(object sender, EventArgs e)
        {
            Status[5] = 16.67;
            progressBar1.Value = (int)(Status[0] + Status[1] + Status[2] + Status[3] + Status[4] + Status[5]);   
            // Tính vector trung bình màu và hiển thị hình phân đoạn
            AvgVector = AvgColorVector(HinhGoc, x1, y1, x2, y2);
            picBoxSegmentedImage.Image = ColorSegmentation(HinhGoc, AvgVector, threshold);
            // Đưa giá trị của vector trung bình màu và hiển thị màu đó lên panel
            txtBoxR.Text = ((byte)AvgVector[0]).ToString();
            txtBoxG.Text = ((byte)AvgVector[1]).ToString();
            txtBoxB.Text = ((byte)AvgVector[2]).ToString();
            Panel.BackColor = Color.FromArgb((int)AvgVector[0], (int)AvgVector[1], (int)AvgVector[2]);
        }
        // Ấn nút reset để xóa các thông số cũ
        private void buttonReset_Click(object sender, EventArgs e)
        {
            txtBoxX1.Text = "";
            txtBoxY1.Text = "";
            txtBoxX2.Text = "";
            txtBoxY2.Text = "";
            trackBarThreshold.Value = 0;

            txtBoxR.Text = "";
            txtBoxG.Text = "";
            txtBoxB.Text = "";
            Panel.BackColor = Color.Transparent;
            picBoxSegmentedImage.Image = null;

            Array.Clear(Status, 0, 6);
            progressBar1.Value = (int)(Status[0] + Status[1] + Status[2] + Status[3] + Status[4] + Status[5]);

        }
        




    }
}






