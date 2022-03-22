using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using UniClub.Domain.Entities;
using UniClub.HttpApi.Filters;
using UniClub.HttpApi.Utils;

namespace UniClub.HttpApi.ApiControllers.V1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<Person> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IOptions<AppSettings> _appSettings;

        public AuthenticationController(UserManager<Person> userManager, RoleManager<IdentityRole> roleManager, IOptions<AppSettings> _appSettings)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            this._appSettings = _appSettings;
        }

        [Route("login")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(TokenVerifyRequest request)
        {
            try
            {
                var auth = FirebaseAdmin.Auth.FirebaseAuth.DefaultInstance;
                var response = await auth.VerifyIdTokenAsync(request.Token);

                if (response != null)
                {
                    if (response.Claims.TryGetValue("email", out object email))
                    {
                        var user = await _userManager.FindByEmailAsync(email.ToString());

                        if (user == null || user.IsDeleted)
                        {
                            throw new Exception("Not found user");
                        }

                        var roles = await _userManager.GetRolesAsync(user);
                        var userClaims = await _userManager.GetClaimsAsync(user);

                        IDictionary<string, object> claims = new Dictionary<string, object>();
                        claims.Add("user_id", user.Id);
                        claims.Add("username", user.UserName);
                        claims.Add("email", user.Email);
                        claims.Add("name", user.Name);
                        claims.Add("image_url", user.ImageUrl);

                        foreach (var role in roles)
                        {
                            claims.Add("role", role);
                        }

                        foreach (var claim in userClaims)
                        {
                            claims.Add(claim.Type, claim.Value);
                        }



                        var token = generateJwtToken(user, claims);
                        if (token != null)
                        {
                            return Ok(new
                            {
                                token = token,
                                expire = 3600,
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
            //var user = await _userManager.FindByIdAsync("c59ea4ff-17cf-4a73-bdc5-e703eca5f7a6");
            //await _userManager.DeleteAsync(user);
            //return Ok();
        }

        private string generateJwtToken(Person user, IDictionary<string, object> claims)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Value.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id) }),
                Expires = DateTime.UtcNow.AddHours(1),
                Claims = claims,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

    }

    public class TokenVerifyRequest
    {
        public string Token { get; set; }
    }

}
