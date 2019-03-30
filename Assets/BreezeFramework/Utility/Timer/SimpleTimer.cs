/*
 * Copyright (c) 2019.  DragonKnightOfBreeze Windea / 微风的龙骑士 风游迩
 * Email: dk_breeze@qq.com
 * A WindKid who has tamed the proud Ancient Dragon and led the wind of stories and tales.
 */

using UnityEngine;

namespace BreezeFramework.Utility.Timer {
	/// <summary>简单的计时器。</summary>
	public class SimpleTimer : ITimer {
		/// <summary>持续时间。</summary>
		private float durationTime;
		/// <summary>已经流逝的时间。</summary>
		private float elapsedTime;

		public TimerState State { get; set; }

		public void Tick() {
			switch(State) {
				case TimerState.NotRunning:
					break;
				case TimerState.Running:
					elapsedTime += Time.deltaTime;
					if(elapsedTime >= durationTime)
						State = TimerState.End;
					break;
				case TimerState.End:
					State = TimerState.NotRunning;
					break;
			}
		}

		public void Start(float duration) {
			durationTime = duration;
			elapsedTime = 0;
			State = TimerState.Running;
		}
	}
}
