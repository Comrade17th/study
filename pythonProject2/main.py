# This is a sample Python script.
import numpy
import cv2
import pyautogui as pag
import time as t
import  dot_class as dt
import random as rnd

# interesting only for devs, prints the rgb touple of pixels in the square
# and find the min and max of each RGB collor
def dev_test_color(): #
    add_clr_x = 1545
    add_clr_y = 875
    img = create_screenshot()
    (minb, ming, minr) = img[add_clr_y, add_clr_x]
    (maxb, maxg, maxr) = img[add_clr_y, add_clr_x]
    for i in range(1545, 1550):
        for j in range(875, 880):
            (b, g, r) = img[j, i]
            if (b < minb): minb = b
            if (g < ming): ming = g
            if (r < minb): minr = r
            if (b > maxb): maxb = b
            if (g > maxb): maxg = g
            if (r > maxr): maxr = r
            print("Красный: {}, Зелёный: {}, Синий: {} [{};{}] is_grey: {}".format(r, g, b, i, j, is_px_grey(img[j,i])))
    print("min({} {} {}) max({} {} {})".format(minb, ming, minr, maxb, maxg, maxr))


# min(253 177 40) max(255 177 55) yellow
# min(186 186 186) max(193 186 193) grey
# 0_upg_button x1370y976 center of the button
FIRST_UPG_BTN_X = 1370
FIRST_UPG_BTN_Y = 976

ADD_PAWN_BTN_X = 1605
ADD_PAWN_BTN_Y = 890

CLICK_CIRCLE_RADIUS = 16  # square side 32px to rand clic on with center in XY
GREY_IDEAL = 5 # the maximum differ of any clr channel in pixel, to mark it's as a grey color pixel

def clc():
    print("\n" * 100)

# def rand_click(int x, int y)

def get_coord():
    print(pag.position())
    t.sleep(0.5)
    clc()

def click_const():
    pag.click(1646, 735, 1, 1, "left")

# initialize 5 dots of the upgrade buttons
# the difference between 2 dots is 90px
# dots are centers of the buttons
def init_upg_dots():
    pawn_upgrade_dots = []
    dt1 = dt.dot(FIRST_UPG_BTN_X + 90 * 0, FIRST_UPG_BTN_Y)
    dt2 = dt.dot(FIRST_UPG_BTN_X + 90 * 1, FIRST_UPG_BTN_Y)
    dt3 = dt.dot(FIRST_UPG_BTN_X + 90 * 2, FIRST_UPG_BTN_Y)
    dt4 = dt.dot(FIRST_UPG_BTN_X + 90 * 3, FIRST_UPG_BTN_Y)
    dt5 = dt.dot(FIRST_UPG_BTN_X + 90 * 4, FIRST_UPG_BTN_Y)
    pawn_upgrade_dots.append(dt1)
    pawn_upgrade_dots.append(dt2)
    pawn_upgrade_dots.append(dt3)
    pawn_upgrade_dots.append(dt4)
    pawn_upgrade_dots.append(dt5)
    return pawn_upgrade_dots

# click inside square 32X32px around the dot
def click_dot(dot):
    pag.click(dot.x + rnd.randint(-CLICK_CIRCLE_RADIUS, CLICK_CIRCLE_RADIUS),
              dot.y + rnd.randint(-CLICK_CIRCLE_RADIUS, CLICK_CIRCLE_RADIUS),
              1, 1, "left")

#   return cv_img to work, (possible to create scr file, commended)
def create_screenshot():
    tmp = pag.screenshot()
    #   print(type(tmp)) #testing to convert to cv2 img
    cv_img = numpy.array(tmp)
    return cv_img
    #   cv2.imshow('ig', cv_img) # also tasting does it eaten by cv2
    #   cv2.waitKey(0)
    #   tmp.save("main.png") # trying to safe scrns to file, but soon it goona break the drive

def is_px_grey(arr):
    result = True
    max_differ = 0 # the max differ between any 2 clr channel
    for i in range(0, 3):
        for j in range(i + 1, 3):
            if(abs(arr[i] - arr[j]) > max_differ):
                max_differ = arr[i] - arr[j]
    if(max_differ > 5):
        result = False
    return result

if __name__ == '__main__':
    PAWN_UPG_DOTS = init_upg_dots()     # 5 dots to upgrade pawns
    ADD_PAWN_DOT = dt.dot(ADD_PAWN_BTN_X, ADD_PAWN_BTN_Y)   # initialize the dot to add pawns

    img = create_screenshot()
    print(is_px_grey(img[0,0]))

    # t.sleep(3)
    # click_dot(PAWN_UPG_DOTS[0])
    # t.sleep(3)
    # click_dot(PAWN_UPG_DOTS[4])


# See PyCharm help at https://www.jetbrains.com/help/pycharm/
