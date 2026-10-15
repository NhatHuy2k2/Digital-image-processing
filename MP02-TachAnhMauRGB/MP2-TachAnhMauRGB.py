import cv2             # Sử dụng thư viện xla OpenCV
import numpy as np     # Thư viện toán học, đặc biệt là các tính toán ma trận

# Đọc ảnh màu dùng thư viện OpenCV
img = cv2.imread('Lena.png', cv2.IMREAD_COLOR)

# Lấy kích thước của ảnh
height = img.shape[0]
width = img.shape[1]
print("Chiều cao của ảnh: ",height)
print("Chiều rộng của ảnh: ",width)
# Khai báo 3 biến để chứa 3 kênh màu RGB
red = np.zeros((height, width, 3), np.uint8) # số 3 là ba kênh R-G-B
green = np.zeros((height, width, 3), np.uint8)
blue = np.zeros((height, width, 3), np.uint8)
# Ban đầu set zero cho tất cả điểm ảnh có trong cả 3 kênh trong mỗi hình
red[:]=[0,0,0]
green[:]=[0,0,0]
blue[:]=[0,0,0]
# Mỗi hình là một ma trận 2 chiều nên sẽ dùng 2 vòng for
#để đọc hết các điểm ảnh có trong hình
for x in range(width):
    for y in range (height):
        # Lấy giá trị điểm ảnh tại vị trí (x,y)
        R = img[y, x, 2]
        G = img[y, x, 1]
        B = img[y, x, 0]
        # Thiết lập màu cho các kênh
        red[y, x, 2] = R
        green[y, x, 1] = G
        blue[y, x, 0] = B

# Hiển thị hình thư viện OpenCV
cv2.imshow('Hinh mau RGB goc co gai Lena', img)
cv2.imshow('Kenh RED', red)
cv2.imshow('Kenh GREEN', green)
cv2.imshow('Kenh BLUE', blue)
# Bấm phím bất ký để đóng cửa sổ hiển thị hình
cv2.waitKey(0)

# Giải phóng bộ nhớ đã cấp phát cho các cửa sổ hiển thị hình
cv2.destroyAllWindows()
 
