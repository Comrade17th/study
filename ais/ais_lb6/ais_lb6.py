import requests
 
#Функция извлекает из html кода
#результаты поисковой выдачи гугла
#и возвращает список из словарей
#[{page: '', url: '', title: ''}, {page: '', url: '', title: ''}, …]
def parse_html(html, page=1):
    lst = []
    
    k = 0
    while True:
        i = html.find('<div class="r"', k)
        if i == -1: break
 
        x1 = i + 24
        x2 = html.find('"', x1)
        url = html[x1:x2]
 
        x1 = html.find('class="LC20lb"', x2) + 15
        x2 = html.find('</h3>', x1)
        title = html[x1:x2]
 
        lst.append({'page': page, 'url': url, 'title': title})
 
        k = i + 1
 
    return lst
 
import time

import requests
from bs4 import BeautifulSoup
from googlesearch import search


def get_title(url):
    while True:
        try:
            html_text = requests.get(url).text
            break
        except:
            time.sleep(2)
    soup = BeautifulSoup(html_text, 'html.parser')
    try:
        res = soup.find(name="title").text
    except:
        res = "No Title"

    return res


def search_html(query):
    arr = []
    for j in search(query):
        arr.append(j)
    return arr


def first():
    query = input("Введите фразу для поиска: ")
    arr = search_html(query)
    return arr


def second(arr):
    list = []
    for i in range(len(arr)):
        list.append({"page": i, "url": arr[i], "title": get_title(arr[i])})
    print(list)


if __name__ == '__main__':
    arr = first()
    second(arr)