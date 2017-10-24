namespace NetsuiteEnvironmentViewer
{
	partial class CSVImportTool
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
			this.ofdOpenFile = new System.Windows.Forms.OpenFileDialog();
			this.btnOpenFile = new System.Windows.Forms.Button();
			this.lblFileName = new System.Windows.Forms.Label();
			this.txtFileName = new System.Windows.Forms.TextBox();
			this.lblCSVImportId = new System.Windows.Forms.Label();
			this.txtCSVImportId = new System.Windows.Forms.TextBox();
			this.btnUpload = new System.Windows.Forms.Button();
			this.lblQueue = new System.Windows.Forms.Label();
			this.txtQueue = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// ofdOpenFile
			// 
			this.ofdOpenFile.FileName = "csvFile";
			this.ofdOpenFile.Filter = "CSV Files|*.csv";
			// 
			// btnOpenFile
			// 
			this.btnOpenFile.Location = new System.Drawing.Point(277, 12);
			this.btnOpenFile.Name = "btnOpenFile";
			this.btnOpenFile.Size = new System.Drawing.Size(75, 23);
			this.btnOpenFile.TabIndex = 0;
			this.btnOpenFile.Text = "Open File";
			this.btnOpenFile.UseVisualStyleBackColor = true;
			this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
			// 
			// lblFileName
			// 
			this.lblFileName.AutoSize = true;
			this.lblFileName.Location = new System.Drawing.Point(32, 17);
			this.lblFileName.Name = "lblFileName";
			this.lblFileName.Size = new System.Drawing.Size(54, 13);
			this.lblFileName.TabIndex = 1;
			this.lblFileName.Text = "File Name";
			// 
			// txtFileName
			// 
			this.txtFileName.Location = new System.Drawing.Point(92, 14);
			this.txtFileName.Name = "txtFileName";
			this.txtFileName.ReadOnly = true;
			this.txtFileName.Size = new System.Drawing.Size(179, 20);
			this.txtFileName.TabIndex = 2;
			// 
			// lblCSVImportId
			// 
			this.lblCSVImportId.AutoSize = true;
			this.lblCSVImportId.Location = new System.Drawing.Point(12, 48);
			this.lblCSVImportId.Name = "lblCSVImportId";
			this.lblCSVImportId.Size = new System.Drawing.Size(74, 13);
			this.lblCSVImportId.TabIndex = 3;
			this.lblCSVImportId.Text = "CSV Import ID";
			// 
			// txtCSVImportId
			// 
			this.txtCSVImportId.Location = new System.Drawing.Point(92, 41);
			this.txtCSVImportId.Name = "txtCSVImportId";
			this.txtCSVImportId.Size = new System.Drawing.Size(260, 20);
			this.txtCSVImportId.TabIndex = 4;
			// 
			// btnUpload
			// 
			this.btnUpload.Location = new System.Drawing.Point(277, 67);
			this.btnUpload.Name = "btnUpload";
			this.btnUpload.Size = new System.Drawing.Size(75, 23);
			this.btnUpload.TabIndex = 5;
			this.btnUpload.Text = "Upload";
			this.btnUpload.UseVisualStyleBackColor = true;
			this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
			// 
			// lblQueue
			// 
			this.lblQueue.AutoSize = true;
			this.lblQueue.Location = new System.Drawing.Point(47, 70);
			this.lblQueue.Name = "lblQueue";
			this.lblQueue.Size = new System.Drawing.Size(39, 13);
			this.lblQueue.TabIndex = 6;
			this.lblQueue.Text = "Queue";
			// 
			// txtQueue
			// 
			this.txtQueue.Location = new System.Drawing.Point(92, 67);
			this.txtQueue.Name = "txtQueue";
			this.txtQueue.Size = new System.Drawing.Size(77, 20);
			this.txtQueue.TabIndex = 7;
			// 
			// CSVImportTool
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(364, 96);
			this.Controls.Add(this.txtQueue);
			this.Controls.Add(this.lblQueue);
			this.Controls.Add(this.btnUpload);
			this.Controls.Add(this.txtCSVImportId);
			this.Controls.Add(this.lblCSVImportId);
			this.Controls.Add(this.txtFileName);
			this.Controls.Add(this.lblFileName);
			this.Controls.Add(this.btnOpenFile);
			this.MaximumSize = new System.Drawing.Size(380, 135);
			this.MinimumSize = new System.Drawing.Size(380, 135);
			this.Name = "CSVImportTool";
			this.Text = "CSV Import Tool";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.OpenFileDialog ofdOpenFile;
		private System.Windows.Forms.Button btnOpenFile;
		private System.Windows.Forms.Label lblFileName;
		private System.Windows.Forms.TextBox txtFileName;
		private System.Windows.Forms.Label lblCSVImportId;
		private System.Windows.Forms.TextBox txtCSVImportId;
		private System.Windows.Forms.Button btnUpload;
		private System.Windows.Forms.Label lblQueue;
		private System.Windows.Forms.TextBox txtQueue;
	}
}