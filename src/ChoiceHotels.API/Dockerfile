FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY src/ChoiceHotels.API/ChoiceHotels.API.csproj .
COPY src/ChoiceHotels.Domain/ChoiceHotels.Domain.csproj ./src/ChoiceHotels.Domain/
RUN dotnet restore ChoiceHotels.API.csproj
COPY . .
WORKDIR /src/src/ChoiceHotels.API
RUN dotnet publish -c Release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "ChoiceHotels.API.dll"]