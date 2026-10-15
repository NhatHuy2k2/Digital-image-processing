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

# Tạo một ảnh có cùng kích thước và mode với ảnh imgPIL
# Ảnh này dùng để chứa kết quả chuyển đổi RGB sang Grayscale
binary = Image.new(imgPIL.mode, imgPIL.size)

# Lấy kích thước của ảnh từ imgPIL
width = binary.size[0]
height = binary.size[1]


while 1:
    # Thiết lập một giá trị ngưỡng để tính điểm ảnh nhị phân
    nguong = int(input("Nhập giá trị ngưỡng: "))
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
            if (gray < nguong):
                binary.putpixel((x, y),(0, 0, 0))
            else:
                binary.putpixel((x, y),(255, 255, 255))
            
            

    # Chuyển ảnh từ PIL sang OpenCV để hiển thị bằng OpenCV
    anhnhiphan = np.array(binary)

    # Hiện thị ảnh dùng thư viện OpenCV
    cv2.imshow('Anh mau RGB goc co gai Lena', img)
    cv2.imshow('Anh nhi phan (Binary)', anhnhiphan)

    # Bấm phím bất kỳ để đóng cửa sổ hiện thị ảnh
    cv2.waitKey(0)

    # Giải phóng bộ nhớ đã cấp phát cho các cửa sổ
    cv2.destroyAllWindows()






