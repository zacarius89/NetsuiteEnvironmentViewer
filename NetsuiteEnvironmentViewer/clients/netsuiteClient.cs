using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace NetsuiteEnvironmentViewer
{
    public class netsuiteCustomRecords
    {
        public netsuiteCustomRecord[] customRecords { get; set; }
    }

    public class netsuiteCustomRecord
    {
        public string internalId { get; set; }
        public string recordId { get; set; }
        public string recordName { get; set; }
        public string[] recordFields { get; set; }
    }

    public class netsuiteCustomScripts
    {
        public netsuiteCustomScript[] customScripts { get; set; }
    }

    public class netsuiteCustomScript
    {
        public string internalId { get; set; }
        public string scriptId { get; set; }
        public string scriptName { get; set; }
        public string scriptType { get; set; }
        public string scriptAPIVersion { get; set; }
        public netsuiteFile scriptFile { get; set; }
        public netsuiteCustomScriptFunction[] scriptFunctions { get; set; }
        public netsuiteCustomScriptDeployment[] scriptDeployments { get; set; }
    }

    public class netsuiteCustomScriptFunction
    {
        public string functionType { get; set;}
        public string function { get; set; }
    }

    public class netsuiteFile
    {
        public string internalId { get; set; }
        public string name { get; set; }
        public string folderId { get; set; }
        public string fileType { get; set; }
        public string size { get; set; }
        public string content { get; set; }
    }

    public partial class netsuiteCustomScriptFileSave : netsuiteFile
    {
        public string method = "saveCustomScriptFile";
    }

    public partial class netsuiteFileSave : netsuiteFile
    {
        public string method = "saveFile";
    }

    public partial class netsuiteFileDelete : netsuiteFile
    {
        public string method = "deleteFile";
    }

    public class netsuiteFolder
    {
        public string internalId { get; set; }
        public string name { get; set; }
        public string parentFolderInternalId { get; set; }
    }

    public partial class netsuiteFolderSave : netsuiteFolder
    {
        public string method = "saveFolder";
    }

    public partial class netsuiteFolderDelete : netsuiteFolder
    {
        public string method = "deleteFolder";
    }

    public class netsuiteCustomScriptDeployment
    {
        public string internalId { get; set; }
        public string scriptDeploymentId { get; set; }
        public string isDeployed { get; set; }
        public string recordType { get; set; }
        public string status { get; set; }
    }

    public class netsuiteCSVImportJob
    {
        public string method = "importCSVFile";
        public string internalId { get; set; }
        public string csvImportId { get; set; }
        public string queue { get; set; }
    }

    public class netsuiteClient
    {
        private string netsuiteAuthorization;
        private string querySchemaUrl = "/app/site/hosting/restlet.nl?script=customscript_commonnetsuitefunctions&deploy=customdeploy_commonnetsuitefunctions";

        public netsuiteClient(string url, string account, string email, string signature, string role)
        {
            netsuiteAuthorization = "NLAuth nlauth_account = " + account +
                ", nlauth_email = " + email +
                ", nlauth_signature = " + signature +
                ", nlauth_role = " + role;

            querySchemaUrl = url + querySchemaUrl;
        }

        public netsuiteCustomRecords getCustomRecords()
        {
            //string payload = "{\"method\":\"getCustomRecords\", \"includeAll\":\"T\", \"internalId\":\"180\"}";
            string payload = "{\"method\":\"getCustomRecords\", \"includeAll\":\"T\"}";
            string result = restPOSTCall(querySchemaUrl, payload, netsuiteAuthorization);
            return JsonConvert.DeserializeObject<netsuiteCustomRecords>(result);
        }

        public netsuiteCustomScripts getCustomScripts()
        {
            //string payload = "{\"method\":\"getCustomScripts\", \"includeAll\":\"T\", \"internalId\":\"47\"}";
            string payload = "{\"method\":\"getCustomScripts\", \"includeAll\":\"T\"}";
            string result = restPOSTCall(querySchemaUrl, payload, netsuiteAuthorization);
            return JsonConvert.DeserializeObject<netsuiteCustomScripts>(result);
        }

        public netsuiteFile getCustomScriptFile(string internalId)
        {
            //string payload = "{\"method\":\"getCustomScripts\", \"includeAll\":\"T\", \"internalId\":\"47\"}";
            string payload = "{\"method\":\"getFile\", \"internalId\":\"" + internalId + "\"}";
            string result = restPOSTCall(querySchemaUrl, payload, netsuiteAuthorization);
            return JsonConvert.DeserializeObject<netsuiteFile>(result);
        }

        public string saveCustomScriptFileContents(netsuiteFile netsuiteCustomScriptFile1, netsuiteFile netsuiteCustomScriptFile2)
        {
            netsuiteCustomScriptFileSave customScriptFile = new netsuiteCustomScriptFileSave();

            customScriptFile.internalId = netsuiteCustomScriptFile2.internalId;
            customScriptFile.name = netsuiteCustomScriptFile1.name;
            customScriptFile.content = netsuiteCustomScriptFile1.content;

            string payload = JsonConvert.SerializeObject(customScriptFile);

            return restPOSTCall(querySchemaUrl, payload, netsuiteAuthorization);
        }

        public netsuiteFile saveFile(netsuiteFileSave netsuiteFile)
        {
            string payload = JsonConvert.SerializeObject(netsuiteFile);

            return JsonConvert.DeserializeObject<netsuiteFile>(restPOSTCall(querySchemaUrl, payload, netsuiteAuthorization));
        }

        public string deleteFile(netsuiteFile netsuiteFile)
        {
            netsuiteFileDelete netsuiteFileToDelete = new netsuiteFileDelete();
            netsuiteFileToDelete.internalId = netsuiteFile.internalId;

            string payload = JsonConvert.SerializeObject(netsuiteFileToDelete);
        
            return restPOSTCall(querySchemaUrl, payload, netsuiteAuthorization);
        }

        public netsuiteFolder saveFolder(netsuiteFolderSave netsuiteFolder)
        {
            string payload = JsonConvert.SerializeObject(netsuiteFolder);

            return JsonConvert.DeserializeObject<netsuiteFolder>(restPOSTCall(querySchemaUrl, payload, netsuiteAuthorization));
        }

        public string deleteFolder(netsuiteFolder netsuiteFolder)
        {
            netsuiteFolderDelete netsuiteFolderToDelete = new netsuiteFolderDelete();
            netsuiteFolderToDelete.internalId = netsuiteFolder.internalId;

            string payload = JsonConvert.SerializeObject(netsuiteFolderToDelete);

            return restPOSTCall(querySchemaUrl, payload, netsuiteAuthorization);
        }

        public string importCSVFile(netsuiteCSVImportJob netsuiteCSVImportJob)
        {
            string payload = JsonConvert.SerializeObject(netsuiteCSVImportJob);

            return restPOSTCall(querySchemaUrl, payload, netsuiteAuthorization);
        }

        private string restPOSTCall(string url, string payload, string netsuiteAuthorization)
        {
            string result = "";

            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);

            httpWebRequest.Method = "POST";
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Headers.Add("Authorization", netsuiteAuthorization);

            using (StreamWriter streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(payload);
                streamWriter.Flush();
                streamWriter.Close();
            }

            HttpWebResponse httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            using (StreamReader streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
            }

            return result;
        }
    }
}
