using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceAPI.Models
{
    public class Role
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid IdRole { get; set; }
        public string LibRole { get; set; }
        public string DescRole { get; set; }
        public ICollection<Utilisateur> Utilisateurs { get; set; }
    }
}
