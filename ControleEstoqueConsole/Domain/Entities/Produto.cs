namespace ControleEstoqueConsole.Domain.Entities;
public class Produto
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public int Estoque { get; set; }
    public decimal Preco { get; set; }

    public bool RemoverEstoque(int quantidade)
    {
        if (quantidade < 0)
        {
            Console.WriteLine("Quantidade inválida para remover do estoque.");
            return false;
        }

        if (quantidade > Estoque)
        {
            Console.WriteLine($"Estoque insuficiente para o produto {Nome}.");
            return false;
        }

        Estoque -= quantidade;
        Console.WriteLine($"{quantidade} unidade(s) removida(s) do estoque do produto {Nome}");
        return true;
    }
}
