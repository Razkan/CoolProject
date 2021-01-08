
function Get-Command {
    $setWindow = "[console]::WindowWidth=90; [console]::WindowHeight=30; [console]::BufferWidth=[console]::WindowWidth"
    $location = Get-Location
    $runProject = "npm start --prefix $location/anima-client/"
    $command = "cmd /c start powershell -Command { $setWindow; $runProject }"
    return $command
}

function Stop-Project {  
    $process = Get-NetTCPConnection -State Listen | Where-Object { $_.LocalPort -eq '3000' } | Select-Object -ExpandProperty OwningProcess
    if ($process) {
        Stop-Process $process
    }
}

function Start-Project {
    Stop-Project
    $command = Get-Command
    invoke-expression $command
}

Start-Project