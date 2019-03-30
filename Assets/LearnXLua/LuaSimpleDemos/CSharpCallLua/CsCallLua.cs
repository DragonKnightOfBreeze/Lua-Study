/*
 * Tencent is pleased to support the open source community by making xLua available.
 * Copyright (C) 2016 THL A29 Limited, a Tencent company. All rights reserved.
 * Licensed under the MIT License (the "License"); you may not use this file except in compliance with the License. You may obtain a copy of the License at
 * http://opensource.org/licenses/MIT
 * Unless required by applicable law or agreed to in writing, software distributed under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the License for the specific language governing permissions and limitations under the License.
*/

/* Reformatted and refactored by @DragonKnightOfBreeze. */

using System;
using System.Collections.Generic;
using UnityEngine;
using XLua;

namespace LearnXLua.LuaSimpleDemos.CSharpCallLua {
	public class CsCallLua : MonoBehaviour {
		LuaEnv luaEnv;
		//language=Lua
		private const string script = @"
        a = 1
        b = 'hello world'
        c = true

        d = {
           f1 = 12, f2 = 34, 
           1, 2, 3,
           add = function(self, a, b) 
              print('d.add called')
              return a + b 
           end
        }

        function e()
            print('i am e')
        end

        function f(a, b)
            print('a', a, 'b', b)
            return 1, {f1 = 1024}
        end
        
        function ret_e()
            print('ret_e called')
            return e
        end
		";

		public class TestClass {
			public int f1;
			public int f2;
		}

		[CSharpCallLua]
		public interface ITestInterface {
			int Prop1 { get; set; }
			int Prop2 { get; set; }

			int Add(int a, int b);
		}

		[CSharpCallLua]
		public delegate int FDelegate(int a, string b, out TestClass c);

		[CSharpCallLua]
		public delegate Action GetE();

		void Start() {
			luaEnv = new LuaEnv();
			luaEnv.DoString(script);

			Debug.Log("_G.a = " + luaEnv.Global.Get<int>("a"));
			Debug.Log("_G.b = " + luaEnv.Global.Get<string>("b"));
			Debug.Log("_G.c = " + luaEnv.Global.Get<bool>("c"));

			//映射到有对应字段的class，by value
			TestClass test = luaEnv.Global.Get<TestClass>("d");
			Debug.Log("_G.d = {f1=" + test.f1 + ", f2=" + test.f2 + "}");

			//映射到Dictionary<string, double>，by value
			Dictionary<string, double> d1 = luaEnv.Global.Get<Dictionary<string, double>>("d");
			Debug.Log("_G.d = {f1=" + d1["f1"] + ", f2=" + d1["f2"] + "}, d.Count=" + d1.Count);

			//映射到List<double>，by value
			List<double> d2 = luaEnv.Global.Get<List<double>>("d");
			Debug.Log("_G.d.len = " + d2.Count);

			//映射到interface实例，by ref，这个要求interface加到生成列表，否则会返回null，建议用法
			ITestInterface d3 = luaEnv.Global.Get<ITestInterface>("d");
			d3.Prop2 = 1000;
			Debug.Log("_G.d = {f1=" + d3.Prop1 + ", f2=" + d3.Prop2 + "}");
			Debug.Log("_G.d:add(1, 2)=" + d3.Add(1, 2));

			LuaTable d4 = luaEnv.Global.Get<LuaTable>("d"); //映射到LuaTable，by ref
			Debug.Log("_G.d = {f1=" + d4.Get<int>("f1") + ", f2=" + d4.Get<int>("f2") + "}");

			//映射到一个delegate，要求delegate加到生成列表，否则返回null，建议用法
			Action e = luaEnv.Global.Get<Action>("e");
			e();

			//lua的多返回值映射：从左往右映射到c#的输出参数，输出参数包括返回值，out参数，ref参数
			FDelegate f = luaEnv.Global.Get<FDelegate>("f");
			int f_ret = f(100, "John", out TestClass testRet);
			Debug.Log("ret.d = {f1=" + testRet.f1 + ", f2=" + testRet.f2 + "}, ret=" + f_ret);

			//delegate可以返回更复杂的类型，甚至是另外一个delegate
			GetE ret_e = luaEnv.Global.Get<GetE>("ret_e");
			e = ret_e();
			e();

			LuaFunction d_e = luaEnv.Global.Get<LuaFunction>("e");
			d_e.Call();
		}

		void Update() {
			luaEnv?.Tick();
		}

		void OnDestroy() {
			luaEnv.Dispose();
		}
	}
}