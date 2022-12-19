from tkinter import *
from tkinter import ttk, filedialog
from tkinter.font import nametofont
import pandas as pd
import requests
import json


def parsed_new():
    tree.delete(*tree.get_children())
    # Прописываем инфу из network: header и payload
    Headers = {"accept": "application/json, text/plain, */*",
               "user-agent": "Freak show is the best"}
    payload = {
        "filters": {},
        "page": 1,
        "pageCount": "100",
        "sortBy": {}
    }

    # делаем пост запрос на json файл по адресу в network headers Request URL

    res = requests.post('https://api-open-nostroy.anonamis.ru/api/sro/list', data=json.dumps(payload), headers=Headers)

    result = res.json()
    spisok = result['data']['data']

    countpages = int(result['data']['countPages'])
    listall = []
    data1 = []
    data2 = []
    listall += spisok

    for i in range(countpages - 1):
        payload = {
            "filters": {},
            "page": i + 2,  # 2-4 страницы
            "pageCount": "100",
            "sortBy": {}
        }
        res = requests.post('https://api-open-nostroy.anonamis.ru/api/sro/list', data=json.dumps(payload),
                            headers=Headers)
        result = res.json()
        listall = listall + result['data']['data']

    for i in range(len(listall)):
        # data2.append(
        #     {'num': i, 'status': listall[i]['enabled'], 'reg_num': listall[i]['registration_number'],
        #      'full_name': listall[i]['full_description'],
        #      'address': listall[i]['place'], 'subject': listall[i]['region_name'],
        #      'fed_okr': listall[i]['federal_district']['title'], 'id': listall[i]['id']})
        data1.append(
            [i, listall[i]['enabled'], listall[i]['registration_number'],
             listall[i]['full_description'],
             listall[i]['place'], listall[i]['region_name'],
             listall[i]['federal_district']['title'], listall[i]['id']])

    for comp in data1:
        tree.insert("", 'end', values=comp)
    # добавляем список в датафрейм
    df = pd.DataFrame(data1)
    # df.to_csv('parser.csv', index=False, header=False)
    df.to_csv('parser.csv', index=False)
    mylist = pd.read_csv('parser.csv', sep=',')


def parsed_old():
    tree.delete(*tree.get_children())
    mylist = pd.read_csv('parser.csv', sep=',')
    data1 = []

    data1 = mylist.values.tolist()
    for comp in data1:
        tree.insert("", 'end', values=comp)
    # print(data1)


def parsed_filtered():
    tree.delete(*tree.get_children())
    mylist = pd.read_csv('parser.csv', sep=',')
    data1 = mylist.values.tolist()
    data2 = []
    data3 = []
    data4 = []
    data5 = []
    data6 = []
    data7 = []
    for i in range(len(data1)):  # статус
        if txt1.get() != '':
            if txt1.get() == 'False':
                if data1[i][1] == False:
                    data2.append(data1[i])
            elif txt1.get() == 'True':
                if data1[i][1] == True:
                    data2.append(data1[i])
        else:
            data2.append(data1[i])

    for i in range(len(data2)):  # рег номер
        if txt2.get() != '':  # рег номер
            if txt2.get() in str(data2[i][2]):
                data3.append(data2[i])
        else:
            data3.append(data2[i])

    # for i in range(len(data3)):
    #     if txt3.get() != '':  # название
    #         if data3[i][3] == txt3.get():
    #             data4.append(data3[i])
    #     else:
    #         data4.append(data3[i])

    for i in range(len(data3)):
        if txt3.get() != '':  # название
            if txt3.get() in str(data3[i][3]):
                data4.append(data3[i])
        else:
            data4.append(data3[i])

    for i in range(len(data4)):
        if txt4.get() != '':  # адрес
            if txt4.get() in str(data4[i][4]):
                data5.append(data4[i])
        else:
            data5.append(data4[i])

    for i in range(len(data5)):
        if txt5.get() != '':  # субъект
            if txt5.get() in str(data5[i][5]):
                data6.append(data5[i]
)
        else:
            data6.append(data5[i])

    for i in range(len(data6)):
        if txt6.get() != '':  # фо
            if txt6.get() in str(data6[i][6]):
                data7.append(data6[i])
        else:
            data7.append(data6[i])

    for comp in data7:
        tree.insert("", 'end', values=comp)
    print(data7)


