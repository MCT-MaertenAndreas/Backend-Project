FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 5000
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["API.IMDB.csproj", "./"]
RUN dotnet restore "API.IMDB.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "API.IMDB.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "API.IMDB.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "API.IMDB.dll"]
