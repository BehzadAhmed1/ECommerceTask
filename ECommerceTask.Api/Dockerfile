FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

## Disable the invariant mode
#ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
## Install the ICU libraries
#RUN apt-get update && apt-get install -y libicu-dev
#
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ECommerceTask.Api/ECommerceTask.Api.csproj", "ECommerceTask.Api/"]
RUN dotnet restore "./ECommerceTask.Api/./ECommerceTask.Api.csproj"
COPY . .
WORKDIR "/src/ECommerceTask.Api"
RUN dotnet build "./ECommerceTask.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

## Disable the invariant mode
#ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
## Install the ICU libraries
#RUN apt-get update && apt-get install -y libicu-dev
#
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ECommerceTask.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ECommerceTask.Api.dll"]
