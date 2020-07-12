using ECommerceAPI.Models;
using ECommerceAPI.Models.Authentification;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace ECommerceAPI.Models
{
    public class ECommerceAPIContext : IdentityDbContext
    {



        public ECommerceAPIContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Categorie> Categories { get; set; }
        public DbSet<Commande> Commandes { get; set; }
        public DbSet<EtatCmd> EtatCmds { get; set; }
        public DbSet<Facture> Factures { get; set; }
        public DbSet<Fournisseur> Fournisseurs { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Marque> Marques { get; set; }
        // public DbSet<Role> Roles { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Utilisateur> Utilisateurs { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            {
                //one to many categories and article
                modelBuilder.Entity<Categorie>()
               .HasMany(a => a.Articles)
               .WithOne(x => x.Categorie)
               .HasForeignKey(y =>y.IdCategorie);


                //one to many marque and article
                modelBuilder.Entity<Marque>()
               .HasMany(a => a.Articles)
               .WithOne(x => x.Marque)
               .HasForeignKey(y => y.IdMarque);

                //one to many Fournisseur and article
                modelBuilder.Entity<Fournisseur>()
               .HasMany(a => a.Articles)
               .WithOne(x => x.Fournisseur)
               .HasForeignKey(y => y.IdFournisseur);

                //one to many article and images
                modelBuilder.Entity<Article>()
               .HasMany(p => p.Images)
               .WithOne(x => x.Article)
               .HasForeignKey(y => y.IdArticle);
                // one to many ville and users
                modelBuilder.Entity<Ville>()
               .HasMany(p => p.Utilisateurs)
               .WithOne(x => x.Ville)
               .HasForeignKey(y => y.IdVille );
                //one to one user and image
                modelBuilder.Entity<Utilisateur>()
               .HasOne(p => p.Image)
               .WithOne(x => x.Utilisateur)
               .HasForeignKey<Image>(y => y.IdUser);
                // one to many role and user 
                modelBuilder.Entity<Role>()
                 .HasMany(p => p.Utilisateurs)
                 .WithOne(x => x.Role)
                 .HasForeignKey(y => y.IdRole);
                // one to many EtatCmd and Commande 
                modelBuilder.Entity<EtatCmd>()
                .HasMany(p => p.Commandes)
                .WithOne(x => x.EtatCmd);
               
                // one to one Facture and Commandes 
                modelBuilder.Entity<Facture>()
                  .HasOne(p => p.Commande)
                  .WithOne(x => x.Facture)
                  .HasForeignKey<Commande>(y => y.IdFacture);
                // one to many commande and article 
                modelBuilder.Entity<Commande>()
                 .HasMany(p => p.Articles)
                 .WithOne(x => x.Commande);
                 
            }
        }



        public DbSet<ECommerceAPI.Models.Role> Role { get; set; }



        public DbSet<ECommerceAPI.Models.Ville> Ville { get; set; }






    }
}

