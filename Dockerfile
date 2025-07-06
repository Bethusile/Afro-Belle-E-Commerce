# Use the official .NET SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy everything into the container
COPY . ./

# Restore dependencies
RUN dotnet restore AB.csproj

# Publish the app
RUN dotnet publish AB.csproj -c Release -o /out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /out ./

# Expose port
EXPOSE 80

# Start the app
ENTRYPOINT ["dotnet", "AB.dll"]
