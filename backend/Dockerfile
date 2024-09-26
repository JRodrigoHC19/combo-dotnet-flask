FROM mcr.microsoft.com/dotnet/sdk:8.0 AS create
WORKDIR /src
RUN dotnet new webapi -o api-srv-cats --no-https
COPY ./Program.cs ./api-srv-cats/Program.cs


FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY --from=create /src/api-srv-cats/api-srv-cats.csproj .
RUN dotnet restore
COPY --from=create /src/api-srv-cats .
RUN dotnet publish -c release -o /app


FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "api-srv-cats.dll"]