#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["IdentityApi/IdentityApi.csproj", "IdentityApi/"]
COPY ["IdentityApi.Domain/IdentityApi.Domain.csproj", "IdentityApi.Domain/"]
COPY ["Utility/Denver.Infra.csproj", "Utility/"]
COPY ["IdentityApi.DataCore/IdentityApi.DataCore.csproj", "IdentityApi.DataCore/"]
COPY ["Denver.DataAccess/Denver.DataAccess.csproj", "Denver.DataAccess/"]
RUN dotnet restore "IdentityApi/IdentityApi.csproj"
COPY . .
WORKDIR "/src/IdentityApi"
RUN dotnet build "IdentityApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "IdentityApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "IdentityApi.dll"]