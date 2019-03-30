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

namespace LearnXLua.LuaDemo.U3DScripting {
	[Serializable]
	public class Injection {
		public string name;
		public GameObject value;
	}

    /// <summary>展示怎么用lua来写MonoBehaviour。</summary>
    [LuaCallCSharp]
	public class LuaBehaviour : MonoBehaviour {
	    //需要通过Unity初始化，其文本资源即为对应的lua脚本
		public TextAsset luaScript;
		public Injection[] injections;

	    //all lua behaviour shared one luaEnv only!
		internal static LuaEnv luaEnv = new LuaEnv();
		internal static float lastGCTime;
	    //1 second
		internal const float GCInterval = 1;

		private Action luaStart;
		private Action luaUpdate;
		private Action luaOnDestroy;

		private LuaTable scriptEnv;

		void Awake() {
			//这是这个lua代码块的环境变量
			scriptEnv = luaEnv.NewTable();

			// 为每个脚本设置一个独立的环境，可一定程度上防止脚本间全局变量、函数冲突
			LuaTable meta = luaEnv.NewTable();
			//这个环境变量就是lua虚拟机的全局环境
			meta.Set("__index", luaEnv.Global);
			scriptEnv.SetMetaTable(meta);
			meta.Dispose();

			//绑定lua变量self到此脚本类
			scriptEnv.Set("self", this);
			foreach(var injection in injections) {
				scriptEnv.Set(injection.name, injection.value);
			}

			//从一个textAsset得到lua脚本，这个textAsset需要通过unity进行初始化
			luaEnv.DoString(luaScript.text, "LuaBehaviour", scriptEnv);

			//得到变量
			Action luaAwake = scriptEnv.Get<Action>("awake");
			scriptEnv.Get("start", out luaStart);
			scriptEnv.Get("update", out luaUpdate);
			scriptEnv.Get("onDestroy", out luaOnDestroy);

			luaAwake?.Invoke();
		}

		void Start() {
			luaStart?.Invoke();
		}

		void Update() {
			luaUpdate?.Invoke();
			if(Time.time - lastGCTime > GCInterval) {
				luaEnv.Tick();
				lastGCTime = Time.time;
			}
		}

		void OnDestroy() {
			luaOnDestroy?.Invoke();
			luaOnDestroy = null;
			luaUpdate = null;
			luaStart = null;
			scriptEnv.Dispose();
			injections = null;
		}
	}
}