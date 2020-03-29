using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ProjAgil.Dominio.Identity;
using ProjAgil.Dominio.ViewModels;

namespace ProjAgil.WebAPI.Controllers
{
    /// <summary>
    /// Controller de autenticação de usuário
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IMapper _mapper;

        /// <summary>
        /// Construtor
        /// </summary>
        public UserController(IConfiguration config, UserManager<User> userManager
            , SignInManager<User> signInManager
            , IMapper mapper)
        {
            this._config = config;
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._mapper = mapper;
        }

        /// <summary>
        /// Retorna os usuarios
        /// </summary>
        /// <returns></returns>
        // GET: api/User
        [HttpGet("GetUser")]
        public async Task<IActionResult> Get()
        {
            return Ok(new UserViewModel());
        }

        /// <summary>
        /// Registra o usuário informado
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        // POST: api/UserViewModel
        [HttpPost("Register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register(UserViewModel model)
        {
            try
            {
                var user = _mapper.Map<User>(model);
                var result = await _userManager.CreateAsync(user, model.Password);
                var userToReturn = _mapper.Map<UserViewModel>(user);

                if (result.Succeeded)
                {
                    return Created("GetUser", userToReturn);
                }

                return BadRequest(result.Errors);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco de dados Falhou {ex.Message}");
            }
        }

        /// <summary>
        /// Realizar o login do usuario
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(UserLoginViewMode model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);
            var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);

            if (result.Succeeded)
            {
                var appUser = await _userManager.Users
                      .FirstOrDefaultAsync(x => x.NormalizedUserName == model.UserName.ToUpper());

                var userToReturn = _mapper.Map<UserLoginViewMode>(appUser);

                return Ok(new
                {
                    token = GenerateJwtToken(appUser).Result,
                    user = userToReturn
                });
            }

            return Unauthorized();

        }

        private async Task<string> GenerateJwtToken(User _user)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, _user.Id.ToString()),
                new Claim(ClaimTypes.Name, _user.UserName),
            };

            var roles = await _userManager.GetRolesAsync(_user);

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var identityClaims = new ClaimsIdentity(claims);

            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_config.GetSection("AppSettings:Token").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = identityClaims,
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
        }
    }
}
