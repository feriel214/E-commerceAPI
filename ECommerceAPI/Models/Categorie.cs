using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceAPI.Models
{
    public class Categorie
    {
        public Categorie()
        {
            Articles  = new HashSet<Article>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid IdCategorie { get; set; }
        public string LibCategorie { get; set; }

        public ICollection<Article> Articles { get; set; }
    }
}
