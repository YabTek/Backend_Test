This section guides you through setting up and running the backend server .NET project. The backend is built with ASP.NET Core and uses Entity Framework Core for data management. Follow the steps below to get started.

Prerequisites
Before you begin, ensure you have the following installed:

.NET SDK (version 6.0 or later)
PostgreSQL (if using PostgreSQL for your database)
Setup
Clone the Repository
First, clone the project repository to your local machine using Git:

git clone https://github.com/YabTek/Backend_Test.git

Restore Dependencies
Inside the project directory, restore the project dependencies by running:

Copy code
dotnet restore
Configure the Database
Update Connection Strings

Open the appsettings.json file and update the connection string for your database. Ensure it points to your PostgreSQL database.

Apply Migrations

Apply the database migrations to set up the initial schema:

Copy code: dotnet ef database update

Running the Server
After completing the setup steps, you can start the backend server with:
dotnet run --project Project.API
This command will launch the ASP.NET Core application on the default port, usually defined in your appsettings.json file (e.g., http://localhost:5000). You can access the backend services by navigating to this URL in your web browser or using tools like Postman to make requests.

API Documentation
The backend includes Swagger for API documentation. Once the server is running, you can access the Swagger UI by navigating to:
Copy code: http://localhost:5037/swagger/index.html

