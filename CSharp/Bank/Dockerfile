FROM mcr.microsoft.com/dotnet/core/runtime:3.1 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["Bank/Bank.csproj", "Bank/"]
RUN dotnet restore "Bank/Bank.csproj"
COPY . .
WORKDIR "/src/Bank"
RUN dotnet build "Bank.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Bank.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Bank.dll"]
