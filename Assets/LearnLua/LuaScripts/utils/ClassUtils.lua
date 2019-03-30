--- 模拟类的工具类
ClassUtils = {}

---类的实例化方法
---@param class any 需要实例化的类
function ClassUtils.New(class, ...)
	local this = {}
	class.__index = class
	setmetatable(this, class)
	class.Init(...)
	return this
end

---类的继承方法
---@param supperClass any 需要继承的父类
function ClassUtils.Extends(supperClass, ...)
	local subClass = {}
	supperClass.__index = supperClass
	setmetatable(subClass, supperClass)
	supperClass.Init(...)
	return subClass
end

return ClassUtils
