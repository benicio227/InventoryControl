namespace ControleEstoqueConsole.Domain.Entities;
public class Estoque
{
    public List<Produto> Produtos { get; set; } = new List<Produto>();
    public List<Venda> HistoricoVendas { get; set; } = new List<Venda>();

    public void AdicionarProduto(Produto produto)
    {

        Produtos.Add(produto);
    }

    public void VenderProduto(Produto produto, int quantidade)
    {
        if (produto.Estoque < quantidade)
        {
            Console.WriteLine($"Estoque para o produto {produto.Nome} indisponível");
            return;
        }

        produto.Estoque -= quantidade;
        Console.WriteLine($"Venda realizada com sucesso! {quantidade} unidade(s) do produto {produto.Nome} vendida(s).");
    }

    public void ListarProdutos()
    {
        if (!Produtos.Any())
        {
            Console.WriteLine("Não há produtos cadastrados no estoque.");
            return;
        }

        Console.WriteLine("=== Produtos no Estoque ===");

        foreach (var item in Produtos)
        {
            Console.WriteLine($"ID: {item.Id} | Nome: {item.Nome} | Estoque: {item.Estoque}");
        }
    }

}
