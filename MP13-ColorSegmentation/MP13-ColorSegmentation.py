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

'__________________________________!!!Viết hàm tính vector trung bình màu!!!_______________________________'
def AvgColorVector(imgPIL,x1, y1, x2, y2):
    AvgVector = [0, 0, 0]

    # Tính kích thước của vùng ảnh được chọn
    size = abs((x2 - x1 + 1) * (y2 - y1 + 1))

    # Mỗi ảnh là một ma trận 2 chiều nên sẽ dùng 2 vòng lặp for để
    #đọc hết các điểm ảnh (pixel) có trong ảnh
    for x in range(x1, x2 + 1):
        for y in range(y1, y2 + 1):


            # Lấy giá trị điểm ảnh tại vị trí (x,y)
            # parameters for getpixel have to be a tuple (a,b)
            R, G, B = imgPIL.getpixel((x,y))
            # Cộng dồn giá trị tất cả điểm ảnh theo mỗi kênh tương ứng
            AvgVector[0] += R 
            AvgVector[1] += G 
            AvgVector[2] += B 

    # Kết thúc quét và tính trung bình cộng cho mỗi kênh màu
    AvgVector[0] /= size
    AvgVector[1] /= size
    AvgVector[2] /= size
    print("Vector trung bình màu: ",AvgVector)
    # Kết quả trả về là 1 tuple chứa giá trị 3 kênh màu của vector trung bình màu
    return AvgVector

'_____________________________________________________________________________________'

'__________________________________!!!Viết hàm phân đoạn ảnh!!!_______________________________'
def ColorSegmentation(imgPIL, AvgVector, threshold):
    # Tạo ảnh có cùng kích thước và mode với ảnh gốc
    SegmentedImg= Image.new(imgPIL.mode, imgPIL.size)

    # Lấy kích thước của ảnh từ imgPIL
    width = imgPIL.size[0]
    height = imgPIL.size[1]

    Ra = np.double(AvgVector[0])
    Ga = np.double(AvgVector[1])
    Ba = np.double(AvgVector[2])
    # Mỗi ảnh là một ma trận 2 chiều nên sẽ dùng 2 vòng lặp for để
    #đọc hết các điểm ảnh (pixel) có trong ảnh
    for x in range(width):
        for y in range(height):
            # Lấy giá trị điểm ảnh tại vị trí (x,y)
            # parameters for getpixel have to be a tuple (a,b)
            R, G, B = imgPIL.getpixel((x,y))
            # Kiểu dữ liệu của R, G, B là int
            #Tính Eucledian distance giữa điểm ảnh đang xét và vector trung bình màu
            EucledianDistance = sqrt((R - Ra) * (R - Ra) + (G - Ga) * (G - Ga) + (B - Ba) * (B - Ba))
            # So sánh với giá trị ngưỡng 
            # Nếu lớn hơn giữ nguyên,
            # nếu nhỏ hơn cho điểm ảnh đó bằng (255, 255, 255)
            if (EucledianDistance <= threshold):
                SegmentedImg.putpixel((x, y),(255, 255, 255))
            else:
                SegmentedImg.putpixel((x, y), (B, G, R))
    return SegmentedImg
'__________________________________________________________________________________________________________'
'______________________________________Kết thúc các hàm tính toán__________________________________________'
'__________________________________________________________________________________________________________'

while 1:
    print("Chọn vùng ảnh làm nền")
    
    xy1 = (input("\nNhập tọa độ điểm đầu: ").split())
    while len(xy1) != 2:
        xy1 = input("Mời nhập lại tọa độ điểm đầu: ").split()
    x1 = int(xy1[0])
    y1 = int(xy1[1])
    print("Tọa độ điểm đầu ({},{})".format(x1, y1))


    xy2 = input("\nNhập tọa độ điểm cuối: ").split()
    while len(xy2) != 2:
        xy2 = input("Mời nhập lại tọa độ điểm cuối: ").split()
    x2 = int(xy2[0])
    y2 = int(xy2[1])
    print("Tọa độ điểm cuối ({},{})".format(x2, y2))
    
    threshold = int(input("\nNhập giá trị ngưỡng: "))
    print("Giá trị ngưỡng: ",threshold)

    AvgVector = AvgColorVector(imgPIL, x1, y1, x2, y2)
    Segmented_img = ColorSegmentation(imgPIL, AvgVector, threshold)
    # Chuyển ảnh từ PIL sang OpenCV để hiển thị bằng OpenCV

    Segmented_img = np.array(Segmented_img)

    # Hiển thị ảnh dùng thư viện OpenCV
    cv2.imshow('Anh mau RGB goc co gai Lena', img)
    cv2.imshow('Hinh da phan doan', Segmented_img)
    

    # Bấm phím bất kỳ để đóng cửa sổ hiện thị ảnh
    cv2.waitKey(0)

    # Giải phóng bộ nhớ đã cấp phát cho các cửa sổ
    cv2.destroyAllWindows()






