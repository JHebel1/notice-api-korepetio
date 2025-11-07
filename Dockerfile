#build

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore src/NoticesAPI/NoticesAPI.csproj
RUN dotnet publish src/NoticesAPI/NoticesAPI.csproj -c Release -o /app/publish


#run
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app 
COPY --from=build /app/publish .
EXPOSE 5001
ENV ASPNETCORE_URLS=http://+:5001
ENTRYPOINT ["dotnet", "NoticesAPI.dll"]
