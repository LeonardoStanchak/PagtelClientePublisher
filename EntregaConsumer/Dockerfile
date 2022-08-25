#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["EntregaConsumer/EntregaConsumer.csproj", "EntregaConsumer/"]
COPY ["Pagtel.Model/Pagtel.Models.csproj", "Pagtel.Model/"]
COPY ["Pagtel.Repositories/Pagtel.Repositories.csproj", "Pagtel.Repositories/"]
COPY ["Pagtel.Services/Pagtel.Services.csproj", "Pagtel.Services/"]
COPY ["PagtelReciver/ClienteConsumer.csproj", "PagtelReciver/"]
RUN dotnet restore "EntregaConsumer/EntregaConsumer.csproj"
COPY . .
WORKDIR "/src/EntregaConsumer"
RUN dotnet build "EntregaConsumer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EntregaConsumer.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EntregaConsumer.dll"]