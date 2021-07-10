FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/Client/Client.csproj", "Client/"]
RUN dotnet restore "src/Client/Client.csproj"
COPY . .
WORKDIR "/src/Client"
RUN dotnet build "Client.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Client.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Client.dll"]
