#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 6060
ENV ASPNETCORE_URLS=http://*:6060

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/Sysolutions.Erp.WebApi/Sysolutions.Erp.WebApi.csproj", "src/Sysolutions.Erp.WebApi/"]
COPY ["src/Sysolutions.Erp.Application/Sysolutions.Erp.Application.csproj", "src/Sysolutions.Erp.Application/"]
COPY ["src/Sysolutions.Erp.Domain/Sysolutions.Erp.Domain.csproj", "src/Sysolutions.Erp.Domain/"]
COPY ["src/Sysolutions.Erp.Infrastructure/Sysolutions.Erp.Infrastructure.csproj", "src/Sysolutions.Erp.Infrastructure/"]
RUN dotnet restore "src/Sysolutions.Erp.WebApi/Sysolutions.Erp.WebApi.csproj"
COPY . .
WORKDIR "/src/src/Sysolutions.Erp.WebApi"
RUN dotnet build "Sysolutions.Erp.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Sysolutions.Erp.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Sysolutions.Erp.WebApi.dll"]