/*
 * Copyright (c) 2019.  DragonKnightOfBreeze Windea / 微风的龙骑士 风游迩
 * Email: dk_breeze@qq.com
 * A WindKid who has tamed the proud Ancient Dragon and led the wind of stories and tales.
 */

using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace BreezeFramework.Utility.Extensions {
	/// <summary>游戏对象的拓展类。</summary>
	public static class GameObjectExtension {
		private const string Msg_GmeObjectNotFound = "找不到指定的游戏对象！";
		private const string Msg_ComponentNotFound = "找不到指定游戏对象上的对应组件！尝试为该游戏对象添加一个默认的组件。";

		#region ［查询子游戏对象］

		/// <summary>对于当前的游戏对象，查询指定名字的子游戏对象，然后返回。</summary>
		/// <summary>如果查询失败，则返回null。</summary>
		/// <summary>输出：是否存在查询到的结果。</summary>
		[CanBeNull]
		public static GameObject GetChild([NotNull] this GameObject tGo, [NotNull] string name, out bool hasResult) {
			hasResult = false;
			Transform child = tGo.transform.Find(name);
			if(child != null) {
				hasResult = true;
				return child.gameObject;
			}
			Debug.LogWarning(Msg_GmeObjectNotFound);
			return null;
		}

		/// <summary>对于当前的游戏对象，遍历查询指定名字的子游戏对象，然后返回。</summary>
		/// <summary>如果查询失败，则返回null。</summary>
		/// <summary>输出：是否存在查询到的结果。</summary>
		[CanBeNull]
		public static GameObject GetChildInAll([NotNull] this GameObject tGo, [NotNull] string name, out bool hasResult) {
			hasResult = false;
			foreach(GameObject child in tGo.transform) {
				//如果遍历查询到，就直接返回，否则继续遍历
				if(name == child.name) {
					hasResult = true;
					return child;
				}
				GetChildInAll(child, name, out hasResult);
			}
			Debug.LogWarning(Msg_GmeObjectNotFound);
			return null;
		}

		/// <summary>对于当前的游戏对象，查询指定标签名的子游戏对象，然后返回。</summary>
		/// <summary>如果查询失败，则返回null。</summary>
		/// <summary>输出：是否存在查询到的结果。</summary>
		[CanBeNull]
		public static GameObject GetChildByTag([NotNull] this GameObject tGo, [NotNull] string tagName, out bool hasResult) {
			hasResult = false;
			foreach(GameObject child in tGo.transform) {
				if(child.CompareTag(tagName)) {
					hasResult = true;
					return child;
				}
			}
			Debug.LogWarning(Msg_GmeObjectNotFound);
			return null;
		}

		/// <summary>对于当前的游戏对象，查询指定标签名的所有的子游戏对象，然后返回其组成的数组。</summary>
		/// <summary>如果查询失败，则返回null。</summary>
		/// <summary>输出：是否存在查询到的结果。</summary>
		[CanBeNull]
		public static GameObject[] GetChildrenByTag([NotNull] this GameObject tGo, [NotNull] string tagName,
			out bool hasResult) {
			hasResult = false;
			List<GameObject> list = new List<GameObject>();
			foreach(GameObject child in tGo.transform) {
				if(child.CompareTag(tagName)) {
					hasResult = true;
					list.Add(child);
				}
			}
			if(list.Count != 0) {
				return list.ToArray();
			}
			Debug.LogWarning(Msg_GmeObjectNotFound);
			return null;
		}

		/// <summary>对于当前的游戏对象，遍历查询指定标签名的子游戏对象，然后返回。</summary>
		/// <summary>如果查询失败，则返回null。</summary>
		/// <summary>输出：是否存在查询到的结果。</summary>
		[CanBeNull]
		public static GameObject GetChildByTagInAll([NotNull] this GameObject tGo, [NotNull] string tagName,
			out bool hasResult) {
			hasResult = false;
			foreach(GameObject child in tGo.transform) {
				if(child.CompareTag(tagName)) {
					hasResult = true;
					return child;
				}
				GetChildByTagInAll(child, tagName, out hasResult);
			}
			Debug.LogWarning(Msg_GmeObjectNotFound);
			return null;
		}

		/// <summary>对于当前的游戏对象，遍历查询指定标签名的所有的子游戏对象，然后返回其组成的数组。</summary>
		/// <summary>如果查询失败，则返回null。</summary>
		/// <summary>输出：是否存在查询到的结果。</summary>
		[CanBeNull]
		public static GameObject[] GetChildrenByTagInAll([NotNull] this GameObject tGo, [NotNull] string tagName,
			out bool hasResult) {
			hasResult = false;
			List<GameObject> list = new List<GameObject>();
			foreach(GameObject child in tGo.transform) {
				if(child.CompareTag(tagName)) {
					hasResult = true;
					list.Add(child);
				}
				GetChildByTagInAll(child, tagName, out hasResult);
			}
			if(list.Count != 0) {
				return list.ToArray();
			}
			Debug.LogWarning(Msg_GmeObjectNotFound);
			return null;
		}

		#endregion

		#region ［查询父游戏对象］

		/// <summary>对于当前的游戏对象，查询对应的父游戏对象，然后返回。</summary>
		/// <summary>如果查询失败，则返回null。</summary>
		/// <summary>输出：是否存在查询到的结果。</summary>
		[CanBeNull]
		public static GameObject GetParent([NotNull] this GameObject tGo, out bool hasResult) {
			hasResult = false;
			Transform parent = tGo.transform.parent;
			if(parent != null) {
				hasResult = true;
				return parent.gameObject;
			}
			Debug.LogWarning(Msg_GmeObjectNotFound);
			return null;
		}


		/// <summary>对于当前的游戏对象，遍历查询指定名字的父游戏对象，然后返回。</summary>
		/// <summary>如果查询失败，则返回null。</summary>
		/// <summary>输出：是否存在查询到的结果。</summary>
		[CanBeNull]
		public static GameObject GetParentInAll([NotNull] this GameObject tGo, [NotNull] string name, out bool hasResult) {
			hasResult = false;
			Transform parent = tGo.transform.parent;
			while(parent != null && parent.name != name) {
				parent = tGo.transform.parent;
			}
			if(parent != null) {
				hasResult = true;
				return parent.gameObject;
			}
			Debug.LogWarning(Msg_GmeObjectNotFound);
			return null;
		}

		/// <summary>对于当前的游戏对象，遍历查询指定标签名的父游戏对象，然后返回。</summary>
		/// <summary>如果查询失败，则返回null。</summary>
		/// <summary>输出：是否存在查询到的结果。</summary>
		[CanBeNull]
		public static GameObject GetParentByTagInAll([NotNull] this GameObject tGo, [NotNull] string tagName, out bool hasResult) {
			hasResult = false;
			Transform parent = tGo.transform.parent;
			while(parent != null && !parent.CompareTag(tagName)) {
				parent = tGo.transform.parent;
			}
			if(parent != null) {
				hasResult = true;
				return parent.gameObject;
			}
			Debug.LogWarning(Msg_GmeObjectNotFound);
			return null;
		}

		/// <summary>对于当前的游戏对象，遍历查询指定名字的所有的父游戏对象，然后返回其组成的数组。</summary>
		/// <summary>如果查询失败，则返回null。</summary>
		/// <summary>输出：是否存在查询到的结果。</summary>
		[CanBeNull]
		public static GameObject[] GetParentsByTagInAll([NotNull] this GameObject tGo, [NotNull] string tagName, out bool hasResult) {
			hasResult = false;
			List<GameObject> list = new List<GameObject>();
			Transform parent = tGo.transform.parent;
			while(parent != null && !parent.CompareTag(tagName)) {
				parent = tGo.transform.parent;
			}
			if(parent != null) {
				hasResult = true;
				list.Add(parent.gameObject);
			}
			if(list.Count != 0) {
				return list.ToArray();
			}
			Debug.LogWarning(Msg_GmeObjectNotFound);
			return null;
		}

		#endregion

		#region ［查询组件］


		/// <summary>对于当前的游戏对象，得到绑定的指定类型的组件，然后返回。</summary>
		/// <summary>如果查询失败，则添加一个默认的指定类型的组件并返回。</summary>
		/// <summary>输出：是否存在查询到的结果。</summary>
		[NotNull]
		public static T GetComponentSafely<T>([NotNull] this GameObject tGo, out bool hasResult) where T : Component {
			hasResult = false;
			T component = tGo.GetComponent<T>();
			if(component != null) {
				hasResult = true;
				return component;
			}
			Debug.LogWarning(Msg_ComponentNotFound);
			return tGo.AddComponent<T>();
		}

		/// <summary>对于当前的游戏对象，得到绑定的指定类型的所有组件，然后返回其组成的数组。</summary>
		/// <summary>如果查询失败，则添加一个默认的指定类型的组件并返回其组成的数组。</summary>
		/// <summary>输出：是否存在查询到的结果。</summary>
		[NotNull]
		public static T[] GetComponentsSafely<T>([NotNull] this GameObject tGo, out bool hasResult) where T : Component {
			hasResult = false;
			T[] components = tGo.GetComponents<T>();
			if(components != null && components.Length != 0) {
				hasResult = true;
				return components;
			}
			Debug.LogWarning(Msg_ComponentNotFound);
			return new[]{tGo.AddComponent<T>()};
		}

		#endregion
	}
}