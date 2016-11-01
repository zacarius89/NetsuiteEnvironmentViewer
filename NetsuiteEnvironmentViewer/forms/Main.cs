using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using DiffPlex;
using DiffPlex.DiffBuilder;
using DiffPlex.DiffBuilder.Model;

namespace NetsuiteEnvironmentViewer
{
    public partial class Main : Form
    {
        private string confirmationTitle = "Confirmation";
        private string saveSettingsConfirmationText = "Are you sure you want to save the settings?  This will overwrite the existing settings.";

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

            if(chkCustomRecords.Checked)
            {
                buildCustomRecordTrees(records1, records2);
                tvEnvironment1CustomRecords.AddLinkedTreeView(tvEnvironment2CustomRecords);
            }
            
            if(chkcustomScripts.Checked)
            {
                buildCustomScriptTrees(scripts1, scripts2);
                tvEnvironment1CustomScripts.AddLinkedTreeView(tvEnvironment2CustomScripts);
            }
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
            MessageBox.Show("This functionality it is in progress and not completed.");
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
        private void buildCustomRecordTrees(netsuiteCustomRecords customRecords1, netsuiteCustomRecords customRecords2)
        {
            commonClient commonClient = new commonClient();

            tvEnvironment1CustomRecords.Nodes.Clear();
            tvEnvironment2CustomRecords.Nodes.Clear();

            int customRecordsMaxLength = commonClient.findMaxLength(customRecords1.customRecords.Length, customRecords2.customRecords.Length);

            TreeNode customRecords1Node = tvEnvironment1CustomRecords.Nodes.Add("customRecords");
            TreeNode customRecords2Node = tvEnvironment2CustomRecords.Nodes.Add("customRecords");

            int i1 = 0;
            int i2 = 0;

            for (int i = 0; i < customRecordsMaxLength; i++)
            {
                netsuiteCustomRecord customRecord1 = customRecords1.customRecords[i1];
                netsuiteCustomRecord customRecord2 = customRecords2.customRecords[i2];

                if (customRecord1.recordName == customRecord2.recordName)
                {

                    TreeNode customRecord1Node = commonClient.addNode(customRecords1Node, customRecord1.recordName);
                    TreeNode customRecord2Node = commonClient.addNode(customRecords2Node, customRecord2.recordName);

                    TreeNode customRecord1InternalIdNode = commonClient.addNode(commonClient.addNode(customRecord1Node, "internalId"), customRecord1.internalId);
                    TreeNode customRecord2InternalIdNode = commonClient.addNode(commonClient.addNode(customRecord2Node, "internalId"), customRecord2.internalId);
                    commonClient.checkNodeColor(customRecord1InternalIdNode, customRecord2InternalIdNode, commonClient.warningColor);

                    TreeNode customRecord1RecordIdNode = commonClient.addNode(commonClient.addNode(customRecord1Node, "recordId"), customRecord1.recordId);
                    TreeNode customRecord2RecordIdNode = commonClient.addNode(commonClient.addNode(customRecord2Node, "recordId"), customRecord2.recordId);
                    commonClient.checkNodeColor(customRecord1RecordIdNode, customRecord2RecordIdNode, commonClient.warningColor);

                    TreeNode customRecord1RecordsFieldsNode = commonClient.addNode(customRecord1Node, "recordFields");
                    TreeNode customRecord2RecordsFieldsNode = commonClient.addNode(customRecord2Node, "recordFields");

                    string[] customRecordFields1 = customRecords1.customRecords[i1].recordFields;
                    string[] customRecordFields2 = customRecords2.customRecords[i2].recordFields;

                    Array.Sort(customRecordFields1);
                    Array.Sort(customRecordFields2);


                    int j1 = 0;
                    int j2 = 0;

                    int recordFieldsMaxLength = commonClient.findMaxLength(customRecordFields1.Length, customRecordFields2.Length);

                    for (int j = 0; j < recordFieldsMaxLength; j++)
                    {
                        if (customRecordFields1[j1] == customRecordFields2[j2])
                        {
                            commonClient.addNode(customRecord1RecordsFieldsNode, customRecordFields1[j1]);
                            commonClient.addNode(customRecord2RecordsFieldsNode, customRecordFields2[j2]);

                            j1++;
                            j2++;
                        }
                        else
                        {
                            if (String.Compare(customRecordFields1[j1], customRecordFields2[j2]) == -1)
                            {
                                TreeNode cusomRecordField1Node = commonClient.addNode(customRecord1RecordsFieldsNode, customRecordFields1[j1]);
                                TreeNode cusomRecordField2Node = commonClient.addNode(customRecord2RecordsFieldsNode, customRecordFields1[j1]);

                                commonClient.setNodeColor(cusomRecordField1Node, commonClient.newColor);
                                commonClient.setNodeColor(cusomRecordField2Node, commonClient.errorColor);

                                j1++;
                            }
                            else
                            {
                                TreeNode cusomRecordField1Node = commonClient.addNode(customRecord1RecordsFieldsNode, customRecordFields2[j2]);
                                TreeNode cusomRecordField2Node = commonClient.addNode(customRecord2RecordsFieldsNode, customRecordFields2[j2]);

                                commonClient.setNodeColor(cusomRecordField1Node, commonClient.errorColor);
                                commonClient.setNodeColor(cusomRecordField2Node, commonClient.newColor);

                                j2++;
                            }
                        }
                    }

                    i1++;
                    i2++;
                }
                else
                {
                    if (String.Compare(customRecord1.recordName, customRecord2.recordName) == -1)
                    {
                        addMissingCustomRecord(customRecords1Node, customRecord1, commonClient.newColor);
                        addMissingCustomRecord(customRecords2Node, customRecord1, commonClient.errorColor);

                        i1++;
                    }
                    else
                    {
                        addMissingCustomRecord(customRecords1Node, customRecord2, commonClient.errorColor);
                        addMissingCustomRecord(customRecords2Node, customRecord2, commonClient.newColor);

                        i2++;
                    }
                }
            }
        }

