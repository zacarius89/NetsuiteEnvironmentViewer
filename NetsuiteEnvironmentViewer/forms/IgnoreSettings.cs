using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace NetsuiteEnvironmentViewer
{
    public partial class IgnoreSettings : Form
    {
        public IgnoreSettings()
        {
            InitializeComponent();
        }

        private void IgnoreSettings_Load(object sender, EventArgs e)
        {
            foreach(var internalId in Main.settings.environment1IgnoreScripts)
            {
                dgvEnvironment1IgnoreScripts.Rows.Add(internalId);
            }
            
            foreach(var internalId in Main.settings.environment2IgnoreScripts)
            {
                dgvEnvironment2IgnoreScripts.Rows.Add(internalId);
            }
        }

        private void btnSaveSettings_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show(Main.saveSettingsConfirmationText, Main.confirmationTitle, MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                Main.settings.environment1IgnoreScripts.Clear();
                Main.settings.environment2IgnoreScripts.Clear();

                for (int i = 0; i < dgvEnvironment1IgnoreScripts.Rows.Count - 1; i++)
                {
                    string rowValue = dgvEnvironment1IgnoreScripts.Rows[i].Cells[0].Value != null ? dgvEnvironment1IgnoreScripts.Rows[i].Cells[0].Value.ToString() : string.Empty;
                    if (Regex.IsMatch(rowValue, @"^\d+$"))
                    {
                        Main.settings.environment1IgnoreScripts.Add(rowValue);
                    }
                }

                for (int i = 0; i < dgvEnvironment2IgnoreScripts.Rows.Count - 1; i++)
                {
                    string rowValue = dgvEnvironment2IgnoreScripts.Rows[i].Cells[0].Value != null ? dgvEnvironment2IgnoreScripts.Rows[i].Cells[0].Value.ToString() : string.Empty;
                    if (Regex.IsMatch(rowValue, @"^\d+$"))
                    {
                        Main.settings.environment2IgnoreScripts.Add(rowValue);
                    }
                }

                Main.settingsClient.saveSettings(Main.settings);

                Close();
            }
        }
    }
}
