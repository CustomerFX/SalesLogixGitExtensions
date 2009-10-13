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
    }
}
