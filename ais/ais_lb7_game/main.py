import sys

def check_line(the_word, len):
    is_win = 0 # 0 - nobody win, 1 - firts plr(O) win, 2 - (X) win
    if(the_word == "O" * len):
        is_win = 1
    if (the_word == "X" * len):
        is_win = 2
    return(is_win)


loop = True # main loop

width = height = 3
#height = 6
mas = [0] * height
for i in range(height):
    mas[i] = ['#'] * width
print("X" * 6)
turn = 1 # O start the game
is_found_winner = False
while loop: # the main loop of game


    # out the field to console
    for i in range(height + 1):
        for j in range(width + 1):
            if (i == 0):
                print(j, end='')
            elif (j == 0):
                print(i, end='')
            else:
                print(mas[i - 1][j - 1], end='')
        print()
    if(turn == -1):
        print("Ход: O")
    else:
        print("Ход: X")
    # end of field out

    # input the coordinates and draw X or O
    succes_input = False
    while succes_input == False:
        input_ = input()
        if (input_ == "exit"):
            loop = False
        else:
            x, y = map(int, input_.split())
            if turn == -1:
                # check for drawen X or O
                if (mas[x - 1][y - 1] == "O" or mas[x - 1][y - 1] == "X"):
                    print("Это поле уже занято, попытайся еще")
                else:
                    mas[x - 1][y - 1] = "O"
                    turn *= -1
                    succes_input = True
            else:
                if (mas[x - 1][y - 1] == "O" or mas[x - 1][y - 1] == "X"):
                    print("Это поле уже занято, попытайся еще")
                else:
                    mas[x - 1][y - 1] = "X"
                    turn *= -1
                    succes_input = True
    # input end

    #check for the winner
    if (is_found_winner == False): # chk verticals
        i = 0
        j = 0
        while i < width:
            chk_str = ""
            while j < width:
                chk_str += mas[i][j]
                j+=1
            num_chk = check_line(chk_str, width)
            i += 1
            if(num_chk != 0):
                is_found_winner = true
                print("Игра закончена!")
                print("Выиграл игрок " + str(num_chk))
    if (is_found_winner == False): # chk horizontals
        i = 0
        j = 0
        while i < width:
            chk_str = ""
            while j < width:
                chk_str += mas[j][i]
                j += 1
            num_chk = check_line(chk_str, width)
            i += 1
            if (num_chk != 0):
                is_found_winner = True
                print("Игра закончена!")
                print("Выиграл игрок " + str(num_chk))
    if (is_found_winner == False): # check for the diagonals
        i = 0
        j = 0
        chk_str = ""
        chk_str2 = ""
        while i < width:
            chk_str += mas[i][j]
            chk_str2 += mas[width - 1 - i][width - 1 -j]
            i+=1
            j += 1
        num_chk = check_line(chk_str, width)
        if (num_chk != 0):
            is_found_winner = True
            print("Игра закончена!")
            print("Выиграл игрок " + str(num_chk))
        num_chk = check_line(chk_str2, width)
        if (num_chk != 0):
            is_found_winner = True
            print("Игра закончена!")
            print("Выиграл игрок " + str(num_chk))
    else:
        loop = False
        print("Игра закончена")
    #end check for the winner