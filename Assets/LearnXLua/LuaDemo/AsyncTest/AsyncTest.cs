/*
 * Tencent is pleased to support the open source community by making xLua available.
 * Copyright (C) 2016 THL A29 Limited, a Tencent company. All rights reserved.
 * Licensed under the MIT License (the "License"); you may not use this file except in compliance with the License. You may obtain a copy of the License at
 * http://opensource.org/licenses/MIT
 * Unless required by applicable law or agreed to in writing, software distributed under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the License for the specific language governing permissions and limitations under the License.
*/

/* Reformatted and refactored by @DragonKnightOfBreeze. */

using UnityEngine;
using XLua;

namespace LearnXLua.LuaDemo.AsyncTest {
	/// <summary>异步测试，展示如何使用lua协程将异步逻辑同步化。</summary>
	public class AsyncTest : MonoBehaviour {
		LuaEnv luaEnv;

		void Start() {
			luaEnv = new LuaEnv();
			//language=Lua
			luaEnv.DoString("require 'async_test'");
		}

		void Update() {
			luaEnv.Tick();
		}

		private void OnDestroy() {
			luaEnv.Dispose();
		}
	}
}