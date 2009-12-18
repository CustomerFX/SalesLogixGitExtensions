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

                if (!labelProgress.Visible)
                {
                    Utility.ControlHelper.SetControlVisible(labelProgress, true);
                    Utility.ControlHelper.SetControlVisible(progressBar1, true);
                }

                if (e.ActionStep == _action.TotalSteps)
                {
                    Utility.ControlHelper.SetControlVisible(progressBar1, false);
                    Utility.ControlHelper.SetControlVisible(buttonStart, false);
                    Utility.ControlHelper.SetControlText(buttonCancel, "Close");
                }
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
