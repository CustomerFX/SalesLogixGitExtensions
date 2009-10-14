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
            if (!ExtensionsConnector.IsInstalled) { NoExtensionsAction(); return; }
            if (!WorkspaceConnector.IsExportedModel) { NoModelAction(); return; }

            ExtensionsConnector.Commit();
        }

        [CommandHandler("cmd://GitExtensionsModule/GitPull")]
        public void GitPullClick(object sender, EventArgs e)
        {
            if (!ExtensionsConnector.IsInstalled) { NoExtensionsAction(); return; }
            if (!WorkspaceConnector.IsExportedModel) { NoModelAction(); return; }

            ExtensionsConnector.Pull();
        }

        [CommandHandler("cmd://GitExtensionsModule/GitPush")]
        public void GitPushClick(object sender, EventArgs e)
        {
            if (!ExtensionsConnector.IsInstalled) { NoExtensionsAction(); return; }
            if (!WorkspaceConnector.IsExportedModel) { NoModelAction(); return; }

            ExtensionsConnector.Push();
        }

        [CommandHandler("cmd://GitExtensionsModule/GitSettings")]
        public void GitSettingsClick(object sender, EventArgs e)
        {
            if (!ExtensionsConnector.IsInstalled) { NoExtensionsAction(); return; }
            ExtensionsConnector.Settings();
        }

        [CommandHandler("cmd://GitExtensionsModule/GitExtensions")]
        public void GitExtensionsClick(object sender, EventArgs e)
        {
            if (!ExtensionsConnector.IsInstalled) { NoExtensionsAction(); return; }
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
            if (!ExtensionsConnector.IsInstalled) { NoExtensionsAction(); return; }
            if (!WorkspaceConnector.IsExportedModel) { NoModelAction(); return; }

            ExtensionsConnector.Stash();
        }

        [CommandHandler("cmd://GitExtensionsModule/GitAdd")]
        public void GitAddClick(object sender, EventArgs e)
        {
            if (!ExtensionsConnector.IsInstalled) { NoExtensionsAction(); return; }
            if (!WorkspaceConnector.IsExportedModel) { NoModelAction(); return; }

            ExtensionsConnector.Add();
        }

        [CommandHandler("cmd://GitExtensionsModule/GitBranch")]
        public void GitBranchClick(object sender, EventArgs e)
        {
            if (!ExtensionsConnector.IsInstalled) { NoExtensionsAction(); return; }
            if (!WorkspaceConnector.IsExportedModel) { NoModelAction(); return; }

            ExtensionsConnector.Branch();
        }

        [CommandHandler("cmd://GitExtensionsModule/GitCheckout")]
        public void GitCheckoutClick(object sender, EventArgs e)
        {
            if (!ExtensionsConnector.IsInstalled) { NoExtensionsAction(); return; }
            if (!WorkspaceConnector.IsExportedModel) { NoModelAction(); return; }

            ExtensionsConnector.Checkout();
        }

        [CommandHandler("cmd://GitExtensionsModule/GitMerge")]
        public void GitMergeClick(object sender, EventArgs e)
        {
            if (!ExtensionsConnector.IsInstalled) { NoExtensionsAction(); return; }
            if (!WorkspaceConnector.IsExportedModel) { NoModelAction(); return; }

            ExtensionsConnector.Merge();
        }

        [CommandHandler("cmd://GitExtensionsModule/GitViewChanges")]
        public void GitViewChangesClick(object sender, EventArgs e)
        {
            if (!ExtensionsConnector.IsInstalled) { NoExtensionsAction(); return; }
            if (!WorkspaceConnector.IsExportedModel) { NoModelAction(); return; }

            ExtensionsConnector.ViewChanges();
        }

        private void NoExtensionsAction()
        {
            MessageBox.Show(
                            "Git Extensions is not installed. Git Extensions must be installed to use Git Extensions for SalesLogix.\r\n\r\n" + 
                            "To install Git Extensions visit: http://code.google.com/p/gitextensions/",
                            "Git Extensions for SalesLogix",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation
                            );
        }

        private void NoModelAction()
        {
            MessageBox.Show(
                            "This function is not available with a model in the VFS.\r\nExport your working model to work with source control.", 
                            "Git Extensions for SalesLogix", 
                            MessageBoxButtons.OK, 
                            MessageBoxIcon.Exclamation
                            );
        }

        private void ShowExceptionMessage(Exception exception)
        {
            MessageBox.Show(exception.Message, "Git Extensions for SalesLogix", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
