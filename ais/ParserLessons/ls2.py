import requests
from bs4 import BeautifulSoup

url = "https://auto.drom.ru/audi/"

headers = {
    "Accept": "*/*",
    "User-Agent":"Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:107.0) Gecko/20100101 Firefox/107.0"
}

req = requests.get(url, headers=headers)
src = req.text
soup = BeautifulSoup(src, "lxml")

with open("index.html","w") as file:
    file.write(src)