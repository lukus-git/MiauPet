using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using MiauPet.API.Models;


namespace MiauPet.API.Models;

[Table("Categoria")]
public class Categoria
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    [Required(ErrorMessage = "O Nome é obrigatório")]
    public string Nome { get; set; }

    [StringLength(300)]
    public string Foto { get; set; }

    [StringLength(26)]
    [Display(Name = "Cor (RGBA)")]
    public string Cor { get; set; } = "rgba(0,0,0,1)";

    // Relação com Produto
    public ICollection<Produto> Produtos { get; set; }
}
