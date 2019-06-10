using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Ecommerce_.Models
{
    [Table("produto")]
    public class produto
    {
        [Key]
        public string produtoId { get; set; }
        public string nome { get; set; }
        public double preco { get; set; }
        public string descricao { get; set; }
        public bool vitrine { get; set; }
    }
}