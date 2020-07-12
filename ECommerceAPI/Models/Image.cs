using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceAPI.Models
{
    public class Image
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid IdImage { get; set; }
        public string NomImage { get; set;  }

        //relation with image
        public Guid IdArticle { get; set; }
        public Article Article { get; set; }
        //relation with image
        public Guid IdUser { get; set; }
        public Utilisateur Utilisateur { get; set; }
    }
}
