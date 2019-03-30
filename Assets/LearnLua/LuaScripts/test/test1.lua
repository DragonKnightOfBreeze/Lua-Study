---test1.lua
---lua基础知识，测试范例


--[[基础知识]]

--使用`--`进行单行注释。
--使用`--[[`和`--]]`进行多行注释。
abc = "abc"             --声明一个变量并赋值，每行语句不需要以分号结尾
abc = 20                --变量的类型可以随时改变
print(type(abc))        --打印变量的类型，结果为：number
abc = nil                --通过空类型关键字，销毁一个变量



--[[数据类型与运算符]]

boo = true          --布尔类型变量
str = "你好"         --字符串类型变量
num = 123           --数字类型变量
--表类型变量
numTable = { 1, 2, 3 }
--函数类型变量
function myFunction()
	print("这是一个函数")
end

--算术运算符：`+`、`-`、`*`、`/`（除）、`//`（整除）、`%`（取模）、`^`（次方）
--lua中没有自增和自减运算符。
--
--关系运算符：`<`、`<=`、`>`、`>=`、`==`、`~=`（不等于）
--注意：nil只与自身相等，对于table、function、userdata是作引用比较的，即只有当它们引用同一对象使才认为其相等。
--
--逻辑运算符：`and`（逻辑与）、`or`（逻辑或）、`not`（逻辑非）
--规定除了nil和false以外，其他的值都为真。
--短路规则：不做多余的判断（例如：对于逻辑与运算，有假为假，全真为真）
--
--其他：`=`（赋值）、`..`（字符串连接）

--lua的多重赋值
num1, num2, num3 = 1, 2, 3      --左边多，则多的变量为nil；右边多，则舍去

globalNum = 1               --全局变量
local localNum = 1          --局部变量（如果定义在语句块内，在语句块外不能访问）

--一个自定义的语句块
do
	print("这是一个语句块！")
end



--[[流程控制语句]]

--if条件语句
if (num == 1) then
	print("num等于1")
elseif (num == 2) then
	print("num等于2")
else
	print("num等于其他的值")
end

--while循环语句
i = 1
while (i <= 10) do
	print(i)
	i = i + 1
end                --先判断条件
--repeat           --先执行一次语句块中的代码

--for循环语句
--相关参数：开始的值，结束的值，间隔（默认为1）
for i = 1, 10 do
	print(i)
end

--泛型for循环语句，遍历形似列表的表
--i是索引，v是值
myArray1 = { 1, 2, 3 }
for i, v in ipairs(myArray1) do
	print(i .. "\t" .. v)
end

--泛型for循环语句，一般用于遍历形似字典的表（键也可以是索引）
--k是键，v是值
--k、v可以由任何字母或合法的关键字代替
myArray2 = { item1 = 1, item2 = 2, item3 = 3 }
for k, v in pairs(myArray2) do
	print(k .. "\t" .. v)
end

--循环中断关键字：break

--lua标准库中提供了几种迭代器：
--迭代文件每行的`io.lines`；
--迭代table中的元素（形似列表）的`ipairs`；
--迭代table中的元素（形似字典，或者将索引作为键）的`pairs`；
--迭代字符串中单词的`string.gmatch`；
--……



--[[函数]]

--定义一个函数
function myFun1(para1)
	print("这是一个函数，参数：")
	para1Str = tostring(para1)
	return para1Str
end
--调用函数
myFun1(1)
--得到函数的返回值
result = myFun1(1)
--将函数赋值给变量，得到这个函数
myFun1Copy = myFun1

--lua中定义的变量默认是全局变量，在函数中的也是如此。
--在函数中定义的全局变量，在外部照样可以访问。
--函数可以声明为全局的或局部的，默认是全局的。
--局部函数中的都是局部变量。

--函数可以返回多个值
function getNum()
	return 1, 2, 3
end
num1, num2, num3 = getNum()       --左边多，则多的变量为nil；右边多，则舍去

--函数可以为变量赋值，也可以作为参数进行传递（相当于C#的委托）

--匿名函数及其调用
namelessFunc = function(para1)
	print(tostring(para1))
end
namelessFunc(233)
--lua中没有lambda表达式



--[[字符串]]

--定义单行字符串
str = "abc"
--定义多行字符串
strMultiLine [[
    太阳骑士 索拉尔
    太阳万岁！
]]
--字符串的连接
print("太阳骑士 " .. "索拉尔")       --输出：太阳骑士 索拉尔
--字符串的转换
print("123" + "100")              --输出：223
--其他情况
print("数字：" .. 123)               --输出：数字：123
print("123" + 100)                --输出：223
--求字符串的长度
print(#"123")                   --输出：3
print(#"数字")                    --输出：4

--字符串中两个重要的转换函数
--tonumber()、tostring()
numStr1 = "233"
num2 = 100
num3 = tonumber(numStr1) - num2
numStr3 = "233" .. tostring(num2)

--必须用到tostring()的场合1
numTable = { 1, 2, 3 }
--print("表的内容："..numTable)              --错误，表不能自动转化为字符串
print("表的内容：" .. tostring(numTable))      --输出的是表的地址，而非内容
--必须用到tostring()的场合2
num = nil
--print("num = "..num)                    --错误，不能连接空类型
print("num1 = " .. tostring(num))

--输出字符串长度：可以使用`string.len(str)`。（一个汉字的长度为2），返回number。可以使用`#str`。
--转别成大写和小写：可以分别使用`string.upper(str)`和`string.lower(str)`，返回string。
--查找：可以使用`string.find(str,pattern)`，返回number。
--截取字符串：可以使用`string.sub(str,i,j)`，返回string。
--字符串替换：可以使用`string.gsub(str,pattern,repl)`。
--字符串反转：可以使用`string.reverse(str)`，返回string。
--格式化字符串：可以使用`string.format(formatString,...)`，返回string。

--格式化字符串的使用
print("select ? from ? where id=? and ......")      --示例的SQL语句
strResult = string.format("select %s from %s where id=%d and ......", content, db, id)



--[[表]]

--表的定义
numTable1 = {}                      --一个空表
numTable2 = { 1, 2, 3 }                 --一个列表形式的表
numTable3 = { i1 = 1, i2 = 2, i3 = 3 }  --一个字典形式的表
numTable3.i4 = 5                    --表的元素可以继续添加

print(numTable1)                    --输出表的地址
print(numTable2[1])                 --输出表的第一个元素（索引以1开始）
print(numTable3.i1)                 --输出表中键为i1的元素（也可以用索引）（类似属性的形式）
print(numTable3["i1"])              --输出表中键为i1的元素（也可以用索引）（必须是字符串）

--表的迭代输出
--也可以使用ipairs()和pairs()函数进行迭代输出。对于键值对形式的表，不能保证顺序。
myTable = { 1, 2, 3 }
for i = 1, #myTable do
	print(myTable[i])
end
for i, v in ipairs(myTable) do
	print(i)
end

--自定义得到表中最大数值的函数
function getMax(tab)
	if type(tab) == "table" then
		return tab[table.maxn(tab)]
	else
		print("给定的参数不是table！")
		return nil
	end
end