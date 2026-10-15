import cv2                  # Sử dụng thư viện xử lý ảnh OpenCV
from PIL import Image       # Thư viện xử lý ảnh PILLOW hỗ trợ nhiều định dạng ảnh khác nhau
import numpy as np          # Thư viện toán học, đặc biệt là các tính toán ma trận

# Khai báo đường dẫn file hình
filehinh = r'C:\Users\DELL\Pictures\Screenshots\Lena.png'
# r'string' means raw string. With it, Python can interpret '\' as a literal backslash. 

# Đọc ảnh màu dùng thư viện OpenCV
img = cv2.imread(filehinh,1)

# Đọc ảnh màu dùng thư viện PIL. Ảnh PIL này chúng ta sẽ dùng
#để thực hiện các tác vụ xử lý & tính toán thay vì dùng OpenCV
imgPIL = Image.open(filehinh)


'_____________________________________________________________________________________'
def ChuyenDoiRGBSangXYZ(imgPIL):
    # Tạo bốn ảnh có cùng kích thước và mode với ảnh imgPIL
    # Ảnh này dùng để chứa kết quả chuyển đổi RGB sang 3 kênh tương ứng X-Y-Z và 1 hình XYZ
    X_img = Image.new(imgPIL.mode, imgPIL.size)
    Y_img = Image.new(imgPIL.mode, imgPIL.size)
    Z_img = Image.new(imgPIL.mode, imgPIL.size)
    XYZImg = Image.new(imgPIL.mode, imgPIL.size)

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

            '''Coefficients = np.array([[0.4124564,0.3575761,0.1804375],[0.2126729,0.7151522,0.0721750],[0.0193339,0.1191920,0.9503041]])
            RGB = np.array([[R],[G],[B]])
            XYZ = Coefficients@RGB

            X = np.uint8(XYZ[0,0])
            Y = np.uint8(XYZ[1,0])
            Z = np.uint8(XYZ[2,0])'''

            X = np.uint8(R * 0.4124564 + G * 0.3575761 + B * 0.1804375)
            Y = np.uint8(R * 0.2126729 + G * 0.7151522 + B * 0.0721750)
            Z = np.uint8(R * 0.0193339 + G * 0.1191920 + B * 0.9503041)
            
            X_img.putpixel((x,y),(X, X, X))
            Y_img.putpixel((x,y),(Y, Y, Y))
            Z_img.putpixel((x,y),(Z, Z, Z))
            XYZImg.putpixel((x,y),(Z, Y, X))
    # Kết quả trả về là một tuple chứa 4 hình tương ứng với 3 kênh X-Y-Z và hình XYZ
    return X_img, Y_img, Z_img, XYZImg

'_____________________________________________________________________________________'



XPIL, YPIL, ZPIL, XYZPIL = ChuyenDoiRGBSangXYZ(imgPIL)
# Chuyển ảnh từ PIL sang OpenCV để hiển thị bằng OpenCV
X_img = np.array(XPIL)
Y_img = np.array(YPIL)
Z_img = np.array(ZPIL)
XYZImg = np.array(XYZPIL)

# Hiển thị ảnh dùng thư viện OpenCV
cv2.imshow('Anh mau RGB goc co gai Lena', img)
cv2.imshow('Kenh X', X_img)
cv2.imshow('Kenh Y', Y_img)
cv2.imshow('Kenh Z', Z_img)
cv2.imshow('Hinh XYZ', XYZImg)


# Bấm phím bất kỳ để đóng cửa sổ hiện thị ảnh
cv2.waitKey(0)

# Giải phóng bộ nhớ đã cấp phát cho các cửa sổ
cv2.destroyAllWindows()






