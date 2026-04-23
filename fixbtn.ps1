$files = Get-ChildItem -Filter *.Designer.cs
foreach ($file in $files) {
    $content = Get-Content $file.FullName
    $newContent = @()
    $changed = $false
    foreach ($line in $content) {
        $newContent += $line
        if ($line -match '^\s*(this\.)?(btn[A-Za-z0-9_]+)\.Text\s*=') {
            $btnName = $matches[2]
            $thisPrefix = if ($matches[1]) { $matches[1] } else { "" }
            $indent = $line.Substring(0, $line.IndexOf($btnName) - $thisPrefix.Length)
            $newContent += "$indent$thisPrefix$btnName.AutoSize = true;"
            $changed = $true
        }
    }
    if ($changed) {
        Set-Content -Path $file.FullName -Value $newContent
        Write-Host "Updated $($file.Name)"
    }
}
