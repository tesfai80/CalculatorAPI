# Calculator API

This is a simple .NET Core Web API project that provides a calculation endpoint.

- The project follows the SOLID principles to enhance maintainability and scalability.
- The project implements the repository pattern for potential future data access requirements.

- Dependency injection is used to manage and inject dependencies, promoting loose coupling and testability.

- The project is Dockerized for easy deployment and isolation.


#### SwaggerHub API Url
[SwaggerHub](https://app.swaggerhub.com/apis/TESFAI80/CalculatorAPI/1.0.0)

## API Endpoint

### POST /calculator

#### Request

- **Body:** CalculationRequest
  - Number1 (string): First number for the calculation.
  - Number2 (string): Second number for the calculation.

- **Headers:**
  - _operator (string): The operator for the calculation (+, -, *, /).

#### Response

- 200 OK: Successful operation. Returns the result of the calculation.

- 400 Bad Request: Invalid request. Check the request body and headers.

- 401 Unauthorized: the token is not valid or expired

### POST /user
#### Request

- **Body:** CalculationRequest
  - UserName (string): The name of the user(identity).
  - Password (string): The Password of the user.



#### Response

- 200 OK: Successful login. Returns the JWT token.

- 400 Bad Request: Invalid request. Check the request body.

- 401 Unauthorized: the token is not valid or expired

## How to Build and Run Docker
1. Install Docker on your machine.

2. Open a terminal in the project root directory.

3. Build the Docker image:

   ```bash
   docker-compose build

   ## Run the Docker container:
      docker-compose up --build

## How to Run

1. Clone the repository.
2. Open the solution in Visual Studio.
3. Run the project.
4. Use a tool like Postman to make a POST request to `http://localhost:port/TESFAI80/CalculatorAPI/1.0.0/calculator` with the following JSON body:

```json
{
    "number1": "10",
    "number2": "5"
}
