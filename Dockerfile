FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["Management.Tasks.Rest/Management.Tasks.Rest.csproj", "src/Management.Tasks.Rest/"]
COPY ["Application/Application.csproj", "src/Application/"]
COPY ["Domain/Domain.csproj", "src/Domain/"]
COPY ["Infraestructure/Infrastructure.csproj", "src/Infraestructure/"]

RUN dotnet restore "src/Management.Tasks.Rest/Management.Tasks.Rest.csproj"
COPY . .
WORKDIR "/src/Management.Tasks.Rest"
RUN dotnet build "./Management.Tasks.Rest.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "./Management.Tasks.Rest.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Management.Tasks.Rest.dll"]