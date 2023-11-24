using Hakaton_UUNIT.Dtos;
using Hakaton.Application.Domain.Users;
using Microsoft.AspNetCore.Mvc;

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
    [ProducesResponseType(typeof(User),200)]
    public async Task<User> Authorization(AuthorizationModel model)
    {
        return await _userService.Authorization(model.Username, model.Password);
    }
    
    [HttpPost("registration")]
    [ProducesResponseType(typeof(User),200)]
    public async Task<User> Registration(AuthorizationModel model)
    {
        return await _userService.Registration(model.Username, model.Password);
    }
}