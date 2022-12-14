using System.ComponentModel.DataAnnotations;

namespace FilmeAPI.Models
{
    public class Filme
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "Necessário adicionar titulo no filme")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "Necessário adicionar diretor no filme")]
        public string Diretor { get; set; }
        [StringLength(100, ErrorMessage = "Genero com tamanho máximo de 100 caracteres")]
        public string Genero {  get ; set;  }
        [Range(1, 600)]
        public int Duracao { get; set; }
    }
}
