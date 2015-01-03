using System.Collections.Generic;
using System.IO;
using System.Web;
using SuperScript.Declarables;
using SuperScript.Modifiers;
using SuperScript.Modifiers.Converters;
using SuperScript.Templates.Declarables;
using SuperScript.Templates.Modifiers.Arguments;

namespace SuperScript.Templates.Modifiers.Converters
{
	/// <summary>
	/// Converts the 'Declarations' property of the specified <see cref="PreModifierArgs"/> into an instance of <see cref="PostModifierArgs"/> 
	/// where the 'Emitted' property contains the output of the collated <see cref="TemplateDeclaration"/> objects.
	/// </summary>
	public abstract class TemplateStringify : CollectionConverter
	{
		private string _scriptPath;


		#region Properties

		/// <summary>
		/// Gets or sets whether the templates should be pre-compiled before being sent to the client.
		/// </summary>
		public bool PreCompile { get; set; }


		/// <summary>
		/// Gets or sets the contents of the JavaScript which enables the templating.
		/// </summary>
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

				var fullPath = value.StartsWith("~")
					               ? HttpContext.Current.Server.MapPath(value)
					               : value;

				if (File.Exists(fullPath))
				{
					_scriptPath = fullPath;
					ScriptContents = File.ReadAllText(fullPath);
				}
			}
		}

		#endregion


		/// <summary>
		/// Converts the specified <see cref="PreModifierArgs"/> into an instance of <see cref="PostModifierArgs"/>.
		/// </summary>
		/// <returns>An instance of <see cref="TemplatePostModifierArgs"/>, a derivation of <see cref="PostModifierArgs"/>.</returns>
		public override PostModifierArgs Process(PreModifierArgs args)
		{
			return new TemplatePostModifierArgs
				       {
					       CustomObject = args.CustomObject,
					       Emitted = CollateTemplates(args.Declarations),
					       ScriptContents = ScriptContents
				       };
		}


		/// <summary>
		/// <para>Enumerates each <see cref="TemplateDeclaration"/> and converts the declarations into a string.</para>
		/// <para>If <see cref="PreCompile"/> is <c>true</c> then pre-compilation should occur in this method.</para>
		/// </summary>
		/// <param name="declarations">
		/// A generic collection of <see cref="DeclarationBase"/> implementations. Only implementations which are of type 
		/// <see cref="TemplateDeclaration"/> will be considered.
		/// </param>
		protected abstract string CollateTemplates(IEnumerable<DeclarationBase> declarations);
	}
}