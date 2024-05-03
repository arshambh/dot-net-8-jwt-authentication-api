using System.Text.Json.Serialization;

namespace dot_net_8_jwt_authentication_api.EntitiesModel;

/// <summary>
/// This class represents a user entity
/// </summary>
public class User
{
    /// <summary>
    /// Unique identifier for the user
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Full name of the user
    /// It's a required string and cannot be null
    /// </summary>
    public required string FullName { get; set; }

    /// <summary>
    /// Username of the user
    /// It's a required string and cannot be null
    /// </summary>
    public required string Username { get; set; }

    /// <summary>
    /// Password of the user (not serialized)
    /// It's a required string and cannot be null
    /// </summary>
    public required string Password { get; set; }
}
