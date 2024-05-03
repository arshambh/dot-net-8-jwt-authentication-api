using dot_net_8_jwt_authentication_api.EntitiesModel;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace dot_net_8_jwt_authentication_api.Helper;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class CustomAuthorizeAttribute : Attribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        try
        {
            // Check if the Authorization header is present in the request
            string? headerJwtToken = context.HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (string.IsNullOrEmpty(headerJwtToken))
            {
                // If the token is missing, return a 401 Unauthorized response
                context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
                return;
            }

            // Validate the JWT token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(StaticMember.JwtSecretKey);
            tokenHandler.ValidateToken(headerJwtToken, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true, // Validate the issuer signing key
                IssuerSigningKey = new SymmetricSecurityKey(key), // Set the issuer signing key
                ValidateIssuer = false, // Do not validate the issuer
                ValidateAudience = false, // Do not validate the audience
                ClockSkew = TimeSpan.Zero // Set the clock skew to zero

            }, out SecurityToken validatedToken);

            // Retrieve the user ID from the token
            var decodedToken = (JwtSecurityToken)validatedToken;
            var userId = int.Parse(decodedToken.Claims.First(x => x.Type == "id").Value);// if you want to get user id from claim
        }
        catch (Exception e)
        {
            // If an exception occurs, return a 401 Unauthorized response
            context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
            return;
        }
    }

}