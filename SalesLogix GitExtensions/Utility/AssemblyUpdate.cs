using System;
using System.IO;
using System.Diagnostics;
using Microsoft.Win32;

namespace FX.SalesLogix.Modules.GitExtensions.Utility
{
    public class AssemblyUpdate
    {
        public static void Start()
        {
            try
            {
                string file = InstallerLocation;
                if (file != string.Empty)
                {
                    Process p = new Process();
                    p.StartInfo.UseShellExecute = true;
                    p.StartInfo.FileName = file;
                    p.StartInfo.Arguments = "AUTO";
                    p.Start();
                }
            }
            catch { }
        }

        public static string InstallerLocation
        {
            get
            {
                string path = string.Empty;
                try
                {
                    RegistryKey key = null;
                    key = Registry.CurrentUser.OpenSubKey(@"Software\Git Extensions for SalesLogix", false);
                    if (key != null)
                    {
                        object o = key.GetValue("InstallerLocation");
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
