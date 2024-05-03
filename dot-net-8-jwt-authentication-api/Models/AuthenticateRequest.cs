using System.ComponentModel.DataAnnotations;

namespace dot_net_8_jwt_authentication_api.Models;

/// <summary>
/// This class represents a request object for authentication
/// </summary>
public class AuthenticateRequest
{
    /// <summary>
    /// Required property for the username
    /// It's a string type and cannot be null
    /// </summary>
    public required string Username { get; set; }

    /// <summary>
    /// Required property for the password
    /// It's a string type and cannot be null
    /// </summary>
    public required string Password { get; set; }
}