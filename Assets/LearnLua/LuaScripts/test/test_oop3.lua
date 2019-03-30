--类的实例化方法
function New(class, ...)
	local this = {}
	class.__index = class
	setmetatable(this, class)
	class.Init(...)
	return this
end

--定义类的继承方法
function Extends(supperClass, ...)
	local subClass = {}
	supperClass.__index = supperClass
	setmetatable(subClass, supperClass)
	supperClass.Init(...)
	return subClass
end


--定义空表，相当于一个类
Knights = {}

--定义类的字段
Knights.Name = nil
Knights.Race = nil

--定义类的构造方法
function Knights:Init(name, race)
	self.Name = name
	self.Race = race
end

--定义类的方法
function Knights:Acton1()
	print("攻击！")
end


--定义子类
Knight = Extends(Knights)

--定义子类的字段
Knight.Weapon1 = nil
Knight.Weapon2 = nil

--定义子类的构造方法
function Knight:Init(name, race, w1, w2)
	self.Name = name
	self.Race = race
	self.Weapon1 = w1
	self.Weapon2 = w2
end

--定义子类的方法
function Knight:Acton2()
	print("互动！")
end


--实例化
BreezeKnights = New(Knights, "微风骑士团", "伊咪")
DragonKnightOfBreeze = New(Knight, "微风的龙骑士 风游迩", "伊咪", "风临", "风之弓")

--测试
DragonKnightOfBreeze:Acton1()
DragonKnightOfBreeze:Acton2()