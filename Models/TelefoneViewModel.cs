using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServicoAssociadoWeb.Models
{
    public class TelefoneViewModel
    {
        [Required]
        public string Numero { get; set; }

        [Required]
        public string DDI { get; set; }

        [Required]
        public string DDD { get; set; }

        [Required]
        public string TipoTelefone { get; set; }
    }
}
