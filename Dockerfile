# Esta fase é usada durante a execução
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Esta fase é usada para compilar o projeto
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["doQrApi.csproj", "."]
RUN dotnet restore "./doQrApi.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "./doQrApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Esta fase é usada para publicar o projeto
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./doQrApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Esta fase é usada na produção
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "doQrApi.dll"]
