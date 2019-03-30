using System.IO;
using UnityEngine;
using XLua;

namespace LearnXLua.LuaDemo.SignatureLoader {
	/// <summary>展示如何读取经数字签名的lua脚本 。</summary>
	public class SignatureLoaderTest : MonoBehaviour {
		public static string PUBLIC_KEY =
			"BgIAAACkAABSU0ExAAQAAAEAAQBVDDC5QJ+0uSCJA+EysIC9JBzIsd6wcXa+FuTGXcsJuwyUkabwIiT2+QEjP454RwfSQP8s4VZE1m4npeVD2aDnY4W6ZNJe+V+d9Drt9b+9fc/jushj/5vlEksGBIIC/plU4ZaR6/nDdMIs/JLvhN8lDQthwIYnSLVlPmY1Wgyatw==";

		void Start() {
			LuaEnv luaEnv = new LuaEnv();
#if UNITY_EDITOR
			//关键就是自定义一个SignatureLoader并且注册，使用公共key和一个CustomLoader来作为参数
			luaEnv.AddLoader(new XLua.SignatureLoader(PUBLIC_KEY, (ref string filepath) => {
				filepath = Application.dataPath + "/LearnXLua/LuaDemo/SignatureLoader/" + filepath.Replace('.', '/') + ".lua";
				if(File.Exists(filepath)) {
					return File.ReadAllBytes(filepath);
				}
				return null;
			}));

#else
			//为了让手机也能测试
			luaEnv.AddLoader(new XLua.SignatureLoader(PUBLIC_KEY, (ref string filepath) => {
				filepath = filepath.Replace('.', '/') + ".lua";
				TextAsset file = (TextAsset) Resources.Load(filepath);
				if(file != null) {
					return file.bytes;
				} else {
					return null;
				}
			}));
#endif
			//language=Lua
			luaEnv.DoString(@"
            require 'signatured1'
            require 'signatured2'
			");
			luaEnv.Dispose();
		}
	}
}