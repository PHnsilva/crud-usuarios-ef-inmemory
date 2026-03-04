using System.ComponentModel.DataAnnotations;

namespace CadastroApi.Models;

public class Usuario
{
    // Chave = Email
    [Key]
    [Required]
    [EmailAddress]
    [StringLength(200)]
    public string Email { get; set; } = default!;

    [Required]
    [StringLength(120)]
    public string Nome { get; set; } = default!;

    [Required]
    [StringLength(200)]
    public string Senha { get; set; } = default!;

    [Required]
    [StringLength(60)]
    public string CodigoPessoa { get; set; } = default!;

    [StringLength(200)]
    public string? LembreteSenha { get; set; }

    [Range(0, 150)]
    public int Idade { get; set; }

    [Required]
    [StringLength(20)]
    public string Sexo { get; set; } = default!;
}