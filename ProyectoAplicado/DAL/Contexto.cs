using Microsoft.EntityFrameworkCore;
using ProyectoAplicado.Models;

namespace ProyectoAplicado.DAL;

public class Contexto:DbContext
{
    public Contexto(DbContextOptions<Contexto>options)
    :base(options){ }   

    public DbSet<Bebidas> Bebidas { get; set; }
    public DbSet<Cocineros> Cocineros { get; set; }
    public DbSet<Comidas> Comidas { get; set; }
    public DbSet<Comanda> Comandas { get; set; }
    public DbSet<Mesa> Mesas { get; set; }
    public DbSet<Mesera> Meseras { get; set; }
     
}
