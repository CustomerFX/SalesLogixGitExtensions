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
        public int TotalSteps = 5;
        public event ActionEventHandler ActionEvent;

        // Github is doing some caching and is returning old versions of the file
        // so changing to my own location for now
        //private const string _FILEURL = "http://cloud.github.com/downloads/CustomerFX/SalesLogixGitExtensions/FX.SalesLogix.Modules.GitExtensions.dll";
        private const string _FILEURL = "http://www.cfxconnect.com/applications/saleslogixgitextensions/FX.SalesLogix.Modules.GitExtensions.dll";
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
                WebClient client = new WebClient();
                
                WebProxy proxy = GetWebProxy();
                if (proxy != null) client.Proxy = proxy;
                
                client.CachePolicy = new RequestCachePolicy(RequestCacheLevel.NoCacheNoStore);
                client.DownloadFile(string.Format("{0}?q={0}", _FILEURL, Environment.TickCount), localfile);                
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
            try
            {
                RegistryKey key = null;
                key = Registry.LocalMachine.OpenSubKey(@"Software\SalesLogix", false);
                if (key != null)
                {
                    object o = key.GetValue("Path");
                    if (o != null)
                    {
                        path = o.ToString();
                        if (!Directory.Exists(o.ToString())) path = string.Empty;
                    }
                }
            }
            catch { }
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
