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
using System.Text;
using System.IO;
using System.Security.Cryptography;

namespace FX.SalesLogix.Modules.GitExtensions.Installer.Utility
{
    public class SecurityUtility
    {
        public static string MD5GetHash(string input)
        {
            MD5 md5Hasher = MD5.Create();
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));

            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }

        public static bool MD5VerifyHash(string input, string hash)
        {
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;
            return (0 == comparer.Compare(MD5GetHash(input), hash));
        }

        public static string DESEncrypt(string Value)
        {
            return DESEncrypt(Value, _ENCKEY);
        }

        public static string DESEncrypt(string Value, string Key)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();

            byte[] inputByteArray = Encoding.UTF8.GetBytes(Value);

            des.Key = ASCIIEncoding.ASCII.GetBytes(Key);
            des.IV = ASCIIEncoding.ASCII.GetBytes(Key);

            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();

            StringBuilder sb = new StringBuilder();
            foreach (byte b in ms.ToArray())
            {
                sb.AppendFormat("{0:X2}", b);
            }
            return sb.ToString();
        }

        public static string DESDecrypt(string Value)
        {
            return DESDecrypt(Value, _ENCKEY);
        }

        public static string DESDecrypt(string Value, string Key)
        {
            if (Value.Trim().Equals(string.Empty))
                return string.Empty;

            DESCryptoServiceProvider des = new DESCryptoServiceProvider();

            byte[] inputByteArray = new byte[Value.Length / 2];
            for (int x = 0; x < Value.Length / 2; x++)
            {
                int i = (Convert.ToInt32(Value.Substring(x * 2, 2), 16));
                inputByteArray[x] = (byte)i;
            }

            des.Key = ASCIIEncoding.ASCII.GetBytes(Key);
            des.IV = ASCIIEncoding.ASCII.GetBytes(Key);

            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();

            StringBuilder sb = new StringBuilder();
            foreach (byte b in ms.ToArray())
            {
                sb.Append((char)b);
            }
            return sb.ToString();
        }

        private const string _ENCKEY = "4Jkw9N3f";
    }
}
