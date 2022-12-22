import requests
import json
from bs4 import  BeautifulSoup
import pandas as pd
def get_result():
    Headers = {
        "Accept": "*/*",
        "User-Agent": "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:107.0) Gecko/20100101 Firefox/107.0"
    }
    payload = {
        "rows": 10,
        "page": 2
    }
    # делаем гет запрос на json файл по адресу в network headers Request URL
    res = requests.get(
        'https://i.rts-tender.ru/main/auction/Trade/Search.aspx?jqGridID=BaseMainContent_MainContent_jqgTrade&auto_Keyword=&auto_UseTradeName=true&auto_UseLotName=true&auto_UseOrganizerInn=false&auto_UseSellerName=false&auto_UseOrganizerName=false&auto_Number=&auto_OrganizerInnName=&auto_TradeNameOrLotName=&manual_Locations=null&manual_ProcedureTypes=null&manual_Regions=null&manual_TradeLotStates=0%2C2%2C3%2C5%2C6%2C7%2C8%2C9%2C10%2C11%2C12%2C14%2C15%2C18%2C19%2C20%2C21%2C22%2C23%2C25%2C26%2C27%2C28%2C29%2C30%2C31%2C32%2C33&manual_ProcedureSubTypeNames=null&auto_StartPriceMin=&auto_StartPriceMax=&auto_PublicationDate.From=17.12.2021&auto_PublicationDate.To=17.12.2022&auto_ApplicationStartDate.From=&auto_ApplicationStartDate.To=&auto_ApplicationEndDate.From=&auto_ApplicationEndDate.To=&auto_AuctionDate.From=&auto_AuctionDate.To=&auto_AuctionVariant=-1&nd=1671308316296&rows=10&page=1&sidx=&sord=asc',
        data=json.dumps(payload), headers=Headers)
    result = res.json()
    return result

def clear_soup(input):
    soup =  BeautifulSoup(input, "lxml")
    return soup.text.strip()

def get_header():
    header = ["Номер",
             "Процедура",
             "Лот",
             "Тип",
             "Статус",
             "Организация",
             "Цена",
             "Региона",
             "Дата начала",
             "Дата окончания"]
    return header

def row_to_cort(row):
    id = row[3]
    proc_name = row[4]
    lot_name = row[5]
    type = clear_soup(row[6])
    status = clear_soup(row[7])
    org = row[8]
    price = clear_soup(row[10])
    region = clear_soup(row[11])
    date1 = row[12]
    date2 = row[13]

    cort = (
        id,proc_name,lot_name,type,status, org, price, region, date1, date2
    )
    return cort

def get_data(result):
    data = []
    for i in range(len(result['rows'])):  # итерирование по строкам
        #print(i)
        #print(result['rows'][i]['cell'])
        cort = ()
        #for j in range(len(result['rows'][i]['cell'])):  #
        data.append(row_to_cort(result['rows'][i]['cell']))
    return data


if __name__ == "__main__":
   # data = result_to_data(get_result())
    #for item in data:
    #print(item)
    pass

    #result = get_result()
    #for i in range(len(result['rows'])):  # итерирование по строкам
    #    print(i)
    #    print(result['rows'][i]['cell'])

    #for i in range(len(result['rows'][0]['cell'])):  #
    #    print(i)
    #    print(result['rows'][0]['cell'][i])  # итерирование по столбцам (ячейкам)