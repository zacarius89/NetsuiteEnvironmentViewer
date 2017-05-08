using System;
using System.Collections.Generic;
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
            foreach(var ignoredScript in Main.settings.environment1IgnoreScripts)
            {
                dgvEnvironment1IgnoreScripts.Rows.Add(ignoredScript.internalId, ignoredScript.fileName);
            }
            
            foreach(var ignoredScript in Main.settings.environment2IgnoreScripts)
            {
                dgvEnvironment2IgnoreScripts.Rows.Add(ignoredScript.internalId, ignoredScript.fileName);
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
                    string scriptInternalId = dgvEnvironment1IgnoreScripts.Rows[i].Cells[0].Value != null ? dgvEnvironment1IgnoreScripts.Rows[i].Cells[0].Value.ToString() : string.Empty;
                    string scriptFileName = dgvEnvironment1IgnoreScripts.Rows[i].Cells[1].Value != null ? dgvEnvironment1IgnoreScripts.Rows[i].Cells[1].Value.ToString() : string.Empty;

                    if (Regex.IsMatch(scriptInternalId, @"^\d+$") && scriptFileName != string.Empty)
                    {
                        Main.settings.environment1IgnoreScripts.Add(new IgnoredScript { internalId = scriptInternalId, fileName = scriptFileName });
                    }
                }

                for (int i = 0; i < dgvEnvironment2IgnoreScripts.Rows.Count - 1; i++)
                {
                    string scriptInternalId = dgvEnvironment2IgnoreScripts.Rows[i].Cells[0].Value != null ? dgvEnvironment2IgnoreScripts.Rows[i].Cells[0].Value.ToString() : string.Empty;
                    string scriptFileName = dgvEnvironment2IgnoreScripts.Rows[i].Cells[1].Value != null ? dgvEnvironment2IgnoreScripts.Rows[i].Cells[1].Value.ToString() : string.Empty;

                    if (Regex.IsMatch(scriptInternalId, @"^\d+$") && scriptFileName != string.Empty)
                    {
                        Main.settings.environment2IgnoreScripts.Add(new IgnoredScript { internalId = scriptInternalId, fileName = scriptFileName });
                    }
                }

                Main.settingsClient.saveSettings(Main.settings);

                Close();
            }
        }
    }
}
