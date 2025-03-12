using ControleEstoqueConsole.Domain.Entities;

namespace ControleEstoqueConsole.Repositories;
public class VendaRepository : IVendaRepository
{
    private readonly List<Venda> _venda = new();
    private int _proximoId = 1;
    public List<Venda> ObterHistorico()
    {
        return _venda;
    }

    public void RegistrarVenda(Venda venda)
    {
        venda.Id = _proximoId++;
        _venda.Add(venda);

        Console.WriteLine($"Venda registrada: {venda.Quantidade} unidade(s) de {venda.Nome} em {venda.Data:dd/MM/yyyy HH:mm}");
    }

}
