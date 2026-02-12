using Fechas_Importantes.Models;
using Microsoft.EntityFrameworkCore;

namespace Fechas_Importantes.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<FechaEspecial> FechasEspeciales { get; set; }
    }
}
