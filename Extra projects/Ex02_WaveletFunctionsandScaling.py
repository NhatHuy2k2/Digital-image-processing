# Import libraries and functions
import cv2                          # For images processing
import numpy as np                  # For mathematical matrices processing
import matplotlib.pyplot as plt     # For making plots, chars, etc
from math import sqrt               # For mathematic computation
from rgbToGray import to_gray_average, to_gray_luminance, to_gray_lightness  # Gray-scaling methods

# Read image from file path
file_path =  r'C:\Users\DELL\Pictures\Screenshots\lenu.jpg'
original_img = cv2.imread(file_path, cv2.IMREAD_COLOR)  # In form of Numpy array, convert for gray scaling

# Original RGB image dimension
image_size = original_img.shape

# Gray-scale the image
gray_img_avg = to_gray_average(original_img, image_size)     # With Average Method
gray_img_lmn = to_gray_luminance(original_img, image_size)   # With Luminance Method
gray_img_lgh = to_gray_lightness(original_img, image_size)   # With Lightness Method

#============ Data scaling array with chosen set point ============#
def dataScale(array_to_scale, scaled_max, scaled_min):
  scaled_array = ((array_to_scale-  np.min(array_to_scale)) /
                    (np.max(array_to_scale) - np.min(array_to_scale)))*(scaled_max - scaled_min) + scaled_min
  return np.uint8(scaled_array)

#============ Down sampling with Haar Transform ============#
def fastWaveletTransform(gray_img):

    # Define input image size
    image_width  = gray_img.shape[1]
    image_height = gray_img.shape[0]

    # Define storing matrices
    width_waveletvec_01  = np.zeros((image_height, int(image_width/2), 3)).astype('float32')           # Horizontal Haar transform (wavelet)
    height_waveletvec_01 = np.zeros((int(image_height/2), int(image_width/2), 3)).astype('float32')    # Wpsi D
    height_scalingvec_01 = np.zeros((int(image_height/2), int(image_width/2), 3)).astype('float32')    # Wpsi V

    width_scalevec_02    = np.zeros((image_height, int(image_width/2), 3)).astype('float32')          # Horizontal Haar transform (wavelet)
    height_waveletvec_02 = np.zeros((int(image_height/2), int(image_width/2), 3)).astype('float32')   # Wpsi H
    height_scalingvec_02 = np.zeros((int(image_height/2), int(image_width/2), 3)).astype('float32')   # Wphi (Scaled image)

    #======================== Stage number 1 ========================#
    # Init counter
    x = y = 0

    # Haar transform to downsample width
    while y <= image_width-1:
        while x <= image_height-2:
            # Haar transform and downsample by the factor of 2
            width_waveletvec_01[y, int(x/2), :] = (gray_img[y, x, 0].astype('float32')  - gray_img[y, x+1, 0].astype('float32'))/sqrt(2)

            # Update counter
            x += 2
        
        # Reset column and update row
        x=0
        y+=1

    # Stage number 1.1
    # Re-Init counter
    x = y = 0

    # Haar transform
    while x <= int(image_width/2)-1:
        while y <= image_height-2:
            # Haar transform and downsample by the factor of 2
            height_waveletvec_01[int(y/2), x, :] = (width_waveletvec_01[y, x, 0]  - width_waveletvec_01[y+1, x, 0])/sqrt(2);

            # Update counter
            y += 2
        
        # Reset row and update column
        y=0
        x+=1

    # Stage number 1.2
    # Re-Init counter
    x = y = 0

    # Haar transform
    while x <= int(image_width/2)-1:
        while y <= image_height-2:
            # Haar transform and downsample by the factor of 2
            height_scalingvec_01[int(y/2), x, :] = (width_waveletvec_01[y+1, x, 0] + width_waveletvec_01[y, x, 0])/sqrt(2);

            # Update counter
            y += 2
        
        # Reset row and update column
        y=0
        x+=1

    #======================== Stage number 2 ========================#
    # Re-Init counter
    x = y = 0

    # Haar transform to downsample width
    while y <= image_width-1:
        while x <= image_height-2:
            # Haar transform and downsample by the factor of 2
            width_scalevec_02[y, int(x/2), :] = (gray_img[y, x, 0].astype('float32')  + gray_img[y, x+1, 0].astype('float32'))/sqrt(2)

            # Update counter
            x += 2
        
        # Reset column and update row
        x=0
        y+=1

    # Stage number 2.1
    # Re-Init counter
    x = y = 0

    # Haar transform
    while x <= int(image_width/2)-1:
        while y <= image_height-2:
            # Haar transform and downsample by the factor of 2
            height_waveletvec_02[int(y/2), x, :] = (width_scalevec_02[y, x, 0]  - width_scalevec_02[y+1, x, 0])/sqrt(2);

            # Update counter
            y += 2
        
        # Reset row and update column
        y=0
        x+=1

    # Stage number 2.2
    # Re-Init counter
    x = y = 0

    # Haar transform
    while x <= int(image_width/2)-1:
        while y <= image_height-2:
            # Haar transform and downsample by the factor of 2
            height_scalingvec_02[int(y/2), x, :] = (width_scalevec_02[y+1, x, 0] + width_scalevec_02[y, x, 0])/sqrt(2);

            # Update counter
            y += 2
        
        # Reset row and update column
        y=0
        x+=1

    # Remap image to unsigned for digital images
    height_waveletvec_01 = dataScale(height_waveletvec_01, 255, 0)
    height_scalingvec_01 = dataScale(height_scalingvec_01, 255, 0)
    height_waveletvec_02 = dataScale(height_waveletvec_02, 255, 0)
    height_scalingvec_02 = dataScale(height_scalingvec_02, 255, 0)

    # Return results
    return height_waveletvec_01, height_scalingvec_01, height_waveletvec_02, height_scalingvec_02

# Wavelet transform on gray scaled images
wavelet_img_diagonal, wavelet_img_row, wavelet_img_column, scaled_img = fastWaveletTransform(gray_img_lgh)
wavelet_img_diagonal2, wavelet_img_row2, wavelet_img_column2, scaled_img2 = fastWaveletTransform(scaled_img)

# Combined decompositions
decompose_01 = np.concatenate((scaled_img2, wavelet_img_column2), axis=1)
decompose_02 = np.concatenate((wavelet_img_row2, wavelet_img_diagonal2), axis=1)
decompose_03 = np.concatenate((decompose_01, decompose_02), axis=0)
decompose_04 = np.concatenate((decompose_03, wavelet_img_column), axis=1)
decompose_05 = np.concatenate((wavelet_img_row, wavelet_img_diagonal), axis=1)

# Final result
decompose_res = np.concatenate((decompose_04, decompose_05), axis=0)

# Display the decomposed images
cv2.imshow("Decomposed Images", decompose_res)
cv2.imshow("Scaled image: 256x256", scaled_img)
cv2.imshow("Orgininal Images", original_img)
plt.imshow(decompose_res)

# Fluish memory when turn off
plt.show()
cv2.waitKey(0)            # Wait until keyboard pressed
cv2.destroyAllWindows()