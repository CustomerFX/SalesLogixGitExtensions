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
using System.Text;
using System.Windows.Forms;

namespace FX.SalesLogix.Modules.GitExtensions.Installer
{
    public partial class ProxySettings : Form
    {
        public ProxySettings()
        {
            InitializeComponent();
        }

        private void ProxyServer_Leave(object sender, EventArgs e)
        {
            if (ProxyServer.Text.Trim() == string.Empty)
                ProxyPort.Text = string.Empty;
        }

        private void CheckUseProxyAuth_CheckedChanged(object sender, EventArgs e)
        {
            labelProxyUser.Enabled = CheckUseProxyAuth.Checked;
            labelProxyPassword.Enabled = CheckUseProxyAuth.Checked;
            ProxyUser.Enabled = CheckUseProxyAuth.Checked;
            ProxyPassword.Enabled = CheckUseProxyAuth.Checked;

            if (!CheckUseProxyAuth.Checked)
            {
                ProxyUser.Text = string.Empty;
                ProxyPassword.Text = string.Empty;
            }
        }
    }
}
