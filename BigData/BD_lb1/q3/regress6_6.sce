clc
printf('Hello world')
arrX = [
1 ,11;
1, 9.5;
1, 8.1;
1, 25;
1, 19 ;
1, 3.6;
1, 15;
1, 5.3;
1, 9.5;
1, 15;
1, 14;
1, 27;
1, 27;
1, 70;
1, 34;
1, 13]
arrY = [57.41; 40.6; 57.2; 122.49; 63.5; 37.41; 42.75; 41.3; 44.89; 47.9; 59.46; 67.79; 67.79; 124.51; 99.7; 43.63]
x = [11;
9.5;
8.1;
25;
19;
3.6;
15;
5.3;
9.5;
15;
14;
27;
27;
70;
34;
13
]

disp(arrX)
arrXT = arrX'
disp(arrXT)
arrXT_x = arrXT * arrX
disp(arrXT_x)
arrXT_x_inv = inv(arrXT_x) // ^-1
disp(arrXT_x_inv)
arrXT_x_inv_xt = arrXT_x_inv * arrXT // ^-1 * T
disp(arrXT_x_inv_xt)
arrXT_x_inv_xt_y = arrXT_x_inv_xt * arrY
disp(arrXT_x_inv_xt_y)
plot(x, arrY, "*")
ab = arrXT_x_inv_xt_y
function y = reg(x)
    y = ab(2)*x + ab(1);
endfunction;
plot(x ,reg(x))
