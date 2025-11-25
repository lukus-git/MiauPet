using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MiauPet.API.Models;

[Table("Produto")]
public class Produto
{
    [Key]
    public int Id { get; set; }

    [ForeignKey("Categoria")]
    [Display(Name = "Categoria")]
    public int CategoriaId { get; set; }

    public Categoria Categoria { get; set; }

    [StringLength(100)]
    [Required(ErrorMessage = "O Nome é obrigatório")]
    public string Nome { get; set; }

    [StringLength(3000)]
    [Display(Name = "Descrição")]
    public string Descricao { get; set; }

    [Display(Name = "Quantidade")]
    public int Qtde { get; set; }

    [Column(TypeName = "decimal(12,2)")]
    [Display(Name = "Valor de Custo")]
    public decimal ValorCusto { get; set; }

    [Column(TypeName = "decimal(12,2)")]
    [Display(Name = "Valor de Venda")]
    public decimal ValorVenda { get; set; }

    [Display(Name = "Destaque na Home?")]
    public bool Destaque { get; set; } = false;

    [StringLength(300)]
    public string Foto { get; set; }
}
