
function Get-Command {

    param (
        $Project
    )

    $setWindow = "[console]::WindowWidth=90; [console]::WindowHeight=30; [console]::BufferWidth=[console]::WindowWidth"
    $setTitle = "`$host.ui.RawUI.WindowTitle = ""$Project"""
    $runProject = "dotnet run --configuration Release --project .\$project\"
    $command = "cmd -noexit /c start powershell -Command { $setWindow; $setTitle; $runProject }"
    return $command
}

function Stop-Project {
    param (
        $ProcessName
    )

    Get-Process | Where-Object { $_.Name -eq $ProcessName } | Select-Object -First 1 | Stop-Process
}

function Start-Project {
    param(
        $Project
    )

    Stop-Project -ProcessName $Project
    $command = Get-Command -Project $Project
    invoke-expression $command
}

Start-Project -Project "Tracker"
Start-Project -Project "BackendAPI"
Start-Project -Project "FrontendAPI"
