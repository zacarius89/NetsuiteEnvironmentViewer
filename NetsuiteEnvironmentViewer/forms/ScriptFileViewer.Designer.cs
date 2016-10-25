namespace NetsuiteEnvironmentViewer
{
    partial class ScriptFileViewer
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
            this.grpEnvironment1 = new System.Windows.Forms.GroupBox();
            this.btnCompareToEnvironment2 = new System.Windows.Forms.Button();
            this.rTxtContent1 = new NetsuiteEnvironmentViewer.MyRichTextBox();
            this.btnPushToEnvironment2 = new System.Windows.Forms.Button();
            this.txtSize1 = new System.Windows.Forms.TextBox();
            this.txtType1 = new System.Windows.Forms.TextBox();
            this.txtName1 = new System.Windows.Forms.TextBox();
            this.txtInternalId1 = new System.Windows.Forms.TextBox();
            this.lblContent1 = new System.Windows.Forms.Label();
            this.lblSize1 = new System.Windows.Forms.Label();
            this.lvlType1 = new System.Windows.Forms.Label();
            this.lblName1 = new System.Windows.Forms.Label();
            this.lblInternalId1 = new System.Windows.Forms.Label();
            this.grpEnvironment2 = new System.Windows.Forms.GroupBox();
            this.rTxtContent2 = new NetsuiteEnvironmentViewer.MyRichTextBox();
            this.txtSize2 = new System.Windows.Forms.TextBox();
            this.txtType2 = new System.Windows.Forms.TextBox();
            this.txtName2 = new System.Windows.Forms.TextBox();
            this.txtInternalId2 = new System.Windows.Forms.TextBox();
            this.lblContent2 = new System.Windows.Forms.Label();
            this.lblSize2 = new System.Windows.Forms.Label();
            this.lblType2 = new System.Windows.Forms.Label();
            this.lblName2 = new System.Windows.Forms.Label();
            this.lblInternalId2 = new System.Windows.Forms.Label();
            this.btnCompareToEnvironment1 = new System.Windows.Forms.Button();
            this.grpEnvironment1.SuspendLayout();
            this.grpEnvironment2.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpEnvironment1
            // 
            this.grpEnvironment1.Controls.Add(this.btnCompareToEnvironment2);
            this.grpEnvironment1.Controls.Add(this.rTxtContent1);
            this.grpEnvironment1.Controls.Add(this.btnPushToEnvironment2);
            this.grpEnvironment1.Controls.Add(this.txtSize1);
            this.grpEnvironment1.Controls.Add(this.txtType1);
            this.grpEnvironment1.Controls.Add(this.txtName1);
            this.grpEnvironment1.Controls.Add(this.txtInternalId1);
            this.grpEnvironment1.Controls.Add(this.lblContent1);
            this.grpEnvironment1.Controls.Add(this.lblSize1);
            this.grpEnvironment1.Controls.Add(this.lvlType1);
            this.grpEnvironment1.Controls.Add(this.lblName1);
            this.grpEnvironment1.Controls.Add(this.lblInternalId1);
            this.grpEnvironment1.Location = new System.Drawing.Point(12, 12);
            this.grpEnvironment1.Name = "grpEnvironment1";
            this.grpEnvironment1.Size = new System.Drawing.Size(543, 466);
            this.grpEnvironment1.TabIndex = 0;
            this.grpEnvironment1.TabStop = false;
            this.grpEnvironment1.Text = "Environment 1";
            // 
            // btnCompareToEnvironment2
            // 
            this.btnCompareToEnvironment2.Location = new System.Drawing.Point(393, 70);
            this.btnCompareToEnvironment2.Name = "btnCompareToEnvironment2";
            this.btnCompareToEnvironment2.Size = new System.Drawing.Size(144, 23);
            this.btnCompareToEnvironment2.TabIndex = 10;
            this.btnCompareToEnvironment2.Text = "Compare To Environment 2";
            this.btnCompareToEnvironment2.UseVisualStyleBackColor = true;
            this.btnCompareToEnvironment2.Click += new System.EventHandler(this.btnCompareToEnvironment2_Click);
            // 
            // rTxtContent1
            // 
            this.rTxtContent1.Location = new System.Drawing.Point(9, 145);
            this.rTxtContent1.Name = "rTxtContent1";
            this.rTxtContent1.ReadOnly = true;
            this.rTxtContent1.Size = new System.Drawing.Size(528, 315);
            this.rTxtContent1.TabIndex = 9;
            this.rTxtContent1.Text = "";
            this.rTxtContent1.WordWrap = false;
            // 
            // btnPushToEnvironment2
            // 
            this.btnPushToEnvironment2.Location = new System.Drawing.Point(393, 98);
            this.btnPushToEnvironment2.Name = "btnPushToEnvironment2";
            this.btnPushToEnvironment2.Size = new System.Drawing.Size(144, 23);
            this.btnPushToEnvironment2.TabIndex = 2;
            this.btnPushToEnvironment2.Text = "Push To Environment 2";
            this.btnPushToEnvironment2.UseVisualStyleBackColor = true;
            this.btnPushToEnvironment2.Click += new System.EventHandler(this.btnPushToEnvironment2_Click);
            // 
            // txtSize1
            // 
            this.txtSize1.Location = new System.Drawing.Point(62, 100);
            this.txtSize1.Name = "txtSize1";
            this.txtSize1.ReadOnly = true;
            this.txtSize1.Size = new System.Drawing.Size(224, 20);
            this.txtSize1.TabIndex = 8;
            // 
            // txtType1
            // 
            this.txtType1.Location = new System.Drawing.Point(62, 73);
            this.txtType1.Name = "txtType1";
            this.txtType1.ReadOnly = true;
            this.txtType1.Size = new System.Drawing.Size(224, 20);
            this.txtType1.TabIndex = 7;
            // 
            // txtName1
            // 
            this.txtName1.Location = new System.Drawing.Point(62, 45);
            this.txtName1.Name = "txtName1";
            this.txtName1.ReadOnly = true;
            this.txtName1.Size = new System.Drawing.Size(224, 20);
            this.txtName1.TabIndex = 6;
            // 
            // txtInternalId1
            // 
            this.txtInternalId1.Location = new System.Drawing.Point(62, 19);
            this.txtInternalId1.Name = "txtInternalId1";
            this.txtInternalId1.ReadOnly = true;
            this.txtInternalId1.Size = new System.Drawing.Size(224, 20);
            this.txtInternalId1.TabIndex = 5;
            // 
            // lblContent1
            // 
            this.lblContent1.AutoSize = true;
            this.lblContent1.Location = new System.Drawing.Point(6, 129);
            this.lblContent1.Name = "lblContent1";
            this.lblContent1.Size = new System.Drawing.Size(43, 13);
            this.lblContent1.TabIndex = 4;
            this.lblContent1.Text = "content";
            // 
            // lblSize1
            // 
            this.lblSize1.AutoSize = true;
            this.lblSize1.Location = new System.Drawing.Point(6, 103);
            this.lblSize1.Name = "lblSize1";
            this.lblSize1.Size = new System.Drawing.Size(25, 13);
            this.lblSize1.TabIndex = 3;
            this.lblSize1.Text = "size";
            // 
            // lvlType1
            // 
            this.lvlType1.AutoSize = true;
            this.lvlType1.Location = new System.Drawing.Point(6, 76);
            this.lvlType1.Name = "lvlType1";
            this.lvlType1.Size = new System.Drawing.Size(27, 13);
            this.lvlType1.TabIndex = 2;
            this.lvlType1.Text = "type";
            // 
            // lblName1
            // 
            this.lblName1.AutoSize = true;
            this.lblName1.Location = new System.Drawing.Point(6, 49);
            this.lblName1.Name = "lblName1";
            this.lblName1.Size = new System.Drawing.Size(33, 13);
            this.lblName1.TabIndex = 1;
            this.lblName1.Text = "name";
            // 
            // lblInternalId1
            // 
            this.lblInternalId1.AutoSize = true;
            this.lblInternalId1.Location = new System.Drawing.Point(6, 22);
            this.lblInternalId1.Name = "lblInternalId1";
            this.lblInternalId1.Size = new System.Drawing.Size(50, 13);
            this.lblInternalId1.TabIndex = 0;
            this.lblInternalId1.Text = "internalId";
            // 
            // grpEnvironment2
            // 
            this.grpEnvironment2.Controls.Add(this.btnCompareToEnvironment1);
            this.grpEnvironment2.Controls.Add(this.rTxtContent2);
            this.grpEnvironment2.Controls.Add(this.txtSize2);
            this.grpEnvironment2.Controls.Add(this.txtType2);
            this.grpEnvironment2.Controls.Add(this.txtName2);
            this.grpEnvironment2.Controls.Add(this.txtInternalId2);
            this.grpEnvironment2.Controls.Add(this.lblContent2);
            this.grpEnvironment2.Controls.Add(this.lblSize2);
            this.grpEnvironment2.Controls.Add(this.lblType2);
            this.grpEnvironment2.Controls.Add(this.lblName2);
            this.grpEnvironment2.Controls.Add(this.lblInternalId2);
            this.grpEnvironment2.Location = new System.Drawing.Point(583, 12);
            this.grpEnvironment2.Name = "grpEnvironment2";
            this.grpEnvironment2.Size = new System.Drawing.Size(543, 466);
            this.grpEnvironment2.TabIndex = 1;
            this.grpEnvironment2.TabStop = false;
            this.grpEnvironment2.Text = "Environment 2";
            // 
            // rTxtContent2
            // 
            this.rTxtContent2.Location = new System.Drawing.Point(9, 145);
            this.rTxtContent2.Name = "rTxtContent2";
            this.rTxtContent2.ReadOnly = true;
            this.rTxtContent2.Size = new System.Drawing.Size(528, 315);
            this.rTxtContent2.TabIndex = 10;
            this.rTxtContent2.Text = "";
            this.rTxtContent2.WordWrap = false;
            // 
            // txtSize2
            // 
            this.txtSize2.Location = new System.Drawing.Point(62, 100);
            this.txtSize2.Name = "txtSize2";
            this.txtSize2.ReadOnly = true;
            this.txtSize2.Size = new System.Drawing.Size(224, 20);
            this.txtSize2.TabIndex = 8;
            // 
            // txtType2
            // 
            this.txtType2.Location = new System.Drawing.Point(62, 73);
            this.txtType2.Name = "txtType2";
            this.txtType2.ReadOnly = true;
            this.txtType2.Size = new System.Drawing.Size(224, 20);
            this.txtType2.TabIndex = 7;
            // 
            // txtName2
            // 
            this.txtName2.Location = new System.Drawing.Point(62, 45);
            this.txtName2.Name = "txtName2";
            this.txtName2.ReadOnly = true;
            this.txtName2.Size = new System.Drawing.Size(224, 20);
            this.txtName2.TabIndex = 6;
            // 
            // txtInternalId2
            // 
            this.txtInternalId2.Location = new System.Drawing.Point(62, 19);
            this.txtInternalId2.Name = "txtInternalId2";
            this.txtInternalId2.ReadOnly = true;
            this.txtInternalId2.Size = new System.Drawing.Size(224, 20);
            this.txtInternalId2.TabIndex = 5;
            // 
            // lblContent2
            // 
            this.lblContent2.AutoSize = true;
            this.lblContent2.Location = new System.Drawing.Point(6, 129);
            this.lblContent2.Name = "lblContent2";
            this.lblContent2.Size = new System.Drawing.Size(43, 13);
            this.lblContent2.TabIndex = 4;
            this.lblContent2.Text = "content";
            // 
            // lblSize2
            // 
            this.lblSize2.AutoSize = true;
            this.lblSize2.Location = new System.Drawing.Point(6, 103);
            this.lblSize2.Name = "lblSize2";
            this.lblSize2.Size = new System.Drawing.Size(25, 13);
            this.lblSize2.TabIndex = 3;
            this.lblSize2.Text = "size";
            // 
            // lblType2
            // 
            this.lblType2.AutoSize = true;
            this.lblType2.Location = new System.Drawing.Point(6, 76);
            this.lblType2.Name = "lblType2";
            this.lblType2.Size = new System.Drawing.Size(27, 13);
            this.lblType2.TabIndex = 2;
            this.lblType2.Text = "type";
            // 
            // lblName2
            // 
            this.lblName2.AutoSize = true;
            this.lblName2.Location = new System.Drawing.Point(6, 49);
            this.lblName2.Name = "lblName2";
            this.lblName2.Size = new System.Drawing.Size(33, 13);
            this.lblName2.TabIndex = 1;
            this.lblName2.Text = "name";
            // 
            // lblInternalId2
            // 
            this.lblInternalId2.AutoSize = true;
            this.lblInternalId2.Location = new System.Drawing.Point(6, 22);
            this.lblInternalId2.Name = "lblInternalId2";
            this.lblInternalId2.Size = new System.Drawing.Size(50, 13);
            this.lblInternalId2.TabIndex = 0;
            this.lblInternalId2.Text = "internalId";
            // 
            // btnCompareToEnvironment1
            // 
            this.btnCompareToEnvironment1.Location = new System.Drawing.Point(393, 71);
            this.btnCompareToEnvironment1.Name = "btnCompareToEnvironment1";
            this.btnCompareToEnvironment1.Size = new System.Drawing.Size(144, 23);
            this.btnCompareToEnvironment1.TabIndex = 11;
            this.btnCompareToEnvironment1.Text = "Compare To Environment 1";
            this.btnCompareToEnvironment1.UseVisualStyleBackColor = true;
            this.btnCompareToEnvironment1.Click += new System.EventHandler(this.btnCompareToEnvironment1_Click);
            // 
            // ScriptFileViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1138, 490);
            this.Controls.Add(this.grpEnvironment2);
            this.Controls.Add(this.grpEnvironment1);
            this.Name = "ScriptFileViewer";
            this.Text = "Script File Viewer";
            this.Load += new System.EventHandler(this.ScriptFileViewer_Load);
            this.grpEnvironment1.ResumeLayout(false);
            this.grpEnvironment1.PerformLayout();
            this.grpEnvironment2.ResumeLayout(false);
            this.grpEnvironment2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpEnvironment1;
        private System.Windows.Forms.Label lblName1;
        private System.Windows.Forms.Label lblInternalId1;
        private System.Windows.Forms.TextBox txtSize1;
        private System.Windows.Forms.TextBox txtType1;
        private System.Windows.Forms.TextBox txtName1;
        private System.Windows.Forms.TextBox txtInternalId1;
        private System.Windows.Forms.Label lblContent1;
        private System.Windows.Forms.Label lblSize1;
        private System.Windows.Forms.Label lvlType1;
        private System.Windows.Forms.GroupBox grpEnvironment2;
        private System.Windows.Forms.TextBox txtSize2;
        private System.Windows.Forms.TextBox txtType2;
        private System.Windows.Forms.TextBox txtName2;
        private System.Windows.Forms.TextBox txtInternalId2;
        private System.Windows.Forms.Label lblContent2;
        private System.Windows.Forms.Label lblSize2;
        private System.Windows.Forms.Label lblType2;
        private System.Windows.Forms.Label lblName2;
        private System.Windows.Forms.Label lblInternalId2;
        private System.Windows.Forms.Button btnPushToEnvironment2;
        private MyRichTextBox rTxtContent1;
        private MyRichTextBox rTxtContent2;
        private System.Windows.Forms.Button btnCompareToEnvironment2;
        private System.Windows.Forms.Button btnCompareToEnvironment1;
    }
}