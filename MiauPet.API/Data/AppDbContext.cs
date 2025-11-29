using MiauPet.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MiauPet.API.Data;

public class AppDbContext : IdentityDbContext<Usuario>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Produto> Produtos { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        SeedUsuarioPadrao(builder);
        SeedCategoriaPadrao(builder);
        SeedProdutoPadrao(builder);
    }

    private static void SeedUsuarioPadrao(ModelBuilder builder)
    {
        #region Populate Roles - Perfis de Usuário
        List<IdentityRole> roles =
        [
            new IdentityRole() {
               Id = "0b44ca04-f6b0-4a8f-a953-1f2330d30894",
               Name = "Administrador",
               NormalizedName = "ADMINISTRADOR"
            },
            new IdentityRole() {
               Id = "ddf093a6-6cb5-4ff7-9a64-83da34aee005",
               Name = "Cliente",
               NormalizedName = "CLIENTE"
            },
        ];
        builder.Entity<IdentityRole>().HasData(roles);
        #endregion

        #region Populate Usuário
        List<Usuario> usuarios = [
            new Usuario(){
                Id = "ddf093a6-6cb5-4ff7-9a64-83da34aee005",
                Email = "lucas.garbi@hotmail.com",
                NormalizedEmail = "LUCAS.GARBI@HOTMAIL.COM",
                UserName = "lucas.garbi@hotmail.com",
                NormalizedUserName = "LUCAS.GARBI@HOTMAIL.COM",
                LockoutEnabled = true,
                EmailConfirmed = true,
                Nome = "Lucas Lanfredi Garbi",
                DataNascimento = DateTime.Parse("22/07/2004"),
                Foto = "/img/usuarios/avatar.png"
            }
        ];
        foreach (var user in usuarios)
        {
            PasswordHasher<Usuario> pass = new();
            user.PasswordHash = pass.HashPassword(user, "123456");
        }
        builder.Entity<Usuario>().HasData(usuarios);
        #endregion

        #region Populate UserRole - Usuário com Perfil
        List<IdentityUserRole<string>> userRoles =
        [
            new IdentityUserRole<string>() {
                UserId = usuarios[0].Id,
                RoleId = roles[0].Id
            }
        ];
        builder.Entity<IdentityUserRole<string>>().HasData(userRoles);
        #endregion
    }

    private static void SeedCategoriaPadrao(ModelBuilder builder)
    {
        List<Categoria> categorias = new()
        {
            // Criar suas categorias

            new Categoria {Id = 1, Nome = "Acessórios"},
            new Categoria {Id = 2, Nome = "Alimentação"},
            new Categoria {Id = 3, Nome = "Higiene"},
            new Categoria {Id = 4, Nome = "Mimos"},
            new Categoria {Id = 5, Nome = "Saúde"},

        };
        builder.Entity<Categoria>().HasData(categorias);
    }

    private static void SeedProdutoPadrao(ModelBuilder builder)
    {
        List<Produto> produtos = new()
        {
            // Criar seus produtos

            //categoria alimentacao
            new Produto {Id = 1, CategoriaId = 2, Nome = "PremierCookie", ValorCusto = 120.00m, ValorVenda = 100.00m, Qtde = 12, Destaque = true, Foto = "/img/produtos/alimentacao/Pet_1_Cao_PremierCookie.jpg"},
            new Produto {Id = 2, CategoriaId = 2, Nome = "Ração Pedigree", ValorCusto = 122.00m, ValorVenda = 60.00m, Qtde = 10, Destaque = true, Foto = "/img/produtos/alimentacao/RacMol_2_CaoG_Pedigree_100g.jpg",},

            // categoria acessorios
            new Produto {Id = 3, CategoriaId = 1, Nome = "Coleira de Gato AirTag", ValorCusto = 120.00m, ValorVenda = 100.00m, Qtde = 20, Destaque = true, Foto = "/img/produtos/acessorios/Ace_3_Gato_Airtag.jpg"},
            new Produto {Id = 4, CategoriaId = 1, Nome = "Vestido Pocoto em Jeans", ValorCusto = 110.00m, ValorVenda = 99.00m, Qtde = 12, Destaque = true, Foto = "/img/produtos/acessorios/Vestido-Pocoto-Pet-Kelly-em-Jeans.png"},
            

            //categoria saude
            new Produto {Id = 5, CategoriaId = 5, Nome = "Roupa Pós Cirúrgica Pet", ValorCusto = 126.00m, ValorVenda = 113.70m, Qtde = 15, Destaque = true, Foto = "/img/produtos/saude/roupa-pos-cirurgia.webp"},
            new Produto {Id = 6, CategoriaId = 5, Nome = "Vermifugo World Plus 30 Kg", ValorCusto = 30.00m, ValorVenda = 19.90m, Qtde = 10, Destaque = true, Foto = "/img/produtos/saude/Vermifugo.jpg"},
            new Produto {Id = 7, CategoriaId = 5, Nome = "Antipulgas Zoetis Simparic", ValorCusto = 110.00m, ValorVenda = 66.59m, Qtde = 10, Destaque = true, Foto = "/img/produtos/saude/simparic.jpg"},
            
            //categoria Higiene
            new Produto{Id = 8, CategoriaId = 3, Nome = "Tapete Higiênico Meau Premium", ValorCusto= 115.00m, ValorVenda= 92.70m, Qtde= 5, Destaque = true, Foto ="/img/produtos/higiene/tapeteHigienico.webp"},

            //mimos
            
        };
        builder.Entity<Produto>().HasData(produtos);
    }

}