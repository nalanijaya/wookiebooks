FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY WookieBooks.API/WookieBooks.API.csproj WookieBooks.API/
COPY WookieBooks.API/NuGet.Config WookieBooks.API/
COPY WookieBooks.Utility/WookieBooks.Utility.csproj WookieBooks.Utility/
COPY WookieBooks.DTO/WookieBooks.DTO.csproj WookieBooks.DTO/
COPY WookieBooks.Service/WookieBooks.Service.csproj WookieBooks.Service/
COPY WookieBooks.Repository/WookieBooks.Repository.csproj WookieBooks.Repository/
RUN dotnet restore WookieBooks.API/WookieBooks.API.csproj
COPY . .
WORKDIR /src/WookieBooks.API
RUN dotnet build WookieBooks.API.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish WookieBooks.API.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "WookieBooks.API.dll"]
