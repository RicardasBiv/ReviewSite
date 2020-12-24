using BackEnd.Data.Contracts.Requests;
using BackEnd.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;


namespace BackEnd.Controllers
{
    [Route("api")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly RoleManager<Role> _roleManager;
        private readonly UserManager<Naudotojas> _userManager;
        private readonly SignInManager<Naudotojas> _signInManager;

        public AuthenticationController(RoleManager<Role> roleManager, UserManager<Naudotojas> userManager, SignInManager<Naudotojas> signInManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest registerRequest)
        {
            var userExist = await _userManager.FindByNameAsync(registerRequest.Username);
            if (userExist != null)
            {
                return BadRequest($"user with the username = {registerRequest.Username} already exists");
            }
            var user = new Naudotojas
            {
                UserName = registerRequest.Username,
                Email = registerRequest.Email,
                SecurityStamp = Guid.NewGuid().ToString()
            };
            var result = await _userManager.CreateAsync(user, registerRequest.Password);
            if (!result.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            await _userManager.AddToRoleAsync(user, "User");
            return Ok("User registered successfully");
        }


        [HttpPost("register/admin")]
        public async Task<IActionResult> RegisterAdmin([FromBody] RegisterRequest registerRequest)
        {
            var userExist = await _userManager.FindByNameAsync(registerRequest.Username);
            if (userExist != null)
            {
                return BadRequest($"user with the username = {registerRequest.Username} already exists");
            }
            var user = new Naudotojas
            {
                UserName = registerRequest.Username,
                Email = registerRequest.Email,
                SecurityStamp = Guid.NewGuid().ToString()
            };
            var result = await _userManager.CreateAsync(user, registerRequest.Password);
            if (!result.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            if (await _roleManager.FindByNameAsync("Admin") == null)
            {
                await _roleManager.CreateAsync(new Role() { Name = "Admin" });
            }
            if (await _roleManager.FindByNameAsync("User") == null)
            {
                await _roleManager.CreateAsync(new Role() { Name = "User" });
            }
            await _userManager.AddToRoleAsync(user, "Admin");
            return Ok("Admin registered successfully");
        }

        [HttpPost("register/writer")]
        public async Task<IActionResult> RegisterWriter([FromBody] RegisterRequest registerRequest)
        {
            var userExist = await _userManager.FindByNameAsync(registerRequest.Username);
            if (userExist != null)
            {
                return BadRequest($"user with the username = {registerRequest.Username} already exists");
            }
            var user = new Naudotojas
            {
                UserName = registerRequest.Username,
                Email = registerRequest.Email,
                SecurityStamp = Guid.NewGuid().ToString()
            };
            var result = await _userManager.CreateAsync(user, registerRequest.Password);
            if (!result.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            if (await _roleManager.FindByNameAsync("Writer") == null)
            {
                await _roleManager.CreateAsync(new Role() { Name = "Writer" });
            }
            if (await _roleManager.FindByNameAsync("User") == null)
            {
                await _roleManager.CreateAsync(new Role() { Name = "User" });
            }
            await _userManager.AddToRoleAsync(user, "Writer");
            return Ok("Writer registered successfully");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            var loginResult = await _signInManager.PasswordSignInAsync(loginRequest.Username, loginRequest.Password, false, false);
            if (!loginResult.Succeeded)
            {
                return BadRequest();
            }
            var user = await _userManager.FindByNameAsync(loginRequest.Username);
            var roles = await _userManager.GetRolesAsync(user);
            var claims = await _userManager.GetClaimsAsync(user);

            //creating token
            if (claims == null)
            {
                claims = new Claim[] { };
            }
            var claimsList = claims.Concat(new[]
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Role, string.Join(",", roles))
            });
            var signinKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("secretToVerifyJwtTokens"));
            var signingCredentials = new SigningCredentials(signinKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                signingCredentials: signingCredentials,
                claims: claimsList,
                expires: DateTime.UtcNow.AddMinutes(60)
            );
            return Ok(new JwtSecurityTokenHandler().WriteToken(token));
        }
    }
}
