--定义类的继承方法
function Extends(supperClass)
	local subClass = {}
	supperClass.__index = supperClass
	setmetatable(subClass, supperClass)
	return subClass
end


--定义空表，相当于一个类
Knights = {}

--定义类的字段
Knights.Name = nil
Knights.Race = nil
--定义类的方法
function Knights:Acton1()
	print("攻击！")
end

--定义类的构造方法
function Knights:Init(name, race)
	local newClass = {}
	self.__index = self
	setmetatable(subClass, self)

	newClass.Name = name
	newClass.Race = race
	return newClass
end

--定义子类
Knight = Extends(Knights)
Knight.Weapon1 = nil
Knight.Weapon2 = nil

--定义子类的方法
function Knight:Acton2()
	print("互动！")
end

--定义子类的构造方法
function Knights:Init(name, race, w1, w2)
	local newClass = {}
	self.__index = self
	setmetatable(subClass, self)

	newClass.Name = name
	newClass.Race = race
	newClass.Weapon1 = w1
	newClass.Weapon2 = w2
	return newClass
end

--实例化
BreezeKnights = Knights:Init("微风骑士团", "伊咪")
DragonKnightOfBreeze = Knight:Init("微风的龙骑士 风游迩", "伊咪")

--测试
DragonKnightOfBreeze:Acton1()
DragonKnightOfBreeze:Acton2()