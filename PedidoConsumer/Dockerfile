#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["PedidoConsumer/PedidoConsumer.csproj", "PedidoConsumer/"]
COPY ["Pagtel.Model/Pagtel.Models.csproj", "Pagtel.Model/"]
COPY ["Pagtel.Repositories/Pagtel.Repositories.csproj", "Pagtel.Repositories/"]
COPY ["Pagtel.Services/Pagtel.Services.csproj", "Pagtel.Services/"]
COPY ["PagtelReciver/ClienteConsumer.csproj", "PagtelReciver/"]
RUN dotnet restore "PedidoConsumer/PedidoConsumer.csproj"
COPY . .
WORKDIR "/src/PedidoConsumer"
RUN dotnet build "PedidoConsumer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PedidoConsumer.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PedidoConsumer.dll"]