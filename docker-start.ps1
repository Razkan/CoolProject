Begin {
}
  
Process {
    # $command = "docker-compose -p anima up --build --force-recreate -d"
    $command = "docker-compose -p anima up --build -d"
    Write-Host "Invoking $($command)"

    Invoke-Expression -Command $command
    
}

End {
}