namespace Italo.Models;

public class FolhaPag
{

    public FolhaPag()
    {
        Id = Guid.NewGuid().ToString();
    }

    public FolhaPag(int valor, int quantidade, int ano, int mes)
    {
        Id = Guid.NewGuid().ToString();
        Valor = valor;
        Quantidade = quantidade;
        Ano = ano;
        Mes = mes;
    }

    public string Id { get; set; }
    public int Valor { get; set; }
    public int Quantidade { get; set; }
    public int Ano { get; set; }
    public int Mes { get; set; }

}