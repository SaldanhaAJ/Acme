# About The Solution


This a "Helix" based solution, where the structure was created manually. 

More about Helix ..
	While there are a number of tools (
	e.g <a href="https://blog.marcduiker.nl/2016/12/29/hands-on-with-sitecore-helix-anatomy-add-helix-powershell-script.html">Add Helix PS Script</a> or 
	<a href="https://www.akshaysura.com/2017/01/21/habi-what-a-tat-create-a-sitecore-helix-solution-from-scratch-using-powershell/">Habi what-a-tat ? Create a Sitecore Helix solution from scratch using PowerShell</a>)
	 that enable the creation of the structure of a SiteCore Helix solution 

	It may be a good exercise to create an initial Helix solution as illustrated in this 
	video <a href="http://sitecoremaster.com/videos/developer-track/">Sitecore SetUp Project With Helix</a>;  His gitHub repo 
	can be found 
	<a href="https://github.com/sitecoremaster/Helix-Starter-Kit">here</a> which differs a bit from what he outlines in his video.


	The solution uses

		- Helix
		- MVC 5.2
		- .Net Framework 4.6.2
		- Sitecore 9.0.2
		- Unicorn 4.0.3 (??? Not yet)

## Installation

	Create a new Sitecore Site (in this case I created one called adhera.dev.local in c:\inetpub\wwwroot\adhera.dev.local)

	Clone this repository (c:\GitPublic\HelixExample in my case)

	Mofify the Publish settings of the projects to publish to the folder that houses your new SC site; or, you can move the DLLs and files
	manually.


	Import package exm08312018.zip (or whatever is the latest) into your SC instance. This will get the content and the files into your new 
	instance.




## Architecture

	The solution has  Foundation and a Project layer modules.

	The foundation layer includes modules for:
		Serialization using Unicorn (Epsilon.Foundation.Serialization) 
		SitecoreExtensions (Epsilon.Foundation.SitecoreExtensions) - has extension to the "Submit Button"  of forms.
			http://<sc instance>/SubscriptionForm/DoubleOptin - does out of the box EXM Double opt-in with data entered via 
			SC created form; some GUID values hard-coded and may have to modified. 
			
		Utilities/WebForms - During the "figuring" out stage it may be faster to work with Web Forms/ASPX pages 
			e.g
			http://<sc instance>/DoubleOptin.aspx - does out of the box EXM Double opt-in with some values hard-coded. 
			http://<sc instance>/AddContactToList.aspx - adds a contact to a list; GUID values are hard coded here which 
				you may have to change.
			
		Utilities/XconnectNonSC - Code for a non-SC client to connect via Xconnet
		

	The project layer contains one project, Example which contains the bare essentials needed.

## Build & Release

TBD

## Testing

TBD




## Extending

TBD

## Contribution

TBD

## Issues/Work-arounds
	When just using the gulp default task there was an issue with the Microsoft.Practices.ServiceLocation dll that landed up in the destination bin. So,
	a "special" directory was created in which the correct dll was kept. The file is copied over using the gulp task 
			gulp.task("copySpecial",
				function () {
					return gulp.src("./special/*.*")
					.pipe(gulp.dest(config.websiteRoot + "/bin"));
			});

	If Gulp is run without it you get the following error
		Could not load file or assembly 'Microsoft.Practices.ServiceLocation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35' or one of its dependencies. The located assembly's manifest definition does not match the assembly reference. (Exception from HRESULT: 0x80131040)
		Description: An unhandled exception occurred during the execution of the current web request. Please review the stack trace for more information about the error and where it originated in the code. "# Acme" 
