#Dockerfile should target a .NET 8 project with an entry point of RazorPagesTestSample.dll.
# The Dockerfile should copy the project file and restore the dependencies before copying the source code and building the application.

# Use the .NET 8 SDK image
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy the project file and restore the dependencies
COPY *.csproj ./
RUN dotnet restore

# Copy the source code and build the application
COPY . ./
RUN dotnet publish -c Release -o out

# Use the .NET 8 runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Copy the built application from the build image
COPY --from=build /app/out ./

# Set the entry point
ENTRYPOINT ["dotnet", "RazorPagesTestSample.dll"]