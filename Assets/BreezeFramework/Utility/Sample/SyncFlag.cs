/*
 * Copyright (c) 2019.  DragonKnightOfBreeze Windea / 微风的龙骑士 风游迩
 * Email: dk_breeze@qq.com
 * A WindKid who has tamed the proud Ancient Dragon and led the wind of stories and tales.
 */

using System;

namespace BreezeFramework.Utility.Sample {
	/// <summary>同步标记（带有一个用作同步锁的字段）。</summary>
	public abstract class SyncFlag {
		/// <summary>同步锁。</summary>
		protected static readonly object syncLock = new object();

		/// <summary>空类型数组。</summary>
		protected static readonly Type[] emptyTypes = new Type[0];
	}
}
