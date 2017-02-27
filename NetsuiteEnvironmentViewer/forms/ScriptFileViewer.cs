using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DiffPlex;
using DiffPlex.DiffBuilder;
using DiffPlex.DiffBuilder.Model;

namespace NetsuiteEnvironmentViewer
{
    public partial class FileViewer : Form
    {
        private string confirmationTitle = "Confirmation";
        private string confirmationText = "Are you sure you want to push this content to the other environment?  This will overwrite the existing content.";

        public netsuiteFile netsuiteCustomScriptFile1;
        public netsuiteFile netsuiteCustomScriptFile2;

        public netsuiteClient netsuiteClient1;
        public netsuiteClient netsuiteClient2;

        public FileViewer()
        {
            InitializeComponent();
        }

        #region "Events"

        #region "Load"
        private void FileViewer_Load(object sender, EventArgs e)
        {
            txtInternalId1.Text = netsuiteCustomScriptFile1.internalId;
            txtName1.Text = netsuiteCustomScriptFile1.name;
            txtType1.Text = netsuiteCustomScriptFile1.fileType;
            txtSize1.Text = netsuiteCustomScriptFile1.size;
            rTxtContent1.Text = base64Decode(netsuiteCustomScriptFile1.content);

            txtInternalId2.Text = netsuiteCustomScriptFile2.internalId;
            txtName2.Text = netsuiteCustomScriptFile2.name;
            txtType2.Text = netsuiteCustomScriptFile2.fileType;
            txtSize2.Text = netsuiteCustomScriptFile2.size;
            rTxtContent2.Text = base64Decode(netsuiteCustomScriptFile2.content);

            rTxtContent1.AddLinkedRichTextBox(rTxtContent2);
        }

        #endregion

        #region "Click"
        private void btnCompare_Click(object sender, EventArgs e)
        {
            compareTexts(rTxtContent1, base64Decode(netsuiteCustomScriptFile1.content), rTxtContent2, base64Decode(netsuiteCustomScriptFile2.content));
        }

        private void btnPushToEnvironment2_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show(confirmationText, confirmationTitle, MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                netsuiteClient2.saveCustomScriptFileContents(netsuiteCustomScriptFile1, netsuiteCustomScriptFile2);
            }
        }

        #endregion

        #endregion

        private void compareTexts(MyRichTextBox newRichTextBox, string newText, MyRichTextBox oldRichTextBox, string oldText)
        {
            ISideBySideDiffBuilder diffBuilder = new SideBySideDiffBuilder(new Differ());
            SideBySideDiffModel sideBySideModel = diffBuilder.BuildDiffModel(oldText, newText);

            colorRichTextBox(newRichTextBox, sideBySideModel.NewText.Lines, true);
            colorRichTextBox(oldRichTextBox, sideBySideModel.OldText.Lines, false);

            newRichTextBox.AddLinkedRichTextBox(oldRichTextBox);
        }

        private void colorRichTextBox(MyRichTextBox richTextBox, List<DiffPiece> textLines, bool productionEnvironment)
        {
            commonClient commonClient = new commonClient();
            richTextBox.Text = "";

            foreach (DiffPiece diffPiece in textLines)
            {
                if (diffPiece.Type == ChangeType.Unchanged)
                {
                    richTextBox.AppendText(diffPiece.Text + "\n");
                }
                else if (diffPiece.Type == ChangeType.Inserted)
                {
                    if(productionEnvironment)
                    {
                        richTextBox.AppendText(diffPiece.Text + "\n", commonClient.insertedColor);
                    }
                    else
                    {
                        richTextBox.AppendText(diffPiece.Text + "\n", commonClient.deletedColor);
                    }
                }
                else if (diffPiece.Type == ChangeType.Deleted)
                {
                    if(productionEnvironment)
                    {
                        richTextBox.AppendText(diffPiece.Text + "\n", commonClient.deletedColor);
                    }
                    else
                    {
                        richTextBox.AppendText(diffPiece.Text + "\n", commonClient.insertedColor);
                    }
                }
                else if (diffPiece.Type == ChangeType.Modified)
                {
                    richTextBox.AppendText(diffPiece.Text + "\n", commonClient.modifiedColor);
                }
                else if (diffPiece.Type == ChangeType.Imaginary)
                {
                    richTextBox.AppendText(diffPiece.Text + "\n", commonClient.deletedColor);
                }
            }
        }

        private string base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }
    }
}
