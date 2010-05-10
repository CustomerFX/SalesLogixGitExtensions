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
using System.Windows.Forms;
using System.Reflection;
using System.Threading;
using System.Diagnostics;
using Microsoft.Win32;

namespace FX.SalesLogix.Modules.GitExtensions.Installer
{
    static class Program
    {
        public static bool AutoRun = false;

        [STAThread]
        static void Main(string[] args)
        {
            SetAppLocation();

            if (args.Length > 0 && args[0].ToLower() == "auto")
            {
                // Check is autoupdate is disabled
                Utility.InstallerSettings settings = Utility.InstallerSettingsSerializer.Deserialize();
                if (settings.DisableAutoUpdate)
                {
                    Debug.WriteLine("GitExtensionsInstaller: Exiting, autoupdate is disabled");
                    return;
                }

                // Pause for 2 seconds to allow Application Architect to close
                Thread.Sleep(2000);
                AutoRun = true;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

        private static void SetAppLocation()
        {
            try
            {
                RegistryKey key = null;
                key = Registry.CurrentUser.OpenSubKey(@"Software\Git Extensions for SalesLogix", true);
                if (key == null)
                {
                    key = Registry.CurrentUser.CreateSubKey(@"Software\Git Extensions for SalesLogix");
                }
                key.SetValue("InstallerLocation", Assembly.GetExecutingAssembly().Location);
            }
            catch { }
        }
    }
}
