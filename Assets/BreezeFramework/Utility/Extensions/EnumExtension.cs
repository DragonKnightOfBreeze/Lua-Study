/*
 * Copyright (c) 2019.  DragonKnightOfBreeze Windea / 微风的龙骑士 风游迩
 * Email: dk_breeze@qq.com
 * A WindKid who has tamed the proud Ancient Dragon and led the wind of stories and tales.
 */

using System;
using JetBrains.Annotations;

namespace BreezeFramework.Utility.Extensions {
	/// <summary>枚举的拓展</summary>
	public static class EnumExtension {
		/// <summary>
		/// 默认的转化器。
		/// </summary>
		private static string DefaultConverter(string str) {
			string result = "";
			if(str.StartsWith("__", StringComparison.Ordinal)) {
				result = str.Substring(2);
			} else if(str.Contains("__")) {
				result = str.Replace("__", " ");
			} else if(str.Contains("SP")) {
				result = str.Replace("SP", "/");
			}
			return result;
		}

		/// <summary>对于当前的枚举值，得到对应的字符串。</summary>
		[NotNull]
		public static string Text([NotNull] this Enum tEnum) {
			string str = tEnum.ToString();
			return str;
		}

		/// <summary>对于当前的枚举值，根据指定的转化器，得到转换后的字符串。</summary>
		/// <remarks>默认转化器的说明：</remarks>
		/// <remarks>如果要以数字开头："__1Str" -> "1Str"；</remarks>
		/// <remarks>如果要包含空格："Str__Str" -> "Str Str"；</remarks>
		/// <remarks>如果要包含路径分隔符："StrSPStr" ->"Str/Str"。</remarks>
		[NotNull]
		public static string Val([NotNull] this Enum tEnum, [CanBeNull] Func<string,string> converter = null) {
			converter = converter ?? DefaultConverter;
			string str = tEnum.ToString();
			str = converter(str);
			return str;
		}
	}
}