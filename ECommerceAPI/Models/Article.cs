using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceAPI.Models
{
    public class Article
    {

        public Article()
        {
            Images = new HashSet<Image>();
           
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid IdArticle { get; set; }
        public float prix { get; set; }
        public string Designation { get; set; }
        public float  QteStock { get; set; }
        public float TauxVal { get; set; }
        public int TauxRemise { get; set; }
        public string DescArticle { get; set; }

        //relation with categorie 
        public Guid IdCategorie { get; set; }
        public Categorie Categorie { get; set; }


        public Guid IdMarque { get; set; }
        public Marque Marque { get; set; }


        public Guid IdFournisseur { get; set; }
        public Fournisseur Fournisseur { get; set; }

        public ICollection<Image> Images { get; set; }


       
        public Commande Commande { get; set; }
    }
}
