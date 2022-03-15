﻿using FirebaseAdmin.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using UniClub.Application.Interfaces;
using UniClub.Application.Models;
using UniClub.Domain.Entities;
using UniClub.HttpApi.Utils;

namespace UniClub.HttpApi.ApiControllers.V1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<Person> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IJwtUtils _jwt;
        private readonly IOptions<AppSettings> _appSettings;

        public AuthenticationController(UserManager<Person> userManager, RoleManager<IdentityRole> roleManager, IJwtUtils jwt, IOptions<AppSettings> _appSettings)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _jwt = jwt;
            this._appSettings = _appSettings;
        }

        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> Login(TokenVerifyRequest request)

        {
            try
            {
                var auth = FirebaseAuth.DefaultInstance;
                var response = await auth.VerifyIdTokenAsync(request.Token);

                if (response != null)
                {
                    if (response.Claims.TryGetValue("email", out object email))
                    {
                        var user = await _userManager.FindByEmailAsync(email.ToString());

                        if (user == null)
                        {
                            throw new Exception("Not found user");
                        }

                        var roles = await _userManager.GetRolesAsync(user);
                        var claims = await _userManager.GetClaimsAsync(user);

                        claims.Add(new Claim("user_id", user.Id));
                        claims.Add(new Claim("username", user.UserName));
                        claims.Add(new Claim("name", user.Name));
                        claims.Add(new Claim("role", user.Email));
                        foreach (var role in roles)
                        {
                            claims.Add(new Claim(ClaimTypes.Role, role));
                        }

                        var token = _jwt.GenerateToken(user, claims);
                        if (token != null)
                        {
                            return Ok(new
                            {
                                token = token,
                                expire = 10800,
                            });
                        }
                    }
                }

                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
