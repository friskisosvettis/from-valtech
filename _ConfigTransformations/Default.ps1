#
# This is script is used for deployment of Habitat environment - is will transform, rename, replace, remove files
#


param (
	[string]$type = "local",
	[string]$search="solr",
  [string]$computername = "",
  [string]$websiteName = "",
  [string]$webRootPath = "")
 

  try{

  
 Set-Location -Path "$PSScriptRoot" -PassThru
 Write-Host "Script path is set to $(Get-Location)"
 
 #Include common functions
 . .\Common.ps1
 . .\ChangeToSolrSearch.ps1 

 
 #Init 
 Initialize
	Write-Host "search = " $search
	Write-Host "webRootPath = " $webRootPath

   if($type -eq 'local' -and $computername -eq "")
    {
        $computername = $env:computername
    } 

    if($computername -eq "" -or $type -eq "" -or ($websiteName -eq "" -and $webRootPath -eq "")){
      Write-Error "Missing Params, please ensure that we have computername, type and either websiteName or webrootpath"
      Write-Host "Type = $type"
      Write-Host "Computername = $computername"
       Write-Host "WebsiteName = $websiteName"
       Write-Host "WebRootPath = $webRootPath"
      exit
    }

    if ($webRootPath -eq "")
    {
       #Get webroot path from IIS
       $webRootPath = (Get-Website $websiteName).physicalPath 
    }

  #Set variables for easy access.
 $configFolder = join-path $webRootPath "_ConfigTransformations"

 #Global folder
 $globalFolder = (join-path $configFolder "_GLOBAL")
 #Environment folder
 $environmentFolder = join-path $configFolder (join-path $type "_ENVIRONMENT")
 #Server folder
 $serverFolder = join-path $configFolder (join-path $type $computername)

    
Write-Host "" 
Write-Host "******* Executing with these settings ********"
Write-Host "" 
Write-Host "PSCommandPath = " $PSCommandPath 
Write-Host "Type = " $type
Write-Host "ComputerName = " $computername
Write-Host "websiteName = " $websiteName
Write-Host "WebrootPath = " $webRootPath
Write-Host "ConfigFolder = " $configFolder
Write-Host "GlobalFolder = " $globalFolder
Write-Host "EnvironmentFolder = " $environmentFolder
Write-Host "ServerFolder = " $serverfolder
Write-Host "Search = " $search
Write-Host "" 
Write-Host "**********************************************"
Write-Host ""
 
 
 #Transform in Global folder
 GetFoldersAndTransform -folder $globalFolder -webRootPath $webRootPath

 #Transform in Environment folder
 GetFoldersAndTransform -folder $environmentFolder -webRootPath $webRootPath

 #Transform in Server folder
 GetFoldersAndTransform -folder $serverFolder -webRootPath $webRootPath
    
 if($search -eq 'solr')
 {
 	ActivateSolrConfigFiles -webRootPath $webRootPath
 	DeActivateLuceneConfigFiles -webRootPath $webRootPath
	UpdateGlobalAsax -webRootPath $webRootPath
 } 
	
 }Catch{
      Write-Host ""
      Write-Host "*** ALERT ******* ALERT ******* ALERT ******* ALERT ****"
      Write-Host ""
      Write-Error $_.Exception
      Write-Host ""
      Write-Host "*** ALERT ******* ALERT ******* ALERT ******* ALERT ****"
      Write-Host ""
      break
    }