using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using DiffPlex;
using DiffPlex.DiffBuilder;
using DiffPlex.DiffBuilder.Model;

namespace NetsuiteEnvironmentViewer
{
    public partial class Main : Form
    {
        private string confirmationTitle = "";
        private string saveSettingsConfirmationText = "Are you sure you want to save the settings?  This will overwrite the existing settings.";
        private string haveNotComparedText = "Have you compared the environments yet?  Please compare before opening the File Viewer.";
        private string missingCustomScriptFileText = "Cannot compare scriptFile(s).  The scriptFile does not exist in one of the environments.";

        private bool dataPulled = false;
        private bool compared = false;

        public Main()
        {
            InitializeComponent();
        }

        #region "Events"

        #region "Load"
        private void Main_Load(object sender, EventArgs e)
        {
            settingsClient settingsClient = new settingsClient();
            settings settings = settingsClient.loadSettings();

            chkUseSameCredentials.Checked = settings.useSameCredentialsChecked;
            chkCustomRecords.Checked = settings.customRecordsChecked;
            chkcustomScripts.Checked = settings.customScriptsChecked;

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
        private void chkUseSameCredentials_CheckedChanged(object sender, EventArgs e)
        {
            syncCredentials();
            enableEnvironment2Credentials();
        }
        #endregion

        #region "Click"
        private void btnPullNetsuiteEnvironmentData_Click(object sender, EventArgs e)
        {
            pullNetsuiteEnvironmentData();
        }

        private void btnSaveSettings_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show(saveSettingsConfirmationText, confirmationTitle, MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                settingsClient settingsClient = new settingsClient();
                settings settings = new settings();

                settings.useSameCredentialsChecked = chkUseSameCredentials.Checked;
                settings.customRecordsChecked = chkCustomRecords.Checked;
                settings.customScriptsChecked = chkcustomScripts.Checked;

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
            compareNetsuiteEnvironmentData();
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
        private void tvEnvironment1CustomRecords_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            commonClient commonClient = new commonClient();
            commonClient.getNodeFromPath(tvEnvironment2CustomRecords.Nodes[0], e.Node.FullPath).Collapse();
        }

        private void tvEnvironment2CustomRecords_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            commonClient commonClient = new commonClient();
            commonClient.getNodeFromPath(tvEnvironment1CustomRecords.Nodes[0], e.Node.FullPath).Collapse();
        }

        private void tvEnvironment1CustomScripts_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            commonClient commonClient = new commonClient();
            commonClient.getNodeFromPath(tvEnvironment2CustomScripts.Nodes[0], e.Node.FullPath).Collapse();
        }

