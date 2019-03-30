/* Reformatted and refactored by @DragonKnightOfBreeze. */

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using XLua;

namespace LearnXLua.LuaDemo.Coroutine {
	public class Coroutine_Runner : MonoBehaviour { }

	/// <summary>协程的设置，用于设置白名单。</summary>
	public static class CoroutineConfig {
		[LuaCallCSharp]
		public static List<Type> LuaCallCSharp => new List<Type>{
			typeof(WaitForSeconds),
			//UnityEngine.WWW已过时，使用UnityEngine.Networking.UnityWebRequest
			typeof(UnityWebRequest)
		};
	}
}