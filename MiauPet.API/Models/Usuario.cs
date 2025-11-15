using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;


namespace MiauPet.API.Models;

[Table("Usuario")]
public class Usuario : IdentityUser
{
    [StringLength(50)]
    [Required(ErrorMessage = "O Nome é obrigatório")]
    public string Nome { get; set; }

    [DataType(DataType.Date)]
    [Display(Name = "Data de Nascimento")]
    public DateTime DataNascimento { get; set; }

    [StringLength(300)]
    public string Foto { get; set; }
}
