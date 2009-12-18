﻿using System;
using System.Diagnostics;
using System.Net;
using System.IO;
using Microsoft.Win32;

namespace FX.SalesLogix.Modules.GitExtensions.Installer
{
    public delegate void ActionEventHandler(object source, ActionEventArgs e);

    public class InstallationAction
    {
        public int TotalSteps = 4;
        public event ActionEventHandler ActionEvent;

        private const string _FILEURL = "http://cloud.github.com/downloads/CustomerFX/SalesLogixGitExtensions/FX.SalesLogix.Modules.GitExtensions.dll";
        private const string _FILENAME = "FX.SalesLogix.Modules.GitExtensions.dll";

        private int _installstep = 0;

        public void Start()
        {
            RaiseInstallEvent("Initializing installation");
            if (CheckApplicationRunning())
            {
                RaiseInstallEvent("Application Architect is currently running. Close and try again.", TotalSteps);
                return;
            }

            RaiseInstallEvent("Downloading assembly from github");
            string file = DownloadFile();
            if (file == string.Empty) return;

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

            try
            {
                WebClient client = new WebClient();
                client.DownloadFile(_FILEURL, localfile);
            }
            catch (Exception ex)
            {
                localfile = string.Empty;
                RaiseInstallEvent("An error occurred downloading the assembly from github", TotalSteps);
            }

            return localfile;
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
                ElevatedCopy(file, Path.Combine(location, @"Modules\"));
                ElevatedCopy(file, Path.Combine(location, @"SalesLogix\"));
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

        private void RaiseInstallEvent(string description)
        {
            RaiseInstallEvent(description, _installstep);
        }

        private void RaiseInstallEvent(string description, int step)
        {
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
