FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /src
COPY . .
RUN dotnet restore 
RUN dotnet publish -c Release --nologo -o publish/linux

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /src/publish/linux .
ENTRYPOINT [ "dotnet", "RazorPagesTestSample.dll" ]