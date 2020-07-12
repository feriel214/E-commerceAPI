using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceAPI.Models
{
    public class Commande
    {
        public Commande()
        {
            Articles = new HashSet<Article>();

        }


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid IdCommande { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public string Descreption { get; set; }
        //relation commande and EtatCommande 
       
        public EtatCmd EtatCmd { get; set; }
        // relation facture and commande 
        public Guid IdFacture { get; set; }
        public Facture Facture { get; set; }

        public ICollection<Article> Articles { get; set; }
       
    }
}
