using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceAPI.Models
{
    public class Utilisateur
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid IdUser { get; set; }
        public string NomPrenom { get; set; }
        public string Tel { get; set; }
        public string Adresse { get; set; }
        public string email { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public Image Image { get; set; }
        public Guid IdVille { get; set; }
        public Ville Ville { get; set; }

        public Guid IdRole { get; set; }
        public Role Role { get; set; }
    }
}
