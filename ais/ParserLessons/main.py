from bs4 import  BeautifulSoup
import re
import requests
import text_split as ts
import csv
import pandas as pd
def read_csv_to_df():
    df_cars = pd.read_csv("data/audinew.csv", sep = ",")
    for row in df_cars:
        print(row)
    return df_cars

def write_to_csv_df(data):
    df = pd.DataFrame(data)
    # df.to_csv('parser.csv', index=False, header=False)
    df.to_csv(f"data/audinew.csv", index=False)

def write_to_csv_file(data):
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
             #"Пробег тыс.км.",
             "Цена",)
        )
    for cort1 in data:
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
                 cort1[8],)
                 #cort1[9],)
            )

def item_to_cort1(item):
    bull_title = item.find("span", attrs={"data-ftid": "bull_title"})
    cort1 = ts.mark_model_year(bull_title.text)
    bull_info = item.find_all("span", attrs={"data-ftid": "bull_description-item"})
    bull_price = item.find("span", attrs={"data-ftid": "bull_price"}).text
    bull_price = ts.clear_price(bull_price)
    cort1 += ts.value_hp(bull_info[0].text)
    cort = ("","","","")
    if ( len(bull_info) > 3):
        cort = (
            ts.get_clear(bull_info[1].text),
            ts.get_clear(bull_info[2].text),
            ts.get_clear(bull_info[3].text),
            #ts.get_clear(bull_info[4].text),
            bull_price
        )
    cort1 += cort
    return cort1

def  write_res(res):
    data = []

    for item in res:

        cort1 = item_to_cort1(item)
        #print(cort1)
        data.append(cort1)

    print("page_ended")
    return data

def url_to_res(URL):
    headers = {
        "Accept": "*/*",
        "User-Agent": "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:107.0) Gecko/20100101 Firefox/107.0"
    }
    req = requests.get(URL, headers=headers)
    src = req.text
    soup = BeautifulSoup(src, "lxml")
    res = soup.find_all("a", attrs={"data-ftid": "bulls-list_bull"})
    return res
def get_data(count):
    URL = "https://auto.drom.ru/audi/all/page"
    data = []
    i = 1
    while(i < count):
        URL_tmp = URL + str(i)+"/"
        data += write_res(url_to_res(URL_tmp))
        i+=1
    write_to_csv_file(data)
    #write_to_csv_df(data)
    return data


if __name__ == "__main__":
    pass
    #get_data()
    #read_csv_to_df()

#with open("index.html") as file:
#    src = file.read();
#print(src)

#soup = BeautifulSoup(src, "lxml")
#res = soup.find_all("a", attrs={"data-ftid": "bulls-list_bull"})
#data = write_res(res)



    #print(item.text)