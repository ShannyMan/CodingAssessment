# CodingAssessment

[![CI](https://github.com/ShannyMan/CodingAssessment/actions/workflows/ci.yml/badge.svg)](https://github.com/ShannyMan/CodingAssessment/actions/workflows/ci.yml)

## Continuous Integration

This repository includes a GitHub Actions CI pipeline that automatically:
- Builds the project on every push and pull request to the main branch
- Runs all unit tests
- Reports test results directly in pull request comments
- Uses .NET 6.0 for consistency with the project targets

## Running the Solution with Docker
Clone the repo locally
Create an appsettings.development.json file (Or paste the one provided to you) within the `src\CodingAssessment.Web` directory
Open the Command Prompt/Terminal
Change to the `src` directory
Run the following command: `docker build --pull -t coding-assessment .`
Run the following command: `docker run -d -p 8080:80 -e ASPNETCORE_ENVIRONMENT='Development' coding-assessment`
Open your browser to (http://localhost:8080)[http://localhost:8080]

## Running Unit Tests with Docker
Clone the repo locally
Open the Command Prompt/Terminal
Change to the `tests` directory
Run the following command: `docker build --pull -t coding-assessment-test -f . ..`
Run the following command: `docker run coding-assessment-test`

## Running Unit Tests Locally
Ensure you have .NET 6.0 SDK installed
Clone the repo locally
Open the Command Prompt/Terminal in the repository root
Run the following command: `dotnet restore`
Run the following command: `dotnet test`