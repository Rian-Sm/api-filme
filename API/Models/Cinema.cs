using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Cinema
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Necessario adicionar nome!")]
        public string Nome { get; set; }

    }
}
