<img src="http://cloud.github.com/downloads/CustomerFX/SalesLogixGitExtensions/logo.png">

This project integrates Git Extensions into the SalesLogix Application Architect. <a href="http://cloud.github.com/downloads/CustomerFX/SalesLogixGitExtensions/GitExtensionsForSalesLogix_CompleteWithMenu.png">See a screenshot</a> or <a href="http://www.screencast.com/users/RyanFarley/folders/Default/media/3e0ce61c-9c83-4539-b26e-05b2e0c4476f" target=_blank>watch a video overview</a>.

<b>To add Git Extensions for SalesLogix to the Application Architect, complete the following steps:</b>

<ol><li><a href="http://cloud.github.com/downloads/CustomerFX/SalesLogixGitExtensions/FX.SalesLogix.Modules.GitExtensions.dll">Download the compiled assembly</a>
<li>Copy the FX.SalesLogix.Modules.GitExtensions.dll assembly into C:\Program Files\SalesLogix\SalesLogix
<li>Open the file "C:\Program Files\SalesLogix\AppConfig\SalesLogix.xml" in a text editor
<li>Locate the &lt;Modules&gt; section
<li>Add the following line:<br>
<blockquote>&lt;Include ModuleName="FX.SalesLogix.Modules.GitExtensions.GitExtensionsInit, FX.SalesLogix.Modules.GitExtensions" /&gt;</blockquote></ol>

<a href="http://code.google.com/p/gitextensions/" target=_blank>Git Extensions</a> must also be installed.

Contact <a href="http://crmdeveloper.com/" target=_blank>Ryan Farley, Customer FX Corporation</a> for any information.<br>
<br>