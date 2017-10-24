namespace NetsuiteEnvironmentViewer
{
	partial class Main
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
			this.button1 = new System.Windows.Forms.Button();
			this.tbCtrlEnvironment1 = new System.Windows.Forms.TabControl();
			this.tbPgEnvironment1Records = new System.Windows.Forms.TabPage();
			this.tvEnvironment1Records = new NetsuiteEnvironmentViewer.MyTreeView();
			this.tbPgEnvironment1Scripts = new System.Windows.Forms.TabPage();
			this.tvEnvironment1Scripts = new NetsuiteEnvironmentViewer.MyTreeView();
			this.tbCtrlEnvironment2 = new System.Windows.Forms.TabControl();
			this.tbPgEnvironment2Records = new System.Windows.Forms.TabPage();
			this.tvEnvironment2Records = new NetsuiteEnvironmentViewer.MyTreeView();
			this.tbPgEnvironment2Scripts = new System.Windows.Forms.TabPage();
			this.tvEnvironment2Scripts = new NetsuiteEnvironmentViewer.MyTreeView();
			this.chkRecords = new System.Windows.Forms.CheckBox();
			this.chkScripts = new System.Windows.Forms.CheckBox();
			this.btnSaveSettings = new System.Windows.Forms.Button();
			this.btnCompare = new System.Windows.Forms.Button();
			this.tblLayout = new System.Windows.Forms.TableLayoutPanel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.grpEnvironment1 = new System.Windows.Forms.GroupBox();
			this.btnOpenCSVImport1 = new System.Windows.Forms.Button();
			this.lblUrl1 = new System.Windows.Forms.Label();
			this.lblRole1 = new System.Windows.Forms.Label();
			this.txtUrl1 = new System.Windows.Forms.TextBox();
			this.lblSignature1 = new System.Windows.Forms.Label();
			this.txtRole1 = new System.Windows.Forms.TextBox();
			this.lblEmail1 = new System.Windows.Forms.Label();
			this.lblAccount1 = new System.Windows.Forms.Label();
			this.txtAccount1 = new System.Windows.Forms.TextBox();
			this.txtEmail1 = new System.Windows.Forms.TextBox();
			this.txtSignature1 = new System.Windows.Forms.TextBox();
			this.pnlEnvironment1TreeViews = new System.Windows.Forms.Panel();
			this.panel3 = new System.Windows.Forms.Panel();
			this.btnIgnoreSettings = new System.Windows.Forms.Button();
			this.grpEnvironment2 = new System.Windows.Forms.GroupBox();
			this.btnOpenCSVImport2 = new System.Windows.Forms.Button();
			this.chkUseSameCredentials = new System.Windows.Forms.CheckBox();
			this.lblUrl2 = new System.Windows.Forms.Label();
			this.lblRole2 = new System.Windows.Forms.Label();
			this.txtUrl2 = new System.Windows.Forms.TextBox();
			this.lblSignature2 = new System.Windows.Forms.Label();
			this.txtRole2 = new System.Windows.Forms.TextBox();
			this.lblEmail2 = new System.Windows.Forms.Label();
			this.lblAccount2 = new System.Windows.Forms.Label();
			this.txtAccount2 = new System.Windows.Forms.TextBox();
			this.txtEmail2 = new System.Windows.Forms.TextBox();
			this.txtSignature2 = new System.Windows.Forms.TextBox();
			this.pnlEnvironment2TreeViews = new System.Windows.Forms.Panel();
			this.tbCtrlEnvironment1.SuspendLayout();
			this.tbPgEnvironment1Records.SuspendLayout();
			this.tbPgEnvironment1Scripts.SuspendLayout();
			this.tbCtrlEnvironment2.SuspendLayout();
			this.tbPgEnvironment2Records.SuspendLayout();
			this.tbPgEnvironment2Scripts.SuspendLayout();
			this.tblLayout.SuspendLayout();
			this.panel1.SuspendLayout();
			this.grpEnvironment1.SuspendLayout();
			this.pnlEnvironment1TreeViews.SuspendLayout();
			this.panel3.SuspendLayout();
			this.grpEnvironment2.SuspendLayout();
			this.pnlEnvironment2TreeViews.SuspendLayout();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(9, 94);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(149, 23);
			this.button1.TabIndex = 12;
			this.button1.Text = "Pull NetSuite Env Data";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.btnPullNetsuiteEnvironmentData_Click);
			// 
			// tbCtrlEnvironment1
			// 
			this.tbCtrlEnvironment1.Controls.Add(this.tbPgEnvironment1Records);
			this.tbCtrlEnvironment1.Controls.Add(this.tbPgEnvironment1Scripts);
			this.tbCtrlEnvironment1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tbCtrlEnvironment1.Location = new System.Drawing.Point(0, 0);
			this.tbCtrlEnvironment1.Name = "tbCtrlEnvironment1";
			this.tbCtrlEnvironment1.SelectedIndex = 0;
			this.tbCtrlEnvironment1.Size = new System.Drawing.Size(436, 160);
			this.tbCtrlEnvironment1.TabIndex = 13;
			this.tbCtrlEnvironment1.SelectedIndexChanged += new System.EventHandler(this.tbCtrlEnvironment1_SelectedIndexChanged);
			// 
			// tbPgEnvironment1Records
			// 
			this.tbPgEnvironment1Records.Controls.Add(this.tvEnvironment1Records);
			this.tbPgEnvironment1Records.Location = new System.Drawing.Point(4, 22);
			this.tbPgEnvironment1Records.Name = "tbPgEnvironment1Records";
			this.tbPgEnvironment1Records.Padding = new System.Windows.Forms.Padding(3);
			this.tbPgEnvironment1Records.Size = new System.Drawing.Size(428, 134);
			this.tbPgEnvironment1Records.TabIndex = 0;
			this.tbPgEnvironment1Records.Text = "Records";
			this.tbPgEnvironment1Records.UseVisualStyleBackColor = true;
			// 
			// tvEnvironment1Records
			// 
			this.tvEnvironment1Records.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tvEnvironment1Records.Location = new System.Drawing.Point(3, 3);
			this.tvEnvironment1Records.Name = "tvEnvironment1Records";
			this.tvEnvironment1Records.Size = new System.Drawing.Size(422, 128);
			this.tvEnvironment1Records.TabIndex = 0;
			this.tvEnvironment1Records.AfterCollapse += new System.Windows.Forms.TreeViewEventHandler(this.tvEnvironment1Records_AfterCollapse);
			this.tvEnvironment1Records.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.tvEnvironment1Records_AfterExpand);
			// 
			// tbPgEnvironment1Scripts
			// 
			this.tbPgEnvironment1Scripts.Controls.Add(this.tvEnvironment1Scripts);
			this.tbPgEnvironment1Scripts.Location = new System.Drawing.Point(4, 22);
			this.tbPgEnvironment1Scripts.Name = "tbPgEnvironment1Scripts";
			this.tbPgEnvironment1Scripts.Padding = new System.Windows.Forms.Padding(3);
			this.tbPgEnvironment1Scripts.Size = new System.Drawing.Size(428, 134);
			this.tbPgEnvironment1Scripts.TabIndex = 1;
			this.tbPgEnvironment1Scripts.Text = "Scripts";
			this.tbPgEnvironment1Scripts.UseVisualStyleBackColor = true;
			// 
			// tvEnvironment1Scripts
			// 
			this.tvEnvironment1Scripts.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tvEnvironment1Scripts.Location = new System.Drawing.Point(3, 3);
			this.tvEnvironment1Scripts.Name = "tvEnvironment1Scripts";
			this.tvEnvironment1Scripts.Size = new System.Drawing.Size(422, 128);
			this.tvEnvironment1Scripts.TabIndex = 0;
			this.tvEnvironment1Scripts.AfterCollapse += new System.Windows.Forms.TreeViewEventHandler(this.tvEnvironment1Scripts_AfterCollapse);
			this.tvEnvironment1Scripts.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.tvEnvironment1Scripts_BeforeExpand);
			this.tvEnvironment1Scripts.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.tvEnvironment1Scripts_AfterExpand);
			this.tvEnvironment1Scripts.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvEnvironment1Scripts_NodeMouseDoubleClick);
			// 
			// tbCtrlEnvironment2
			// 
			this.tbCtrlEnvironment2.Controls.Add(this.tbPgEnvironment2Records);
			this.tbCtrlEnvironment2.Controls.Add(this.tbPgEnvironment2Scripts);
			this.tbCtrlEnvironment2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tbCtrlEnvironment2.Location = new System.Drawing.Point(0, 0);
			this.tbCtrlEnvironment2.Name = "tbCtrlEnvironment2";
			this.tbCtrlEnvironment2.SelectedIndex = 0;
			this.tbCtrlEnvironment2.Size = new System.Drawing.Size(436, 160);
			this.tbCtrlEnvironment2.TabIndex = 14;
			this.tbCtrlEnvironment2.SelectedIndexChanged += new System.EventHandler(this.tbCtrlEnvironment2_SelectedIndexChanged);
			// 
			// tbPgEnvironment2Records
			// 
			this.tbPgEnvironment2Records.Controls.Add(this.tvEnvironment2Records);
			this.tbPgEnvironment2Records.Location = new System.Drawing.Point(4, 22);
			this.tbPgEnvironment2Records.Name = "tbPgEnvironment2Records";
			this.tbPgEnvironment2Records.Padding = new System.Windows.Forms.Padding(3);
			this.tbPgEnvironment2Records.Size = new System.Drawing.Size(428, 134);
			this.tbPgEnvironment2Records.TabIndex = 0;
			this.tbPgEnvironment2Records.Text = "Records";
			this.tbPgEnvironment2Records.UseVisualStyleBackColor = true;
			// 
			// tvEnvironment2Records
			// 
			this.tvEnvironment2Records.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tvEnvironment2Records.Location = new System.Drawing.Point(3, 3);
			this.tvEnvironment2Records.Name = "tvEnvironment2Records";
			this.tvEnvironment2Records.Size = new System.Drawing.Size(422, 128);
			this.tvEnvironment2Records.TabIndex = 0;
			this.tvEnvironment2Records.AfterCollapse += new System.Windows.Forms.TreeViewEventHandler(this.tvEnvironment2Records_AfterCollapse);
			this.tvEnvironment2Records.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.tvEnvironment2Records_AfterExpand);
			// 
			// tbPgEnvironment2Scripts
			// 
			this.tbPgEnvironment2Scripts.Controls.Add(this.tvEnvironment2Scripts);
			this.tbPgEnvironment2Scripts.Location = new System.Drawing.Point(4, 22);
			this.tbPgEnvironment2Scripts.Name = "tbPgEnvironment2Scripts";
			this.tbPgEnvironment2Scripts.Padding = new System.Windows.Forms.Padding(3);
			this.tbPgEnvironment2Scripts.Size = new System.Drawing.Size(428, 134);
			this.tbPgEnvironment2Scripts.TabIndex = 1;
			this.tbPgEnvironment2Scripts.Text = "Scripts";
			this.tbPgEnvironment2Scripts.UseVisualStyleBackColor = true;
			// 
			// tvEnvironment2Scripts
			// 
			this.tvEnvironment2Scripts.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tvEnvironment2Scripts.Location = new System.Drawing.Point(3, 3);
			this.tvEnvironment2Scripts.Name = "tvEnvironment2Scripts";
			this.tvEnvironment2Scripts.Size = new System.Drawing.Size(422, 128);
			this.tvEnvironment2Scripts.TabIndex = 0;
			this.tvEnvironment2Scripts.AfterCollapse += new System.Windows.Forms.TreeViewEventHandler(this.tvEnvironment2Scripts_AfterCollapse);
			this.tvEnvironment2Scripts.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.tvEnvironment2Scripts_BeforeExpand);
			this.tvEnvironment2Scripts.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.tvEnvironment2Scripts_AfterExpand);
			this.tvEnvironment2Scripts.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvEnvironment2Scripts_NodeMouseDoubleClick);
			// 
			// chkRecords
			// 
			this.chkRecords.AutoSize = true;
			this.chkRecords.Checked = true;
			this.chkRecords.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkRecords.Location = new System.Drawing.Point(164, 98);
			this.chkRecords.Name = "chkRecords";
			this.chkRecords.Size = new System.Drawing.Size(66, 17);
			this.chkRecords.TabIndex = 15;
			this.chkRecords.Text = "Records";
			this.chkRecords.UseVisualStyleBackColor = true;
			// 
			// chkScripts
			// 
			this.chkScripts.AutoSize = true;
			this.chkScripts.Checked = true;
			this.chkScripts.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkScripts.Location = new System.Drawing.Point(236, 98);
			this.chkScripts.Name = "chkScripts";
			this.chkScripts.Size = new System.Drawing.Size(58, 17);
			this.chkScripts.TabIndex = 16;
			this.chkScripts.Text = "Scripts";
			this.chkScripts.UseVisualStyleBackColor = true;
			// 
			// btnSaveSettings
			// 
			this.btnSaveSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSaveSettings.Location = new System.Drawing.Point(347, 94);
			this.btnSaveSettings.Name = "btnSaveSettings";
			this.btnSaveSettings.Size = new System.Drawing.Size(82, 23);
			this.btnSaveSettings.TabIndex = 17;
			this.btnSaveSettings.Text = "Save Settings";
			this.btnSaveSettings.UseVisualStyleBackColor = true;
			this.btnSaveSettings.Click += new System.EventHandler(this.btnSaveSettings_Click);
			// 
			// btnCompare
			// 
			this.btnCompare.Location = new System.Drawing.Point(9, 94);
			this.btnCompare.Name = "btnCompare";
			this.btnCompare.Size = new System.Drawing.Size(149, 23);
			this.btnCompare.TabIndex = 18;
			this.btnCompare.Text = "Compare NetSuite Env Data";
			this.btnCompare.UseVisualStyleBackColor = true;
			this.btnCompare.Click += new System.EventHandler(this.btnCompare_Click);
			// 
			// tblLayout
			// 
			this.tblLayout.ColumnCount = 2;
			this.tblLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tblLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tblLayout.Controls.Add(this.panel1, 0, 0);
			this.tblLayout.Controls.Add(this.pnlEnvironment1TreeViews, 0, 1);
			this.tblLayout.Controls.Add(this.panel3, 1, 0);
			this.tblLayout.Controls.Add(this.pnlEnvironment2TreeViews, 1, 1);
			this.tblLayout.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tblLayout.Location = new System.Drawing.Point(0, 0);
			this.tblLayout.Name = "tblLayout";
			this.tblLayout.RowCount = 2;
			this.tblLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 125F));
			this.tblLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tblLayout.Size = new System.Drawing.Size(884, 291);
			this.tblLayout.TabIndex = 19;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.grpEnvironment1);
			this.panel1.Controls.Add(this.button1);
			this.panel1.Controls.Add(this.chkRecords);
			this.panel1.Controls.Add(this.chkScripts);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(3, 3);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(436, 119);
			this.panel1.TabIndex = 0;
			// 
			// grpEnvironment1
			// 
			this.grpEnvironment1.Controls.Add(this.btnOpenCSVImport1);
			this.grpEnvironment1.Controls.Add(this.lblUrl1);
			this.grpEnvironment1.Controls.Add(this.lblRole1);
			this.grpEnvironment1.Controls.Add(this.txtUrl1);
			this.grpEnvironment1.Controls.Add(this.lblSignature1);
			this.grpEnvironment1.Controls.Add(this.txtRole1);
			this.grpEnvironment1.Controls.Add(this.lblEmail1);
			this.grpEnvironment1.Controls.Add(this.lblAccount1);
			this.grpEnvironment1.Controls.Add(this.txtAccount1);
			this.grpEnvironment1.Controls.Add(this.txtEmail1);
			this.grpEnvironment1.Controls.Add(this.txtSignature1);
			this.grpEnvironment1.Dock = System.Windows.Forms.DockStyle.Top;
			this.grpEnvironment1.Location = new System.Drawing.Point(0, 0);
			this.grpEnvironment1.Name = "grpEnvironment1";
			this.grpEnvironment1.Size = new System.Drawing.Size(436, 88);
			this.grpEnvironment1.TabIndex = 1;
			this.grpEnvironment1.TabStop = false;
			this.grpEnvironment1.Text = "Environment 1";
			// 
			// btnOpenCSVImport1
			// 
			this.btnOpenCSVImport1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOpenCSVImport1.Location = new System.Drawing.Point(359, 11);
			this.btnOpenCSVImport1.Name = "btnOpenCSVImport1";
			this.btnOpenCSVImport1.Size = new System.Drawing.Size(70, 23);
			this.btnOpenCSVImport1.TabIndex = 19;
			this.btnOpenCSVImport1.Text = "CSV Import";
			this.btnOpenCSVImport1.UseVisualStyleBackColor = true;
			this.btnOpenCSVImport1.Click += new System.EventHandler(this.btnOpenCSVImport1_Click);
			// 
			// lblUrl1
			// 
			this.lblUrl1.AutoSize = true;
			this.lblUrl1.Location = new System.Drawing.Point(6, 22);
			this.lblUrl1.Name = "lblUrl1";
			this.lblUrl1.Size = new System.Drawing.Size(20, 13);
			this.lblUrl1.TabIndex = 1;
			this.lblUrl1.Text = "Url";
			// 
			// lblRole1
			// 
			this.lblRole1.AutoSize = true;
			this.lblRole1.Location = new System.Drawing.Point(362, 42);
			this.lblRole1.Name = "lblRole1";
			this.lblRole1.Size = new System.Drawing.Size(29, 13);
			this.lblRole1.TabIndex = 9;
			this.lblRole1.Text = "Role";
			// 
			// txtUrl1
			// 
			this.txtUrl1.Location = new System.Drawing.Point(32, 19);
			this.txtUrl1.Name = "txtUrl1";
			this.txtUrl1.Size = new System.Drawing.Size(188, 20);
			this.txtUrl1.TabIndex = 2;
			// 
			// lblSignature1
			// 
			this.lblSignature1.AutoSize = true;
			this.lblSignature1.Location = new System.Drawing.Point(238, 42);
			this.lblSignature1.Name = "lblSignature1";
			this.lblSignature1.Size = new System.Drawing.Size(52, 13);
			this.lblSignature1.TabIndex = 7;
			this.lblSignature1.Text = "Signature";
			// 
			// txtRole1
			// 
			this.txtRole1.Location = new System.Drawing.Point(372, 58);
			this.txtRole1.Name = "txtRole1";
			this.txtRole1.Size = new System.Drawing.Size(57, 20);
			this.txtRole1.TabIndex = 10;
			this.txtRole1.TextChanged += new System.EventHandler(this.txtRole1_TextChanged);
			// 
			// lblEmail1
			// 
			this.lblEmail1.AutoSize = true;
			this.lblEmail1.Location = new System.Drawing.Point(77, 42);
			this.lblEmail1.Name = "lblEmail1";
			this.lblEmail1.Size = new System.Drawing.Size(32, 13);
			this.lblEmail1.TabIndex = 5;
			this.lblEmail1.Text = "Email";
			// 
			// lblAccount1
			// 
			this.lblAccount1.AutoSize = true;
			this.lblAccount1.Location = new System.Drawing.Point(6, 42);
			this.lblAccount1.Name = "lblAccount1";
			this.lblAccount1.Size = new System.Drawing.Size(47, 13);
			this.lblAccount1.TabIndex = 3;
			this.lblAccount1.Text = "Account";
			// 
			// txtAccount1
			// 
			this.txtAccount1.Location = new System.Drawing.Point(9, 58);
			this.txtAccount1.Name = "txtAccount1";
			this.txtAccount1.Size = new System.Drawing.Size(65, 20);
			this.txtAccount1.TabIndex = 4;
			this.txtAccount1.TextChanged += new System.EventHandler(this.txtAccount1_TextChanged);
			// 
			// txtEmail1
			// 
			this.txtEmail1.Location = new System.Drawing.Point(80, 58);
			this.txtEmail1.Name = "txtEmail1";
			this.txtEmail1.Size = new System.Drawing.Size(140, 20);
			this.txtEmail1.TabIndex = 6;
			this.txtEmail1.TextChanged += new System.EventHandler(this.txtEmail1_TextChanged);
			// 
			// txtSignature1
			// 
			this.txtSignature1.Location = new System.Drawing.Point(226, 58);
			this.txtSignature1.Name = "txtSignature1";
			this.txtSignature1.PasswordChar = '●';
			this.txtSignature1.Size = new System.Drawing.Size(140, 20);
			this.txtSignature1.TabIndex = 8;
			this.txtSignature1.TextChanged += new System.EventHandler(this.txtSignature1_TextChanged);
			// 
			// pnlEnvironment1TreeViews
			// 
			this.pnlEnvironment1TreeViews.Controls.Add(this.tbCtrlEnvironment1);
			this.pnlEnvironment1TreeViews.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlEnvironment1TreeViews.Location = new System.Drawing.Point(3, 128);
			this.pnlEnvironment1TreeViews.Name = "pnlEnvironment1TreeViews";
			this.pnlEnvironment1TreeViews.Size = new System.Drawing.Size(436, 160);
			this.pnlEnvironment1TreeViews.TabIndex = 1;
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.btnIgnoreSettings);
			this.panel3.Controls.Add(this.grpEnvironment2);
			this.panel3.Controls.Add(this.btnCompare);
			this.panel3.Controls.Add(this.btnSaveSettings);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel3.Location = new System.Drawing.Point(445, 3);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(436, 119);
			this.panel3.TabIndex = 2;
			// 
			// btnIgnoreSettings
			// 
			this.btnIgnoreSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnIgnoreSettings.Location = new System.Drawing.Point(255, 94);
			this.btnIgnoreSettings.Name = "btnIgnoreSettings";
			this.btnIgnoreSettings.Size = new System.Drawing.Size(86, 23);
			this.btnIgnoreSettings.TabIndex = 17;
			this.btnIgnoreSettings.Text = "Ignore Settings";
			this.btnIgnoreSettings.UseVisualStyleBackColor = true;
			this.btnIgnoreSettings.Click += new System.EventHandler(this.btnIgnoreSettings_Click);
			// 
			// grpEnvironment2
			// 
			this.grpEnvironment2.Controls.Add(this.btnOpenCSVImport2);
			this.grpEnvironment2.Controls.Add(this.chkUseSameCredentials);
			this.grpEnvironment2.Controls.Add(this.lblUrl2);
			this.grpEnvironment2.Controls.Add(this.lblRole2);
			this.grpEnvironment2.Controls.Add(this.txtUrl2);
			this.grpEnvironment2.Controls.Add(this.lblSignature2);
			this.grpEnvironment2.Controls.Add(this.txtRole2);
			this.grpEnvironment2.Controls.Add(this.lblEmail2);
			this.grpEnvironment2.Controls.Add(this.lblAccount2);
			this.grpEnvironment2.Controls.Add(this.txtAccount2);
			this.grpEnvironment2.Controls.Add(this.txtEmail2);
			this.grpEnvironment2.Controls.Add(this.txtSignature2);
			this.grpEnvironment2.Dock = System.Windows.Forms.DockStyle.Top;
			this.grpEnvironment2.Location = new System.Drawing.Point(0, 0);
			this.grpEnvironment2.Name = "grpEnvironment2";
			this.grpEnvironment2.Size = new System.Drawing.Size(436, 88);
			this.grpEnvironment2.TabIndex = 12;
			this.grpEnvironment2.TabStop = false;
			this.grpEnvironment2.Text = "Environment 2";
			// 
			// btnOpenCSVImport2
			// 
			this.btnOpenCSVImport2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOpenCSVImport2.Location = new System.Drawing.Point(359, 11);
			this.btnOpenCSVImport2.Name = "btnOpenCSVImport2";
			this.btnOpenCSVImport2.Size = new System.Drawing.Size(70, 23);
			this.btnOpenCSVImport2.TabIndex = 20;
			this.btnOpenCSVImport2.Text = "CSV Import";
			this.btnOpenCSVImport2.UseVisualStyleBackColor = true;
			this.btnOpenCSVImport2.Click += new System.EventHandler(this.btnOpenCSVImport2_Click);
			// 
			// chkUseSameCredentials
			// 
			this.chkUseSameCredentials.AutoSize = true;
			this.chkUseSameCredentials.Checked = true;
			this.chkUseSameCredentials.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkUseSameCredentials.Location = new System.Drawing.Point(226, 21);
			this.chkUseSameCredentials.Name = "chkUseSameCredentials";
			this.chkUseSameCredentials.Size = new System.Drawing.Size(130, 17);
			this.chkUseSameCredentials.TabIndex = 22;
			this.chkUseSameCredentials.Text = "Use Same Credentials";
			this.chkUseSameCredentials.UseVisualStyleBackColor = true;
			this.chkUseSameCredentials.CheckedChanged += new System.EventHandler(this.chkUseSameCredentials_CheckedChanged);
			// 
			// lblUrl2
			// 
			this.lblUrl2.AutoSize = true;
			this.lblUrl2.Location = new System.Drawing.Point(6, 22);
			this.lblUrl2.Name = "lblUrl2";
			this.lblUrl2.Size = new System.Drawing.Size(20, 13);
			this.lblUrl2.TabIndex = 12;
			this.lblUrl2.Text = "Url";
			// 
			// lblRole2
			// 
			this.lblRole2.AutoSize = true;
			this.lblRole2.Location = new System.Drawing.Point(369, 42);
			this.lblRole2.Name = "lblRole2";
			this.lblRole2.Size = new System.Drawing.Size(29, 13);
			this.lblRole2.TabIndex = 20;
			this.lblRole2.Text = "Role";
			// 
			// txtUrl2
			// 
			this.txtUrl2.Location = new System.Drawing.Point(32, 19);
			this.txtUrl2.Name = "txtUrl2";
			this.txtUrl2.Size = new System.Drawing.Size(188, 20);
			this.txtUrl2.TabIndex = 13;
			// 
			// lblSignature2
			// 
			this.lblSignature2.AutoSize = true;
			this.lblSignature2.Location = new System.Drawing.Point(223, 42);
			this.lblSignature2.Name = "lblSignature2";
			this.lblSignature2.Size = new System.Drawing.Size(52, 13);
			this.lblSignature2.TabIndex = 18;
			this.lblSignature2.Text = "Signature";
			// 
			// txtRole2
			// 
			this.txtRole2.Location = new System.Drawing.Point(372, 58);
			this.txtRole2.Name = "txtRole2";
			this.txtRole2.Size = new System.Drawing.Size(57, 20);
			this.txtRole2.TabIndex = 21;
			// 
			// lblEmail2
			// 
			this.lblEmail2.AutoSize = true;
			this.lblEmail2.Location = new System.Drawing.Point(77, 42);
			this.lblEmail2.Name = "lblEmail2";
			this.lblEmail2.Size = new System.Drawing.Size(32, 13);
			this.lblEmail2.TabIndex = 16;
			this.lblEmail2.Text = "Email";
			// 
			// lblAccount2
			// 
			this.lblAccount2.AutoSize = true;
			this.lblAccount2.Location = new System.Drawing.Point(6, 42);
			this.lblAccount2.Name = "lblAccount2";
			this.lblAccount2.Size = new System.Drawing.Size(47, 13);
			this.lblAccount2.TabIndex = 14;
			this.lblAccount2.Text = "Account";
			// 
			// txtAccount2
			// 
			this.txtAccount2.Location = new System.Drawing.Point(9, 58);
			this.txtAccount2.Name = "txtAccount2";
			this.txtAccount2.Size = new System.Drawing.Size(65, 20);
			this.txtAccount2.TabIndex = 15;
			// 
			// txtEmail2
			// 
			this.txtEmail2.Location = new System.Drawing.Point(80, 58);
			this.txtEmail2.Name = "txtEmail2";
			this.txtEmail2.Size = new System.Drawing.Size(140, 20);
			this.txtEmail2.TabIndex = 17;
			// 
			// txtSignature2
			// 
			this.txtSignature2.Location = new System.Drawing.Point(226, 58);
			this.txtSignature2.Name = "txtSignature2";
			this.txtSignature2.PasswordChar = '●';
			this.txtSignature2.Size = new System.Drawing.Size(140, 20);
			this.txtSignature2.TabIndex = 19;
			// 
			// pnlEnvironment2TreeViews
			// 
			this.pnlEnvironment2TreeViews.Controls.Add(this.tbCtrlEnvironment2);
			this.pnlEnvironment2TreeViews.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlEnvironment2TreeViews.Location = new System.Drawing.Point(445, 128);
			this.pnlEnvironment2TreeViews.Name = "pnlEnvironment2TreeViews";
			this.pnlEnvironment2TreeViews.Size = new System.Drawing.Size(436, 160);
			this.pnlEnvironment2TreeViews.TabIndex = 3;
			// 
			// Main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(884, 291);
			this.Controls.Add(this.tblLayout);
			this.MinimumSize = new System.Drawing.Size(900, 330);
			this.Name = "Main";
			this.Text = "Netsuite Environment Viewer";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.Main_Load);
			this.tbCtrlEnvironment1.ResumeLayout(false);
			this.tbPgEnvironment1Records.ResumeLayout(false);
			this.tbPgEnvironment1Scripts.ResumeLayout(false);
			this.tbCtrlEnvironment2.ResumeLayout(false);
			this.tbPgEnvironment2Records.ResumeLayout(false);
			this.tbPgEnvironment2Scripts.ResumeLayout(false);
			this.tblLayout.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.grpEnvironment1.ResumeLayout(false);
			this.grpEnvironment1.PerformLayout();
			this.pnlEnvironment1TreeViews.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.grpEnvironment2.ResumeLayout(false);
			this.grpEnvironment2.PerformLayout();
			this.pnlEnvironment2TreeViews.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TabControl tbCtrlEnvironment1;
		private System.Windows.Forms.TabPage tbPgEnvironment1Records;
		private System.Windows.Forms.TabPage tbPgEnvironment1Scripts;
		private System.Windows.Forms.TabControl tbCtrlEnvironment2;
		private System.Windows.Forms.TabPage tbPgEnvironment2Records;
		private System.Windows.Forms.TabPage tbPgEnvironment2Scripts;
		private MyTreeView tvEnvironment1Records;
		private MyTreeView tvEnvironment1Scripts;
		private MyTreeView tvEnvironment2Records;
		private MyTreeView tvEnvironment2Scripts;
		private System.Windows.Forms.CheckBox chkRecords;
		private System.Windows.Forms.CheckBox chkScripts;
		private System.Windows.Forms.Button btnSaveSettings;
		private System.Windows.Forms.Button btnCompare;
		private System.Windows.Forms.TableLayoutPanel tblLayout;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.GroupBox grpEnvironment1;
		private System.Windows.Forms.Button btnOpenCSVImport1;
		private System.Windows.Forms.Label lblUrl1;
		private System.Windows.Forms.Label lblRole1;
		private System.Windows.Forms.TextBox txtUrl1;
		private System.Windows.Forms.Label lblSignature1;
		private System.Windows.Forms.TextBox txtRole1;
		private System.Windows.Forms.Label lblEmail1;
		private System.Windows.Forms.Label lblAccount1;
		private System.Windows.Forms.TextBox txtAccount1;
		private System.Windows.Forms.TextBox txtEmail1;
		private System.Windows.Forms.TextBox txtSignature1;
		private System.Windows.Forms.Panel pnlEnvironment1TreeViews;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.GroupBox grpEnvironment2;
		private System.Windows.Forms.Button btnOpenCSVImport2;
		private System.Windows.Forms.CheckBox chkUseSameCredentials;
		private System.Windows.Forms.Label lblUrl2;
		private System.Windows.Forms.Label lblRole2;
		private System.Windows.Forms.TextBox txtUrl2;
		private System.Windows.Forms.Label lblSignature2;
		private System.Windows.Forms.TextBox txtRole2;
		private System.Windows.Forms.Label lblEmail2;
		private System.Windows.Forms.Label lblAccount2;
		private System.Windows.Forms.TextBox txtAccount2;
		private System.Windows.Forms.TextBox txtEmail2;
		private System.Windows.Forms.TextBox txtSignature2;
		private System.Windows.Forms.Panel pnlEnvironment2TreeViews;
		private System.Windows.Forms.Button btnIgnoreSettings;
	}
}

