$files = Get-ChildItem -Filter *.cs -Recurse
foreach ($file in $files) {
    $content = Get-Content $file.FullName
    $changed = $false
    $newContent = foreach ($line in $content) {
        $newLine = $line -replace 'namespace HotelManagement.UI', 'namespace HotelManagement'
        $newLine = $newLine -replace 'using HotelManagement.UI;', '// using HotelManagement.UI;'
        if ($newLine -ne $line) { $changed = $true }
        $newLine
    }
    if ($changed) {
        Set-Content -Path $file.FullName -Value $newContent
        Write-Host "Updated namespace in $($file.Name)"
    }
}
