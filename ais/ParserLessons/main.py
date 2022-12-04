from bs4 import  BeautifulSoup
import re
import text_split as ts
import csv

with open("index.html") as file:
    src = file.read();
#print(src)

soup = BeautifulSoup(src, "lxml")
title = soup.title
print(title)
print(title.text)

res = soup.find_all("a", attrs={"data-ftid": "bulls-list_bull"})
for item in res:

    bull_title = item.find("span", attrs={"data-ftid": "bull_title"})
    cort1 = ts.mark_model_year(bull_title.text)
    bull_info = item.find_all("span", attrs={"data-ftid": "bull_description-item"})
    cort1 += ts.value_hp(bull_info[0].text)
    cort = (
        ts.get_clear(bull_info[1].text),
        ts.get_clear(bull_info[2].text),
        ts.get_clear(bull_info[3].text),
        ts.get_clear(bull_info[4].text)
    )
    cort1 += cort
    print(cort1)
    with open(f"data/audinew.csv", "w") as file:
        writer = csv.writer(file)
        writer.writerow(
            ("Марка",
            "Модель",
            "Год выпуска",
            "Объем двигателя л.",
            "л.с.",
            "топливо",
            "КПП",
            "Привод",
            "Пробег тыс.км.",)
        )
    with open(f"data/audinew.csv", "a") as file:
        writer = csv.writer(file)
        writer.writerow(
            (cort1[0],
            cort1[1],
            cort1[2],
            cort1[3],
            cort1[4],
            cort1[5],
            cort1[6],
            cort1[7],
            cort1[8])
        )
    #print(item.text)