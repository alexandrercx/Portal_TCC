using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServicoAssociadoWeb.Models
{
   public class LoginViewModel
   {
      [Display(Name = "E-mail")]
      [Required(ErrorMessage = "Email obrigatório")]
      [EmailAddress(ErrorMessage = "Email inválido")]
      public string Email { get; set; }

      [Display(Name = "Senha")]
      [Required(ErrorMessage = "Senha obrigatória")]
      [StringLength(255, ErrorMessage = "Deve ter entre 5 e 255 caracteres", MinimumLength = 5)]
      [DataType(DataType.Password)]
      public string Password { get; set; }
   }
}
