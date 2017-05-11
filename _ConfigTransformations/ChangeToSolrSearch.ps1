function ActivateConfigureFile{
	param([string]$FileName)
	
	$newFileName = ""
	if($FileName.EndsWith(".config"))
	{
		Write-Host "Allready Active" $FileName
	}
	elseif ($FileName.EndsWith(".disabled"))
	{
		$newFileName = $FileName.Replace(".disabled","")
		Rename-Item $FileName $newFileName
		Write-Host $FileName "=>"
		Write-Host "====>" $newFileName
	}
	elseif ($FileName.EndsWith(".example"))
	{
		$newFileName = $FileName.Replace(".example","")
		Rename-Item $FileName $newFileName
		Write-Host $FileName "=>"
		Write-Host "====>" $newFileName
	}	
 }
 
 function DeActivateConfigureFile{
	param([string]$FileName)
	
	if($FileName.EndsWith(".config"))
	{
		$newFileName = $FileName.Replace(".config",".config.disabled")
		Rename-Item $FileName $newFileName
		Write-Host $FileName "=>"
		Write-Host "====>" $newFileName
	}
	else
	{
		Write-Host "Allready DeActived" $FileName
	}
 }

function ActivateSolrConfigFiles{
	param([string]$webRootPath)
	
	Write-Host "ActivateSolrConfigFiles WebRoot:" $webRootPath
	if($webRootPath -eq ""){
		exit
	}
	
	$configFileListSolr = Get-ChildItem -Path $webRootPath -Recurse -Include *.Solr.*config*
	foreach ($config in $configFileListSolr)
	{
		ActivateConfigureFile $config
	}
}

function DeActivateSolrMasterConfigFiles{
	param([string]$webRootPath)
	
	Write-Host "DeActivateLuceneConfigFiles WebRoot:" $webRootPath
	if($webRootPath -eq ""){
		exit
	}
	
	$configFileListSolrMaster = Get-ChildItem -Path $webRootPath -Recurse -Include *.Solr.*.Master*config

	foreach ($config in $configFileListSolrMaster)
	{
		DeActivateConfigureFile $config
	}
	
	# List of others Solr configs that does not need to be on CD
	$ContentTestingSolr = join-path $webRootPath "App_Config/Include/ContentTesting/Sitecore.ContentTesting.Solr.IndexConfiguration.config"
	$ListManagerIndexListSolr = join-path $webRootPath "App_Config/Include/ListManagement/Sitecore.ListManagement.Solr.Index.List.config"
	$ListManagerIndexConfigurationSolr = join-path $webRootPath "App_Config/Include/ListManagement/Sitecore.ListManagement.Solr.IndexConfiguration.config"
	
	DeActivateConfigureFile $ContentTestingSolr
	DeActivateConfigureFile $ListManagerIndexListSolr
	DeActivateConfigureFile $ListManagerIndexConfigurationSolr
}
 
function DeActivateLuceneConfigFiles{
	param([string]$webRootPath)
	
	Write-Host "DeActivateLuceneConfigFiles WebRoot:" $webRootPath
	if($webRootPath -eq ""){
		exit
	}
	
	$configFileListLucene = Get-ChildItem -Path $webRootPath -Recurse -Include *.Lucene*.config*
	foreach ($config in $configFileListLucene)
	{
		DeActivateConfigureFile $config
	}
}

function UpdateGlobalAsax {
	param([string]$webRootPath)
	
	$globalFilePath = join-path $webRootPath "Global.asax"
	(Get-Content $globalFilePath).Replace("Sitecore.Web.Application","Sitecore.ContentSearch.SolrProvider.CastleWindsorIntegration.WindsorApplication") | Set-Content $globalFilePath 
}

