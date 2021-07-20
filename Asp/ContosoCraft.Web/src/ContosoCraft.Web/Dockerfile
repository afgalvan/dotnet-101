FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 8000
ENV ASPNETCORE_URLS=http://+:8000
RUN adduser -u 5678 --disabled-password --gecos "" appuser && chown -R appuser /app
USER appuser

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/ContosoCraft.Web/ContosoCraft.Web.csproj", "ContosoCraft.Web/"]
COPY ["src/ContosoCraft/ContosoCraft.csproj", "ContosoCraft/"]
RUN dotnet restore "/src/ContosoCraft.Web/ContosoCraft.Web.csproj"
COPY ./src .
WORKDIR "/src/ContosoCraft.Web"
RUN dotnet build "ContosoCraft.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ContosoCraft.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ContosoCraft.Web.dll"]
