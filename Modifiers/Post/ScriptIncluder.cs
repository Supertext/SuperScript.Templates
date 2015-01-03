using System;
using System.IO;
using System.Web;
using SuperScript.Modifiers;
using SuperScript.Modifiers.Post;
using SuperScript.Templates.Modifiers.Arguments;

namespace SuperScript.Templates.Modifiers.Post
{
	public class ScriptIncluder : CollectionPostModifier
	{
		private string _scriptPath;


		#region Properties

		protected internal string ScriptContents { get; set; }


		/// <summary>
		/// Gets or sets the path for the script file.
		/// </summary>
		public string ScriptPath
		{
			get { return _scriptPath; }
			set
			{
				_scriptPath = value;

				var fullPath = HttpContext.Current.Server.MapPath(value);

				if (File.Exists(fullPath))
				{
					_scriptPath = fullPath;
					ScriptContents = File.ReadAllText(fullPath);
				}
			}
		}

		#endregion


		/// <summary>
		/// Executes this instance of <see cref="CollectionPostModifier"/> upon the specified <see cref="PostModifierArgs"/>.
		/// </summary>
		/// <param name="args">An instance of <see cref="PostModifierArgs"/> which contains the data for this modifier.</param>
		/// <returns>An instance of <see cref="PostModifierArgs"/> which is expected to be a modified version of the input argument.</returns>
		public override PostModifierArgs Process(PostModifierArgs args)
		{
			if (!String.IsNullOrWhiteSpace(ScriptContents))
			{
				args.Emitted = ScriptContents + "\n" + args.Emitted;
			}
			else
			{
				var templateArgs = args as TemplatePostModifierArgs;
				if (templateArgs != null && !String.IsNullOrWhiteSpace(templateArgs.ScriptContents))
				{
					args.Emitted = templateArgs.ScriptContents + "\n" + args.Emitted;
				}
			}

			return args;
		}
	}
}