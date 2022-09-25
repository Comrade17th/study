
dictionary = {
    "кошка":"cat",
    "собака":"dog"
    }

out = True
while(out):
    print("1. Найти перевод")
    print("2. Добавить перевод")
    print("3. Вывести словарь")
    print("0. Выйти")
    choice = int(input())
    if(choice == 0):
        out = False
    elif(choice == 1):
        word = input("Введите слово для перевода: ")
        if word in dictionary:
            res = dictionary[word]
            print(res)
        else:
            print("Слово не найдено")
    elif(choice == 2):
        ru = input("Введите слово на русском языке: ")
        en = input("Введите слово на английском языке: ")
        dictionary[ru] = en
    elif(choice == 3):
        for ru, en in dictionary.items(): 
            print(ru, en)
        