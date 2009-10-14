/* Git Extensions Command Line Arguments

    browse
    add
    addfiles
    apply
    applypatch
    branch
    checkout
    checkoutbranch
    checkoutrevision
    init
    clone [path]
    commit
    filehistory [file]
    formatpatch
    pull
    push
    settings
    viewdiff
    rebase
    merge
    cherry
    tag
    stash

*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using Microsoft.Win32;

namespace FX.SalesLogix.Modules.GitExtensions.Connectors
{
    public class ExtensionsConnector
    {
        public static string Executable = "GitExtensions.exe";

        public static bool IsInstalled
        {
            get
            {
                return (ExtensionsPath != string.Empty);
            }
        }

        public static string ExtensionsFile
        {
            get
            {
                return Path.Combine(ExtensionsPath, Executable);
            }
        }

        public static string ExtensionsPath
        {
            get
            {
                string path = string.Empty;
                try
                {
                    RegistryKey key = null;
                    key = Registry.CurrentUser.OpenSubKey(@"Software\GitExtensions\GitExtensions\1.0.0.0", false);
                    if (key != null)
                    {
                        object o = key.GetValue("InstallDir");
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
        }

        public static void Show()
        {
            try
            {
                ShellCommand(null);
            }
            catch { throw; }
        }

        public static void Settings()
        {
            try
            {
                ShellCommand("settings");
            }
            catch { throw; }
        }

        public static void Commit()
        {
            try
            {
                ShellCommand("commit");
            }
            catch { throw; }
        }

        public static void Push()
        {
            try
            {
                ShellCommand("push");
            }
            catch { throw; }
        }

        public static void Pull()
        {
            try
            {
                ShellCommand("pull");
            }
            catch { throw; }
        }

        public static void Browse()
        {
            try
            {
                ShellCommand("browse");
            }
            catch { throw; }
        }

        public static void Stash()
        {
            try
            {
                ShellCommand("stash");
            }
            catch { throw; }
        }

        public static void Add()
        {
            try
            {
                ShellCommand("addfiles");
            }
            catch { throw; }
        }

        public static void Branch()
        {
            try
            {
                ShellCommand("branch");
            }
            catch { throw; }
        }

        public static void Checkout()
        {
            try
            {
                ShellCommand("checkout");
            }
            catch { throw; }
        }

        public static void Merge()
        {
            try
            {
                ShellCommand("merge");
            }
            catch { throw; }
        }

        public static void ViewChanges()
        {
            try
            {
                ShellCommand("viewdiff");
            }
            catch { throw; }
        }

        public static void ShellCommand(string command)
        {
            try
            {
                ShellCommand(command, null);
            }
            catch { throw; }
        }

        public static void ShellCommand(string command, string arg)
        {
            try
            {
                if (ExtensionsPath == string.Empty) throw new Exception("Git Extensions is not installed. Git Extensions must be installed to use Git Extensions for SalesLogix.");
                using (Process p = new Process())
                {
                    p.StartInfo.UseShellExecute = true;
                    p.StartInfo.FileName = ExtensionsConnector.ExtensionsFile;
                    p.StartInfo.WorkingDirectory = WorkspaceConnector.ProjectPathRoot;
                    if (command != null) p.StartInfo.Arguments = command + (arg == null ? string.Empty : " " + arg);
                    p.Start();
                }
            }
            catch { throw; }
        }
    }
}
