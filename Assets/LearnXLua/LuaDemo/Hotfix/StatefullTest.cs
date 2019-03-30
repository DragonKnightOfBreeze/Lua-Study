/* Reformatted and refactored by @DragonKnightOfBreeze. */

using System;
using UnityEngine;
using XLua;

namespace LearnXLua.LuaDemo.Hotfix {
	[Hotfix]
	public class StatefullTest {
		public StatefullTest() { }

		public StatefullTest(int a, int b) {
			if(a > 0) {
				return;
			}

			Debug.Log("a=" + a);
			if(b > 0) {
				return;
			} else {
				if(a + b > 0) {
					return;
				}
			}
			Debug.Log("b=" + b);
		}

		public int AProp { get; set; }

		public event Action<int, double> AEvent;

		public int this[string field] {
			get => 1;
			set {}
		}

		public void Start() { }

		void Update() { }

		public void GenericTest<T>(T a) { }

		public static void StaticFunc(int a, int b) { }

		public static void StaticFunc(string a, int b, int c) { }

		~StatefullTest() {
			Debug.Log("~StatefullTest");
		}
	}
}