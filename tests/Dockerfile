FROM mcr.microsoft.com/dotnet/sdk:6.0 AS base
WORKDIR /
COPY . .

WORKDIR tests/CodingAssessment.UnitTests
RUN dotnet restore

RUN dotnet test

ENTRYPOINT ["dotnet", "test"]