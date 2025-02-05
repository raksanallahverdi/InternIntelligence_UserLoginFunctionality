using Business.Dtos.Auth;
using Business.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Abstract
{
    public interface IAuthService
    {
        Task<Response> RegisterAsync(AuthRegisterDto model);
        Task<Response<AuthLoginResponseDto>> LoginAsync(AuthLoginDto model);
        Task LogoutAsync(string token);
    }
}
