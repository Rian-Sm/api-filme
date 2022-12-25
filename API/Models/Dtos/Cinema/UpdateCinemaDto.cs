using System.ComponentModel.DataAnnotations;

namespace API.Models.Dtos.Cinema
{
    public class UpdateCinemaDto
    {
        [Required(ErrorMessage = "Necessario adicionar nome!")]
        public string Nome { get; set; }
    }
}
