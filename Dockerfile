# Build Stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy everything and restore
COPY . .
RUN dotnet restore AB.csproj
RUN dotnet publish AB.csproj -c Release -o /app/out

# Runtime Stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/out ./
EXPOSE 80
ENTRYPOINT ["dotnet", "AB.dll"]
