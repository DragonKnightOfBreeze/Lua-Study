/*
 * Tencent is pleased to support the open source community by making xLua available.
 * Copyright (C) 2016 THL A29 Limited, a Tencent company. All rights reserved.
 * Licensed under the MIT License (the "License"); you may not use this file except in compliance with the License. You may obtain a copy of the License at
 * http://opensource.org/licenses/MIT
 * Unless required by applicable law or agreed to in writing, software distributed under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the License for the specific language governing permissions and limitations under the License.
*/

/* Reformatted and refactored by @DragonKnightOfBreeze. */

using System;
using UnityEngine;
using XLua;

namespace LearnXLua.LuaDemo.LuaObjectOrented {
    public abstract class PropertyChangedEventArgs : EventArgs {
		public string name;
		public object value;
	}

	/// <summary>展示lua面向对象和cs的整合。</summary>
	public class InvokeLua : MonoBehaviour {
		[CSharpCallLua]
		public interface ICalc {
			event EventHandler<PropertyChangedEventArgs> PropertyChanged;

			int Add(int a, int b);

			int Multi { get; set; }

			object this[int index] { get; set; }
		}

		[CSharpCallLua]
		public delegate ICalc CalcNew(int multi, params string[] args);

		//language=Lua
		private const string script = @"
        local calc_mt = {
            __index = {
                Add = function(self, a, b)
                    return (a + b) * self.Multi
                end,

                get_Item = function(self, index)
                    return self.list[index + 1]
                end,

                set_Item = function(self, index, value)
                    self.list[index + 1] = value
                    self:notify({name = index, value = value})
                end,

                add_PropertyChanged = function(self, delegate)
                    if self.notifyList == nil then
                        self.notifyList = {}
                    end
                    table.insert(self.notifyList, delegate)
                    print('add',delegate)
                end,

                remove_PropertyChanged = function(self, delegate)
                    for i=1, #self.notifyList do
                        if CS.System.Object.Equals(self.notifyList[i], delegate) then
	                        table.remove(self.notifyList, i)
	                        break
                        end
                    end
                    print('remove', delegate)
                end,

                notify = function(self, evt)
                    if self.notifyList ~= nil then
                        for i=1, #self.notifyList do
	                        self.notifyList[i](self, evt)
                        end
                    end
                end,
            }
        }

        Calc = {
        	--CalC:new就相当于一个构造方法，用于构造一个接口的代理类，需要有对应的参数
        	--返回一个设置过元表的，属性包含对应的接口中的属性，且元表中的__index属性中的方法包含对应的接口中的方法
        	--NOTE 应该还有更好的结构
            New = function (multi, ...)
                print(...)
                --第一个参数：需要返回的原始表，需要设置接口中对应的属性
                --第二个参数：需要返回的表的元表，需要在元表的__index属性中设置接口中对应的方法。
                return setmetatable({Multi = multi, list = {'aaa','bbb','ccc'}}, calc_mt)
            end
        }
        ";

		void Start() {
			LuaEnv luaEnv = new LuaEnv();
			//调用了带可变参数的delegate，函数结束都不会释放delegate，即使置空并调用GC
			Test(luaEnv);
			luaEnv.Dispose();
		}

		void Test(LuaEnv luaEnv) {
			luaEnv.DoString(script);
			//从全局路径中得到这个委托
			CalcNew calc_new = luaEnv.Global.GetInPath<CalcNew>("Calc.New");
			//将这个委托作为构造方法构造一个接口的代理类
			ICalc calc = calc_new(10, "hi", "john");
			Debug.Log("sum(*10) =" + calc.Add(1, 2));
			calc.Multi = 100;
			Debug.Log("sum(*100)=" + calc.Add(1, 2));

			Debug.Log("list[0]=" + calc[0]);
			Debug.Log("list[1]=" + calc[1]);

			calc.PropertyChanged += Notify;
			calc[1] = "ddd";
			Debug.Log("list[1]=" + calc[1]);

			calc.PropertyChanged -= Notify;

			calc[1] = "eee";
			Debug.Log("list[1]=" + calc[1]);
		}

		void Notify(object sender, PropertyChangedEventArgs e) {
			Debug.Log($"{sender} has property changed {e.name}={e.value}");
		}
	}
}