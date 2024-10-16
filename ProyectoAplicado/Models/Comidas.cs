using System.ComponentModel.DataAnnotations;

namespace ProyectoAplicado.Models;

    public class Comidas
    {
        [Key]
        public int ComidaId { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "El nombre solo puede contener letras y espacios.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La descripcion es obligatoria.")]
        [RegularExpression(@"^[a-zA-Z\s.,]+$", ErrorMessage = "La descripción solo puede contener letras, espacios, puntos y comas.")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "La categoría es obligatoria.")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "La categoría solo puede contener letras y espacios.")]
        public string Categoria { get; set; }

        [Required(ErrorMessage = "El precio es obligatorio.")]
        [Range(0.01, 200000.00, ErrorMessage = "El precio debe estar entre 0.01 y 200000.00.")]
        public decimal Precio { get; set; }

        [Required(ErrorMessage = "Colocame la disponibilidad.")]
        public string Disponibilidad { get; set; }

        [Required(ErrorMessage = "La foto es obligatoria.")]
        public string FotoURL { get; set; }
    }
