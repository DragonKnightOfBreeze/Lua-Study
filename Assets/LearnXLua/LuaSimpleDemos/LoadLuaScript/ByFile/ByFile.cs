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

namespace LearnXLua.LuaSimpleDemos.LoadLuaScript.ByFile {
	public class ByFile : MonoBehaviour {
		LuaEnv luaEnv;

		void Start() {
			luaEnv = new LuaEnv();
			luaEnv.LoadString("require 'byFile'");
		}

		void Update() {
			//NOTE Update方法必定在Start方法之后调用，这时不可能为空
			luaEnv.Tick();
		}

		void OnDestroy() {
			luaEnv.Dispose();
		}
	}
}