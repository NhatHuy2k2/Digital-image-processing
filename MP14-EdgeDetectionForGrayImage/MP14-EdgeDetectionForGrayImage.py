import cv2                  # Sử dụng thư viện xử lý ảnh OpenCV
import numpy as np          # Thư viện toán học, đặc biệt là các tính toán ma trận
from skimage.exposure import rescale_intensity
import time

# Khai báo đường dẫn file hình
filehinh = r'C:\Users\DELL\Pictures\Screenshots\lenu.jpg'
# r'string' means raw string. With it, Python can interpret '\' as a literal backslash. 

# Đọc ảnh màu dùng thư viện OpenCV
img = cv2.imread(filehinh,1)


'_________________________________________________Hàm nhận dạng đường biên_________________________________________________________'
def EdgeDetectionForGrayImage(img, threshold):    
    # Lấy kích thước ảnh 
    #start_time = time.time()
    img_height, img_width = img.shape[:2]
    gray_img = np.zeros((img_height, img_width), np.uint8)
    
    Luminance_mask = np.array([0.0722, 0.7152, 0.2126])
    for x in range(img_width):
        for y in range(img_height):
            RGB = img[y, x, :]
            Gray_val = (RGB * Luminance_mask).sum()
            gray_img[y, x] = Gray_val
    
    # Tạo mask để thực hiện tích chập
    Sobel_x = np.array([[-1, 0, 1],
                        [-2, 0, 2],
                        [-1, 0, 1]])
    
    Sobel_y = np.array([[-1, -2, -1],
                        [ 0,  0,  0],
                        [ 1,  2,  1]])
    
    # Tạo ma trận để lưu kết quả tích chập
    EdgeDetectedImage = np.zeros((img_height, img_width, 3),np.uint8)
    # Tạo viền xung quanh ma trận gốc để có thể thực hiện xử lý phần viền ban đầu
    gray_img = np.pad(gray_img, pad_width= 1, mode='edge')       
    # Dùng 2 vòng lặp for để quét từng điểm ảnh từ trái sang phải, từ trên xuống dưới
    for y in range(1, img_height + 1):
        for x in range(1, img_width + 1):
            # Tạo ma trận con (region of interest) gồm các điểm ảnh xung quanh 1 điểm ảnh trung tâm  
            ROI = gray_img[y - 1: y + 2, x - 1: x + 2]
            # Thực hiện phép nhân tích chập (Convolution)
            Gx = (ROI * Sobel_x ).sum()
            Gy = (ROI * Sobel_y ).sum()
            Gradient = abs(Gx) + abs(Gy)
            # Nếu gradient nhỏ hơn threshold thì pixel thuộc background
            if (Gradient <= threshold):
                EdgeDetectedImage[y - 1, x- 1, :] = 0
            # Nếu gradient lớn hơn threshold thì pixel nằm trên edge
            else:
                EdgeDetectedImage[y - 1, x- 1, :] = 255
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

    EdgeDetectedImg = EdgeDetectionForGrayImage(img, nguong)

    # Hiển thị ảnh dùng thư viện OpenCV
    cv2.imshow('Anh mau RGB goc co gai Lena', img)
    cv2.imshow('Nhan dang bien anh xam Luminance bang pp Sobel nguong {}'.format(nguong), EdgeDetectedImg)

    # Bấm phím bất kỳ để đóng cửa sổ hiện thị ảnh
    cv2.waitKey(0)

    # Giải phóng bộ nhớ đã cấp phát cho các cửa sổ
    cv2.destroyAllWindows()






