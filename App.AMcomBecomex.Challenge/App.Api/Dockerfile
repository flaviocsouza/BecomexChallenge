
FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["App.Api/App.Api.csproj", "App.Api/"]
RUN dotnet restore "App.Api/App.Api.csproj"
COPY . .
WORKDIR "/src/App.Api"
RUN dotnet build "App.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "App.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "App.Api.dll"]