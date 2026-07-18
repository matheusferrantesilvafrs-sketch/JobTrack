using JobTracker.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

string? connectionString =
    builder.Configuration.GetConnectionString("DefaultConnection");

if (string.IsNullOrWhiteSpace(connectionString))
{
    throw new InvalidOperationException(
        "A ConnectionString 'DefaultConnection' não foi encontrada."
    );
}

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseMySql(
        connectionString,
        ServerVersion.AutoDetect(connectionString)
    );
});

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

app.MapGet("/dadoscad", async (AppDbContext banco) =>
{
    List<PostDados> cadastros = await banco.Cadastro
        .AsNoTracking()
        .ToListAsync();

    return Results.Ok(cadastros);
});

app.MapPost("/dadoscad", async (
    PostDados novoCadastro,
    AppDbContext banco) =>
{
    if (string.IsNullOrWhiteSpace(novoCadastro.Empresa))
    {
        return Results.BadRequest(
            new { mensagem = "O nome da empresa é obrigatório." }
        );
    }

    if (string.IsNullOrWhiteSpace(novoCadastro.Cargo))
    {
        return Results.BadRequest(
            new { mensagem = "O cargo é obrigatório." }
        );
    }

    if (string.IsNullOrWhiteSpace(novoCadastro.Descricoes))
    {
        return Results.BadRequest(
            new { mensagem = "A descrição é obrigatória." }
        );
    }

    if (novoCadastro.Data == default)
    {
        return Results.BadRequest(
            new { mensagem = "A data da candidatura é obrigatória." }
        );
    }

    banco.Cadastro.Add(novoCadastro);

    await banco.SaveChangesAsync();

    return Results.Created(
        $"/dadoscad/{novoCadastro.ID}",
        novoCadastro
    );
});

app.Run();