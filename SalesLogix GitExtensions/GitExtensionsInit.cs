using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Windows.Forms;
using System.IO;
using log4net;
using Sage.Platform;
using Sage.Platform.Application;
using Sage.Platform.Application.UI;
using Sage.Platform.Projects;
using Sage.Platform.Projects.Interfaces;

namespace FX.SalesLogix.Modules.GitExtensions
{
    public class GitExtensionsInit : ModuleInit<UIWorkItem>, IModuleConfigurationProvider
    {
        public const string AdminWorkItemID = "9D4BB197-6FBC-4bf4-AAF5-7EE958603EDE";

        private IProjectContextService _projectContextService;
        private static readonly ILog _log = LogManager.GetLogger("FX.Modules");

        public override string ToString()
        {
            return GitExtensionResources.ModuleName;
        }

        public ModuleConfiguration GetConfiguration()
        {
            return ModuleConfiguration.LoadFromResource("FX.SalesLogix.Modules.GitExtensions.FX.SalesLogix.Modules.GitExtensions.Configuration.xml", base.GetType().Assembly);
        }

        [CommandHandler("cmd://GitExtensionsModule/GitCommit")]
        public void GitCommit_Click(object sender, EventArgs e)
        {
            ProjectWorkspace workspace = _projectContextService.ActiveProject.ProjectWorkspace;
            MessageBox.Show("Workspace Type: " + (workspace.WorkingPath.ToLower().StartsWith("vfs") ? "VFS" : "File System") + "\r\nName: " + workspace.Name + "\r\nPath: " + workspace.WorkingPath);
        }

        [CommandHandler("cmd://GitExtensionsModule/GitPull")]
        public void GitPull_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Pull");
        }

        [CommandHandler("cmd://GitExtensionsModule/GitPush")]
        public void GitPush_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Push");
        }

        [CommandHandler("cmd://GitExtensionsModule/GitSettings")]
        public void GitSettings_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Settings");
        }

        [CommandHandler("cmd://GitExtensionsModule/GitExtensions")]
        public void GitExtensions_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Launch Git Extensions");
        }

        [ServiceDependency]
        public IProjectContextService ProjectContextService
        {
            get
            {
                return this._projectContextService;
            }
            set
            {
                this._projectContextService = value;
            }
        }

        protected override void Configure(XmlElement xmlConfig)
        {
        }

        protected override void Load()
        {
            _log.Info("Loading Git Extensions for SalesLogix");
        }
    }
}
