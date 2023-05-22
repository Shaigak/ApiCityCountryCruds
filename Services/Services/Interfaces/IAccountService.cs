using Services.DTOs.Account;
using Services.Helpers.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.Interfaces
{
    public interface IAccountService
    {
        Task<RegisterResponse> SignUpAsync(RegisterDto model);

        Task<LoginResponse> SignInAsync(LoginDto model);
    }
}
