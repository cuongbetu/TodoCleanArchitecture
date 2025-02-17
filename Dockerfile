FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy all project files
COPY ["TodoCleanArchitecture.API/TodoCleanArchitecture.API.csproj", "TodoCleanArchitecture.API/"]
COPY ["TodoCleanArchitecture.Application/TodoCleanArchitecture.Application.csproj", "TodoCleanArchitecture.Application/"]
COPY ["TodoCleanArchitecture.Infrastructure/TodoCleanArchitecture.Infrastructure.csproj", "TodoCleanArchitecture.Infrastructure/"]

# Copy all source code
COPY . .

# Restore and build
WORKDIR /src/TodoCleanArchitecture.API
RUN dotnet restore
RUN dotnet build -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TodoCleanArchitecture.API.dll"]