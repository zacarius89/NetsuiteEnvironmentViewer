(function (){
	var _global = this;

	var querySchema = {};
	
	querySchema.postRESTlet = function(datain)
	{
		var returnJSON = {};
		
		if(!datain.includeAll)
		{
			datain.includeAll = 'F';
		}
		
		if(!datain.internalId)
		{
			datain.internalId = null;
		}
		
		if(!datain.parentFolderInternalId)
		{
			datain.parentFolderInternalId = '@NONE@';
		}
		
		if(datain.method == 'getCustomRecords')
		{
			returnJSON = querySchema.getCustomRecords(datain.internalId, datain.includeAll);
		}
		else if(datain.method == 'getCustomScripts')
		{
			returnJSON = querySchema.getCustomScripts(datain.internalId, datain.includeAll);
		}
		else if(datain.method == 'saveCustomScriptFile')
		{
			returnJSON = querySchema.saveCustomScriptFile(datain.name, datain.content);
		}
		else if(datain.method == 'getFile')
		{
			returnJSON = querySchema.getFile(datain.internalId);
		}
		else if(datain.method == 'saveFile')
		{
			returnJSON = querySchema.saveFile(datain.name, datain.fileType, datain.content, datain.folderId);
		}
		else if(datain.method == 'getFolders')
		{
			returnJSON = querySchema.getFolders(datain.parentFolderInternalId);
		}
		
		return returnJSON;
	};
	
	querySchema.getCustomRecords = function(internalId, includeAll)
	{
		try
		{
			var filters = new Array();
			
			if(internalId)
			{
				filters[0] = new nlobjSearchFilter('internalid', null, 'anyof', internalId)
			}

			var columns = new Array();
			columns[0] = new nlobjSearchColumn('internalid');
			columns[1] = new nlobjSearchColumn('scriptid');
			columns[2] = new nlobjSearchColumn('name');

			var results = nlapiSearchRecord('customrecordtype', null, filters, columns);
			
			var customRecords = [];

			if (results && results.length > 0)
			{
				for(i = 0; i < results.length; i++)
				{
					var customRecord = {};
					
					var internalId = results[i].getValue('internalid');
					var recordId = results[i].getValue('scriptid');
					var recordName = results[i].getValue('name');
					var recordFields;
					
					if(includeAll == 'T')
					{
						recordFields = querySchema.getCustomRecordFields(recordId, includeAll)
					}
					
					customRecord.internalId = internalId;
					customRecord.recordId = recordId;
					customRecord.recordName = recordName;
					
					if(recordFields)
					{
						customRecord.recordFields = recordFields;
					}
					
					customRecords.push(customRecord);
				}
			}
			
			return {'customRecords': customRecords};
		}
		catch (e)
		{
			nlapiLogExecution('ERROR', 'querySchema.getCustomRecords', e.message);
			
			return e.message;
		};
	};
	
	querySchema.getCustomRecordFields = function(recordId, includeAll)
	{
		try
		{
			var customRecord = nlapiCreateRecord(recordId);
			
			var customRecordFields = customRecord.getAllFields();
			
			return customRecordFields;
		}
		catch (e)
		{
			nlapiLogExecution('ERROR', 'querySchema.getCustomRecordFields', e.message);
		};
	};
	
	querySchema.getCustomScripts = function(internalId, includeAll)
	{
		try
		{
			var filters = new Array();
			
			if(internalId)
			{
				filters[0] = new nlobjSearchFilter('internalid', null, 'anyof', internalId)
			}

			var columns = new Array();
			columns[0] = new nlobjSearchColumn('internalid');
			columns[1] = new nlobjSearchColumn('scriptid');
			columns[2] = new nlobjSearchColumn('name');
			columns[3] = new nlobjSearchColumn('scripttype');
			columns[4] = new nlobjSearchColumn('apiversion');
			columns[5] = new nlobjSearchColumn('scriptfile');
			
			var possibleScriptFunctionTypes = querySchema.getScriptFunctionTypes();
			
			for(i = 0; i < possibleScriptFunctionTypes.length; i++)
			{
				columns[i + 6] = new nlobjSearchColumn(possibleScriptFunctionTypes[i]);
			}

			var results = nlapiSearchRecord('script', null, filters, columns);
			
			var customScripts = [];
			
			if (results && results.length > 0)
			{
				for(i = 0; i < results.length; i++)
				{
					var customScript = {};
					
					var internalId = results[i].getValue('internalid');
					var scriptId = results[i].getValue('scriptid');
					var scriptName = results[i].getValue('name');
					var scriptType = results[i].getValue('scripttype');
					var scriptFileInternalId = results[i].getValue('scriptfile');
					var scriptAPIVersion = results[i].getValue('apiversion');
					
					var scriptFunctions = [];
					var scriptFile;
					var scriptDeployments;
					
					for(j = 0; j < possibleScriptFunctionTypes.length; j++)
					{
						var scriptFunction = {};
						
						scriptFunction.functionType = possibleScriptFunctionTypes[j];
						scriptFunction.function = results[i].getValue(possibleScriptFunctionTypes[j]);
						
						if(results[i].getValue(possibleScriptFunctionTypes[j]) != '')
						{
							scriptFunctions.push(scriptFunction);
						}
					}
					
					if(includeAll == 'T')
					{
						scriptFile = querySchema.getFile(scriptFileInternalId);
					}
					
					if(includeAll == 'T')
					{
						scriptDeployments = querySchema.getCustomScriptDeployments(internalId, includeAll)
					}
					
					customScript.internalId = internalId;
					customScript.scriptId = scriptId;
					customScript.scriptName = scriptName;
					customScript.scriptType = scriptType;
					customScript.scriptAPIVersion = scriptAPIVersion; 
					customScript.scriptFunctions = scriptFunctions;
					
					if(scriptFile)
					{
						customScript.scriptFile = scriptFile;
					}
					
					if(scriptDeployments)
					{
						customScript.scriptDeployments = scriptDeployments;
					}
					
					customScripts.push(customScript);
				}
			}
			
			return {'customScripts': customScripts};
		}
		catch (e)
		{
			nlapiLogExecution('ERROR', 'querySchema.getCustomScripts', e.message);
			
			return e.message;
		};
	}
	
	querySchema.getCustomScriptDeployments = function(scriptInternalId, includeAll)
	{
		try
		{
			var filters = new Array();
			
			filters[0] = new nlobjSearchFilter('script', null, 'anyof', scriptInternalId);

			var columns = new Array();
			columns[0] = new nlobjSearchColumn('internalid');
			columns[1] = new nlobjSearchColumn('scriptid');
			columns[2] = new nlobjSearchColumn('isdeployed');
			columns[3] = new nlobjSearchColumn('recordtype');
			columns[4] = new nlobjSearchColumn('status');

			var results = nlapiSearchRecord('scriptdeployment', null, filters, columns);
			
			var customScriptDeployments = [];
			
			if (results && results.length > 0)
			{
				for(j = 0; j < results.length; j++)
				{
					var customScriptDeployment = {};
					
					var internalId = results[j].getValue('internalid');
					var scriptDeploymentId = results[j].getValue('scriptid');
					var isDeployed = results[j].getValue('isdeployed');
					var scriptDeploymentRecordType = results[j].getValue('recordtype');
					var scriptDeploymentStatus = results[j].getValue('status');
					
					customScriptDeployment.internalId = internalId;
					customScriptDeployment.scriptDeploymentId = scriptDeploymentId;
					customScriptDeployment.isDeployed = isDeployed;
					customScriptDeployment.recordType = scriptDeploymentRecordType;
					customScriptDeployment.status = scriptDeploymentStatus;
	
					customScriptDeployments.push(customScriptDeployment);
				}
			}
			
			return customScriptDeployments;
		}
		catch (e)
		{
			nlapiLogExecution('ERROR', 'querySchema.getCustomScriptDeployments', e.message);
			
			return e.message;
		};
	};
	
	querySchema.saveCustomScriptFile = function(name, content)
	{
		try
		{			
			
			return querySchema.saveFile(name, 'JAVASCRIPT', content, '-15');
		}
		catch (e)
		{
			nlapiLogExecution('ERROR', 'querySchema.saveCustomScriptFile', e.message);
			
			return e.message;
		};
	};
	
	querySchema.getFile = function(internalId)
	{
		try
		{
			var filters = new Array();
			
			filters[0] = new nlobjSearchFilter('internalid', null, 'anyof', internalId)

			var columns = new Array();
			columns[0] = new nlobjSearchColumn('internalid');
			columns[1] = new nlobjSearchColumn('name');
			
			var results = nlapiSearchRecord('file', null, filters, columns);
			
			var customScriptFile = {};
			
			if (results && results.length > 0)
			{
				customScriptFile.internalId = results[0].getValue('internalid');
				customScriptFile.name = results[0].getValue('name');
				
				nlapiLogExecution('DEBUG', 'querySchema.getFile', customScriptFile.internalId);
				
				var customScriptFileRecord = nlapiLoadFile(customScriptFile.internalId);
				
				customScriptFile.folder = customScriptFileRecord.getFolder();
				customScriptFile.type = customScriptFileRecord.getType();
				customScriptFile.size = customScriptFileRecord.getSize();
				customScriptFile.content = nlapiEncrypt(customScriptFileRecord.getValue(), 'base64');
			}
			
			return customScriptFile;
		}
		catch (e)
		{
			nlapiLogExecution('ERROR', 'querySchema.getFile', e.message);
			
			//Check to see if the user does not have permission for the script
			//Most likely, this error comes from an installed bundle
			if(e.message = 'You do not have access to the media item you selected.')
			{
				return {'content': e.message};
			}
			
			return e.message;
		};
	};
	
	querySchema.saveFile = function(name, fileType, content, folderId)
	{
		try
		{
			content = nlapiDecrypt(content, 'base64');
			
			var file = nlapiCreateFile(name, fileType, content);
			file.setFolder(folderId);
			
			var fileId = nlapiSubmitFile(file);
			
			return querySchema.getFile(fileId);
		}
		catch (e)
		{
			nlapiLogExecution('ERROR', 'querySchema.saveFile', e.message);
			
			return e.message;
		};
	};
	
	querySchema.getFolders = function(parentFolderInternalId)
	{
		nlapiLogExecution('DEBUG', 'querySchema.getFolders');
		
		try
		{	
			var filters = new Array();
			filters[0] = new nlobjSearchFilter('parent', null, 'anyof', parentFolderInternalId);

			var columns = new Array();
			columns[0] = new nlobjSearchColumn('internalid');
			columns[1] = new nlobjSearchColumn('name');
			columns[2] = new nlobjSearchColumn('parent');
			columns[3] = new nlobjSearchColumn('numfiles');
			columns[4] = new nlobjSearchColumn('foldersize');

			var results = nlapiSearchRecord('folder', null, filters, columns);
			
			var folders = [];

			if (results && results.length > 0)
			{
				for(i = 0; i < results.length; i++)
				{
					var folder = {};
					
					var internalId = results[i].getValue('internalid');
					var folderName = results[i].getValue('name');
					var parentFolderInternalId = results[i].getValue('parent');
					var parentFolderName = results[i].getText('parent');
					var numberOfFiles = results[i].getValue('numfiles');
					var folderSize = results[i].getValue('foldersize');
					
					folder.internalId = internalId;
					folder.name = folderName;
					folder.parentFolder = {'internalId': parentFolderInternalId, 'name': parentFolderName};
					folder.numberOfFiles = numberOfFiles;
					folder.size = folderSize;
					
					folders.push(folder);
				}
			}
			
			return {'folders': folders};
		}
		catch (e)
		{
			nlapiLogExecution('ERROR', 'querySchema.getFolders', e.message);
			
			return e.message;
		};
	};
	
	querySchema.getScriptFunctionTypes = function()
	{
		var scriptFunctions =
		[
			'afterinstallfunction',
			'aftersubmitfunction',
			'afterupdatefunction',
			'beforeinstallfunction',
			'beforeloadfunction',
			'beforesubmitfunction',
			'beforeuninstallfunction',
			'beforeupdatefunction',
			'deletefunction',
			'defaultfunction',
			'fieldchangedfunction',
			'getfunction',
			'lineinitfunction',
			'postfunction',
			'putfunction',
			'pageinitfunction',
			'postsourcingfunction',
			'recalcfunction',
			'saverecordfunction',
			'validatedeletefunction',
			'validatefieldfunction',
			'validateinsertfunction',
			'validatelinefunction'
		];
		
		return scriptFunctions;
	};
	
	_global.querySchema = querySchema;
	
}).call(this);