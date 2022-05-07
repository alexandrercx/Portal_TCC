using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServicoAssociadoWeb.Models
{
    public class EnderecoViewModel
    {
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
    }
}
