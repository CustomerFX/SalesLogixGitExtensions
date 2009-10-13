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
            ShellCommand(null);
        }

        public static void Settings()
        {
            ShellCommand("settings");
        }

        public static void Commit()
        {
            ShellCommand("commit");
        }

        public static void Push()
        {
            ShellCommand("push");
        }

        public static void Pull()
        {
            ShellCommand("pull");
        }

        private static void ShellCommand(string command)
        {
            ShellCommand(command, null);
        }

        private static void ShellCommand(string command, string arg)
        {
            using (Process p = new Process())
            {
                p.StartInfo.UseShellExecute = true;
                p.StartInfo.FileName = ExtensionsConnector.ExtensionsFile;
                p.StartInfo.WorkingDirectory = WorkspaceConnector.ProjectPathRoot;
                if (command != null) p.StartInfo.Arguments = command + (arg == null ? string.Empty : " " + arg);
                p.Start();
            }
        }
    }
}
