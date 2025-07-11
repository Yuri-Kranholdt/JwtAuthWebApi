using JwtAuthWebApi.Dto;
using JwtAuthWebApi.Models;

namespace JwtAuthWebApi.Services.AuthService
{
    public interface AuthInterface
    {
        Task<Response<UsuarioDto>> Registrar(UsuarioDto usuario);

        Task<Response<string>> Login(UsuarioLoginDto userDto);
    }
}
