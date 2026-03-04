using CadastroApi.Data;
using CadastroApi.Dtos;
using CadastroApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; // <-- necessário p/ AnyAsync, ToListAsync etc

namespace CadastroApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsuariosController : ControllerBase
{
    private readonly AppDbContext _db;

    public UsuariosController(AppDbContext db) => _db = db;

    private static string NormEmail(string email) =>
        (email ?? "").Trim().ToLowerInvariant();

    [HttpPost]
    public async Task<ActionResult<Usuario>> Create([FromBody] UsuarioCreateRequest req)
    {
        var email = NormEmail(req.Email);

        var exists = await _db.Usuarios.AnyAsync(u => u.Email == email);
        if (exists) return Conflict(new { message = "E-mail já cadastrado." });

        var usuario = new Usuario
        {
            Nome = req.Nome.Trim(),
            Email = email,
            Senha = req.Senha,
            CodigoPessoa = req.CodigoPessoa.Trim(),
            LembreteSenha = req.LembreteSenha,
            Idade = req.Idade,
            Sexo = req.Sexo.Trim()
        };

        _db.Usuarios.Add(usuario);
        await _db.SaveChangesAsync();

        return CreatedAtAction(nameof(GetByEmail), new { email = usuario.Email }, usuario);
    }

    [HttpGet]
    public async Task<ActionResult<List<Usuario>>> GetAll()
    {
        var list = await _db.Usuarios
            .OrderBy(u => u.Nome)
            .ToListAsync();

        return Ok(list);
    }

    [HttpGet("{email}")]
    public async Task<ActionResult<Usuario>> GetByEmail([FromRoute] string email)
    {
        var key = NormEmail(email);

        // Agora funciona pq Usuarios é DbSet
        var usuario = await _db.Usuarios.FindAsync(key);

        if (usuario is null) return NotFound(new { message = "Usuário não encontrado." });
        return Ok(usuario);
    }

    [HttpPut("{email}")]
    public async Task<ActionResult<Usuario>> Replace([FromRoute] string email, [FromBody] UsuarioCreateRequest req)
    {
        var key = NormEmail(email);
        var usuario = await _db.Usuarios.FindAsync(key);

        if (usuario is null) return NotFound(new { message = "Usuário não encontrado." });

        usuario.Nome = req.Nome.Trim();
        usuario.Senha = req.Senha;
        usuario.CodigoPessoa = req.CodigoPessoa.Trim();
        usuario.LembreteSenha = req.LembreteSenha;
        usuario.Idade = req.Idade;
        usuario.Sexo = req.Sexo.Trim();

        await _db.SaveChangesAsync();
        return Ok(usuario);
    }

    [HttpPatch("{email}")]
    public async Task<ActionResult<Usuario>> Patch([FromRoute] string email, [FromBody] UsuarioUpdateRequest req)
    {
        var key = NormEmail(email);
        var usuario = await _db.Usuarios.FindAsync(key);

        if (usuario is null) return NotFound(new { message = "Usuário não encontrado." });

        if (req.Nome is not null) usuario.Nome = req.Nome.Trim();
        if (req.Senha is not null) usuario.Senha = req.Senha;
        if (req.CodigoPessoa is not null) usuario.CodigoPessoa = req.CodigoPessoa.Trim();
        if (req.LembreteSenha is not null) usuario.LembreteSenha = req.LembreteSenha;
        if (req.Idade.HasValue) usuario.Idade = req.Idade.Value;
        if (req.Sexo is not null) usuario.Sexo = req.Sexo.Trim();

        await _db.SaveChangesAsync();
        return Ok(usuario);
    }

    [HttpDelete("{email}")]
    public async Task<IActionResult> Delete([FromRoute] string email)
    {
        var key = NormEmail(email);
        var usuario = await _db.Usuarios.FindAsync(key);

        if (usuario is null) return NotFound(new { message = "Usuário não encontrado." });

        _db.Usuarios.Remove(usuario);
        await _db.SaveChangesAsync();
        return NoContent();
    }
}