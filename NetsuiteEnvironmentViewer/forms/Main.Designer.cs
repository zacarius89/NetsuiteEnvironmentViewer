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
            this.chkOnlyCustomFields = new System.Windows.Forms.CheckBox();
            this.grpEnvironment1 = new System.Windows.Forms.GroupBox();
            this.lblSuffix1 = new System.Windows.Forms.Label();
            this.txtSuffix1 = new System.Windows.Forms.TextBox();
            this.chkHideSignature = new System.Windows.Forms.CheckBox();
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
            this.lblSuffix2 = new System.Windows.Forms.Label();
            this.txtSuffix2 = new System.Windows.Forms.TextBox();
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
            this.button1.Location = new System.Drawing.Point(12, 116);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(199, 28);
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
            this.tbCtrlEnvironment1.Margin = new System.Windows.Forms.Padding(4);
            this.tbCtrlEnvironment1.Name = "tbCtrlEnvironment1";
            this.tbCtrlEnvironment1.SelectedIndex = 0;
            this.tbCtrlEnvironment1.Size = new System.Drawing.Size(623, 196);
            this.tbCtrlEnvironment1.TabIndex = 13;
            this.tbCtrlEnvironment1.SelectedIndexChanged += new System.EventHandler(this.tbCtrlEnvironment1_SelectedIndexChanged);
            // 
            // tbPgEnvironment1Records
            // 
            this.tbPgEnvironment1Records.Controls.Add(this.tvEnvironment1Records);
            this.tbPgEnvironment1Records.Location = new System.Drawing.Point(4, 25);
            this.tbPgEnvironment1Records.Margin = new System.Windows.Forms.Padding(4);
            this.tbPgEnvironment1Records.Name = "tbPgEnvironment1Records";
            this.tbPgEnvironment1Records.Padding = new System.Windows.Forms.Padding(4);
            this.tbPgEnvironment1Records.Size = new System.Drawing.Size(615, 167);
            this.tbPgEnvironment1Records.TabIndex = 0;
            this.tbPgEnvironment1Records.Text = "Records";
            this.tbPgEnvironment1Records.UseVisualStyleBackColor = true;
            // 
            // tvEnvironment1Records
            // 
            this.tvEnvironment1Records.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvEnvironment1Records.Location = new System.Drawing.Point(4, 4);
            this.tvEnvironment1Records.Margin = new System.Windows.Forms.Padding(4);
            this.tvEnvironment1Records.Name = "tvEnvironment1Records";
            this.tvEnvironment1Records.Size = new System.Drawing.Size(607, 159);
            this.tvEnvironment1Records.TabIndex = 0;
            this.tvEnvironment1Records.AfterCollapse += new System.Windows.Forms.TreeViewEventHandler(this.tvEnvironment1Records_AfterCollapse);
            this.tvEnvironment1Records.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.tvEnvironment1Records_AfterExpand);
            // 
            // tbPgEnvironment1Scripts
            // 
            this.tbPgEnvironment1Scripts.Controls.Add(this.tvEnvironment1Scripts);
            this.tbPgEnvironment1Scripts.Location = new System.Drawing.Point(4, 25);
            this.tbPgEnvironment1Scripts.Margin = new System.Windows.Forms.Padding(4);
            this.tbPgEnvironment1Scripts.Name = "tbPgEnvironment1Scripts";
            this.tbPgEnvironment1Scripts.Padding = new System.Windows.Forms.Padding(4);
            this.tbPgEnvironment1Scripts.Size = new System.Drawing.Size(780, 167);
            this.tbPgEnvironment1Scripts.TabIndex = 1;
            this.tbPgEnvironment1Scripts.Text = "Scripts";
            this.tbPgEnvironment1Scripts.UseVisualStyleBackColor = true;
            // 
            // tvEnvironment1Scripts
            // 
            this.tvEnvironment1Scripts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvEnvironment1Scripts.Location = new System.Drawing.Point(4, 4);
            this.tvEnvironment1Scripts.Margin = new System.Windows.Forms.Padding(4);
            this.tvEnvironment1Scripts.Name = "tvEnvironment1Scripts";
            this.tvEnvironment1Scripts.Size = new System.Drawing.Size(772, 159);
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
            this.tbCtrlEnvironment2.Margin = new System.Windows.Forms.Padding(4);
            this.tbCtrlEnvironment2.Name = "tbCtrlEnvironment2";
            this.tbCtrlEnvironment2.SelectedIndex = 0;
            this.tbCtrlEnvironment2.Size = new System.Drawing.Size(623, 196);
            this.tbCtrlEnvironment2.TabIndex = 14;
            this.tbCtrlEnvironment2.SelectedIndexChanged += new System.EventHandler(this.tbCtrlEnvironment2_SelectedIndexChanged);
            // 
            // tbPgEnvironment2Records
            // 
            this.tbPgEnvironment2Records.Controls.Add(this.tvEnvironment2Records);
            this.tbPgEnvironment2Records.Location = new System.Drawing.Point(4, 25);
            this.tbPgEnvironment2Records.Margin = new System.Windows.Forms.Padding(4);
            this.tbPgEnvironment2Records.Name = "tbPgEnvironment2Records";
            this.tbPgEnvironment2Records.Padding = new System.Windows.Forms.Padding(4);
            this.tbPgEnvironment2Records.Size = new System.Drawing.Size(615, 167);
            this.tbPgEnvironment2Records.TabIndex = 0;
            this.tbPgEnvironment2Records.Text = "Records";
            this.tbPgEnvironment2Records.UseVisualStyleBackColor = true;
            // 
            // tvEnvironment2Records
            // 
            this.tvEnvironment2Records.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvEnvironment2Records.Location = new System.Drawing.Point(4, 4);
            this.tvEnvironment2Records.Margin = new System.Windows.Forms.Padding(4);
            this.tvEnvironment2Records.Name = "tvEnvironment2Records";
            this.tvEnvironment2Records.Size = new System.Drawing.Size(607, 159);
            this.tvEnvironment2Records.TabIndex = 0;
            this.tvEnvironment2Records.AfterCollapse += new System.Windows.Forms.TreeViewEventHandler(this.tvEnvironment2Records_AfterCollapse);
            this.tvEnvironment2Records.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.tvEnvironment2Records_AfterExpand);
            // 
            // tbPgEnvironment2Scripts
            // 
            this.tbPgEnvironment2Scripts.Controls.Add(this.tvEnvironment2Scripts);
            this.tbPgEnvironment2Scripts.Location = new System.Drawing.Point(4, 25);
            this.tbPgEnvironment2Scripts.Margin = new System.Windows.Forms.Padding(4);
            this.tbPgEnvironment2Scripts.Name = "tbPgEnvironment2Scripts";
            this.tbPgEnvironment2Scripts.Padding = new System.Windows.Forms.Padding(4);
            this.tbPgEnvironment2Scripts.Size = new System.Drawing.Size(781, 167);
            this.tbPgEnvironment2Scripts.TabIndex = 1;
            this.tbPgEnvironment2Scripts.Text = "Scripts";
            this.tbPgEnvironment2Scripts.UseVisualStyleBackColor = true;
            // 
            // tvEnvironment2Scripts
            // 
            this.tvEnvironment2Scripts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvEnvironment2Scripts.Location = new System.Drawing.Point(4, 4);
            this.tvEnvironment2Scripts.Margin = new System.Windows.Forms.Padding(4);
            this.tvEnvironment2Scripts.Name = "tvEnvironment2Scripts";
            this.tvEnvironment2Scripts.Size = new System.Drawing.Size(773, 159);
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
            this.chkRecords.Location = new System.Drawing.Point(219, 121);
            this.chkRecords.Margin = new System.Windows.Forms.Padding(4);
            this.chkRecords.Name = "chkRecords";
            this.chkRecords.Size = new System.Drawing.Size(83, 21);
            this.chkRecords.TabIndex = 15;
            this.chkRecords.Text = "Records";
            this.chkRecords.UseVisualStyleBackColor = true;
            this.chkRecords.CheckedChanged += new System.EventHandler(this.chkRecords_CheckedChanged);
            // 
            // chkScripts
            // 
            this.chkScripts.AutoSize = true;
            this.chkScripts.Checked = true;
            this.chkScripts.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkScripts.Location = new System.Drawing.Point(476, 121);
            this.chkScripts.Margin = new System.Windows.Forms.Padding(4);
            this.chkScripts.Name = "chkScripts";
            this.chkScripts.Size = new System.Drawing.Size(73, 21);
            this.chkScripts.TabIndex = 16;
            this.chkScripts.Text = "Scripts";
            this.chkScripts.UseVisualStyleBackColor = true;
            // 
            // btnSaveSettings
            // 
            this.btnSaveSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveSettings.Location = new System.Drawing.Point(505, 116);
            this.btnSaveSettings.Margin = new System.Windows.Forms.Padding(4);
            this.btnSaveSettings.Name = "btnSaveSettings";
            this.btnSaveSettings.Size = new System.Drawing.Size(109, 28);
            this.btnSaveSettings.TabIndex = 17;
            this.btnSaveSettings.Text = "Save Settings";
            this.btnSaveSettings.UseVisualStyleBackColor = true;
            this.btnSaveSettings.Click += new System.EventHandler(this.btnSaveSettings_Click);
            // 
            // btnCompare
            // 
            this.btnCompare.Location = new System.Drawing.Point(12, 116);
            this.btnCompare.Margin = new System.Windows.Forms.Padding(4);
            this.btnCompare.Name = "btnCompare";
            this.btnCompare.Size = new System.Drawing.Size(199, 28);
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
            this.tblLayout.Margin = new System.Windows.Forms.Padding(4);
            this.tblLayout.Name = "tblLayout";
            this.tblLayout.RowCount = 2;
            this.tblLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 154F));
            this.tblLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblLayout.Size = new System.Drawing.Size(1262, 358);
            this.tblLayout.TabIndex = 19;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chkOnlyCustomFields);
            this.panel1.Controls.Add(this.grpEnvironment1);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.chkRecords);
            this.panel1.Controls.Add(this.chkScripts);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(4, 4);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(623, 146);
            this.panel1.TabIndex = 0;
            // 
            // chkOnlyCustomFields
            // 
            this.chkOnlyCustomFields.AutoSize = true;
            this.chkOnlyCustomFields.Checked = true;
            this.chkOnlyCustomFields.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkOnlyCustomFields.Location = new System.Drawing.Point(315, 121);
            this.chkOnlyCustomFields.Margin = new System.Windows.Forms.Padding(4);
            this.chkOnlyCustomFields.Name = "chkOnlyCustomFields";
            this.chkOnlyCustomFields.Size = new System.Drawing.Size(151, 21);
            this.chkOnlyCustomFields.TabIndex = 17;
            this.chkOnlyCustomFields.Text = "Only Custom Fields";
            this.chkOnlyCustomFields.UseVisualStyleBackColor = true;
            // 
            // grpEnvironment1
            // 
            this.grpEnvironment1.Controls.Add(this.lblSuffix1);
            this.grpEnvironment1.Controls.Add(this.txtSuffix1);
            this.grpEnvironment1.Controls.Add(this.chkHideSignature);
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
            this.grpEnvironment1.Margin = new System.Windows.Forms.Padding(4);
            this.grpEnvironment1.Name = "grpEnvironment1";
            this.grpEnvironment1.Padding = new System.Windows.Forms.Padding(4);
            this.grpEnvironment1.Size = new System.Drawing.Size(623, 108);
            this.grpEnvironment1.TabIndex = 1;
            this.grpEnvironment1.TabStop = false;
            this.grpEnvironment1.Text = "Environment 1";
            // 
            // lblSuffix1
            // 
            this.lblSuffix1.AutoSize = true;
            this.lblSuffix1.Location = new System.Drawing.Point(94, 49);
            this.lblSuffix1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSuffix1.Name = "lblSuffix1";
            this.lblSuffix1.Size = new System.Drawing.Size(42, 17);
            this.lblSuffix1.TabIndex = 21;
            this.lblSuffix1.Text = "Suffix";
            // 
            // txtSuffix1
            // 
            this.txtSuffix1.Location = new System.Drawing.Point(97, 70);
            this.txtSuffix1.Margin = new System.Windows.Forms.Padding(4);
            this.txtSuffix1.Name = "txtSuffix1";
            this.txtSuffix1.Size = new System.Drawing.Size(48, 22);
            this.txtSuffix1.TabIndex = 22;
            // 
            // chkHideSignature
            // 
            this.chkHideSignature.AutoSize = true;
            this.chkHideSignature.Checked = true;
            this.chkHideSignature.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkHideSignature.Location = new System.Drawing.Point(294, 26);
            this.chkHideSignature.Margin = new System.Windows.Forms.Padding(4);
            this.chkHideSignature.Name = "chkHideSignature";
            this.chkHideSignature.Size = new System.Drawing.Size(124, 21);
            this.chkHideSignature.TabIndex = 20;
            this.chkHideSignature.Text = "Hide Signature";
            this.chkHideSignature.UseVisualStyleBackColor = true;
            this.chkHideSignature.CheckedChanged += new System.EventHandler(this.chkHideSignature_CheckedChanged);
            // 
            // btnOpenCSVImport1
            // 
            this.btnOpenCSVImport1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenCSVImport1.Location = new System.Drawing.Point(522, 15);
            this.btnOpenCSVImport1.Margin = new System.Windows.Forms.Padding(4);
            this.btnOpenCSVImport1.Name = "btnOpenCSVImport1";
            this.btnOpenCSVImport1.Size = new System.Drawing.Size(93, 28);
            this.btnOpenCSVImport1.TabIndex = 19;
            this.btnOpenCSVImport1.Text = "CSV Import";
            this.btnOpenCSVImport1.UseVisualStyleBackColor = true;
            this.btnOpenCSVImport1.Click += new System.EventHandler(this.btnOpenCSVImport1_Click);
            // 
            // lblUrl1
            // 
            this.lblUrl1.AutoSize = true;
            this.lblUrl1.Location = new System.Drawing.Point(5, 28);
            this.lblUrl1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUrl1.Name = "lblUrl1";
            this.lblUrl1.Size = new System.Drawing.Size(26, 17);
            this.lblUrl1.TabIndex = 1;
            this.lblUrl1.Text = "Url";
            // 
            // lblRole1
            // 
            this.lblRole1.AutoSize = true;
            this.lblRole1.Location = new System.Drawing.Point(536, 49);
            this.lblRole1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRole1.Name = "lblRole1";
            this.lblRole1.Size = new System.Drawing.Size(37, 17);
            this.lblRole1.TabIndex = 9;
            this.lblRole1.Text = "Role";
            // 
            // txtUrl1
            // 
            this.txtUrl1.Location = new System.Drawing.Point(37, 24);
            this.txtUrl1.Margin = new System.Windows.Forms.Padding(4);
            this.txtUrl1.Name = "txtUrl1";
            this.txtUrl1.Size = new System.Drawing.Size(249, 22);
            this.txtUrl1.TabIndex = 2;
            // 
            // lblSignature1
            // 
            this.lblSignature1.AutoSize = true;
            this.lblSignature1.Location = new System.Drawing.Point(343, 49);
            this.lblSignature1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSignature1.Name = "lblSignature1";
            this.lblSignature1.Size = new System.Drawing.Size(69, 17);
            this.lblSignature1.TabIndex = 7;
            this.lblSignature1.Text = "Signature";
            // 
            // txtRole1
            // 
            this.txtRole1.Location = new System.Drawing.Point(539, 70);
            this.txtRole1.Margin = new System.Windows.Forms.Padding(4);
            this.txtRole1.Name = "txtRole1";
            this.txtRole1.Size = new System.Drawing.Size(75, 22);
            this.txtRole1.TabIndex = 10;
            this.txtRole1.TextChanged += new System.EventHandler(this.txtRole1_TextChanged);
            // 
            // lblEmail1
            // 
            this.lblEmail1.AutoSize = true;
            this.lblEmail1.Location = new System.Drawing.Point(150, 49);
            this.lblEmail1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEmail1.Name = "lblEmail1";
            this.lblEmail1.Size = new System.Drawing.Size(42, 17);
            this.lblEmail1.TabIndex = 5;
            this.lblEmail1.Text = "Email";
            // 
            // lblAccount1
            // 
            this.lblAccount1.AutoSize = true;
            this.lblAccount1.Location = new System.Drawing.Point(1, 49);
            this.lblAccount1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAccount1.Name = "lblAccount1";
            this.lblAccount1.Size = new System.Drawing.Size(59, 17);
            this.lblAccount1.TabIndex = 3;
            this.lblAccount1.Text = "Account";
            // 
            // txtAccount1
            // 
            this.txtAccount1.Location = new System.Drawing.Point(4, 70);
            this.txtAccount1.Margin = new System.Windows.Forms.Padding(4);
            this.txtAccount1.Name = "txtAccount1";
            this.txtAccount1.Size = new System.Drawing.Size(85, 22);
            this.txtAccount1.TabIndex = 4;
            this.txtAccount1.TextChanged += new System.EventHandler(this.txtAccount1_TextChanged);
            // 
            // txtEmail1
            // 
            this.txtEmail1.Location = new System.Drawing.Point(153, 70);
            this.txtEmail1.Margin = new System.Windows.Forms.Padding(4);
            this.txtEmail1.Name = "txtEmail1";
            this.txtEmail1.Size = new System.Drawing.Size(185, 22);
            this.txtEmail1.TabIndex = 6;
            this.txtEmail1.TextChanged += new System.EventHandler(this.txtEmail1_TextChanged);
            // 
            // txtSignature1
            // 
            this.txtSignature1.Location = new System.Drawing.Point(346, 70);
            this.txtSignature1.Margin = new System.Windows.Forms.Padding(4);
            this.txtSignature1.Name = "txtSignature1";
            this.txtSignature1.PasswordChar = '●';
            this.txtSignature1.Size = new System.Drawing.Size(185, 22);
            this.txtSignature1.TabIndex = 8;
            this.txtSignature1.TextChanged += new System.EventHandler(this.txtSignature1_TextChanged);
            // 
            // pnlEnvironment1TreeViews
            // 
            this.pnlEnvironment1TreeViews.Controls.Add(this.tbCtrlEnvironment1);
            this.pnlEnvironment1TreeViews.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlEnvironment1TreeViews.Location = new System.Drawing.Point(4, 158);
            this.pnlEnvironment1TreeViews.Margin = new System.Windows.Forms.Padding(4);
            this.pnlEnvironment1TreeViews.Name = "pnlEnvironment1TreeViews";
            this.pnlEnvironment1TreeViews.Size = new System.Drawing.Size(623, 196);
            this.pnlEnvironment1TreeViews.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnIgnoreSettings);
            this.panel3.Controls.Add(this.grpEnvironment2);
            this.panel3.Controls.Add(this.btnCompare);
            this.panel3.Controls.Add(this.btnSaveSettings);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(635, 4);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(623, 146);
            this.panel3.TabIndex = 2;
            // 
            // btnIgnoreSettings
            // 
            this.btnIgnoreSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIgnoreSettings.Location = new System.Drawing.Point(382, 116);
            this.btnIgnoreSettings.Margin = new System.Windows.Forms.Padding(4);
            this.btnIgnoreSettings.Name = "btnIgnoreSettings";
            this.btnIgnoreSettings.Size = new System.Drawing.Size(115, 28);
            this.btnIgnoreSettings.TabIndex = 17;
            this.btnIgnoreSettings.Text = "Ignore Settings";
            this.btnIgnoreSettings.UseVisualStyleBackColor = true;
            this.btnIgnoreSettings.Click += new System.EventHandler(this.btnIgnoreSettings_Click);
            // 
            // grpEnvironment2
            // 
            this.grpEnvironment2.Controls.Add(this.lblSuffix2);
            this.grpEnvironment2.Controls.Add(this.btnOpenCSVImport2);
            this.grpEnvironment2.Controls.Add(this.txtSuffix2);
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
            this.grpEnvironment2.Margin = new System.Windows.Forms.Padding(4);
            this.grpEnvironment2.Name = "grpEnvironment2";
            this.grpEnvironment2.Padding = new System.Windows.Forms.Padding(4);
            this.grpEnvironment2.Size = new System.Drawing.Size(623, 108);
            this.grpEnvironment2.TabIndex = 12;
            this.grpEnvironment2.TabStop = false;
            this.grpEnvironment2.Text = "Environment 2";
            // 
            // btnOpenCSVImport2
            // 
            this.btnOpenCSVImport2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenCSVImport2.Location = new System.Drawing.Point(526, 14);
            this.btnOpenCSVImport2.Margin = new System.Windows.Forms.Padding(4);
            this.btnOpenCSVImport2.Name = "btnOpenCSVImport2";
            this.btnOpenCSVImport2.Size = new System.Drawing.Size(93, 28);
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
            this.chkUseSameCredentials.Location = new System.Drawing.Point(292, 24);
            this.chkUseSameCredentials.Margin = new System.Windows.Forms.Padding(4);
            this.chkUseSameCredentials.Name = "chkUseSameCredentials";
            this.chkUseSameCredentials.Size = new System.Drawing.Size(170, 21);
            this.chkUseSameCredentials.TabIndex = 22;
            this.chkUseSameCredentials.Text = "Use Same Credentials";
            this.chkUseSameCredentials.UseVisualStyleBackColor = true;
            this.chkUseSameCredentials.CheckedChanged += new System.EventHandler(this.chkUseSameCredentials_CheckedChanged);
            // 
            // lblUrl2
            // 
            this.lblUrl2.AutoSize = true;
            this.lblUrl2.Location = new System.Drawing.Point(1, 26);
            this.lblUrl2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUrl2.Name = "lblUrl2";
            this.lblUrl2.Size = new System.Drawing.Size(26, 17);
            this.lblUrl2.TabIndex = 12;
            this.lblUrl2.Text = "Url";
            // 
            // lblRole2
            // 
            this.lblRole2.AutoSize = true;
            this.lblRole2.Location = new System.Drawing.Point(536, 49);
            this.lblRole2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRole2.Name = "lblRole2";
            this.lblRole2.Size = new System.Drawing.Size(37, 17);
            this.lblRole2.TabIndex = 20;
            this.lblRole2.Text = "Role";
            this.lblRole2.Click += new System.EventHandler(this.lblRole2_Click);
            // 
            // txtUrl2
            // 
            this.txtUrl2.Location = new System.Drawing.Point(35, 23);
            this.txtUrl2.Margin = new System.Windows.Forms.Padding(4);
            this.txtUrl2.Name = "txtUrl2";
            this.txtUrl2.Size = new System.Drawing.Size(249, 22);
            this.txtUrl2.TabIndex = 13;
            // 
            // lblSignature2
            // 
            this.lblSignature2.AutoSize = true;
            this.lblSignature2.Location = new System.Drawing.Point(345, 49);
            this.lblSignature2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSignature2.Name = "lblSignature2";
            this.lblSignature2.Size = new System.Drawing.Size(69, 17);
            this.lblSignature2.TabIndex = 18;
            this.lblSignature2.Text = "Signature";
            this.lblSignature2.Click += new System.EventHandler(this.lblSignature2_Click);
            // 
            // txtRole2
            // 
            this.txtRole2.Location = new System.Drawing.Point(539, 70);
            this.txtRole2.Margin = new System.Windows.Forms.Padding(4);
            this.txtRole2.Name = "txtRole2";
            this.txtRole2.Size = new System.Drawing.Size(75, 22);
            this.txtRole2.TabIndex = 21;
            this.txtRole2.TextChanged += new System.EventHandler(this.txtRole2_TextChanged);
            // 
            // lblEmail2
            // 
            this.lblEmail2.AutoSize = true;
            this.lblEmail2.Location = new System.Drawing.Point(150, 49);
            this.lblEmail2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEmail2.Name = "lblEmail2";
            this.lblEmail2.Size = new System.Drawing.Size(42, 17);
            this.lblEmail2.TabIndex = 16;
            this.lblEmail2.Text = "Email";
            this.lblEmail2.Click += new System.EventHandler(this.lblEmail2_Click);
            // 
            // lblAccount2
            // 
            this.lblAccount2.AutoSize = true;
            this.lblAccount2.Location = new System.Drawing.Point(1, 49);
            this.lblAccount2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAccount2.Name = "lblAccount2";
            this.lblAccount2.Size = new System.Drawing.Size(59, 17);
            this.lblAccount2.TabIndex = 14;
            this.lblAccount2.Text = "Account";
            // 
            // txtAccount2
            // 
            this.txtAccount2.Location = new System.Drawing.Point(4, 70);
            this.txtAccount2.Margin = new System.Windows.Forms.Padding(4);
            this.txtAccount2.Name = "txtAccount2";
            this.txtAccount2.Size = new System.Drawing.Size(85, 22);
            this.txtAccount2.TabIndex = 15;
            // 
            // txtEmail2
            // 
            this.txtEmail2.Location = new System.Drawing.Point(153, 70);
            this.txtEmail2.Margin = new System.Windows.Forms.Padding(4);
            this.txtEmail2.Name = "txtEmail2";
            this.txtEmail2.Size = new System.Drawing.Size(185, 22);
            this.txtEmail2.TabIndex = 17;
            this.txtEmail2.TextChanged += new System.EventHandler(this.txtEmail2_TextChanged);
            // 
            // txtSignature2
            // 
            this.txtSignature2.Location = new System.Drawing.Point(346, 70);
            this.txtSignature2.Margin = new System.Windows.Forms.Padding(4);
            this.txtSignature2.Name = "txtSignature2";
            this.txtSignature2.PasswordChar = '●';
            this.txtSignature2.Size = new System.Drawing.Size(185, 22);
            this.txtSignature2.TabIndex = 19;
            this.txtSignature2.TextChanged += new System.EventHandler(this.txtSignature2_TextChanged);
            // 
            // pnlEnvironment2TreeViews
            // 
            this.pnlEnvironment2TreeViews.Controls.Add(this.tbCtrlEnvironment2);
            this.pnlEnvironment2TreeViews.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlEnvironment2TreeViews.Location = new System.Drawing.Point(635, 158);
            this.pnlEnvironment2TreeViews.Margin = new System.Windows.Forms.Padding(4);
            this.pnlEnvironment2TreeViews.Name = "pnlEnvironment2TreeViews";
            this.pnlEnvironment2TreeViews.Size = new System.Drawing.Size(623, 196);
            this.pnlEnvironment2TreeViews.TabIndex = 3;
            // 
            // lblSuffix2
            // 
            this.lblSuffix2.AutoSize = true;
            this.lblSuffix2.Location = new System.Drawing.Point(94, 49);
            this.lblSuffix2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSuffix2.Name = "lblSuffix2";
            this.lblSuffix2.Size = new System.Drawing.Size(42, 17);
            this.lblSuffix2.TabIndex = 23;
            this.lblSuffix2.Text = "Suffix";
            // 
            // txtSuffix2
            // 
            this.txtSuffix2.Location = new System.Drawing.Point(97, 70);
            this.txtSuffix2.Margin = new System.Windows.Forms.Padding(4);
            this.txtSuffix2.Name = "txtSuffix2";
            this.txtSuffix2.Size = new System.Drawing.Size(48, 22);
            this.txtSuffix2.TabIndex = 24;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 358);
            this.Controls.Add(this.tblLayout);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(1194, 395);
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
		private System.Windows.Forms.CheckBox chkHideSignature;
		private System.Windows.Forms.CheckBox chkOnlyCustomFields;
        private System.Windows.Forms.Label lblSuffix1;
        private System.Windows.Forms.TextBox txtSuffix1;
        private System.Windows.Forms.Label lblSuffix2;
        private System.Windows.Forms.TextBox txtSuffix2;
    }
}

