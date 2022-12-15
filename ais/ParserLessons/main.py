from bs4 import  BeautifulSoup
import re
import text_split as ts
import csv

def  write_res(res):
    with open(f"data/audinew.csv", "w", newline='') as file:
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
             "Пробег тыс.км.",
             "Цена",)
        )
    for item in res:
        bull_title = item.find("span", attrs={"data-ftid": "bull_title"})
        cort1 = ts.mark_model_year(bull_title.text)
        bull_info = item.find_all("span", attrs={"data-ftid": "bull_description-item"})
        bull_price = item.find("span", attrs = {"data-ftid": "bull_price"}).text
        cort1 += ts.value_hp(bull_info[0].text)
        cort = (
            ts.get_clear(bull_info[1].text),
            ts.get_clear(bull_info[2].text),
            ts.get_clear(bull_info[3].text),
            ts.get_clear(bull_info[4].text)
        )
        cort1 += cort
        print(cort1)

        with open(f"data/audinew.csv", "a", newline='') as file:
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
                 cort1[8],
                 bull_price)
            )

with open("index.html") as file:
    src = file.read();
#print(src)

soup = BeautifulSoup(src, "lxml")
res = soup.find_all("a", attrs={"data-ftid": "bulls-list_bull"})
write_res(res)
    #print(item.text)