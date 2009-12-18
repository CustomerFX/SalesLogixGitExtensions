namespace FX.SalesLogix.Modules.GitExtensions.Installer
{
    partial class ProxySettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProxySettings));
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.CheckUseProxyAuth = new System.Windows.Forms.CheckBox();
            this.labelProxyPassword = new System.Windows.Forms.Label();
            this.labelProxyUser = new System.Windows.Forms.Label();
            this.ProxyPassword = new System.Windows.Forms.TextBox();
            this.ProxyUser = new FX.SalesLogix.Modules.GitExtensions.Installer.Controls.TextBoxExtended();
            this.ProxyPort = new FX.SalesLogix.Modules.GitExtensions.Installer.Controls.TextBoxExtended();
            this.ProxyServer = new FX.SalesLogix.Modules.GitExtensions.Installer.Controls.TextBoxExtended();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(45, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(316, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "If you require the use of a proxy server, enter the values below";
            // 
            // groupBox1
            // 
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 49);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(403, 2);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(8, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(403, 49);
            this.panel1.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(26, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Proxy Server Address:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(26, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Proxy Server Port:";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Location = new System.Drawing.Point(-19, 256);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(444, 2);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(235, 267);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 26);
            this.buttonOK.TabIndex = 11;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(316, 267);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 26);
            this.buttonCancel.TabIndex = 12;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // CheckUseProxyAuth
            // 
            this.CheckUseProxyAuth.AutoSize = true;
            this.CheckUseProxyAuth.Location = new System.Drawing.Point(29, 145);
            this.CheckUseProxyAuth.Name = "CheckUseProxyAuth";
            this.CheckUseProxyAuth.Size = new System.Drawing.Size(210, 17);
            this.CheckUseProxyAuth.TabIndex = 13;
            this.CheckUseProxyAuth.Text = "My proxy server requires authentication";
            this.CheckUseProxyAuth.UseVisualStyleBackColor = true;
            this.CheckUseProxyAuth.CheckedChanged += new System.EventHandler(this.CheckUseProxyAuth_CheckedChanged);
            // 
            // labelProxyPassword
            // 
            this.labelProxyPassword.AutoSize = true;
            this.labelProxyPassword.Enabled = false;
            this.labelProxyPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelProxyPassword.Location = new System.Drawing.Point(26, 207);
            this.labelProxyPassword.Name = "labelProxyPassword";
            this.labelProxyPassword.Size = new System.Drawing.Size(100, 13);
            this.labelProxyPassword.TabIndex = 16;
            this.labelProxyPassword.Text = "Proxy Password:";
            // 
            // labelProxyUser
            // 
            this.labelProxyUser.AutoSize = true;
            this.labelProxyUser.Enabled = false;
            this.labelProxyUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelProxyUser.Location = new System.Drawing.Point(26, 180);
            this.labelProxyUser.Name = "labelProxyUser";
            this.labelProxyUser.Size = new System.Drawing.Size(108, 13);
            this.labelProxyUser.TabIndex = 14;
            this.labelProxyUser.Text = "Proxy User Name:";
            // 
            // ProxyPassword
            // 
            this.ProxyPassword.Enabled = false;
            this.ProxyPassword.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ProxyPassword.Location = new System.Drawing.Point(170, 204);
            this.ProxyPassword.Name = "ProxyPassword";
            this.ProxyPassword.Size = new System.Drawing.Size(193, 20);
            this.ProxyPassword.TabIndex = 17;
            this.ProxyPassword.UseSystemPasswordChar = true;
            // 
            // ProxyUser
            // 
            this.ProxyUser.Enabled = false;
            this.ProxyUser.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ProxyUser.IsPassword = false;
            this.ProxyUser.Location = new System.Drawing.Point(170, 177);
            this.ProxyUser.Name = "ProxyUser";
            this.ProxyUser.Size = new System.Drawing.Size(193, 20);
            this.ProxyUser.TabIndex = 15;
            this.ProxyUser.WatermarkColor = System.Drawing.Color.Silver;
            this.ProxyUser.WatermarkText = "";
            // 
            // ProxyPort
            // 
            this.ProxyPort.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ProxyPort.IsPassword = false;
            this.ProxyPort.Location = new System.Drawing.Point(170, 102);
            this.ProxyPort.Name = "ProxyPort";
            this.ProxyPort.Size = new System.Drawing.Size(193, 20);
            this.ProxyPort.TabIndex = 9;
            this.ProxyPort.WatermarkColor = System.Drawing.Color.Silver;
            this.ProxyPort.WatermarkText = "Proxy server port";
            // 
            // ProxyServer
            // 
            this.ProxyServer.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ProxyServer.IsPassword = false;
            this.ProxyServer.Location = new System.Drawing.Point(170, 75);
            this.ProxyServer.Name = "ProxyServer";
            this.ProxyServer.Size = new System.Drawing.Size(193, 20);
            this.ProxyServer.TabIndex = 7;
            this.ProxyServer.WatermarkColor = System.Drawing.Color.Silver;
            this.ProxyServer.WatermarkText = "Proxy server name or address";
            this.ProxyServer.Leave += new System.EventHandler(this.ProxyServer_Leave);
            // 
            // ProxySettings
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(403, 303);
            this.Controls.Add(this.ProxyPassword);
            this.Controls.Add(this.labelProxyPassword);
            this.Controls.Add(this.ProxyUser);
            this.Controls.Add(this.labelProxyUser);
            this.Controls.Add(this.CheckUseProxyAuth);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.ProxyPort);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ProxyServer);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProxySettings";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Proxy Server Settings";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        public Controls.TextBoxExtended ProxyServer;
        public Controls.TextBoxExtended ProxyPort;
        public System.Windows.Forms.TextBox ProxyPassword;
        private System.Windows.Forms.Label labelProxyPassword;
        public Controls.TextBoxExtended ProxyUser;
        private System.Windows.Forms.Label labelProxyUser;
        public System.Windows.Forms.CheckBox CheckUseProxyAuth;
    }
}