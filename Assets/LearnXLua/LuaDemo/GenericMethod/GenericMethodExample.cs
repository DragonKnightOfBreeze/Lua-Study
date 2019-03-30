using UnityEngine;
using XLua;

namespace LearnXLua.LuaDemo.GenericMethod {
    /// <summary>模拟泛型方法的例子。</summary>
    public class GenericMethodExample : MonoBehaviour {
	    //language=Lua
		private const string script = @"
        local foo1 = CS.LearnXLua.LuaDemo.GenericMethod.Foo1Child()
        local foo2 = CS.CS.LearnXLua.LuaDemo.GenericMethod.Foo2Child()

        local obj = CS.UnityEngine.GameObject()
        foo1:PlainExtension()
        foo1:Extension1()
        foo1:Extension2(obj) -- overload1
        foo1:Extension2(foo2) -- overload2
        
        local foo = CS.CS.LearnXLua.LuaDemo.GenericMethod.Foo()
        foo:Test1(foo1)
        foo:Test2(foo1,foo2,obj)
		";

		private LuaEnv env;

		private void Start() {
			env = new LuaEnv();
			env.DoString(script);
		}

		private void Update() {
			env.Tick();
		}

		private void OnDestroy() {
			env.Dispose();
		}
	}
}