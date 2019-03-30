--定义链表的初始化函数
function CreateLinkedList(value)
	local linkedList = {}
	linkedList.Value = value
	linkedList.Next = nil
	return linkedList
end

--增加一个结点
function Add(linkedList, value)
	--参数类型检查
	if type(linkedList) ~= "table" then
		return nil
	end

	local temp = {}
	temp.Value = value
	temp.Next = nil
	--定位最后一个结点的Next
	local index = linkedList
	while (index ~= nil) do
		index = index.Next
	end
	--连接到最后一个节点
	index = temp
end


--定义链表的迭代器
function Iterator(linkedList)
	--参数类型检查
	if (type(linkedList) ~= "table") then
		return nil
	end

	--开始迭代链表中的Value
	return function()
		if (not list) then
			return nil
		end
		returnValue = list.Value
		list = list.Next
		return returnValue
	end
end