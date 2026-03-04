using System.ComponentModel.DataAnnotations;

namespace CadastroApi.Dtos;

public class UsuarioUpdateRequest
{
    [StringLength(120)]
    public string? Nome { get; set; }

    [StringLength(200)]
    public string? Senha { get; set; }

    [StringLength(60)]
    public string? CodigoPessoa { get; set; }

    [StringLength(200)]
    public string? LembreteSenha { get; set; }

    [Range(0, 150)]
    public int? Idade { get; set; }

    [StringLength(20)]
    public string? Sexo { get; set; }
}