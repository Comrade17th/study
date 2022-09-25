# test data
# a  b  c
# 1 -2 -3
# -1 -2 15
# 1 12 36
# 5 3 7
print("a*x^2 + b*x + c = 0")
a = int(input("a = "))
b = int(input("b = "))
c = int(input("c = "))
d = b**2 - 4*a*c
if d < 0:
    print("No roots")
elif d == 0:
    x = (-b + d**(0.5)) / (2 * a)
    print("x = ", x)
else:
    x1 = (-b + d**(0.5)) / (2 * a)
    x2 = (-b - d**(0.5)) / (2 * a)
    print("x1 = ", x1)
    print("x2 = ", x2)