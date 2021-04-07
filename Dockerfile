FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 5000
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Documents.csproj", "./"]
RUN dotnet restore "Documents.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "Documents.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Documents.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Documents.dll"]
