from datetime import datetime


mxlen = 90
s_date = "{:%d.%m.%Y}".format(datetime.now())
s_start = "\"ПОПОЛНЕНИЕ\""
s0 = "Большая панда в зоопарке на западе Японии принесла потомство. При этом у нее вместо одного"
s1 = "родилось сразу два детёныша. Близнецы появились на свет в парке «Вакаяма». С разницей в 3"
s2 = "часа. Каждый весит приблизительно по 180 граммов."
s_ = "_"
count = 0
count += len(s0.split())
count += len(s1.split())
count += len(s2.split())
print(s_date.rjust(mxlen, " "))
print(s_start.center(mxlen, " "))
print(s0.center(mxlen, " "))
print(s1.center(mxlen, " "))
print(s2.center(mxlen, " "))
print(s_.center(mxlen, "_"))
print("Количество слов в тексте: ", count)