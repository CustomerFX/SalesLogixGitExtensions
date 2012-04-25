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
	public enum OutputLogType
	{
		Info,
		Error,
		Warn
	}

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

			OutputMessage(string.Format("Git commit to branch '{0}'", ExtensionsConnector.GetCurrentBranch()), OutputLogType.Info, true);
            ExtensionsConnector.Commit();
        }

        [CommandHandler(Commands.Pull)]
        public void GitPullClick(object sender, EventArgs e)
        {
            if (!EnvironmentCheck()) return;

			OutputMessage("Git pull", OutputLogType.Info, true);
            ExtensionsConnector.Pull();
			OutputMessage("Reloading project workspace");
            WorkspaceConnector.Reload();

            OutputMessage("Your project workspace has been reloaded. Note: you will need to rebuild your web platform before you deploy.");
        }

        [CommandHandler(Commands.Push)]
        public void GitPushClick(object sender, EventArgs e)
        {
            if (!EnvironmentCheck()) return;

			OutputMessage("Git push", OutputLogType.Info, true);
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

			OutputMessage("Git stash", OutputLogType.Info, true);
            ExtensionsConnector.Stash();
        }

        [CommandHandler(Commands.Add)]
        public void GitAddClick(object sender, EventArgs e)
        {
            if (!EnvironmentCheck()) return;

			OutputMessage("Git add", OutputLogType.Info, true);
            ExtensionsConnector.Add();
        }

        [CommandHandler(Commands.Branch)]
        public void GitBranchClick(object sender, EventArgs e)
        {
            if (!EnvironmentCheck()) return;

			OutputMessage("Git branch", OutputLogType.Info, true);
            ExtensionsConnector.Branch();
        }

        [CommandHandler(Commands.Checkout)]
        public void GitCheckoutClick(object sender, EventArgs e)
        {
            if (!EnvironmentCheck()) return;

			OutputMessage("Git checkout", OutputLogType.Info, true);
            ExtensionsConnector.Checkout();
			OutputMessage("Reloading project workspace");
			WorkspaceConnector.Reload();

			OutputMessage("Your project workspace has been reloaded. Note: you will need to rebuild your web platform before you deploy.");
        }

        [CommandHandler(Commands.Merge)]
        public void GitMergeClick(object sender, EventArgs e)
        {
            if (!EnvironmentCheck()) return;

			OutputMessage("Git merge", OutputLogType.Info, true);
            ExtensionsConnector.Merge();
			OutputMessage("Reloading project workspace");
			WorkspaceConnector.Reload();

			OutputMessage("Your project workspace has been reloaded. Note: you will need to rebuild your web platform before you deploy.");
        }

        [CommandHandler(Commands.ViewChanges)]
        public void GitViewChangesClick(object sender, EventArgs e)
        {
            if (!EnvironmentCheck()) return;

			OutputMessage("Git view changes", OutputLogType.Info, true);
            ExtensionsConnector.ViewChanges();
        }

        [CommandHandler(Commands.Bash)]
        public void GitBashClick(object sender, EventArgs e)
        {
			if (!EnvironmentCheck()) return;

			OutputMessage("Starting Git bash", OutputLogType.Info, true);
            ExtensionsConnector.ShellBash();
        }

        [CommandHandler(Commands.EditGitIgnore)]
        public void GitIgnoreClick(object sender, EventArgs e)
        {
            if (!EnvironmentCheck()) return;
			OutputMessage("", OutputLogType.Info, true);
			
            if (!WorkspaceConnector.HasGitIgnore)
            {
                switch (MessageBox.Show("Your current repository does not yet have a .gitignore file. Would you like to add the standard SalesLogix ignore entries?", "Add Standard SalesLogix Model Entries?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                {
                    case DialogResult.Yes:
						OutputMessage("Creating standard gitignore");
                        WorkspaceConnector.AddStandardIgnore();
                        break;
                    case DialogResult.Cancel:
                        return;
                }
            }

			OutputMessage("Edit gitignore");
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
			string message = "Git Extensions is not installed. Git Extensions must be installed to use Git Extensions for SalesLogix.\r\n" +
							 "To install Git Extensions visit: http://code.google.com/p/gitextensions/";

			OutputMessage(message, OutputLogType.Error, true);
            MessageBox.Show(
                            message,
                            "Git Extensions for SalesLogix",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation
                            );
        }

        private void NoRepositoryAction()
        {
			string message = "The current workspace directory '" + WorkspaceConnector.ProjectPathRoot + "' is not a Git repository.";

			OutputMessage(message, OutputLogType.Warn, true);
            if (MessageBox.Show(
                            message + "\r\n\r\nWould you like to make it a repository? (Note: this will also add the standard SalesLogix ignore entries to the .gitignore file)",
                            "Git Extensions for SalesLogix",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question
                            ) == DialogResult.Yes)
            {
				_log.Info("Start process to create repo and .gitignore");
				
				OutputMessage("Creating Git repository for " + WorkspaceConnector.ProjectPathRoot);
                ExtensionsConnector.Init();

				OutputMessage("Creating standard SalesLogix model ignore file");
                WorkspaceConnector.AddStandardIgnore();
            }
        }

        private void NoModelAction()
        {
			string message = "This function is not available with a model in the VFS.\r\nExport your working model to work with source control.";

			OutputMessage(message, OutputLogType.Warn, true);
			MessageBox.Show(
                            message, 
							"Git Extensions for SalesLogix", 
                            MessageBoxButtons.OK, 
                            MessageBoxIcon.Exclamation
                            );
        }

		private void OutputMessage(string Message)
		{
			OutputMessage(Message, OutputLogType.Info);
		}

		private void OutputMessage(string Message, OutputLogType OutputType)
		{
			OutputMessage(Message, OutputType, false);
		}

		private void OutputMessage(string Message, OutputLogType OutputType, bool InitOutput)
		{
			IOutputWindowLog log = Sage.Platform.Application.ApplicationContext.Current.Services.Get<IOutputWindowService>().Get("default");
			if (log == null) return;

			try
			{
				if (InitOutput)
				{
					this.ModuleWorkItem.Commands["cmd://IDE/ShowOutputWindow"].Execute();
					log.Activate();
					log.Clear();

					log.LogInformation("Git Extensions for SalesLogix\r\n");
					log.LogInformation("Copyright © 2012 Customer FX Corporation - http://customerfx.com/\r\n");
					log.LogInformation("---\r\n");
				}

				if (Message.Trim() == string.Empty) return;
				Message = Message.Replace("\r\n", string.Format("\r\n{0} ", OutputType.ToString().ToUpper()));

				switch (OutputType)
				{
					case OutputLogType.Warn:
						log.LogWarning(string.Format("WARN {0}\r\n", Message));
						break;
					case OutputLogType.Error:
						log.LogError(string.Format("ERROR {0}\r\n", Message));
						break;
					default:
						log.LogInformation(string.Format("INFO {0}\r\n", Message));
						break;
				}
			}
			catch { }
		}

        private void ShowExceptionMessage(Exception exception)
        {
			OutputMessage(exception.Message, OutputLogType.Error);
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
