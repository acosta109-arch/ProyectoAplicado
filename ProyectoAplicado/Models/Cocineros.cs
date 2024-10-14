using System.ComponentModel.DataAnnotations;

namespace ProyectoAplicado.Models;

public class Cocineros
{
    [Key]
    public int CocineroId { get; set; }

    [Required(ErrorMessage = "El nombre completo es obligatorio.")]
    [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "El nombre completo solo puede contener letras.")]
    public string NombreCompleto { get; set; }

    [Required(ErrorMessage = "La especialidad es obligatoria.")]
    [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "La especialidad solo puede contener letras.")]
    public string Especialidad { get; set; }

    [Required(ErrorMessage = "El teléfono es obligatorio.")]
    [RegularExpression(@"^\d{10}$", ErrorMessage = "El teléfono debe tener exactamente 10 dígitos.")]
    public string Telefono { get; set; }

    [Required(ErrorMessage = "El estado es obligatorio.")]
    [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "El estado solo puede contener letras.")]
    public string Estado { get; set; }
}
