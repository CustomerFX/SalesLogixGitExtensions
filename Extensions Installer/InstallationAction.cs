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
using System.Diagnostics;
using System.Net;
using System.Net.Cache;
using System.IO;
using Microsoft.Win32;

namespace FX.SalesLogix.Modules.GitExtensions.Installer
{
    public delegate void ActionEventHandler(object source, ActionEventArgs e);

    public class InstallationAction
    {
        public bool AssemblyUpdated = false;
        public bool AppArchitectRunningFailure = false;
        public int TotalSteps = 6;
        public event ActionEventHandler ActionEvent;

        // Github is doing some caching and is returning old versions of the file
        // so changing to my own location for now
        //private const string _FILEURL = "http://cloud.github.com/downloads/CustomerFX/SalesLogixGitExtensions/FX.SalesLogix.Modules.GitExtensions.dll";
        private const string _FILEURL = "http://www.cfxconnect.com/applications/saleslogixgitextensions/FX.SalesLogix.Modules.GitExtensions.dll";
        private const string _FILEVERSONURL = "http://www.cfxconnect.com/applications/saleslogixgitextensions/CurrentVersion.txt";
        private const string _FILENAME = "FX.SalesLogix.Modules.GitExtensions.dll";

        private int _installstep = 0;

        public void Start()
        {
            _installstep = 0;

            RaiseInstallEvent("Initializing installation");
            if (CheckApplicationRunning())
            {
                AppArchitectRunningFailure = true;
                RaiseInstallEvent("Application Architect is currently running. Close and try again.", TotalSteps);
                return;
            }

            RaiseInstallEvent("Checking if new version is available");
            if (!CheckUpdateAvailable()) return;

            RaiseInstallEvent("Downloading assembly from github");
            string file = DownloadFile();
            if (file == string.Empty) return;

            RaiseInstallEvent("Checking installed file version");
            if (!NewFileVersionCheck(file)) return;

            RaiseInstallEvent("Installing assembly in Application Architect");
            if (!InstallFile(file)) return;

            RaiseInstallEvent("Installation complete!", TotalSteps);
        }

        private bool CheckApplicationRunning()
        {
            Process[] procs = Process.GetProcessesByName("SageAppArchitect");
            return (procs.Length > 0);
        }