        private void tvEnvironment2CustomScripts_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            commonClient commonClient = new commonClient();
            commonClient.getNodeFromPath(tvEnvironment1CustomScripts.Nodes[0], e.Node.FullPath).Collapse();
        }
        #endregion

        #region "BeforeExpand"
        private void tvEnvironment1CustomScripts_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.Level == 3 && e.Node.Text == "content")
            {
                e.Cancel = true;
            }
        }

        private void tvEnvironment2CustomScripts_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.Level == 3 && e.Node.Text == "content")
            {
                e.Cancel = true;
            }
        }

        #endregion

        #region "AfterExpand"
        private void tvEnvironment1CustomRecords_AfterExpand(object sender, TreeViewEventArgs e)
        {
            commonClient commonClient = new commonClient();
            commonClient.getNodeFromPath(tvEnvironment2CustomRecords.Nodes[0], e.Node.FullPath).Expand();
        }

        private void tvEnvironment2CustomRecords_AfterExpand(object sender, TreeViewEventArgs e)
        {
            commonClient commonClient = new commonClient();
            commonClient.getNodeFromPath(tvEnvironment1CustomRecords.Nodes[0], e.Node.FullPath).Expand();
        }

        private void tvEnvironment1CustomScripts_AfterExpand(object sender, TreeViewEventArgs e)
        {
            commonClient commonClient = new commonClient();
            commonClient.getNodeFromPath(tvEnvironment2CustomScripts.Nodes[0], e.Node.FullPath).Expand();
        }

        private void tvEnvironment2CustomScripts_AfterExpand(object sender, TreeViewEventArgs e)
        {
            commonClient commonClient = new commonClient();
            commonClient.getNodeFromPath(tvEnvironment1CustomScripts.Nodes[0], e.Node.FullPath).Expand();
        }
        #endregion

        #region "NodeMouseDoubleClick"
        private void tvEnvironment1CustomScripts_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            loadCustomScript(e.Node);
        }

        private void tvEnvironment2CustomScripts_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            loadCustomScript(e.Node);
        }

        #endregion

        #endregion

        #region "Credentials"
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

        #region "CustomRecords"
        private void buildCustomRecordTree(MyTreeView treeView, netsuiteCustomRecord[] customRecords)
        {
            commonClient commonClient = new commonClient();

            treeView.Nodes.Clear();

            TreeNode customRecordsNode = treeView.Nodes.Add("customRecords");

            for (int i = 0; i < customRecords.Length; i++)
            {
                netsuiteCustomRecord customRecord = customRecords[i];

                TreeNode customRecordNode = commonClient.addNode(customRecordsNode, customRecord.recordName);
                TreeNode customRecordInternalIdNode = commonClient.addNode(commonClient.addNode(customRecordNode, "internalId"), customRecord.internalId);
                TreeNode customRecordRecordIdNode = commonClient.addNode(commonClient.addNode(customRecordNode, "recordId"), customRecord.recordId);
                TreeNode customRecordRecordsFieldsNode = commonClient.addNode(customRecordNode, "recordFields");

                string[] customRecordFields = customRecords[i].recordFields;
                Array.Sort(customRecordFields);

                for (int j = 0; j < customRecordFields.Length; j++)
                {
                    commonClient.addNode(customRecordRecordsFieldsNode, customRecordFields[j]);
                }
            }
        }

        #endregion

        #region "CustomScripts"

        private void buildCustomScriptTree(MyTreeView treeView, netsuiteCustomScript[] customScripts)
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

                netsuiteCustomScriptFunction[] customScriptFunctions = customScript.scriptFunctions;

                Array.Sort(customScriptFunctions, delegate (netsuiteCustomScriptFunction scripFunction1, netsuiteCustomScriptFunction scripFunction2)
                {
                    return scripFunction1.functionType.CompareTo(scripFunction2.functionType);
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

                TreeNode customScriptScriptDeploymentsNode = commonClient.addNode(customScriptNode, "scriptDeployments");

                netsuiteCustomScriptDeployment[] customScriptDeployments = customScript.scriptDeployments;

                Array.Sort(customScriptDeployments, delegate (netsuiteCustomScriptDeployment scriptDeployment1, netsuiteCustomScriptDeployment scriptDeployment2)
                {
                    return scriptDeployment1.scriptDeploymentId.CompareTo(scriptDeployment2.scriptDeploymentId);
                });

                for (int j = 0; j < customScriptDeployments.Length; j++)
                {
                    TreeNode customScriptScriptDeploymentsScriptDeploymentNode = commonClient.addNode(customScriptScriptDeploymentsNode, customScriptDeployments[j].scriptDeploymentId);
                    //TreeNode customScriptScriptDeploymentsScriptDeploymentNode = commonClient.addNode(customScriptScriptDeploymentsNode, "deployment " + (j + 1).ToString());
                    commonClient.addNode(commonClient.addNode(customScriptScriptDeploymentsScriptDeploymentNode, "internalId"), customScriptDeployments[j].internalId);
                    //commonClient.addNode(commonClient.addNode(customScriptScriptDeploymentsScriptDeploymentNode, "scriptDeploymentId"), customScriptDeployments[j].scriptDeploymentId);
                    commonClient.addNode(commonClient.addNode(customScriptScriptDeploymentsScriptDeploymentNode, "isDeployed"), customScriptDeployments[j].isDeployed);
                    commonClient.addNode(commonClient.addNode(customScriptScriptDeploymentsScriptDeploymentNode, "recordType"), customScriptDeployments[j].recordType);
                    commonClient.addNode(commonClient.addNode(customScriptScriptDeploymentsScriptDeploymentNode, "status"), customScriptDeployments[j].status);
                }
            }
        }

        private void loadCustomScript(TreeNode treeNode)
        {
            if (treeNode.Level == 2 && treeNode.Text == "scriptFile")
            {
                commonClient commonClient = new commonClient();

                TreeNode customScriptFile1Node = commonClient.getNodeFromPath(tvEnvironment1CustomScripts.Nodes[0], treeNode.FullPath);
                TreeNode customScriptFile2Node = commonClient.getNodeFromPath(tvEnvironment2CustomScripts.Nodes[0], treeNode.FullPath);

                string scriptFile1InternalId = "0";
                string scriptFile2InternalId = "0";

                if (compared)
                {
                    scriptFile1InternalId = customScriptFile1Node.Nodes[0].Nodes[0].Text;
                    scriptFile2InternalId = customScriptFile2Node.Nodes[0].Nodes[0].Text;
                }
                
                if (scriptFile1InternalId == "0" || scriptFile2InternalId == "0")
                {
                    if(!compared)
                    {
                        MessageBox.Show(haveNotComparedText);
                    }
                    else
                    {
                        MessageBox.Show(missingCustomScriptFileText);
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

            netsuiteCustomRecords records1 = null;
            netsuiteCustomRecords records2 = null;

            netsuiteCustomScripts scripts1 = null;
            netsuiteCustomScripts scripts2 = null;

            List<Task> tasks = new List<Task>()
            {
                Task.Factory.StartNew(() =>
                {
                    if(chkCustomRecords.Checked)
                    {
                        records1 = netsuiteClient1.getCustomRecords();
                    }
                }),
                Task.Factory.StartNew(() =>
                {
                    if(chkCustomRecords.Checked)
                    {
                        records2 = netsuiteClient2.getCustomRecords();
                    }
                }),
                Task.Factory.StartNew(() =>
                {
                    if(chkcustomScripts.Checked)
                    {
                        scripts1 = netsuiteClient1.getCustomScripts();
                    }
                }),
                Task.Factory.StartNew(() =>
                {
                    if(chkcustomScripts.Checked)
                    {
                        scripts2 = netsuiteClient2.getCustomScripts();
                    }
                })
            };

            Task.WaitAll(tasks.ToArray());

            if (chkCustomRecords.Checked)
            {
                buildCustomRecordTree(tvEnvironment1CustomRecords, records1.customRecords);
                buildCustomRecordTree(tvEnvironment2CustomRecords, records2.customRecords);
                //buildCustomRecordTrees(records1, records2);
                tvEnvironment1CustomRecords.AddLinkedTreeView(tvEnvironment2CustomRecords);
            }
            else
            {
                tvEnvironment1CustomRecords.Nodes.Clear();
                tvEnvironment2CustomRecords.Nodes.Clear();
            }

            if (chkcustomScripts.Checked)
            {
                buildCustomScriptTree(tvEnvironment1CustomScripts, scripts1.customScripts);
                buildCustomScriptTree(tvEnvironment2CustomScripts, scripts2.customScripts);

                //buildCustomScriptTrees(scripts1, scripts2);
                tvEnvironment1CustomScripts.AddLinkedTreeView(tvEnvironment2CustomScripts);
            }
            else
            {
                tvEnvironment1CustomScripts.Nodes.Clear();
                tvEnvironment2CustomScripts.Nodes.Clear();
            }
        } 

        private void compareNetsuiteEnvironmentData()
        {
            if(!dataPulled)
            {
                DialogResult dialogResult = MessageBox.Show("Cannot compare until Netsuite Environment Data has been pulled.  Do you want to do this now?", confirmationTitle, MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    pullNetsuiteEnvironmentData();
                    compareNetsuiteEnvironmentData();
                }
            }
            else if (compared)
            {
                DialogResult dialogResult = MessageBox.Show("Cannot compare until Netsuite Environment Data has been pulled again.  Do you want to do this now?", confirmationTitle, MessageBoxButtons.YesNo);

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

                if (tvEnvironment1CustomRecords.Nodes.Count > 0)
                {
                    customRecords1TreeString = convertTreeViewToString("", tvEnvironment1CustomRecords.Nodes[0]);
                }

                if (tvEnvironment2CustomRecords.Nodes.Count > 0)
                {
                    customRecords2TreeString = convertTreeViewToString("", tvEnvironment2CustomRecords.Nodes[0]);
                }

                if (tvEnvironment1CustomScripts.Nodes.Count > 0)
                {
                    customScripts1TreeString = convertTreeViewToString("", tvEnvironment1CustomScripts.Nodes[0]);
                }

                if (tvEnvironment2CustomScripts.Nodes.Count > 0)
                {
                    customScripts2TreeString = convertTreeViewToString("", tvEnvironment2CustomScripts.Nodes[0]);
                }

                if (customRecords1TreeString != "" && customRecords2TreeString != "")
                {
                    compareTreeViewStrings(tvEnvironment1CustomRecords, customRecords1TreeString, tvEnvironment2CustomRecords, customRecords2TreeString);
                }

                if (customScripts1TreeString != "" && customScripts2TreeString != "")
                {
                    compareTreeViewStrings(tvEnvironment1CustomScripts, customScripts1TreeString, tvEnvironment2CustomScripts, customScripts2TreeString);
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

                if(diffPiece.Type == ChangeType.Imaginary)
                {
                    diffPiece.Text = textLines2[i].Text;
                }

                if (diffPiece.Text != "" && parentFullPath == diffPiece.Text.Substring(0, diffPiece.Text.LastIndexOf("\\")))
                {
                    TreeNode treeNode = parentTreeNode.Nodes.Add(diffPiece.Text.Replace(parentFullPath + "\\", ""));

                    if (diffPiece.Type == ChangeType.Inserted)
                    {
                        if(productionEnvironment)
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
                    else if(diffPiece.Type == ChangeType.Imaginary)
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
                        if(parentTreeNode.Text != "internalId")
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
