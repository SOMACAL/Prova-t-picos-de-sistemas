using Microsoft.EntityFrameworkCore;
namespace Italo.Models;

public class AppDbContext : DbContext
{
    public DbSet<Funcionario> Funcionarios { get; set; }
    public DbSet<FolhaPag> FolhaPags { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=Italo_Caio.db");
    }
}