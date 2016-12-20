using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetsuiteEnvironmentViewer
{
    public partial class CSVImportTool : Form
    {
        public netsuiteClient netsuiteClient;
        private string fileName;
        private string safeFileName;
        private string content;
        private string contentBase64;

        public CSVImportTool()
        {
            InitializeComponent();
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            fileName = "";
            safeFileName = "";
            content = "";
            contentBase64 = "";

            int size = -1;
            DialogResult result = ofdOpenFile.ShowDialog();
            if (result == DialogResult.OK)
            {
                fileName = ofdOpenFile.FileName;
                safeFileName = ofdOpenFile.SafeFileName;

                try
                {
                    content = File.ReadAllText(fileName);

                    var contentBytes = Encoding.UTF8.GetBytes(content);
                    contentBase64 = Convert.ToBase64String(contentBytes);

                    size = content.Length;
                }
                catch (IOException)
                {
                }
            }

            txtFileName.Text = safeFileName;
        }

        private void CSVImportTool_Load(object sender, EventArgs e)
        {

        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            netsuiteFileSave netsuiteFile = new netsuiteFileSave();

            netsuiteFile.name = safeFileName;
            netsuiteFile.folderId = txtFolderId.Text;
            netsuiteFile.fileType = "CSV";
            netsuiteFile.content = contentBase64;

            if(netsuiteFile.name != "" && txtCSVImportId.Text != "" && txtFolderId.Text != "")
            {
                netsuiteFile savedNetsuiteFile = new netsuiteFile();

                savedNetsuiteFile = netsuiteClient.saveFile(netsuiteFile);

                netsuiteCSVImportJob netsuiteCSVImportJob = new netsuiteCSVImportJob();
                netsuiteCSVImportJob.internalId = savedNetsuiteFile.internalId;
                netsuiteCSVImportJob.csvImportId = txtCSVImportId.Text;
                netsuiteCSVImportJob.queue = txtQueue.Text;

                netsuiteClient.importCSVFile(netsuiteCSVImportJob);
                netsuiteClient.deleteFile(savedNetsuiteFile);
            }
            else
            {
                MessageBox.Show("Please choose a file and specify a CSV Import ID and Folder ID before uploading.");
            }
        }
    }
}
