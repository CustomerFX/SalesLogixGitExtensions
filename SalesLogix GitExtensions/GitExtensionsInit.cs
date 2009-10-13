using System;
using System.Xml;
using System.Windows.Forms;
using log4net;
using Sage.Platform.Application;
using Sage.Platform.Application.UI;
using Sage.Platform.Projects;
using Sage.Platform.Projects.Interfaces;
using FX.SalesLogix.Modules.GitExtensions.Connectors;

namespace FX.SalesLogix.Modules.GitExtensions
{
    public class GitExtensionsInit : ModuleInit<UIWorkItem>, IModuleConfigurationProvider
    {
        private const string _NOTEXPORTEDMODELMESSAGE = "This function is not available with a model in the VFS. Export your working model to work with source control.";

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
        public void GitCommitClick(object sender, EventArgs e)
        {
            if (WorkspaceConnector.IsExportedModel)
            {
                ExtensionsConnector.Commit();
            }
            else
                MessageBox.Show(_NOTEXPORTEDMODELMESSAGE);
        }

        [CommandHandler("cmd://GitExtensionsModule/GitPull")]
        public void GitPullClick(object sender, EventArgs e)
        {
            if (WorkspaceConnector.IsExportedModel)
            {
                ExtensionsConnector.Pull();
            }
            else
                MessageBox.Show(_NOTEXPORTEDMODELMESSAGE);
        }

        [CommandHandler("cmd://GitExtensionsModule/GitPush")]
        public void GitPushClick(object sender, EventArgs e)
        {
            if (WorkspaceConnector.IsExportedModel)
            {
                ExtensionsConnector.Push();
            }
            else
                MessageBox.Show(_NOTEXPORTEDMODELMESSAGE);
        }

        [CommandHandler("cmd://GitExtensionsModule/GitSettings")]
        public void GitSettingsClick(object sender, EventArgs e)
        {
            ExtensionsConnector.Settings();
        }

        [CommandHandler("cmd://GitExtensionsModule/GitExtensions")]
        public void GitExtensionsClick(object sender, EventArgs e)
        {
            ExtensionsConnector.Show();
        }

        [CommandHandler("cmd://GitExtensionsModule/GitBrowse")]
        public void GitBrowseClick(object sender, EventArgs e)
        {
            ExtensionsConnector.Browse();
        }

        [CommandHandler("cmd://GitExtensionsModule/GitStash")]
        public void GitStashClick(object sender, EventArgs e)
        {
            ExtensionsConnector.Stash();
        }

        [CommandHandler("cmd://GitExtensionsModule/GitAdd")]
        public void GitAddClick(object sender, EventArgs e)
        {
            ExtensionsConnector.Add();
        }

        [CommandHandler("cmd://GitExtensionsModule/GitBranch")]
        public void GitBranchClick(object sender, EventArgs e)
        {
            ExtensionsConnector.Branch();
        }

        [CommandHandler("cmd://GitExtensionsModule/GitCheckout")]
        public void GitCheckoutClick(object sender, EventArgs e)
        {
            ExtensionsConnector.Checkout();
        }

        [CommandHandler("cmd://GitExtensionsModule/GitMerge")]
        public void GitMergeClick(object sender, EventArgs e)
        {
            ExtensionsConnector.Merge();
        }

        [CommandHandler("cmd://GitExtensionsModule/GitViewChanges")]
        public void GitViewChangesClick(object sender, EventArgs e)
        {
            ExtensionsConnector.ViewChanges();
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
                WorkspaceConnector.ProjectContextService = this._projectContextService;
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
