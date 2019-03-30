/*
 * Copyright (c) 2019.  DragonKnightOfBreeze Windea / 微风的龙骑士 风游迩
 * Email: dk_breeze@qq.com
 * A WindKid who has tamed the proud Ancient Dragon and led the wind of stories and tales.
 */

using UnityEngine;

namespace BreezeFramework.Utility.Utils {
	/// <summary>游戏对象的工具类。</summary>
	public static class GameObjectUtils {
		/// <summary>锁定Y轴，根据指定的旋转速度，使指定的游戏对象转向目标游戏对象。</summary>
		/// <param name="rotationSpeed">旋转速度。自动限制为非负数。</param>
		public static void FaceTo(GameObject selfGo, GameObject targetGo, float rotationSpeed) {
			var selfRotation = selfGo.transform.rotation;
			var targetRotation = targetGo.transform.rotation;
			var slerpToRotation = Quaternion.LookRotation(new Vector3(targetRotation.x, 0, targetRotation.z) -
				new Vector3(selfRotation.x, 0, selfRotation.z));
			selfRotation = Quaternion.Slerp(selfRotation, slerpToRotation, rotationSpeed);
			selfGo.transform.rotation = selfRotation;
		}
	}
}