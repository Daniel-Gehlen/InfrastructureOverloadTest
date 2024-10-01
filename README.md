## Technical README - **Infrastructure Overload Test** Project

### Project Objective

This full-stack project implements a basic web application that allows performing CRUD operations on a list of categories and mathematical calculations (scenario probabilities). The backend API is built with **ASP.NET Core**, and the frontend uses **HTML**, **JavaScript**, and **CSS** to interact with the API via HTTP requests.

![](/assets/InfrastructureOverloadTest.gif)

### Technologies Used

1. **Backend:**
   - ASP.NET Core 8.0
   - Web API
   - JSON with `Newtonsoft.Json`
   - CORS to allow cross-origin requests
   - Swagger for API documentation

2. **Frontend:**
   - HTML, CSS, and JavaScript
   - Fetch API to interact with the backend

3. **Local Server:**
   - `http-server` to serve static frontend files
   - ASP.NET Core to serve the backend (executed via `dotnet run`)

4. **Development Tools:**
   - Visual Studio or any IDE that supports ASP.NET Core
   - Bash for automating the process of file and folder creation

### Project Structure

```
my-app/
│
├── Backend/
│   ├── Controllers/
│   │   └── CategoryController.cs
│   ├── Models/
│   │   └── Category.cs
│   ├── Program.cs
│   ├── appsettings.json
│   ├── Backend.csproj
│   └── Properties/
│       └── launchSettings.json
│
├── Frontend/
│   ├── index.html
│   ├── app.js
│   └── style.css
│
└── README.md
```

### Steps to Create the Project Structure Using Bash

Here are the Bash commands you can execute to automatically create the entire project structure and pre-populated files for development:

```bash
# Create the main project folder
mkdir my-app
cd my-app

# Create the Backend structure (ASP.NET Core Web API)
dotnet new webapi -o Backend
cd Backend

# Remove default Controller and Model and create new ones
rm -rf WeatherForecast.cs Controllers/WeatherForecastController.cs
mkdir Models
touch Controllers/CategoryController.cs Models/Category.cs

# Add support for Newtonsoft.Json and CORS
dotnet add package Microsoft.AspNetCore.Mvc.NewtonsoftJson

# Go back to the main project folder
cd ..

# Create the Frontend structure
mkdir Frontend
cd Frontend
touch index.html app.js style.css

# Install http-server globally to serve the frontend
npm install -g http-server

# Go back to the project root
cd ..
```

After running these commands, the basic structure will be created with all the necessary files ready for development.

### Programming Techniques

#### Backend (ASP.NET Core Web API)

**Case Study:**
The application performs calculations based on inputs such as "Total Computers," "Computers in Office C," "Access Points," among others, and then calculates two scenarios and the probability of overload in Office C.

**Technologies and Techniques Used:**
- **ASP.NET Core Web API**: Used to build the REST API that manages categories and performs calculations.
- **Newtonsoft.Json**: Support for JSON serialization and deserialization.
- **CORS (Cross-Origin Resource Sharing)**: Enabled to allow frontend access to the backend via HTTP across different origins.
- **Swagger**: Automatically generated API documentation to facilitate testing and integration.

**Code Example (CategoryController.cs)**:

```csharp
[HttpGet]
public ActionResult<IEnumerable<Category>> GetAllCategories()
{
    // Returns the list of categories (e.g., mathematical categories)
}

[HttpPost]
public ActionResult AddCategory(Category category)
{
    // Logic to add a new category and perform scenario calculations
}
```

#### Frontend (HTML/JavaScript)

**Case Study:**
The interface allows users to input data for calculations and view the results. Using JavaScript, the frontend dynamically interacts with the API using `fetch()` to send and receive data.

**Technologies and Techniques Used:**
- **Fetch API**: Used for making asynchronous HTTP calls to the backend API.
- **HTML/CSS**: Structuring and styling the webpage.
- **JavaScript**: DOM manipulation and backend interaction.

**Code Example (app.js)**:

```javascript
async function fetchCategories() {
    try {
        const response = await fetch('https://localhost:5001/api/category');
        const data = await response.json();
        // Update the UI with scenario results
    } catch (error) {
        console.error("Failed to fetch categories", error);
    }
}

document.getElementById('calculateButton').addEventListener('click', () => {
    // Send input data and get results from the backend
});
```

### How to Run the Project

#### Running the Backend (ASP.NET Core Web API)

1. Navigate to the `Backend` folder:
   ```bash
   cd Backend
   ```

2. Run the backend server with the following command:
   ```bash
   dotnet run
   ```

   The server will be available at: `https://localhost:5001`.

#### Running the Frontend (HTTP Server)

1. Navigate to the `Frontend` folder:
   ```bash
   cd Frontend
   ```

2. Start the local server to serve the frontend:
   ```bash
   http-server -p 8000
   ```

   Access the frontend in your browser: `http://localhost:8000`.

### Conclusion

This project offers a simple yet effective full-stack application using **ASP.NET Core Web API** for the backend and **HTML/JavaScript** for the frontend. The programming techniques applied include asynchronous API calls using JavaScript, CORS handling, and JSON data manipulation. The case study focuses on performing mathematical calculations based on different scenarios and dynamically displaying the results in the user interface.

The project can be easily extended to include features such as data persistence (e.g., database integration) or more complex calculations.