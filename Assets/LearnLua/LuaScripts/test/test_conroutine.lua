--范例：生产者与消费者问题

--具体产生一个累加数值的迭代函数
--用闭包实现一个迭代器函数
function GetNumber()
	local num = 0
	return function()
		num = num + 1
		return num
	end
end
--这一步必须要有
local getNum = GetNumber()  --得到一个返回函数


--生产者程序
--在循环内得到迭代器函数的引用
Producer = coroutine.create(
		function()
			while (true) do
				local num = getNum()    --得到一个迭代器函数返回的具体数值
				print("生产的数据=", num)
				coroutine.yield(num)    --返回迭代生成的数值
			end
		end
)

--接收者程序
--接收生产者，传给消费者
function Receiver()
	local status, value = coroutine.resume(Producer)
	return value
end


--消费者程序
function Consumer(printNum)
	for i = 1, printNum do
		local receiveValue = Receiver()
		print("消费数据=", receiveValue)
	end
end

--程序的测试
Consumer(10)
