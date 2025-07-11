using JwtAuthWebApi.Data;
using JwtAuthWebApi.Dto;
using JwtAuthWebApi.Models;
using JwtAuthWebApi.Services.SenhaService;
using Microsoft.EntityFrameworkCore;

namespace JwtAuthWebApi.Services.AuthService
{
    public class AuthService : AuthInterface
    {
        private readonly AppDbContext _context;
        private readonly SenhaInterface _senhaInterface;

        public AuthService(AppDbContext context, SenhaInterface si)
        {
            _context = context;
            _senhaInterface = si;
        }


        public async Task<Response<UsuarioDto>> Registrar(UsuarioDto usuario)
        {
            Response<UsuarioDto> response = new Response<UsuarioDto>();

            try
            {
                if (ExistUserEmail(usuario)) 
                {
                    response.Mensagem = "Email/Usuário já cadastrado";
                    response.status = false;
                    return response;
                }

                _senhaInterface.HashPassword(usuario.Senha, out byte[] hashpass, out byte[] saltpass);

                var new_user = new UsuarioModel
                {
                    Usuario = usuario.Usuario,
                    Email = usuario.Email,
                    SenhaHash = hashpass,
                    SenhaSalt = saltpass,
                    Cargo = usuario.Cargo,

                };

                _context.Usuarios.Add(new_user);
                await _context.SaveChangesAsync();

                response.Dados = usuario;
                response.Mensagem = "Usuário cadastrado com sucesso";
            }
            catch (Exception ex) 
            { 
                response.Mensagem = ex.Message;
                response.status = false;
            }
            return response;

        }

        public bool ExistUserEmail(UsuarioDto usuario) 
        {
            var user = _context.Usuarios.FirstOrDefault(x => x.Email == usuario.Email || x.Usuario == usuario.Usuario);
            return user != null ? true : false;
        }

        public async Task<Response<string>> Login(UsuarioLoginDto userDto)
        {
            Response<string> response = new Response<string>();

            try
            {
                var user = await _context.Usuarios.FirstOrDefaultAsync(x =>  x.Email == userDto.Email);

                if (user == null) 
                {
                    response.Mensagem = "Usuário ou Senha incorretos";
                    response.status = false;
                    return response;
                }

                if (!_senhaInterface.ValidatePassword(userDto.Password, user.SenhaHash, user.SenhaSalt))
                {
                    response.Mensagem = "Usuário ou Senha incorretossss";
                    response.status = false;
                    return response;
                }

                var token = _senhaInterface.GenToken(user);

                response.Dados = token;
                response.Mensagem = "Usuário logado com sucesso";
            }
            catch(Exception ex)  
            {
                response.Mensagem = ex.Message;
                response.status = false;
            }
            return response;
        }
    }
}
