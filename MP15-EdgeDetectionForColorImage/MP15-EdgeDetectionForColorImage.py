import cv2                  # Sử dụng thư viện xử lý ảnh OpenCV
import numpy as np          # Thư viện toán học, đặc biệt là các tính toán ma trận
from skimage.exposure import rescale_intensity
import time
import math

# Khai báo đường dẫn file hình
filehinh = r'C:\Users\DELL\Pictures\Screenshots\lenu.jpg'
# r'string' means raw string. With it, Python can interpret '\' as a literal backslash. 

# Đọc ảnh màu dùng thư viện OpenCV
img = cv2.imread(filehinh,1)


'_________________________________________________Hàm nhận dạng đường biên_________________________________________________________'
def EdgeDetectionForColorImage(img, threshold):    
    # Lấy kích thước ảnh 
    #start_time = time.time()
    img_height, img_width = img.shape[:2]
    
    # Tạo mask để thực hiện tích chập
    Sobel_x = np.array([[-1, 0, 1],
                        [-2, 0, 2],
                        [-1, 0, 1]])
    
    Sobel_y = np.array([[-1, -2, -1],
                        [ 0,  0,  0],
                        [ 1,  2,  1]])
    
    # Tạo ma trận để lưu kết quả tích chập
    EdgeDetectedImage = np.zeros((img_height, img_width, 3),np.uint8) 
    # Dùng 2 vòng lặp for để quét từng điểm ảnh từ trái sang phải, từ trên xuống dưới
    for y in range(1, img_height - 1):
        for x in range(1, img_width - 1):
            # Tạo ma trận con (region of interest) gồm các điểm ảnh xung quanh 1 điểm ảnh trung tâm  
            ROI_R = img[y - 1: y + 2, x - 1: x + 2, 2]
            ROI_G = img[y - 1: y + 2, x - 1: x + 2, 1]
            ROI_B = img[y - 1: y + 2, x - 1: x + 2, 0]
            # Thực hiện phép nhân tích chập (Convolution)
            # Tính đạo hàm riêng theo phương x, y trên kênh đỏ
            gx_R = (ROI_R * Sobel_x ).sum()
            gy_R = (ROI_R * Sobel_y ).sum()
            # Tính đạo hàm riêng theo phương x, y trên kênh xanh lá
            gx_G = (ROI_G * Sobel_x ).sum()
            gy_G = (ROI_G * Sobel_y ).sum()
            # Tính đạo hàm riêng theo phương x, y trên kênh xanh nước biển
            gx_B = (ROI_B * Sobel_x ).sum()
            gy_B = (ROI_B * Sobel_y ).sum()
            # Tinh Gxx, Gyy, Gxy, theta và F0 theo công thức trong tài liệu
            Gxx = math.pow(gx_R, 2) + math.pow(gx_G, 2) + math.pow(gx_B, 2)
            Gyy = math.pow(gy_R, 2) + math.pow(gy_G, 2) + math.pow(gy_B, 2)
            Gxy = gx_R * gy_R + gx_G * gy_G + gx_B * gy_B

            theta = math.atan2(2 * Gxy, Gxx - Gyy) / 2
            F0 = math.sqrt((Gxx + Gyy + (Gxx - Gyy) * math.cos(2 * theta) + 2 * Gxy * math.sin(2 * theta))/2)
            # Nếu gradient nhỏ hơn threshold thì pixel thuộc background
            if (F0 <= threshold):
                EdgeDetectedImage[y, x, :] = 0
            # Nếu gradient lớn hơn threshold thì pixel nằm trên edge
            else:
                EdgeDetectedImage[y, x, :] = 255
    '''
    end_time = time.time()
    elapsed_time = end_time - start_time
    print ("elapsed_time:{0}".format(elapsed_time) + "[sec]")
    '''
	# Trả kết quả đã tính
    return EdgeDetectedImage
'___________________________________________________________________________________________________________________________'

while 1:
    nguong = int(input("Nhập giá trị ngưỡng: "))

    EdgeDetectedImg = EdgeDetectionForColorImage(img, nguong)

    # Hiển thị ảnh dùng thư viện OpenCV
    cv2.imshow('Anh mau RGB goc co gai Lena', img)
    cv2.imshow('Nhan dang bien anh mau RGB bang pp Sobel nguong {}'.format(nguong), EdgeDetectedImg)

    # Bấm phím bất kỳ để đóng cửa sổ hiện thị ảnh
    cv2.waitKey(0)

    # Giải phóng bộ nhớ đã cấp phát cho các cửa sổ
    cv2.destroyAllWindows()






