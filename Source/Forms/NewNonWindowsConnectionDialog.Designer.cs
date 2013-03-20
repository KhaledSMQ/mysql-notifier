﻿// 
// Copyright (c) 2012, Oracle and/or its affiliates. All rights reserved.
//
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License as
// published by the Free Software Foundation; version 2 of the
// License.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program; if not, write to the Free Software
// Foundation, Inc., 51 Franklin St, Fifth Floor, Boston, MA
// 02110-1301  USA
//

namespace MySQL.Notifier
{
  partial class NewNonWindowsConnectionDialog
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewNonWindowsConnectionDialog));
      this.tabControl1 = new System.Windows.Forms.TabControl();
      this.parametersPage = new System.Windows.Forms.TabPage();
      this.savePasswordInVault = new System.Windows.Forms.CheckBox();
      this.txtPassword = new System.Windows.Forms.TextBox();
      this.lblPassword = new System.Windows.Forms.Label();
      this.labelHelpSocket = new System.Windows.Forms.Label();
      this.labelPromptSocket = new System.Windows.Forms.Label();
      this.socketPath = new System.Windows.Forms.TextBox();
      this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
      this.labelHelpUserName = new System.Windows.Forms.Label();
      this.port = new System.Windows.Forms.TextBox();
      this.userName = new System.Windows.Forms.TextBox();
      this.hostName = new System.Windows.Forms.TextBox();
      this.labelHelpHostName = new System.Windows.Forms.Label();
      this.labelPromptPort = new System.Windows.Forms.Label();
      this.labelPromptUserName = new System.Windows.Forms.Label();
      this.labelPromptHostName = new System.Windows.Forms.Label();
      this.advancedPage = new System.Windows.Forms.TabPage();
      this.label21 = new System.Windows.Forms.Label();
      this.label20 = new System.Windows.Forms.Label();
      this.label19 = new System.Windows.Forms.Label();
      this.textBox4 = new System.Windows.Forms.TextBox();
      this.textBox3 = new System.Windows.Forms.TextBox();
      this.textBox2 = new System.Windows.Forms.TextBox();
      this.textBox1 = new System.Windows.Forms.TextBox();
      this.label18 = new System.Windows.Forms.Label();
      this.label17 = new System.Windows.Forms.Label();
      this.label16 = new System.Windows.Forms.Label();
      this.label15 = new System.Windows.Forms.Label();
      this.label14 = new System.Windows.Forms.Label();
      this.label13 = new System.Windows.Forms.Label();
      this.label12 = new System.Windows.Forms.Label();
      this.labelCompression = new System.Windows.Forms.Label();
      this.useSSL = new System.Windows.Forms.CheckBox();
      this.useANSI = new System.Windows.Forms.CheckBox();
      this.useCompression = new System.Windows.Forms.CheckBox();
      this.connectionMethod = new System.Windows.Forms.ComboBox();
      this.labelHelpMethod = new System.Windows.Forms.Label();
      this.labelPromptMethod = new System.Windows.Forms.Label();
      this.labelHelpName = new System.Windows.Forms.Label();
      this.connectionName = new System.Windows.Forms.TextBox();
      this.labelPromptName = new System.Windows.Forms.Label();
      this.testButton = new System.Windows.Forms.Button();
      this.cancelButton = new System.Windows.Forms.Button();
      this.okButton = new System.Windows.Forms.Button();
      this.tabControl1.SuspendLayout();
      this.parametersPage.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
      this.advancedPage.SuspendLayout();
      this.SuspendLayout();
      // 
      // tabControl1
      // 
      this.tabControl1.Controls.Add(this.parametersPage);
      this.tabControl1.Controls.Add(this.advancedPage);
      this.tabControl1.Location = new System.Drawing.Point(12, 69);
      this.tabControl1.Name = "tabControl1";
      this.tabControl1.SelectedIndex = 0;
      this.tabControl1.Size = new System.Drawing.Size(769, 178);
      this.tabControl1.TabIndex = 2;
      // 
      // parametersPage
      // 
      this.parametersPage.Controls.Add(this.savePasswordInVault);
      this.parametersPage.Controls.Add(this.txtPassword);
      this.parametersPage.Controls.Add(this.lblPassword);
      this.parametersPage.Controls.Add(this.labelHelpSocket);
      this.parametersPage.Controls.Add(this.labelPromptSocket);
      this.parametersPage.Controls.Add(this.socketPath);
      this.parametersPage.Controls.Add(this.labelHelpUserName);
      this.parametersPage.Controls.Add(this.port);
      this.parametersPage.Controls.Add(this.userName);
      this.parametersPage.Controls.Add(this.hostName);
      this.parametersPage.Controls.Add(this.labelHelpHostName);
      this.parametersPage.Controls.Add(this.labelPromptPort);
      this.parametersPage.Controls.Add(this.labelPromptUserName);
      this.parametersPage.Controls.Add(this.labelPromptHostName);
      this.parametersPage.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.parametersPage.Location = new System.Drawing.Point(4, 24);
      this.parametersPage.Name = "parametersPage";
      this.parametersPage.Padding = new System.Windows.Forms.Padding(3);
      this.parametersPage.Size = new System.Drawing.Size(761, 150);
      this.parametersPage.TabIndex = 0;
      this.parametersPage.Text = "Parameters";
      this.parametersPage.UseVisualStyleBackColor = true;
      // 
      // savePasswordInVault
      // 
      this.savePasswordInVault.AutoSize = true;
      this.savePasswordInVault.Location = new System.Drawing.Point(442, 80);
      this.savePasswordInVault.Name = "savePasswordInVault";
      this.savePasswordInVault.Size = new System.Drawing.Size(145, 19);
      this.savePasswordInVault.TabIndex = 28;
      this.savePasswordInVault.Text = "Save password in vault";
      this.savePasswordInVault.UseVisualStyleBackColor = true;
      // 
      // txtPassword
      // 
      this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.txtPassword.Location = new System.Drawing.Point(119, 78);
      this.txtPassword.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.txtPassword.Name = "txtPassword";
      this.txtPassword.Size = new System.Drawing.Size(317, 23);
      this.txtPassword.TabIndex = 27;
      this.txtPassword.UseSystemPasswordChar = true;
      // 
      // lblPassword
      // 
      this.lblPassword.AutoSize = true;
      this.lblPassword.BackColor = System.Drawing.Color.Transparent;
      this.lblPassword.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblPassword.Location = new System.Drawing.Point(47, 81);
      this.lblPassword.Name = "lblPassword";
      this.lblPassword.Size = new System.Drawing.Size(60, 15);
      this.lblPassword.TabIndex = 26;
      this.lblPassword.Text = "Password:";
      // 
      // labelHelpSocket
      // 
      this.labelHelpSocket.AutoSize = true;
      this.labelHelpSocket.Location = new System.Drawing.Point(442, 111);
      this.labelHelpSocket.Name = "labelHelpSocket";
      this.labelHelpSocket.Size = new System.Drawing.Size(303, 15);
      this.labelHelpSocket.TabIndex = 13;
      this.labelHelpSocket.Text = "Path to local socket or pipe file. Leave empty for default.";
      this.labelHelpSocket.Visible = false;
      // 
      // labelPromptSocket
      // 
      this.labelPromptSocket.AutoSize = true;
      this.labelPromptSocket.Location = new System.Drawing.Point(13, 111);
      this.labelPromptSocket.Name = "labelPromptSocket";
      this.labelPromptSocket.Size = new System.Drawing.Size(100, 15);
      this.labelPromptSocket.TabIndex = 12;
      this.labelPromptSocket.Text = "Socket/Pipe Path:";
      this.labelPromptSocket.Visible = false;
      // 
      // socketPath
      // 
      this.socketPath.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Socket", true));
      this.socketPath.Location = new System.Drawing.Point(119, 108);
      this.socketPath.MaxLength = 484;
      this.socketPath.Name = "socketPath";
      this.socketPath.Size = new System.Drawing.Size(317, 23);
      this.socketPath.TabIndex = 4;
      this.socketPath.Visible = false;
      // 
      // bindingSource
      // 
      this.bindingSource.DataSource = typeof(MySQL.Utility.MySqlWorkbenchConnection);
      // 
      // labelHelpUserName
      // 
      this.labelHelpUserName.AutoSize = true;
      this.labelHelpUserName.Location = new System.Drawing.Point(442, 51);
      this.labelHelpUserName.Name = "labelHelpUserName";
      this.labelHelpUserName.Size = new System.Drawing.Size(187, 15);
      this.labelHelpUserName.TabIndex = 7;
      this.labelHelpUserName.Text = "Name of the user to connect with.";
      // 
      // port
      // 
      this.port.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Port", true));
      this.port.Location = new System.Drawing.Point(312, 19);
      this.port.Name = "port";
      this.port.Size = new System.Drawing.Size(124, 23);
      this.port.TabIndex = 5;
      // 
      // userName
      // 
      this.userName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "UserName", true));
      this.userName.Location = new System.Drawing.Point(119, 48);
      this.userName.MaxLength = 679;
      this.userName.Name = "userName";
      this.userName.Size = new System.Drawing.Size(317, 23);
      this.userName.TabIndex = 6;
      // 
      // hostName
      // 
      this.hostName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Host", true));
      this.hostName.Location = new System.Drawing.Point(119, 19);
      this.hostName.MaxLength = 484;
      this.hostName.Name = "hostName";
      this.hostName.Size = new System.Drawing.Size(151, 23);
      this.hostName.TabIndex = 3;
      // 
      // labelHelpHostName
      // 
      this.labelHelpHostName.AutoSize = true;
      this.labelHelpHostName.Location = new System.Drawing.Point(442, 23);
      this.labelHelpHostName.Name = "labelHelpHostName";
      this.labelHelpHostName.Size = new System.Drawing.Size(276, 15);
      this.labelHelpHostName.TabIndex = 4;
      this.labelHelpHostName.Text = "Name or IP address of the server host - TCP/IP port";
      // 
      // labelPromptPort
      // 
      this.labelPromptPort.AutoSize = true;
      this.labelPromptPort.Location = new System.Drawing.Point(276, 23);
      this.labelPromptPort.Name = "labelPromptPort";
      this.labelPromptPort.Size = new System.Drawing.Size(32, 15);
      this.labelPromptPort.TabIndex = 2;
      this.labelPromptPort.Text = "Port:";
      // 
      // labelPromptUserName
      // 
      this.labelPromptUserName.AutoSize = true;
      this.labelPromptUserName.Location = new System.Drawing.Point(50, 51);
      this.labelPromptUserName.Name = "labelPromptUserName";
      this.labelPromptUserName.Size = new System.Drawing.Size(63, 15);
      this.labelPromptUserName.TabIndex = 5;
      this.labelPromptUserName.Text = "Username:";
      // 
      // labelPromptHostName
      // 
      this.labelPromptHostName.AutoSize = true;
      this.labelPromptHostName.Location = new System.Drawing.Point(48, 23);
      this.labelPromptHostName.Name = "labelPromptHostName";
      this.labelPromptHostName.Size = new System.Drawing.Size(65, 15);
      this.labelPromptHostName.TabIndex = 0;
      this.labelPromptHostName.Text = "Hostname:";
      // 
      // advancedPage
      // 
      this.advancedPage.Controls.Add(this.label21);
      this.advancedPage.Controls.Add(this.label20);
      this.advancedPage.Controls.Add(this.label19);
      this.advancedPage.Controls.Add(this.textBox4);
      this.advancedPage.Controls.Add(this.textBox3);
      this.advancedPage.Controls.Add(this.textBox2);
      this.advancedPage.Controls.Add(this.textBox1);
      this.advancedPage.Controls.Add(this.label18);
      this.advancedPage.Controls.Add(this.label17);
      this.advancedPage.Controls.Add(this.label16);
      this.advancedPage.Controls.Add(this.label15);
      this.advancedPage.Controls.Add(this.label14);
      this.advancedPage.Controls.Add(this.label13);
      this.advancedPage.Controls.Add(this.label12);
      this.advancedPage.Controls.Add(this.labelCompression);
      this.advancedPage.Controls.Add(this.useSSL);
      this.advancedPage.Controls.Add(this.useANSI);
      this.advancedPage.Controls.Add(this.useCompression);
      this.advancedPage.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.advancedPage.Location = new System.Drawing.Point(4, 24);
      this.advancedPage.Name = "advancedPage";
      this.advancedPage.Padding = new System.Windows.Forms.Padding(3);
      this.advancedPage.Size = new System.Drawing.Size(761, 150);
      this.advancedPage.TabIndex = 1;
      this.advancedPage.Text = "Advanced";
      this.advancedPage.UseVisualStyleBackColor = true;
      // 
      // label21
      // 
      this.label21.AutoSize = true;
      this.label21.Location = new System.Drawing.Point(420, 258);
      this.label21.Name = "label21";
      this.label21.Size = new System.Drawing.Size(323, 15);
      this.label21.TabIndex = 17;
      this.label21.Text = "Optional list of permissible ciphers to use for SSL encryption";
      this.label21.Visible = false;
      // 
      // label20
      // 
      this.label20.AutoSize = true;
      this.label20.Location = new System.Drawing.Point(420, 216);
      this.label20.Name = "label20";
      this.label20.Size = new System.Drawing.Size(109, 15);
      this.label20.TabIndex = 16;
      this.label20.Text = "Path to Key for SSL.";
      this.label20.Visible = false;
      // 
      // label19
      // 
      this.label19.AutoSize = true;
      this.label19.Location = new System.Drawing.Point(420, 175);
      this.label19.Name = "label19";
      this.label19.Size = new System.Drawing.Size(165, 15);
      this.label19.TabIndex = 15;
      this.label19.Text = "Path to Certificate File for SSL.";
      this.label19.Visible = false;
      // 
      // textBox4
      // 
      this.textBox4.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "SSLCipher", true));
      this.textBox4.Location = new System.Drawing.Point(83, 255);
      this.textBox4.Name = "textBox4";
      this.textBox4.Size = new System.Drawing.Size(325, 23);
      this.textBox4.TabIndex = 15;
      this.textBox4.Visible = false;
      // 
      // textBox3
      // 
      this.textBox3.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "SSLKey", true));
      this.textBox3.Location = new System.Drawing.Point(83, 208);
      this.textBox3.Name = "textBox3";
      this.textBox3.Size = new System.Drawing.Size(325, 23);
      this.textBox3.TabIndex = 14;
      this.textBox3.Visible = false;
      // 
      // textBox2
      // 
      this.textBox2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "SSLCert", true));
      this.textBox2.Location = new System.Drawing.Point(83, 167);
      this.textBox2.Name = "textBox2";
      this.textBox2.Size = new System.Drawing.Size(325, 23);
      this.textBox2.TabIndex = 13;
      this.textBox2.Visible = false;
      // 
      // textBox1
      // 
      this.textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "SSLCA", true));
      this.textBox1.Location = new System.Drawing.Point(83, 127);
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new System.Drawing.Size(325, 23);
      this.textBox1.TabIndex = 12;
      this.textBox1.Visible = false;
      // 
      // label18
      // 
      this.label18.AutoSize = true;
      this.label18.Location = new System.Drawing.Point(15, 263);
      this.label18.Name = "label18";
      this.label18.Size = new System.Drawing.Size(66, 15);
      this.label18.TabIndex = 10;
      this.label18.Text = "SSL Cipher:";
      this.label18.Visible = false;
      // 
      // label17
      // 
      this.label17.AutoSize = true;
      this.label17.Location = new System.Drawing.Point(12, 216);
      this.label17.Name = "label17";
      this.label17.Size = new System.Drawing.Size(71, 15);
      this.label17.TabIndex = 9;
      this.label17.Text = "SSL Key File:";
      this.label17.Visible = false;
      // 
      // label16
      // 
      this.label16.AutoSize = true;
      this.label16.Location = new System.Drawing.Point(3, 175);
      this.label16.Name = "label16";
      this.label16.Size = new System.Drawing.Size(80, 15);
      this.label16.TabIndex = 8;
      this.label16.Text = "SSL CERT File:";
      this.label16.Visible = false;
      // 
      // label15
      // 
      this.label15.AutoSize = true;
      this.label15.Location = new System.Drawing.Point(420, 134);
      this.label15.Name = "label15";
      this.label15.Size = new System.Drawing.Size(218, 15);
      this.label15.TabIndex = 7;
      this.label15.Text = "Path to Certificate Authority File for SSL.";
      this.label15.Visible = false;
      // 
      // label14
      // 
      this.label14.AutoSize = true;
      this.label14.Location = new System.Drawing.Point(15, 134);
      this.label14.Name = "label14";
      this.label14.Size = new System.Drawing.Size(68, 15);
      this.label14.TabIndex = 6;
      this.label14.Text = "SSL CA File:";
      this.label14.Visible = false;
      // 
      // label13
      // 
      this.label13.AutoSize = true;
      this.label13.Location = new System.Drawing.Point(420, 84);
      this.label13.Name = "label13";
      this.label13.Size = new System.Drawing.Size(195, 15);
      this.label13.TabIndex = 5;
      this.label13.Text = "This option turns on SSL encryption";
      this.label13.Visible = false;
      // 
      // label12
      // 
      this.label12.AutoSize = true;
      this.label12.Location = new System.Drawing.Point(420, 53);
      this.label12.Name = "label12";
      this.label12.Size = new System.Drawing.Size(301, 15);
      this.label12.TabIndex = 3;
      this.label12.Text = "If enabled this option overwrites the server side settings.";
      // 
      // labelCompression
      // 
      this.labelCompression.AutoSize = true;
      this.labelCompression.Location = new System.Drawing.Point(420, 26);
      this.labelCompression.Name = "labelCompression";
      this.labelCompression.Size = new System.Drawing.Size(215, 15);
      this.labelCompression.TabIndex = 1;
      this.labelCompression.Text = "Select this option for WAN connections";
      // 
      // useSSL
      // 
      this.useSSL.AutoSize = true;
      this.useSSL.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "UseSSL", true));
      this.useSSL.Location = new System.Drawing.Point(87, 84);
      this.useSSL.Name = "useSSL";
      this.useSSL.Size = new System.Drawing.Size(125, 19);
      this.useSSL.TabIndex = 11;
      this.useSSL.Text = "Use SSL if available";
      this.useSSL.UseVisualStyleBackColor = true;
      this.useSSL.Visible = false;
      // 
      // useANSI
      // 
      this.useANSI.AutoSize = true;
      this.useANSI.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "UseAnsiQuotes", true));
      this.useANSI.Location = new System.Drawing.Point(87, 52);
      this.useANSI.Name = "useANSI";
      this.useANSI.Size = new System.Drawing.Size(216, 19);
      this.useANSI.TabIndex = 10;
      this.useANSI.Text = "Use ANSI quotes to quote identifiers";
      this.useANSI.UseVisualStyleBackColor = true;
      // 
      // useCompression
      // 
      this.useCompression.AutoSize = true;
      this.useCompression.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "ClientCompress", true));
      this.useCompression.Location = new System.Drawing.Point(87, 22);
      this.useCompression.Name = "useCompression";
      this.useCompression.Size = new System.Drawing.Size(166, 19);
      this.useCompression.TabIndex = 9;
      this.useCompression.Text = "Use Compression protocol";
      this.useCompression.UseVisualStyleBackColor = true;
      // 
      // connectionMethod
      // 
      this.connectionMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.connectionMethod.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.connectionMethod.FormattingEnabled = true;
      this.connectionMethod.Items.AddRange(new object[] {
            "Standard (TCP/IP)",
            "Local Socket/Pipe"});
      this.connectionMethod.Location = new System.Drawing.Point(135, 40);
      this.connectionMethod.Name = "connectionMethod";
      this.connectionMethod.Size = new System.Drawing.Size(420, 23);
      this.connectionMethod.TabIndex = 1;
      this.connectionMethod.SelectedIndexChanged += new System.EventHandler(this.connectionMethod_SelectedIndexChanged);
      // 
      // labelHelpMethod
      // 
      this.labelHelpMethod.AutoSize = true;
      this.labelHelpMethod.BackColor = System.Drawing.Color.Transparent;
      this.labelHelpMethod.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labelHelpMethod.Location = new System.Drawing.Point(557, 43);
      this.labelHelpMethod.Name = "labelHelpMethod";
      this.labelHelpMethod.Size = new System.Drawing.Size(220, 15);
      this.labelHelpMethod.TabIndex = 5;
      this.labelHelpMethod.Text = "Method to use to connect to the RDBMS";
      // 
      // labelPromptMethod
      // 
      this.labelPromptMethod.AutoSize = true;
      this.labelPromptMethod.BackColor = System.Drawing.Color.Transparent;
      this.labelPromptMethod.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labelPromptMethod.Location = new System.Drawing.Point(12, 43);
      this.labelPromptMethod.Name = "labelPromptMethod";
      this.labelPromptMethod.Size = new System.Drawing.Size(117, 15);
      this.labelPromptMethod.TabIndex = 3;
      this.labelPromptMethod.Text = "Connection Method:";
      // 
      // labelHelpName
      // 
      this.labelHelpName.AutoSize = true;
      this.labelHelpName.BackColor = System.Drawing.Color.Transparent;
      this.labelHelpName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labelHelpName.Location = new System.Drawing.Point(557, 14);
      this.labelHelpName.Name = "labelHelpName";
      this.labelHelpName.Size = new System.Drawing.Size(176, 15);
      this.labelHelpName.TabIndex = 2;
      this.labelHelpName.Text = "Type a name for the connection";
      // 
      // connectionName
      // 
      this.connectionName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Name", true));
      this.connectionName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.connectionName.Location = new System.Drawing.Point(135, 11);
      this.connectionName.MaxLength = 358;
      this.connectionName.Name = "connectionName";
      this.connectionName.Size = new System.Drawing.Size(420, 23);
      this.connectionName.TabIndex = 0;
      this.connectionName.TextChanged += new System.EventHandler(this.connectionName_TextChanged);
      // 
      // labelPromptName
      // 
      this.labelPromptName.AutoSize = true;
      this.labelPromptName.BackColor = System.Drawing.Color.Transparent;
      this.labelPromptName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labelPromptName.Location = new System.Drawing.Point(22, 14);
      this.labelPromptName.Name = "labelPromptName";
      this.labelPromptName.Size = new System.Drawing.Size(107, 15);
      this.labelPromptName.TabIndex = 0;
      this.labelPromptName.Text = "Connection Name:";
      // 
      // testButton
      // 
      this.testButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.testButton.Location = new System.Drawing.Point(491, 250);
      this.testButton.Name = "testButton";
      this.testButton.Size = new System.Drawing.Size(128, 23);
      this.testButton.TabIndex = 18;
      this.testButton.Text = "Test Connection";
      this.testButton.UseVisualStyleBackColor = true;
      this.testButton.Click += new System.EventHandler(this.testButton_Click);
      // 
      // cancelButton
      // 
      this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.cancelButton.Location = new System.Drawing.Point(706, 249);
      this.cancelButton.Name = "cancelButton";
      this.cancelButton.Size = new System.Drawing.Size(75, 23);
      this.cancelButton.TabIndex = 17;
      this.cancelButton.Text = "Cancel";
      this.cancelButton.UseVisualStyleBackColor = true;
      // 
      // okButton
      // 
      this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.okButton.Enabled = false;
      this.okButton.Location = new System.Drawing.Point(625, 250);
      this.okButton.Name = "okButton";
      this.okButton.Size = new System.Drawing.Size(75, 23);
      this.okButton.TabIndex = 16;
      this.okButton.Text = "OK";
      this.okButton.UseVisualStyleBackColor = true;
      this.okButton.Click += new System.EventHandler(this.okButton_Click);
      // 
      // NewNonWindowsConnectionDialog
      // 
      this.AcceptButton = this.okButton;
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.BackColor = System.Drawing.SystemColors.Window;
      this.CancelButton = this.cancelButton;
      this.ClientSize = new System.Drawing.Size(796, 285);
      this.Controls.Add(this.tabControl1);
      this.Controls.Add(this.connectionMethod);
      this.Controls.Add(this.labelHelpMethod);
      this.Controls.Add(this.labelPromptMethod);
      this.Controls.Add(this.labelHelpName);
      this.Controls.Add(this.connectionName);
      this.Controls.Add(this.labelPromptName);
      this.Controls.Add(this.testButton);
      this.Controls.Add(this.okButton);
      this.Controls.Add(this.cancelButton);
      this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Location = new System.Drawing.Point(0, 425);
      this.Name = "NewNonWindowsConnectionDialog";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Setup New Non-Windows Connection";
      this.Paint += new System.Windows.Forms.PaintEventHandler(this.commandAreaPanel_Paint);
      this.tabControl1.ResumeLayout(false);
      this.parametersPage.ResumeLayout(false);
      this.parametersPage.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
      this.advancedPage.ResumeLayout(false);
      this.advancedPage.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TabControl tabControl1;
    private System.Windows.Forms.TabPage parametersPage;
    private System.Windows.Forms.Label labelHelpUserName;
    private System.Windows.Forms.TextBox port;
    private System.Windows.Forms.TextBox userName;
    private System.Windows.Forms.TextBox hostName;
    private System.Windows.Forms.Label labelHelpHostName;
    private System.Windows.Forms.Label labelPromptPort;
    private System.Windows.Forms.Label labelPromptUserName;
    private System.Windows.Forms.Label labelPromptHostName;
    private System.Windows.Forms.TabPage advancedPage;
    private System.Windows.Forms.Label label13;
    private System.Windows.Forms.Label label12;
    private System.Windows.Forms.Label labelCompression;
    private System.Windows.Forms.CheckBox useSSL;
    private System.Windows.Forms.CheckBox useANSI;
    private System.Windows.Forms.CheckBox useCompression;
    private System.Windows.Forms.ComboBox connectionMethod;
    private System.Windows.Forms.Label labelHelpMethod;
    private System.Windows.Forms.Label labelPromptMethod;
    private System.Windows.Forms.Label labelHelpName;
    private System.Windows.Forms.TextBox connectionName;
    private System.Windows.Forms.Label labelPromptName;
    private System.Windows.Forms.Button testButton;
    private System.Windows.Forms.Button cancelButton;
    private System.Windows.Forms.Button okButton;
    private System.Windows.Forms.Label label21;
    private System.Windows.Forms.Label label20;
    private System.Windows.Forms.Label label19;
    private System.Windows.Forms.TextBox textBox4;
    private System.Windows.Forms.TextBox textBox3;
    private System.Windows.Forms.TextBox textBox2;
    private System.Windows.Forms.TextBox textBox1;
    private System.Windows.Forms.Label label18;
    private System.Windows.Forms.Label label17;
    private System.Windows.Forms.Label label16;
    private System.Windows.Forms.Label label15;
    private System.Windows.Forms.Label label14;
    private System.Windows.Forms.BindingSource bindingSource;
    private System.Windows.Forms.Label labelHelpSocket;
    private System.Windows.Forms.Label labelPromptSocket;
    private System.Windows.Forms.TextBox socketPath;
    private System.Windows.Forms.CheckBox savePasswordInVault;
    private System.Windows.Forms.TextBox txtPassword;
    private System.Windows.Forms.Label lblPassword;
  }
}