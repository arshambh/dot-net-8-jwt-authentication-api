using dot_net_8_jwt_authentication_api.EntitiesModel;

namespace dot_net_8_jwt_authentication_api.Models;

/// <summary>
/// Initializes a new instance of the AuthenticateResponse class.
/// </summary>
/// <param name="user">The user for whom the authentication response is created.</param>
/// <param name="jwtToken">The JWT token for the authenticated user.</param>
public class AuthenticateResponse(User user, string jwtToken)
{

    /// <summary>
    /// The ID of the authenticated user.
    /// </summary>
    public int Id { get; set; } = user.Id;

    /// <summary>
    /// The full name of the authenticated user.
    /// </summary>
    public string FullName { get; set; } = user.FullName;

    /// <summary>
    /// The username of the authenticated user.
    /// </summary>
    public string Username { get; set; } = user.Username;

    /// <summary>
    /// The JWT token for the authenticated user.
    /// </summary>
    public string JwtToken { get; set; } = jwtToken;
}