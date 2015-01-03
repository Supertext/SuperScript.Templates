using System;
using SuperScript.Templates.Declarables;

namespace SuperScript.Templates.Exceptions
{
	/// <summary>
	/// An <see cref="Exception"/> indicating that an instance of <see cref="TemplateDeclaration"/> has already been declared with the same Name property.
	/// </summary>
	public class DuplicateTemplateException : SuperScriptException
	{
		/// <summary>
		/// Constructor for <see cref="DuplicateTemplateException"/> which allows an exception-specific message to be relayed to the developer.
		/// </summary>
		public DuplicateTemplateException(string message)
			: base(message)
		{
		}


		public DuplicateTemplateException()
			: base("An instance of TemplateDeclaration has already been declared with the same Name property.")
		{
		}
	}


	/// <summary>
	/// An <see cref="Exception"/> indicating that information required for a <see cref="TemplateDeclaration"/> has not been specified.
	/// </summary>
	public class MissingTemplateInformationException : SuperScriptException
	{
		/// <summary>
		/// Constructor for <see cref="MissingTemplateInformationException"/> which allows an exception-specific message to be relayed to the developer.
		/// </summary>
		public MissingTemplateInformationException(string message)
			: base(message)
		{
		}


		public MissingTemplateInformationException()
			: base("Information required for a correct TemplateDeclaration has not been specified.")
		{
		}
	}
}