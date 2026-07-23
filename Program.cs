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

    if (string.IsNullOrWhiteSpace(novoCadastro.Plataforma))
    {
        return Results.BadRequest(
            new { mensagem = "A Plataforma é obrigatória." }
        );
    }

    if (string.IsNullOrWhiteSpace(novoCadastro.Link))
    {
        return Results.BadRequest(
            new { mensagem = "O Link é obrigatória." }
        );
    }

    if (string.IsNullOrWhiteSpace(novoCadastro.Status))
    {
        return Results.BadRequest(
            new { mensagem = "Os Status são obrigatórios." }
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

app.MapDelete("/dadoscad/{id:int}", async (
    int id,
    AppDbContext banco) =>
{
    PostDados? candidatura =
        await banco.Cadastro.FindAsync(id);

    if (candidatura is null)
    {
        return Results.NotFound(
            new
            {
                mensagem = "Candidatura não encontrada."
            }
        );
    }

    banco.Cadastro.Remove(candidatura);

    await banco.SaveChangesAsync();

    return Results.Ok(
        new
        {
            mensagem = "Candidatura excluída com sucesso."
        }
    );
});

app.MapPut("/dadoscad/{id:int}", async (
    int id,
    PostDados dadosAtualizados,
    AppDbContext banco) =>
{
    PostDados? candidatura =
        await banco.Cadastro
            .FirstOrDefaultAsync(cadastro =>
                cadastro.ID == id
            );

    if (candidatura is null)
    {
        return Results.NotFound(
            new
            {
                mensagem = "Candidatura não encontrada."
            }
        );
    }

    candidatura.Empresa =
        dadosAtualizados.Empresa;

    candidatura.Cargo =
        dadosAtualizados.Cargo;

    candidatura.Data =
        dadosAtualizados.Data;

    candidatura.Descricoes =
        dadosAtualizados.Descricoes;

    candidatura.Plataforma =
        dadosAtualizados.Plataforma;

    candidatura.Link =
        dadosAtualizados.Link;

    candidatura.Status =
        dadosAtualizados.Status;

    await banco.SaveChangesAsync();

    return Results.Ok(candidatura);
});

app.Run();