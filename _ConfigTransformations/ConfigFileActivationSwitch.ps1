function RenameFile{
	param([string]$FileName
	     ,[string]$newFileName)
	
	if($newFileName | Test-Path)
	{
		Remove-Item -Path $newFileName -Force
		Write-Host "Deleting old file" $newFileName
	}
	
	Rename-Item $FileName $newFileName
	Write-Host $FileName "=>"
	Write-Host "====>" $newFileName
}

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
		RenameFile -FileName $FileName -newFileName $newFileName
	}
	elseif ($FileName.EndsWith(".example"))
	{
		$newFileName = $FileName.Replace(".example","")
		RenameFile -FileName $FileName -newFileName $newFileName
	}	
 }
 
 function DeActivateConfigureFile{
	param([string]$FileName)

	if($FileName.EndsWith(".config"))
	{
		$newFileName = $FileName.Replace(".config",".config.disabled")
		RenameFile -FileName $FileName -newFileName $newFileName
	}
	else
	{
		Write-Host "Allready DeActived" $FileName
	}
 }
 
 function ActivateAspxFile{
	param([string]$FileName)

	$newFileName = ""
	if($FileName.EndsWith(".aspx"))
	{
		Write-Host "Allready Active" $FileName
	}
	elseif ($FileName.EndsWith(".disabled"))
	{
		$newFileName = $FileName.Replace(".aspx.disabled",".aspx")
		RenameFile -FileName $FileName -newFileName $newFileName
	}	
 }
 
function DeActivateAspxFile{
	param([string]$FileName)

	if($FileName.EndsWith(".aspx"))
	{
		$newFileName = $FileName.Replace(".aspx",".aspx.disabled")
		RenameFile -FileName $FileName -newFileName $newFileName
	}
	else
	{
		Write-Host "Allready DeActived" $FileName
	}
 }