classA = {}

function classA.new(cls, ...)
	--定义类方法时使用"."号，不适用隐式传参
	this = {}
	setmetatable(this, cls)
	cls.__index = cls           --将元表的__index设为自身，访问表的属性不存在时会搜索元表
	cls.init(this, ...)        --初始化表，注意访问类的方法都是"."，此时不会隐式传入参数
	return this
end

function classA.init(self, name)
	self.name = name
end

function classA.getname(self)
	return self.name
end

p = classA:new("gray.yang")
print(p:getname())
print(string.rep("*", 50))


--模拟继承


classB = classA:new()        --获得实例

function classB.new(cls, ...)
	this = {}
	setmetatable(this, cls)
	cls.__index = cls
	cls.init(this, ...)
	return this
end

function classB.init(self, name, address)
	super = getmetatable(self)
	super:init(name)                --使用父类初始化
	self.address = address
end

function classB.getaddress(self)
	return self.address
end

b = classB:new("tom.li", "shenzhen")

print("getbname==============>", b:getname())
print("getbaddress===========>", b:getaddress())