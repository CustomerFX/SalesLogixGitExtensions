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

        public static string BashFile
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
                        object o = key.GetValue("gitbindir");
                        if (o != null)
                        {
                            path = o.ToString();
                            if (!Directory.Exists(o.ToString()))
                                path = string.Empty;
                            else
                                path = Path.Combine(path, "sh.exe");
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

        public static void Init()
        {
            try
            {
                ShellCommand("init");
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

        public static void ShellBash()
        {
            try
            {
                if (ExtensionsPath == string.Empty) throw new Exception("Git Extensions is not installed. Git Extensions must be installed to use Git Extensions for SalesLogix.");
                using (Process p = new Process())
                {
                    p.StartInfo.UseShellExecute = true;
                    p.StartInfo.FileName = "cmd.exe";
                    p.StartInfo.Arguments = "/c pushd \"" + WorkspaceConnector.ProjectPathRoot + "\" && \"" + ExtensionsConnector.BashFile + "\" --login -i";
                    p.Start();
                }
            }
            catch { throw; }
        }
    }
}

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
