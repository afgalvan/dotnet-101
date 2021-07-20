FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 5000
ENV ASPNETCORE_URLS=http://+:5000
RUN adduser -u 5678 --disabled-password --gecos "" appuser && chown -R appuser /app
USER appuser

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/ContosoCraft.Api/ContosoCraft.Api.csproj", "ContosoCraft.Api/"]
COPY ["src/ContosoCraft/ContosoCraft.csproj", "ContosoCraft/"]
RUN dotnet restore "/src/ContosoCraft.Api/ContosoCraft.Api.csproj"
COPY ./src .
WORKDIR "/src/ContosoCraft.Api"
RUN dotnet build "ContosoCraft.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ContosoCraft.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ContosoCraft.Api.dll"]
