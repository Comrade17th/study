clf()
clc
x = 0:.1:10
Y = grand(1000, 1, "gam", 6, 4)
function y = f(x,k,lam)
    y = x.^(k-1).*exp(-lam*x)*lam^k/gamma(k);
endfunction
// 13.	Гамма-распределение  λ= 4, k=6.
p = get("hdl")
set(gca(), "font_style", 5, "font_size", 5, "font_color", 0);
p.thickness= 3
plot(x, f(x,6,4), '-')
histplot(11, Y)
p.thickness = 1
legend('k = 6, lam = 4', 'Гистограмма')
xgrid()
[X] = cdfgam("X", 6,4,0.93,0.07)
disp(X)
