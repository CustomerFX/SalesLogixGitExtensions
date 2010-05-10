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

namespace FX.SalesLogix.Modules.GitExtensions.Installer
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panelHeader = new System.Windows.Forms.Panel();
            this.pictureBoxCfx = new System.Windows.Forms.PictureBox();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.groupBoxHeader = new System.Windows.Forms.GroupBox();
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelDescription1 = new System.Windows.Forms.Label();
            this.labelDescription2 = new System.Windows.Forms.Label();
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.labelProgress = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.panelNoGitExt = new System.Windows.Forms.Panel();
            this.linkLabelGetGitExt = new System.Windows.Forms.LinkLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelNoGitExt = new System.Windows.Forms.Label();
            this.linkSetProxy = new System.Windows.Forms.LinkLabel();
            this.checkDisableAutoUpdates = new System.Windows.Forms.CheckBox();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCfx)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.panelNoGitExt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.White;
            this.panelHeader.Controls.Add(this.pictureBoxCfx);
            this.panelHeader.Controls.Add(this.pictureBoxLogo);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(537, 71);
            this.panelHeader.TabIndex = 0;
            // 
            // pictureBoxCfx
            // 
            this.pictureBoxCfx.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxCfx.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxCfx.Image")));
            this.pictureBoxCfx.Location = new System.Drawing.Point(414, 24);
            this.pictureBoxCfx.Name = "pictureBoxCfx";
            this.pictureBoxCfx.Size = new System.Drawing.Size(107, 23);
            this.pictureBoxCfx.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxCfx.TabIndex = 1;
            this.pictureBoxCfx.TabStop = false;
            this.pictureBoxCfx.Click += new System.EventHandler(this.pictureBoxCfx_Click);
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxLogo.Image")));
            this.pictureBoxLogo.Location = new System.Drawing.Point(11, 9);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(241, 54);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxLogo.TabIndex = 0;
            this.pictureBoxLogo.TabStop = false;
            // 
            // groupBoxHeader
            // 
            this.groupBoxHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxHeader.Location = new System.Drawing.Point(0, 71);
            this.groupBoxHeader.Name = "groupBoxHeader";
            this.groupBoxHeader.Size = new System.Drawing.Size(537, 2);
            this.groupBoxHeader.TabIndex = 1;
            this.groupBoxHeader.TabStop = false;
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.Location = new System.Drawing.Point(12, 95);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(376, 23);
            this.labelTitle.TabIndex = 2;
            this.labelTitle.Text = "Git Extensions for SalesLogix Installer";
            // 
            // labelDescription1
            // 
            this.labelDescription1.Location = new System.Drawing.Point(13, 139);
            this.labelDescription1.Name = "labelDescription1";
            this.labelDescription1.Size = new System.Drawing.Size(494, 47);
            this.labelDescription1.TabIndex = 3;
            this.labelDescription1.Text = resources.GetString("labelDescription1.Text");
            // 
            // labelDescription2
            // 
            this.labelDescription2.AutoSize = true;
            this.labelDescription2.Location = new System.Drawing.Point(13, 196);
            this.labelDescription2.Name = "labelDescription2";
            this.labelDescription2.Size = new System.Drawing.Size(447, 13);
            this.labelDescription2.TabIndex = 4;
            this.labelDescription2.Text = "When you are ready to install Git Extensions for SalesLogix, click the \'Start Ins" +
                "tallation\' button.";
            // 
            // buttonStart
            // 
            this.buttonStart.Image = ((System.Drawing.Image)(resources.GetObject("buttonStart.Image")));
            this.buttonStart.Location = new System.Drawing.Point(275, 374);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(132, 31);
            this.buttonStart.TabIndex = 5;
            this.buttonStart.Text = "Start Installation";
            this.buttonStart.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(413, 374);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(94, 31);
            this.buttonCancel.TabIndex = 6;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // labelProgress
            // 
            this.labelProgress.AutoSize = true;
            this.labelProgress.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelProgress.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelProgress.Location = new System.Drawing.Point(72, 270);
            this.labelProgress.Name = "labelProgress";
            this.labelProgress.Size = new System.Drawing.Size(0, 14);
            this.labelProgress.TabIndex = 7;
            this.labelProgress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelProgress.Visible = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(75, 288);
            this.progressBar1.MarqueeAnimationSpeed = 80;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(385, 23);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 8;
            this.progressBar1.Visible = false;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.BalloonTipText = "Git Extensions for SalesLogix has been updated.";
            this.notifyIcon1.BalloonTipTitle = "Git Extensions for SalesLogix";
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Git Extensions for SalesLogix Updater";
            // 
            // panelNoGitExt
            // 
            this.panelNoGitExt.BackColor = System.Drawing.SystemColors.Info;
            this.panelNoGitExt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelNoGitExt.Controls.Add(this.linkLabelGetGitExt);
            this.panelNoGitExt.Controls.Add(this.pictureBox1);
            this.panelNoGitExt.Controls.Add(this.labelNoGitExt);
            this.panelNoGitExt.Location = new System.Drawing.Point(10, 363);
            this.panelNoGitExt.Name = "panelNoGitExt";
            this.panelNoGitExt.Size = new System.Drawing.Size(258, 52);
            this.panelNoGitExt.TabIndex = 9;
            this.panelNoGitExt.Visible = false;
            // 
            // linkLabelGetGitExt
            // 
            this.linkLabelGetGitExt.AutoSize = true;
            this.linkLabelGetGitExt.Location = new System.Drawing.Point(23, 31);
            this.linkLabelGetGitExt.Name = "linkLabelGetGitExt";
            this.linkLabelGetGitExt.Size = new System.Drawing.Size(55, 13);
            this.linkLabelGetGitExt.TabIndex = 2;
            this.linkLabelGetGitExt.TabStop = true;
            this.linkLabelGetGitExt.Text = "Download";
            this.linkLabelGetGitExt.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelGetGitExt_LinkClicked);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(6, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(16, 16);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // labelNoGitExt
            // 
            this.labelNoGitExt.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNoGitExt.Location = new System.Drawing.Point(24, 3);
            this.labelNoGitExt.Name = "labelNoGitExt";
            this.labelNoGitExt.Size = new System.Drawing.Size(234, 41);
            this.labelNoGitExt.TabIndex = 0;
            this.labelNoGitExt.Text = "Git Extensions does not appear to be installed. This is required for Git Extensio" +
                "ns for SalesLogix to function.";
            // 
            // linkSetProxy
            // 
            this.linkSetProxy.AutoSize = true;
            this.linkSetProxy.Location = new System.Drawing.Point(13, 216);
            this.linkSetProxy.Name = "linkSetProxy";
            this.linkSetProxy.Size = new System.Drawing.Size(96, 13);
            this.linkSetProxy.TabIndex = 10;
            this.linkSetProxy.TabStop = true;
            this.linkSetProxy.Text = "Click to set a proxy";
            this.linkSetProxy.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkSetProxy_LinkClicked);
            // 
            // checkDisableAutoUpdates
            // 
            this.checkDisableAutoUpdates.AutoSize = true;
            this.checkDisableAutoUpdates.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkDisableAutoUpdates.Location = new System.Drawing.Point(381, 342);
            this.checkDisableAutoUpdates.Name = "checkDisableAutoUpdates";
            this.checkDisableAutoUpdates.Size = new System.Drawing.Size(126, 17);
            this.checkDisableAutoUpdates.TabIndex = 11;
            this.checkDisableAutoUpdates.Text = "Disable auto-updates";
            this.checkDisableAutoUpdates.UseVisualStyleBackColor = true;
            this.checkDisableAutoUpdates.CheckedChanged += new System.EventHandler(this.checkDisableAutoUpdates_CheckedChanged);
            // 
            // MainForm
            // 
            this.AcceptButton = this.buttonStart;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(537, 429);
            this.Controls.Add(this.checkDisableAutoUpdates);
            this.Controls.Add(this.linkSetProxy);
            this.Controls.Add(this.panelNoGitExt);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.labelProgress);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.labelDescription2);
            this.Controls.Add(this.labelDescription1);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.groupBoxHeader);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Install Git Extensions for SalesLogix";
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCfx)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.panelNoGitExt.ResumeLayout(false);
            this.panelNoGitExt.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.GroupBox groupBoxHeader;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelDescription1;
        private System.Windows.Forms.Label labelDescription2;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelProgress;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.PictureBox pictureBoxCfx;
        private System.Windows.Forms.Panel panelNoGitExt;
        private System.Windows.Forms.Label labelNoGitExt;
        private System.Windows.Forms.LinkLabel linkLabelGetGitExt;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.LinkLabel linkSetProxy;
        private System.Windows.Forms.CheckBox checkDisableAutoUpdates;
    }
}

