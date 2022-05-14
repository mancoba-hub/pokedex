#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["Mbiza.Pokedex/Mbiza.Pokedex.csproj", "Mbiza.Pokedex/"]
RUN dotnet restore "Mbiza.Pokedex/Mbiza.Pokedex.csproj"
COPY . .
WORKDIR "/src/Mbiza.Pokedex"
RUN dotnet build "Mbiza.Pokedex.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Mbiza.Pokedex.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Mbiza.Pokedex.dll"]