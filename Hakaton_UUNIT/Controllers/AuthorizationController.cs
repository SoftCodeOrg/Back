using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Hakaton_UUNIT.Dtos;
using Hakaton.Application.Domain.Users;
using Hakaton.Infrastruct.Options;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Hakaton_UUNIT.Controllers;

[ApiController]
public class AuthorizationController : ControllerBase
{
    private readonly IUserService _userService;

    public AuthorizationController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("authorization")]
    [ProducesResponseType(typeof(AuthorizationResponse),200)]
    public async Task<AuthorizationResponse> Authorization(AuthorizationModel model)
    {
        var user = await _userService.Authorization(model.Username, model.Password);
        
        var claims = new List<Claim>
        {
            new Claim(ClaimsIdentity.DefaultNameClaimType, user.Username),
            new Claim(ClaimsIdentity.DefaultRoleClaimType, user.isAdmin ? "admin" : "user")
        };
        var claimsIdentity =
            new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                               ClaimsIdentity.DefaultRoleClaimType);
        
        var now = DateTime.UtcNow;
        
        var jwt = new JwtSecurityToken(
            issuer: AuthOptions.ISSUER,
            audience: AuthOptions.AUDIENCE,
            notBefore: now,
            claims: claimsIdentity.Claims,
            expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
            signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
        var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

        return new AuthorizationResponse
        {
            Username = user.Username,
            Token = encodedJwt
        };
    }
    
    [HttpPost("registration")]
    [ProducesResponseType(typeof(User),200)]
    public async Task<User> Registration(AuthorizationModel model)
    {
        return await _userService.Registration(model.Username, model.Password);
    }
    
    [Authorize]
    [HttpGet("getlogin")]
    public IActionResult GetLogin()
    {
        return Ok($"Ваш логин: {User.Identity.Name}");
    }
         
    [Authorize(Roles = "admin")]
    [HttpGet("getrole")]
    public IActionResult GetRole()
    {
        return Ok("Ваша роль: администратор");
    }
}