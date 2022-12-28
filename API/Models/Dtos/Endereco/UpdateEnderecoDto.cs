using System.ComponentModel.DataAnnotations;

namespace API.Models.Dtos.Endereco
{
    public class UpdateEnderecoDto
    {
        public string Logradouro { get; set; }
        public string Bairo { get; set; }
        public int Numero { get; set; }
    }
}
