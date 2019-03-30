/*
 * Copyright (c) 2019.  DragonKnightOfBreeze Windea / 微风的龙骑士 风游迩
 * Email: dk_breeze@qq.com
 * A WindKid who has tamed the proud Ancient Dragon and led the wind of stories and tales.
 */

using System;
using System.Reflection;

namespace BreezeFramework.Utility.Utils {
	/// <summary>反射的工具类。</summary>
	public static class ReflectionTool {
		/// <summary>绑定标记 普通的</summary>
		public static readonly BindingFlags flags_common = BindingFlags.Instance | BindingFlags.SetField |
			BindingFlags.GetField | BindingFlags.GetProperty | BindingFlags.SetProperty;
		/// <summary>绑定标记 公共的</summary>
		public static readonly BindingFlags flags_public = flags_common | BindingFlags.Public;
		/// <summary>绑定标记 非公共的</summary>
		public static readonly BindingFlags flags_nonpublic = flags_common | BindingFlags.NonPublic;
		/// <summary>绑定标记 所有的</summary>
		public static readonly BindingFlags flags_all = flags_common | BindingFlags.Public | BindingFlags.NonPublic;
		/// <summary>绑定标记 方法</summary>
		public static readonly BindingFlags flags_method = BindingFlags.InvokeMethod | BindingFlags.Public |
			BindingFlags.NonPublic;
		/// <summary>绑定标记 方法实例</summary>
		public static readonly BindingFlags flags_method_instance = flags_method | BindingFlags.Instance;
		/// <summary>绑定标记 静态方法</summary>
		public static readonly BindingFlags flags_method_static = flags_method | BindingFlags.Static;
		/// <summary>绑定标记 空的</summary>
		public static readonly Type[] empty_types = new Type[0];

		/// <summary>得到指定类型的构造器信息。</summary>
		/// <param name="bindingFlags">指定的绑定类型。</param>
		/// <param name="type">指定的类型。</param>
		/// <param name="types">指定的参数类型。</param>
		public static ConstructorInfo GetConstructorInfo(Type type, BindingFlags bindingFlags, Type[] types) {
			return type?.GetConstructor(bindingFlags, null, types, null);
		}

		/// <summary>创建指定类型的实例。</summary>
		/// <param name="type">指定的类型。</param>
		/// <param name="bindFlags">指定的绑定类型。</param>
		public static object CreateInstance(Type type, BindingFlags bindFlags) {
			ConstructorInfo rConstructorInfo = GetConstructorInfo(type, bindFlags, empty_types);
			return rConstructorInfo.Invoke(null);
		}

		/// <summary>调用指定类型的构造器。不带参数。</summary>
		/// <param name="type">指定的类型。</param>
		public static object Construct(Type type) {
			ConstructorInfo rConstructorInfo = GetConstructorInfo(type, flags_all, empty_types);
			return rConstructorInfo.Invoke(null);
		}

		/// <summary>调用指定类型构造器。带参数。</summary>
		/// <param name="type">指定的类型。</param>
		/// <param name="types">指定的参数类型。</param>
		/// <param name="param">指定的参数。</param>
		public static object Construct(Type type, Type[] types, params object[] param) {
			ConstructorInfo rConstructorInfo = GetConstructorInfo(type, flags_all, types);
			return rConstructorInfo.Invoke(null, param);
		}

		/// <summary>得到指定对象的指定成员。</summary>
		/// <param name="rObject">指定的对象。</param>
		/// <param name="rMemberName">指定成员的名字。</param>
		/// <param name="bindFlags">指定的绑定类型。</param>
		public static object GetAttrMember(object rObject, string rMemberName, BindingFlags bindFlags) {
			Type type = rObject?.GetType();
			return type?.InvokeMember(rMemberName, bindFlags, null, rObject, new object[]{});
		}

		/// <summary>设置指定对象的指定成员。</summary>
		/// <param name="rObject">指定的对象。</param>
		/// <param name="rMemberName">指定成员的名字。</param>
		/// <param name="bindFlags">指定的绑定类型。</param>
		/// <param name="param">指定的参数。</param>
		public static void SetAttrMember(object rObject, string rMemberName, BindingFlags bindFlags, params object[] param) {
			Type type = rObject?.GetType();
			type?.InvokeMember(rMemberName, bindFlags, null, rObject, param);
		}

		/// <summary>调用指定对象的指定方法。</summary>
		/// <param name="rObject">指定的对象。</param>
		/// <param name="rMemberName">指定方法的名字。</param>
		/// <param name="bindFlags">指定的绑定类型。</param>
		/// <param name="param">指定的参数。</param>
		public static object MethodMember(object rObject, string rMemberName, BindingFlags bindFlags, params object[] param) {
			Type type = rObject?.GetType();
			return type?.InvokeMember(rMemberName, bindFlags, null, rObject, param);
		}

		/// <summary>调用指定类型的指定方法。</summary>
		/// <param name="type">指定的类型。</param>
		/// <param name="rMemberName">指定方法的名字。</param>
		/// <param name="bindFlags">指定的绑定类型。</param>
		/// <param name="param">指定的参数。</param>
		public static object MethodMember(Type type, string rMemberName, BindingFlags bindFlags, params object[] param) {
			return type?.InvokeMember(rMemberName, bindFlags, null, null, param);
		}
	}
}