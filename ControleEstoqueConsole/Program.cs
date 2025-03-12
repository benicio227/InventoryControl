using ControleEstoqueConsole.Domain.Entities;
using ControleEstoqueConsole.Repositories;
using ControleEstoqueConsole.Services;

namespace ControleEstoqueConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var produtoRepository = new ProdutoRepository();
            var produtoService = new ProdutoService(produtoRepository);

            produtoService.CadastrarProduto("Notebook", 3500, 10);
            produtoService.CadastrarProduto("Mouse", 100, 50);

            produtoService.ListarProdutos();

            produtoService.VenderProduto(1, 2);
            produtoService.AdicionarEstoque(2, 10);

            produtoService.ListarProdutos();

            produtoService.RemoverProduto(2);

            produtoService.ListarProdutos();
        }
    }
}
