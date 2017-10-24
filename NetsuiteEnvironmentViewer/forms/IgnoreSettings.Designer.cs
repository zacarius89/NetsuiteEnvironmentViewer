namespace NetsuiteEnvironmentViewer
{
	partial class IgnoreSettings
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
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.lblEnvironment1Scripts = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.btnSaveSettings = new System.Windows.Forms.Button();
			this.lblEnvironment2Scripts = new System.Windows.Forms.Label();
			this.panel3 = new System.Windows.Forms.Panel();
			this.dgvEnvironment1IgnoreScripts = new System.Windows.Forms.DataGridView();
			this.panel4 = new System.Windows.Forms.Panel();
			this.dgvEnvironment2IgnoreScripts = new System.Windows.Forms.DataGridView();
			this.Env2InternalId = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Env1InternalId = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Env1ScriptFileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Env2ScriptFileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.tableLayoutPanel1.SuspendLayout();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvEnvironment1IgnoreScripts)).BeginInit();
			this.panel4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvEnvironment2IgnoreScripts)).BeginInit();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.panel4, 1, 1);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(469, 261);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.lblEnvironment1Scripts);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(3, 3);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(228, 29);
			this.panel1.TabIndex = 0;
			// 
			// lblEnvironment1Scripts
			// 
			this.lblEnvironment1Scripts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lblEnvironment1Scripts.AutoSize = true;
			this.lblEnvironment1Scripts.Location = new System.Drawing.Point(4, 10);
			this.lblEnvironment1Scripts.Name = "lblEnvironment1Scripts";
			this.lblEnvironment1Scripts.Size = new System.Drawing.Size(110, 13);
			this.lblEnvironment1Scripts.TabIndex = 0;
			this.lblEnvironment1Scripts.Text = "Environment 1 Scripts";
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.btnSaveSettings);
			this.panel2.Controls.Add(this.lblEnvironment2Scripts);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(237, 3);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(229, 29);
			this.panel2.TabIndex = 1;
			// 
			// btnSaveSettings
			// 
			this.btnSaveSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSaveSettings.Location = new System.Drawing.Point(139, 3);
			this.btnSaveSettings.Name = "btnSaveSettings";
			this.btnSaveSettings.Size = new System.Drawing.Size(81, 23);
			this.btnSaveSettings.TabIndex = 1;
			this.btnSaveSettings.Text = "Save Settings";
			this.btnSaveSettings.UseVisualStyleBackColor = true;
			this.btnSaveSettings.Click += new System.EventHandler(this.btnSaveSettings_Click);
			// 
			// lblEnvironment2Scripts
			// 
			this.lblEnvironment2Scripts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lblEnvironment2Scripts.AutoSize = true;
			this.lblEnvironment2Scripts.Location = new System.Drawing.Point(3, 10);
			this.lblEnvironment2Scripts.Name = "lblEnvironment2Scripts";
			this.lblEnvironment2Scripts.Size = new System.Drawing.Size(110, 13);
			this.lblEnvironment2Scripts.TabIndex = 0;
			this.lblEnvironment2Scripts.Text = "Environment 2 Scripts";
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.dgvEnvironment1IgnoreScripts);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel3.Location = new System.Drawing.Point(3, 38);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(228, 220);
			this.panel3.TabIndex = 2;
			// 
			// dgvEnvironment1IgnoreScripts
			// 
			this.dgvEnvironment1IgnoreScripts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvEnvironment1IgnoreScripts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
			this.Env1InternalId,
			this.Env1ScriptFileName});
			this.dgvEnvironment1IgnoreScripts.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvEnvironment1IgnoreScripts.Location = new System.Drawing.Point(0, 0);
			this.dgvEnvironment1IgnoreScripts.Name = "dgvEnvironment1IgnoreScripts";
			this.dgvEnvironment1IgnoreScripts.Size = new System.Drawing.Size(228, 220);
			this.dgvEnvironment1IgnoreScripts.TabIndex = 0;
			// 
			// panel4
			// 
			this.panel4.Controls.Add(this.dgvEnvironment2IgnoreScripts);
			this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel4.Location = new System.Drawing.Point(237, 38);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(229, 220);
			this.panel4.TabIndex = 3;
			// 
			// dgvEnvironment2IgnoreScripts
			// 
			this.dgvEnvironment2IgnoreScripts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvEnvironment2IgnoreScripts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
			this.Env2InternalId,
			this.Env2ScriptFileName});
			this.dgvEnvironment2IgnoreScripts.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvEnvironment2IgnoreScripts.Location = new System.Drawing.Point(0, 0);
			this.dgvEnvironment2IgnoreScripts.Name = "dgvEnvironment2IgnoreScripts";
			this.dgvEnvironment2IgnoreScripts.Size = new System.Drawing.Size(229, 220);
			this.dgvEnvironment2IgnoreScripts.TabIndex = 0;
			// 
			// Env2InternalId
			// 
			this.Env2InternalId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.Env2InternalId.HeaderText = "InternalId";
			this.Env2InternalId.Name = "Env2InternalId";
			// 
			// Env1InternalId
			// 
			this.Env1InternalId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.Env1InternalId.HeaderText = "InternalId";
			this.Env1InternalId.Name = "Env1InternalId";
			// 
			// Env1ScriptFileName
			// 
			this.Env1ScriptFileName.HeaderText = "ScriptFileName";
			this.Env1ScriptFileName.Name = "Env1ScriptFileName";
			// 
			// Env2ScriptFileName
			// 
			this.Env2ScriptFileName.HeaderText = "ScriptFileName";
			this.Env2ScriptFileName.Name = "Env2ScriptFileName";
			// 
			// IgnoreSettings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(469, 261);
			this.Controls.Add(this.tableLayoutPanel1);
			this.MinimumSize = new System.Drawing.Size(485, 300);
			this.Name = "IgnoreSettings";
			this.Text = "Ignore Settings";
			this.Load += new System.EventHandler(this.IgnoreSettings_Load);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.panel3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvEnvironment1IgnoreScripts)).EndInit();
			this.panel4.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvEnvironment2IgnoreScripts)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label lblEnvironment1Scripts;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label lblEnvironment2Scripts;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.DataGridView dgvEnvironment1IgnoreScripts;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.DataGridView dgvEnvironment2IgnoreScripts;
		private System.Windows.Forms.DataGridViewTextBoxColumn Env2InternalId;
		private System.Windows.Forms.Button btnSaveSettings;
		private System.Windows.Forms.DataGridViewTextBoxColumn Env1InternalId;
		private System.Windows.Forms.DataGridViewTextBoxColumn Env1ScriptFileName;
		private System.Windows.Forms.DataGridViewTextBoxColumn Env2ScriptFileName;
	}
}