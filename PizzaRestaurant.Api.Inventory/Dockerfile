#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["PizzaRestaurant.Api.Inventory/PizzaRestaurant.Api.Inventory.csproj", "PizzaRestaurant.Api.Inventory/"]
RUN dotnet restore "PizzaRestaurant.Api.Inventory/PizzaRestaurant.Api.Inventory.csproj"
COPY . .
WORKDIR "/src/PizzaRestaurant.Api.Inventory"
RUN dotnet build "PizzaRestaurant.Api.Inventory.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PizzaRestaurant.Api.Inventory.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PizzaRestaurant.Api.Inventory.dll"]