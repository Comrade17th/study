import requests
import json
import pandas as pd
Headers = {
    "Accept": "*/*",
    "User-Agent":"Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:107.0) Gecko/20100101 Firefox/107.0"
}
payload = {
    "rows": 10,
    "page": 1
}

# делаем гет запрос на json файл по адресу в network headers Request URL

res = requests.get('https://i.rts-tender.ru/main/auction/Trade/Search.aspx?jqGridID=BaseMainContent_MainContent_jqgTrade&auto_Keyword=&auto_UseTradeName=true&auto_UseLotName=true&auto_UseOrganizerInn=false&auto_UseSellerName=false&auto_UseOrganizerName=false&auto_Number=&auto_OrganizerInnName=&auto_TradeNameOrLotName=&manual_Locations=null&manual_ProcedureTypes=null&manual_Regions=null&manual_TradeLotStates=0%2C2%2C3%2C5%2C6%2C7%2C8%2C9%2C10%2C11%2C12%2C14%2C15%2C18%2C19%2C20%2C21%2C22%2C23%2C25%2C26%2C27%2C28%2C29%2C30%2C31%2C32%2C33&manual_ProcedureSubTypeNames=null&auto_StartPriceMin=&auto_StartPriceMax=&auto_PublicationDate.From=17.12.2021&auto_PublicationDate.To=17.12.2022&auto_ApplicationStartDate.From=&auto_ApplicationStartDate.To=&auto_ApplicationEndDate.From=&auto_ApplicationEndDate.To=&auto_AuctionDate.From=&auto_AuctionDate.To=&auto_AuctionVariant=-1&nd=1671308316296&rows=10&page=1&sidx=&sord=asc', data=json.dumps(payload), headers=Headers)

result = res.json()

for i in range (len(result['rows'])): # итерирование по строкам
    print(i)
    print(result['rows'][i]['cell'])

for i in range (len(result['rows'][0]['cell'])): #
    print(i)
    print(result['rows'][0]['cell'][i]) # итерирование по столбцам (ячейкам)
