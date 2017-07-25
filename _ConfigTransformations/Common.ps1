# PowerShell common deployment functions for TradingFloor 4.0 / Sitecore 8.
#
# This script contains common functions, used by the main deployment and


#region Initialization, finalization and logging

	# Function to initialize (setup transcript, NLog and error handling).
	function Initialize {
    Write-Host "Initialize called"
    Initialize-WebAdministration
  }

  function GetFoldersAndTransform{
    param(
			[string]$folder,
    [string] $webRootPath)

    if(Test-Path $folder){
        TransformFilesInFolder -folder (join-path $folder "FOUNDATION") -webRootPath $webRootPath
        TransformFilesInFolder -folder (join-path $folder "FEATURE") -webRootPath $webRootPath
        TransformFilesInFolder -folder (join-path $folder "PROJECT") -webRootPath $webRootPath
		TransformFilesInFolder -folder (join-path $folder "SECURITY") -webRootPath $webRootPath
    }else{
      Write-Host "GetFoldersAndTransform - could not find folder "$folder
    }
  }

  function TransformFilesInFolder{
    param(
			[string]$folder, 
      [string]$webRootPath
   )

    
    if(Test-Path $folder){
          #Define filter
          $filter = @("*.xml")
          
          #Get child items
          $files = get-childitem  $folder -force -Include "*.xml" -Recurse
          
          if($files.count -eq 0){
              Write-Host "TransformFilesInFolder - No settings.xml files found in "$folder
          }

          #Loop through files
          foreach($file in $files){
           [xml]$xml = Get-Content $file
           Write-Host "TransformFilesInFolder - Executing file "$file
           ExecuteSettingFile -settings $xml -rootPath $webRootPath
           }
    }else{
      Write-Host "TransformFilesInFolder - Could not find folder "$folder
    }

  }

  function Replace-XmlItems {

		param(
			[string]$folder,
			$file,
			$targetFile = ""
		)
		
		if ($file.Item -ne $null) 
		{
			# Load web.config, preserving whitespace.
			$xml = new-object System.Xml.XmlDocument
			$xml.PreserveWhitespace = $true
			
			if ($targetFile -eq "")
			{
				$xml.Load("$($folder)$($file.name)")
			}
			else
			{
				$xml.Load($targetFile)
			}

			foreach($item in $file.Item)
			{
				if ($item.path -ne $null)
				{
					$node = $xml.SelectSingleNode($item.path)
          Write-Host $item.path
					#if ($node -eq $null) {
					#	Write-Host Error "Could not get node $($item.path) because it was not found in $($file.name)."
					#}

					if ($item.action -eq "Replace") {
						Write-Host Info "Replacing $($item.path) with value $($item.value)"
						[System.String]$val = $item.value
						if ($val.StartsWith("Powershell"))
						{
							$block = [scriptblock]::Create($val.SubString(11))
							$val = & $block
						}
            $node.Attributes.GetNamedItem($item.key).Value = $val
					}
					elseif ($item.action -eq "Remove") {
						Write-Host Info "Removing $($item.path)"
						$node.ParentNode.RemoveChild($node) | Out-Null
					}elseif($item.action -eq "InsertIfMissing"){
           
            $foundElement = $false
             #Write-Host Info "InsertIfMissing $($item.path)"
            if($node){
              $foundElement = $true
            }else{
				if ($item.rootPath){
					$parentPath = $item.rootPath
				}
				else{
					#replace // with / and convert to array
					$path = $item.path -replace '//','/' -split "/"
             
					#Find the parent path
					if($path.count -gt 1){
						$parentPath = $path[0..($path.Length-2)] -join '/'
					}else{
						$parentPath = "/"
					}
              }
            }

            [xml]$itemXml = $item.InnerXml
            
            #check if we found the element, if not, we will add it. 
             if($foundElement -eq $true){
               Write-Host "Found "$item.path" and will skip"
            }else{
              Write-Host "Did not find "$item.path" and will add it"

              $parentNode = $xml.SelectSingleNode($parentPath)
              
               if($parentNode){
                  Write-Host "Did find parentNode with path " $parentPath 
             
                  #Import the last node 
                  $importNode = $xml.ImportNode($itemXml.DocumentElement, $True)
                  $parentNode.AppendChild($importNode)

                }else{
                  Write-Host "Could not find parent node with path " $parentPath 
                }
            }

          }
				}
			}

			if ($targetFile -eq "")
			{
				Write-Host Info "Writing $($folder)$($file.name)"
				$xml.Save("$($folder)$($file.name)")
			}
			else
			{
				Write-Host Info "Writing $targetFile"
				$xml.Save($targetFile)
			}
		}
	}

	function ExecuteSettingFile {
	param(
		[xml]$settings,
		[string]$rootPath
	)

	# REPLACEFILE
	foreach($file in $settings.Deployment.Website.ReplaceFile.File)
	{
		try
		{
			$destination = "$rootPath\$($file.destination)"
			$source = $file.source
			Write-Host "Replacing config file: $($destination) with source file: $($source)"                
			Copy-Item $source $destination -Force
		}
		catch 
		{ 
			Write-Host Error "Could not replace file $($rootPath)\$($file.destination). Error: $($_.Exception.Message)"                
		}
	}


		# RENAME FILE
	if ($settings.Deployment.Website.RenameFiles.Item -ne $null)
	{
        foreach($file in $settings.Deployment.Website.RenameFiles.File)
	    {  
			try{
				$currentFile = join-path $rootPath $file.path;
        if(Test-Path $currentFile){
				Write-Host Info "Rename file '$($file.path)' to '$($file.name)'."
				Rename-Item $currentFile $($file.name) 
          }else{
            Write-Host "ExecuteSettingFile (Rename)- Could not find '$($currentFile)'."
          }
			}   
			catch{
				Write-Host Error "Could not rename file '$($currentFile)' to '$($file.name)'."
				}
        }
    }


    # REPLACE section in settings file        
    foreach($configFile in $settings.Deployment.Website.ReplaceXml.File)
	{
        try 
        {
			Write-Host Info "Replacing settings values in '$($configFile.name)'."
			Replace-XmlItems -folder "$rootPath\" -file $configFile
        }
        catch
        {
            Write-Host Error "AN error occured during update of config file ('$($configFile.name)'). Error: $($_.Exception.Message)" 
			throw               
        }
	}

    # REMOVEFILES section in settings file
    if ($settings.Deployment.Website.RemoveFiles.Item -ne $null)
	{
        foreach($file in $settings.Deployment.Website.RemoveFiles.File)
	    {                                  
		        Write-Host Info "Removing file '$($rootPath)\$($file.path)'."
            Remove-Item -Path "$rootPath\$($file.path)" -Recurse -Force -ErrorAction SilentlyContinue              
        }
    }


	
}

		function Initialize-WebAdministration {
      Write-Host "Initialize-WebAdministration called"
		# Import IIS module (can only be loaded when running in elevated mode).
		Import-Module WebAdministration
	}


#endregion
