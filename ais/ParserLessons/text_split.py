import  re

input = "Audi A6 allroad quattro, 2015"


#Audi A6, 2018
#2.0 л (150 л.с.),
#дизель,
#робот,
#передний,
#112 тыс. км

def clear_price(price):
    res = "";
    words = re.split("\xa0",price)
    for word in words:
        res += word
    return res

def get_clear(input):
    words = re.split(" |,", input)

    return words[0]

def value_hp(input):

    words = re.split(" |\(",input)
    if(len(words) >3):
        cort = (
            words[0],
            words[3]
        )
    else:
        cort = (
            words[0],
            "none"
        )
    return cort

def mark_model_year(input):
    words = re.split(" |,", input)
    model = ""
    for i in range(len(words)):
        if (i != 0 and i != len(words) - 1):
            model += " " + words[i];
    cort = (
         words[0], #mark
         model, #model
        words[-1] # year
    )
    return cort


crt = mark_model_year(input)
#print(mark_model_year(input))
input2 = "2.0 л (150 л.с.),"
crt += value_hp(input2)
#print(value_hp(input2))
#print(crt)