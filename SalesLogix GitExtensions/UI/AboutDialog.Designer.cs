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

namespace FX.SalesLogix.Modules.GitExtensions.UI
{
    partial class AboutDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutDialog));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelVersion = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelGitExtVersionText = new System.Windows.Forms.Label();
            this.labelVisitGitExtSite = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelVisitSite = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureCustomerFX = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.labelGitExtVersion = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureCustomerFX)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(453, 75);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(18, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(241, 54);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 75);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(453, 2);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.Location = new System.Drawing.Point(37, 91);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(271, 24);
            this.labelTitle.TabIndex = 2;
            this.labelTitle.Text = "Git Extensions for SalesLogix";
            // 
            // labelVersion
            // 
            this.labelVersion.AutoSize = true;
            this.labelVersion.Location = new System.Drawing.Point(38, 115);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(45, 13);
            this.labelVersion.TabIndex = 3;
            this.labelVersion.Text = "Version ";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(38, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(374, 52);
            this.label2.TabIndex = 4;
            this.label2.Text = "Git Extensions for SalesLogix integrates Git Extensions into the SalesLogix Appli" +
                "cation Architect to allow you to easily use Git for SalesLogix development proje" +
                "cts.";
            // 
            // labelGitExtVersionText
            // 
            this.labelGitExtVersionText.AutoSize = true;
            this.labelGitExtVersionText.Location = new System.Drawing.Point(38, 242);
            this.labelGitExtVersionText.Name = "labelGitExtVersionText";
            this.labelGitExtVersionText.Size = new System.Drawing.Size(155, 13);
            this.labelGitExtVersionText.TabIndex = 5;
            this.labelGitExtVersionText.Text = "Git Extensions version installed:";
            // 
            // labelVisitGitExtSite
            // 
            this.labelVisitGitExtSite.AutoSize = true;
            this.labelVisitGitExtSite.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelVisitGitExtSite.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVisitGitExtSite.ForeColor = System.Drawing.Color.Blue;
            this.labelVisitGitExtSite.Location = new System.Drawing.Point(38, 257);
            this.labelVisitGitExtSite.Name = "labelVisitGitExtSite";
            this.labelVisitGitExtSite.Size = new System.Drawing.Size(115, 13);
            this.labelVisitGitExtSite.TabIndex = 6;
            this.labelVisitGitExtSite.Text = "Visit Git Extensions site";
            this.labelVisitGitExtSite.Click += new System.EventHandler(this.labelVisitGitExtSite_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 272);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(172, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Git Extensions is © Henk Westhuis";
            // 
            // labelVisitSite
            // 
            this.labelVisitSite.AutoSize = true;
            this.labelVisitSite.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelVisitSite.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVisitSite.ForeColor = System.Drawing.Color.Blue;
            this.labelVisitSite.Location = new System.Drawing.Point(38, 192);
            this.labelVisitSite.Name = "labelVisitSite";
            this.labelVisitSite.Size = new System.Drawing.Size(287, 13);
            this.labelVisitSite.TabIndex = 8;
            this.labelVisitSite.Text = "View the Git Extensions for SalesLogix  repository on Github";
            this.labelVisitSite.Click += new System.EventHandler(this.labelVisitSite_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(38, 326);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(359, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Git Extensions for SalesLogix is Copyright © 2009 Customer FX Corporation";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(38, 341);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(190, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "and actively developed by Ryan Farley";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(38, 396);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(119, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Licensed under GPL v3";
            // 
            // pictureCustomerFX
            // 
            this.pictureCustomerFX.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureCustomerFX.Image = ((System.Drawing.Image)(resources.GetObject("pictureCustomerFX.Image")));
            this.pictureCustomerFX.Location = new System.Drawing.Point(41, 357);
            this.pictureCustomerFX.Name = "pictureCustomerFX";
            this.pictureCustomerFX.Size = new System.Drawing.Size(107, 23);
            this.pictureCustomerFX.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureCustomerFX.TabIndex = 12;
            this.pictureCustomerFX.TabStop = false;
            this.pictureCustomerFX.Click += new System.EventHandler(this.pictureCustomerFX_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Location = new System.Drawing.Point(38, 229);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(380, 2);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Location = new System.Drawing.Point(38, 301);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(380, 2);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            // 
            // labelGitExtVersion
            // 
            this.labelGitExtVersion.AutoSize = true;
            this.labelGitExtVersion.Location = new System.Drawing.Point(198, 242);
            this.labelGitExtVersion.Name = "labelGitExtVersion";
            this.labelGitExtVersion.Size = new System.Drawing.Size(53, 13);
            this.labelGitExtVersion.TabIndex = 15;
            this.labelGitExtVersion.Text = "Unknown";
            // 
            // AboutDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 428);
            this.Controls.Add(this.labelGitExtVersion);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.pictureCustomerFX);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labelVisitSite);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelVisitGitExtSite);
            this.Controls.Add(this.labelGitExtVersionText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelVersion);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "About";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureCustomerFX)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelGitExtVersionText;
        private System.Windows.Forms.Label labelVisitGitExtSite;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelVisitSite;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureCustomerFX;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label labelGitExtVersion;
    }
}