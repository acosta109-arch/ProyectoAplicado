using System.ComponentModel.DataAnnotations;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Diagnostics.Metrics;

namespace ProyectoAplicado.Models;

public class Mesa
{
    [Key]
    public int MesaId { get; set; }

    [Required(ErrorMessage = "El número de la mesa es obligatorio.")]
    public int Numero { get; set; }

    [Required(ErrorMessage = "La capacidad de la mesa es obligatoria.")]
    public int Capacidad { get; set; }

    [Required(ErrorMessage = "El estado de la mesa es obligatorio.")]
    public string? Estado { get; set; } // Libre, Ocupada, Reservada

    public int? MeseraId { get; set; }
    public Mesera? Mesera { get; set; }
    public List<Comanda> Comandas { get; set; } = new List<Comanda>();
}
