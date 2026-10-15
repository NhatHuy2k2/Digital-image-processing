import cv2                  # Sử dụng thư viện xử lý ảnh OpenCV
from PIL import Image       # Thư viện xử lý ảnh PILLOW hỗ trợ nhiều định dạng ảnh khác nhau
import numpy as np          # Thư viện toán học, đặc biệt là các tính toán ma trận
import matplotlib.pyplot as plt  # Thư viện vẽ biểu đồ


'________________________________________________________________________'
'Hàm chuyển đổi ảnh màu RGB sang ảnh mức xám (Grayscale) dùng PP Luminance'
def ChuyenDoiAnhMauRGBSangAnhXamLuminance(imgPIL):
    # Tạo một ảnh có cùng kích thước và mode với ảnh imgPIL
    # Ảnh này dùng để chứa kết quả chuyển đổi RGB sang Grayscale
    average = Image.new(imgPIL.mode, imgPIL.size)

    # Lấy kích thước của ảnh từ imgPIL
    width = average.size[0]
    height = average.size[1]
    


    # Mỗi ảnh là một ma trận 2 chiều nên sẽ dùng 2 vòng lặp for để
    #đọc hết các điểm ảnh (pixel) có trong ảnh
    for x in range(width):
        for y in range(height):
            # Lấy giá trị điểm ảnh tại vị trí (x,y)
            # parameters for getpixel have to be a tuple (a,b)
            R, G, B = imgPIL.getpixel((x,y))
            # Kiểu dữ liệu của R, G, B là int

            # Công thức chuyển đổi điểm ảnh màu RGB thành
            #điểm ảnh mức xám dùng phương pháp Luminance
            gray = np.uint8(0.2126*R +0.7152*G + 0.0722*B)

            # Gán giá trị mức xám vừa tính cho ảnh xám
            # 2nd tuple has the values of B, G, R color band respectively
            average.putpixel((x,y),(gray, gray, gray))
    return average
'________________________________________________________________________'   

#Tính histogram của ảnh xám

def TinhHistogramXam(HinhXamPIL):
    # Mỗi pixel có giá trị từ 0-255, nên phải khai báo một mảng có 
    #256 phần tử để chứa số đếm của các pixels có cùng giá trị
    his = np.zeros(256)

    # Kích thước ảnh
    w = HinhXamPIL.size[0]
    h = HinhXamPIL.size[1]
    for x in range(w):
        for y in range(h):
            # Lấy giá trị xám tại điểm (x,y)
            gR, gG, gB = HinhXamPIL.getpixel((x,y))

            # Giá trị gray tính ra cũng chính là phần tử thứ gray
            #trong mảng his đã khai báo ở trên, sẽ tăng số đếm
            #của phần tử thứ gray lên 1
            his[gR] += 1
    return his        
'________________________________________________________________________'
def TinhHistogramRGB(imgPIL):
    # Mỗi pixel có giá trị từ 0-255, nên phải khai báo một mảng có 
    #256 phần tử để chứa số đếm của các pixels có cùng giá trị
    hisRGB = np.zeros((3,256),np.double)

    # Kích thước ảnh
    w = imgPIL.size[0]
    h = imgPIL.size[1]
    for x in range(w):
        for y in range(h):
            # Lấy giá trị kênh R-G-B tại điểm (x,y)
            gR, gG, gB = imgPIL.getpixel((x,y))

            # Giá trị gray tính ra cũng chính là phần tử thứ gray
            #trong mảng his đã khai báo ở trên, sẽ tăng số đếm
            #của phần tử thứ gray lên 1
            hisRGB[0,gR] += 1
            hisRGB[1,gG] += 1
            hisRGB[2,gB] += 1
    return hisRGB        
'________________________________________________________________________'    
# Vẽ biểu đồ Histogram dùng thư viện matplotlib
def VeBieuDoHistogram(his, hisRGB):
    w = 6
    h = 4
    # Tách từng hàng trong mảng hisRGB rồi lưu vào 3 mảng mới
    RedArray, GreenArray, BlueArray = np.array_split(hisRGB, 3, axis = 0)
    # Biến mảng 2 chiều thành 1 chiều
    RFlat = RedArray.flatten()
    GFlat = GreenArray.flatten()
    BFlat = BlueArray.flatten()
    
    # Tạo 1 mảng 1 chiều có giá trị từ 0 đến 255
    trucX = np.zeros(256)
    trucX = np.linspace(0, 256, 256)

    fig, graph = plt.subplots(2,figsize=(7, 8))
    fig.canvas.manager.set_window_title('Biểu đồ Histogram')
    
    graph[0].plot(trucX, his,color = 'black')
    graph[0].set_title("Grayscale Histogram ", weight = "bold") 
    graph[0].set_xlabel("Giá trị mức xám ") 
    graph[0].set_ylabel("Số điểm cùng giá trị mức xám ")
    

    graph[1].plot(trucX, RFlat,color = 'red', label = 'red')
    graph[1].plot(trucX, GFlat,color = 'green', label = 'green')
    graph[1].plot(trucX, BFlat,color = 'blue', label = 'blue')
    graph[1].set_title("Colour Histogram ", weight = "bold") 
    graph[1].set_xlabel("Giá trị màu của các điểm ảnh ") 
    graph[1].set_ylabel("Số điểm ảnh có cùng giá trị màu ") 
    graph[1].legend()

    plt.subplots_adjust(hspace = 0.4, top = 0.96)
    
    plt.show()
'________________________________________________________________________'



# Khai báo đường dẫn file hình
#filehinh = r'C:\Users\DELL\Pictures\Screenshots\bird_small.jpg'
filehinh = r'C:\Users\DELL\Pictures\Screenshots\Lenu.jpg'
# r'string' means raw string. With it, Python can interpret '\' as a literal backslash. 

# Đọc ảnh màu dùng thư viện OpenCV
img = cv2.imread(filehinh,1)
# Đọc ảnh màu dùng thư viện PIL.
imgPIL = Image.open(filehinh)
print(imgPIL)
# Chuyển sang ảnh mức xám
HinhXamPIL = ChuyenDoiAnhMauRGBSangAnhXamLuminance(imgPIL)

# Tính Histogram
his = TinhHistogramXam(HinhXamPIL)
hisRGB = TinhHistogramRGB(imgPIL)

# Chuyển ảnh PIL sang OpenCV để hiển thị bằng thư viện cv2
HinhXamCV = np.array(HinhXamPIL)


# Hiện thị ảnh dùng thư viện OpenCV
cv2.imshow('Anh mau RGB goc', img)
cv2.imshow('Anh muc xam dung Luminance', HinhXamCV)
# Hiển thị biểu đồ Histogram
VeBieuDoHistogram(his, hisRGB)
# Bấm phím bất kỳ để đóng cửa sổ hiện thị ảnh
cv2.waitKey(0)

# Giải phóng bộ nhớ đã cấp phát cho các cửa sổ
cv2.destroyAllWindows()
