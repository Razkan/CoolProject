Begin {
}
  
Process {
    $serviceArr = ("frontendapi")
    # $serviceArr = ("anima")
    # $serviceArr = ("backendapi", "trackerapi", "frontendapi")

    Foreach ($service in $serviceArr)
    {
        $command = "docker build -t $($service):latest -f .\Dockerfile.$($service) ."
        Write-Host "Invoking $($command)"

        Invoke-Expression -Command $command
    }
}

End {
}