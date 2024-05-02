using Italo.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>();

var app = builder.Build();

List<Funcionario> funcionario =
[
];

app.MapGet("/", () => "Prova Folha funcionário!");

//Post https://localhost:5031/funcionario/cadastrar

app.MapPost("/funcionario/cadastrar", ([FromBody] Funcionario funcionario,
    [FromServices] AppDbContext ctx) =>
{
    List<ValidationResult> erros = new List<ValidationResult>();
    if (!Validator.TryValidateObject(
        funcionario, new ValidationContext(funcionario), erros, true
    ))
    {
        return Results.BadRequest(erros);
    }

    Funcionario? funcionarioEncontrado = ctx.Funcionarios.FirstOrDefault
        (x => x.Nome == funcionario.Nome);
    if (funcionarioEncontrado is null)
    {
        //Adicionar o objeto dentro da tabela no banco de dados
        ctx.Funcionarios.Add(funcionario);
        ctx.SaveChanges();
        return Results.Created("", funcionario);
    }
    return Results.BadRequest("Já existe um funcionario com o mesmo nome");
});

// GET: http://localhost:5031/funcionario/listar
app.MapGet("/funcionario/listar", ([FromServices] AppDbContext ctx) =>
{
    if (ctx.Funcionarios.Any())
    {
        return Results.Ok(ctx.Funcionarios.ToList());
    }
    return Results.NotFound("Não existem Funcionarios cadastrados");
});

app.Run();

