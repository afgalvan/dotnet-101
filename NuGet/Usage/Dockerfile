FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Usage.csproj", "Usage/"]
WORKDIR "/src/Usage"
RUN dotnet restore "Usage/Usage.csproj"
RUN dotnet build "Usage.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Usage.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Usage.dll"]
