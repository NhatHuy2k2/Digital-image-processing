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
def ChuyenDoiRGBSangCMYK(imgPIL):
    # Tạo bốn ảnh có cùng kích thước và mode với ảnh imgPIL
    # Ảnh này dùng để chứa kết quả chuyển đổi RGB sang 4 kênh tương ứng C-M-Y-K
    Cyan = Image.new(imgPIL.mode, imgPIL.size)
    Magenta = Image.new(imgPIL.mode, imgPIL.size)
    Yellow = Image.new(imgPIL.mode, imgPIL.size)
    Black = Image.new(imgPIL.mode, imgPIL.size)

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

            # Kênh Black đơn giản là lấy min(R, G, B)
            K = min(R, G, B)
        
            # Màu Cyan là kết hợp giữa Green và Blue, nên kênh Red mình set về 0
            # Màu Magenta là kết hợp giữa Red và Blue, nên kênh Green mình set về 0
            # Màu Yellow là kết hợp giữa Red và Green, nên kênh Blue mình set về 0
            # Hàm putpixel quy ước 3 kênh màu theo thứ tự là B, G, R
            Cyan.putpixel((x,y),(B, G, 0))
            Magenta.putpixel((x,y),(B, 0, R))
            Yellow.putpixel((x,y),(0, G, R))
            Black.putpixel((x,y),(K, K, K))
    # Kết quả trả về là một tuple chứa 4 hình tương ứng với 4 kênh màu C-M-Y-K
    return Cyan, Magenta, Yellow, Black

'_____________________________________________________________________________________'



CyanPIL, MagentaPIL, YellowPIL, BlackPIL = ChuyenDoiRGBSangCMYK(imgPIL)
# Chuyển ảnh từ PIL sang OpenCV để hiển thị bằng OpenCV
Cyan = np.array(CyanPIL)
Magenta = np.array(MagentaPIL)
Yellow = np.array(YellowPIL)
Black = np.array(BlackPIL)

# Hiện thị ảnh dùng thư viện OpenCV
cv2.imshow('Anh mau RGB goc co gai Lena', img)
cv2.imshow('Kenh CYAN', Cyan)
cv2.imshow('Kenh MAGENTA', Magenta)
cv2.imshow('Kenh YELLOW', Yellow)
cv2.imshow('Kenh BLACK', Black)


# Bấm phím bất kỳ để đóng cửa sổ hiện thị ảnh
cv2.waitKey(0)

# Giải phóng bộ nhớ đã cấp phát cho các cửa sổ
cv2.destroyAllWindows()






