using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceAPI.Models
{
    public class Facture
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid IdFacture { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public float BaseHt { get; set; }
        public float TVA { get; set; }
        public float  Remise { get; set; }
        public float TotalHT { get; set; }
        public float TotalHTTC { get; set; }

        
        public Commande Commande { get; set; }
    }
}
