﻿/* 

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
using System.Threading;

namespace FX.SalesLogix.Modules.GitExtensions.Installer
{
    public partial class MainForm : Form
    {
        private object _lockobject = new object();
        private InstallationAction _action;

        public MainForm()
        {
            InitializeComponent();

            panelNoGitExt.Visible = (!Utility.ExtensionsHelper.IsInstalled);

            Utility.InstallerSettings settings = Utility.InstallerSettingsSerializer.Deserialize();
            checkDisableAutoUpdates.Checked = settings.DisableAutoUpdate;

            if (Program.AutoRun)
            {
                this.Hide(); this.Visible = false;
                this.ShowInTaskbar = false;
                this.WindowState = FormWindowState.Minimized;
                notifyIcon1.Visible = true;
                notifyIcon1.BalloonTipClosed += new EventHandler(notifyIcon1_BalloonTipClosed);

                buttonStart_Click(null, EventArgs.Empty);
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            _action = new InstallationAction();
            _action.ActionEvent += new ActionEventHandler(this.InstallationActionEvent);

            Thread t = new Thread(new ThreadStart(_action.Start));
            t.Start();
        }

        private void InstallationActionEvent(object source, ActionEventArgs e)
        {
            lock (_lockobject)
            {
                Utility.ControlHelper.SetControlText(labelProgress, e.ActionDescription);

                if (!labelProgress.Visible) Utility.ControlHelper.SetControlVisible(labelProgress, true);
                if (!progressBar1.Visible) Utility.ControlHelper.SetControlVisible(progressBar1, true);

                if (e.ActionStep == _action.TotalSteps)
                {
                    Utility.ControlHelper.SetControlVisible(progressBar1, false);

                    if (!_action.AppArchitectRunningFailure)
                    {
                        if (notifyIcon1.Visible)
                        {
                            if (_action.AssemblyUpdated)
                                notifyIcon1.ShowBalloonTip(5000);
                            else
                                Utility.ControlHelper.CloseForm(this);
                        }
                        else
                        {
                            Utility.ControlHelper.SetControlVisible(buttonStart, false);
                            Utility.ControlHelper.SetControlText(buttonCancel, "Close");
                        }
                    }
                }
            }
        }

        void notifyIcon1_BalloonTipClosed(object sender, EventArgs e)
        {
            notifyIcon1.Visible = false;
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBoxCfx_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://customerfx.com/");
        }

        private void linkLabelGetGitExt_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(Utility.ExtensionsHelper.GitExtensionsUrl);
        }

        private void linkSetProxy_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (ProxySettings dlg = new ProxySettings())
            {
                Utility.InstallerSettings settings = Utility.InstallerSettingsSerializer.Deserialize();

                dlg.ProxyServer.Text = settings.ProxyServer;
                dlg.ProxyPort.Text = settings.ProxyPort;

                if (settings.ProxyUser != string.Empty)
                {
                    dlg.CheckUseProxyAuth.Checked = true;
                    dlg.ProxyUser.Text = settings.ProxyUser;
                    dlg.ProxyPassword.Text = settings.ProxyPassword;
                }

                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    settings.ProxyServer = dlg.ProxyServer.Text;
                    settings.ProxyPort = dlg.ProxyPort.Text;
                    if (dlg.CheckUseProxyAuth.Checked)
                    {
                        settings.ProxyUser = dlg.ProxyUser.Text;
                        settings.ProxyPassword = dlg.ProxyPassword.Text;
                    }
                    else
                    {
                        settings.ProxyUser = string.Empty;
                        settings.ProxyPassword = string.Empty;
                    }

                    Utility.InstallerSettingsSerializer.Serialize(settings);
                }
            }
        }

        private void checkDisableAutoUpdates_CheckedChanged(object sender, EventArgs e)
        {
            Utility.InstallerSettings settings = Utility.InstallerSettingsSerializer.Deserialize();
            settings.DisableAutoUpdate = checkDisableAutoUpdates.Checked;
            Utility.InstallerSettingsSerializer.Serialize(settings);
        }
    }
}
