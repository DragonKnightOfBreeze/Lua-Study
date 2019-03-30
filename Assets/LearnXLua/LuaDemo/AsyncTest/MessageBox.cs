/*
 * Tencent is pleased to support the open source community by making xLua available.
 * Copyright (C) 2016 THL A29 Limited, a Tencent company. All rights reserved.
 * Licensed under the MIT License (the "License"); you may not use this file except in compliance with the License. You may obtain a copy of the License at
 * http://opensource.org/licenses/MIT
 * Unless required by applicable law or agreed to in writing, software distributed under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the License for the specific language governing permissions and limitations under the License.
*/

/* Reformatted and refactored by @DragonKnightOfBreeze. */

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using XLua;
using Debug = System.Diagnostics.Debug;

namespace LearnXLua.LuaDemo.AsyncTest {
	/// <summary>信息框。</summary>
	public class MessageBox : MonoBehaviour {
		/// <summary>显示警告框。</summary>
		public static void ShowAlertBox(string message, string title, Action onFinished = null) {
			//得到信息框游戏对象，没有则新建
			var alertPanel = GameObject.Find("Canvas").transform.Find("AlertBox");
			if(alertPanel == null) {
				alertPanel = (Instantiate(Resources.Load("AlertBox")) as GameObject)?.transform;
				Debug.Assert(alertPanel != null, nameof(alertPanel) + " != null");
				alertPanel.gameObject.name = "AlertBox";
				alertPanel.SetParent(GameObject.Find("Canvas").transform);
				alertPanel.localPosition = new Vector3(-6f, -6f, 0f);
			}

			//得到相关文本和按键
			alertPanel.Find("title").GetComponent<Text>().text = title;
			alertPanel.Find("message").GetComponent<Text>().text = message;
			var button = alertPanel.Find("alertBtn").GetComponent<Button>();

			//点击事件，首先调用回调函数，然后移除所有监听器，然后禁用相关游戏对象
			void Onclick() {
				onFinished?.Invoke();
				button.onClick.RemoveAllListeners();
				alertPanel.gameObject.SetActive(false);
			}

			//防止消息框未关闭时多次被调用
			button.onClick.RemoveAllListeners();
			button.onClick.AddListener(Onclick);
			alertPanel.gameObject.SetActive(true);
		}

		/// <summary>显示确认框。</summary>
		public static void ShowConfirmBox(string message, string title, Action<bool> onFinished = null) {
			//得到确认框游戏对象，没有则新建
			var confirmPanel = GameObject.Find("Canvas").transform.Find("ConfirmBox");
			if(confirmPanel == null) {
				confirmPanel = (Instantiate(Resources.Load("ConfirmBox")) as GameObject)?.transform;
				Debug.Assert(confirmPanel != null, nameof(confirmPanel) + " != null");
				confirmPanel.gameObject.name = "ConfirmBox";
				confirmPanel.SetParent(GameObject.Find("Canvas").transform);
				confirmPanel.localPosition = new Vector3(-8f, -18f, 0f);
			}

			confirmPanel.Find("confirmTitle").GetComponent<Text>().text = title;
			confirmPanel.Find("confirmMsg").GetComponent<Text>().text = message;

			var confirmBtn = confirmPanel.Find("confirmBtn").GetComponent<Button>();
			var cancelBtn = confirmPanel.Find("cancelBtn").GetComponent<Button>();

			void Cleanup() {
				confirmBtn.onClick.RemoveAllListeners();
				cancelBtn.onClick.RemoveAllListeners();
				confirmPanel.gameObject.SetActive(false);
			}

			void OnConfirm() {
				onFinished?.Invoke(true);
				Cleanup();
			}

			void OnCancel() {
				onFinished?.Invoke(false);
				Cleanup();
			}

			//防止消息框未关闭时多次被调用
			confirmBtn.onClick.RemoveAllListeners();
			confirmBtn.onClick.AddListener(OnConfirm);
			cancelBtn.onClick.RemoveAllListeners();
			cancelBtn.onClick.AddListener(OnCancel);
			confirmPanel.gameObject.SetActive(true);
		}
	}

	/// <summary>信息框的设置，用于设置白名单。</summary>
	public static class MessageBoxConfig {
		[CSharpCallLua]
		public static List<Type> CSharpCallLua = new List<Type>{
			typeof(Action),
			typeof(Action<bool>),
			typeof(UnityAction)
		};
	}
}