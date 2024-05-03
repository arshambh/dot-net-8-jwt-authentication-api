# dot-net-8-jwt-authentication-api

Welcome to the dot-net-8-jwt-authentication-api project!

This open-source sample project demonstrates a basic implementation of JSON Web Token (JWT) authentication using .NET 8. The project provides a simple example of how to secure an API by generating and verifying JWT tokens for authentication.

### Nuget packages references
```
Install-Package Microsoft.AspNetCore.Authentication.JwtBearer
Install-Package System.IdentityModel.Tokens.Jwt
Install-Package Swashbuckle.AspNetCore
```

### Controllers

The project contains a single controller, `UserController`, which handles user authentication and retrieval.

### Authentication

The `Authenticate` method is responsible for authenticating a user using the provided credentials. It uses the `IUserService` interface to authenticate the user and returns an `OkResult` with the user's details if the authentication is successful.
For example send post request to `/api/User/authenticate`
```json
{
    "username": "admin",
    "password": "admin"
}
```
### Authorization

The `CustomAuthorize` attribute is used to ensure that the user is authenticated before accessing the `GetAll` and `GetUserById` methods.

### Running the Project

To run the project, follow these steps:

1. Clone the project from GitHub: `git clone https://github.com/arshambh/dot-net-8-jwt-authentication-api.git`
2. Run the project using the following command: `dotnet run`
3. Access the API endpoints using a tool like Postman or cURL.
