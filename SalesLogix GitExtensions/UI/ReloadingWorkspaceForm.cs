using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace FX.SalesLogix.Modules.GitExtensions.UI
{
    public partial class ReloadingWorkspaceForm : Form
    {
        public ReloadingWorkspaceForm()
        {
            InitializeComponent();
            this.Text = GitExtensionResources.ModuleName;
        }

        public void SetClose()
        {
            Thread.Sleep(1000);
            this.Close();
        }
    }
}
