# Task 10 - **Building a Mini Microservice with ASP.NET Core**

## **Objective:**
- Create a small RESTful API that manages a resource (e.g., Products, Orders, or Books) using ASP.NET Core.

## **Implementation:**

### Project Setup
- ASP.NET Core Web API template used
- RESTful routing configured using `[Route("api/[controller]")]`

### Services and Dependency Injection
- `IBookService` and `BookService` handle business logic
- Registered using `AddScoped()` in `Program.cs`

### Data Access
- Entity Framework Core with **In-Memory Database**
- `AppDbContext` registered in `Program.cs`

### CRUD Functionality
- Resource: `Book` model with properties: `Id`, `Title`, `Author`, `PublishedYear`
- API Endpoints (in `BooksController.cs`):
  - `GET /api/books` – List all books
  - `GET /api/books/{id}` – Get a specific book by ID
  - `POST /api/books` – Add a new book
  - `PUT /api/books/{id}` – Update a book by ID
  - `DELETE /api/books/{id}` – Delete a book by ID

### Exception Handling
- Global `ExceptionMiddleware` catches unhandled exceptions
- Returns structured error response:

```json
{
"message": "Internal Server Error",
"details": "Exception Message Here"
}
```

### Logging
- Logs generated using `ILogger<T>` in both Controller and Service
- Includes info logs for operations and warnings for not found cases

### Swagger Integration
- Swagger UI enabled for API documentation and testing
- Available at `/swagger` in development environment


## **Output:**

### **Swagger UI**

- URL: https://localhost:{port}/swagger
- All available API endpoints for Book CRUD operations displayed via Swagger.

![Swagger](./outputs/swagger.png)


### **POST**

- Request to add a new book.

![Post](./outputs/post_request.png)

- Successful creation of a book with returned JSON response.

![Post](./outputs/post_response.png)

- Log showing book addition.

![Post](./outputs/post_log.png)

### **GET**

- Displays a list of all books currently stored.

![GET](./outputs/get_all.png)

- Log showing fetch operation for all books.

![GET](./outputs/get_log.png)

### **GET BY ID**

- Fetches a single book by ID.

![GET](./outputs/get_by_id.png)

- Log confirming the fetch request for a specific book.

![GET](./outputs/get_by_id_log.png)

### **UPDATE**

- Request to update a book’s details.

![UPDATE](./outputs/update_request.png)

- Response for successful update.

![UPDATE](./outputs/update_response.png)

- Log of the update operation.

![UPDATE](./outputs/update_log.png)

### **DELETE**

- Delete operation on a book using its ID.

![DELETE](./outputs/delete.png)

- Log confirming successful deletion.

![DELETE](./outputs/delete_log.png)

### **EXCEPTION**

- Triggering Exception via Invalid PUT

![EXCEPTION](./outputs/exception_request.png)

- Exception Response from Middleware

![EXCEPTION](./outputs/exception_response.png)

- Detailed exception logged by the middleware for debugging.

![EXCEPTION](./outputs/exception_log.png)