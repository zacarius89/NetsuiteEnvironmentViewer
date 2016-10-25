using System;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.Security.Cryptography;

namespace NetsuiteEnvironmentViewer
{
    public class settings
    {
        public bool useSameCredentialsChecked = true;
        public bool customRecordsChecked = true;
        public bool customScriptsChecked = true;

        public string environment1Url = "https://rest.netsuite.com";
        public string environment1Account = "";
        public string environment1Email = "";
        public string environment1Signature = "";
        public string environment1Role = "3";

        public string environment2Url = "https://rest.sandbox.netsuite.com";
        public string environment2Account = "";
        public string environment2Email = "";
        public string environment2Signature = "";
        public string environment2Role = "3";
    }

    public class settingsClient
    {
        private string directoryPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\NetsuiteEnvironmentViewer\\";
        private string filePath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\NetsuiteEnvironmentViewer\\system.settings";

        public settings loadSettings()
        {
            settings localSettings = new settings();

            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            if(!File.Exists(filePath))
            {
                saveSettings(localSettings);
            }

            string decryptedSettings = decrypt(File.ReadAllText(filePath));

            localSettings = JsonConvert.DeserializeObject<settings>(decryptedSettings);

            return localSettings;
        }

        public void saveSettings(settings localSettings)
        {
            string settings = JsonConvert.SerializeObject(localSettings);

            string encryptedSettings = encrypt(settings);

            File.WriteAllText(filePath, encryptedSettings);
        }

        //https://dotnetcodr.com/2015/10/23/encrypt-and-decrypt-plain-string-with-triple-des-in-c/
        private string encrypt(string source)
        {
            string key = getCurrentMacAddress();

            TripleDESCryptoServiceProvider desCryptoProvider = new TripleDESCryptoServiceProvider();
            MD5CryptoServiceProvider hashMD5Provider = new MD5CryptoServiceProvider();

            byte[] byteHash;
            byte[] byteBuff;

            byteHash = hashMD5Provider.ComputeHash(Encoding.UTF8.GetBytes(key));
            desCryptoProvider.Key = byteHash;
            desCryptoProvider.Mode = CipherMode.ECB; //CBC, CFB
            byteBuff = Encoding.UTF8.GetBytes(source);

            string encryptedText = Convert.ToBase64String(desCryptoProvider.CreateEncryptor().TransformFinalBlock(byteBuff, 0, byteBuff.Length));

            return encryptedText;
        }

        private string decrypt(string encryptedText)
        {
            string key = getCurrentMacAddress();

            TripleDESCryptoServiceProvider desCryptoProvider = new TripleDESCryptoServiceProvider();
            MD5CryptoServiceProvider hashMD5Provider = new MD5CryptoServiceProvider();

            byte[] byteHash;
            byte[] byteBuff;

            byteHash = hashMD5Provider.ComputeHash(Encoding.UTF8.GetBytes(key));
            desCryptoProvider.Key = byteHash;
            desCryptoProvider.Mode = CipherMode.ECB; //CBC, CFB
            byteBuff = Convert.FromBase64String(encryptedText);

            string decryptedText = Encoding.UTF8.GetString(desCryptoProvider.CreateDecryptor().TransformFinalBlock(byteBuff, 0, byteBuff.Length));

            return decryptedText;
        }

        //http://stackoverflow.com/questions/850650/reliable-method-to-get-machines-mac-address-in-c-sharp
        private string getCurrentMacAddress()
        {
            string allowedUrl = "www.google.com";

            TcpClient client = new TcpClient();
            client.Client.Connect(new IPEndPoint(Dns.GetHostAddresses(allowedUrl)[0], 80));

            while (!client.Connected)
            {
                Thread.Sleep(500);
            }

            IPAddress address2 = ((IPEndPoint)client.Client.LocalEndPoint).Address;
            client.Client.Disconnect(false);

            NetworkInterface[] allNetworkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
            client.Close();

            if (allNetworkInterfaces.Length > 0)
            {
                foreach (NetworkInterface interface2 in allNetworkInterfaces)
                {
                    UnicastIPAddressInformationCollection unicastAddresses = interface2.GetIPProperties().UnicastAddresses;

                    if ((unicastAddresses != null) && (unicastAddresses.Count > 0))
                    {
                        for (int i = 0; i < unicastAddresses.Count; i++)
                        {
                            if (unicastAddresses[i].Address.Equals(address2))
                            {
                                return interface2.GetPhysicalAddress().ToString();
                            }
                        }
                    }
                }
            }

            return "000000000000";
        }
    }
}
