using System.ComponentModel.DataAnnotations;

namespace Italo.Models;

public class Funcionario
{

    public Funcionario()
    {

        Id = Guid.NewGuid().ToString();

    }

    public Funcionario(string nome, string cpf)
    {
        Id = Guid.NewGuid().ToString();
        Nome = nome;
        Cpf = cpf;
    }

    public string Id { get; set; }

    [Required(ErrorMessage = "Este campo é obrigatório!")]
    public string? Nome { get; set; }

    [Required(ErrorMessage = "Este campo é obrigatório!")]
    [MaxLength(11, ErrorMessage = "Este campo tem o tamanho máximo de 11 caracteres!")]
    public string? Cpf { get; set; }
}