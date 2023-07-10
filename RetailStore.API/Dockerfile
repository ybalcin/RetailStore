FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["RetailStore.API/RetailStore.API.csproj", "RetailStore.API/"]
RUN dotnet restore "RetailStore.API/RetailStore.API.csproj"
COPY . .
WORKDIR "/src/RetailStore.API"
RUN dotnet build "RetailStore.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RetailStore.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RetailStore.API.dll"]
