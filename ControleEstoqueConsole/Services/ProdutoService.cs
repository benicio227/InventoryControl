using ControleEstoqueConsole.Domain.Entities;
using ControleEstoqueConsole.Repositories;

namespace ControleEstoqueConsole.Services;
public class ProdutoService
{
    private readonly IProdutoRepository _produtoRepository;
    private readonly IVendaRepository _vendaRepository;
    public ProdutoService(IProdutoRepository produtoRepository, IVendaRepository vendaRepository)
    {
        _produtoRepository = produtoRepository;
        _vendaRepository = vendaRepository;
    }

    public void CadastrarProduto(string nome, decimal preco, int estoqueInicial)
    {
        var produto = new Produto
        {
            Nome = nome,
            Preco = preco,
            Estoque = estoqueInicial,
        };

        _produtoRepository.Adicionar(produto);
    }

    public void AdicionarEstoque(int produtoId, int quantidade)
    {
        var produto = _produtoRepository.ObterPorId(produtoId);
        if (produto is null)
        {
            Console.WriteLine("Produto não encontrado");
            return;
        }

        if (quantidade <= 0)
        {
            Console.WriteLine("Quantidade inválida para adicionar ao estoque.");
            return;
        }

        produto.Estoque += quantidade;
        Console.WriteLine($"{quantidade} unidade(s) adicionada(s) ao estoque do produto {produto.Nome}");
        _produtoRepository.Atualizar(produto);
    }

    public void VenderProduto(int produtoId, int quantidade)
    {
        var produto = _produtoRepository.ObterPorId(produtoId);
        if (produto is null)
        {
            Console.WriteLine("Produto não encontrado.");
            return;
        }

        if (produto.RemoverEstoque(quantidade))
        {
            _produtoRepository.Atualizar(produto);
            Console.WriteLine($"Venda de {quantidade} unidade(s) do produto {produto.Nome} realizada com sucesso!");

            var venda = new Venda
            {
                Nome = produto.Nome,
                Quantidade = quantidade,
                Data = DateTime.Now
            };

            _vendaRepository.RegistrarVenda(venda);

            Console.WriteLine($"Venda de {quantidade} unidade(s) do produto {produto.Nome} registrada com sucesso!");
        }
    }

    public void ListarProdutos()
    {
        var produtos = _produtoRepository.ObterTodos();
        if (!produtos.Any())
        {
            Console.WriteLine("Nenhum produtos cadastrado");
            return;
        }

        Console.WriteLine("=== Lista de Produtos ===");
        foreach (var produto in produtos)
        {
            Console.WriteLine($"ID: {produto.Id} | Nome: {produto.Nome} | Estoque: {produto.Estoque} | Preço: R$ {produto.Preco}");
        }
    }

    public void RemoverProduto(int produtoId)
    {
        _produtoRepository.Remover(produtoId);
    }

    public void ListarHistorico()
    {
        var vendas = _vendaRepository.ObterHistorico();

        if (!vendas.Any())
        {
            Console.WriteLine("Nenhuma venda registrada");
            return;
        }

        Console.WriteLine("=== Histórico de Vendas ===");
        foreach(var venda in vendas)
        {
            Console.WriteLine($"ID: {venda.Id} | Produto: {venda.Nome} | Quantidade: {venda.Quantidade} | " +
                          $"Data: {venda.Data:dd/MM/yyyy HH:mm}");
        }
    }

}
