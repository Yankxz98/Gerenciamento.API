using System.ComponentModel.DataAnnotations;

namespace GerenciamentoAPI.Models
{
    public class PessoaJuridica
    {
        [Key]
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

