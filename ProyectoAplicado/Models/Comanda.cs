using System.ComponentModel.DataAnnotations;
namespace ProyectoAplicado.Models;

public class Comanda
{
    [Key]
    public int ComandaId { get; set; }

    [Required(ErrorMessage = "Es obligatorio asignar la mesa.")]
    public int MesaId { get; set; }

    public Mesa? Mesa { get; set; }

    public int? MeseraId { get; set; }
    public Mesera? Mesera { get; set; }

    public int? CocineroId { get; set; }
    public Cocineros? Cocinero { get; set; }

    [Required(ErrorMessage = "El estado de la comanda es obligatorio.")]
    public string? Estado { get; set; } // En preparación, Listo, Servido

    [Required(ErrorMessage = "La fecha y hora son obligatorias.")]
    public DateTime FechaHora { get; set; } = DateTime.Now;

    public List<Comidas> Comidas { get; set; } = new List<Comidas>();
}
