/*
 * Copyright (c) 2019.  DragonKnightOfBreeze Windea / 微风的龙骑士 风游迩
 * Email: dk_breeze@qq.com
 * A WindKid who has tamed the proud Ancient Dragon and led the wind of stories and tales.
 */

using System;

namespace BreezeFramework.Attributes {
	/// <summary>Markdown注释的特性。</summary>
	/// <summary>用于为目标附加一段Markdown格式的注释。</summary>
	[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
	public class MarkdownAttribute : Attribute {
		public MarkdownAttribute(string value, bool useExtendSyntax = true, bool useCriticMarkup = false) {
			this.Value = value;
			this.UseExtendSyntax = useExtendSyntax;
			this.UseCriticMarkup = useCriticMarkup;
		}

		/// <summary>Markdown注释的内容。</summary>
		public string Value { get; }
		/// <summary>是否启用拓展语法。</summary>
		/// <summary>例如，启用下标语法`[^n]`。</summary>
		public bool UseExtendSyntax { get; }
		/// <summary>是否启用CriticMarkup语法。</summary>
		/// <summary>例如 ，删除语法{--text--}。</summary>
		public bool UseCriticMarkup { get; }
	}
}