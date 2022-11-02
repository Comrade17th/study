clf()
clc
funcprot()
x=[2, 4.5, 6, 12,18,34,21,4,4,23,17,22,36,2, 45]
h = 4
n = length(x)
//p = y/n/h

//bar(x, p, 1, 'red')
//plot(x, p, 'black')
histplot(4,x, polygon = %t, style = [3,5])
m = mean(x)
function mom = f(k)
    mom = sum((x-m).^k)/length(x)
endfunction

m = mean(x)
printf("Оценка мат-ожидалния %2.4f\n",m)
//disp("")
s2 = variance(x) 
printf("Несмещенная оценка дисперсии %2.4f\n",s2)
s = stdev(x)
printf("Несмещенная оценка среднеквадратичного отклонения %2.4f\n", s)
m2 = f(2)
printf("Центр. момент 2го порядка Смещенная оценка Дисперсии %2.4f\n", m2)
m3 = f(3)
printf("Центр. момент 3го порядка %2.4f\n", m3)
m4 = f(4)
printf("Центр. момент 4го порядка %2.4f\n", m4)
s1 = f(2)
s3 = s1^0.5
Assm= m3/s3^3
printf("Смещенная ассиметрия: %2.4f\n",Assm)
As = Assm*(n*(n-1))^0.5/(n-2)
printf("Не смещенная ассиметрия: %2.4f\n",As)

Exsm = m4/s3^4-3
printf("Смещенный эксцесс: %2.4f\n",Exsm)
Ex = (n^2 -1)/(n-2)/(n-3)*(Exsm + 6 /(n+1))
printf("Не смещенный эксцесс: %2.4f\n",Ex)
printf("Оценка коэффициента вариации %2.4f\n", s3/m)
printf("Смещенная оценка среднеквадратичного отклонения %2.4f\n", s3)
