using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServicoAssociadoWeb.Models
{
    public class AssociadoViewModel
    {
        public long? Id { get; set; }

        [Required(ErrorMessage = "CPF obrigatório")]
        public long CPF { get; set; }

        [Required(ErrorMessage = "Nome obrigatório")]
        [MaxLength(100)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Data de nascimento obrigatória")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "Nome da mãe obrigatório")]
        public string NomeMae { get; set; }

        public long? CNS { get; set; }

        public long? PisPasep { get; set; }

        [Required(ErrorMessage = "Email obrigatório")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Senha obrigatória")]
        [StringLength(255, ErrorMessage = "Deve ter entre 5 e 255 caracteres", MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        
        
        
        [Required]
        public string TipoEndereco { get; set; }

        [Required]
        public string Logradouro { get; set; }

        [Required]
        public string Numero { get; set; }

        [Required]
        public string Bairro { get; set; }

        [Required]
        public string Cidade { get; set; }

        [Required]
        public string CEP { get; set; }

        [Required]
        public string UF { get; set; }

        public string Complemento { get; set; }

        [Required]
        public string Pais { get; set; }

       
        
        
        [Required]
        public string NumeroTelefone { get; set; }

        [Required]
        public string DDI { get; set; }

        [Required]
        public string DDD { get; set; }

        [Required]
        public string TipoTelefone { get; set; }




        [Required]
        public int BancoId { get; set; }

        [Required]
        public string Agencia { get; set; }

        public string DigitoAgencia { get; set; }

        [Required]
        public string Conta { get; set; }

        public string DigitoConta { get; set; }

        [Required]
        public string TipoConta { get; set; }
    }
}
