#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 6060
ENV ASPNETCORE_URLS=http://*:6060

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/Sysolutions.Security.WebApi/Sysolutions.Security.WebApi.csproj", "src/Sysolutions.Security.WebApi/"]
COPY ["src/Sysolutions.Security.Application/Sysolutions.Security.Application.csproj", "src/Sysolutions.Security.Application/"]
COPY ["src/Sysolutions.Security.Domain/Sysolutions.Security.Domain.csproj", "src/Sysolutions.Security.Domain/"]
COPY ["src/Sysolutions.Security.Infrastructure/Sysolutions.Security.Infrastructure.csproj", "src/Sysolutions.Security.Infrastructure/"]
RUN dotnet restore "src/Sysolutions.Security.WebApi/Sysolutions.Security.WebApi.csproj"
COPY . .
WORKDIR "/src/src/Sysolutions.Security.WebApi"
RUN dotnet build "Sysolutions.Security.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Sysolutions.Security.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Sysolutions.Security.WebApi.dll"]