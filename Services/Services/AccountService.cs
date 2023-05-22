using AutoMapper;
using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Services.DTOs.Account;
using Services.Helpers.Responses;
using Services.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Services.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;
        private IConfiguration _config;

        public AccountService(RoleManager<IdentityRole> roleManager,UserManager<AppUser> userManager, IMapper mapper, IConfiguration config)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _mapper = mapper;
            _config = config;
        }

        public async Task<LoginResponse> SignInAsync(LoginDto model)
        {
            throw new NotImplementedException();
        }

        public async Task<RegisterResponse> SignUpAsync(RegisterDto model)
        {

            AppUser user = _mapper.Map<AppUser>(model);


            IdentityResult result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                return new RegisterResponse { StatusMessage="Failed", Errors=result.Errors.Select(m=>m.Description).ToList() };
            }

            return new RegisterResponse { Errors = null, StatusMessage = "Succes" };

           
        }

        //private string GenerateJwtToken(string username, List<string> roles)
        //{
        //    var claims = new List<Claim>
        //{
        //    new Claim(JwtRegisteredClaimNames.Sub, username),
        //    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        //    new Claim(ClaimTypes.NameIdentifier, username)
        //};

        //    roles.ForEach(role =>
        //    {
        //        claims.Add(new Claim(ClaimTypes.Role, role));
        //    });

        //    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JwtKey"]));
        //    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        //    var expires = DateTime.Now.AddDays(Convert.ToDouble(_config["JwtExpireDays"]));

        //    var token = new JwtSecurityToken(
        //        _config["JwtIssuer"],
        //        _config["JwtIssuer"],
        //        claims,
        //        expires: expires,
        //        signingCredentials: creds
        //    );

        //    return new JwtSecurityTokenHandler().WriteToken(token);
        //}











    }
}
