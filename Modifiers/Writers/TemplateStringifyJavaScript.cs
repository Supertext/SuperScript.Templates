using System;
using System.Web;
using SuperScript.Modifiers;
using SuperScript.Modifiers.Writers;

namespace SuperScript.Templates.Modifiers.Writers
{
	public class TemplateStringifyJavaScript : HtmlWriter
	{
		public override IHtmlString Process(PostModifierArgs args)
		{
			return new HtmlString(String.Format("<script type=\"text/javascript\">\n{0}\n</script>", args.Emitted.Trim()));
		}
	}
}