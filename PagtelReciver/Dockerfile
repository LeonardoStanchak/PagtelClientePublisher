#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["PagtelReciver/ClienteConsumer.csproj", "PagtelReciver/"]
COPY ["Pagtel.Model/Pagtel.Models.csproj", "Pagtel.Model/"]
COPY ["Pagtel.Repositories/Pagtel.Repositories.csproj", "Pagtel.Repositories/"]
COPY ["Pagtel.Services/Pagtel.Services.csproj", "Pagtel.Services/"]
RUN dotnet restore "PagtelReciver/ClienteConsumer.csproj"
COPY . .
WORKDIR "/src/PagtelReciver"
RUN dotnet build "ClienteConsumer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ClienteConsumer.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ClienteConsumer.dll"]