
function Stop-Project {  
    $process = Get-NetTCPConnection -State Listen | Where-Object { $_.LocalPort -eq '3000' } | Select-Object -ExpandProperty OwningProcess
    if ($process) {
        Stop-Process $process
    }
}

Stop-Project