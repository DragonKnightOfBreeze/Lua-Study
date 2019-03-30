/*
 * Copyright (c) 2019.  DragonKnightOfBreeze Windea / 微风的龙骑士 风游迩
 * Email: dk_breeze@qq.com
 * A WindKid who has tamed the proud Ancient Dragon and led the wind of stories and tales.
 */

using System;
using UnityEngine;
using Random = System.Random;

namespace BreezeFramework.Utility.Utils {
	/// <summary>随机数的工具类。</summary>
	public static class RandomUtils {
		private static Random random = new Random();

		/// <summary>设置随机对象的随机种子。</summary>
		public static void SetSeed(int seed) {
			random = new Random(seed);
		}

		/// <summary>生成指定范围内的随机数。包含上限和下限。从0开始。</summary>
		/// <param name="max">最大值。自动转化为不小于最小值的数。</param>
		public static int Range(int max) {
			return Range(0, max);
		}

		/// <summary>生成指定范围内的随机数。包含上限和下限。</summary>
		/// <param name="min">最小值。</param>
		/// <param name="max">最大值。自动转化为不小于最小值的数。</param>
		public static int Range(int min, int max) {
			max = Mathf.Max(min, max);

			return random.Next(min, max + 1);
		}

		/// <summary>生成指定范围内的指定精确度的随机数。包含上限和下限。从0开始。</summary>
		/// <param name="max">最大值。自动转化为不小于最小值的数。</param>
		/// <param name="precision">精确度。自动限制在0和10之间。</param>
		public static float Range(float max, int precision = 2) {
			return Range(0, max, precision);
		}

		/// <summary>生成指定范围内的指定精确度的随机数。包含上限和下限。</summary>
		/// <param name="min">最小值。</param>
		/// <param name="max">最大值。自动转化为不小于最小值的数。</param>
		/// <param name="precision">精确度。自动限制在0和10之间。</param>
		public static float Range(float min, float max, int precision = 2) {
			max = Mathf.Max(min, max);
			precision = Mathf.Clamp(precision, 0, 10);

			var powNum = (float) Math.Pow(10, precision);
			return Range((int) (min * powNum), (int) (max * powNum)) / powNum;
		}

		/// <summary>生成0到1之间的指定精确度的随机数。包含上限和下限。</summary>
		/// <param name="precision">精确度。自动限制在0和10之间。</param>
		public static float Range01(int precision = 2) {
			return Range(0, 1, precision);
		}

		/// <summary>生成浮动范围内的随机数。包含上限和下限。</summary>
		/// <param name="num">中心数值。</param>
		/// <param name="floatDown">向下浮动的数值。</param>
		/// <param name="floatUp">向上浮动的数值。</param>
		public static int Delta(int num, int floatDown, int floatUp) {
			return num - floatDown + Range(floatDown + floatUp);
		}

		/// <summary>生成浮动范围内的随机数。包含上限和下限。</summary>
		/// <param name="num">中心数值。</param>
		/// <param name="delta">向下/向上浮动的数值。</param>
		public static int Delta(int num, int delta) {
			return num - delta + Range(2 * delta);
		}

		/// <summary>生成浮动范围内的随机数。包含上限和下限。</summary>
		/// <param name="num">中心数值。</param>
		/// <param name="floatDown">向下浮动的数值。</param>
		/// <param name="floatUp">向上浮动的数值。</param>
		/// <param name="precision">精确度。自动限制在0和10之间。</param>
		public static float Delta(float num, float floatDown, float floatUp, int precision = 2) {
			return num - floatDown + Range(floatDown + floatUp, precision);
		}

		/// <summary>生成浮动范围内的随机数。包含上限和下限。</summary>
		/// <param name="num">中心数值。</param>
		/// <param name="delta">向下/向上浮动的数值。</param>
		/// <param name="precision">精确度。自动限制在0和10之间。</param>
		public static float Delta(float num, float delta, int precision = 2) {
			return num - delta + Range(2 * delta, precision);
		}
	}
}
