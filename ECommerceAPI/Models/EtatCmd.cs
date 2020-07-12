using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceAPI.Models
{
    public class EtatCmd
    {

        public EtatCmd()
        {
            Commandes = new HashSet<Commande>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid IdEtatCmd { get; set; }
        public string LibEtatCmd { get; set; }
        public ICollection<Commande> Commandes  { get; set; }

        
    }
}
