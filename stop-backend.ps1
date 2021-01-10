
function Stop-Project {
    param (
        $ProcessName
    )

    Get-Process | Where-Object { $_.Name -eq $ProcessName } | Select-Object -First 1 | Stop-Process
}

Stop-Project -Project "Tracker"
Stop-Project -Project "BackendAPI"
Stop-Project -Project "FrontendAPI"
