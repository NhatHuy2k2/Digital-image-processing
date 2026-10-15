import cv2                          # For images processing
import numpy as np                  # For mathematical matrices processing
import matplotlib.pyplot as plt     # For making plots, chars, etc
from math import sqrt
from rgbToGray import to_gray_average, to_gray_luminance, to_gray_lightness  # Gray-scaling methods

# Define filters
filter_x3 = np.array([[0, 1, 0],
                      [1, 1, 1], 
                      [0, 1, 0]])

filter_x5 = np.array([[0, 0, 1, 0, 0], 
                      [0, 1, 1, 1, 0],
                      [1, 1, 1, 1, 1], 
                      [0, 1, 1, 1, 0], 
                      [0, 0, 1, 0, 0]])

filter_x7 = np.array([[0, 0, 0, 1, 0, 0, 0], 
                      [0, 0, 1, 1, 1, 0, 0],
                      [0, 1, 1, 1, 1, 1, 0],
                      [1, 1, 1, 1, 1, 1, 1],
                      [0, 1, 1, 1, 1, 1, 0],
                      [0, 0, 1, 1, 1, 0, 0], 
                      [0, 0, 0, 1, 0, 0, 0]])

# Read image from file path
file_path =  r'C:\Users\DELL\Pictures\Screenshots\v.jpg'
original_img = np.intc(cv2.imread(file_path, cv2.IMREAD_COLOR))  # In form of Numpy array

# Original RGB image dimension
image_size = original_img.shape

# Gray-scale the image
gray_img_avg = to_gray_average(original_img, image_size)     # With Average Method
gray_img_lmn = to_gray_luminance(original_img, image_size)   # With Luminance Method
gray_img_lgh = to_gray_lightness(original_img, image_size)   # With Lightness Method


###================ Image padding ================### 
def imagePadding(gray_img, img_height, img_width, pad_size):
    # Define empty array to store image
    pad_img = np.zeros((img_height+pad_size*2, img_width+pad_size*2, 3)).astype('uint8')

    # Filled the empty image by 2D scanning - Scan by row
    for x in range(pad_size, img_width+pad_size, 1):
        for y in range(pad_size, img_height+pad_size, 1):
            pad_img[y, x, :] = gray_img[y-pad_size, x-pad_size, 0]

    # Return processed image
    return pad_img  

# pad_img = imagePadding(gray_img_avg, image_size[0], image_size[1], 2)     # Uncomment these lines to test the padding
# cv2.imshow("Padded image", pad_img)

# # Fluish memory when turn off
# cv2.waitKey(0)            # Wait until keyboard pressed
# cv2.destroyAllWindows()

###================ Image Dilation ================### 
def imageDilation(gray_img, img_height, img_width, filter):

    # Read filter size
    filter_size = filter.shape[0]

    # Define output image
    dilated_image = np.zeros((img_height, img_width, 3)).astype('uint8')

    # Define pad size
    pad_size = filter_size%2

    # Create pads for the original gray-scaled image
    pad_img = imagePadding(gray_img, img_height, img_width, pad_size)

    # Define list to store set of computed value
    templist = []

    # Start 2D scanning and convolving image
    for y in range(pad_size, img_height+pad_size, 1):
        for x in range(pad_size, img_width+pad_size, 1):

            # 2D scanning within the filer area
            for sub_y in range(y-pad_size, y+pad_size+1, 1):
                for sub_x in range(x-pad_size, x+pad_size+1, 1):
                    
                    # Combine the neighbor and the pixel itself with filter element
                        # The cases of 1 element
                    if(filter[y - sub_y + pad_size, x - sub_x + pad_size] == 1):
                        templist.append(filter[y - sub_y + pad_size, x - sub_x + pad_size] * pad_img[sub_y, sub_x, 0])

                        # The cases of 0 element
                    else:
                        continue

            # Find the maximum pixel value
            max_val = max(templist)

            # Add the value to the empty array
            dilated_image[y-pad_size, x-pad_size, :] = max_val

            # Clear the temporary list
            templist = []

    # Return image
    return dilated_image

###================ Image Erosion ================### 
def imageErosion(gray_img, img_height, img_width, filter):

    # Read filter size
    filter_size = filter.shape[0]

    # Define output image
    erosen_image = np.zeros((img_height, img_width, 3)).astype('uint8')

    # Define pad size
    pad_size = filter_size%2

    # Create pads for the original gray-scaled image
    pad_img = imagePadding(gray_img, img_height, img_width, pad_size)

    # Define list to store set of computed value
    templist = []

    # Start 2D scanning and convolving image
    for y in range(pad_size, img_height+pad_size, 1):
        for x in range(pad_size, img_width+pad_size, 1):

            # 2D scanning within the filer area
            for sub_y in range(y-pad_size, y+pad_size+1, 1):
                for sub_x in range(x-pad_size, x+pad_size+1, 1):
                    
                    # Combine the neighbor and the pixel itself with filter element
                        # The cases of 1 element
                    if(filter[y - sub_y + pad_size, x - sub_x + pad_size] == 1):
                        templist.append(filter[y - sub_y + pad_size, x - sub_x + pad_size] * pad_img[sub_y, sub_x, 0])

                        # The cases of 0 element
                    else:
                        continue

            # Find the maximum pixel value
            max_val = min(templist)

            # Add the value to the empty array
            erosen_image[y-pad_size, x-pad_size, :] = max_val

            # Clear the temporary list
            templist = []

    # Return image
    return erosen_image

###================ Image Morphological: Opening ================### 
def morphologicalOpenning(gray_im,  img_height, img_width, filter):
    
    # Conduct the erosion first
    erosen_img = imageErosion(gray_im,  img_height, img_width, filter)

    # Conduct the dilation next
    openning_img = imageDilation(erosen_img, img_height, img_width, filter)

    # Return image
    return openning_img

###================ Image Morphological: Closing ================### 
def morphologicalClosing(gray_im,  img_height, img_width, filter):
    
    # Conduct the dilation first
    dilated_img = imageDilation(gray_im,  img_height, img_width, filter)

    # Conduct the erosion next
    closing_img = imageErosion(dilated_img, img_height, img_width, filter)

    # Return image
    return closing_img

###================ Practical Test ================### 
# Create dilated image
dilated_img = imageDilation(gray_img_avg, image_size[0], image_size[1], filter_x5)
erosen_img = imageErosion(gray_img_avg, image_size[0], image_size[1], filter_x5)
opening_img = morphologicalOpenning(gray_img_avg, image_size[0], image_size[1], filter_x5)
closing_img = morphologicalClosing(gray_img_avg, image_size[0], image_size[1], filter_x5)

# Display Erosen Image and Original Image
cv2.imshow("Original image", gray_img_avg)
cv2.imshow("Dilated image", dilated_img)
cv2.imshow("Erosen image", erosen_img)
cv2.imshow("Openning image", opening_img)
cv2.imshow("Closing image", closing_img)

# Fluish memory when turn off
cv2.waitKey(0)            # Wait until keyboard pressed
cv2.destroyAllWindows()