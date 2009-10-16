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
using Sage.Platform.Projects;
using Sage.Platform.Projects.Interfaces;

namespace FX.SalesLogix.Modules.GitExtensions.Connectors
{
    public class WorkspaceConnector
    {
        public static IProjectContextService ProjectContextService = null;

        public static bool IsExportedModel
        {
            get
            {
                ProjectWorkspace workspace = ProjectContextService.ActiveProject.ProjectWorkspace;
                return !workspace.WorkingPath.ToLower().StartsWith("vfs");
            }
        }

        public static string ProjectPath
        {
            get
            {
                ProjectWorkspace workspace = ProjectContextService.ActiveProject.ProjectWorkspace;
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

        public static bool IsRepository
        {
            get
            {
                return Directory.Exists(Path.Combine(ProjectPathRoot, ".git"));
            }
        }
    }
}
