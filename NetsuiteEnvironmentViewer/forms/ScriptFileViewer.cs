using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace NetsuiteEnvironmentViewer
{
    public partial class ScriptFileViewer : Form
    {
        private string confirmationTitle = "Confirmation";
        private string confirmationText = "Are you sure you want to push this content to the other environment?  This will overwrite the existing content.";

        public netsuiteCustomScriptFile netsuiteCustomScriptFile1;
        public netsuiteCustomScriptFile netsuiteCustomScriptFile2;

        public netsuiteClient netsuiteClient1;
        public netsuiteClient netsuiteClient2;

        public ScriptFileViewer()
        {
            InitializeComponent();
        }

        private void ScriptFileViewer_Load(object sender, EventArgs e)
        {
            txtInternalId1.Text = netsuiteCustomScriptFile1.internalId;
            txtName1.Text = netsuiteCustomScriptFile1.name;
            txtType1.Text = netsuiteCustomScriptFile1.type;
            txtSize1.Text = netsuiteCustomScriptFile1.size;
            rTxtContent1.Text = netsuiteCustomScriptFile1.content;

            txtInternalId2.Text = netsuiteCustomScriptFile2.internalId;
            txtName2.Text = netsuiteCustomScriptFile2.name;
            txtType2.Text = netsuiteCustomScriptFile2.type;
            txtSize2.Text = netsuiteCustomScriptFile2.size;
            rTxtContent2.Text = netsuiteCustomScriptFile2.content;

            rTxtContent1.AddLinkedRichTextBox(rTxtContent2);
        }

        private void btnPushToEnvironment2_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show(confirmationText, confirmationTitle, MessageBoxButtons.YesNo);

            if(dialogResult == DialogResult.Yes)
            {
                netsuiteClient2.saveCustomScriptFileContents(netsuiteCustomScriptFile1, netsuiteCustomScriptFile2);
            }
        }

        private void btnCompareToEnvironment2_Click(object sender, EventArgs e)
        {
            compareTexts(rTxtContent1, rTxtContent2);

            rTxtContent1.AddLinkedRichTextBox(rTxtContent2);
        }

        private void btnCompareToEnvironment1_Click(object sender, EventArgs e)
        {
            compareTexts(rTxtContent1, rTxtContent2);

            rTxtContent1.AddLinkedRichTextBox(rTxtContent2);
        }

        private void compareTexts(RichTextBox richTextBox1, RichTextBox richTextBox2)
        {
            int maxCharactersLength;

            List<string> richTextCharacters1 = new List<string>(richTextBox1.Text.Split(new char[] { '\n' }));
            List<string> richTextCharacters2 = new List<string>(richTextBox2.Text.Split(new char[] { '\n' }));

            if (richTextCharacters1.Count > richTextCharacters2.Count)
            {
                maxCharactersLength = richTextCharacters1.Count;
            }
            else
            {
                maxCharactersLength = richTextCharacters2.Count;
            }

            List<richTextBoxColor> richTextBoxColors1 = new List<richTextBoxColor>();
            List<richTextBoxColor> richTextBoxColors2 = new List<richTextBoxColor>();

            for (int i = 0; i < maxCharactersLength; i++)
            {
                bool isSame;

                string a = richTextCharacters1[i];
                string b = richTextCharacters2[i];
                isSame = string.Equals(a, b, StringComparison.Ordinal);

                if (isSame == false)
                {
                    richTextBoxColor richTextBoxColor1 = new richTextBoxColor();
                    richTextBoxColor richTextBoxColor2 = new richTextBoxColor();

                    bool existsLater = false;

                    for(int j = i; j < richTextCharacters2.Count; j++)
                    {
                        if(richTextCharacters1[i] == richTextCharacters2[j])
                        {
                            existsLater = true;
                            j = richTextCharacters2.Count;
                        }
                    }

                    if (existsLater)
                    {
                        richTextCharacters1.Insert(i, richTextCharacters2[i]);
                        richTextBox1.Text = String.Join("\n", richTextCharacters1);

                        richTextBoxColor1.start = (int)(richTextBox1.Text.IndexOf(richTextCharacters1[i]));
                        richTextBoxColor1.length = richTextCharacters1[i].Length;
                        richTextBoxColor1.color = Color.Red;

                        richTextBoxColor2.start = (int)(richTextBox2.Text.IndexOf(richTextCharacters2[i]));
                        richTextBoxColor2.length = richTextCharacters2[i].Length;
                        richTextBoxColor2.color = Color.Green;
                    }
                    else
                    {
                        richTextCharacters2.Insert(i, richTextCharacters1[i]);
                        richTextBox2.Text = String.Join("\n", richTextCharacters2);

                        richTextBoxColor1.start = (int)(richTextBox1.Text.IndexOf(richTextCharacters1[i]));
                        richTextBoxColor1.length = richTextCharacters1[i].Length;
                        richTextBoxColor1.color = Color.Green;

                        richTextBoxColor2.start = (int)(richTextBox2.Text.IndexOf(richTextCharacters2[i]));
                        richTextBoxColor2.length = richTextCharacters2[i].Length;
                        richTextBoxColor2.color = Color.Red;
                    }

                    richTextBoxColors1.Add(richTextBoxColor1);
                    richTextBoxColors2.Add(richTextBoxColor2);
                }

                if (richTextCharacters1.Count > richTextCharacters2.Count)
                {
                    maxCharactersLength = richTextCharacters1.Count;
                }
                else
                {
                    maxCharactersLength = richTextCharacters2.Count;
                }
            }

            foreach (richTextBoxColor richTextColor in richTextBoxColors1)
            {
                richTextBox1.SelectionStart = richTextColor.start;
                richTextBox1.SelectionLength = richTextColor.length;
                richTextBox1.SelectionColor = richTextColor.color;
            }

            foreach (richTextBoxColor richTextColor in richTextBoxColors2)
            {
                richTextBox2.SelectionStart = richTextColor.start;
                richTextBox2.SelectionLength = richTextColor.length;
                richTextBox2.SelectionColor = richTextColor.color;
            }
        }
    }
}