        private bool CheckUpdateAvailable()
        {
            bool newavail = false;

            if (!File.Exists(Path.Combine(Path.Combine(GetSalesLogixRoot(), @"Modules\"), _FILENAME)))
                newavail = true;
            else
            {
                Version currentversion = new Version(FileVersionInfo.GetVersionInfo(Path.Combine(Path.Combine(GetSalesLogixRoot(), @"Modules\"), _FILENAME)).FileVersion);
                if (currentversion.CompareTo(GetAvailableFileVersion()) < 0) newavail = true;
            }

            if (newavail) RaiseInstallEvent("An update is available!");
            if (!newavail) RaiseInstallEvent("There is not a newer version available. You are already up to date", TotalSteps);

            return newavail;
        }

        private Version GetAvailableFileVersion()
        {
            Version availversion = new Version("1.0.0.0");

            try
            {
                using (WebClient client = new WebClient())
                {
                    WebProxy proxy = GetWebProxy();
                    if (proxy != null) client.Proxy = proxy;

                    client.CachePolicy = new RequestCachePolicy(RequestCacheLevel.NoCacheNoStore);
                    availversion = new Version(client.DownloadString(string.Format("{0}?q={0}", _FILEVERSONURL, Environment.TickCount)));
                }
            }
            catch { }

            return availversion;
        }

        private string DownloadFile()
        {
            string localfile = Path.Combine(Path.GetTempPath(), _FILENAME);
            Debug.WriteLine("GitExtensionsInstaller: Downloading to " + localfile);

            try
            {
                if (File.Exists(localfile)) File.Delete(localfile);
            }
            catch { }

            try
            {
                using (WebClient client = new WebClient())
                {
                    WebProxy proxy = GetWebProxy();
                    if (proxy != null) client.Proxy = proxy;

                    client.CachePolicy = new RequestCachePolicy(RequestCacheLevel.NoCacheNoStore);
                    client.DownloadFile(string.Format("{0}?q={0}", _FILEURL, Environment.TickCount), localfile);
                }
            }
            catch (Exception ex)
            {
                localfile = string.Empty;
                RaiseInstallEvent("An error occurred downloading the assembly from github. " + ex.Message, TotalSteps);
            }

            return localfile;
        }

        private bool NewFileVersionCheck(string file)
        {
            string slxfilelocation = Path.Combine(Path.Combine(GetSalesLogixRoot(), @"Modules\"), _FILENAME);
            if (!File.Exists(slxfilelocation)) return true;

            Utility.FileComparison filecompare = Utility.FileHelper.CompareFileVersions(slxfilelocation, file);
            if (filecompare != Utility.FileComparison.Older)
            {
                RaiseInstallEvent("Installed file is already up to date", TotalSteps);
                return false;
            }

            return true;
        }

        private bool InstallFile(string file)
        {
            string location = GetSalesLogixRoot();
            if (location == string.Empty)
            {
                RaiseInstallEvent("Cannot locate SalesLogix directory.", TotalSteps);
                return false;
            }

            try
            {
                try
                {
                    File.Copy(file, Path.Combine(location, @"Modules\" + _FILENAME), true);
                    File.Copy(file, Path.Combine(location, @"SalesLogix\" + _FILENAME), true);
                }
                catch { }

                if (!File.Exists(Path.Combine(location, @"Modules\" + _FILENAME)))
                    ElevatedCopy(file, Path.Combine(location, @"Modules\"));

                if (!File.Exists(Path.Combine(location, @"SalesLogix\" + _FILENAME)))
                    ElevatedCopy(file, Path.Combine(location, @"SalesLogix\"));

                AssemblyUpdated = true;
                return true;
            }
            catch (Exception ex)
            {
                RaiseInstallEvent("Failure copying files. " + ex.Message);
                return false;
            }
        }

        private void ElevatedCopy(string file, string location)
        {
            try
            {
                Process process = new Process();
                process.StartInfo.FileName = "cmd.exe";
                process.StartInfo.Arguments = "/c COPY \"" + file + "\" \"" + location + "\"";
                process.StartInfo.UseShellExecute = true;
                process.StartInfo.Verb = "runas";
                process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

                process.Start();
            }
            catch { throw; }
        }

        private string GetSalesLogixRoot()
        {
            string path = string.Empty;
            RegistryKey key = null;

            // Check 32-bit location
            try
            {
                key = Registry.LocalMachine.OpenSubKey(@"Software\SalesLogix", false);
                if (key != null)
                {
                    object o32 = key.GetValue("Path");
                    if (o32 != null)
                    {
                        path = o32.ToString();
                        if (!Directory.Exists(path)) path = string.Empty;
                    }
                }
            }
            catch { }

            //check 64-bit location
            if (path == string.Empty)
            {
                try
                {
                    key = Registry.LocalMachine.OpenSubKey(@"Software\Wow6432Node\SalesLogix", false);
                    if (key != null)
                    {
                        object o64 = key.GetValue("Path");
                        if (o64 != null)
                        {
                            path = o64.ToString();
                            if (!Directory.Exists(path)) path = string.Empty;
                        }
                    }
                }
                catch { }
            }

            return path;
        }

        private WebProxy GetWebProxy()
        {
            WebProxy proxy = null;

            Utility.InstallerSettings settings = Utility.InstallerSettingsSerializer.Deserialize();
            if (settings.FullProxyAddress != null)
            {
                proxy = new WebProxy(settings.FullProxyAddress);
                if (settings.ProxyUser != string.Empty)
                {
                    proxy.Credentials = new System.Net.NetworkCredential(settings.ProxyUser, settings.ProxyPassword);
                }
                System.Net.GlobalProxySelection.Select = proxy;
            }

            return proxy;
        }

        private void RaiseInstallEvent(string description)
        {
            RaiseInstallEvent(description, _installstep);
        }

        private void RaiseInstallEvent(string description, int step)
        {
            Debug.WriteLine("GitExtensionsInstaller: " + description);

            if (ActionEvent != null)
                ActionEvent(this, new ActionEventArgs(description, step));

            _installstep = step;
        }
    }

    public class ActionEventArgs : EventArgs
    {
        public ActionEventArgs() { }

        public ActionEventArgs(string Description, int Step)
        {
            this.ActionDescription = Description;
            this.ActionStep = Step;
        }

        public string ActionDescription = string.Empty;
        public int ActionStep = 0;
    }
}
