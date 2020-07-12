using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceAPI.Models
{
    public class Marque
    {
        public Marque()
        {
            Articles = new HashSet<Article>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid IdMarque { get; set; }
        public string LibMarque { get; set; }
        public ICollection<Article> Articles { get; set; }
       
    }
}
