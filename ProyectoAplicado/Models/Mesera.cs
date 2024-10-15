using System.ComponentModel.DataAnnotations;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
namespace ProyectoAplicado.Models;
public class Mesera
{
    [Key]
    public int MeseraId { get; set; }

    [Required(ErrorMessage = "El nombre de la mesera es obligatorio.")]
    [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "El nombre solo puede contener letras.")]
    public string? Nombre { get; set; }

    [Required(ErrorMessage = "El apellido de la mesera es obligatorio.")]
    [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "El apellido solo puede contener letras.")]
    public string? Apellido { get; set; }

    [Required(ErrorMessage = "El teléfono de la mesera es obligatorio.")]
    [RegularExpression(@"^\d{10}$", ErrorMessage = "El teléfono debe tener 10 dígitos.")]
    public string? Telefono { get; set; }

    public List<Mesa> Mesas { get; set; } = new List<Mesa>();
    public List<Comanda> Comandas { get; set; } = new List<Comanda>();
}
