This project integrates Git Extensions into the SalesLogix Application Architect. <a href="http://cloud.github.com/downloads/CustomerFX/SalesLogixGitExtensions/GitExtensionsForSalesLogix.png">See a screenshot</a>.

To add to Application Architect, copy the assembly into the "C:\Program Files\SalesLogix\SalesLogix" folder and then edit the file "C:\Program Files\SalesLogix\AppConfig\SalesLogix.xml" and do the following:

<ol><li>Locate the &lt;Modules&gt; section
<li>Add the following line:<br><br>
<blockquote>&lt;Include ModuleName="FX.SalesLogix.Modules.GitExtensions.GitExtensionsInit, FX.SalesLogix.Modules.GitExtensions" /&gt;</blockquote></ol>

<a href="http://code.google.com/p/gitextensions/" target=_blank>Git Extensions</a> must also be installed.

Contact <a href="http://crmdeveloper.com/" target=_blank>Ryan Farley, Customer FX Corporation</a> for any information.<br>
<br>