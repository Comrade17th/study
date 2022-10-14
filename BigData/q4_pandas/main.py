
import pandas as pd

# Press the green button in the gutter to run the script.
if __name__ == '__main__':
#1. В таблице Customers.csv
# посчитайте количество клиентов, чья должность - Owner.
# посчитайте количество клиентов, чьи имена начинаются на латинскую
#букву A. Сколько таких клиентов?
# выведите клиентов, чьи номера телефонов содержат 5555 (четыре
#символа 5 подряд). Четыре пятерки подряд могут быть в начале номера,
#в середине или в конце. Сколько таких клиентов?
# посчитайте количество клиентов, у которых должность Owner или Sales
#Representative. Сколько таких клиентов?
# посчитайте в разрезе должностей количество клиентов. Иными словами,
#сгруппируйте должности и посчитайте количество клиентов.
#Сопоставьте должность и количество клиентов.
    df_c = pd.read_csv('Customers.csv', sep = ';')
    print(df_c['ContactTitle'].str.contains('Owner'))

# See PyCharm help at https://www.jetbrains.com/help/pycharm/
