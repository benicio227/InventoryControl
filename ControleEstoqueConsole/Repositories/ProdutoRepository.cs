using ControleEstoqueConsole.Domain.Entities;

namespace ControleEstoqueConsole.Repositories;
public class ProdutoRepository : IProdutoRepository
{
    private readonly List<Produto> _produtos = new();
    private int _proximoId = 1;
    public void Adicionar(Produto produto)
    {
        produto.Id = _proximoId++;
        _produtos.Add(produto);
        Console.WriteLine($"Produto {produto.Nome} adicionado com sucesso!");
    }

    public void Atualizar(Produto produto)
    {
        var index = _produtos.FindIndex(p => p.Id == produto.Id);
        if (index != -1)
        {
            _produtos[index] = produto;
            Console.WriteLine($"Produto {produto.Nome} atualizado com sucesso!");
        }
        else
        {
            Console.WriteLine("Produto não encontrado.");
        }
    }

    public Produto? ObterPorId(int id)
    {
        return _produtos.FirstOrDefault(p => p.Id == id);
    }

    public List<Produto> ObterTodos()
    {
        return _produtos;
    }

    public void Remover(int id)
    {
        var produto = ObterPorId(id);
        if (produto != null)
        {
            _produtos.Remove(produto);
            Console.WriteLine($"Produto {produto.Nome} removido com sucesso!");
        }
        else
        {
            Console.WriteLine("Produto não encontrado.");
        }
    }
}
