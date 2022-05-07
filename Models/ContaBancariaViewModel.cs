using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServicoAssociadoWeb.Models
{
    public class ContaBancariaViewModel
    {
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
