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