#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM node:10-alpine as build-node
WORKDIR /ClientApp
COPY ClientApp/package.json .
COPY ClientApp/package-lock.json .
RUN npm install
COPY ClientApp/ .
RUN npm run build

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
ENV BuildingDocker true
WORKDIR /src
COPY ["BookingAdminUi.csproj", "BookingAdminUi/"]
RUN dotnet restore "BookingAdminUi/BookingAdminUi.csproj"

COPY . "BookingAdminUi/"
WORKDIR "/src/BookingAdminUi"
RUN dotnet build "BookingAdminUi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BookingAdminUi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY --from=build-node /ClientApp/build ./ClientApp/build
ENTRYPOINT ["dotnet", "BookingAdminUi.dll"]