# Use the official .NET SDK image to build the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy the csproj file and restore dependencies
COPY *.csproj ./
RUN dotnet restore

# Copy the rest of the application and build it
COPY . ./
RUN dotnet publish -c Release -o out

# Use the official ASP.NET Core runtime image to run the application
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .

# Expose port 80
ENV ASPNETCORE_HTTP_PORTS=80
# ENV ASPNETCORE_URLS=http://+:80
EXPOSE 80

# Start the application 
ENTRYPOINT ["dotnet", "RazorPagesTestSample.dll"]