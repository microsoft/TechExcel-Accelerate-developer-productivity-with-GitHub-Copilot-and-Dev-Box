# Use the official .NET 8 SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy the csproj and restore dependencies
COPY *.csproj ./
RUN dotnet restore

# Copy the project files and build the app
COPY . ./
RUN dotnet publish -c Release -o /out

# Use the runtime image to run the app
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /out .

# Set the environment variable
ENV ASPNETCORE_HTTP_PORTS=80

# Set the entry point
ENTRYPOINT ["dotnet", "RazorPagesTestSample.dll"]
