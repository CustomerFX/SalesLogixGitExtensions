using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sage.Platform.Application.UI;
using Sage.Platform.Application;
using Sage.Platform.Application.UI.WinForms;
using FX.SalesLogix.Modules.GitExtensions.Constants;

namespace FX.SalesLogix.Modules.GitExtensions.SmartParts
{
	[SmartPart]
	public partial class GitControlPanel : UserControl, ISmartPartInfoProvider
	{
		public GitControlPanel()
		{
			InitializeComponent();
		}

		#region Service Dependencies

		[ServiceDependency]
		public UIWorkItem ModuleWorkItem { get; set; }

		#endregion

		#region SmartPart

		public ISmartPartInfo GetSmartPartInfo(Type smartPartInfoType)
		{
			if (smartPartInfoType == typeof(UltraDockSmartPartInfo))
			{
				UltraDockSmartPartInfo info = new UltraDockSmartPartInfo();
				info.Title = GitExtensionResources.ControlPanelText;
				info.Description = GitExtensionResources.ControlPanelTooltip;
				info.Image = GitExtensionResources.GitExtensionsImage;
				info.DefaultLocation = DockedLocation.DockedBottom;
				info.DefaultPaneStyle = ChildPaneStyle.TabGroup;
				info.PreferredGroup = "ui://Bottom";
				return info;
			}

			if (smartPartInfoType == typeof(UltraMdiTabSmartPartInfo))
			{
				UltraMdiTabSmartPartInfo info2 = new UltraMdiTabSmartPartInfo();
				info2.Title = GitExtensionResources.ControlPanelText;
				info2.Description = GitExtensionResources.ControlPanelTooltip;
				info2.Image = GitExtensionResources.GitExtensionsImage;
				return info2;
			}

			return new SmartPartInfo(GitExtensionResources.ControlPanelText, GitExtensionResources.ControlPanelTooltip);
		}

		#endregion

		private void buttonCommit_Click(object sender, EventArgs e)
		{
			this.ModuleWorkItem.Commands[Commands.Commit].Execute();
			this.ModuleWorkItem.Commands[Commands.ShowControlPanel].Execute();
		}

		private void buttonPush_Click(object sender, EventArgs e)
		{
			this.ModuleWorkItem.Commands[Commands.Push].Execute();
			this.ModuleWorkItem.Commands[Commands.ShowControlPanel].Execute();
		}

		private void buttonPull_Click(object sender, EventArgs e)
		{
			this.ModuleWorkItem.Commands[Commands.Pull].Execute();
			this.ModuleWorkItem.Commands[Commands.ShowControlPanel].Execute();
		}

		private void buttonCreateBranch_Click(object sender, EventArgs e)
		{
			this.ModuleWorkItem.Commands[Commands.Branch].Execute();
			this.ModuleWorkItem.Commands[Commands.ShowControlPanel].Execute();
		}

		private void buttonMergeBranch_Click(object sender, EventArgs e)
		{
			this.ModuleWorkItem.Commands[Commands.Merge].Execute();
			this.ModuleWorkItem.Commands[Commands.ShowControlPanel].Execute();
		}
	}
}
