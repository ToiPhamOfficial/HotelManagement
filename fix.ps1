$files = Get-ChildItem -Filter *.cs | Where-Object { $_.Name -notmatch "Designer" }

foreach ($file in $files) {
    if ($file.Name -eq "frmMain.cs") { continue }
    $content = Get-Content $file.FullName
    $newContent = @()
    $textLine = $null
    foreach ($line in $content) {
        if ($line -match '^\s*(this\.)?Text\s*=\s*"(.*?)";') {
            $textLine = $matches[2]
            Write-Host "Found in $($file.Name): $textLine"
        } else {
            $newContent += $line
        }
    }
    
    if ($textLine -ne $null) {
        Set-Content -Path $file.FullName -Value $newContent
        
        $designerPath = $file.FullName -replace '\.cs$', '.Designer.cs'
        if (Test-Path $designerPath) {
            $designerContent = Get-Content $designerPath
            $newDesignerContent = @()
            $added = $false
            foreach ($dline in $designerContent) {
                $newDesignerContent += $dline
                if ($dline -match 'AutoScaleDimensions\s*=') {
                    $newDesignerContent += "            this.Text = `"$textLine`";"
                    $added = $true
                }
            }
            if ($added) {
                Set-Content -Path $designerPath -Value $newDesignerContent
                Write-Host "Added Text to $designerPath"
            }
        }
    }
}
