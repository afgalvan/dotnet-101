FROM mcr.microsoft.com/dotnet/core/runtime:3.1 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["ConditionalsAndLoops/ConditionalsAndLoops.csproj", "ConditionalsAndLoops/"]
RUN dotnet restore "ConditionalsAndLoops/ConditionalsAndLoops.csproj"
COPY . .
WORKDIR "/src/ConditionalsAndLoops"
RUN dotnet build "ConditionalsAndLoops.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ConditionalsAndLoops.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ConditionalsAndLoops.dll"]
