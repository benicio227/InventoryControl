using ControleEstoqueConsole.Repositories;
using ControleEstoqueConsole.Services;

namespace ControleEstoqueConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var produtoRepository = new ProdutoRepository();
            var vendaRepository = new VendaRepository();
            var produtoService = new ProdutoService(produtoRepository, vendaRepository);

            produtoService.CadastrarProduto("Notebook", 3500, 10);
            produtoService.CadastrarProduto("Mouse", 100, 50);

            produtoService.ListarProdutos();

            produtoService.VenderProduto(1, 2);
            produtoService.VenderProduto(2, 5);

            produtoService.ListarProdutos();

            produtoService.ListarHistorico();
        }
    }
}
