using GerenciamentoAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace Gerenciamento.API.DTO
{
    public class PessoaJuridicaDTO
    {
        public int IDCliente { get; set; }

        [Required(ErrorMessage = "O campo Razão Social é obrigatório.")]
        public string RazaoSocial { get; set; }

        [Required(ErrorMessage = "O campo CNPJ é obrigatório.")]
        public string CNPJ { get; set; }
        public string NomeFantasia { get; set; }
        public string Endereco { get; set; }

        [Required(ErrorMessage = "É necessário fornecer pelo menos um contato (Telefone ou Email).")]
        public Contato Contatos { get; set; }
    }
}