        private void addMissingCustomRecord(TreeNode treeNode, netsuiteCustomRecord customRecord, Color color)
        {
            commonClient commonClient = new commonClient();

            TreeNode customRecordNode = commonClient.addNode(treeNode, customRecord.recordName);
            commonClient.setNodeColor(customRecordNode, color);

            TreeNode customRecordInternalIdNode = commonClient.addNode(commonClient.addNode(customRecordNode, "internalId"), customRecord.internalId);
            commonClient.setNodeColor(customRecordInternalIdNode, color);

            TreeNode customRecordRecordIdNode = commonClient.addNode(commonClient.addNode(customRecordNode, "recordId"), customRecord.recordId);
            commonClient.setNodeColor(customRecordRecordIdNode, color);

            TreeNode customRecordRecordFieldsNode = commonClient.addNode(customRecordNode, "scriptDeployments");
            commonClient.setNodeColor(customRecordRecordFieldsNode, color);

            Array.Sort(customRecord.recordFields);

            foreach (string customRecordfield in customRecord.recordFields)
            {
                TreeNode customRecordRecordFieldRecordFieldNode = commonClient.addNode(customRecordRecordFieldsNode, customRecordfield);
                commonClient.setNodeColor(customRecordRecordFieldRecordFieldNode, color);
            }
        }

        private void addMissingCustomRecords(TreeView treeView1, TreeView treeView2, int index, netsuiteCustomRecord customRecord)
        {
            commonClient commonClient = new commonClient();

            treeView1.Nodes[0].Nodes.Add(customRecord.recordName);
            treeView1.Nodes[0].Nodes[index].ForeColor = commonClient.newColor;

            treeView1.Nodes[0].Nodes[index].Nodes.Add("internalId");
            treeView1.Nodes[0].Nodes[index].Nodes[0].Nodes.Add(customRecord.internalId);
            treeView1.Nodes[0].Nodes[index].Nodes[0].ForeColor = commonClient.newColor;
            treeView1.Nodes[0].Nodes[index].Nodes[0].Nodes[0].ForeColor = commonClient.newColor;

            treeView1.Nodes[0].Nodes[index].Nodes.Add("recordId");
            treeView1.Nodes[0].Nodes[index].Nodes[1].Nodes.Add(customRecord.recordId);
            treeView1.Nodes[0].Nodes[index].Nodes[1].ForeColor = commonClient.newColor;
            treeView1.Nodes[0].Nodes[index].Nodes[1].Nodes[0].ForeColor = commonClient.newColor;

            treeView1.Nodes[0].Nodes[index].Nodes.Add("recordFields");
            treeView1.Nodes[0].Nodes[index].Nodes[2].ForeColor = commonClient.newColor;

            treeView2.Nodes[0].Nodes.Add(customRecord.recordName);
            treeView2.Nodes[0].Nodes[index].ForeColor = commonClient.errorColor;

            treeView2.Nodes[0].Nodes[index].Nodes.Add("internalId");
            treeView2.Nodes[0].Nodes[index].Nodes[0].Nodes.Add(customRecord.internalId);
            treeView2.Nodes[0].Nodes[index].Nodes[0].ForeColor = commonClient.errorColor;
            treeView2.Nodes[0].Nodes[index].Nodes[0].Nodes[0].ForeColor = commonClient.errorColor;

            treeView2.Nodes[0].Nodes[index].Nodes.Add("recordId");
            treeView2.Nodes[0].Nodes[index].Nodes[1].Nodes.Add(customRecord.recordId);
            treeView2.Nodes[0].Nodes[index].Nodes[1].ForeColor = commonClient.errorColor;
            treeView2.Nodes[0].Nodes[index].Nodes[1].Nodes[0].ForeColor = commonClient.errorColor;

            treeView2.Nodes[0].Nodes[index].Nodes.Add("recordFields");
            treeView2.Nodes[0].Nodes[index].Nodes[2].ForeColor = commonClient.errorColor;

            foreach (string customRecordfield in customRecord.recordFields)
            {
                treeView1.Nodes[0].Nodes[index].Nodes[2].Nodes.Add(customRecordfield);
                treeView2.Nodes[0].Nodes[index].Nodes[2].Nodes.Add(customRecordfield);

                treeView1.Nodes[0].Nodes[index].Nodes[2].Nodes[0].ForeColor = commonClient.newColor;
                treeView2.Nodes[0].Nodes[index].Nodes[2].Nodes[0].ForeColor = commonClient.errorColor;
            }
        }
        #endregion

