using Hakaton_UUNIT.Dtos;
using Hakaton.Application.Domain.Users;
using Microsoft.AspNetCore.Mvc;

namespace Hakaton_UUNIT.Controllers;

[ApiController]
public class AuthorizationController : ControllerBase
{
    private readonly IUsersService _usersService;

    public AuthorizationController(IUsersService usersService)
    {
        _usersService = usersService;
    }

    [HttpPost("authorization")]
    [ProducesResponseType(typeof(User),200)]
    public async Task<User> Authorization(AuthorizationModel model)
    {
        return await _usersService.Authorization(model.Username, model.Password);
    }
    
    [HttpPost("registration")]
    [ProducesResponseType(typeof(User),200)]
    public async Task<User> Registration(AuthorizationModel model)
    {
        return await _usersService.Registration(model.Username, model.Password);
    }
}