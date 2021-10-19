#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1.17-focal AS base
ENV ASPNETCORE_URLS=http://+:8080
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY NuGet.Config .
COPY ["src/TOTVSIntegrationCRM.Web/TOTVSIntegrationCRM.Web.csproj", "TOTVSIntegrationCRM.Web/"]
RUN dotnet restore "TOTVSIntegrationCRM.Web/TOTVSIntegrationCRM.Web.csproj"
COPY /src /src
WORKDIR "/src/TOTVSIntegrationCRM.Web"
RUN dotnet build "TOTVSIntegrationCRM.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TOTVSIntegrationCRM.Web.csproj" -c Release -o /app/publish

FROM base AS final
RUN useradd nonroot -m
USER nonroot
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TOTVSIntegrationCRM.Web.dll"]