        #region "CustomScripts"
        private void buildCustomScriptTrees(netsuiteCustomScripts customScripts1, netsuiteCustomScripts customScripts2)
        {
            commonClient commonClient = new commonClient();

            tvEnvironment1CustomScripts.Nodes.Clear();
            tvEnvironment2CustomScripts.Nodes.Clear();

            int customScriptsMaxLength = commonClient.findMaxLength(customScripts1.customScripts.Length, customScripts2.customScripts.Length);

            TreeNode customScripts1Node = tvEnvironment1CustomScripts.Nodes.Add("customScripts");
            TreeNode customScripts2Node = tvEnvironment2CustomScripts.Nodes.Add("customScripts");

            int i1 = 0;
            int i2 = 0;

            for (int i = 0; i < customScriptsMaxLength; i++)
            {
                netsuiteCustomScript customScript1 = customScripts1.customScripts[i1];
                netsuiteCustomScript customScript2 = customScripts2.customScripts[i2];

                if (customScript1.scriptName == customScript2.scriptName)
                {
                    TreeNode customScript1Node = commonClient.addNode(customScripts1Node, customScript1.scriptName);
                    TreeNode customScript2Node = commonClient.addNode(customScripts2Node, customScript2.scriptName);

                    TreeNode customScript1InternalIdNode = commonClient.addNode(commonClient.addNode(customScript1Node, "internalId"), customScript1.internalId);
                    TreeNode customScript2InternalIdNode = commonClient.addNode(commonClient.addNode(customScript2Node, "internalId"), customScript2.internalId);
                    commonClient.checkNodeColor(customScript1InternalIdNode, customScript2InternalIdNode, commonClient.warningColor);

                    TreeNode customScript1ScriptIdNode = commonClient.addNode(commonClient.addNode(customScript1Node, "scriptId"), customScript1.scriptId);
                    TreeNode customScript2ScriptIdNode = commonClient.addNode(commonClient.addNode(customScript2Node, "scriptId"), customScript2.scriptId);
                    commonClient.checkNodeColor(customScript1ScriptIdNode, customScript2ScriptIdNode, commonClient.errorColor);

                    TreeNode customScript1ScriptTypeNode = commonClient.addNode(commonClient.addNode(customScript1Node, "scriptType"), customScript1.scriptType);
                    TreeNode customScript2ScriptTypeNode = commonClient.addNode(commonClient.addNode(customScript2Node, "scriptType"), customScript2.scriptType);
                    commonClient.checkNodeColor(customScript1ScriptTypeNode, customScript2ScriptTypeNode, commonClient.errorColor);

                    TreeNode customScript1ScriptAPIVersionNode = commonClient.addNode(commonClient.addNode(customScript1Node, "scriptAPIVersion"), customScript1.scriptAPIVersion);
                    TreeNode customScript2ScriptAPIVersionNode = commonClient.addNode(commonClient.addNode(customScript2Node, "scriptAPIVersion"), customScript2.scriptAPIVersion);
                    commonClient.checkNodeColor(customScript1ScriptAPIVersionNode, customScript2ScriptAPIVersionNode, commonClient.errorColor);

                    TreeNode customScript1ScriptFunctionsNode = commonClient.addNode(customScript1Node, "scriptFunctions");
                    TreeNode customScript2ScriptFunctionsNode = commonClient.addNode(customScript2Node, "scriptFunctions");

                    netsuiteCustomScriptFunction[] customScriptFunctions1 = customScript1.scriptFunctions;
                    netsuiteCustomScriptFunction[] customScriptFunctions2 = customScript2.scriptFunctions;

                    Array.Sort(customScriptFunctions1, delegate (netsuiteCustomScriptFunction scripFunction1, netsuiteCustomScriptFunction scripFunction2)
                    {
                        return scripFunction1.functionType.CompareTo(scripFunction2.functionType);
                    });

                    Array.Sort(customScriptFunctions2, delegate (netsuiteCustomScriptFunction scripFunction1, netsuiteCustomScriptFunction scripFunction2)
                    {
                        return scripFunction1.functionType.CompareTo(scripFunction2.functionType);
                    });

                    int scriptFunctionsMaxLength = commonClient.findMaxLength(customScriptFunctions1.Length, customScriptFunctions2.Length);

                    int j1 = 0;
                    int j2 = 0;

                    for (int j = 0; j < scriptFunctionsMaxLength; j++)
                    {
                        TreeNode customScript1ScriptFunctionsFunctionTypeNode;
                        TreeNode customScript2ScriptFunctionsFunctionTypeNode;

                        TreeNode customScript1ScriptFunctionsFunctionTypeFunctionNode;
                        TreeNode customScript2ScriptFunctionsFunctionTypeFunctionNode;

                        if (customScriptFunctions1[j1].functionType == customScriptFunctions2[j2].functionType)
                        {
                            customScript1ScriptFunctionsFunctionTypeNode = commonClient.addNode(customScript1ScriptFunctionsNode, customScriptFunctions1[j1].functionType);
                            customScript2ScriptFunctionsFunctionTypeNode = commonClient.addNode(customScript2ScriptFunctionsNode, customScriptFunctions2[j2].functionType);

                            customScript1ScriptFunctionsFunctionTypeFunctionNode = commonClient.addNode(customScript1ScriptFunctionsFunctionTypeNode, customScriptFunctions1[j1].function);
                            customScript2ScriptFunctionsFunctionTypeFunctionNode = commonClient.addNode(customScript2ScriptFunctionsFunctionTypeNode, customScriptFunctions2[j2].function);
                            commonClient.checkNodeColor(customScript1ScriptFunctionsFunctionTypeFunctionNode, customScript2ScriptFunctionsFunctionTypeFunctionNode, commonClient.errorColor);

                            j1++;
                            j2++;
                        }
                        else
                        {
                            if (String.Compare(customScriptFunctions1[j1].functionType, customScriptFunctions2[j2].functionType) == -1)
                            {
                                customScript1ScriptFunctionsFunctionTypeNode = commonClient.addNode(customScript1ScriptFunctionsNode, customScriptFunctions1[j1].functionType);
                                customScript2ScriptFunctionsFunctionTypeNode = commonClient.addNode(customScript1ScriptFunctionsNode, customScriptFunctions1[j1].functionType);

                                customScript1ScriptFunctionsFunctionTypeFunctionNode = commonClient.addNode(customScript1ScriptFunctionsFunctionTypeNode, customScriptFunctions1[j1].function);
                                customScript2ScriptFunctionsFunctionTypeFunctionNode = commonClient.addNode(customScript1ScriptFunctionsFunctionTypeNode, customScriptFunctions1[j1].function);

                                j1++;
                            }
                            else
                            {
                                customScript1ScriptFunctionsFunctionTypeNode = commonClient.addNode(customScript2ScriptFunctionsNode, customScriptFunctions2[j2].functionType);
                                customScript2ScriptFunctionsFunctionTypeNode = commonClient.addNode(customScript2ScriptFunctionsNode, customScriptFunctions2[j2].functionType);

                                customScript1ScriptFunctionsFunctionTypeFunctionNode = commonClient.addNode(customScript2ScriptFunctionsFunctionTypeNode, customScriptFunctions2[j2].function);
                                customScript2ScriptFunctionsFunctionTypeFunctionNode = commonClient.addNode(customScript2ScriptFunctionsFunctionTypeNode, customScriptFunctions2[j2].function);

                                j2++;
                            }

                            commonClient.setNodeColor(customScript1ScriptFunctionsFunctionTypeFunctionNode, commonClient.errorColor);
                            commonClient.setNodeColor(customScript2ScriptFunctionsFunctionTypeFunctionNode, commonClient.errorColor);
                        }
                    }

                    TreeNode customScript1ScriptFileNode = commonClient.addNode(customScript1Node, "scriptFile");
                    TreeNode customScript2ScriptFileNode = commonClient.addNode(customScript2Node, "scriptFile");

                    TreeNode customScript1ScriptFileInternalIdNode = commonClient.addNode(commonClient.addNode(customScript1ScriptFileNode, "internalId"), customScript1.scriptFile.internalId);
                    TreeNode customScript2ScriptFileInternalIdNode = commonClient.addNode(commonClient.addNode(customScript2ScriptFileNode, "internalId"), customScript2.scriptFile.internalId);
                    commonClient.checkNodeColor(customScript1ScriptFileInternalIdNode, customScript2ScriptFileInternalIdNode, commonClient.warningColor);

                    TreeNode customScript1ScriptFileNameNode = commonClient.addNode(commonClient.addNode(customScript1ScriptFileNode, "name"), customScript1.scriptFile.name);
                    TreeNode customScript2ScriptFileNameNode = commonClient.addNode(commonClient.addNode(customScript2ScriptFileNode, "name"), customScript2.scriptFile.name);
                    commonClient.checkNodeColor(customScript1ScriptFileNameNode, customScript2ScriptFileNameNode, commonClient.errorColor);

                    TreeNode customScript1ScriptFileFolderNode = commonClient.addNode(commonClient.addNode(customScript1ScriptFileNode, "folder"), customScript1.scriptFile.folder);
                    TreeNode customScript2ScriptFileFolderNode = commonClient.addNode(commonClient.addNode(customScript2ScriptFileNode, "folder"), customScript2.scriptFile.folder);
                    commonClient.checkNodeColor(customScript1ScriptFileFolderNode, customScript2ScriptFileFolderNode, commonClient.errorColor);

                    TreeNode customScript1ScriptFileTypeNode = commonClient.addNode(commonClient.addNode(customScript1ScriptFileNode, "type"), customScript1.scriptFile.type);
                    TreeNode customScript2ScriptFileTypeNode = commonClient.addNode(commonClient.addNode(customScript2ScriptFileNode, "type"), customScript2.scriptFile.type);
                    commonClient.checkNodeColor(customScript1ScriptFileTypeNode, customScript2ScriptFileTypeNode, commonClient.errorColor);

                    TreeNode customScript1ScriptFileSizeNode = commonClient.addNode(commonClient.addNode(customScript1ScriptFileNode, "size"), customScript1.scriptFile.size);
                    TreeNode customScript2ScriptFileSizeNode = commonClient.addNode(commonClient.addNode(customScript2ScriptFileNode, "size"), customScript2.scriptFile.size);
                    commonClient.checkNodeColor(customScript1ScriptFileSizeNode, customScript2ScriptFileSizeNode, commonClient.warningColor);

                    TreeNode customScript1ScriptFileContentNode = commonClient.addNode(commonClient.addNode(customScript1ScriptFileNode, "content"), customScript1.scriptFile.content);
                    TreeNode customScript2ScriptFileContentNode = commonClient.addNode(commonClient.addNode(customScript2ScriptFileNode, "content"), customScript2.scriptFile.content);
                    commonClient.checkNodeColor(customScript1ScriptFileContentNode, customScript2ScriptFileContentNode, commonClient.errorColor);

                    TreeNode customScript1ScriptDeploymentsNode = commonClient.addNode(customScript1Node, "scriptDeployments");
                    TreeNode customScript2ScriptDeploymentsNode = commonClient.addNode(customScript2Node, "scriptDeployments");

                    int scriptDeploymentsMaxLength = commonClient.findMaxLength(customScript1.scriptDeployments.Length, customScript2.scriptDeployments.Length);

                    netsuiteCustomScriptDeployment[] customScriptDeployment1 = customScript1.scriptDeployments;
                    netsuiteCustomScriptDeployment[] customScriptDeployment2 = customScript2.scriptDeployments;

                    Array.Sort(customScriptDeployment1, delegate (netsuiteCustomScriptDeployment scriptDeployment1, netsuiteCustomScriptDeployment scriptDeployment2)
                    {
                        return scriptDeployment1.scriptDeploymentId.CompareTo(scriptDeployment2.scriptDeploymentId);
                    });

                    Array.Sort(customScriptDeployment2, delegate (netsuiteCustomScriptDeployment scriptDeployment1, netsuiteCustomScriptDeployment scriptDeployment2)
                    {
                        return scriptDeployment1.scriptDeploymentId.CompareTo(scriptDeployment2.scriptDeploymentId);
                    });

                    j1 = 0;
                    j2 = 0;

                    for (int j = 0; j < scriptDeploymentsMaxLength; j++)
                    {
                        TreeNode customScript1ScriptDeploymentsScriptDeploymentNode = commonClient.addNode(customScript1ScriptDeploymentsNode, "deployment " + (j + 1).ToString());
                        TreeNode customScript2ScriptDeploymentsScriptDeploymentNode = commonClient.addNode(customScript2ScriptDeploymentsNode, "deployment " + (j + 1).ToString());

                        TreeNode customScript1ScriptDeploymentsScriptDeploymentInternalIdNode;
                        TreeNode customScript2ScriptDeploymentsScriptDeploymentInternalIdNode;

                        TreeNode customScript1ScriptDeploymentsScriptDeploymentScriptDeploymentIdNode;
                        TreeNode customScript2ScriptDeploymentsScriptDeploymentScriptDeploymentIdNode;

                        TreeNode customScript1ScriptDeploymentsScriptDeploymentIsDeployedNode;
                        TreeNode customScript2ScriptDeploymentsScriptDeploymentIsDeployedNode;

                        TreeNode customScript1ScriptDeploymentsScriptDeploymentRecordTypeNode;
                        TreeNode customScript2ScriptDeploymentsScriptDeploymentRecordTypeNode;

                        TreeNode customScript1ScriptDeploymentsScriptDeploymentStatusNode;
                        TreeNode customScript2ScriptDeploymentsScriptDeploymentStatusNode;

                        if (customScriptDeployment1[j1].scriptDeploymentId == customScriptDeployment2[j2].scriptDeploymentId)
                        {
                            customScript1ScriptDeploymentsScriptDeploymentInternalIdNode = commonClient.addNode(commonClient.addNode(customScript1ScriptDeploymentsScriptDeploymentNode, "internalId"), customScriptDeployment1[j1].internalId);
                            customScript2ScriptDeploymentsScriptDeploymentInternalIdNode = commonClient.addNode(commonClient.addNode(customScript2ScriptDeploymentsScriptDeploymentNode, "internalId"), customScriptDeployment2[j2].internalId);
                            commonClient.checkNodeColor(customScript1ScriptDeploymentsScriptDeploymentInternalIdNode, customScript2ScriptDeploymentsScriptDeploymentInternalIdNode, commonClient.warningColor);

                            customScript1ScriptDeploymentsScriptDeploymentScriptDeploymentIdNode = commonClient.addNode(commonClient.addNode(customScript1ScriptDeploymentsScriptDeploymentNode, "scriptDeploymentId"), customScriptDeployment1[j1].scriptDeploymentId);
                            customScript2ScriptDeploymentsScriptDeploymentScriptDeploymentIdNode = commonClient.addNode(commonClient.addNode(customScript2ScriptDeploymentsScriptDeploymentNode, "scriptDeploymentId"), customScriptDeployment2[j2].scriptDeploymentId);
                            commonClient.checkNodeColor(customScript1ScriptDeploymentsScriptDeploymentScriptDeploymentIdNode, customScript2ScriptDeploymentsScriptDeploymentScriptDeploymentIdNode, commonClient.errorColor);

                            customScript1ScriptDeploymentsScriptDeploymentIsDeployedNode = commonClient.addNode(commonClient.addNode(customScript1ScriptDeploymentsScriptDeploymentNode, "isDeployed"), customScriptDeployment1[j1].isDeployed);
                            customScript2ScriptDeploymentsScriptDeploymentIsDeployedNode = commonClient.addNode(commonClient.addNode(customScript2ScriptDeploymentsScriptDeploymentNode, "isDeployed"), customScriptDeployment2[j2].isDeployed);
                            commonClient.checkNodeColor(customScript1ScriptDeploymentsScriptDeploymentIsDeployedNode, customScript2ScriptDeploymentsScriptDeploymentIsDeployedNode, commonClient.errorColor);

                            customScript1ScriptDeploymentsScriptDeploymentRecordTypeNode = commonClient.addNode(commonClient.addNode(customScript1ScriptDeploymentsScriptDeploymentNode, "recordType"), customScriptDeployment1[j1].recordType);
                            customScript2ScriptDeploymentsScriptDeploymentRecordTypeNode = commonClient.addNode(commonClient.addNode(customScript2ScriptDeploymentsScriptDeploymentNode, "recordType"), customScriptDeployment2[j2].recordType);
                            commonClient.checkNodeColor(customScript1ScriptDeploymentsScriptDeploymentRecordTypeNode, customScript2ScriptDeploymentsScriptDeploymentRecordTypeNode, commonClient.errorColor);

                            customScript1ScriptDeploymentsScriptDeploymentStatusNode = commonClient.addNode(commonClient.addNode(customScript1ScriptDeploymentsScriptDeploymentNode, "status"), customScriptDeployment1[j1].status);
                            customScript2ScriptDeploymentsScriptDeploymentStatusNode = commonClient.addNode(commonClient.addNode(customScript2ScriptDeploymentsScriptDeploymentNode, "status"), customScriptDeployment2[j2].status);
                            commonClient.checkNodeColor(customScript1ScriptDeploymentsScriptDeploymentStatusNode, customScript2ScriptDeploymentsScriptDeploymentStatusNode, commonClient.errorColor);

                            j1++;
                            j2++;
                        }
                        else
                        {
                            if (String.Compare(customScriptDeployment1[j1].scriptDeploymentId, customScriptDeployment2[j2].scriptDeploymentId) == -1)
                            {
                                customScript1ScriptDeploymentsScriptDeploymentInternalIdNode = commonClient.addNode(commonClient.addNode(customScript1ScriptDeploymentsScriptDeploymentNode, "internalId"), customScriptDeployment1[j1].internalId);
                                customScript2ScriptDeploymentsScriptDeploymentInternalIdNode = commonClient.addNode(commonClient.addNode(customScript2ScriptDeploymentsScriptDeploymentNode, "internalId"), customScriptDeployment1[j1].internalId);

                                customScript1ScriptDeploymentsScriptDeploymentScriptDeploymentIdNode = commonClient.addNode(commonClient.addNode(customScript1ScriptDeploymentsScriptDeploymentNode, "scriptDeploymentId"), customScriptDeployment1[j1].scriptDeploymentId);
                                customScript2ScriptDeploymentsScriptDeploymentScriptDeploymentIdNode = commonClient.addNode(commonClient.addNode(customScript2ScriptDeploymentsScriptDeploymentNode, "scriptDeploymentId"), customScriptDeployment1[j1].scriptDeploymentId);

                                customScript1ScriptDeploymentsScriptDeploymentIsDeployedNode = commonClient.addNode(commonClient.addNode(customScript1ScriptDeploymentsScriptDeploymentNode, "isDeployed"), customScriptDeployment1[j1].isDeployed);
                                customScript2ScriptDeploymentsScriptDeploymentIsDeployedNode = commonClient.addNode(commonClient.addNode(customScript2ScriptDeploymentsScriptDeploymentNode, "isDeployed"), customScriptDeployment1[j1].isDeployed);

                                customScript1ScriptDeploymentsScriptDeploymentRecordTypeNode = commonClient.addNode(commonClient.addNode(customScript1ScriptDeploymentsScriptDeploymentNode, "recordType"), customScriptDeployment1[j1].recordType);
                                customScript2ScriptDeploymentsScriptDeploymentRecordTypeNode = commonClient.addNode(commonClient.addNode(customScript2ScriptDeploymentsScriptDeploymentNode, "recordType"), customScriptDeployment1[j1].recordType);

                                customScript1ScriptDeploymentsScriptDeploymentStatusNode = commonClient.addNode(commonClient.addNode(customScript1ScriptDeploymentsScriptDeploymentNode, "status"), customScriptDeployment1[j1].status);
                                customScript2ScriptDeploymentsScriptDeploymentStatusNode = commonClient.addNode(commonClient.addNode(customScript2ScriptDeploymentsScriptDeploymentNode, "status"), customScriptDeployment1[j1].status);

                                commonClient.setNodeColor(customScript1ScriptDeploymentsScriptDeploymentInternalIdNode, commonClient.newColor);
                                commonClient.setNodeColor(customScript2ScriptDeploymentsScriptDeploymentInternalIdNode, commonClient.errorColor);

                                commonClient.setNodeColor(customScript1ScriptDeploymentsScriptDeploymentScriptDeploymentIdNode, commonClient.newColor);
                                commonClient.setNodeColor(customScript2ScriptDeploymentsScriptDeploymentScriptDeploymentIdNode, commonClient.errorColor);

                                commonClient.setNodeColor(customScript1ScriptDeploymentsScriptDeploymentIsDeployedNode, commonClient.newColor);
                                commonClient.setNodeColor(customScript2ScriptDeploymentsScriptDeploymentIsDeployedNode, commonClient.errorColor);

                                commonClient.setNodeColor(customScript1ScriptDeploymentsScriptDeploymentRecordTypeNode, commonClient.newColor);
                                commonClient.setNodeColor(customScript2ScriptDeploymentsScriptDeploymentRecordTypeNode, commonClient.errorColor);

                                commonClient.setNodeColor(customScript1ScriptDeploymentsScriptDeploymentStatusNode, commonClient.newColor);
                                commonClient.setNodeColor(customScript2ScriptDeploymentsScriptDeploymentStatusNode, commonClient.errorColor);

                                j1++;
                            }
                            else
                            {
                                customScript1ScriptDeploymentsScriptDeploymentInternalIdNode = commonClient.addNode(commonClient.addNode(customScript1ScriptDeploymentsScriptDeploymentNode, "internalId"), customScriptDeployment2[j2].internalId);
                                customScript2ScriptDeploymentsScriptDeploymentInternalIdNode = commonClient.addNode(commonClient.addNode(customScript2ScriptDeploymentsScriptDeploymentNode, "internalId"), customScriptDeployment2[j2].internalId);

                                customScript1ScriptDeploymentsScriptDeploymentScriptDeploymentIdNode = commonClient.addNode(commonClient.addNode(customScript1ScriptDeploymentsScriptDeploymentNode, "scriptDeploymentId"), customScriptDeployment2[j2].scriptDeploymentId);
                                customScript2ScriptDeploymentsScriptDeploymentScriptDeploymentIdNode = commonClient.addNode(commonClient.addNode(customScript2ScriptDeploymentsScriptDeploymentNode, "scriptDeploymentId"), customScriptDeployment2[j2].scriptDeploymentId);

                                customScript1ScriptDeploymentsScriptDeploymentIsDeployedNode = commonClient.addNode(commonClient.addNode(customScript1ScriptDeploymentsScriptDeploymentNode, "isDeployed"), customScriptDeployment2[j2].isDeployed);
                                customScript2ScriptDeploymentsScriptDeploymentIsDeployedNode = commonClient.addNode(commonClient.addNode(customScript2ScriptDeploymentsScriptDeploymentNode, "isDeployed"), customScriptDeployment2[j2].isDeployed);

                                customScript1ScriptDeploymentsScriptDeploymentRecordTypeNode = commonClient.addNode(commonClient.addNode(customScript1ScriptDeploymentsScriptDeploymentNode, "recordType"), customScriptDeployment2[j2].recordType);
                                customScript2ScriptDeploymentsScriptDeploymentRecordTypeNode = commonClient.addNode(commonClient.addNode(customScript2ScriptDeploymentsScriptDeploymentNode, "recordType"), customScriptDeployment2[j2].recordType);

                                customScript1ScriptDeploymentsScriptDeploymentStatusNode = commonClient.addNode(commonClient.addNode(customScript1ScriptDeploymentsScriptDeploymentNode, "status"), customScriptDeployment2[j2].status);
                                customScript2ScriptDeploymentsScriptDeploymentStatusNode = commonClient.addNode(commonClient.addNode(customScript2ScriptDeploymentsScriptDeploymentNode, "status"), customScriptDeployment2[j2].status);

                                commonClient.setNodeColor(customScript1ScriptDeploymentsScriptDeploymentInternalIdNode, commonClient.errorColor);
                                commonClient.setNodeColor(customScript2ScriptDeploymentsScriptDeploymentInternalIdNode, commonClient.newColor);

                                commonClient.setNodeColor(customScript1ScriptDeploymentsScriptDeploymentScriptDeploymentIdNode, commonClient.errorColor);
                                commonClient.setNodeColor(customScript2ScriptDeploymentsScriptDeploymentScriptDeploymentIdNode, commonClient.newColor);

                                commonClient.setNodeColor(customScript1ScriptDeploymentsScriptDeploymentIsDeployedNode, commonClient.errorColor);
                                commonClient.setNodeColor(customScript2ScriptDeploymentsScriptDeploymentIsDeployedNode, commonClient.newColor);

                                commonClient.setNodeColor(customScript1ScriptDeploymentsScriptDeploymentRecordTypeNode, commonClient.errorColor);
                                commonClient.setNodeColor(customScript2ScriptDeploymentsScriptDeploymentRecordTypeNode, commonClient.newColor);

                                commonClient.setNodeColor(customScript1ScriptDeploymentsScriptDeploymentStatusNode, commonClient.errorColor);
                                commonClient.setNodeColor(customScript2ScriptDeploymentsScriptDeploymentStatusNode, commonClient.newColor);

                                j2++;
                            }
                        }
                    }

                    i1++;
                    i2++;
                }
                else
                {
                    if (String.Compare(customScript1.scriptName, customScript2.scriptName) == -1)
                    {
                        addMissingCustomScript(customScripts1Node, customScript1, commonClient.newColor);
                        addMissingCustomScript(customScripts2Node, customScript1, commonClient.errorColor);

                        i1++;
                    }
                    else
                    {
                        addMissingCustomScript(customScripts2Node, customScript2, commonClient.newColor);
                        addMissingCustomScript(customScripts1Node, customScript2, commonClient.errorColor);

                        i2++;
                    }
                }

            }
        }

