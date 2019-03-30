--具备多个内嵌函数的闭包
function FunMulti()
	local numUpValue = 10   --upValue
	function InnerFun1()
		--内嵌函数
		print(numUpValue)
	end
	function InnerFun2()
		numUpValue = numUpValue + 100
	end

	return InnerFun1, InnerFun2
end

--调用测试
local res1, res2 = FunMulti()
res1()      --输出：10
res2()
res1()      --输出：110