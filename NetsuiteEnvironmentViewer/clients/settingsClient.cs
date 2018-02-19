using System;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.Security.Cryptography;
using System.Collections.Generic;

namespace NetsuiteEnvironmentViewer
{
	public class Settings
	{
		public bool useSameCredentialsChecked = true;
		public bool recordsChecked = true;
		public bool scriptsChecked = true;
		public bool onlyCustomFieldsChecked = true;

		public string environment1Url = "https://rest.netsuite.com";
		public string environment1Account = string.Empty;
        public string environment1Suffix = string.Empty;
        public string environment1Email = string.Empty;
		public string environment1Signature = string.Empty;
		public string environment1Role = "3";

		public string environment2Url = "https://rest.netsuite.com";
		public string environment2Account = string.Empty;
        public string environment2Suffix = "_SB1";
        public string environment2Email = string.Empty;
		public string environment2Signature = string.Empty;
		public string environment2Role = "3";

		public List<IgnoredScript> environment1IgnoreScripts = new List<IgnoredScript>();
		public List<IgnoredScript> environment2IgnoreScripts = new List<IgnoredScript>();
	}

	public class IgnoredScript
	{
		public string internalId = string.Empty;
		public string fileName = string.Empty;
	}

	public class SettingsClient
	{
		private string directoryPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\NetsuiteEnvironmentViewer\\";
		private string filePath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\NetsuiteEnvironmentViewer\\system.settings";

		public Settings loadSettings()
		{
			Settings localSettings = new Settings();

			if (!Directory.Exists(directoryPath))
			{
				Directory.CreateDirectory(directoryPath);
			}

			if (!File.Exists(filePath))
			{
				saveSettings(localSettings);
			}

			string decryptedSettings = decrypt(File.ReadAllText(filePath));

			localSettings = JsonConvert.DeserializeObject<Settings>(decryptedSettings);

			return localSettings;
		}

		public void saveSettings(Settings localSettings)
		{
			string settings = JsonConvert.SerializeObject(localSettings);

			string encryptedSettings = encrypt(settings);

			File.WriteAllText(filePath, encryptedSettings);
		}

		//https://dotnetcodr.com/2015/10/23/encrypt-and-decrypt-plain-string-with-triple-des-in-c/
		public string encrypt(string text)
		{
			string key = getCurrentMacAddress();

			TripleDESCryptoServiceProvider desCryptoProvider = new TripleDESCryptoServiceProvider();
			MD5CryptoServiceProvider hashMD5Provider = new MD5CryptoServiceProvider();

			byte[] byteHash;
			byte[] byteBuff;

			byteHash = hashMD5Provider.ComputeHash(Encoding.UTF8.GetBytes(key));
			desCryptoProvider.Key = byteHash;
			desCryptoProvider.Mode = CipherMode.ECB; //CBC, CFB
			byteBuff = Encoding.UTF8.GetBytes(text);

			string encryptedText = Convert.ToBase64String(desCryptoProvider.CreateEncryptor().TransformFinalBlock(byteBuff, 0, byteBuff.Length));

			return encryptedText;
		}

		public string decrypt(string encryptedText)
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
