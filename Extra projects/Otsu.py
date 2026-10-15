'__________________________________!!!Viết hàm tìm ngưỡng tối ưu!!!_______________________________'
def OptimizeThreshold(imgPIL, his):
    VarianceB_prev = 0
    global_mean = 0
    P1 = P2 = P3 = 0
    mk1 = mk2 = mk3 = 0
    VarianceG = (int)
    for i in range(256):
        global_mean += i*his[i]
        VarianceG = ((i - global_mean)^2)*his[i]
    for k2 in range(2,256):
        for k1 in range(1,k2):
            for i in range(k1):
                P1 += his[i]
                mk1 += i*his[i]
            m1 = mk1/P1
            for i in range (k1+1, k2):
                P2 += his[i]
                mk2 += i*his[i]
            m2 = mk2/P2
            for i in range (k2,256):
                P3 += his[i]
                mk3 += i*his[i]
            m3 = mk3/P3
            if (VarianceB > VarianceB_prev):
                VarianceB = P1*(m1 - global_mean)^2 + P2*(m2 - global_mean)^2 + P3*(m3 - global_mean)^2
                VarianceB_prev = VarianceB
                k1_optimized = k1
                k2_optimized = k2
    eta = VarianceB/VarianceG
    print("separability measurement", eta)
    return k1_optimized, k2_optimized


'_____________________________________________________________________________________'
his = TinhHistogramXam(imgPIL)
k1, k2 = OptimizeThreshold(imgPIL, his)
print("Các ngưỡng tối ưu là {}, {}".format(k1, k2))