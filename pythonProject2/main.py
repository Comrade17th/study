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
    # add_clr_x = 1545 coords of dots to test color
    # add_clr_y = 875
    DX = 5 # the width and of square to test
    DY = 5 # and the height
    add_test = dt.dot(1545, 875)
    #PAWN_UPG_DOTS[]
    test = ADD_PAWN_DOT
    test = PAWN_UPG_DOTS[0]

    img = create_screenshot()
    (minb, ming, minr) = img[test.y, test.x]
    (maxb, maxg, maxr) = img[test.y, test.x]
    for i in range(test.x, test.x + DX):
        for j in range(test.y, test.y + DY):
            (b, g, r) = img[j, i]
            if (b < minb): minb = b
            if (g < ming): ming = g
            if (r < minb): minr = r
            if (b > maxb): maxb = b
            if (g > maxb): maxg = g
            if (r > maxr): maxr = r
            print("Красный: {}, Зелёный: {}, Синий: {} [{};{}] is_grey: {}".format(r, g, b, i, j, is_px_grey(img[j,i])))
    print("min({} {} {}) max({} {} {})".format(minb, ming, minr, maxb, maxg, maxr))

BLUE = "b"
WHITE = "w"
GREEN = "g"
def printc(msg,color):
    if (color == "w"): print("\033[37m {}".format(msg))
    if (color == "b"): print("\033[34m {}".format(msg))
    if (color == "g"): print("\033[32m {}".format(msg))
# the block of consts

# min(253 177 40) max(255 177 55) yellow
# min(186 186 186) max(193 186 193) grey
# 0_upg_button x1370y976 center of the button

THE_CENTER_X = 1600 # for 1920x1080 display, if game total in right place of display

FIRST_UPG_BTN_X = 1370
FIRST_UPG_BTN_Y = 976

ADD_PAWN_BTN_X = 1605
ADD_PAWN_BTN_Y = 890

CLICK_CIRCLE_RADIUS = 16  # square side 32px to rand clic on with center in XY
GREY_IDEAL = 5 # the maximum differ of any clr channel in pixel, to mark it's as a grey color pixel
BLUE_IDEAL = 5 # the same for blue, jast for blue and red channels
YELLOW_IDEAL = 5

CHECK_ADD_DOT = dt.dot(1545, 875)

IS_COOP_WIN_DOT = dt.dot(1500,500) # have to check for blue color, if the coop game is winned
CONTINUE_DOT = dt.dot(1600,990) # the button continue (rus продолжить)
CHAPTER_1_DOT = dt.dot(1600,420) # the button of chapter 1
FLOOR_1_PLAY_DOT = dt.dot(1600, 680) # play button for floor 1
START_FLOOR_RANDOM = dt.dot(1600, 640) # button to start game with random player
# the end of the consts
def clc():
    print("\n" * 100)

# sleep to write less symbols in code
def slp(time):
    t.sleep(time)
# def rand_click(int x, int y)

def get_coord():
    print(pag.position())
    t.sleep(0.5)
    clc()


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
            if(abs(int(arr[i]) - int(arr[j])) > max_differ):
                max_differ = int(arr[i]) - int(arr[j])
    if(max_differ > 5):
        result = False
    return result

# the px is yellow if red channel more than +-250
def is_px_yellow(arr):
    dt = YELLOW_IDEAL
    result = False
    if (
            int(arr[0]) < 255 + dt and
            int(arr[0]) > 245 - dt):
        result = True
    return result

# the coop is win if bgr color  bgr > (239 - dt, doesn't matter,39 - dt)
# and bgr < (239 + dt,doesn't matter,39 + dt)
# dt is BLUE_IDEAL
def is_coop_win(arr):
    dt = BLUE_IDEAL
    result = False
    if(
    int(arr[2]) < 239 + dt and
    int(arr[2]) > 239 - dt and
    int(arr[0]) < 39 + dt and
    int(arr[0]) > 39 - dt):
        result = True
    return result

# do this function if the coop is winned
# 3 times press continue button
def end_coop():
    click_dot(CONTINUE_DOT)
    slp(2)
    click_dot(CONTINUE_DOT)
    slp(2)
    # befor 3rd click, have to check, is ADS offered, because
    # there is different coords of buttons to continue
    click_dot(CONTINUE_DOT)
    slp(2)

