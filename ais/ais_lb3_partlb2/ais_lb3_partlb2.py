
from random import randint


#text_for_mirror = input("Введите строку чтобы отзеркалить ее: ")
#for elem in reversed(text_for_mirror):
#    print(elem, end = "")
#print()

nums1 = []
nums2 = []
n = 10
while(n > 0):
    n-=1
    nums1.append(randint(-5, 5))
print(nums1)

counter = 0;
for n in nums1:
    if n<0 and counter%2 == 1:
        nums2.append(n)
    counter+=1
print(nums2)
# [65:90] A-Z
# [97:122] a-z

text = "Alice. 'Exactly so,' said the Gryphon never learnt it.' 'Hadn't time,' said the Gryphon remarked: 'because they lessen from day to day.'"
print(text)
c_up =0
c_low = 0
for n in text:
    if(n >= 'A' and n <= 'Z'):
        c_up+=1
    if(n >= 'a' and n <= 'z'):
        c_low+=1
print("Заглавных: ", c_up)
print("Строчных: ", c_low)

#n = 32
#while(n < 128):
#    print("|",chr(n), " ", n, "|" , end = "\t")
#    if(n%8 == 0):
#        print()
#    n+=1