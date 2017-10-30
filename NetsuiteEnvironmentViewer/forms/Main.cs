using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using DiffPlex;
using DiffPlex.DiffBuilder;
using DiffPlex.DiffBuilder.Model;
using System.Linq;

namespace NetsuiteEnvironmentViewer
{
	public partial class Main : Form
	{
		public static string confirmationTitle = "";
		private static string errorTitle = "Error";
		public static string saveSettingsConfirmationText = "Are you sure you want to save the settings?  This will overwrite the existing settings.";
		private string haveNotComparedText = "Have you compared the environments yet?  Please compare before opening the File Viewer.";
		private string missingScriptFileText = "Cannot compare scriptFile(s).  The scriptFile does not exist in one of the environments.";
		private string cannotCompareText = "Cannot compare until Netsuite Environment Data has been pulled.  Do you want to do this now?";
		private string compareAgainText = "Cannot compare until Netsuite Environment Data has been pulled again.  Do you want to do this now?";

		private bool dataPulled = false;
		private bool compared = false;

		public static SettingsClient settingsClient = new SettingsClient();
		public static Settings settings = new Settings();

		public Main()
		{
			InitializeComponent();
		}

		#region "Events"

		#region "Load"
		private void Main_Load(object sender, EventArgs e)
		{
			settings = settingsClient.loadSettings();

			chkUseSameCredentials.Checked = settings.useSameCredentialsChecked;
			chkRecords.Checked = settings.recordsChecked;
			chkScripts.Checked = settings.scriptsChecked;

			txtUrl1.Text = settings.environment1Url;
			txtAccount1.Text = settings.environment1Account;
			txtEmail1.Text = settings.environment1Email;
			txtSignature1.Text = settings.environment1Signature;
			txtRole1.Text = settings.environment1Role;

			txtUrl2.Text = settings.environment2Url;
			txtAccount2.Text = settings.environment2Account;
			txtEmail2.Text = settings.environment2Email;
			txtSignature2.Text = settings.environment2Signature;
			txtRole2.Text = settings.environment2Role;

			syncCredentials();
			enableEnvironment2Credentials();
		}
		#endregion

		#region "TextChanged"
		private void txtAccount1_TextChanged(object sender, EventArgs e)
		{
			syncCredentials();
		}

		private void txtEmail1_TextChanged(object sender, EventArgs e)
		{
			syncCredentials();
		}

		private void txtSignature1_TextChanged(object sender, EventArgs e)
		{
			syncCredentials();
		}

		private void txtRole1_TextChanged(object sender, EventArgs e)
		{
			syncCredentials();
		}
		#endregion

		#region "CheckChanged"
		private void chkHideSignature_CheckedChanged(object sender, EventArgs e)
		{
			toggleSignatureDisplay();
		}

		private void chkUseSameCredentials_CheckedChanged(object sender, EventArgs e)
		{
			syncCredentials();
			enableEnvironment2Credentials();
		}
		#endregion

		#region "Click"
		private void btnPullNetsuiteEnvironmentData_Click(object sender, EventArgs e)
		{
			try
			{
				Application.UseWaitCursor = true;
				this.Cursor = Cursors.WaitCursor;
				Application.DoEvents();

				pullNetsuiteEnvironmentData();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, errorTitle);
			}
			finally
			{
				Application.UseWaitCursor = false;
				this.Cursor = Cursors.Default;
			}
		}

		private void btnIgnoreSettings_Click(object sender, EventArgs e)
		{
			IgnoreSettings ignoreSettings = new IgnoreSettings();
			ignoreSettings.Show();
		}

