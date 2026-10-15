import cv2                  # Sử dụng thư viện xử lý ảnh OpenCV
import numpy as np          # Thư viện toán học, đặc biệt là các tính toán ma trận
from skimage.exposure import rescale_intensity

# Khai báo đường dẫn file hình
filehinh = r'C:\Users\DELL\Pictures\Screenshots\lenu.jpg'
# r'string' means raw string. With it, Python can interpret '\' as a literal backslash. 

# Đọc ảnh màu dùng thư viện OpenCV
img = cv2.imread(filehinh,1)


'_________________________________________________Hàm tính tích chập_________________________________________________________'
def convolve(img, kernel):    
    # Lấy kích thước ảnh và mask 
    img_height, img_width = img.shape[:2]
    kernel_height, kernel_width = kernel.shape[:2]
    # Tạo ma trận để lưu kết quả tích chập
    output = np.zeros((img_height, img_width),dtype = "float32")
    # Tính toán kích thước đường viền, // là phép chia lấy phần nguyên
    pad = (kernel_width - 1) // 2
    # Phương thức copyMakeBorder dùng để tạo phần viền xung quanh hình
    # Parameters: (source, top, bottom, left, right, borderType, value)
    # borderType chọn cv2.BORDER_REPLICATE để lặp lại giá trị trước
    # Lưu ý: phương thức copyMakeBorder xuất ra kết quả là một ma trận 3 chiều bất kế input đầu vào là gì
    img = cv2.copyMakeBorder(img, pad, pad, pad, pad, cv2.BORDER_REPLICATE)

    # Dùng 2 vòng lặp for để quét từng điểm ảnh từ trái sang phải, từ trên xuống dưới
    for y in np.arange(pad, img_height + pad):
        for x in np.arange(pad, img_width + pad):
            # Tạo ma trận con (region of interest) gồm các điểm ảnh xung quanh 1 điểm ảnh trung tâm  
            ROI = img[y - pad: y + pad + 1, x - pad: x + pad + 1]
            # Thực hiện phép nhân tích chập (Convolution)
            val = (ROI * kernel).sum()
            # Gán giá trị tích chập vào 1 ảnh mới
            
            output[y - pad, x - pad] = val
    
    
    # scale lại các giá trị trong ma trận output bằng hàm rescale_intensity
    # Parameters: (image, in_range='image', out_range='dtype')
    # in_range: khoảng giá trị của ma trận đầu vào, mặc định là min max của image
    # out_range: khoảng giá trị của ma trận đầu ra, mặc định là khoảng giá trị của kiểu dữ liệu được chọn
    output = rescale_intensity(output, in_range=(0, 255), out_range = (0, 255))
    output = output.astype("uint8")
	# Trả kết quả đã tính
    return output
'___________________________________________________________________________________________________________________________'

'___________________________________________________________Hàm làm nét ảnh____________________________________________________'
def ColorImageSharpening(img,mask_number):
    # Tạo mask để thực hiện tích chập
    Sharpen = np.array([[0, -1, 0],
                        [-1, 5, -1],
                        [0, -1, 0]])
    
    Sharpen_diagonal = np.array([[-1, -1, -1],
                                [-1, 9, -1],
                                [-1, -1, -1]])
    if mask_number == 0:
        mask = Sharpen
    elif mask_number == 1:
        mask = Sharpen_diagonal

    height, width = img.shape[:2]
    Sharpened_img = np.zeros((height, width, 3), np.uint8)
    Sharpened_img [:,:,2] = convolve(img[:,:,2], mask)
    Sharpened_img [:,:,1] = convolve(img[:,:,1], mask)
    Sharpened_img [:,:,0] = convolve(img[:,:,0], mask)
            
    # Trả về hình đã làm nét
    return Sharpened_img

'_____________________________________________________________________________________'


while 1:
    print("0: mask chỉ xét 4 điểm ảnh trên, dưới, trái, phải\n1: mask xét cả 8 điểm ảnh xung quanh ")
    mask_number = int(input("Chọn mask: "))
    if mask_number > 1:
        print("Vui lòng nhập lại:\n")
        continue

    Sharpened_img = ColorImageSharpening(img, mask_number)

    # Hiển thị ảnh dùng thư viện OpenCV
    cv2.imshow('Anh mau RGB goc co gai Lena', img)
    cv2.imshow('Hinh da duoc lam net', Sharpened_img)

    # Bấm phím bất kỳ để đóng cửa sổ hiện thị ảnh
    cv2.waitKey(0)

    # Giải phóng bộ nhớ đã cấp phát cho các cửa sổ
    cv2.destroyAllWindows()






