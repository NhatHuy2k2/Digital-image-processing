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
average = Image.new(imgPIL.mode, imgPIL.size)
print(imgPIL.size)

# Lấy kích thước của ảnh từ imgPIL
width = average.size[0]
height = average.size[1]

' Chỉ dùng thư viện EmguCV và Numpy để chuyển đổi ảnh màu RGB sang ảnh mức xám'
'______________________________________________________'
gray_array = np.zeros((height, width, 3), np.uint8)
gray_array[:] = [0, 0, 0]
'______________________________________________________'
# Mỗi ảnh là một ma trận 2 chiều nên sẽ dùng 2 vòng lặp for để
#đọc hết các điểm ảnh (pixel) có trong ảnh
for x in range(width):
    for y in range(height):
        # Lấy giá trị điểm ảnh tại vị trí (x,y)
        # parameters for getpixel have to be a tuple (a,b)
        R, G, B = imgPIL.getpixel((x,y))
        # Kiểu dữ liệu của R, G, B là int

        # Công thức chuyển đổi điểm ảnh màu RGB thành
        #điểm ảnh mức xám dùng phương pháp Average
        gray = np.uint8((R +G +B)/3)

        # Gán giá trị mức xám vừa tính cho ảnh xám
        # 2nd tuple has the values of B, G, R color band respectively
        average.putpixel((x,y),(gray, gray, gray))
        '___________________________________________________________'
        R_EMGUCV = img[y, x, 2]
        G_EMGUCV = img[y, x, 1]
        B_EMGUCV = img[y, x, 0]
       
        GRAY_EMGUCV = np.uint8((int(R_EMGUCV) +int(G_EMGUCV) +int(B_EMGUCV))/3)
        
        gray_array[y,x,0] = GRAY_EMGUCV
        gray_array[y,x,1] = GRAY_EMGUCV
        gray_array[y,x,2] = GRAY_EMGUCV
        '___________________________________________________________'
# Kiểu dữ liệu các biến kênh màu của 2 thư viện PILLOW và EmguCV khác nhau
print(type(B))
print(type(B_EMGUCV))

# Chuyển ảnh từ PIL sang OpenCV để hiển thị bằng OpenCV
anhmucxam = np.array(average)

# Hiện thị ảnh dùng thư viện OpenCV
cv2.imshow('Anh mau RGB goc co gai Lena', img)
cv2.imshow('Anh muc xam dung Average', anhmucxam)
cv2.imshow('Anh muc xam dung Average khong dung Pillow', gray_array)

# Bấm phím bất kỳ để đóng cửa sổ hiện thị ảnh
cv2.waitKey(0)

# Giải phóng bộ nhớ đã cấp phát cho các cửa sổ
cv2.destroyAllWindows()






