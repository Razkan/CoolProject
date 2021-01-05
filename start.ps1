invoke-expression 'cmd /c start powershell -Command { dotnet run --project .\Tracker\  }'

Start-Sleep -Seconds 2

invoke-expression 'cmd /c start powershell -Command { dotnet run --project .\BackendAPI\   }'
invoke-expression 'cmd /c start powershell -Command { dotnet run --project .\FrontendAPI\  }'

 

