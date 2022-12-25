using System.ComponentModel.DataAnnotations;

namespace API.Models.Dtos.Cinema
{
    public class ReadCinemaDto
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "Necessario adicionar nome!")]
        public string Nome { get; set; }
    }
}
