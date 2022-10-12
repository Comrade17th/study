import sys
loop = True # main loop

width = 6
height = 3
mas = [0] * height
for i in range(height):
    mas[i] = ['#'] * width
print(mas)
turn = 1 # O start the game
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

    #end check for the winner