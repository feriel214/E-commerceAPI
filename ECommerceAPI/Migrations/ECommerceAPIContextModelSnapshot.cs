﻿// <auto-generated />
using System;
using ECommerceAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ECommerceAPI.Migrations
{
    [DbContext(typeof(ECommerceAPIContext))]
    partial class ECommerceAPIContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ECommerceAPI.Models.Article", b =>
                {
                    b.Property<Guid>("IdArticle")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("CommandeIdCommande");

                    b.Property<string>("DescArticle");

                    b.Property<string>("Designation");

                    b.Property<Guid>("IdCategorie");

                    b.Property<Guid>("IdFournisseur");

                    b.Property<Guid>("IdMarque");

                    b.Property<float>("QteStock");

                    b.Property<int>("TauxRemise");

                    b.Property<float>("TauxVal");

                    b.Property<float>("prix");

                    b.HasKey("IdArticle");

                    b.HasIndex("CommandeIdCommande");

                    b.HasIndex("IdCategorie");

                    b.HasIndex("IdFournisseur");

                    b.HasIndex("IdMarque");

                    b.ToTable("Articles");
                });

            modelBuilder.Entity("ECommerceAPI.Models.Categorie", b =>
                {
                    b.Property<Guid>("IdCategorie")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("LibCategorie");

                    b.HasKey("IdCategorie");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("ECommerceAPI.Models.Commande", b =>
                {
                    b.Property<Guid>("IdCommande")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<string>("Descreption");

                    b.Property<Guid?>("EtatCmdIdEtatCmd");

                    b.Property<Guid>("IdFacture");

                    b.HasKey("IdCommande");

                    b.HasIndex("EtatCmdIdEtatCmd");

                    b.HasIndex("IdFacture")
                        .IsUnique();

                    b.ToTable("Commandes");
                });

            modelBuilder.Entity("ECommerceAPI.Models.EtatCmd", b =>
                {
                    b.Property<Guid>("IdEtatCmd")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("LibEtatCmd");

                    b.HasKey("IdEtatCmd");

                    b.ToTable("EtatCmds");
                });

            modelBuilder.Entity("ECommerceAPI.Models.Facture", b =>
                {
                    b.Property<Guid>("IdFacture")
                        .ValueGeneratedOnAdd();

                    b.Property<float>("BaseHt");

                    b.Property<DateTime>("Date");

                    b.Property<float>("Remise");

                    b.Property<float>("TVA");

                    b.Property<float>("TotalHT");

                    b.Property<float>("TotalHTTC");

                    b.HasKey("IdFacture");

                    b.ToTable("Factures");
                });

            modelBuilder.Entity("ECommerceAPI.Models.Fournisseur", b =>
                {
                    b.Property<Guid>("IdFournisseur")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Adresse");

                    b.Property<string>("Descreption");

                    b.Property<string>("NomPrenom");

                    b.Property<string>("Tel");

                    b.Property<string>("email");

                    b.HasKey("IdFournisseur");

                    b.ToTable("Fournisseurs");
                });

            modelBuilder.Entity("ECommerceAPI.Models.Image", b =>
                {
                    b.Property<Guid>("IdImage")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("IdArticle");

                    b.Property<Guid>("IdUser");

                    b.Property<string>("NomImage");

                    b.HasKey("IdImage");

                    b.HasIndex("IdArticle");

                    b.HasIndex("IdUser")
                        .IsUnique();

                    b.ToTable("Images");
                });

            modelBuilder.Entity("ECommerceAPI.Models.Marque", b =>
                {
                    b.Property<Guid>("IdMarque")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("LibMarque");

                    b.HasKey("IdMarque");

                    b.ToTable("Marques");
                });

            modelBuilder.Entity("ECommerceAPI.Models.Role", b =>
                {
                    b.Property<Guid>("IdRole")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DescRole");

                    b.Property<string>("LibRole");

                    b.HasKey("IdRole");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("ECommerceAPI.Models.Utilisateur", b =>
                {
                    b.Property<Guid>("IdUser")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Adresse");

                    b.Property<Guid>("IdRole");

                    b.Property<Guid>("IdVille");

                    b.Property<string>("NomPrenom");

                    b.Property<string>("Tel");

                    b.Property<string>("email");

                    b.Property<string>("login");

                    b.Property<string>("password");

                    b.HasKey("IdUser");

                    b.HasIndex("IdRole");

                    b.HasIndex("IdVille");

                    b.ToTable("Utilisateurs");
                });

            modelBuilder.Entity("ECommerceAPI.Models.Ville", b =>
                {
                    b.Property<Guid>("IdVille")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("LibVille");

                    b.HasKey("IdVille");

                    b.ToTable("Ville");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("ECommerceAPI.Models.Authentification.ApplicationUser", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(150)");

                    b.ToTable("ApplicationUser");

                    b.HasDiscriminator().HasValue("ApplicationUser");
                });

            modelBuilder.Entity("ECommerceAPI.Models.Article", b =>
                {
                    b.HasOne("ECommerceAPI.Models.Commande", "Commande")
                        .WithMany("Articles")
                        .HasForeignKey("CommandeIdCommande");

                    b.HasOne("ECommerceAPI.Models.Categorie", "Categorie")
                        .WithMany("Articles")
                        .HasForeignKey("IdCategorie")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ECommerceAPI.Models.Fournisseur", "Fournisseur")
                        .WithMany("Articles")
                        .HasForeignKey("IdFournisseur")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ECommerceAPI.Models.Marque", "Marque")
                        .WithMany("Articles")
                        .HasForeignKey("IdMarque")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ECommerceAPI.Models.Commande", b =>
                {
                    b.HasOne("ECommerceAPI.Models.EtatCmd", "EtatCmd")
                        .WithMany("Commandes")
                        .HasForeignKey("EtatCmdIdEtatCmd");

                    b.HasOne("ECommerceAPI.Models.Facture", "Facture")
                        .WithOne("Commande")
                        .HasForeignKey("ECommerceAPI.Models.Commande", "IdFacture")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ECommerceAPI.Models.Image", b =>
                {
                    b.HasOne("ECommerceAPI.Models.Article", "Article")
                        .WithMany("Images")
                        .HasForeignKey("IdArticle")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ECommerceAPI.Models.Utilisateur", "Utilisateur")
                        .WithOne("Image")
                        .HasForeignKey("ECommerceAPI.Models.Image", "IdUser")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ECommerceAPI.Models.Utilisateur", b =>
                {
                    b.HasOne("ECommerceAPI.Models.Role", "Role")
                        .WithMany("Utilisateurs")
                        .HasForeignKey("IdRole")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ECommerceAPI.Models.Ville", "Ville")
                        .WithMany("Utilisateurs")
                        .HasForeignKey("IdVille")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
