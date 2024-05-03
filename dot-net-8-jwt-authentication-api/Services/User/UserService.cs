using dot_net_8_jwt_authentication_api.EntitiesModel;
using dot_net_8_jwt_authentication_api.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using dot_net_8_jwt_authentication_api.Helper;

namespace dot_net_8_jwt_authentication_api.Services.User;

public class UserService : IUserService
{

    /// <summary>
    /// Get all users method
    /// </summary>
    /// <returns>Returns a list of all users</returns>
    public async Task<IEnumerable<EntitiesModel.User>> GetAll()
    {
        // Create a new list of users
        var users = new List<EntitiesModel.User>()
        {
            // Add a sample user for testing purposes
            new EntitiesModel.User()
            {
                // Set the user ID
                Id = 1,
                // Set the full name
                FullName = "Arsham Behbahani",
                // Set the password (for testing purposes only)
                Password = "admin",
                // Set the username
                Username = "admin"
            }
        };

        // Return the list of users
        return users;
    }

    /// <summary>
    /// Authenticates a user and returns an authentication response.
    /// </summary>
    /// <param name="model">The authentication request.</param>
    /// <returns>A task that represents the asynchronous operation, the result of which is an authentication response if the user is authenticated, or null otherwise.</returns>
    public async Task<AuthenticateResponse?> Authenticate(AuthenticateRequest model)
    {
        // Get all users from the database
        var users = await GetAll();

        // Find the user with the matching username and password
        var user = users.SingleOrDefault(x => x.Username == model.Username && x.Password == model.Password);

        // If the user is not found, return null
        if (user == null)
            return null;

        // Generate a JWT token for the user
        var token = GenerateJwtToken(user);

        // Return the authenticate response with the user and token
        return new AuthenticateResponse(user, token);
    }

    /// <summary>
    /// Generates a JSON Web Token for a given user.
    /// </summary>
    /// <param name="user">The user for whom the token is to be generated.</param>
    /// <returns>A string representing the generated JSON Web Token.</returns>
    private string GenerateJwtToken(EntitiesModel.User user)
    {
        // Create a new JWT security token handler
        var tokenHandler = new JwtSecurityTokenHandler();

        // Get the secret key for signing the token
        var key = Encoding.ASCII.GetBytes(StaticMember.JwtSecretKey);

        // Create a new security token descriptor
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            // Set the subject of the token to the user's ID
            Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),

            // Set the expiration date of the token to 15 days from now
            Expires = DateTime.UtcNow.AddDays(15),

            // Set the signing credentials for the token
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        // Create the JWT token
        var token = tokenHandler.CreateToken(tokenDescriptor);

        // Write the token to a string
        return tokenHandler.WriteToken(token);
    }

    /// <summary>
    /// Retrieves a user by their ID.
    /// </summary>
    /// <param name="id">The ID of the user to retrieve.</param>
    /// <returns>The user with the matching ID, or null if no user is found.</returns>
    public async Task<EntitiesModel.User?> GetById(int id)
    {
        // Get all users from the database
        var users = await GetAll();

        // Filter the list of users to find the one with the matching ID
        // If no user is found, FirstOrDefault will return null
        return users.FirstOrDefault(x => x.Id == id);
    }


}