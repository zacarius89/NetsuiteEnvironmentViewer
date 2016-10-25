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
        public netsuiteCustomScriptFile scriptFile { get; set; }
        public netsuiteCustomScriptFunction[] scriptFunctions { get; set; }
        public netsuiteCustomScriptDeployment[] scriptDeployments { get; set; }
    }

    public class netsuiteCustomScriptFunction
    {
        public string functionType { get; set;}
        public string function { get; set; }
    }

    public class netsuiteCustomScriptFile
    {
        public string internalId { get; set; }
        public string name { get; set; }
        public string folder { get; set; }
        public string type { get; set; }
        public string size { get; set; }
        public string content { get; set; }
    }

    public partial class netsuiteCustomScriptFileSave : netsuiteCustomScriptFile
    {
        public string method = "saveCustomScriptFile";
    }

    public class netsuiteCustomScriptDeployment
    {
        public string internalId { get; set; }
        public string scriptDeploymentId { get; set; }
        public string isDeployed { get; set; }
        public string recordType { get; set; }
        public string status { get; set; }
    }

    public class netsuiteClient
    {
        private string netsuiteAuthorization;
        private string querySchemaUrl = "/app/site/hosting/restlet.nl?script=customscript_queryschema&deploy=customdeploy_queryschema";

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

        public string saveCustomScriptFileContents(netsuiteCustomScriptFile netsuiteCustomScriptFile1, netsuiteCustomScriptFile netsuiteCustomScriptFile2)
        {
            netsuiteCustomScriptFileSave customScriptFile = new netsuiteCustomScriptFileSave();

            customScriptFile.internalId = netsuiteCustomScriptFile2.internalId;
            customScriptFile.name = netsuiteCustomScriptFile1.name;
            customScriptFile.content = netsuiteCustomScriptFile1.content;

            string payload = JsonConvert.SerializeObject(customScriptFile);

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
