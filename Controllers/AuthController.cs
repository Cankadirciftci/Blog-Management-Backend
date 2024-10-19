using BlogManagement.Data;
using BlogManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Linq;
using BlogManagement.Dtos;
using BlogManagement.Mappers;

namespace BlogManagement.Controllers
{
    [Route("Api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly AppDbContext _context;

        public AuthController(IConfiguration config, AppDbContext context)
        {
            _config = config;
            _context = context;
        }

      
[HttpPost("login")]
public IActionResult Login([FromBody] LoginDto loginDto)
{
    var user = Authenticate(loginDto);
    if (user != null)
    {
        var token = GenerateToken(user);
        return Ok(new { token });
    }
    return Unauthorized();
}

private User Authenticate(LoginDto loginDto)
{
    // Kullanıcıyı veritabanından al
    var user = _context.Users.SingleOrDefault(u => u.Username == loginDto.Username);

    // Kullanıcı varsa ve şifre hash'leri eşleşiyorsa, kullanıcıyı döndür
    if (user != null && user.PasswordHash == loginDto.PasswordHash)
    {
        return user;
    }

    return null;
}

        private string GenerateToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(_config["Jwt:ExpireMinutes"])),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
