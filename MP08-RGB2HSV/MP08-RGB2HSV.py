import cv2                  # Sử dụng thư viện xử lý ảnh OpenCV
from PIL import Image       # Thư viện xử lý ảnh PILLOW hỗ trợ nhiều định dạng ảnh khác nhau
import numpy as np          # Thư viện toán học, đặc biệt là các tính toán ma trận
from math import sqrt, acos, pi                 # Thư viện toán học, hỗ trợ các hàm lấy căn, arctan,...

# Khai báo đường dẫn file hình
filehinh = r'C:\Users\DELL\Pictures\Screenshots\Lena.png'
# r'string' means raw string. With it, Python can interpret '\' as a literal backslash. 

# Đọc ảnh màu dùng thư viện OpenCV
img = cv2.imread(filehinh,1)

# Đọc ảnh màu dùng thư viện PIL. Ảnh PIL này chúng ta sẽ dùng
#để thực hiện các tác vụ xử lý & tính toán thay vì dùng OpenCV
imgPIL = Image.open(filehinh)


'_____________________________________________________________________________________'
def ChuyenDoiRGBSangHSV(imgPIL):
    # Tạo bốn ảnh có cùng kích thước và mode với ảnh imgPIL
    # Ảnh này dùng để chứa kết quả chuyển đổi RGB sang 3 kênh tương ứng H-S-V và 1 hình HSV
    Hue = Image.new(imgPIL.mode, imgPIL.size)
    Saturation = Image.new(imgPIL.mode, imgPIL.size)
    Value = Image.new(imgPIL.mode, imgPIL.size)
    HSVImg = Image.new(imgPIL.mode, imgPIL.size)

    # Lấy kích thước của ảnh từ imgPIL
    width = imgPIL.size[0]
    height = imgPIL.size[1]

    # Mỗi ảnh là một ma trận 2 chiều nên sẽ dùng 2 vòng lặp for để
    #đọc hết các điểm ảnh (pixel) có trong ảnh
    for x in range(width):
        for y in range(height):
            # Lấy giá trị điểm ảnh tại vị trí (x,y)
            # parameters for getpixel have to be a tuple (a,b)
            R, G, B = imgPIL.getpixel((x,y))
            # Kiểu dữ liệu của R, G, B là int

            R = np.double(R)
            G = np.double(G)
            B = np.double(B)
            # t1 là phần tử số của công thức 
            t1 = ((R - G) + (R - B))/2
            # t2 là phần mẫu số của công thức tính góc theta
            t2 = sqrt((R - G) * (R - G) + (R - B) * (G - B))
            # theta bằng arccos của t1/t2, có đơn vị là radian
            theta = acos(t1/t2)

            # Nếu mà Blue <= Green thì Hue = theta
            if (B <= G):
                H = theta
            # Còn nếu Blue > Green thì Hue = 360 - theta hay 2pi - theta
            else:
                H = 2 * pi - theta

            # Chuyển đổi H từ radian sang độ
            H = H * 180/pi
            H_uint8 = np.uint8(H)
           

            # Công thức tính Saturation
            S = 1 - 3 * min(R, G, B)/(R + G + B)
            # Saturation có giá trị trong khoảng [0, 1], để hiển thị ra hình ảnh phải convert về khoảng giá trị [0, 255]
            S_255 = np.uint8(S * 255)


            # Công thức tính Value 
            V = max(R, G, B)
            V_uint8 = np.uint8(V)

            Hue.putpixel((x,y),(H_uint8, H_uint8, H_uint8))
            Saturation.putpixel((x,y),(S_255, S_255, S_255))
            Value.putpixel((x,y),(V_uint8, V_uint8, V_uint8))
            HSVImg.putpixel((x,y),(V_uint8, S_255, H_uint8))
    # Kết quả trả về là một tuple chứa 4 hình tương ứng với 3 kênh H-S-V và hình HSV
    return Hue, Saturation, Value, HSVImg

'_____________________________________________________________________________________'



HuePIL, SaturationPIL, ValuePIL, HSVImgPIL = ChuyenDoiRGBSangHSV(imgPIL)
# Chuyển ảnh từ PIL sang OpenCV để hiển thị bằng OpenCV
Hue = np.array(HuePIL)
Saturation = np.array(SaturationPIL)
Value = np.array(ValuePIL)
HSVImg = np.array(HSVImgPIL)

# Hiển thị ảnh dùng thư viện OpenCV
cv2.imshow('Anh mau RGB goc co gai Lena', img)
cv2.imshow('Kenh HUE', Hue)
cv2.imshow('Kenh SATURATION', Saturation)
cv2.imshow('Kenh VALUE', Value)
cv2.imshow('Hinh HSV', HSVImg)


# Bấm phím bất kỳ để đóng cửa sổ hiện thị ảnh
cv2.waitKey(0)

# Giải phóng bộ nhớ đã cấp phát cho các cửa sổ
cv2.destroyAllWindows()






