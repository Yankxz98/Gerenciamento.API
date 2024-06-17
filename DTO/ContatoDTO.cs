using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Gerenciamento.API.DTO
{
    public class ContatoDTO
    {
        [JsonIgnore]
        public int ContatoId { get; set; }

        [Required(ErrorMessage = "O campo Telefone é obrigatório.")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "O campo Email é obrigatório.")]
        [EmailAddress(ErrorMessage = "Informe um endereço de email válido.")]
        public string Email { get; set; }
    }
}
