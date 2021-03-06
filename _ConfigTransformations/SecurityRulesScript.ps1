. .\ConfigFileActivationSwitch.ps1

function DisableAdministrativTools{
	param([string]$webRootPath)
	$adminPath = join-path $webRootPath "\sitecore\admin\"
	DeActivateAspxFile (join-path $adminPath "cache.aspx")
	DeActivateAspxFile (join-path $adminPath "dbbrowser.aspx")
	DeActivateAspxFile (join-path $adminPath "DBCleanup.aspx")
	DeActivateAspxFile (join-path $adminPath "ShowServicesConfig.aspx")
	DeActivateAspxFile (join-path $adminPath "eventqueuestats.aspx")
	DeActivateAspxFile (join-path $adminPath "FillDB.aspx")
	DeActivateAspxFile (join-path $adminPath "InstallLanguage.aspx")
	DeActivateAspxFile (join-path $adminPath "Jobs.aspx")
	DeActivateAspxFile (join-path $adminPath "LinqScratchPad.aspx")
	DeActivateAspxFile (join-path $adminPath "Logs.aspx")
	DeActivateAspxFile (join-path $adminPath "MediaHash.aspx")
	DeActivateAspxFile (join-path $adminPath "PackageItem.aspx")
	DeActivateAspxFile (join-path $adminPath "PathAnalyzer.aspx")
	DeActivateAspxFile (join-path $adminPath "Pipelines.aspx")
	DeActivateAspxFile (join-path $adminPath "PublishQueueStats.aspx")
	DeActivateAspxFile (join-path $adminPath "RawSearch.aspx")
	DeActivateAspxFile (join-path $adminPath "RebuildKeyBehaviorCache.aspx")
	DeActivateAspxFile (join-path $adminPath "RebuildReportingDB.aspx")
	DeActivateAspxFile (join-path $adminPath "RedeployMarketingData.aspx")
	DeActivateAspxFile (join-path $adminPath "RemoveBrokenLinks.aspx")
	DeActivateAspxFile (join-path $adminPath "restore.aspx")
	DeActivateAspxFile (join-path $adminPath "SecurityTools.aspx")
	DeActivateAspxFile (join-path $adminPath "serialization.aspx")
	DeActivateAspxFile (join-path $adminPath "SetSACEndpoint.aspx")
	DeActivateAspxFile (join-path $adminPath "ShowConfig.aspx")
	DeActivateAspxFile (join-path $adminPath "SqlShell.aspx")
	DeActivateAspxFile (join-path $adminPath "stats.aspx")
	DeActivateAspxFile (join-path $adminPath "unlock_admin.aspx")
}

function DisableWebDav{
	param([string]$webRootPath)
	DeActivateConfigureFile (join-path $webRootPath "\App_Config\Include\Sitecore.WebDAV.config")
}