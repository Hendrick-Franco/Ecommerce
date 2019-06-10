using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Ecommerce_.Models
{
    [Table("endereco")]
    public class endereco
    {
        [Key]
        public string cep { get; set; }
        public string rua { get; set; }
        public string bairro { get; set; }
        public string cidade { get; set; }
        public int numeroResidencial { get; set; }
        public string uf { get; set; }
    }
}