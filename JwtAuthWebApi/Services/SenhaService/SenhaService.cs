using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using JwtAuthWebApi.Models;
using Microsoft.IdentityModel.Tokens;

namespace JwtAuthWebApi.Services.SenhaService
{
    public class SenhaService : SenhaInterface
    {
        private readonly IConfiguration _configuration;
        public SenhaService(IConfiguration config) 
        { 
            _configuration = config;
        }

        public void HashPassword(string password, out byte[] hashpass, out byte[] saltpass)
        {
            using(var hmac = new HMACSHA512())
            {
                saltpass = hmac.Key;
                hashpass = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public bool ValidatePassword(string password, byte[] hashpass, byte[] saltpass) 
        {
            using (var hmac = new HMACSHA512(saltpass))
            {
                var hash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return hashpass.SequenceEqual(hash);
            }
        }

        public string GenToken(UsuarioModel usuario) 
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim("Cargo", usuario.Cargo.ToString()),
                new Claim("Email", usuario.Email),
                new Claim("Usuário", usuario.Usuario)
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("JwtConfig:TokenKey").Value));

            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims, 
                expires: DateTime.Now.AddDays(1), 
                signingCredentials: cred
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}
