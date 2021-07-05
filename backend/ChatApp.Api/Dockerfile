#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["backend/ChatApp.Api/ChatApp.Api.csproj", "backend/ChatApp.Api/"]
COPY ["backend/ChatApp.Bll/ChatApp.Bll.csproj", "backend/ChatApp.Bll/"]
COPY ["backend/ChatApp.Domain/ChatApp.Domain.csproj", "backend/ChatApp.Domain/"]
COPY ["backend/ChatApp.Dal/ChatApp.Dal.csproj", "backend/ChatApp.Dal/"]
RUN dotnet restore "backend/ChatApp.Api/ChatApp.Api.csproj"
COPY . .
WORKDIR "/src/backend/ChatApp.Api"
RUN dotnet build "ChatApp.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ChatApp.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ChatApp.Api.dll"]