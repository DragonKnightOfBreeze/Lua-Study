/*
 * Copyright (c) 2019.  DragonKnightOfBreeze Windea / 微风的龙骑士 风游迩
 * Email: dk_breeze@qq.com
 * A WindKid who has tamed the proud Ancient Dragon and led the wind of stories and tales.
 */

using JetBrains.Annotations;
using UnityEngine;

namespace BreezeFramework.Utility.Utils {
	/// <summary>颜色的工具类。</summary>
	public class ColorUtils {
		/// <summary>将32位颜色对象转换为64位颜色对象。</summary>
		public static Color ToColor(Color32 color32) {
			return Of(color32.r, color32.g, color32.b, color32.a);
		}

		/// <summary>根据指定的r、g、b、a值，得到对应的颜色对象。</summary>
		public static Color Of(int r, int g, int b, int a = 255) {
			return new Color(r / 255f, g / 255f, b / 255f, a / 255f);
		}

		/// <summary>根据指定的一定格式的字符串，得到对应的颜色对象。</summary>
		/// <summary>字符串的格式形如：#FFF、#FFFF、#FFFFFF或#FFFFFFFF。</summary>
		/// <summary>如果字符串的格式不正确，则返回白色。</summary>
		public static Color Of([NotNull] string colorStr) {
			int[] colorInts = {0, 0, 0, 255};
			switch(colorStr.Length) {
				case 4:
					for(int i = 0; i < 3; i++) {
						colorInts[i] = Get0XValue(colorStr[i + 1]) * 16 + Get0XValue(colorStr[i + 1]);
					}
					break;
				case 5:
					for(int i = 0; i < 4; i++) {
						colorInts[i] = Get0XValue(colorStr[i + 1]) * 16 + Get0XValue(colorStr[i + 1]);
					}
					break;
				case 7:
					//0->2,3  1->4,5  2->6,7
					for(int i = 0; i < 3; i++) {
						colorInts[i] = Get0XValue(colorStr[i * 2 + 2]) * 16 + Get0XValue(colorStr[i * 2 + 3]);
					}
					break;
				case 9:
					for(int i = 0; i < 4; i++) {
						colorInts[i] = Get0XValue(colorStr[i * 2 + 2]) * 16 + Get0XValue(colorStr[i * 2 + 3]);
					}
					break;
				default:
					Debug.LogWarning($"颜色格式错误：{colorStr}，默认返回白色。");
					return Color.white;
			}
			return Of(colorInts[0], colorInts[1], colorInts[2], colorInts[3]);
		}

		/// <summary>将指定的表示16进制数的字符转化为0-15之间的整数。</summary>
		/// <param name="value">表示16进制数的字符。自动限制在0-F之间。</param>
		public static int Get0XValue(char value) {
			int result = 0;
			if(value >= '0' && value <= '9') {
				result = value - '0';
			} else if(value >= 'A' && value <= 'F') {
				result = value - 'A' + 10;
			} else if(value >= 'a' && value <= 'f') {
				result = value - 'a' + 10;
			}
			return result;
		}
	}
}
