FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Meicrosoft.Books.API/Meicrosoft.Books.API.csproj", "src/Meicrosoft.Books.API/"]
COPY ["src/Meicrosoft.Books.IoC/Meicrosoft.Books.IoC.csproj", "src/Meicrosoft.Books.IoC/"]
COPY ["src/Meicrosoft.Books.Application/Meicrosoft.Books.Application.csproj", "src/Meicrosoft.Books.Application/"]
COPY ["src/Meicrosoft.Books.Domain/Meicrosoft.Books.Domain.csproj", "src/Meicrosoft.Books.Domain/"]
COPY ["src/Meicrosoft.Books.Infra/Meicrosoft.Books.Infra.csproj", "src/Meicrosoft.Books.Infra/"]
RUN dotnet restore "./src/Meicrosoft.Books.API/./Meicrosoft.Books.API.csproj"
COPY . .
WORKDIR "/src/src/Meicrosoft.Books.API"
RUN dotnet build "./Meicrosoft.Books.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Meicrosoft.Books.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Meicrosoft.Books.API.dll"]