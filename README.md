# Contact Manager Web App

A simple ASP.NET Core MVC application to manage contacts. It supports basic CRUD operations and in-memory data storage, with unit testing included using xUnit and Moq.

## Features

- View, add, edit, and delete contacts
- Search contacts by first or last name
- Razor Partial Views for dynamic updates
- In-memory storage (no database required)
- Unit tests using xUnit and Moq

## Tech Stack

- ASP.NET Core MVC (.NET 8 or later)
- Razor Views
- Bootstrap 5
- xUnit (Unit Testing)
- Moq (Mocking)

## Getting Started

### Prerequisites

- .NET 8 SDK or later
- Visual Studio 2022+ or VS Code with the C# extension

### Setup Instructions

1. Clone the repository:
git clone https://github.com/akashshah1997/riva_take_home_assignment.git
cd riva_take_home_assignment

markdown
Copy
Edit

2. Open the solution (`ContactApp.sln`) in Visual Studio or open the folder in VS Code.

3. Build the solution:
dotnet build

markdown
Copy
Edit

4. Run the application:
dotnet run --project MyContacts

css
Copy
Edit

5. Open a browser and go to:
http://localhost:5000
or
https://localhost:5001

sql
Copy
Edit

## Running Tests

Unit tests are located in the `MyContacts.Tests` project. To execute:

dotnet test

markdown
Copy
Edit

Ensure the test project references xUnit, Moq, and the main project.

## Project Structure

- `Controllers/` - MVC controllers for routing and logic
- `Models/` - Data models
- `Services/` - Business logic (in-memory service)
- `Views/` - Razor views
- `wwwroot/` - Static content (CSS/JS)
- `MyContacts.Tests/` - xUnit test project

## Contact

Author: Akash Shah  
GitHub: https://github.com/akashshah1997  
LinkedIn: https://www.linkedin.com/in/akashshah1997/
Email: shahakash1997@gmail.com
