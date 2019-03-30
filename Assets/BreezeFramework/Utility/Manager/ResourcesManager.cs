/*
 * Copyright (c) 2019.  DragonKnightOfBreeze Windea / 微风的龙骑士 风游迩
 * Email: dk_breeze@qq.com
 * A WindKid who has tamed the proud Ancient Dragon and led the wind of stories and tales.
 */

using System;
using System.Collections;
using BreezeFramework.Utility.Sample;
using UnityEngine;
using Object = UnityEngine.Object;

namespace BreezeFramework.Utility.Manager {
	/// <summary>简单的资源加载管理器。</summary>
	public class ResourcesMgr : Singleton<ResourcesMgr>, IDisposable {
		/// <summary>资源缓存的哈希表。</summary>
		private readonly Hashtable cacheHashtable = new Hashtable();

		/// <summary>根据指定的资源路径，加载指定类型的对应的资源，然后返回。</summary>
		/// <param name="useCache">是否启用缓存。</param>
		public T LoadResource<T>(string path, bool useCache = true) where T : Object {
			if(cacheHashtable.Contains(path)) {
				return cacheHashtable[path] as T;
			}
			var tResource = Resources.Load<T>(path);
			if(tResource == null) {
				Debug.LogError($"找不到要加载的资源。指定的资源路径：{path}。");
			} else if(useCache) {
				cacheHashtable.Add(path, tResource);
			}
			return tResource;
		}

		/// <summary>根据指定的资源路径，加载对应的游戏对象，然后返回一个克隆的游戏对象。</summary>
		/// <param name="useCache">是否启用缓存。</param>
		public GameObject LoadAsset(string path, bool useCache = true) {
			var go = LoadResource<GameObject>(path, useCache);
			var goClone = Object.Instantiate(go);
			if(goClone == null) {
				Debug.LogError($"找不到要加载的游戏对象。指定的游戏对象路径：{path}。");
			}
			return goClone;
		}

		/// <summary>释放资源。</summary>
		public void Dispose() {
			cacheHashtable.Clear();
			Resources.UnloadUnusedAssets();
		}
	}
}
