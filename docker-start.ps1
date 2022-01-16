Begin {
}
  
Process {
    # $command = "docker-compose -p coolproject up --build --force-recreate -d"
    $build = "docker-compose build --parallel"
    $up = "docker-compose -p coolproject up -d"

    Write-Host "Invoking $($command)"
    Invoke-Expression -Command $command
    
    Write-Host "Invoking $($up)"
    Invoke-Expression -Command $command
    
}

End {
}