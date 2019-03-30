/*
 * Copyright (c) 2019.  DragonKnightOfBreeze Windea / 微风的龙骑士 风游迩
 * Email: dk_breeze@qq.com
 * A WindKid who has tamed the proud Ancient Dragon and led the wind of stories and tales.
 */

using System.Collections.Generic;
using JetBrains.Annotations;

namespace BreezeFramework.Utility.Extensions {
	/// <summary>集合的拓展</summary>
	public static class CollectionExtension {
		#region ［检验方法］

		/// <summary>对于当前的集合，判断是否为null，为空。</summary>
		/// <summary>空引用安全。</summary>
		public static bool IsEmpty<T>([CanBeNull] this ICollection<T> tCollection) {
			return tCollection == null || tCollection.Count == 0;
		}

		/// <summary>对于当前的集合，判断是否为null，小于等于指定长度。</summary>
		/// <summary>空引用安全。</summary>
		public static bool IsLessE<T>([CanBeNull] this ICollection<T> tCollection, int count) {
			return tCollection == null || tCollection.Count <= count;
		}

		#endregion
	}
}
