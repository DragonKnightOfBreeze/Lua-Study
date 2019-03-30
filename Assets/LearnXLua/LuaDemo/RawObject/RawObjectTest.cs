/* Reformatted and refactored by @DragonKnightOfBreeze. */

using UnityEngine;
using XLua;

namespace LearnXLua.LuaDemo.RawObject {
	/// <summary>
	/// 展示当C#参数是object时，如何把一个lua number指定以boxing后的int传递过去。
	/// </summary>
	public class RawObjectTest : MonoBehaviour {
		public static void PrintType(object o) {
			Debug.Log($"type:{o.GetType()}, value:{o}");
		}

		void Start() {
			LuaEnv luaEnv = new LuaEnv();
			//直接传1234到一个object参数，xLua将选择能保留最大精度的long来传递
			//language=Lua
			luaEnv.DoString("CS.LearnXLua.LuaDemo.RawObject.RawObjectTest.PrintType(1234)");
			//通过一个继承RawObject的类，能实现指明以一个int来传递
			//language=Lua
			luaEnv.DoString("CS.LearnXLua.LuaDemo.RawObject.RawObjectTest.PrintType(CS.XLua.Cast.Int32(1234))");
			luaEnv.Dispose();
		}
	}
}