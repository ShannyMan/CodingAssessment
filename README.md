# CodingAssessment

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