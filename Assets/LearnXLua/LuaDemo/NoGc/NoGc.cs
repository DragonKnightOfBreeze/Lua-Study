﻿/*
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

namespace LearnXLua.LuaDemo.NoGc {
	[GCOptimize]
	[LuaCallCSharp]
	public struct Pedding {
		public byte c;
	}

	[GCOptimize]
	[LuaCallCSharp]
	public struct MyStruct {
		public MyStruct(int p1, int p2) {
			a = p1;
			b = p2;
			c = p2;
			e.c = (byte) p1;
		}

		public int a;
		public int b;
		public decimal c;
		public Pedding e;
	}

	[LuaCallCSharp]
	public enum MyEnum {
		E1,
		E2
	}

	[CSharpCallLua]
	public delegate int IntParam(int p);

	[CSharpCallLua]
	public delegate Vector3 Vector3Param(Vector3 p);

	[CSharpCallLua]
	public delegate MyStruct CustomValueTypeParam(MyStruct p);

	[CSharpCallLua]
	public delegate MyEnum EnumParam(MyEnum p);

	[CSharpCallLua]
	public delegate decimal DecimalParam(decimal p);

	[CSharpCallLua]
	public delegate void ArrayAccess(Array arr);

	[CSharpCallLua]
	public interface IExchanger {
		void Exchange(Array arr);
	}

	/// <summary>展示如何避免值类型的GC。</summary>
	[LuaCallCSharp]
	public class NoGc : MonoBehaviour {
		readonly LuaEnv luaEnv = new LuaEnv();

		IntParam f1;
		Vector3Param f2;
		CustomValueTypeParam f3;
		EnumParam f4;
		DecimalParam f5;

		ArrayAccess fArr;
		Action fLua;
		IExchanger ie;
		LuaFunction add;

		[NonSerialized]
		public double[] a1 = {1, 2};
		[NonSerialized]
		public Vector3[] a2 = {new Vector3(1, 2, 3), new Vector3(4, 5, 6)};
		[NonSerialized]
		public MyStruct[] a3 = {new MyStruct(1, 2), new MyStruct(3, 4)};
		[NonSerialized]
		public MyEnum[] a4 = {MyEnum.E1, MyEnum.E2};
		[NonSerialized]
		public decimal[] a5 = {1.00001M, 2.00002M};

		public float FloatParamMethod(float p) {
			return p;
		}

		public Vector3 Vector3ParamMethod(Vector3 p) {
			return p;
		}

		public MyStruct StructParamMethod(MyStruct p) {
			return p;
		}

		public MyEnum EnumParamMethod(MyEnum p) {
			return p;
		}

		public decimal DecimalParamMethod(decimal p) {
			return p;
		}

		void Start() {
			//language=Lua
			luaEnv.DoString(@"
            function id(...)
                return ...
            end

            function add(a, b) return a + b end

            function array_exchange(arr)
                arr[0], arr[1] = arr[1], arr[0]
            end

            local v3 = CS.UnityEngine.Vector3(7, 8, 9)
            local vt = CS.LearnXLua.LuaDemo.NoGc.MyStruct(5, 6)

            function lua_access_csharp()
            	--NOTE 这个monoBehaviour从哪里来的？ 从后面有Set('monoBehaviour',this)
                monoBehaviour:FloatParamMethod(123) --primitive
                monoBehaviour:Vector3ParamMethod(v3) --vector3
                local rnd = math.random(1, 100)
                local r = monoBehaviour:Vector3ParamMethod({x = 1, y = 2, z = rnd}) --vector3
                assert(r.x == 1 and r.y == 2 and r.z == rnd)
                monoBehaviour:StructParamMethod(vt) --custom struct
                r = monoBehaviour:StructParamMethod({a = 1, b = rnd, e = {c = rnd}})
                assert(r.b == rnd and r.e.c == rnd)
                monoBehaviour:EnumParamMethod(CS.LearnXLua.LuaDemo.NoGc.MyEnum.E2) --enum
                monoBehaviour:DecimalParamMethod(monoBehaviour.a5[0])
                monoBehaviour.a1[0], monoBehaviour.a1[1] = monoBehaviour.a1[1], monoBehaviour.a1[0] -- field
            end

            exchanger = {
                exchange = function(self, arr)
                    array_exchange(arr)
                end
            }

            A = { B = { C = 789}}
            GDATA = 1234;
            ");

			luaEnv.Global.Set("monoBehaviour", this);

			luaEnv.Global.Get("id", out f1);
			luaEnv.Global.Get("id", out f2);
			luaEnv.Global.Get("id", out f3);
			luaEnv.Global.Get("id", out f4);
			luaEnv.Global.Get("id", out f5);

			luaEnv.Global.Get("array_exchange", out fArr);
			luaEnv.Global.Get("lua_access_csharp", out fLua);
			luaEnv.Global.Get("exchanger", out ie);
			luaEnv.Global.Get("add", out add);

			luaEnv.Global.Set("g_int", 123);
			luaEnv.Global.Set(123, 456);
			luaEnv.Global.Get("g_int", out int i);
			Debug.Log("g_int:" + i);
			luaEnv.Global.Get(123, out i);
			Debug.Log("123:" + i);
		}

		void Update() {
			// c# call lua function with value type but no gc (using delegate)
			f1(1); // primitive type
			f2(new Vector3(1, 2, 3)); // vector3
			MyStruct myStruct1 = new MyStruct(5, 6);
			f3(myStruct1); // custom complex value type
			f4(MyEnum.E1); //enum
			const decimal dec1 = -32132143143100109.00010001010M;
			f5(dec1); //decimal

			// using LuaFunction.Func<T1, T2, TResult>
			add.Func<int, int, int>(34, 56); // LuaFunction.Func<T1, T2, TResult>

			// lua access c# value type array no gc
			fArr(a1); //primitive value type array
			fArr(a2); //vector3 array
			fArr(a3); //custom struct array
			fArr(a4); //enum array
			fArr(a5); //decimal array

			// lua call c# no gc with value type
			fLua();

			//c# call lua using interface
			ie.Exchange(a2);

			//no gc LuaTable use
			luaEnv.Global.Set("g_int", 456);
			luaEnv.Global.Get("g_int", out int _);

			luaEnv.Global.Set(123.0001, myStruct1);
			luaEnv.Global.Get(123.0001, out MyStruct _);

			luaEnv.Global.Set((byte) 12, dec1);
			luaEnv.Global.Get((byte) 12, out decimal _);

			int gdata = luaEnv.Global.Get<int>("GDATA");
			luaEnv.Global.SetInPath("GDATA", gdata + 1);

			int abc = luaEnv.Global.GetInPath<int>("A.B.C");
			luaEnv.Global.SetInPath("A.B.C", abc + 1);

			luaEnv.Tick();
		}

		void OnDestroy() {
			//需要清空所有这些对象
			f1 = null;
			f2 = null;
			f3 = null;
			f4 = null;
			f5 = null;
			fArr = null;
			fLua = null;
			ie = null;
			add = null;
			luaEnv.Dispose();
		}
	}
}