FROM mcr.microsoft.com/dotnet/core/runtime:3.1 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["ContosoPets.2.csproj", "ContosoPets.2/"]
RUN dotnet restore "ContosoPets.2/ContosoPets.2.csproj"
WORKDIR "/src/ContosoPets.2"
COPY . .
WORKDIR "/src/ContosoPets.2"
RUN dotnet build "ContosoPets.2.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ContosoPets.2.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ContosoPets.2.dll", "appsettings.Docker.json"]
