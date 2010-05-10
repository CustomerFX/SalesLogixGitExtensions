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
using System.Text;
using System.IO;
using System.Diagnostics;

namespace FX.SalesLogix.Modules.GitExtensions.Installer.Utility
{
    public enum FileComparison
    {
        Same = 0,
        Newer = 1, // File1 is newer than File2
        Older = 2, // File1 is older than File2
        Error = 3
    }

    public class FileHelper
    {
        public static FileComparison CompareFileVersions(string file1, string file2)
        {
            FileComparison retValue = FileComparison.Error;
            
            // Check if both files exist 
            if (!File.Exists(file1))
            {
                Console.WriteLine(file1 + " does not exist");
            }
            else if (!File.Exists(file2))
            {
                Console.WriteLine(file2 + " does not exist");
            }
            else
            {
                // Get the version information.
                FileVersionInfo file1Version = FileVersionInfo.GetVersionInfo(file1);
                FileVersionInfo file2Version = FileVersionInfo.GetVersionInfo(file2);

                Debug.WriteLine("Current file version " + file1Version.FileVersion + ", new file version " + file2Version.FileVersion);

                // Check major.
                if (file1Version.FileMajorPart > file2Version.FileMajorPart)
                {
                    Console.WriteLine(file1 + " is a newer version");
                    retValue = FileComparison.Newer;
                }
                else if (file1Version.FileMajorPart < file2Version.FileMajorPart)
                {
                    Console.WriteLine(file2 + " is a newer version");
                    retValue = FileComparison.Older;
                }
                else // Major version is equal, check next…
                {
                    // Check minor.
                    if (file1Version.FileMinorPart > file2Version.FileMinorPart)
                    {
                        Console.WriteLine(file1 + " is a newer version");
                        retValue = FileComparison.Newer;
                    }
                    else if (file1Version.FileMinorPart < file2Version.FileMinorPart)
                    {
                        Console.WriteLine(file2 + " is a newer version");
                        retValue = FileComparison.Older;
                    }
                    else // Minor version is equal, check next…
                    {
                        // Check build.
                        if (file1Version.FileBuildPart > file2Version.FileBuildPart)
                        {
                            Console.WriteLine(file1 + " is a newer version");
                            retValue = FileComparison.Newer;
                        }
                        else if (file1Version.FileBuildPart < file2Version.FileBuildPart)
                        {
                            Console.WriteLine(file2 + " is a newer version");
                            retValue = FileComparison.Older;
                        }
                        else // Build version is equal, check next…
                        {
                            // Check private.
                            if (file1Version.FilePrivatePart >
                                  file2Version.FilePrivatePart)
                            {
                                Console.WriteLine(file1 + " is a newer version");
                                retValue = FileComparison.Newer;
                            }
                            else if (file1Version.FilePrivatePart <
                                      file2Version.FilePrivatePart)
                            {
                                Console.WriteLine(file2 + " is a newer version");
                                retValue = FileComparison.Older;
                            }
                            else
                            {
                                // Identical versions
                                Console.WriteLine("The files have the same version");
                                retValue = FileComparison.Same;
                            }
                        }
                    }
                }
            }
            return retValue;
        }
    }
}
