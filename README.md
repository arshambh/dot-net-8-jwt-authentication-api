# dot-net-8-jwt-authentication-api

Welcome to the dot-net-8-jwt-authentication-api project!

This open-source sample project demonstrates a basic implementation of JSON Web Token (JWT) authentication using .NET 8. The project provides a simple example of how to secure an API by generating and verifying JWT tokens for authentication.
## Getting Started

To get started with the project, simply clone the repository and run the API using your preferred .NET runtime.

### Authentication

The API uses JWT authentication, For example
send post request to `/api/User/authenticate`
```json
{
    "username": "admin",
    "password": "admin"
}

