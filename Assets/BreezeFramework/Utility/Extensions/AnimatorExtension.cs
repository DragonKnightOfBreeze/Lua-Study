/*
 * Copyright (c) 2019.  DragonKnightOfBreeze Windea / 微风的龙骑士 风游迩
 * Email: dk_breeze@qq.com
 * A WindKid who has tamed the proud Ancient Dragon and led the wind of stories and tales.
 */

using JetBrains.Annotations;
using UnityEngine;

namespace BreezeFramework.Utility.Extensions {
	/// <summary>动画状态机的拓展类。</summary>
	public static class AnimatorExtension {
		/// <summary>对于当前的动画状态机，根据指定的名字和层级名，检验当前的动画状态的名字。</summary>
		/// <summary>若是则返回true，否则返回false。</summary>
		public static bool CheckState([NotNull] this Animator tAnimator, [NotNull] string name, [NotNull] string layerName) {
			int layerIndex = tAnimator.GetLayerIndex(layerName);
			return tAnimator.GetCurrentAnimatorStateInfo(layerIndex).IsName(name);
		}

		/// <summary>对于当前的动画状态机，根据指定的标签名和层级名，检验当前的动画状态的标签。</summary>
		/// <summary>若是则返回true，否则返回false。</summary>
		public static bool CheckStateTag([NotNull] this Animator animator, [NotNull] string tagName,
			[NotNull] string layerName) {
			int layerIndex = animator.GetLayerIndex(tagName);
			return animator.GetCurrentAnimatorStateInfo(layerIndex).IsTag(layerName);
		}
	}
}
