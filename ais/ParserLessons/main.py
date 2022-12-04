from bs4 import  BeautifulSoup

with open("blank/index.html", encoding='utf-8') as file:
    src = file.read();
#print(src)

soup = BeautifulSoup(src, "lxml")
title = soup.title
#print(title)
#print(title.text)

#page_h1 = soup.find("h1")
#print(page_h1)
#page_all_h1 = soup.find_all("h1")
#print(page_all_h1)

page_all_h1 = soup.find_all("h1")
for item in page_all_h1:
    print(item.text)

user_city = soup.find("div", class_ = "user__city")
user_posts = soup.find_all("div", class_ = "post__title")
for item in user_posts:
    print(item.text.strip())