FROM mcr.microsoft.com/dotnet/sdk:3.1-alpine as build

WORKDIR /tmp
COPY . ./Tracker
RUN cp /root/Interface .
RUN cp /root/Library .
# COPY . ./Interfaces
# COPY . ./Library
# RUN dotnet restore "./Tracker/Tracker.csproj"

# FROM build AS publish
# RUN dotnet publish "./Tracker/Tracker.csproj" -c Release -o /app/publish
# RUN dotnet publish "./host/Tracker/Tracker.csproj" -c Release -o /app/publish

# FROM mcr.microsoft.com/dotnet/aspnet:3.1-alpine as runtime
# WORKDIR /app
# COPY --from=publish /app/publish .
# ENTRYPOINT ["dotnet", "Tracker.dll"]
