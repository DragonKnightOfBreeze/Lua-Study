/*
 * Copyright (c) 2019.  DragonKnightOfBreeze Windea / 微风的龙骑士 风游迩
 * Email: dk_breeze@qq.com
 * A WindKid who has tamed the proud Ancient Dragon and led the wind of stories and tales.
 */

namespace BreezeFramework.Utility.Extensions {
	/// <summary>布尔类型的拓展类。</summary>
	public static class BoolExtension {
		/// <summary>对于当前的bool值，判断是否为true。</summary>
		/// <summary>若是则返回m，否则返回n。</summary>
		public static float ToM_N(this bool tBool, float m, float n) {
			return tBool ? m : n;
		}

		/// <summary>对于当前的bool值，判断是否为true。</summary>
		/// <summary>若是则返回m，否则返回n。</summary>
		public static int ToM_N(this bool tBool, int m, int n) {
			return tBool ? m : n;
		}

		/// <summary>对于当前的bool值，判断是否为true。</summary>
		/// <summary>若是则返回m，否则返回n。</summary>
		public static int To1_0(this bool tBool) {
			return tBool ? 1 : 0;
		}
	}
}