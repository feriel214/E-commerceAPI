using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerceAPI.Migrations
{
    public partial class fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    IdCategorie = table.Column<Guid>(nullable: false),
                    LibCategorie = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.IdCategorie);
                });

            migrationBuilder.CreateTable(
                name: "EtatCmds",
                columns: table => new
                {
                    IdEtatCmd = table.Column<Guid>(nullable: false),
                    LibEtatCmd = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EtatCmds", x => x.IdEtatCmd);
                });

            migrationBuilder.CreateTable(
                name: "Factures",
                columns: table => new
                {
                    IdFacture = table.Column<Guid>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    BaseHt = table.Column<float>(nullable: false),
                    TVA = table.Column<float>(nullable: false),
                    Remise = table.Column<float>(nullable: false),
                    TotalHT = table.Column<float>(nullable: false),
                    TotalHTTC = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factures", x => x.IdFacture);
                });

            migrationBuilder.CreateTable(
                name: "Fournisseurs",
                columns: table => new
                {
                    IdFournisseur = table.Column<Guid>(nullable: false),
                    NomPrenom = table.Column<string>(nullable: true),
                    Tel = table.Column<string>(nullable: true),
                    Adresse = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    Descreption = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fournisseurs", x => x.IdFournisseur);
                });

            migrationBuilder.CreateTable(
                name: "Marques",
                columns: table => new
                {
                    IdMarque = table.Column<Guid>(nullable: false),
                    LibMarque = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marques", x => x.IdMarque);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    IdRole = table.Column<Guid>(nullable: false),
                    LibRole = table.Column<string>(nullable: true),
                    DescRole = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.IdRole);
                });

            migrationBuilder.CreateTable(
                name: "Ville",
                columns: table => new
                {
                    IdVille = table.Column<Guid>(nullable: false),
                    LibVille = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ville", x => x.IdVille);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Commandes",
                columns: table => new
                {
                    IdCommande = table.Column<Guid>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Descreption = table.Column<string>(nullable: true),
                    EtatCmdIdEtatCmd = table.Column<Guid>(nullable: true),
                    IdFacture = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commandes", x => x.IdCommande);
                    table.ForeignKey(
                        name: "FK_Commandes_EtatCmds_EtatCmdIdEtatCmd",
                        column: x => x.EtatCmdIdEtatCmd,
                        principalTable: "EtatCmds",
                        principalColumn: "IdEtatCmd",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Commandes_Factures_IdFacture",
                        column: x => x.IdFacture,
                        principalTable: "Factures",
                        principalColumn: "IdFacture",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Utilisateurs",
                columns: table => new
                {
                    IdUser = table.Column<Guid>(nullable: false),
                    NomPrenom = table.Column<string>(nullable: true),
                    Tel = table.Column<string>(nullable: true),
                    Adresse = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    login = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: true),
                    IdVille = table.Column<Guid>(nullable: false),
                    IdRole = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilisateurs", x => x.IdUser);
                    table.ForeignKey(
                        name: "FK_Utilisateurs_Role_IdRole",
                        column: x => x.IdRole,
                        principalTable: "Role",
                        principalColumn: "IdRole",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Utilisateurs_Ville_IdVille",
                        column: x => x.IdVille,
                        principalTable: "Ville",
                        principalColumn: "IdVille",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    IdArticle = table.Column<Guid>(nullable: false),
                    prix = table.Column<float>(nullable: false),
                    Designation = table.Column<string>(nullable: true),
                    QteStock = table.Column<float>(nullable: false),
                    TauxVal = table.Column<float>(nullable: false),
                    TauxRemise = table.Column<int>(nullable: false),
                    DescArticle = table.Column<string>(nullable: true),
                    IdCategorie = table.Column<Guid>(nullable: false),
                    IdMarque = table.Column<Guid>(nullable: false),
                    IdFournisseur = table.Column<Guid>(nullable: false),
                    CommandeIdCommande = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.IdArticle);
                    table.ForeignKey(
                        name: "FK_Articles_Commandes_CommandeIdCommande",
                        column: x => x.CommandeIdCommande,
                        principalTable: "Commandes",
                        principalColumn: "IdCommande",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Articles_Categories_IdCategorie",
                        column: x => x.IdCategorie,
                        principalTable: "Categories",
                        principalColumn: "IdCategorie",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Articles_Fournisseurs_IdFournisseur",
                        column: x => x.IdFournisseur,
                        principalTable: "Fournisseurs",
                        principalColumn: "IdFournisseur",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Articles_Marques_IdMarque",
                        column: x => x.IdMarque,
                        principalTable: "Marques",
                        principalColumn: "IdMarque",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    IdImage = table.Column<Guid>(nullable: false),
                    NomImage = table.Column<string>(nullable: true),
                    IdArticle = table.Column<Guid>(nullable: false),
                    IdUser = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.IdImage);
                    table.ForeignKey(
                        name: "FK_Images_Articles_IdArticle",
                        column: x => x.IdArticle,
                        principalTable: "Articles",
                        principalColumn: "IdArticle",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Images_Utilisateurs_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Utilisateurs",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_CommandeIdCommande",
                table: "Articles",
                column: "CommandeIdCommande");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_IdCategorie",
                table: "Articles",
                column: "IdCategorie");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_IdFournisseur",
                table: "Articles",
                column: "IdFournisseur");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_IdMarque",
                table: "Articles",
                column: "IdMarque");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Commandes_EtatCmdIdEtatCmd",
                table: "Commandes",
                column: "EtatCmdIdEtatCmd");

            migrationBuilder.CreateIndex(
                name: "IX_Commandes_IdFacture",
                table: "Commandes",
                column: "IdFacture",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Images_IdArticle",
                table: "Images",
                column: "IdArticle");

            migrationBuilder.CreateIndex(
                name: "IX_Images_IdUser",
                table: "Images",
                column: "IdUser",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Utilisateurs_IdRole",
                table: "Utilisateurs",
                column: "IdRole");

            migrationBuilder.CreateIndex(
                name: "IX_Utilisateurs_IdVille",
                table: "Utilisateurs",
                column: "IdVille");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "Utilisateurs");

            migrationBuilder.DropTable(
                name: "Commandes");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Fournisseurs");

            migrationBuilder.DropTable(
                name: "Marques");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Ville");

            migrationBuilder.DropTable(
                name: "EtatCmds");

            migrationBuilder.DropTable(
                name: "Factures");
        }
    }
}
