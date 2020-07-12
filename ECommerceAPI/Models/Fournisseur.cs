using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceAPI.Models
{
    public class Fournisseur
    {
        public Fournisseur()
        {
            Articles = new HashSet<Article>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid IdFournisseur { get; set; }
        public string NomPrenom { get; set; }
        public string Tel { get; set; }
        public string Adresse { get; set; }
        public string email { get; set; }
        public string Descreption { get; set; }
        public ICollection<Article> Articles { get; set; }

    }
}
