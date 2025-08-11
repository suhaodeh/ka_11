using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KASHOP.DAL.DTO.Requests;
using KASHOP.DAL.DTO.Responses;
using Microsoft.AspNetCore.Identity.Data;
using LoginRequest = KASHOP.DAL.DTO.Requests.LoginRequest;
using RegisterRequest = KASHOP.DAL.DTO.Requests.RegisterRequest;

namespace KASHOP.BLL.Services.Interfaces
{
  public  interface IAuthenticationService
    {
        Task<UserResponse>LoginAsync(LoginRequest loginRequest);
        Task<UserResponse> RegisterAsync(RegisterRequest registerRequest);
        Task<string> ConfirmEmail(string token,string userId);
        Task<bool> ForgotPassword(ForgotPasswordRequest request);
         Task<bool> ResetPassword(ResetPasswordRequest request)

    }
}
