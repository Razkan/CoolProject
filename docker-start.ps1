Begin {
}
  
Process {
    $command = "docker-compose up --build --force-recreate -d"
    Write-Host "Invoking $($command)"

    Invoke-Expression -Command $command
    
}

End {
}