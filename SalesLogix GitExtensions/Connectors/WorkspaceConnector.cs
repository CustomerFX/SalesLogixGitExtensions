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
using System.Threading;
using Sage.Platform.Projects;
using Sage.Platform.Projects.Interfaces;

namespace FX.SalesLogix.Modules.GitExtensions.Connectors
{
    public class WorkspaceConnector
    {
        public static IProjectContextService ProjectContext = null;

        public static bool IsExportedModel
        {
            get
            {
                ProjectWorkspace workspace = ProjectContext.ActiveProject.ProjectWorkspace;
                return !workspace.WorkingPath.ToLower().StartsWith("vfs");
            }
        }

        public static string ProjectPath
        {
            get
            {
                ProjectWorkspace workspace = ProjectContext.ActiveProject.ProjectWorkspace;
                return workspace.WorkingPath;
            }
        }

        public static string ProjectPathRoot
        {
            get
            {
                string path = ProjectPath.TrimEnd(Path.DirectorySeparatorChar);
                if (path.ToLower().EndsWith("model")) path = path.Substring(0, path.Length - 5);
                return path;
            }
        }

        public static void OpenProjectFolder()
        {
            if (ProjectPathRoot != string.Empty)
                System.Diagnostics.Process.Start(ProjectPathRoot);
        }

        public static bool IsRepository
        {
            get
            {
                return Directory.Exists(Path.Combine(ProjectPathRoot, ".git"));
            }
        }

        public static bool HasGitIgnore
        {
            get
            {
                return File.Exists(Path.Combine(ProjectPathRoot, ".gitignore"));
            }
        }

        public static void Reload()
        {
            ProjectContext.ReloadActiveProject();
        }

        public static void AddStandardIgnore()
        {
            if (HasGitIgnore) return;

            using (StreamWriter writer = new StreamWriter(Path.Combine(ProjectPathRoot, ".gitignore")))
            {
                writer.WriteLine("# Files created from merge tools");
                writer.WriteLine("*.BASE");
                writer.WriteLine("*.LOCAL");
                writer.WriteLine("*.REMOTE");
                writer.WriteLine("*.orig");
                writer.WriteLine(writer.NewLine);

                writer.WriteLine("# Model files that are auto-generated");
                writer.WriteLine("[Mm]odel[Ii]ndex.xml");
                writer.WriteLine(writer.NewLine);

                writer.WriteLine("# Standard deployment files");
                writer.WriteLine("*/deployment/webroot/common/[Ss]mart[Pp]arts/**/*");
                writer.WriteLine("*/deployment/webroot/common/[Ss]mart[Pp]arts/**/**/*");
                writer.WriteLine("*/deployment/webroot/common/[Ss]ummary[Cc]onfig[Dd]ata/*");
                writer.WriteLine("*/deployment/webroot/common/bin/*");
                writer.WriteLine("*/deployment/webroot/common/*");
                writer.WriteLine("*/deployment/common/bin/[Ss]age.[Ee]ntity.[Ii]nterfaces.dll");
                writer.WriteLine("*/deployment/common/bin/[Ss]age.[Ff]orm.[Ii]nterfaces.dll");
                writer.WriteLine(writer.NewLine);

                writer.Close();
            }
        }
    }
}
