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
def ChuyenDoiRGBSangYCrCb(imgPIL):
    # Tạo bốn ảnh có cùng kích thước và mode với ảnh imgPIL
    # Ảnh này dùng để chứa kết quả chuyển đổi RGB sang 3 kênh tương ứng Y-Cr-Cb và 1 hình YCrCb
    Y_img = Image.new(imgPIL.mode, imgPIL.size)
    Cr_img = Image.new(imgPIL.mode, imgPIL.size)
    Cb_img = Image.new(imgPIL.mode, imgPIL.size)
    YCrCbImg = Image.new(imgPIL.mode, imgPIL.size)

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

            Y =  np.uint8(16  + (R * 65.738  + G * 129.057 + B * 25.064)  / 256)
            Cr = np.uint8(128 - (R * 37.945  + G * 74.494  - B * 112.439) / 256)
            Cb = np.uint8(128 + (R * 112.439 - G * 94.154  - B * 18.285)  / 256)

            Y_img.putpixel((x,y),(Y, Y, Y))
            Cr_img.putpixel((x,y),(Cr, Cr, Cr))
            Cb_img.putpixel((x,y),(Cb, Cb, Cb))
            YCrCbImg.putpixel((x,y),(Cb, Cr, Y))
    # Kết quả trả về là một tuple chứa 4 hình tương ứng với 3 kênh Y-Cr-Cb và hình YCrCb
    return Y_img, Cr_img, Cb_img, YCrCbImg

'_____________________________________________________________________________________'



YPIL, CrPIL, CbPIL, YCrCbPIL = ChuyenDoiRGBSangYCrCb(imgPIL)
# Chuyển ảnh từ PIL sang OpenCV để hiển thị bằng OpenCV
Y_img = np.array(YPIL)
Cr_img = np.array(CrPIL)
Cb_img = np.array(CbPIL)
YCrCbImg = np.array(YCrCbPIL)

# Hiển thị ảnh dùng thư viện OpenCV
cv2.imshow('Anh mau RGB goc co gai Lena', img)
cv2.imshow('Kenh Y', Y_img)
cv2.imshow('Kenh Cr', Cr_img)
cv2.imshow('Kenh Cb', Cb_img)
cv2.imshow('Hinh YCrCb', YCrCbImg)


# Bấm phím bất kỳ để đóng cửa sổ hiện thị ảnh
cv2.waitKey(0)

# Giải phóng bộ nhớ đã cấp phát cho các cửa sổ
cv2.destroyAllWindows()






