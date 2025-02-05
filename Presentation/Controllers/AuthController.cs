using Business.Dtos.Auth;
using Business.Services.Abstract;
using Business.Services.Concrete;
using Business.Wrappers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }
    #region Documentation
    /// <summary>
    /// Register
    /// </summary>
    /// <param name="model"></param>
    #endregion
    [ProducesResponseType(typeof(Response), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Response), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(Response), StatusCodes.Status500InternalServerError)]
    [HttpPost("Register")]
    public async Task<Response> RegisterAsync(AuthRegisterDto model)
        => await _authService.RegisterAsync(model);

    #region Documentation
    /// <summary>
    /// Login
    /// </summary>
    /// <param name="model"></param>
    [ProducesResponseType(typeof(Response<AuthLoginResponseDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Response), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(Response), StatusCodes.Status500InternalServerError)]
    #endregion
    [HttpPost("Login")]
    public async Task<Response<AuthLoginResponseDto>> LoginAsync(AuthLoginDto model)
    => await _authService.LoginAsync(model);

    #region Documentation
    /// <summary>
    /// LogOut
    /// </summary>
    /// <param name="model"></param>
#endregion
    [HttpPost("logout")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public async Task<IActionResult> Logout()
    {
        
        var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

        if (string.IsNullOrEmpty(token))
        {
            return BadRequest(new { Message = "Invalid or missing token." });
        }

       
        await _authService.LogoutAsync(token);
        

        return Ok(new { Message = "User successfully logged out." });
    }

}
