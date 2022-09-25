
f = open('key.txt','r')
key = int(*f)
#print(key)
text = ("Съешь же ещё этих мягких французских булок, да выпей чаю.").upper()
res = ""
alphabet = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ"
key = key % len(alphabet)
for i in text: # coding text
    symbol = alphabet.find(i)
    new_symbol = symbol + key
    if i in alphabet:
        res += alphabet[new_symbol%len(alphabet)]
    else:
        res += i

isLoop = True
res_ =""
tries = 1
while(isLoop):
    choice = int(input("Ключ: "))
    if(choice % len(alphabet) == key):
        print("Угадал, молодец!")
        for i in res: # coding text
            symbol = alphabet.find(i)
            new_symbol = symbol - key
            if i in alphabet:
                res_ += alphabet[new_symbol%len(alphabet)]
            else:
                res_ += i
        print(res_)
        print("Попыток:", tries)
        isLoop = False
    else:
        print("Попробуй еще разок")
        tries +=1