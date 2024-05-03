using dot_net_8_jwt_authentication_api.Models;

namespace dot_net_8_jwt_authentication_api.Services.User;

public interface IUserService
{
    /// <summary>
    /// Get all users method
    /// </summary>
    /// <returns>Returns a list of all users</returns>
    Task<IEnumerable<EntitiesModel.User>> GetAll();

    /// <summary>
    /// Authenticates a user and returns an authentication response.
    /// </summary>
    /// <param name="model">The authentication request.</param>
    /// <returns>A task that represents the asynchronous operation, the result of which is an authentication response if the user is authenticated, or null otherwise.</returns>
    Task<AuthenticateResponse?> Authenticate(AuthenticateRequest model);

    /// <summary>
    /// Retrieves a user by their ID.
    /// </summary>
    /// <param name="id">The ID of the user to retrieve.</param>
    /// <returns>The user with the matching ID, or null if no user is found.</returns>
    Task<EntitiesModel.User?> GetById(int id);
}