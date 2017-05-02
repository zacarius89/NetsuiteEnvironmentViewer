using System;
using System.IO;
using System.Text;
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
            netsuiteFolderSave netsuiteFolder = new netsuiteFolderSave();
            netsuiteFolder.name = "NetsuiteEnvironmentViewer Temp Folder - " + DateTime.Now.ToString();

            netsuiteFileSave netsuiteFile = new netsuiteFileSave();

            netsuiteFile.name = safeFileName;
            netsuiteFile.fileType = "CSV";
            netsuiteFile.content = contentBase64;

            if(netsuiteFile.name != "" && txtCSVImportId.Text != "")
            {
                netsuiteFolder savedNetsuiteFolder = new netsuiteFolder();
                netsuiteFile savedNetsuiteFile = new netsuiteFile();

                savedNetsuiteFolder = netsuiteClient.saveFolder(netsuiteFolder);
                netsuiteFile.folderId = savedNetsuiteFolder.internalId;

                savedNetsuiteFile = netsuiteClient.saveFile(netsuiteFile);

                netsuiteCSVImportJob netsuiteCSVImportJob = new netsuiteCSVImportJob();
                netsuiteCSVImportJob.internalId = savedNetsuiteFile.internalId;
                netsuiteCSVImportJob.csvImportId = txtCSVImportId.Text;
                netsuiteCSVImportJob.queue = txtQueue.Text;

                netsuiteClient.importCSVFile(netsuiteCSVImportJob);
                netsuiteClient.deleteFile(savedNetsuiteFile);
                netsuiteClient.deleteFolder(savedNetsuiteFolder);

                MessageBox.Show("Upload Complete!");
            }
            else
            {
                MessageBox.Show("Please choose a file and specify a CSV Import ID before uploading.");
            }
        }
    }
}
