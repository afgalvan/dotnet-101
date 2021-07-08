FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["ContosoPets.Web.csproj", "ContosoPets.Web/"]
RUN dotnet restore "ContosoPets.Web/ContosoPets.Web.csproj"
WORKDIR "/src/ContosoPets.Web"
COPY . .
WORKDIR "/src/ContosoPets.Web"
RUN dotnet build "ContosoPets.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ContosoPets.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ContosoPets.Web.dll"]
