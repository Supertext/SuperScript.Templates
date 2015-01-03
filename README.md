_**IMPORTANT NOTE:**_ This project is currently in beta and the documentation is currently incomplete. Please bear with us while the documentation is being written.

####SuperScript offers a means of declaring assets in one part of a .NET web solution and have them emitted somewhere else.


When developing web solutions, assets such as JavaScript declarations or HTML templates are frequently written in a location that differs from their desired output location.

For example, all JavaScript declarations should ideally be emitted together just before the HTML document is closed. And if caching is preferred then these declarations should be in an external file with caching headers set.

This is the functionality offered by SuperScript.



##Easily declare HTML Templates from anywhere in your project

`SuperScript.Templates` adds `TemplateDeclaration` to the types of `DeclarationBase`, as well as emitter modifiers.

This allows developers to declare an HTML template as an instance of `DeclarationBase`, though the advantages offered 
by `SuperScript.Templates` are better realised when used in conjunction with `SuperScript.Templates.Mvc` or 
`SuperScript.Templates.WebForms`.


##What's in this project?

Below is a list of some of the more important classes in the `SuperScript.Templates` project.

* `SuperScript.Templates.Declarables.TemplateDeclaration`

  Allows developers to declare HTML template, along with a name to be used client-side.

* Converters

  * `SuperScript.Templates.Modifiers.Converters.TemplateStringify`: Converts the 'Declarations' property of the specified 
  `PreModifierArgs` into an instance of `PostModifierArgs` where the 'Emitted' property contains the output of the 
  collated `TemplateDeclaration` object.
  
* Post Modifiers

  * `SuperScript.Templates.Modifiers.Post.ScriptIncluder`: Offers a simple method of including the client-side JavaScript
  file for rendering the HTML templates.

* Writers

  * `SuperScript.Templates.Modifiers.Writers.TemplateStringifyHtml`: Formats the HTML template into a client-side 
  &lt;script type="text/html"&gt; tag.
  
  * `SuperScript.Templates.Modifiers.Writers.TemplateStringifyJavaScript`: Formats the HTML template into a client-side 
  &lt;script type="text/javascript"&gt; tag.


##Dependencies
There are a variety of SuperScript projects, some being dependent upon others.

* [`SuperScript.Common`](https://github.com/Supertext/SuperScript.Common)

  This library contains the core classes which facilitate all other SuperScript modules but which won't produce any meaningful output on its own.
  

`SuperScript.Templates` has been made available under the [MIT License](https://github.com/Supertext/SuperScript.Templates/blob/master/LICENSE).
