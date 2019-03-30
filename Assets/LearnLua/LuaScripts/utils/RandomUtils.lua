--- 随机数的工具类
RandomUtils = {}

---得到指定范围内的随机数
---@param min number 最小值
---@param max number 最大值
function RandomUtils.Range(min, max)
	--得到时间戳
	local strTime = tostring(os.time())
	--得到一个反转字符串
	local strRev = string.reverse(strTime)
	--得到前6位
	local strRandomTime = string.sub(strRev, 1, 6)
	--设置时间种子
	math.randomseed(strRandomTime)
	return math.random(min, max)
end

---得到指定范围内的随机数。最小值为0
---@param max number 最大值
function RandomUtils.GetRandom(max)
	return RandomUtils.GetRandom(0, max)
end

return RandomUtils