        private void addMissingCustomScript(TreeNode treeNode, netsuiteCustomScript customScript, Color color)
        {
            commonClient commonClient = new commonClient();

            TreeNode customScriptNode = commonClient.addNode(treeNode, customScript.scriptName);
            commonClient.setNodeColor(customScriptNode, color);

            TreeNode customScriptInternalIdNode = commonClient.addNode(commonClient.addNode(customScriptNode, "internalId"), customScript.internalId);
            commonClient.setNodeColor(customScriptInternalIdNode, color);

            TreeNode customScriptScriptIdNode = commonClient.addNode(commonClient.addNode(customScriptNode, "scriptId"), customScript.scriptId);
            commonClient.setNodeColor(customScriptScriptIdNode, color);

            TreeNode customScriptScriptTypeNode = commonClient.addNode(commonClient.addNode(customScriptNode, "scriptType"), customScript.scriptType);
            commonClient.setNodeColor(customScriptScriptTypeNode, color);

            TreeNode customScriptScriptAPIVersionNode = commonClient.addNode(commonClient.addNode(customScriptNode, "scriptAPIVersion"), customScript.scriptAPIVersion);
            commonClient.setNodeColor(customScriptScriptAPIVersionNode, color);

            TreeNode customScriptScriptFunctionsNode = commonClient.addNode(customScriptNode, "scriptFunctions");
            commonClient.setNodeColor(customScriptScriptFunctionsNode, color);

            foreach (netsuiteCustomScriptFunction customScriptFunction in customScript.scriptFunctions)
            {
                TreeNode customScript1ScriptFunctionsFunctionNode = commonClient.addNode(commonClient.addNode(customScriptScriptFunctionsNode, customScriptFunction.functionType), customScriptFunction.function);
                commonClient.setNodeColor(customScript1ScriptFunctionsFunctionNode, color);
            }

            TreeNode customScriptScriptFileNode = commonClient.addNode(customScriptNode, "scriptFile");
            commonClient.setNodeColor(customScriptScriptFileNode, color);

            TreeNode customScriptScriptFileInternalIdNode = commonClient.addNode(commonClient.addNode(customScriptScriptFileNode, "internalId"), customScript.scriptFile.internalId);
            commonClient.setNodeColor(customScriptScriptFileInternalIdNode, color);

            TreeNode customScriptScriptFileNameNode = commonClient.addNode(commonClient.addNode(customScriptScriptFileNode, "name"), customScript.scriptFile.name);
            commonClient.setNodeColor(customScriptScriptFileNameNode, color);

            TreeNode customScriptScriptFileFolderNode = commonClient.addNode(commonClient.addNode(customScriptScriptFileNode, "folder"), customScript.scriptFile.folder);
            commonClient.setNodeColor(customScriptScriptFileFolderNode, color);

            TreeNode customScriptScriptFileTypeNode = commonClient.addNode(commonClient.addNode(customScriptScriptFileNode, "type"), customScript.scriptFile.type);
            commonClient.setNodeColor(customScriptScriptFileTypeNode, color);

            TreeNode customScriptScriptFileSizeNode = commonClient.addNode(commonClient.addNode(customScriptScriptFileNode, "size"), customScript.scriptFile.size);
            commonClient.setNodeColor(customScriptScriptFileSizeNode, color);

            TreeNode customScriptScriptFileContentNode = commonClient.addNode(commonClient.addNode(customScriptScriptFileNode, "content"), customScript.scriptFile.content);
            commonClient.setNodeColor(customScriptScriptFileContentNode, color);

            TreeNode customScriptScriptDeploymentsNode = commonClient.addNode(customScriptNode, "scriptDeployments");
            commonClient.setNodeColor(customScriptScriptDeploymentsNode, color);

            int k = 0;

            foreach (netsuiteCustomScriptDeployment customScriptDeployment in customScript.scriptDeployments)
            {
                TreeNode customScriptScriptDeploymentsDeploymentNode = commonClient.addNode(customScriptScriptDeploymentsNode, "deployment " + (k + 1).ToString());
                commonClient.setNodeColor(customScriptScriptDeploymentsDeploymentNode, color);

                TreeNode customScriptScriptDeploymentsDeploymentInternalIdNode = commonClient.addNode(commonClient.addNode(customScriptScriptDeploymentsDeploymentNode, "internalId"), customScriptDeployment.internalId);
                commonClient.setNodeColor(customScriptScriptDeploymentsDeploymentInternalIdNode, color);

                TreeNode customScriptScriptDeploymentsDeploymentScriptDeploymentIdNode = commonClient.addNode(commonClient.addNode(customScriptScriptDeploymentsDeploymentNode, "scriptDeploymentId"), customScriptDeployment.scriptDeploymentId);
                commonClient.setNodeColor(customScriptScriptDeploymentsDeploymentScriptDeploymentIdNode, color);

                TreeNode customScriptScriptDeploymentsDeploymentIsDeployedNode = commonClient.addNode(commonClient.addNode(customScriptScriptDeploymentsDeploymentNode, "isDeployed"), customScriptDeployment.isDeployed);
                commonClient.setNodeColor(customScriptScriptDeploymentsDeploymentIsDeployedNode, color);

                TreeNode customScriptScriptDeploymentsDeploymentRecordTypeNode = commonClient.addNode(commonClient.addNode(customScriptScriptDeploymentsDeploymentNode, "recordType"), customScriptDeployment.recordType);
                commonClient.setNodeColor(customScriptScriptDeploymentsDeploymentRecordTypeNode, color);

                TreeNode customScriptScriptDeploymentsDeploymentStatusNode = commonClient.addNode(commonClient.addNode(customScriptScriptDeploymentsDeploymentNode, "status"), customScriptDeployment.status);
                commonClient.setNodeColor(customScriptScriptDeploymentsDeploymentStatusNode, color);

                k++;
            }
        }
        #endregion

