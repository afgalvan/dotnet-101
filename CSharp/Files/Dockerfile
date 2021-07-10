FROM mcr.microsoft.com/dotnet/core/runtime:3.1 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["Files/Files.csproj", "Files/"]
RUN dotnet restore "Files/Files.csproj"
COPY . .
WORKDIR "/src/Files"
RUN dotnet build "Files.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Files.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Files.dll"]
