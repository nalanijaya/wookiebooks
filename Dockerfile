FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src


COPY WookieBooks.API/NuGet.Config ./
COPY ["WookieBooks.API/WookieBooks.API.csproj", "WookieBooks.API/"]
COPY ["WookieBooks.DTO/WookieBooks.DTO.csproj", "WookieBooks.DTO/"]
COPY ["WookieBooks.Repository/WookieBooks.Repository.csproj", "WookieBooks.Repository/"]
COPY ["WookieBooks.Service/WookieBooks.Service.csproj", "WookieBooks.Service/"]
COPY ["WookieBooks.Utility/WookieBooks.Utility.csproj", "WookieBooks.Utility/"]

RUN dotnet restore "WookieBooks.API/WookieBooks.API.csproj" --configfile "./NuGet.Config"

COPY . .
WORKDIR "/src/WookieBooks.API"
RUN dotnet build "WookieBooks.API.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "WookieBooks.API.csproj" -c Release -o /app


FROM base AS final
WORKDIR /app
COPY --from=publish /app .



ENTRYPOINT ["dotnet", "wookiebooksapp.dll"]