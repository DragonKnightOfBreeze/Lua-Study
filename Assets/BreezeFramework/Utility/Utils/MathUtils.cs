/*
 * Copyright (c) 2019.  DragonKnightOfBreeze Windea / 微风的龙骑士 风游迩
 * Email: dk_breeze@qq.com
 * A WindKid who has tamed the proud Ancient Dragon and led the wind of stories and tales.
 */

using System;
using UnityEngine;

namespace BreezeFramework.Utility.Utils {
	/// <summary>数学的工具类。</summary>
	public static class MathUtils {
		/// <summary>将单精度浮点数值精确到指定的位数。</summary>
		/// <param name="precision">精确度。自动限制在0和10之间。</param>
		public static float RoundByBit(float num, int precision = 2) {
			precision = Mathf.Clamp(precision, 0, 10);
			float powNum = (float) Math.Pow(10, precision);
			int intNum = (int) Math.Round(num * powNum);
			return intNum / powNum;
		}

		/// <summary>将双精度浮点值精确到指定的位数。</summary>
		/// <param name="precision">精确度。自动限制在0和10之间。</param>
		public static double RoundByBit(double num, int precision = 2) {
			precision = Mathf.Clamp(precision, 0, 10);
			double powNum = Math.Pow(10, precision);
			int intNum = (int) Math.Round(num * powNum);
			return intNum / powNum;
		}
	}
}
