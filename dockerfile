# Uses official image of .NET SDK for compiling
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

# Copy the project file and restore dependencies
COPY *.csproj ./
RUN dotnet restore

# Copy the rest of the code and compile
COPY . ./
RUN dotnet publish -c Release -o /out

# Uses runtime image for executing the API
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
COPY --from=build /out .

# Exposes the 8080 port for Railway
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

# Comand for executing the API
CMD ["dotnet", "Actors-RestAPI.dll"]
