using System.ComponentModel.DataAnnotations;

namespace API.Models.Dtos.Endereco
{
    public class CreateEnderecoDto
    {
        [Required(ErrorMessage = "Necessario enviar 'logradouro'")]
        public string Logradouro { get; set; }
        [Required(ErrorMessage = "Necessario enviar 'Numero'")]
        public int Numero { get; set; }
        [Required(ErrorMessage = "Necessario enviar 'Cidade'")]
        public string Cidade { get; set; }
        [Required(ErrorMessage = "Necessario enviar 'Estado'")]
        public string Estado { get; set; }
        public string Complemento { get; set; }
    }
}
