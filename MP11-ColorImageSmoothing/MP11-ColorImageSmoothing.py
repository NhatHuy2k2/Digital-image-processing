import cv2                  # Sử dụng thư viện xử lý ảnh OpenCV
from PIL import Image       # Thư viện xử lý ảnh PILLOW hỗ trợ nhiều định dạng ảnh khác nhau
import numpy as np          # Thư viện toán học, đặc biệt là các tính toán ma trận

# Khai báo đường dẫn file hình
filehinh = r'C:\Users\DELL\Pictures\Screenshots\lenu.jpg'
# r'string' means raw string. With it, Python can interpret '\' as a literal backslash. 

# Đọc ảnh màu dùng thư viện OpenCV
img = cv2.imread(filehinh,1)
# Đọc ảnh màu dùng thư viện PIL. Ảnh PIL này chúng ta sẽ dùng
#để thực hiện các tác vụ xử lý & tính toán thay vì dùng OpenCV
imgPIL = Image.open(filehinh)


'_____________________________________________________________________________________'
def ColorImageSmoothing(imgPIL,maskSize):
    # Tạo một ảnh có cùng kích thước và mode với ảnh imgPIL
    # Tính toán kích thước đường viền, là tập hợp những điểm ảnh không có mask toàn vẹn để tính toán    
    Edge = int(maskSize/2)
    Smoothed_img = Image.new(imgPIL.mode, imgPIL.size)
    K = int(maskSize ** 2)

    # Lấy kích thước của ảnh từ imgPIL
    width = imgPIL.size[0]
    height = imgPIL.size[1]

    Rs = Gs = Bs = 0
    # Mỗi ảnh là một ma trận 2 chiều nên sẽ dùng 2 vòng lặp for để
    #đọc hết các điểm ảnh (pixel) có trong ảnh
    # Để tránh các điểm ảnh thuộc đường viền, ta cho vòng lặp for chạy từ giá trị 
    #edge đến width - Edge. Chú ý, hàm range(a,b) chỉ tạo ra một list từ a đến b - 1
    for x in range(Edge, width - Edge):
        for y in range(Edge, height - Edge):

            for i in range(x - Edge, x + Edge + 1):
                for j in range(y - Edge, y + Edge + 1):
                    # Lấy giá trị điểm ảnh tại vị trí (x,y)
                    # parameters for getpixel have to be a tuple (a,b)
                    R, G, B = imgPIL.getpixel((i,j))
                    # Kiểu dữ liệu của R, G, B là int

                    Rs = int(Rs + R)
                    Gs = int(Gs + G)
                    Bs = int(Bs + B)

            
            Rs = np.uint8(Rs/K)
            Gs = np.uint8(Gs/K)
            Bs = np.uint8(Bs/K)

                    
            Smoothed_img.putpixel((x,y),(Bs, Gs, Rs))
            Rs = Gs = Bs = 0
    # Kết quả trả về là hình đã được làm mượt
    return Smoothed_img

'_____________________________________________________________________________________'

while 1:
    a = int(input("Nhập kích thước mask: "))
    if a % 2 ==0:
       a -=1
    print("\tKích thước mask {}x{}".format(a,a))
    Smoothed_img = ColorImageSmoothing(imgPIL,a)
    #Smoothed_img = cv2.blur(img,(a,a))
    # Chuyển ảnh từ PIL sang OpenCV để hiển thị bằng OpenCV

    Smoothed_img = np.array(Smoothed_img)

    # Hiển thị ảnh dùng thư viện OpenCV
    cv2.imshow('Anh mau RGB goc co gai Lena', img)
    cv2.imshow('Hinh lam muot voi mat na {}x{}'.format(a,a), Smoothed_img)
    

    # Bấm phím bất kỳ để đóng cửa sổ hiện thị ảnh
    cv2.waitKey(0)

    # Giải phóng bộ nhớ đã cấp phát cho các cửa sổ
    cv2.destroyAllWindows()






