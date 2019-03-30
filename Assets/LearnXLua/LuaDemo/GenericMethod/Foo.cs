/* Reformatted and refactored by @DragonKnightOfBreeze. */

using System;
using UnityEngine;
using XLua;

namespace LearnXLua.LuaDemo.GenericMethod {
	[LuaCallCSharp]
	public class Foo1Parent { }

	[LuaCallCSharp]
	public class Foo2Parent { }

	[LuaCallCSharp]
	public class Foo1Child : Foo1Parent { }

	[LuaCallCSharp]
	public class Foo2Child : Foo2Parent { }

	[LuaCallCSharp]
	public class Foo {
		//总结：每个泛型参数都必须要有合法的约束，且必须对应至少一个方法参数。

		#region Supported methods

		public void Test1<T>(T a) where T : Foo1Parent {
			Debug.Log($"Test1<{typeof(T)}>");
		}

		public T1 Test2<T1, T2>(T1 a, T2 b, GameObject c) where T1 : Foo1Parent where T2 : Foo2Parent {
			Debug.Log($"Test2<{typeof(T1)},{typeof(T2)}>", c);
			return a;
		}

		#endregion

		#region Unsupported methods

		/// <summary>不支持生成lua的泛型方法（没有泛型约束）</summary>
		public void UnsupportedMethod1<T>(T a) {
			Debug.Log("UnsupportedMethod1");
		}

		/// <summary>不支持生成lua的泛型方法（缺少带约束的泛型参数）</summary>
		public void UnsupportedMethod2<T>() where T : Foo1Parent {
			Debug.Log($"UnsupportedMethod2<{typeof(T)}>");
		}

		/// <summary>不支持生成lua的泛型方法（泛型约束必须为class）</summary>
		public void UnsupportedMethod3<T>(T a) where T : IDisposable {
			Debug.Log($"UnsupportedMethod3<{typeof(T)}>");
		}

		#endregion
	}

	[LuaCallCSharp]
	public static class FooExtension {
		public static void PlainExtension(this Foo1Parent a) {
			Debug.Log("PlainExtension");
		}

		public static T Extension1<T>(this T a) where T : Foo1Parent {
			Debug.Log($"Extension1<{typeof(T)}>");
			return a;
		}

		public static T Extension2<T>(this T a, GameObject b) where T : Foo1Parent {
			Debug.Log($"Extension2<{typeof(T)}>", b);
			return a;
		}

		public static void Extension2<T1, T2>(this T1 a, T2 b) where T1 : Foo1Parent where T2 : Foo2Parent {
			Debug.Log($"Extension2<{typeof(T1)},{typeof(T2)}>");
		}

		public static T UnsupportedExtension<T>(this GameObject obj) where T : Component {
			return obj.GetComponent<T>();
		}
	}
}