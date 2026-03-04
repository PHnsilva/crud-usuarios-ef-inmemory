using CadastroApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CadastroApi.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    // NÃO use ISet aqui
    public DbSet<Usuario> Usuarios => Set<Usuario>();
}