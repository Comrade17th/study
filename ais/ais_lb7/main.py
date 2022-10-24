import urllib
from googlesearch import search
from bs4 import BeautifulSoup

pages = []
c = 1

def new_request():
    return input("Введите поисковый запрос: ")

def zglv(url):
    page = urllib.request.urlopen(url)
    soap =  BeautifulSoup(page, "html.parser")
    return soap.title.text

def append_to_result(page, url, caption):
    result = [page, url, caption]
    pages.append(result)

for url in search(new_request(), stop=2):
    append_to_result(c, url, zglv(url))
    c+=1

print([pages])