using ControleEstoqueConsole.Domain.Entities;

namespace ControleEstoqueConsole.Repositories;
public interface IVendaRepository
{
    void RegistrarVenda(Venda venda);
    List<Venda> ObterHistorico();
}
