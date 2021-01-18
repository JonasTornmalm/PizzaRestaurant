#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["PizzerianLab3/PizzerianLab3.csproj", "PizzerianLab3/"]
RUN dotnet restore "PizzerianLab3/PizzerianLab3.csproj"
COPY . .
WORKDIR "/src/PizzerianLab3"
RUN dotnet build "PizzerianLab3.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PizzerianLab3.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PizzerianLab3.dll"]