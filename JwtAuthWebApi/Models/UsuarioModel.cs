using JwtAuthWebApi.Enum;

namespace JwtAuthWebApi.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }

        public required string Usuario {  get; set; }

        public required string Email { get; set; }

        public CargoEnum Cargo { get; set; }

        public required byte[] SenhaHash { get; set; }

        public required byte[] SenhaSalt { get; set; }

        public DateTime DateTime { get; set; } = DateTime.Now;
    }
}
