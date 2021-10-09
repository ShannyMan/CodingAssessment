FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["CodingAssessment.Web/CodingAssessment.Web.csproj", "CodingAssessment.Web/"]
RUN dotnet restore "CodingAssessment.Web/CodingAssessment.Web.csproj"
COPY . .
WORKDIR "/src/CodingAssessment.Web"
RUN dotnet build "CodingAssessment.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CodingAssessment.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CodingAssessment.Web.dll"]