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
            if (!EnvironmentCheck()) return;
            ExtensionsConnector.Commit();
        }

        [CommandHandler("cmd://GitExtensionsModule/GitPull")]
        public void GitPullClick(object sender, EventArgs e)
        {
            if (!EnvironmentCheck()) return;
            ExtensionsConnector.Pull();
        }

        [CommandHandler("cmd://GitExtensionsModule/GitPush")]
        public void GitPushClick(object sender, EventArgs e)
        {
            if (!EnvironmentCheck()) return;
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
            if (!WorkspaceConnector.IsRepository) { NoRepositoryAction(); return; }
            ExtensionsConnector.Browse();
        }

        [CommandHandler("cmd://GitExtensionsModule/GitStash")]
        public void GitStashClick(object sender, EventArgs e)
        {
            if (!EnvironmentCheck()) return;
            ExtensionsConnector.Stash();
        }

        [CommandHandler("cmd://GitExtensionsModule/GitAdd")]
        public void GitAddClick(object sender, EventArgs e)
        {
            if (!EnvironmentCheck()) return;
            ExtensionsConnector.Add();
        }

        [CommandHandler("cmd://GitExtensionsModule/GitBranch")]
        public void GitBranchClick(object sender, EventArgs e)
        {
            if (!EnvironmentCheck()) return;
            ExtensionsConnector.Branch();
        }

        [CommandHandler("cmd://GitExtensionsModule/GitCheckout")]
        public void GitCheckoutClick(object sender, EventArgs e)
        {
            if (!EnvironmentCheck()) return;
            ExtensionsConnector.Checkout();
        }

        [CommandHandler("cmd://GitExtensionsModule/GitMerge")]
        public void GitMergeClick(object sender, EventArgs e)
        {
            if (!EnvironmentCheck()) return;
            ExtensionsConnector.Merge();
        }

        [CommandHandler("cmd://GitExtensionsModule/GitViewChanges")]
        public void GitViewChangesClick(object sender, EventArgs e)
        {
            if (!EnvironmentCheck()) return;
            ExtensionsConnector.ViewChanges();
        }

        private bool EnvironmentCheck()
        {
            if (!ExtensionsConnector.IsInstalled)
            { 
                NoExtensionsAction();
                return false;
            }

            if (!WorkspaceConnector.IsExportedModel)
            {
                NoModelAction();
                return false;
            }

            if (!WorkspaceConnector.IsRepository)
            {
                NoRepositoryAction();
                return false;
            }

            return true;
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

        private void NoRepositoryAction()
        {
            if (MessageBox.Show(
                            "The current workspace directory '" + WorkspaceConnector.ProjectPathRoot + "' is not a Git repository.\r\n\r\nWould you like to make it a repository?",
                            "Git Extensions for SalesLogix",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question
                            ) == DialogResult.Yes)
            {
                ExtensionsConnector.Init();
            }
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
