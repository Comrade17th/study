import requests
from bs4 import BeautifulSoup

url = "https://i.rts-tender.ru/main/auction/Trade/Search.aspx"

headers = {
    "Accept": "*/*",
    "User-Agent":"Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:107.0) Gecko/20100101 Firefox/107.0"
}

req = requests.get(url, headers=headers)
src = req.text

soup = BeautifulSoup(src, "lxml")
#res = soup.find_all("tr", attrs={"role": "row"})
res = soup.find_all("tr")
print(len(res))
for item in res:
    print(item.text)


with open("indexNastya.html","w", encoding="utf-8") as file:
   file.write(src)