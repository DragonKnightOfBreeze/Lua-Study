/*
 * Copyright (c) 2019.  DragonKnightOfBreeze Windea / 微风的龙骑士 风游迩
 * Email: dk_breeze@qq.com
 * A WindKid who has tamed the proud Ancient Dragon and led the wind of stories and tales.
 */

namespace BreezeFramework.Utility.Sample {
	/// <summary>泛型单例类（带有无参构造方法）。</summary>
	/// <summary>通过继承该类来实现单例模式。</summary>
	public class Singleton<T> : SyncFlag where T : class, new() {
		private static T instance;

		/// <summary>类的单例。</summary>
		/// <summary>使用双重校验锁，线程安全。</summary>
		public static T Instance {
			get {
				if(instance == null) {
					lock(syncLock) {
						if(instance == null) {
							instance = new T();
						}
					}
				}
				return instance;
			}
		}
	}
}
