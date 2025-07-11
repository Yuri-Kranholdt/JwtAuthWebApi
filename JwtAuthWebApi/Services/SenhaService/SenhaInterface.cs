using JwtAuthWebApi.Models;

namespace JwtAuthWebApi.Services.SenhaService
{
    public interface SenhaInterface
    {
        void HashPassword(string password, out byte[] hashpass, out byte[] saltpass);

        bool ValidatePassword(string password, byte[] hashpass, byte[] saltpass);

        string GenToken(UsuarioModel usuario);
    }
}
