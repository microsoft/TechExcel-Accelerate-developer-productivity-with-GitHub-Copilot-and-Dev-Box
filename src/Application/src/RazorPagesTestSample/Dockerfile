# Update the base and SDK images to .NET 8
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["RazorPagesTestSample.csproj", "./"]
RUN dotnet restore "./RazorPagesTestSample.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "RazorPagesTestSample.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RazorPagesTestSample.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RazorPagesTestSample.dll"]