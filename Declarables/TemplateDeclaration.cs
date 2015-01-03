using System;
using System.IO;
using System.Web;
using SuperScript.Declarables;

namespace SuperScript.Templates.Declarables
{
	/// <summary>
	/// </summary>
	public class TemplateDeclaration : DeclarationBase
	{
		private string _templatePath;

		/// <summary>
		/// Gets or sets the template markup.
		/// </summary>
		public string Template { get; set; }


		/// <summary>
		/// <para>Gets or sets the path to a file containing the template markup.</para>
		/// <para>The setter will retrieve the template markup from the specified path and assign this to <see cref="Template"/>.</para>
		/// <para>The setter will also set the <see cref="DeclarationBase.Name"/> property from the specified file name (without file extension).</para>
		/// </summary>
		/// <exception cref="FileNotFoundException">Thrown if the specified template file could not be found.</exception>
		public string Path
		{
			get { return _templatePath; }
			set
			{
				_templatePath = value;

				var fullPath = HttpContext.Current.Server.MapPath(value);

				if (!File.Exists(fullPath))
				{
					throw new FileNotFoundException("The specified template file could not be found.");
				}

				Template = File.ReadAllText(fullPath);
				Name = System.IO.Path.GetFileNameWithoutExtension(fullPath);
			}
		}


		/// <summary>
		/// Returns the contents as a JavaScript variable, i.e. <c>var [name] = "[template markup]";</c>.
		/// </summary>
		public override string ToString()
		{
			return String.Format("var {0} = \"{1}\";", Name, Template);
		}
	}
}