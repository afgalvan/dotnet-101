FROM mcr.microsoft.com/dotnet/core/runtime:3.1 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["Linq.Test/Linq.Test.csproj", "Linq.Test/"]
RUN dotnet restore "Linq.Test/Linq.Test.csproj"
COPY . .
WORKDIR "/src/Linq.Test"
RUN dotnet test
RUN dotnet build "Linq.Test.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Linq.Test.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Linq.Test.dll"]