def parsed_sro(num):
    def parsed_filtered():
        tree1.delete(*tree1.get_children())
        mylist = pd.read_csv('parser23.csv', sep=',')
        data1 = mylist.values.tolist()
        data2 = []
        data3 = []
        data4 = []
        data5 = []
        # data6 = []
        # data7 = []
        for i in range(len(data1)):  # статус
            if txt1.get() != '':
                if txt1.get() in str(data1[i][2]):
                    data2.append(data1[i])
            else:
                data2.append(data1[i])

        for i in range(len(data2)):  # рег номер
            if txt2.get() != '':  # рег номер
                if data2[i][3] == txt2.get():
                    data3.append(data2[i])
            else:
                data3.append(data2[i])


        for i in range(len(data3)):
            if txt3.get() != '':  # название
                if txt3.get() in str(data3[i][1]):
                    data4.append(data3[i])
            else:
                data4.append(data3[i])

        for i in range(len(data4)):
            if txt4.get() != '':  # инн
                if data4[i][6] == int(txt4.get()):
                    data5.append(data4[i])
            else:
                data5.append(data4[i])


        for comp in data5:
            tree1.insert("", 'end', values=comp)
        # print(data7)



    print('какая ты молодец')
    # parsed_new()
    #
    Headers = {"accept": "application/json, text/plain, */*",
               "user-agent": "Freak show is the best"}
    payload = {
        "filters": {},
        "page": 1,
        "pageCount": "100",
        "sortBy": {}
    }

    # делаем пост запрос на json файл по адресу в network headers Request URL

    res = requests.post(f'https://api-open-nostroy.anonamis.ru/api/sro/{num}/member/list', data=json.dumps(payload),
                        headers=Headers)

    result = res.json()
    spisok = result['data']['data']

    countpages = int(result['data']['countPages'])

    listall = []
    # data1 = []
    # data2 = []
    listall += spisok
    if countpages > 10:
        countpages = 10

    for i in range(countpages - 1):
        payload = {
            "filters": {},
            "page": i + 2,  # 2-10 страницы
            "pageCount": "100",
            "sortBy": {}
        }
        res = requests.post('https://api-open-nostroy.anonamis.ru/api/sro/85/member/list', data=json.dumps(payload),
                            headers=Headers)
        result = res.json()
        listall = listall + result['data']['data']

    def compensation_fund_fee_vv_contains(i):
        if listall[i].__contains__("compensation_fund_fee_vv") == True:
            return listall[i]['compensation_fund_fee_vv']
        else:
            return "не указано"

    def responsibility_level_vv_contains(i):
        if listall[i].__contains__("responsibility_level_vv") == True:
            return listall[i]['responsibility_level_vv']['cost']
        else:
            return "не указано"

    def compensation_fund_fee_odo_contains(i):
        if listall[i].__contains__("compensation_fund_fee_odo") == True:
            return listall[i]['compensation_fund_fee_odo']
        else:
            return "не указано"

    def responsibility_level_odo_contains(i):
        if listall[i].__contains__("responsibility_level_odo") == True:
            return listall[i]['responsibility_level_odo']['cost']
        else:
            return "не указано"

    data1 = []
    for i in range(len(listall)):
        data1.append(
            [i, listall[i]['full_description'], listall[i]['member_status']['title'],
             listall[i]['registration_number'],
listall[i]['registry_registration_date_time_string'], listall[i]['ogrnip'],
             listall[i]['inn'], compensation_fund_fee_vv_contains(i), responsibility_level_vv_contains(i),
             compensation_fund_fee_odo_contains(i), responsibility_level_odo_contains(i)])

    df = pd.DataFrame(data1)
    # df.to_csv('parser.csv', index=False, header=False)
    df.to_csv('parser23.csv', index=False)
    mylist = pd.read_csv('parser23.csv', sep=',')

    window1 = Tk()
    window1.geometry('1500x600')
    window1.title(f"Парсинг реестра членов СРО {num}")

    nametofont("TkHeadingFont").configure(family="Song", size=12)
    columns = "i", "full_description", "member_status", "registration_number", "registry_registration_date_time_string", "ogrnip", "inn", "compensation_fund_fee_vv", "responsibility_level_vv", "compensation_fund_fee_odo", "responsibility_level_odo"
    tree1 = ttk.Treeview(window1, columns=columns, show="headings")

    tree1.column("i", width=40)
    tree1.column("full_description", width=280)
    tree1.column("member_status", width=130)
    tree1.column("registration_number", width=70)
    tree1.column("registry_registration_date_time_string", width=100)
    tree1.column("ogrnip", width=125)
    tree1.column("inn", width=100)
    tree1.column("compensation_fund_fee_vv", width=85)
    tree1.column("responsibility_level_vv", width=220)
    tree1.column("compensation_fund_fee_odo", width=80)
    tree1.column("responsibility_level_odo", width=220)

    tree1.heading("i", text="№")
    tree1.heading("full_description", text="Полное наименование")
    tree1.heading("member_status", text="Статус")
    tree1.heading("registration_number", text="Рег.ном")
    tree1.heading("registry_registration_date_time_string", text="Дата рег. в СРО")
    tree1.heading("ogrnip", text="ОГРН/ОГРИП")
    tree1.heading("inn", text="ИНН")
    tree1.heading("compensation_fund_fee_vv", text="КФ ВВ")
    tree1.heading("responsibility_level_vv", text="Стоимость работ")
    tree1.heading("compensation_fund_fee_odo", text="КФ ОДО")
    tree1.heading("responsibility_level_odo", text="Пред размер обязательств")


    tree1.pack(side=LEFT)
    # tree1.grid(sticky=W)
    tree1.place(x=10, y=150, height=350, width=1440)
    for comp in data1:
        tree1.insert("", 'end', values=comp)

    lbl1 = Label(window1, text="По статусу", font=("Arial Bold", 12)).place(x=200, y=30)
    lbl2 = Label(window1, text="По рег. номеру", font=("Arial Bold", 12)).place(x=350, y=30)
    lbl3 = Label(window1, text="По названию", font=("Arial Bold", 12)).place(x=500, y=30)
    lbl4 = Label(window1, text="По инн", font=("Arial Bold", 12)).place(x=700, y=30)

    txt1 = Entry(window1, width=10)
    txt1.place(x=200, y=50)
    txt2 = Entry(window1, width=10)
    txt2.place(x=350, y=50)
    txt3 = Entry(window1, width=15)
    txt3.place(x=500, y=50)
    txt4 = Entry(window1, width=10)
    txt4.place(x=700, y=50)

    btn = Button(window1, text="Фильтр", width=13, font=("Arial Bold", 12), command=parsed_filtered)
    btn.place(x=0, y=50)



