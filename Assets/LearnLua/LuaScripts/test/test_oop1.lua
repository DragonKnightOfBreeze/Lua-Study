---test2.lua
---lua面向对象，测试范例


--定义空表，相当于一个类
Person = {}
--定义局部表引入变量，降低方法引用表字段的耦合性
--local this = Person

--定义类的字段
Person.Name = "微风的龙骑士 风游迩"
Person.Race = "伊咪"
Person.Weapon1 = "风临"
Person.Weapon2 = "《微风的吹息》"
Person.Magic1 = "连环风切"

--定义类的方法（使用this代替类名）
--function Person.Acton1()
--	print("魔法触媒："..this.Weapon2)
--	print("魔法："..this.Magic1)
--end

--使用self关键字，直接在方法中引用表自身字段与方法（方法名中的点改为冒号）
function Person:Acton1()
	print("魔法触媒：" .. self.Weapon2)
	print("魔法：" .. self.Magic1)
end

--调用类的字段和方法（使用this代替类名）
--print(Person.Name)
--Person.Acton1()
--更加完善的调用类的字段和方法的方式（使用self关键字）
print(Person.Name)
Person:Acton1()





