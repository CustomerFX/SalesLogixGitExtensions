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
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using Microsoft.Win32;
using log4net;
using System.Security.Permissions;
using System.ComponentModel;
using FX.SalesLogix.Modules.GitExtensions.Model;

namespace FX.SalesLogix.Modules.GitExtensions.Connectors
{
    public class ExtensionsConnector
    {
		private static readonly ILog _log = LogManager.GetLogger("GitExtensions");

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
                    key = Registry.CurrentUser.OpenSubKey(@"Software\GitExtensions", false);
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
				_log.Info("Extensions path: " + path);
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
                    key = Registry.CurrentUser.OpenSubKey(@"Software\GitExtensions", false);
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
				_log.Info("Bash path: " + path);
                return path;
            }
        }

		public static string GitCommand
		{
			get
			{
				string path = string.Empty;
				try
				{
					RegistryKey key = null;
					key = Registry.CurrentUser.OpenSubKey(@"Software\GitExtensions", false);
					if (key != null)
					{
						object o = key.GetValue("gitcommand");
						if (o != null)
						{
							path = o.ToString();
							if (!File.Exists(o.ToString())) path = string.Empty;
						}
					}
				}
				catch { }
				_log.Info("Git command: " + path);
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
				ShellCommand("init", "\"" + WorkspaceConnector.ProjectPathRoot, true);
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
                ShellCommand("pull", true);
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
                ShellCommand("checkout", true);

            }
            catch { throw; }
        }

        public static void Merge()
        {
            try
            {
                ShellCommand("merge", true);
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

        public static void EditGitIgnore()
        {
            try
            {
                ShellCommand("gitignore");
            }
            catch { throw; }
        }

        public static void ManageRemotes()
        {
            try
            {
                ShellCommand("remotes");
            }
            catch { throw; }
        }

		public static string GetCurrentBranch()
		{
			List<Branch> branches = GetBranches();
			foreach (Branch branch in branches)
				if (branch.Current) return branch.Name;

			return string.Empty;
		}

		public static List<Branch> GetBranches()
		{
			List<Branch> list = new List<Branch>();

			string branches = ShellGitCommand("branch");
			string[] branchStrings = branches.Split('\n');
			foreach (string branch in branchStrings)
			{
				list.Add(new Branch(branch.Trim('*', ' '), (branch.IndexOf('*') > -1)));
			}
			
			return list;
		}

        public static void ShellCommand(string command)
        {
            try
            {
                ShellCommand(command, null, false);
            }
            catch { throw; }
        }

        public static void ShellCommand(string command, bool wait)
        {
            try
            {
                ShellCommand(command, null, wait);
            }
            catch { throw; }
        }

        public static void ShellCommand(string command, string arg)
        {
            try
            {
                ShellCommand(command, null, false);
            }
            catch { throw; }
        }

        public static void ShellCommand(string command, string arg, bool wait)
        {
			try
			{
				_log.Info("Shell command " + command + " with args " + arg ?? string.Empty);
				
				if (ExtensionsPath == string.Empty) throw new Exception("Git Extensions is not installed. Git Extensions must be installed to use Git Extensions for SalesLogix.");
				using (Process p = new Process())
				{
					p.StartInfo.UseShellExecute = true;
					p.StartInfo.FileName = ExtensionsConnector.ExtensionsFile;
					p.StartInfo.WorkingDirectory = WorkspaceConnector.ProjectPathRoot;
					if (command != null) p.StartInfo.Arguments = command + (arg == null ? string.Empty : " " + arg);
					p.Start();
					if (wait) p.WaitForExit();
					_log.Info("Command " + command + " executed");
				}
			}
			catch (Exception ex)
			{
				_log.Error(ex.Message, ex);
				throw new Exception("Error executing command " + command + ".", ex);
			}
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

		[PermissionSetAttribute(SecurityAction.Demand, Name = "FullTrust")]
		public static string ShellGitCommand(string command)
		{
			try
			{
				string gitcmd = GitCommand;

				command = command.Replace("$QUOTE$", "\\\"");

				string output, error;
				CreateAndStartProcess(command, gitcmd, out output, out error);

				if (!string.IsNullOrEmpty(error))
				{
					output += Environment.NewLine + error;
				}
				_log.Info("Command " + command + " executed");
				return output;
			}
			catch (Win32Exception)
			{
				return string.Empty;
			}
		}

		private static void CreateAndStartProcess(string argument, string cmd)
		{
			string stdOutput, stdError;
			CreateAndStartProcess(argument, cmd, out stdOutput, out stdError);
		}

		private static void CreateAndStartProcess(string arguments, string cmd, out string stdOutput, out string stdError)
		{
			//process used to execute external commands

			var startInfo = CreateProcessStartInfo();
			startInfo.CreateNoWindow = true;
			startInfo.FileName = cmd;
			startInfo.Arguments = arguments;
			startInfo.WorkingDirectory = WorkspaceConnector.ProjectPathRoot;
			startInfo.LoadUserProfile = true;

			using (var process = Process.Start(startInfo))
			{
				stdOutput = process.StandardOutput.ReadToEnd();
				stdError = process.StandardError.ReadToEnd();
				process.WaitForExit();
			}
		}

		internal static ProcessStartInfo CreateProcessStartInfo()
		{
			return new ProcessStartInfo()
			{
				UseShellExecute = false,
				ErrorDialog = false,
				RedirectStandardOutput = true,
				RedirectStandardInput = true,
				RedirectStandardError = true,
				StandardOutputEncoding = new System.Text.UTF8Encoding(),
				StandardErrorEncoding = new System.Text.UTF8Encoding()
			};
		}
    }
}

