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
	}
}
