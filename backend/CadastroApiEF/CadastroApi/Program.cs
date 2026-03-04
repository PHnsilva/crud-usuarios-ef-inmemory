using CadastroApi.Data;
using CadastroApi.Models;
using Microsoft.EntityFrameworkCore; // <-- necessário

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseInMemoryDatabase("CadastroDb"));

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    var email = "seuemail@exemplo.com".Trim().ToLowerInvariant();

    if (!db.Usuarios.Any(u => u.Email == email))
    {
        db.Usuarios.Add(new Usuario
        {
            Nome = "SEU NOME REAL AQUI",
            Email = email,
            Senha = "Senha123!",
            CodigoPessoa = "SEU-CODIGO-REAL-AQUI",
            LembreteSenha = "dica qualquer",
            Idade = 18,
            Sexo = "M"
        });

        db.SaveChanges();
    }
}

app.Run();