FROM mcr.microsoft.com/dotnet/core/runtime:3.1 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["ContosoPets.1.csproj", "ContosoPets.1/"]
RUN dotnet restore "ContosoPets.1/ContosoPets.1.csproj"
WORKDIR "/src/ContosoPets.1"
COPY . .
WORKDIR "/src/ContosoPets.1"
RUN dotnet build "ContosoPets.1.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ContosoPets.1.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ContosoPets.1.dll", "appsettings.Docker.json"]
