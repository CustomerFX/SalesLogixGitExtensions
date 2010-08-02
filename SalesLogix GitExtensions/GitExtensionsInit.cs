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
using FX.SalesLogix.Modules.GitExtensions.Constants;
using FX.SalesLogix.Modules.GitExtensions.Connectors;

namespace FX.SalesLogix.Modules.GitExtensions
{
    public class GitExtensionsInit : ModuleInit<UIWorkItem>, IModuleConfigurationProvider
    {
        private IProjectContextService _projectContextService;
        private static readonly ILog _log = LogManager.GetLogger("GitExtensions");

        protected override void Load()
        {
            _log.Info("Loading " + GitExtensionResources.ModuleName);
            this.ModuleWorkItem.RootWorkItem.Terminated += new EventHandler(RootWorkItem_Terminated);
        }

        private void RootWorkItem_Terminated(object sender, EventArgs e)
        {
            Utility.AssemblyUpdate.Start();
        }

        public override string ToString()
        {
            return GitExtensionResources.ModuleName;
        }

        #region Module Configuration

        public ModuleConfiguration GetConfiguration()
        {
            return ModuleConfiguration.LoadFromResource("FX.SalesLogix.Modules.GitExtensions.FX.SalesLogix.Modules.GitExtensions.Configuration.xml", base.GetType().Assembly);
        }

        protected override void Configure(XmlElement xmlConfig)
        {
        }

        #endregion

        # region Command Handlers

        [CommandHandler(Commands.Commit)]
        public void GitCommitClick(object sender, EventArgs e)
        {
            if (!EnvironmentCheck()) return;
            ExtensionsConnector.Commit();
        }

        [CommandHandler(Commands.Pull)]
        public void GitPullClick(object sender, EventArgs e)
        {
            if (!EnvironmentCheck()) return;
            ExtensionsConnector.Pull();
            WorkspaceConnector.Reload();

            MessageBox.Show("Your project workspace has been reloaded. Note: you will need to rebuild your web platform before you deploy.", "Pull Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        [CommandHandler(Commands.Push)]
        public void GitPushClick(object sender, EventArgs e)
        {
            if (!EnvironmentCheck()) return;
            ExtensionsConnector.Push();
        }

        [CommandHandler(Commands.Settings)]
        public void GitSettingsClick(object sender, EventArgs e)
        {
            if (!ExtensionsConnector.IsInstalled) { NoExtensionsAction(); return; }
            ExtensionsConnector.Settings();
        }

        [CommandHandler(Commands.GitExtensions)]
        public void GitExtensionsClick(object sender, EventArgs e)
        {
            if (!ExtensionsConnector.IsInstalled) { NoExtensionsAction(); return; }
            ExtensionsConnector.Show();
        }

        [CommandHandler(Commands.Browse)]
        public void GitBrowseClick(object sender, EventArgs e)
        {
            if (!WorkspaceConnector.IsRepository) { NoRepositoryAction(); return; }
            ExtensionsConnector.Browse();
        }

        [CommandHandler(Commands.Stash)]
        public void GitStashClick(object sender, EventArgs e)
        {
            if (!EnvironmentCheck()) return;
            ExtensionsConnector.Stash();
        }

        [CommandHandler(Commands.Add)]
        public void GitAddClick(object sender, EventArgs e)
        {
            if (!EnvironmentCheck()) return;
            ExtensionsConnector.Add();
        }

        [CommandHandler(Commands.Branch)]
        public void GitBranchClick(object sender, EventArgs e)
        {
            if (!EnvironmentCheck()) return;
            ExtensionsConnector.Branch();
        }

        [CommandHandler(Commands.Checkout)]
        public void GitCheckoutClick(object sender, EventArgs e)
        {
            if (!EnvironmentCheck()) return;
            ExtensionsConnector.Checkout();
			WorkspaceConnector.Reload();

			MessageBox.Show("Your project workspace has been reloaded. Note: you may need to rebuild your web platform.", "Branch Checkout Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        [CommandHandler(Commands.Merge)]
        public void GitMergeClick(object sender, EventArgs e)
        {
            if (!EnvironmentCheck()) return;
            ExtensionsConnector.Merge();
			WorkspaceConnector.Reload();
        }

        [CommandHandler(Commands.ViewChanges)]
        public void GitViewChangesClick(object sender, EventArgs e)
        {
            if (!EnvironmentCheck()) return;
            ExtensionsConnector.ViewChanges();
        }

        [CommandHandler(Commands.Bash)]
        public void GitBashClick(object sender, EventArgs e)
        {
			if (!EnvironmentCheck()) return;
            ExtensionsConnector.ShellBash();
        }

        [CommandHandler(Commands.EditGitIgnore)]
        public void GitIgnoreClick(object sender, EventArgs e)
        {
            if (!EnvironmentCheck()) return;

            if (!WorkspaceConnector.HasGitIgnore)
            {
                switch (MessageBox.Show("Your current repository does not yet have a .gitignore file. Would you like to add the standard SalesLogix ignore entries?", "Add Standard SalesLogix Model Entries?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                {
                    case DialogResult.Yes:
                        WorkspaceConnector.AddStandardIgnore();
                        break;
                    case DialogResult.Cancel:
                        return;
                }
            }

            ExtensionsConnector.EditGitIgnore();
        }

        [CommandHandler(Commands.OpenFolder)]
        public void OpenFolderClick(object sender, EventArgs e)
        {
            if (!WorkspaceConnector.IsExportedModel) return;
            WorkspaceConnector.OpenProjectFolder();
        }

        [CommandHandler(Commands.ManageRemotes)]
        public void ManageRemotesClick(object sender, EventArgs e)
        {
            if (!EnvironmentCheck()) return;
            ExtensionsConnector.ManageRemotes();
        }

        [CommandHandler(Commands.About)]
        public void AboutClick(object sender, EventArgs e)
        {
            using (UI.AboutDialog dlg = new UI.AboutDialog())
            {
                dlg.ShowDialog();
            }
        }

        [CommandHandler(Commands.Feedback)]
        public void FeedbackClick(object sender, EventArgs e)
        {
            using (UI.FeedbackDialog dlg = new UI.FeedbackDialog())
            {
                dlg.ShowDialog();
            }
        }

        #endregion

        #region Environment Check Actions

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
                            "The current workspace directory '" + WorkspaceConnector.ProjectPathRoot + "' is not a Git repository.\r\n\r\nWould you like to make it a repository? (Note: this will also add the standard SalesLogix ignore entries to the .gitignore file)",
                            "Git Extensions for SalesLogix",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question
                            ) == DialogResult.Yes)
            {
				_log.Info("Start process to create repo and .gitignore");
                ExtensionsConnector.Init();
                WorkspaceConnector.AddStandardIgnore();
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

        #endregion

        #region Service Dependencies

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
                WorkspaceConnector.ProjectContext = this._projectContextService;
            }
        }

        #endregion
    }
}
