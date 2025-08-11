using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using KASHOP.BLL.Services.Interfaces;
using KASHOP.DAL.DTO.Requests;
using KASHOP.DAL.DTO.Responses;
using KASHOP.DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ForgotPasswordRequest = KASHOP.DAL.DTO.Requests.ForgotPasswordRequest;
using LoginRequest = KASHOP.DAL.DTO.Requests.LoginRequest;
using RegisterRequest = KASHOP.DAL.DTO.Requests.RegisterRequest;

namespace KASHOP.BLL.Services.Classes
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly IEmailSender _emilSender;

        public AuthenticationService(UserManager<ApplicationUser> userManager,
            IConfiguration configuration,
            IEmailSender emilSender)
        {
            _userManager = userManager;
            _configuration = configuration;
            _emilSender = emilSender;
        }
        public async Task<UserResponse> LoginAsync(LoginRequest loginRequest)
        {
            var user = await _userManager.FindByEmailAsync(loginRequest.Email);
            if (user is null)
            {
                throw new Exception("Invalid Email or POassword");

            }

            if (!await _userManager.IsEmailConfirmedAsync(user))
            {
                throw new Exception("please confirm your email");
            }
            var IsPassValid = await _userManager.CheckPasswordAsync(user, loginRequest.Password);
            if (!IsPassValid)
            {
                throw new Exception("Invalid Email or POassword");
            }



            return new UserResponse
            {
                Token = await CreateTokenAsync(user)
            };

        }
        public async Task<string> ConfirmEmail(string token, string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user is null)
            {
                throw new Exception("user not found");
            }
            var result = await _userManager.ConfirmEmailAsync(user, token);
            if (result.Succeeded)
            {
                return "Email confirmed successfully";
            }
            return "email confirmation failed";
        }

        public async Task<UserResponse> RegisterAsync(RegisterRequest registerRequest)
        {
            var user = new ApplicationUser()
            {
                FullName = registerRequest.FullName,
                Email = registerRequest.Email,
                PhoneNumber = registerRequest.PhoneNumber,
                UserName = registerRequest.UserName,
            };
            var Result = await _userManager.CreateAsync(user, registerRequest.Password);
            if (Result.Succeeded)
            {
                var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var escapeToken = Uri.UnescapeDataString(token);
                var emailUrl = $"https://localhost:7205/api/identity/Account/ConfirmEmail?token={escapeToken}&userId={user.Id}";
                await _emilSender.SendEmailAsync(user.Email, "Welcome", $"<h1>Hello {user.UserName}</h1>" + $"<a href='{emailUrl}'>Confirm</a>");
                return new UserResponse()
                {
                    Token = registerRequest.Email,
                };
            }
            else
            {
                throw new Exception($"{Result.Errors}");
            }

        }
        private async Task<string> CreateTokenAsync(ApplicationUser user)
        {
            var Claims = new List<Claim>
            {
                new Claim (ClaimTypes.Email, user.Email),
                  new Claim (ClaimTypes.Name, user.UserName),

                      new Claim (ClaimTypes.NameIdentifier, user.Id),
            };
            var Roles = await _userManager.GetRolesAsync(user);
            foreach (var role in Roles)
            {
                Claims.Add(new Claim(ClaimTypes.Role, role));
            }
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("jwtOptions")["SecretKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: Claims,
                expires: DateTime.Now.AddDays(15),
                signingCredentials: credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<bool> ForgotPassword(ForgotPasswordRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user is null) throw new Exception("user not found");

            var random = new Random();
            var code = random.Next(1000, 9999).ToString();

            user.CodeResetPassword = code;

            user.PasswordResetCodeExpiry = DateTime.UtcNow.AddMinutes(15);
            await _userManager.UpdateAsync(user);
            await _emilSender.SendEmailAsync(request.Email, "reset password", $"<p>code is {code} </p>");
            return true;
        }

        public async Task<bool> ResetPassword(ResetPasswordRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user is null) throw new Exception("user not found");

            if (user.CodeResetPassword != request.Code) return false;
            if (user.PasswordResetCodeExpiry < DateTime.UtcNow) return false;
            var token = await _userManager.GeneratePasswordResetTokenasync(user);
            var result = await _userManager.ResetPasswordAsync(user, token, request.NewPassword);
            if (result.Succeeded)

                await _emilSender.SendEmailAsync(request.Email, "Change Password", "<h1> your password is changed </h1>");
            return true;
        }
    }

    }

