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
