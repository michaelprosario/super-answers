FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build
WORKDIR /app

COPY App/*.csproj ./App/
COPY App.Core/*.csproj ./App.Core/
COPY App.Infrastructure/*.csproj ./App.Infrastructure/


RUN dotnet restore ./App/App.csproj

COPY App/. ./App/
COPY App.Core/. ./App.Core/
COPY App.Infrastructure/. ./App.Infrastructure/

WORKDIR /app/App
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:2.2 AS runtime
WORKDIR /app
COPY --from=build /app/App/out ./
ENTRYPOINT ["dotnet", "App.dll"]

