/*
 * Copyright (c) 2019.  DragonKnightOfBreeze Windea / 微风的龙骑士 风游迩
 * Email: dk_breeze@qq.com
 *
 * A WindKid who has tamed the proud Ancient Dragon and led the wind of stories and tales.
 */

using System;

namespace BreezeFramework.Attributes {
	/// <summary>语言注入的特性。</summary>
	/// <summary>用于为目标字符串注明需要注入的语言。</summary>
	[AttributeUsage(AttributeTargets.Field|AttributeTargets.Property)]
	public class LanguageAttribute:Attribute{
	public LanguageAttribute(string language) {
		this.Language = language;
	}

	public string Language { get; }
}
}