# NetsuiteEnvironmentViewer
Application to view and compare records and scripts between Netsuite environments
https://s3.amazonaws.com/netsuite-environment-viewer/app/setup.exe

For application to be used, users will have to deploy the SuiteScript, suiteScripts/commonNetSuiteFunctions.js, into the desired Netsuite environments.

It should be deployed as a RESTlet.

The **scriptId** should be _customscript\_commonnetsuitefunctions_, and the **deployId** should be _customdeploy\_commonnetsuitefunctions_.

The application can also save settings to the user's local computer, if you choose.
