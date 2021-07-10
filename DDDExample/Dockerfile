#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["DDDExample/Messaging.API.csproj", "DDDExample/"]
COPY ["Ordering.Infrastructure/Messaging.Infrastructure.csproj", "Ordering.Infrastructure/"]
COPY ["Ordering.Domain/Messaging.Domain.csproj", "Ordering.Domain/"]
RUN dotnet restore "DDDExample/Messaging.API.csproj"
COPY . .
WORKDIR "/src/DDDExample"
RUN dotnet build "Messaging.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Messaging.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Messaging.API.dll"]