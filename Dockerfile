#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
RUN apt-get update
RUN apt-get install nodejs npm -y
WORKDIR /src
COPY ["SmartClock/SmartClock.csproj", "SmartClock/"]
COPY ["SmartClock.Core/SmartClock.Core.csproj", "SmartClock.Core/"]
COPY ["SmartClock.Services.HomeAssistant/SmartClock.Services.HomeAssistant.csproj", "SmartClock.Services.HomeAssistant/"]
RUN dotnet restore "SmartClock/SmartClock.csproj"
COPY . .
WORKDIR "/src/SmartClock"
RUN dotnet build "SmartClock.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SmartClock.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SmartClock.dll"]
