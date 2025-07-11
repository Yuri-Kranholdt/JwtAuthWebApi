using System.ComponentModel.DataAnnotations;

namespace JwtAuthWebApi.Dto
{
    public class UsuarioLoginDto
    {
        [Required(ErrorMessage = "Campo Email Obrigatório"), EmailAddress(ErrorMessage = "Email Inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo Senha Obrigatório")]
        public string Password { get; set; }
    }
}
