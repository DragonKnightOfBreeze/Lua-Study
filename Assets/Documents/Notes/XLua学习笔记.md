# 需要注意的地方

## XLua的使用方法的简单示例

```c#
public class ByString : MonoBehaviour {
	LuaEnv luaEnv;

	void Start() 
		//lua虚拟机建议全局唯一
		luaEnv = new LuaEnv();
		//使用lua虚拟机加载lua代码片段
		luaEnv.DoString("print('hello world')");
		//使用lua虚拟机加载单独的lua脚本
		//建议整个程序只加载main.lua，然后在main.lua里面加载其他脚本
		//luaEnv.DoString("require 'byFile'");
		
		//自定义lua加载器 
		//lua加载器委托的定义： public delegate byte[] CustomLoader(ref string filepath);
        //调用方法： public void LuaEnv.AddLoader(CustomLoader loader);
	}

	void Update() {
		//NOTE Update方法必定在Start方法之后调用，这时不可能为空
		luaEnv.Tick();
	}

	void OnDestroy() {
		luaEnv.Dispose();
	}
}
```