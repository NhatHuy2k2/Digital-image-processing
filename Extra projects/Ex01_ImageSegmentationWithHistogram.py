from asyncio.windows_events import NULL
import cv2                  # Sử dụng thư viện xử lý ảnh OpenCV
from PIL import Image       # Thư viện xử lý ảnh PILLOW hỗ trợ nhiều định dạng ảnh khác nhau
import numpy as np          # Thư viện toán học, đặc biệt là các tính toán ma trận
from math import sqrt

# Khai báo đường dẫn file hình
filehinh = r'C:\Users\DELL\Pictures\Screenshots\lenu.jpg'
# r'string' means raw string. With it, Python can interpret '\' as a literal backslash. 

# Đọc ảnh màu dùng thư viện OpenCV
img = cv2.imread(filehinh,1)
# Đọc ảnh màu dùng thư viện PIL. Ảnh PIL này chúng ta sẽ dùng
#để thực hiện các tác vụ xử lý & tính toán thay vì dùng OpenCV
imgPIL = Image.open(filehinh)


'__________________________________________________________________________________________________________'
'______________________________________Bắt đầu viết các hàm tính toán______________________________________'
'__________________________________________________________________________________________________________'
'________________________________________________________________________'

'________________!!!Hàm chuyển đổi ảnh màu RGB sang ảnh mức xám (Grayscale) dùng PP Luminance!!!____________________'
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


'__________________________________!!!Viết hàm phân đoạn ảnh!!!_______________________________'
def ColorSegmentation(imgPIL, k1, k2):
    # Tạo ảnh có cùng kích thước và mode với ảnh gốc
    SegmentedImg= Image.new(imgPIL.mode, imgPIL.size)

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

            # So sánh với giá trị ngưỡng 
            # Nếu nhỏ hơn k1, cho điểm ảnh đó bằng (0, 0, 0)
            if (R <= k1):
                SegmentedImg.putpixel((x, y),(0, 0, 0))
            # Nếu lớn hơn k1, nhỏ hơn k2, cho điểm ảnh đó bằng (125, 125, 125)
            # Nếu lớn hơn k2 cho điểm ảnh đó bằng (255, 255, 255)
            elif ((R > k1)&(R <= k2)):
                SegmentedImg.putpixel((x, y),(125, 125, 125))
            else:
                SegmentedImg.putpixel((x, y), (255, 255, 255))
    return SegmentedImg


'__________________________________________________________________________________________________________'
'______________________________________Kết thúc các hàm tính toán__________________________________________'
'__________________________________________________________________________________________________________'

# Chuyển sang ảnh mức xám
HinhXamPIL = ChuyenDoiAnhMauRGBSangAnhXamLuminance(imgPIL)

Segmented_img = ColorSegmentation(imgPIL, 100, 180)
# Chuyển ảnh từ PIL sang OpenCV để hiển thị bằng OpenCV

Segmented_img = np.array(Segmented_img)

# Hiển thị ảnh dùng thư viện OpenCV
cv2.imshow('Anh mau RGB goc co gai Lena', img)
cv2.imshow('Hinh da phan doan', Segmented_img)


# Bấm phím bất kỳ để đóng cửa sổ hiện thị ảnh
cv2.waitKey(0)

# Giải phóng bộ nhớ đã cấp phát cho các cửa sổ
cv2.destroyAllWindows()






