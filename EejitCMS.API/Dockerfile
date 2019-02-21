FROM microsoft/dotnet:2.1-aspnetcore-runtime-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk-stretch AS build
WORKDIR /src
COPY ["EejitCMS.API/EejitCMS.API.csproj", "EejitCMS.API/"]
RUN dotnet restore "EejitCMS.API/EejitCMS.API.csproj"
COPY . .
WORKDIR "/src/EejitCMS.API"
RUN dotnet build "EejitCMS.API.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "EejitCMS.API.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "EejitCMS.API.dll"]