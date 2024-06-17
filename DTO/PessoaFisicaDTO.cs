using GerenciamentoAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace Gerenciamento.API.DTO
{
    public class PessoaFisicaDTO
    {
        public int IDCliente { get; set; }

        [Required(ErrorMessage = "O campo Nome Completo é obrigatório.")]
        public string NomeCompleto { get; set; }

        [Required(ErrorMessage = "O campo CPF é obrigatório.")]
        public string CPF { get; set; }

        public DateTime DataNascimento { get; set; }

        public string Endereco { get; set; }

        [Required(ErrorMessage = "É necessário fornecer pelo menos um contato (Telefone ou Email).")]
        public Contato Contatos { get; set; }
    }
}
