import tkinter as tk
import tkinter.ttk

import main


def mainFrames(window, width, height):
    frame_add_form = tk.Frame(window, height=150, width=150, bg='blue')
    frame_statictic = tk.Frame(window, height=150, width=150, bg='green')
    frame_table = tk.Frame(window, height=150, width=300, bg='red')

    frame_add_form.place(relx=0, rely=0, relwidth=0.5, relheight=0.5)
    frame_statictic.place(relx=0.5, rely=0, relwidth=0.5, relheight=0.5)
    frame_table.place(relx=0, rely=0.5, relwidth=1, relheight=0.5)


    loadTable(frame_table, main.get_data())



def loadTable(frame_table, data):
    table = tkinter.ttk.Treeview(frame_table, show='headings')
    heads = ["Марка",
             "Модель",
             "Год выпуска",
             "Объем двигателя л.",
             "л.с.",
             "топливо",
             "КПП",
             "Привод",
             #"Пробег тыс.км.",
             "Цена"]
    table['columns'] = heads #[0, 1, 2, 3, 4, 5, 6, 7, 8, 9]
    for header in heads:
        table.heading(header, text = header, anchor= 'center')
        table.column(header, anchor='center', stretch= tk.YES, width=header.count(header))
    for row in data:
        table.insert('', tk.END, values = row)

    scroll_pane = tk.ttk.Scrollbar(frame_table, command=table.yview())
    table.configure(yscrollcommand=scroll_pane.set)
    scroll_pane.pack(side = tk.RIGHT, fill = tk.Y)


    table.pack(expand=tk.YES, fill=tk.BOTH)

def mainWindow():
    #1280 × 720
    height = 720
    width = 1280
    window = tk.Tk()
    window.title = 'CarParser'
    window.geometry('1280x720')
    mainFrames(window, width, height)

    window.mainloop()

if __name__ == "__main__":
    mainWindow()

#ЭА ->
# Поставка лекарственного препарата для медицинского применения Вандетаниб (РЛ)(0129200005322003429) ->
# 1 090 917.00 RUB -> КОМИТЕТ ПО РЕГУЛИРОВАНИЮ КОНТРАКТНОЙ СИСТЕМЫ В СФЕРЕ ЗАКУПОК ВОЛГОГРАДСКОЙ ОБЛАСТИ ->
# ГОСУДАРСТВЕННОЕ КАЗЕННОЕ УЧРЕЖДЕНИЕ "ДИРЕКЦИЯ ПО ОБЕСПЕЧЕНИЮ ДЕЯТЕЛЬНОСТИ ГОСУДАРСТВЕННЫХ УЧРЕЖДЕНИЙ ЗДРАВООХРАНЕНИЯ ВОЛГОГРАДСКОЙ ОБЛАСТИ" ->
# 16.12.2022 15:19:11(MSK+00:00) ->
# 28.12.2022 09:00:00(MSK+00:00) ->
# 28.12.2022 11:00:00(MSK+00:00) ->
# Прием заявок ->
# Публикация извещения от 16.12.2022 15:19:11 (MSK+00:00) ->
# Извещение в ЕИС

