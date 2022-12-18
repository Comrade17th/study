import tkinter as tk
import tkinter.ttk

import Kamilkatest as main

def loadTxt(frame_filters):
    text_box = []
    labels = []
    heads = main.get_header()
    iterator = 0
    for name in heads:
        text_box.append(tk.Entry(frame_filters, width=15))
        labels.append(tk.Label(frame_filters, text = name))
        #labels[iterator].pack()
        labels[iterator].grid(column=iterator, row=0)
        #text_box[iterator].pack()
        text_box[iterator].grid(column=iterator, row=1)
        iterator +=1
    return text_box

def filter_data(text_box, data):
    data_tmp = data
    data_res = []

    for i in range(len(text_box)):
        for row in data_tmp:
            if text_box[i].get() != '':
                if text_box[i].get() in str(row[i]):
                    data_res.append(row)
            else:
                data_res.append(row)
        data_tmp = data_res
        data_res = []
    data_res = data_tmp
    for row in data_res:
        print(row)
    return data_res

def update_tree(tree, data, text_boxes):
    tree.delete(*tree.get_children())
    data = filter_data(text_boxes, data)
    for comp in data:
        tree.insert("", 'end', values=comp)

def mainFrames(window, width, height):
    frame_filters = tk.Frame(window, height=150, width=150, bg='skyblue')
    frame_statictic = tk.Frame(window, height=150, width=150, bg='#8d21bf')
    frame_table = tk.Frame(window, height=150, width=300, bg='red')

    frame_filters.place(relx=0, rely=0, relwidth=0.5, relheight=0.5)
    frame_statictic.place(relx=0.5, rely=0, relwidth=0.5, relheight=0.5)
    frame_table.place(relx=0, rely=0.5, relwidth=1, relheight=0.5)

    data = main.get_data(main.get_result())
    #loadTable(frame_table, main.get_data())
    table_tree = loadTable(frame_table, data)
    text_boxes = loadTxt(frame_filters)
    def btn_click():
        update_tree(table_tree, data, text_boxes)
    btn = tk.Button(frame_statictic, text="Фильтр", width=13, font=("Arial Bold", 12), command=btn_click)

    btn.pack()


def loadTable(frame_table, data):
    table = tkinter.ttk.Treeview(frame_table, show='headings')
    heads = main.get_header()
    table['columns'] = heads #[0, 1, 2, 3, 4, 5, 6, 7, 8, 9]
    for header in heads:
        table.heading(header, text = header, anchor= 'center')
        table.column(header, anchor='center', stretch= tk.YES, width=len(header))
    for row in data:
        table.insert('', tk.END, values = row)

    scroll_pane = tk.ttk.Scrollbar(frame_table, command=table.yview())
    table.configure(yscrollcommand=scroll_pane.set)
    scroll_pane.pack(side = tk.RIGHT, fill = tk.Y)


    table.pack(expand=tk.YES, fill=tk.BOTH)
    return table

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

