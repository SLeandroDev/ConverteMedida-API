# Use a imagem oficial do .NET 6 SDK como base
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

# Use a imagem do .NET 6 SDK para build
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ConversorDeMedidas/ConversorDeMedidas.csproj", "ConversorDeMedidas/"]
RUN dotnet restore "ConversorDeMedidas/ConversorDeMedidas.csproj"
COPY . .
WORKDIR "/src/ConversorDeMedidas"
RUN dotnet build "ConversorDeMedidas.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ConversorDeMedidas.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ConversorDeMedidas.dll"]