def scrool_up_max_coop():
    pag.scroll(100, 120, 120)
    slp(1)
    pag.scroll(100, 120, 120)
    slp(1)
    pag.scroll(100, 120, 120)

# start the coop match on 1st floor with random player
# have to be in coop layout
def start_coop_floor1_rnd():
    scrool_up_max_coop()
    slp(2)
    click_dot(CHAPTER_1_DOT)
    slp(2)
    click_dot(FLOOR_1_PLAY_DOT)
    slp(2)
    click_dot(START_FLOOR_RANDOM)
    slp(2)


# if bot clicked all buttons to start the game
# it checks is the game found and started by
# checking is the add_button is yellow color
#
def wait_untill_game_started():
    loop = True
    while(loop):
        slp(1)
        img = create_screenshot()
        arr = img[CHECK_ADD_DOT.y, CHECK_ADD_DOT.x]

        if(is_px_yellow(img[CHECK_ADD_DOT.y, CHECK_ADD_DOT.x])): # checking  (255,178,53)
            loop = False
            printc("The game has found!", WHITE)
        else:
            printc("Waiting for found...", WHITE)


# spaming pawns to the field until there 15 of them
def spam_add_pawns():
    pawns_count = 0 # counting the pawns dropped to playing field
    loop = True
    while(loop == True):
        slp(1)
        #printc("Start_loop", WHITE)
        img = create_screenshot()
        if (is_px_yellow(img[CHECK_ADD_DOT.y, CHECK_ADD_DOT.x])):
            click_dot(ADD_PAWN_DOT)
            pawns_count +=1
            printc("Added pawn {}/{}".format(pawns_count, 15), WHITE)
        #else:
        #   arr = img[CHECK_ADD_DOT.y, CHECK_ADD_DOT.x]
        #   printc("Dot not yellow ({},{},{})".format(arr[0], arr[1], arr[2]), BLUE)
        if (pawns_count == 15):
            printc("The field is full", WHITE)
            loop = False
        #printc("End_loop",WHITE)

# each 10 sec tries to upgrade all pawns in total of 2 mins, 120 sec, 12 tries to upg
def spam_upg_pawns():
    for i in range(0, 7):
        slp(15)
        for j in range(0,5): # running throw all upg buttons
            click_dot(PAWN_UPG_DOTS[j])
        printc("upg loop {}/{}".format(i, 7), WHITE)


def wait_untill_coop_game_ended():
    loop = True
    while(loop):
        slp(1)
        img = create_screenshot()
        if (is_coop_win(img[IS_COOP_WIN_DOT.y, IS_COOP_WIN_DOT.x])):
            loop = False

PAWN_UPG_DOTS = init_upg_dots()     # 5 dots to upgrade pawns
ADD_PAWN_DOT = dt.dot(ADD_PAWN_BTN_X, ADD_PAWN_BTN_Y)   # initialize the dot to add pawns

def main_farm():
    loop = True
    mathes = 50
    i = 0
    while(loop):
        # start the game
        printc("{}".format("We start the game!"), GREEN)
        start_coop_floor1_rnd()
        printc("{}".format("start_done! waiting for game..."), GREEN)
        # check is the game started in loop with checks
        wait_untill_game_started()
        printc("{}".format("the_game_started!"), GREEN)
        #slp(10)
        # playing
        spam_add_pawns()
        printc("{}".format("All pawns added!"), GREEN)
        spam_upg_pawns()
        printc("".format("All pawns upgraded! Waiting for the end"), GREEN)
        wait_untill_coop_game_ended()
        printc("{}".format("The game ended!"), GREEN)
        slp(3)
        #ending the game
        end_coop()
        print("\033[34m {}".format("Getting out!"))
        slp(1)
        i += 1
        if(i >= mathes):
            loop = False

def test_functions():
    slp(3)
    start_coop_floor1_rnd()

if __name__ == '__main__':
    slp(3)
    #spam_add_pawns()
    main_farm()
    #test_functions()
    #img = create_screenshot()

# to do list
# avoiding ads to watch after game end
# avoiding msg after game out


# FURTHER FEATURES
# wisely upg
# caclucalting mana
# calculating floor
# uniting pawns (understanding which pawn is it)
# upg and uniting priority


# the main API

# pvp features

# auto watching ads