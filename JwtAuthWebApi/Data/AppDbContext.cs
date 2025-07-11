using JwtAuthWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace JwtAuthWebApi.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<UsuarioModel> Usuarios { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
            
        }
    }
}