		private void btnSaveSettings_Click(object sender, EventArgs e)
		{
			DialogResult dialogResult = MessageBox.Show(saveSettingsConfirmationText, confirmationTitle, MessageBoxButtons.YesNo);

			if (dialogResult == DialogResult.Yes)
			{
				settings.useSameCredentialsChecked = chkUseSameCredentials.Checked;
				settings.recordsChecked = chkRecords.Checked;
				settings.scriptsChecked = chkScripts.Checked;

				settings.environment1Url = txtUrl1.Text;
				settings.environment1Account = txtAccount1.Text;
				settings.environment1Email = txtEmail1.Text;
				settings.environment1Signature = txtSignature1.Text;
				settings.environment1Role = txtRole1.Text;

				settings.environment2Url = txtUrl2.Text;
				settings.environment2Account = txtAccount2.Text;
				settings.environment2Email = txtEmail2.Text;
				settings.environment2Signature = txtSignature2.Text;
				settings.environment2Role = txtRole2.Text;

				settingsClient.saveSettings(settings);
			}
		}

		private void btnCompare_Click(object sender, EventArgs e)
		{
			try
			{
				Application.UseWaitCursor = true;
				this.Cursor = Cursors.WaitCursor;
				Application.DoEvents();

				compareNetsuiteEnvironmentData();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, errorTitle);
			}
			finally
			{
				Application.UseWaitCursor = false;
				this.Cursor = Cursors.Default;
			}
		}

		private void btnOpenCSVImport1_Click(object sender, EventArgs e)
		{
			CSVImportTool csvImportTool = new CSVImportTool();
			csvImportTool.netsuiteClient = new netsuiteClient(txtUrl1.Text, txtAccount1.Text, txtEmail1.Text, txtSignature1.Text, txtRole1.Text);
			csvImportTool.Show();
		}

		private void btnOpenCSVImport2_Click(object sender, EventArgs e)
		{
			CSVImportTool csvImportTool = new CSVImportTool();
			csvImportTool.netsuiteClient = new netsuiteClient(txtUrl2.Text, txtAccount2.Text, txtEmail2.Text, txtSignature2.Text, txtRole2.Text);
			csvImportTool.Show();
		}

		#endregion

		#region "SelectedIndexChanged"
		private void tbCtrlEnvironment1_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (tbCtrlEnvironment1.SelectedIndex != tbCtrlEnvironment2.SelectedIndex)
			{
				tbCtrlEnvironment2.SelectedIndex = tbCtrlEnvironment1.SelectedIndex;
			}
		}

		private void tbCtrlEnvironment2_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (tbCtrlEnvironment2.SelectedIndex != tbCtrlEnvironment1.SelectedIndex)
			{
				tbCtrlEnvironment1.SelectedIndex = tbCtrlEnvironment2.SelectedIndex;
			}
		}
		#endregion

		#region "AfterCollapse"
		private void tvEnvironment1Records_AfterCollapse(object sender, TreeViewEventArgs e)
		{
			try
			{
				commonClient commonClient = new commonClient();
				commonClient.getNodeFromPath(tvEnvironment2Records.Nodes[0], e.Node.FullPath).Collapse();
			}
			catch (Exception ex)
			{

			}
		}

		private void tvEnvironment2Records_AfterCollapse(object sender, TreeViewEventArgs e)
		{
			try
			{
				commonClient commonClient = new commonClient();
				commonClient.getNodeFromPath(tvEnvironment1Records.Nodes[0], e.Node.FullPath).Collapse();
			}
			catch (Exception ex)
			{

			}
		}

		private void tvEnvironment1Scripts_AfterCollapse(object sender, TreeViewEventArgs e)
		{
			try
			{
				commonClient commonClient = new commonClient();
				commonClient.getNodeFromPath(tvEnvironment2Scripts.Nodes[e.Node.Index], e.Node.FullPath).Collapse();
			}
			catch (Exception ex)
			{

			}
		}

		private void tvEnvironment2Scripts_AfterCollapse(object sender, TreeViewEventArgs e)
		{
			try
			{
				commonClient commonClient = new commonClient();
				commonClient.getNodeFromPath(tvEnvironment1Scripts.Nodes[0], e.Node.FullPath).Collapse();
			}
			catch (Exception ex)
			{

			}
		}
		#endregion

		#region "BeforeExpand"
		private void tvEnvironment1Scripts_BeforeExpand(object sender, TreeViewCancelEventArgs e)
		{
			try
			{
				if ((e.Node.Level == 3 || e.Node.Level == 4) && e.Node.Text == "content")
				{
					e.Cancel = true;
				}
			}
			catch (Exception ex)
			{

			}
		}

		private void tvEnvironment2Scripts_BeforeExpand(object sender, TreeViewCancelEventArgs e)
		{
			try
			{
				if ((e.Node.Level == 3 || e.Node.Level == 4) && e.Node.Text == "content")
				{
					e.Cancel = true;
				}
			}
			catch (Exception ex)
			{

			}
		}

		#endregion

		#region "AfterExpand"
		private void tvEnvironment1Records_AfterExpand(object sender, TreeViewEventArgs e)
		{
			try
			{
				commonClient commonClient = new commonClient();
				commonClient.getNodeFromPath(tvEnvironment2Records.Nodes[0], e.Node.FullPath).Expand();
			}
			catch (Exception ex)
			{

			}
		}

		private void tvEnvironment2Records_AfterExpand(object sender, TreeViewEventArgs e)
		{
			try
			{
				commonClient commonClient = new commonClient();
				commonClient.getNodeFromPath(tvEnvironment1Records.Nodes[0], e.Node.FullPath).Expand();
			}
			catch (Exception ex)
			{

			}
		}

		private void tvEnvironment1Scripts_AfterExpand(object sender, TreeViewEventArgs e)
		{
			try
			{
				commonClient commonClient = new commonClient();
				commonClient.getNodeFromPath(tvEnvironment2Scripts.Nodes[0], e.Node.FullPath).Expand();
			}
			catch (Exception ex)
			{

			}
		}

		private void tvEnvironment2Scripts_AfterExpand(object sender, TreeViewEventArgs e)
		{
			try
			{
				commonClient commonClient = new commonClient();
				commonClient.getNodeFromPath(tvEnvironment1Scripts.Nodes[0], e.Node.FullPath).Expand();
			}
			catch (Exception ex)
			{

			}
		}
		#endregion

		#region "NodeMouseDoubleClick"
		private void tvEnvironment1Scripts_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
		{
			loadCustomScript(e.Node);
		}

		private void tvEnvironment2Scripts_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
		{
			loadCustomScript(e.Node);
		}

		#endregion

		#endregion

		#region "Credentials"
		private void toggleSignatureDisplay()
		{
			if (chkHideSignature.Checked)
			{
				txtSignature1.PasswordChar = '●';
				txtSignature2.PasswordChar = '●';
			}
			else
			{
				txtSignature1.PasswordChar = new char();
				txtSignature2.PasswordChar = new char();
			}
		}

		private void syncCredentials()
		{
			if (chkUseSameCredentials.Checked)
			{
				txtAccount2.Text = txtAccount1.Text;
				txtEmail2.Text = txtEmail1.Text;
				txtSignature2.Text = txtSignature1.Text;
				txtRole2.Text = txtRole1.Text;
			}
		}

		private void enableEnvironment2Credentials()
		{
			if (chkUseSameCredentials.Checked)
			{
				//Disable
				txtAccount2.ReadOnly = true;
				txtEmail2.ReadOnly = true;
				txtSignature2.ReadOnly = true;
				txtRole2.ReadOnly = true;
			}
			else
			{
				//Enable
				txtAccount2.ReadOnly = false;
				txtEmail2.ReadOnly = false;
				txtSignature2.ReadOnly = false;
				txtRole2.ReadOnly = false;
			}
		}
		#endregion

		#region "Records"
		private void buildRecordTree(MyTreeView treeView, netsuiteRecord[] entityRecords, netsuiteRecord[] itemRecords, netsuiteRecord[] customRecords)
		{
			commonClient commonClient = new commonClient();

			treeView.Nodes.Clear();

			TreeNode recordsNode = treeView.Nodes.Add("records");

			TreeNode entityRecordsNode = commonClient.addNode(recordsNode, "entityRecords");
			buildRecordTreeNodes(commonClient, treeView, entityRecordsNode, entityRecords);

			TreeNode itemRecordsNode = commonClient.addNode(recordsNode, "itemRecords");
			buildRecordTreeNodes(commonClient, treeView, itemRecordsNode, itemRecords);

			TreeNode customRecordsNode = commonClient.addNode(recordsNode, "customRecords");
			buildRecordTreeNodes(commonClient, treeView, customRecordsNode, customRecords);
		}

		private void buildRecordTreeNodes(commonClient commonClient, MyTreeView treeView, TreeNode parentNode, netsuiteRecord[] records)
		{
			for (int i = 0; i < records.Length; i++)
			{
				netsuiteRecord record = records[i];

				TreeNode recordNode = commonClient.addNode(parentNode, record.recordName);
				TreeNode recordInternalIdNode = commonClient.addNode(commonClient.addNode(recordNode, "internalId"), record.internalId);
				TreeNode recordRecordIdNode = commonClient.addNode(commonClient.addNode(recordNode, "recordId"), record.recordId);
				TreeNode recordRecordsFieldsNode = commonClient.addNode(recordNode, "recordFields");

				string[] recordFields = records[i].recordFields;
				Array.Sort(recordFields);

				for (int j = 0; j < recordFields.Length; j++)
				{
					commonClient.addNode(recordRecordsFieldsNode, recordFields[j]);
				}
			}
		}

		#endregion

		#region "Scripts"

		private void buildScriptTree(MyTreeView treeView, netsuiteCustomScript[] customScripts)
		{
			commonClient commonClient = new commonClient();

			treeView.Nodes.Clear();

			TreeNode customScriptsNode = treeView.Nodes.Add("customScripts");

			for (int i = 0; i < customScripts.Length; i++)
			{
				netsuiteCustomScript customScript = customScripts[i];

				TreeNode customScriptNode = commonClient.addNode(customScriptsNode, customScript.scriptName);
				commonClient.addNode(commonClient.addNode(customScriptNode, "internalId"), customScript.internalId);
				commonClient.addNode(commonClient.addNode(customScriptNode, "scriptId"), customScript.scriptId);
				commonClient.addNode(commonClient.addNode(customScriptNode, "scriptType"), customScript.scriptType);
				commonClient.addNode(commonClient.addNode(customScriptNode, "scriptAPIVersion"), customScript.scriptAPIVersion);

				TreeNode customScriptScriptFunctionsNode = commonClient.addNode(customScriptNode, "scriptFunctions");

				netsuiteCustomScriptFunction[] customScriptFunctions = customScript.scriptFunctions.ToArray();

				Array.Sort(customScriptFunctions, delegate (netsuiteCustomScriptFunction scriptFunction1, netsuiteCustomScriptFunction scriptFunction2)
				{
					return scriptFunction1.functionType.CompareTo(scriptFunction2.functionType);
				});

				for (int j = 0; j < customScriptFunctions.Length; j++)
				{
					TreeNode customScriptScriptFunctionsFunctionTypeNode = commonClient.addNode(customScriptScriptFunctionsNode, customScriptFunctions[j].functionType);
					commonClient.addNode(customScriptScriptFunctionsFunctionTypeNode, customScriptFunctions[j].function);
				}

				TreeNode customScriptScriptFileNode = commonClient.addNode(customScriptNode, "scriptFile");
				commonClient.addNode(commonClient.addNode(customScriptScriptFileNode, "internalId"), customScript.scriptFile.internalId);
				commonClient.addNode(commonClient.addNode(customScriptScriptFileNode, "name"), customScript.scriptFile.name);
				commonClient.addNode(commonClient.addNode(customScriptScriptFileNode, "folder"), customScript.scriptFile.folderId);
				commonClient.addNode(commonClient.addNode(customScriptScriptFileNode, "type"), customScript.scriptFile.fileType);
				commonClient.addNode(commonClient.addNode(customScriptScriptFileNode, "size"), customScript.scriptFile.size);
				commonClient.addNode(commonClient.addNode(customScriptScriptFileNode, "content"), customScript.scriptFile.content);

				TreeNode customScriptScriptLibrariesNode = commonClient.addNode(customScriptNode, "scriptLibraries");

				netsuiteFile[] customScriptLibraries = customScript.scriptLibraries.ToArray();

				Array.Sort(customScriptLibraries, delegate (netsuiteFile scriptLibrary1, netsuiteFile scriptLibrary2)
				{
					return scriptLibrary1.name.CompareTo(scriptLibrary2.name);
				});

				for (int j = 0; j < customScriptLibraries.Length; j++)
				{
					TreeNode customScriptLibrariesScriptLibraryNode = commonClient.addNode(customScriptScriptLibrariesNode, customScriptLibraries[j].name);
					commonClient.addNode(commonClient.addNode(customScriptLibrariesScriptLibraryNode, "internalId"), customScriptLibraries[j].internalId);
					commonClient.addNode(commonClient.addNode(customScriptLibrariesScriptLibraryNode, "folder"), customScriptLibraries[j].folderId);
					commonClient.addNode(commonClient.addNode(customScriptLibrariesScriptLibraryNode, "type"), customScriptLibraries[j].fileType);
					commonClient.addNode(commonClient.addNode(customScriptLibrariesScriptLibraryNode, "size"), customScriptLibraries[j].size);
					commonClient.addNode(commonClient.addNode(customScriptLibrariesScriptLibraryNode, "content"), customScriptLibraries[j].content);
				}

				TreeNode customScriptScriptDeploymentsNode = commonClient.addNode(customScriptNode, "scriptDeployments");

				netsuiteCustomScriptDeployment[] customScriptDeployments = customScript.scriptDeployments.ToArray();

				Array.Sort(customScriptDeployments, delegate (netsuiteCustomScriptDeployment scriptDeployment1, netsuiteCustomScriptDeployment scriptDeployment2)
				{
					return scriptDeployment1.scriptDeploymentId.CompareTo(scriptDeployment2.scriptDeploymentId);
				});

				for (int j = 0; j < customScriptDeployments.Length; j++)
				{
					TreeNode customScriptScriptDeploymentsScriptDeploymentNode = commonClient.addNode(customScriptScriptDeploymentsNode, customScriptDeployments[j].scriptDeploymentId);
					commonClient.addNode(commonClient.addNode(customScriptScriptDeploymentsScriptDeploymentNode, "internalId"), customScriptDeployments[j].internalId);
					commonClient.addNode(commonClient.addNode(customScriptScriptDeploymentsScriptDeploymentNode, "isDeployed"), customScriptDeployments[j].isDeployed);
					commonClient.addNode(commonClient.addNode(customScriptScriptDeploymentsScriptDeploymentNode, "recordType"), customScriptDeployments[j].recordType);
					commonClient.addNode(commonClient.addNode(customScriptScriptDeploymentsScriptDeploymentNode, "status"), customScriptDeployments[j].status);
				}
			}
		}

		private void loadCustomScript(TreeNode treeNode)
		{
			if ((treeNode.Level == 2 && treeNode.Text == "scriptFile") || (treeNode.Level == 3 && treeNode.Parent.Text == "scriptLibraries"))
			{
				string scriptFile1InternalId = "0";
				string scriptFile2InternalId = "0";

				commonClient commonClient = new commonClient();

				TreeNode customScriptFile1Node = commonClient.getNodeFromPath(tvEnvironment1Scripts.Nodes[0], treeNode.FullPath);
				TreeNode customScriptFile2Node = commonClient.getNodeFromPath(tvEnvironment2Scripts.Nodes[0], treeNode.FullPath);

				if (compared)
				{
					scriptFile1InternalId = customScriptFile1Node.Nodes[0].Nodes[0].Text;
					scriptFile2InternalId = customScriptFile2Node.Nodes[0].Nodes[0].Text;
				}

				if (scriptFile1InternalId == "0" || scriptFile2InternalId == "0")
				{
					if (!compared)
					{
						MessageBox.Show(haveNotComparedText);
					}
					else
					{
						MessageBox.Show(missingScriptFileText);
					}

					return;
				}

				netsuiteClient netsuiteClient1 = new netsuiteClient(txtUrl1.Text, txtAccount1.Text, txtEmail1.Text, txtSignature1.Text, txtRole1.Text);
				netsuiteClient netsuiteClient2 = new netsuiteClient(txtUrl2.Text, txtAccount2.Text, txtEmail2.Text, txtSignature2.Text, txtRole2.Text);

				netsuiteFile netsuiteCustomScriptFile1 = netsuiteClient1.getCustomScriptFile(scriptFile1InternalId);
				netsuiteFile netsuiteCustomScriptFile2 = netsuiteClient2.getCustomScriptFile(scriptFile2InternalId);

				FileViewer scriptFileViewer = new FileViewer();

				scriptFileViewer.netsuiteClient1 = netsuiteClient1;
				scriptFileViewer.netsuiteClient2 = netsuiteClient2;

				scriptFileViewer.netsuiteCustomScriptFile1 = netsuiteCustomScriptFile1;
				scriptFileViewer.netsuiteCustomScriptFile2 = netsuiteCustomScriptFile2;

				scriptFileViewer.Show();

			}
			else if (treeNode.Level > 2 && treeNode.Text == "content")
			{
				loadCustomScript(treeNode.Parent);
			}
		}

		#endregion

		private void pullNetsuiteEnvironmentData()
		{
			dataPulled = true;
			compared = false;

			netsuiteClient netsuiteClient1 = new netsuiteClient(txtUrl1.Text, txtAccount1.Text, txtEmail1.Text, txtSignature1.Text, txtRole1.Text);
			netsuiteClient netsuiteClient2 = new netsuiteClient(txtUrl2.Text, txtAccount2.Text, txtEmail2.Text, txtSignature2.Text, txtRole2.Text);

			netsuiteEntityRecords entityRecords1 = null;
			netsuiteEntityRecords entityRecords2 = null;

			netsuiteItemRecords itemRecords1 = null;
			netsuiteItemRecords itemRecords2 = null;

			netsuiteCustomRecords customRecords1 = null;
			netsuiteCustomRecords customRecords2 = null;

			netsuiteCustomScripts scripts1 = null;
			netsuiteCustomScripts scripts2 = null;

			List<Task> tasks = new List<Task>()
			{
				Task.Factory.StartNew(() =>
				{
					if(chkRecords.Checked)
					{
						entityRecords1 = netsuiteClient1.getEntityRecords();
					}
				}),
				Task.Factory.StartNew(() =>
				{
					if(chkRecords.Checked)
					{
						entityRecords2 = netsuiteClient2.getEntityRecords();
					}
				}),
				Task.Factory.StartNew(() =>
				{
					if(chkRecords.Checked)
					{
						itemRecords1 = netsuiteClient1.getItemRecords();
					}
				}),
				Task.Factory.StartNew(() =>
				{
					if(chkRecords.Checked)
					{
						itemRecords2 = netsuiteClient2.getItemRecords();
					}
				}),
				Task.Factory.StartNew(() =>
				{
					if(chkRecords.Checked)
					{
						customRecords1 = netsuiteClient1.getCustomRecords();
					}
				}),
				Task.Factory.StartNew(() =>
				{
					if(chkRecords.Checked)
					{
						customRecords2 = netsuiteClient2.getCustomRecords();
					}
				}),
				Task.Factory.StartNew(() =>
				{
					if(chkScripts.Checked)
					{
						scripts1 = netsuiteClient1.getCustomScripts(settings.environment1IgnoreScripts.Select(x => x.internalId).ToList());
					}
				}),
				Task.Factory.StartNew(() =>
				{
					if(chkScripts.Checked)
					{
						scripts2 = netsuiteClient2.getCustomScripts(settings.environment1IgnoreScripts.Select(x => x.internalId).ToList());
					}
				})
			};

			Task.WaitAll(tasks.ToArray());

			if (chkRecords.Checked)
			{
				buildRecordTree(tvEnvironment1Records, entityRecords1.entityRecords, itemRecords1.itemRecords, customRecords1.customRecords);
				buildRecordTree(tvEnvironment2Records, entityRecords2.entityRecords, itemRecords2.itemRecords, customRecords2.customRecords);

				tvEnvironment1Records.AddLinkedTreeView(tvEnvironment2Records);
			}
			else
			{
				tvEnvironment1Records.Nodes.Clear();
				tvEnvironment2Records.Nodes.Clear();
			}

			if (chkScripts.Checked)
			{
				buildScriptTree(tvEnvironment1Scripts, scripts1.customScripts);
				buildScriptTree(tvEnvironment2Scripts, scripts2.customScripts);

				tvEnvironment1Scripts.AddLinkedTreeView(tvEnvironment2Scripts);
			}
			else
			{
				tvEnvironment1Scripts.Nodes.Clear();
				tvEnvironment2Scripts.Nodes.Clear();
			}
		}

		private void compareNetsuiteEnvironmentData()
		{
			if (!dataPulled)
			{
				DialogResult dialogResult = MessageBox.Show(cannotCompareText, confirmationTitle, MessageBoxButtons.YesNo);

				if (dialogResult == DialogResult.Yes)
				{
					pullNetsuiteEnvironmentData();
					compareNetsuiteEnvironmentData();
				}
			}
			else if (compared)
			{
				DialogResult dialogResult = MessageBox.Show(compareAgainText, confirmationTitle, MessageBoxButtons.YesNo);

				if (dialogResult == DialogResult.Yes)
				{
					pullNetsuiteEnvironmentData();
					compareNetsuiteEnvironmentData();
				}
			}
			else
			{
				compared = true;

				string customRecords1TreeString = "";
				string customRecords2TreeString = "";
				string customScripts1TreeString = "";
				string customScripts2TreeString = "";

				if (tvEnvironment1Records.Nodes.Count > 0)
				{
					customRecords1TreeString = convertTreeViewToString("", tvEnvironment1Records.Nodes[0]);
				}

				if (tvEnvironment2Records.Nodes.Count > 0)
				{
					customRecords2TreeString = convertTreeViewToString("", tvEnvironment2Records.Nodes[0]);
				}

				if (tvEnvironment1Scripts.Nodes.Count > 0)
				{
					customScripts1TreeString = convertTreeViewToString("", tvEnvironment1Scripts.Nodes[0]);
				}

				if (tvEnvironment2Scripts.Nodes.Count > 0)
				{
					customScripts2TreeString = convertTreeViewToString("", tvEnvironment2Scripts.Nodes[0]);
				}

				if (customRecords1TreeString != "" && customRecords2TreeString != "")
				{
					compareTreeViewStrings(tvEnvironment1Records, customRecords1TreeString, tvEnvironment2Records, customRecords2TreeString);
				}

				if (customScripts1TreeString != "" && customScripts2TreeString != "")
				{
					compareTreeViewStrings(tvEnvironment1Scripts, customScripts1TreeString, tvEnvironment2Scripts, customScripts2TreeString);
				}
			}
		}

		private string convertTreeViewToString(string treeViewString, TreeNode parentTreeNode)
		{
			treeViewString = parentTreeNode.FullPath + "\n";

			foreach (TreeNode childTreeNode in parentTreeNode.Nodes)
			{
				treeViewString = treeViewString + convertTreeViewToString(treeViewString, childTreeNode);
			}

			return treeViewString;
		}

		private void compareTreeViewStrings(MyTreeView newTreeView, string newText, MyTreeView oldTreeView, string oldText)
		{
			ISideBySideDiffBuilder diffBuilder = new SideBySideDiffBuilder(new Differ());
			SideBySideDiffModel sideBySideModel = diffBuilder.BuildDiffModel(oldText, newText);

			newTreeView.Nodes.Clear();
			oldTreeView.Nodes.Clear();

			TreeNode newParentNode = newTreeView.Nodes.Add(sideBySideModel.NewText.Lines[0].Text);
			TreeNode oldParentNode = oldTreeView.Nodes.Add(sideBySideModel.OldText.Lines[0].Text);

			colorTreeView(newParentNode.FullPath, newParentNode, sideBySideModel.NewText.Lines, sideBySideModel.OldText.Lines, 1, true);
			colorTreeView(oldParentNode.FullPath, oldParentNode, sideBySideModel.OldText.Lines, sideBySideModel.NewText.Lines, 1, false);

			newTreeView.AddLinkedTreeView(oldTreeView);
		}

		private int colorTreeView(string parentFullPath, TreeNode parentTreeNode, List<DiffPiece> textLines1, List<DiffPiece> textLines2, int currentIndex, bool productionEnvironment)
		{
			commonClient commonClient = new commonClient();
			int i = currentIndex;

			while (i < textLines1.Count)
			{
				DiffPiece diffPiece = textLines1[i];

				if (diffPiece.Type == ChangeType.Imaginary)
				{
					diffPiece.Text = textLines2[i].Text;
				}

				if (diffPiece.Text != "" && parentFullPath == diffPiece.Text.Substring(0, diffPiece.Text.LastIndexOf("\\")))
				{
					TreeNode treeNode = parentTreeNode.Nodes.Add(diffPiece.Text.Replace(parentFullPath + "\\", ""));

					if (diffPiece.Type == ChangeType.Inserted)
					{
						if (productionEnvironment)
						{
							commonClient.setNodeColor(treeNode, commonClient.insertedColor);
						}
						else
						{
							if (parentTreeNode.Text == "internalId")
							{
								treeNode.Text = "0";
							}

							commonClient.setNodeColor(treeNode, commonClient.deletedColor);
						}
					}
					else if (diffPiece.Type == ChangeType.Imaginary)
					{
						if (parentTreeNode.Text == "internalId")
						{
							treeNode.Text = "0";
						}

						if (productionEnvironment)
						{
							commonClient.setNodeColor(treeNode, commonClient.imaginaryColor);
						}
						else
						{
							commonClient.setNodeColor(treeNode, commonClient.deletedColor);
						}
					}
					else if (diffPiece.Type == ChangeType.Deleted)
					{
						if (productionEnvironment)
						{
							if (parentTreeNode.Text == "internalId")
							{
								treeNode.Text = "0";
							}

							commonClient.setNodeColor(treeNode, commonClient.deletedColor);
						}
						else
						{
							commonClient.setNodeColor(treeNode, commonClient.insertedColor);
						}
					}
					else if (diffPiece.Type == ChangeType.Modified)
					{
						if (parentTreeNode.Text != "internalId")
						{
							commonClient.setNodeColor(treeNode, commonClient.modifiedColor);
						}
					}

					i = colorTreeView(treeNode.FullPath, treeNode, textLines1, textLines2, i + 1, productionEnvironment);
				}
				else
				{
					return i;
				}
			}

			return 0;
		}
	}
}
