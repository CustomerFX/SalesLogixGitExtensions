namespace FX.SalesLogix.Modules.GitExtensions.SmartParts
{
	partial class GitControlPanel
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GitControlPanel));
			this.pictureLogo = new System.Windows.Forms.PictureBox();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.buttonCommit = new System.Windows.Forms.ToolStripButton();
			this.buttonPush = new System.Windows.Forms.ToolStripButton();
			this.buttonPull = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
			this.comboBranches = new System.Windows.Forms.ToolStripComboBox();
			this.buttonCreateBranch = new System.Windows.Forms.ToolStripButton();
			this.buttonMergeBranch = new System.Windows.Forms.ToolStripButton();
			((System.ComponentModel.ISupportInitialize)(this.pictureLogo)).BeginInit();
			this.toolStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// pictureLogo
			// 
			this.pictureLogo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.pictureLogo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureLogo.Image = ((System.Drawing.Image)(resources.GetObject("pictureLogo.Image")));
			this.pictureLogo.Location = new System.Drawing.Point(567, 131);
			this.pictureLogo.Name = "pictureLogo";
			this.pictureLogo.Size = new System.Drawing.Size(147, 34);
			this.pictureLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureLogo.TabIndex = 0;
			this.pictureLogo.TabStop = false;
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonCommit,
            this.buttonPush,
            this.buttonPull,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.comboBranches,
            this.buttonCreateBranch,
            this.buttonMergeBranch});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(718, 25);
			this.toolStrip1.TabIndex = 1;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// buttonCommit
			// 
			this.buttonCommit.Image = global::FX.SalesLogix.Modules.GitExtensions.GitExtensionResources.CommitImage;
			this.buttonCommit.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonCommit.Name = "buttonCommit";
			this.buttonCommit.Size = new System.Drawing.Size(71, 22);
			this.buttonCommit.Text = "Commit";
			this.buttonCommit.Click += new System.EventHandler(this.buttonCommit_Click);
			// 
			// buttonPush
			// 
			this.buttonPush.Image = global::FX.SalesLogix.Modules.GitExtensions.GitExtensionResources.PushImage;
			this.buttonPush.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonPush.Name = "buttonPush";
			this.buttonPush.Size = new System.Drawing.Size(53, 22);
			this.buttonPush.Text = "Push";
			this.buttonPush.Click += new System.EventHandler(this.buttonPush_Click);
			// 
			// buttonPull
			// 
			this.buttonPull.Image = global::FX.SalesLogix.Modules.GitExtensions.GitExtensionResources.PullImage;
			this.buttonPull.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonPull.Name = "buttonPull";
			this.buttonPull.Size = new System.Drawing.Size(47, 22);
			this.buttonPull.Text = "Pull";
			this.buttonPull.Click += new System.EventHandler(this.buttonPull_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// toolStripLabel1
			// 
			this.toolStripLabel1.Name = "toolStripLabel1";
			this.toolStripLabel1.Size = new System.Drawing.Size(90, 22);
			this.toolStripLabel1.Text = "Current Branch:";
			// 
			// comboBranches
			// 
			this.comboBranches.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBranches.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.comboBranches.Name = "comboBranches";
			this.comboBranches.Size = new System.Drawing.Size(185, 25);
			// 
			// buttonCreateBranch
			// 
			this.buttonCreateBranch.Image = ((System.Drawing.Image)(resources.GetObject("buttonCreateBranch.Image")));
			this.buttonCreateBranch.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonCreateBranch.Name = "buttonCreateBranch";
			this.buttonCreateBranch.Size = new System.Drawing.Size(101, 22);
			this.buttonCreateBranch.Text = "Create Branch";
			this.buttonCreateBranch.Click += new System.EventHandler(this.buttonCreateBranch_Click);
			// 
			// buttonMergeBranch
			// 
			this.buttonMergeBranch.Image = ((System.Drawing.Image)(resources.GetObject("buttonMergeBranch.Image")));
			this.buttonMergeBranch.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonMergeBranch.Name = "buttonMergeBranch";
			this.buttonMergeBranch.Size = new System.Drawing.Size(101, 22);
			this.buttonMergeBranch.Text = "Merge Branch";
			this.buttonMergeBranch.Click += new System.EventHandler(this.buttonMergeBranch_Click);
			// 
			// GitControlPanel
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.toolStrip1);
			this.Controls.Add(this.pictureLogo);
			this.Name = "GitControlPanel";
			this.Size = new System.Drawing.Size(718, 169);
			((System.ComponentModel.ISupportInitialize)(this.pictureLogo)).EndInit();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureLogo;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton buttonCommit;
		private System.Windows.Forms.ToolStripButton buttonPush;
		private System.Windows.Forms.ToolStripButton buttonPull;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripLabel toolStripLabel1;
		private System.Windows.Forms.ToolStripComboBox comboBranches;
		private System.Windows.Forms.ToolStripButton buttonCreateBranch;
		private System.Windows.Forms.ToolStripButton buttonMergeBranch;
	}
}
