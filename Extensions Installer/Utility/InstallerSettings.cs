﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace FX.SalesLogix.Modules.GitExtensions.Installer.Utility
{
    [Serializable]
    public class InstallerSettings
    {
        public string FullProxyAddress
        {
            get
            {
                if (this.ProxyServer.Trim() != string.Empty)
                {
                    return string.Format("{0}{1}{2}{3)",
                        (this.ProxyServer.Trim().StartsWith("http") ? string.Empty : "http://"),
                        this.ProxyServer,
                        (this.ProxyPort.Trim() == string.Empty ? string.Empty : ":"),
                        this.ProxyPort).Trim();
                }
                else
                    return null;
            }
        }

        private string _proxyserver = string.Empty;
        public string ProxyServer
        {
            get { return this._proxyserver; }
            set { this._proxyserver = value; }
        }

        private string _proxyport = string.Empty;
        public string ProxyPort
        {
            get { return this._proxyport; }
            set { this._proxyport = value; }
        }

        private string _proxyuserencrypted = string.Empty;
        public string ProxyUserEncrypted
        {
            get { return this._proxyuserencrypted; }
            set { this._proxyuserencrypted = value; }
        }

        [XmlIgnore]
        public string ProxyUser
        {
            get
            {
                return SecurityUtility.DESDecrypt(this.ProxyUserEncrypted);
            }
            set
            {
                this.ProxyUserEncrypted = SecurityUtility.DESEncrypt(value);
            }
        }

        private string _proxypasswordencrypted = string.Empty;
        public string ProxyPasswordEncrypted
        {
            get { return this._proxypasswordencrypted; }
            set { this._proxypasswordencrypted = value; }
        }

        [XmlIgnore]
        public string ProxyPassword
        {
            get
            {
                return SecurityUtility.DESDecrypt(this.ProxyPasswordEncrypted);
            }
            set
            {
                this.ProxyPasswordEncrypted = SecurityUtility.DESEncrypt(value);
            }
        }

        private bool _disableautoupdate = false;
        public bool DisableAutoUpdate
        {
            get { return this._disableautoupdate; }
            set { this._disableautoupdate = value; }
        }
    }

    public class InstallerSettingsSerializer
    {
        private InstallerSettingsSerializer() { }

        public static string FileName = string.Empty;

        public static void Serialize(InstallerSettings settings)
        {
            try
            {
                XmlSerializer xs = new XmlSerializer(typeof(InstallerSettings));
                StringWriter s = new StringWriter();

                XmlWriter xw = new XmlTextWriter(s);
                xs.Serialize(xw, settings);
                xw.Close();

                writeFile(s.ToString());
            }
            catch
            {
                throw;
            }
        }

        public static InstallerSettings Deserialize()
        {
            InstallerSettings settings = null;
            try
            {
                XmlSerializer xs = new XmlSerializer(typeof(InstallerSettings));
                StringReader r = new StringReader(readFile());

                XmlReader xr = new XmlTextReader(r);
                settings = (InstallerSettings)xs.Deserialize(xr);
            }
            catch
            {
                return new InstallerSettings();
            }

            return settings;
        }

        private static void writeFile(string text)
        {
            try
            {
                StreamWriter s = new StreamWriter(getFileName());
                s.Write(text);
                s.Close();
            }
            catch { }
        }

        private static string readFile()
        {
            try
            {
                StreamReader s = new StreamReader(getFileName());
                string text = s.ReadToEnd();
                s.Close();

                return text;
            }
            catch
            {
                return string.Empty;
            }
        }

        private static string getFileName()
        {
            if (FileName == string.Empty)
                return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "gitextensionsinstaller_settings.xml");
            else
                return FileName;
        }
    }
}
