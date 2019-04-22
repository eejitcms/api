FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
EXPOSE 3333

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["EejitCms.Api/EejitCms.Api.csproj", "EejitCms.Api/"]
RUN dotnet restore "EejitCms.Api/EejitCms.Api.csproj"
COPY . .
WORKDIR "/src/EejitCms.Api"
RUN dotnet build "EejitCms.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "EejitCms.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "EejitCms.Api.dll"]