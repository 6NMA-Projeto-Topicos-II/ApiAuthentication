#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine3.16 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Api-Authentication/Api-Authentication.csproj", "Api-Authentication/"]
RUN dotnet restore "Api-Authentication/Api-Authentication.csproj"
COPY . .
WORKDIR "/src/Api-Authentication"
RUN dotnet build "Api-Authentication.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Api-Authentication.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Api-Authentication.dll"]