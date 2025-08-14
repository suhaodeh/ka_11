﻿using KASHOP.DAL.DTO.Responses;
using KASHOP.DAL.DTO.Requests;
using KASHOP.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Http;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity.Data;
using ForgotPasswordRequest = KASHOP.DAL.DTO.Requests.ForgotPasswordRequest;
using LoginRequest = KASHOP.DAL.DTO.Requests.LoginRequest;
using RegisterRequest = KASHOP.DAL.DTO.Requests.RegisterRequest;
using Azure.Core;
using Microsoft.AspNetCore.Http.HttpResults;

namespace KASHOP.PL.Area.Identity.Controllers
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Area("Identity")]
    public class AccountController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AccountController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("Register")]
        public async Task<ActionResult<UserResponse>> Register(RegisterRequest registerRequest)
        {
            var result = await _authenticationService.RegisterAsync(registerRequest);
            return Ok(result);
        }

        [HttpPost("Login")]
        public async Task<ActionResult<UserResponse>> Login(LoginRequest loginRequest)
        {
            var result = await _authenticationService.LoginAsync(loginRequest);
            return Ok(result);
        }
        [HttpGet("ConfirmEmail")]
        public async Task<ActionResult<string>> ConfirmEmail([FromQuery] string token, [FromQuery] string userId)
        {
            var result = await _authenticationService.ConfirmEmail(token, userId);
            return Ok(result);
        }

        [HttpPost("forgot-password")]
        public async Task<ActionResult<bool>> ForgotPassword([FromBody] ForgotPasswordRequest request)
        {
            var result = await _authenticationService.ForgotPassword(request);
            return Ok(result);
        }

        [HttpPatch("reset-password")]
        public async Task<ActionResult<string>> ResetPassword([FromBody] ResetPasswordRequest request)
        {
            var result = await _authenticationService.ResetPassword(request);

            return Ok(result);

        }
    }
}
