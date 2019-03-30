/* Reformatted and refactored by @DragonKnightOfBreeze. */

using UnityEngine;
using XLua;

namespace LearnXLua.LuaDemo.Coroutine {
	/// <summary>
	/// 协程测试，战士lua协程如何和Unity协程相结合。
	/// </summary>
	public class CoroutineTest : MonoBehaviour {
		LuaEnv luaEnv;

		void Start() {
			luaEnv = new LuaEnv();
			//language=Lua
			luaEnv.DoString("require 'coruntine_test'");
		}

		void Update() {
			luaEnv.Tick();
		}

		void OnDestroy() {
			luaEnv.Dispose();
		}
	}
}