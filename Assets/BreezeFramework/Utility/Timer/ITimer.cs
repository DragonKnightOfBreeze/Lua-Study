/*
 * Copyright (c) 2019.  DragonKnightOfBreeze Windea / 微风的龙骑士 风游迩
 * Email: dk_breeze@qq.com
 * A WindKid who has tamed the proud Ancient Dragon and led the wind of stories and tales.
 */

namespace BreezeFramework.Utility.Timer {
	/// <summary>计时器的接口.</summary>
	public interface ITimer {
		/// <summary>当前的运行状态。</summary>
		TimerState State { get; set; }

		/// <summary>更新计时。</summary>
		void Tick();

		/// <summary>开始计时。</summary>
		/// <param name="duration">此次计时的持续时间。</param>
		void Start(float duration);
	}
}