window = Tk()
window.geometry('1500x600')
window.title("Парсинг реестра СРО")

nametofont("TkHeadingFont").configure(family="Song", size=12)
columns = "i", "status", "reg_num", "full_name", "address", "subject", "fed_okr", "id"
tree = ttk.Treeview(columns=columns, show="headings")

tree.column("i", width=40)
tree.column("status", width=60)
tree.column("reg_num", width=160)
tree.column("full_name", width=490)
tree.column("address", width=340)
tree.column("subject", width=155)
tree.column("fed_okr", width=155)
tree.column("id", width=0, stretch=NO)

tree.heading("i", text="№")
tree.heading("status", text="Статус")
tree.heading("reg_num", text="Рег номер")
tree.heading("full_name", text="Название")
tree.heading("address", text="Адрес")
tree.heading("subject", text="Субъект")
tree.heading("fed_okr", text="Фед округ")
tree.heading("id", text="id")

tree.pack(side=LEFT)
tree.place(x=10, y=150, height=350, width=1400)

btn_parse_new = Button(window, text="Парсинг новый", command=parsed_new)
btn_parse_new.grid(column=1, row=0)

btn = Button(window, text="Фильтр", width=13, font=("Arial Bold", 12), command=parsed_filtered)
btn.place(x=0, y=50)

lbl1 = Label(window, text="По статусу", font=("Arial Bold", 12)).place(x=200, y=30)
lbl2 = Label(window, text="По рег. номеру", font=("Arial Bold", 12)).place(x=350, y=30)
lbl3 = Label(window, text="По названию", font=("Arial Bold", 12)).place(x=500, y=30)
lbl4 = Label(window, text="По адресу", font=("Arial Bold", 12)).place(x=700, y=30)
lbl5 = Label(window, text="По субъекту", font=("Arial Bold", 12)).place(x=850, y=30)
lbl6 = Label(window, text="По фед. округу", font=("Arial Bold", 12)).place(x=1000, y=30)
# lbl7 = Label(window, text="По id", font=("Arial Bold", 12)).place(x=1150, y=30)
lbl_exept_selection = Label(window, text="Выберите элемент в таблице, по которому хотите перейти в реестр членов СРО",
                            font=("Arial Bold", 15)).place(x=500, y=540)

txt1 = Entry(window, width=10)
txt1.place(x=200, y=50)
txt2 = Entry(window, width=10)
txt2.place(x=350, y=50)
txt3 = Entry(window, width=15)
txt3.place(x=500, y=50)
txt4 = Entry(window, width=10)
txt4.place(x=700, y=50)
txt5 = Entry(window, width=10)
txt5.place(x=850, y=50)
txt6 = Entry(window, width=10)
txt6.place(x=1000, y=50)

parsed_old()


def selected():
    if not tree.selection():
        return
    selected = tree.focus()
    values = tree.item(selected, 'values')
    id_sro = values[7]
    parsed_sro(id_sro)
    print(id_sro)


btn_sro = Button(window, text="Перейти в реестр членов СРО", width=30, font=("Arial Bold", 12), command=selected)
btn_sro.place(x=500, y=500)

window.mainloop()