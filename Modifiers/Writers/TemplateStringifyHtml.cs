using System;
using System.Web;
using SuperScript.Modifiers;
using SuperScript.Modifiers.Writers;

namespace SuperScript.Templates.Modifiers.Writers
{
	public class TemplateStringifyHtml : HtmlWriter
	{
		public override IHtmlString Process(PostModifierArgs args)
		{
			return new HtmlString(String.Format("<script type=\"text/html\">\n{0}\n</script>", args.Emitted.Trim()));
		}
	}
}