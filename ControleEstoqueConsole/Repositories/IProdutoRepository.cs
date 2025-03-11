using ControleEstoqueConsole.Domain.Entities;

namespace ControleEstoqueConsole.Repositories;
public interface IProdutoRepository
{
    Produto ObterPorId(int id);
    List<Produto> ObterTodos();
    void Adicionar(Produto produto);
    void Atualizar(Produto produto);
    void Remover(int id);
}
