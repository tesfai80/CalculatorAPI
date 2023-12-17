using CalculatorAPI.Interfaces;
using CalculatorAPI.Models;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Linq;

namespace CalculatorAPI.Services;

/// <summary>
/// User service to populate dummy data and handinling login operation
/// </summary>
public class UserService : IUserService
{
    // users hardcoded for simplicity,in production users can be stored in data base with hashed passwords or in active directory 
    private readonly List<User> _users = new()
    {
            new User { Id = 1, UserName = "user1", Password = "password1", Role = "admin"},
            new User { Id = 2, UserName = "user2", Password = "password2", Role = "guest"}
        };

    private readonly IConfiguration _configuration;
    /// <summary>
    /// inject iconfiguration for getting values from the appsetting file
    /// </summary>
    /// <param name="configuration"></param>
    public UserService(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    /// <summary>
    /// Authenticates users
    /// </summary>
    /// <param name="userName"></param>
    /// <param name="password"></param>
    /// <returns>JWT token</returns>
    public string Login(string userName, string password)
    {
        var user = _users.SingleOrDefault(x => x.UserName == userName && x.Password == password);

        // return null if user not found
        if (user == null)
        {
            return string.Empty;
        }

        // authentication successful so generate jwt token
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_configuration["jwt:secretKey"]);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                    new(ClaimTypes.Name, user.UserName),
                    new(ClaimTypes.Role, user.Role)
            }),

            //can be configable with appsetting.json file instead of hard coded
            Expires = DateTime.UtcNow.AddMinutes(5),// Token expiration time
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        user.Token = tokenHandler.WriteToken(token);
        return user.Token;
    }
}