        private void loadCustomScript(TreeNode treeNode)
        {
            if(treeNode.Level == 2 && treeNode.Text == "scriptFile")
            {
                commonClient commonClient = new commonClient();
                netsuiteClient netsuiteClient1 = new netsuiteClient(txtUrl1.Text, txtAccount1.Text, txtEmail1.Text, txtSignature1.Text, txtRole1.Text);
                netsuiteClient netsuiteClient2 = new netsuiteClient(txtUrl2.Text, txtAccount2.Text, txtEmail2.Text, txtSignature2.Text, txtRole2.Text);

                TreeNode customScriptFile1Node = commonClient.getNodeFromPath(tvEnvironment1CustomScripts.Nodes[0], treeNode.FullPath);
                TreeNode customScriptFile2Node = commonClient.getNodeFromPath(tvEnvironment2CustomScripts.Nodes[0], treeNode.FullPath);

                netsuiteCustomScriptFile netsuiteCustomScriptFile1 = netsuiteClient1.getCustomScriptFile(customScriptFile1Node.Nodes[0].Nodes[0].Text);
                netsuiteCustomScriptFile netsuiteCustomScriptFile2 = netsuiteClient2.getCustomScriptFile(customScriptFile2Node.Nodes[0].Nodes[0].Text);

                FileViewer scriptFileViewer = new FileViewer();

                scriptFileViewer.netsuiteClient1 = netsuiteClient1;
                scriptFileViewer.netsuiteClient2 = netsuiteClient2;

                scriptFileViewer.netsuiteCustomScriptFile1 = netsuiteCustomScriptFile1;
                scriptFileViewer.netsuiteCustomScriptFile2 = netsuiteCustomScriptFile2;

                scriptFileViewer.Show();

            }
            else if(treeNode.Level > 2)
            {
                loadCustomScript(treeNode.Parent);
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
            SideBySideDiffModel sideBySideModel = diffBuilder.BuildDiffModel(newText, oldText);

            newTreeView.Nodes.Clear();
            oldTreeView.Nodes.Clear();

            TreeNode newParentNode = newTreeView.Nodes.Add(sideBySideModel.NewText.Lines[0].Text);
            TreeNode oldParentNode = oldTreeView.Nodes.Add(sideBySideModel.OldText.Lines[0].Text);

            colorTreeView(newParentNode.FullPath, newParentNode, sideBySideModel.NewText.Lines, 1);
            colorTreeView(oldParentNode.FullPath, oldParentNode, sideBySideModel.OldText.Lines, 1);

            newTreeView.AddLinkedTreeView(oldTreeView);
        }

        private void colorTreeView(string parentFullPath, TreeNode treeNode, List<DiffPiece> textLines, int currentIndex)
        {
            commonClient commonClient = new commonClient();

            for (int i = currentIndex; i < textLines.Count; i++)
            {
                DiffPiece diffPiece = textLines[i];

                if(diffPiece.Text.StartsWith(parentFullPath))
                {

                }
                else
                {
                    treeNode.Text = treeNode.Text + "\n" + diffPiece.Text;
                }
            }

            foreach (DiffPiece diffPiece in textLines)
            {
                if(diffPiece.Text.StartsWith(parentFullPath))
                {
                    treeNode = treeNode.Nodes.Add(diffPiece.Text);
                }
                else
                {

                }
                if (diffPiece.Type == ChangeType.Unchanged)
                {
                    //richTextBox.AppendText(diffPiece.Text + "\n");
                }
                else if (diffPiece.Type == ChangeType.Inserted)
                {
                    //richTextBox.AppendText(diffPiece.Text + "\n", commonClient.newColor);
                }
                else if (diffPiece.Type == ChangeType.Deleted)
                {
                    //richTextBox.AppendText(diffPiece.Text + "\n", commonClient.errorColor);
                }
                else if (diffPiece.Type == ChangeType.Modified)
                {
                    //richTextBox.AppendText(diffPiece.Text + "\n", commonClient.warningColor);
                }
                else if (diffPiece.Type == ChangeType.Imaginary)
                {
                    //richTextBox.AppendText("\n");
                }
            }
        }
    }
}
