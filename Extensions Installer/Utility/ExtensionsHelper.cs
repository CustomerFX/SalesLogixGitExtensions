using System;
using System.IO;
using Microsoft.Win32;

namespace FX.SalesLogix.Modules.GitExtensions.Installer.Utility
{
    public class ExtensionsHelper
    {
        public static string GitExtensionsUrl = "http://code.google.com/p/gitextensions/";
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
    }
}
