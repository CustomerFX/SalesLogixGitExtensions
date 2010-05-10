/* 

    Git Extensions for SalesLogix
    Copyright (C) 2009  Customer FX Corporation - http://customerfx.com/

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.

    Contact Information:
    
    Ryan Farley 
    Customer FX Corporation
    http://customerfx.com/
    2324 University Avenue West, Suite 115
    Saint Paul, Minnesota 55114
    Tel: 651.646.7777  Fax: 651.846.5185
    
    This copyright must remain intact
    
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Reflection;

namespace FX.SalesLogix.Modules.GitExtensions.UI
{
    public partial class AboutDialog : Form
    {
        public AboutDialog()
        {
            InitializeComponent();
            this.Text = "About " + GitExtensionResources.ModuleName;
            this.labelTitle.Text = GitExtensionResources.ModuleName;

            labelVersion.Text = "Version " + FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).FileVersion;

            if (File.Exists(Path.Combine(Connectors.ExtensionsConnector.ExtensionsPath, "GitUI.DLL")))
            {
                //Assembly gitui = Assembly.LoadFile(Path.Combine(Connectors.ExtensionsConnector.ExtensionsPath, "GitUI.DLL"));
                //foreach (Type t in gitui.GetTypes())
                //{
                //    if (t.IsClass && t.Name.Contains("GitUIEventArgs"))
                //    {
                //        object obj = Activator.CreateInstance(t);
                //        object ver = t.InvokeMember("GetVersion", BindingFlags.Default | BindingFlags.GetProperty, null, obj, null);
                //        if (ver != null) labelGitExtVersion.Text = ver.ToString();
                //    }
                //}

                labelGitExtVersion.Text = FileVersionInfo.GetVersionInfo(Connectors.ExtensionsConnector.ExtensionsFile).FileVersion;
            }
            else
                labelGitExtVersion.Text = "Not installed";
        }

        private void labelVisitSite_Click(object sender, EventArgs e)
        {
            Process.Start("http://github.com/CustomerFX/SalesLogixGitExtensions");
        }

        private void labelVisitGitExtSite_Click(object sender, EventArgs e)
        {
            Process.Start("http://code.google.com/p/gitextensions/");
        }

        private void pictureCustomerFX_Click(object sender, EventArgs e)
        {
            Process.Start("http://customerfx.com/");
        }
    }
}
