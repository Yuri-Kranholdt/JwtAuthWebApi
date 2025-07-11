using System.ComponentModel.DataAnnotations;
using JwtAuthWebApi.Enum;

namespace JwtAuthWebApi.Dto
{
    public class UsuarioDto
    {
        [Required(ErrorMessage = "Campo Usuário Obrigatório")]
        public required string Usuario { get; set; }

        [Required(ErrorMessage = "Campo Email Obrigatório"), EmailAddress(ErrorMessage ="Email Inválido")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "Campo Senha Obrigatório")]
        public required string Senha { get; set; }

        [Compare("Senha", ErrorMessage = "As Senhas devem ser iguais")]
        public required string ConfirmaSenha { get; set; }

        [Required(ErrorMessage = "Campo Cargo Obrigatório")]
        public CargoEnum Cargo { get; set; }
    }
}
