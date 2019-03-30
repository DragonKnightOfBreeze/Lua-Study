/*
 * Copyright (c) 2019.  DragonKnightOfBreeze Windea / 微风的龙骑士 风游迩
 * Email: dk_breeze@qq.com
 * A WindKid who has tamed the proud Ancient Dragon and led the wind of stories and tales.
 */

using System;
using JetBrains.Annotations;

namespace BreezeFramework.Utility.Extensions {
	/// <summary>字符串的拓展类。</summary>
	public static class StringExtension {
		#region ［检验方法］

		/// <summary>对于当前的字符串，判断是否为null、空。</summary>
		/// <summary>空引用安全。</summary>
		public static bool IsEmpty([CanBeNull] this string tString) {
			return string.IsNullOrEmpty(tString);
		}

		/// <summary>对于当前的字符串，判断是否为null、空、空格。</summary>
		/// <summary>空引用安全。</summary>
		public static bool IsBlank([CanBeNull] this string tString) {
			return string.IsNullOrWhiteSpace(tString);
		}

		#endregion

		#region ［转化方法］

		/// <summary>对于当前的字符串，尝试转化成对应的枚举值。</summary>
		/// <summary>如果失败，则返回默认的枚举值。</summary>
		public static TEnum ToEnum<TEnum>([NotNull] this string tString, TEnum defaultValue)
			where TEnum : struct {
			try {
				bool isSuccess = Enum.TryParse(tString, false, out TEnum result);
				return isSuccess ? result : defaultValue;
			} catch (Exception e) {
				Console.WriteLine(e.StackTrace);
				return defaultValue;
			}
		}

		/// <summary>对于当前的字符串，尝试转化成对指定类型的对应的值。</summary>
		/// <summary>如果失败，则返回默认的指定类型的值。</summary>
		public static T ToT<T>([NotNull] this string tString, T defaultValue) where T : class {
			try {
				return (T) Convert.ChangeType(tString, typeof(T));
			} catch (Exception e) {
				Console.WriteLine(e.StackTrace);
				return defaultValue;
			}
		}

		#endregion
	}
}