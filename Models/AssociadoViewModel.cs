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

      [Display(Name = "Plano de Saúde")]
      [Required(ErrorMessage = "Plano de Saúde obrigatório")]
      public long PlanoId { get; set; }

      [Display(Name = "CPF")]
      [Required(ErrorMessage = "CPF obrigatório")]
      public long CPF { get; set; }

      [Display(Name = "Nome Completo")]
      [Required(ErrorMessage = "Nome obrigatório")]
      [MaxLength(100)]
      public string Nome { get; set; }

      [Display(Name = "Data de Nascimento")]
      [Required(ErrorMessage = "Data de nascimento obrigatória")]
      public DateTime DataNascimento { get; set; }

      [Display(Name = "Nome da Mãe")]
      [Required(ErrorMessage = "Nome da mãe obrigatório")]
      public string NomeMae { get; set; }

      [Display(Name = "Nº CNS")]
      public long? CNS { get; set; }

      [Display(Name = "Nº Pis/Pasep")]
      public long? PisPasep { get; set; }

      [Display(Name = "E-mail")]
      [Required(ErrorMessage = "Email obrigatório")]
      [EmailAddress(ErrorMessage = "Email inválido")]
      public string Email { get; set; }

      [Display(Name = "Senha")]
      [Required(ErrorMessage = "Senha obrigatória")]
      [StringLength(255, ErrorMessage = "Deve ter entre 5 e 255 caracteres", MinimumLength = 5)]
      [DataType(DataType.Password)]
      public string Senha { get; set; }



      [Display(Name = "Tipo de Endereço")]
      [Required]
      public string TipoEndereco { get; set; }

      [Display(Name = "Logradouro")]
      [Required]
      public string Logradouro { get; set; }

      [Display(Name = "Nº")]
      [Required]
      public string Numero { get; set; }

      [Display(Name = "Bairro")]
      [Required]
      public string Bairro { get; set; }

      [Display(Name = "Cidade")]
      [Required]
      public string Cidade { get; set; }

      [Display(Name = "CEP")]
      [Required]
      public string CEP { get; set; }

      [Display(Name = "Estado")]
      [Required]
      public string UF { get; set; }

      [Display(Name = "Complemento")]
      public string Complemento { get; set; }

      [Display(Name = "País")]
      [Required]
      public string Pais { get; set; }



      [Display(Name = "Nº do Telefone")]
      [Required]
      public string NumeroTelefone { get; set; }

      [Display(Name = "DDI")]
      [Required]
      public string DDI { get; set; }

      [Display(Name = "DDD")]
      [Required]
      public string DDD { get; set; }

      [Display(Name = "Tipo de Telefone")]
      [Required]
      public string TipoTelefone { get; set; }




      [Display(Name = "Código do Banco")]
      [Required]
      public int BancoId { get; set; }

      [Display(Name = "Agência")]
      [Required]
      public string Agencia { get; set; }

      [Display(Name = "Dígito da Agência")]
      public string DigitoAgencia { get; set; }

      [Display(Name = "Nº da Conta")]
      [Required]
      public string Conta { get; set; }

      [Display(Name = "Dígito da Conta")]
      public string DigitoConta { get; set; }

      [Display(Name = "Tipo de Conta")]
      [Required]
      public string TipoConta { get; set; }
   }
}
