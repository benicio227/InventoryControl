using ControleEstoqueConsole.Entities;

namespace ControleEstoqueConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var estoque = new Estoque();

            var venda = new Venda();

            bool sair = false;

            while (!sair)
            {
                Console.Clear();
                Console.WriteLine("[1] Adicionar Produto");
                Console.WriteLine("[2] Vender Produto");
                Console.WriteLine("[3] Listar Produtos");
                Console.WriteLine("[4] Editar Produto");
                Console.WriteLine("[5] Remover Produto");
                Console.WriteLine("[6] Pesquisar Produto por Nome");
                Console.WriteLine("[7] Mostrar Valor Total em Estoque");
                Console.WriteLine("[8] Mostrar Histórico de Vendas");
                Console.WriteLine("[9] Repor Estoque de Produto");
                Console.WriteLine("[10] Produtos com Estoque Baixo");
                Console.WriteLine("[0] Sair");
                Console.Write("Escolha uma opção: ");

                string opcao = Console.ReadLine()!;

                switch (opcao)
                {
                    case "1":
                        Console.Clear();
                        AdicionarProduto(estoque);
                        break;
                    case "2":
                        Console.Clear();
                        VenderProduto(estoque);
                        break;
                    case "3":
                        Console.Clear();
                        estoque.ListarProdutos();
                        AguardarEnter();
                        break;
                    case "4":
                        Console.Clear();
                        EditarProduto(estoque);
                        break;
                    case "5":
                        Console.Clear();
                        RemoverProduto(estoque);
                        AguardarEnter();
                        break;
                    case "6":
                        Console.Clear();
                        PesquisarProdutoPorNome(estoque);
                        AguardarEnter();
                        break;
                    case "7":
                        Console.Clear();
                        CalcularValorTotalEstoque(estoque);
                        AguardarEnter();
                        break;
                    case "8":
                        Console.Clear();
                        MostrarHistoricoDeVendas(estoque);
                        AguardarEnter();
                        break;
                    case "9":
                        Console.Clear();
                        ReporEstoqueProduto(estoque);
                        AguardarEnter();
                        break;
                    case "10":
                        Console.Clear();
                        MostrarProdutosBaixoEstoque(estoque);
                        AguardarEnter();
                        break;
                    case "0":
                        sair = true;
                        break;
                    default:
                        Console.WriteLine("Opção inválida! Pressione Enter para tentar novamente.");
                        Console.ReadLine();
                        break;
                }
            }
        }

        static void AdicionarProduto(Estoque estoque)
        {
            var produto = new Produto();

            Console.Write("Digite o ID do Produto: ");
            produto.Id = int.Parse(Console.ReadLine()!);

            var produtoExistente = estoque.Produtos.FirstOrDefault(p => p.Id == produto.Id);

            if (produtoExistente is not null)
            {
                Console.WriteLine("Produto já cadastrado com o Id informado!");
                AguardarEnter();
                Console.ReadLine();
                return;
            }

            Console.Write("Digite o nome do Produto: ");
            produto.Nome = Console.ReadLine()!;

            if (string.IsNullOrWhiteSpace(produto.Nome))
            {
                Console.WriteLine("O nome do produto não pode ser vazio!");
                Console.ReadLine();
                return;
            }


            Console.Write("Digite a Quantidade em Estoque: ");
            produto.Estoque = int.Parse(Console.ReadLine()!);

            if (produto.Estoque > 100)
            {
                Console.WriteLine("Quantidade do Produto excedeu o limite permitido de 100 unidades!");
                AguardarEnter();
                Console.ReadLine();
                return;
            }

            Console.Write("Digite o Preço do Produto: ");
            produto.Preco = decimal.Parse(Console.ReadLine()!);

            if (produto.Preco <= 0)
            {
                Console.WriteLine("O preço do porduto deve ser maior que zero!");
                Console.ReadLine();
                return;
            }

            estoque.AdicionarProduto(produto);

            Console.WriteLine("Produto adicionado com sucesso!");
            AguardarEnter();
            Console.ReadLine();
        }

        static void VenderProduto(Estoque estoque)
        {
            Console.Write("Digite o ID do Produto que deseja vender: ");
            int id = int.Parse(Console.ReadLine()!);

            var produto = estoque.Produtos.FirstOrDefault(produto => produto.Id == id);

            if (produto is null)
            {
                Console.WriteLine("Produto não encontrado!");
                AguardarEnter();
                Console.ReadLine();
                return;
            }

            Console.Write("Digite a quantidade a ser vendida: ");
            int quantidade = int.Parse(Console.ReadLine()!);

            if (quantidade > produto.Estoque)
            {
                Console.WriteLine($"Quantidade indisponível! Estoque atual: {produto.Estoque}");
                AguardarEnter();
                Console.ReadLine();
                return;
            }

            decimal precoUnitario = produto.Preco;
            decimal precoTotal = quantidade * precoUnitario;
            decimal desconto = 0;

            if (quantidade > 10)
            {
                desconto = precoTotal * 0.10m;
                precoTotal -= desconto;
            }

            Console.WriteLine($"Venda realizada: {quantidade} unidades de {produto.Nome}");

            if (desconto > 0)
            {
                Console.WriteLine($"Desconto aplicado: {desconto:C}"); // {C} mostra como valor monetário
            }

            Console.WriteLine($"Valor total da venda: {precoTotal:C}");

            var produtoHistorico = new Venda()
            {
                Id = produto.Id,
                Nome = produto.Nome,
                Quantidade = quantidade,
                Data = DateTime.Now,
            };

            estoque.HistoricoVendas.Add(produtoHistorico);

            estoque.VenderProduto(produto, quantidade);

            AguardarEnter();
            Console.ReadLine();
        }

        static void EditarProduto(Estoque estoque)
        {
            var produto = new Produto();

            Console.Write("Digite o ID do Produto que deseja alterar: ");
            var id = int.Parse(Console.ReadLine()!);

            var produtoEncontrado = estoque.Produtos.FirstOrDefault(produto => produto.Id == id);

            if (produtoEncontrado is null)
            {
                Console.WriteLine("Produto não encontrado!");
                AguardarEnter();
                Console.ReadLine();
                return;
            }

            Console.Write("Digite o nome do Produto: ");
            produtoEncontrado.Nome = Console.ReadLine()!;

            Console.Write("Digite a Quantidade em Estoque: ");
            produtoEncontrado.Estoque = int.Parse(Console.ReadLine()!);

            Console.Write("Digite o Preço do Produto: ");
            produtoEncontrado.Preco = decimal.Parse(Console.ReadLine()!);

            Console.WriteLine("Produto editado com sucesso!");
            AguardarEnter();
            Console.ReadLine();

        }

        static void RemoverProduto(Estoque estoque)
        {
            var produto = new Produto();

            Console.Write("Digite o ID do Produto que deseja alterar: ");
            var id = int.Parse(Console.ReadLine()!);

            var produtoEncontrado = estoque.Produtos.FirstOrDefault(produto => produto.Id == id);

            if (produtoEncontrado is null)
            {
                Console.WriteLine("Produto não encontrado!");
                AguardarEnter();
                Console.ReadLine();
                return;
            }

            estoque.Produtos.Remove(produtoEncontrado);
            Console.WriteLine("Produto removido com sucesso!");
            AguardarEnter();
            Console.ReadLine();
        }

        static void PesquisarProdutoPorNome(Estoque estoque)
        {
            Console.Write("Digite o nome do Produto que deseja buscar: ");

            var produtoPorNome = Console.ReadLine()!.ToLower();

            var produtosEncontradosPorNome = estoque.Produtos
                .Where(produto => produto.Nome.ToLower().Contains(produtoPorNome))
                .ToList();

            Console.Clear();

            if (produtosEncontradosPorNome.Any())
            {
                Console.WriteLine("Produtos encontrados:\n");

                foreach (var produto in produtosEncontradosPorNome)
                {
                    Console.WriteLine($"Id: {produto.Id}");
                    Console.WriteLine($"Nome: {produto.Nome}");
                    Console.WriteLine($"Estoque: {produto.Estoque}");
                    Console.WriteLine($"Preço: {produto.Preco:C}");
                    Console.WriteLine(new string('-', 30));
                }
            }
            else
            {
                Console.WriteLine("Nenhum produto encontrado com esse nome.");
            }

            AguardarEnter();
            Console.ReadLine();
        }

        static void CalcularValorTotalEstoque(Estoque estoque)
        {
            decimal totalValorDoEstoque = 0;

            foreach (var produto in estoque.Produtos)
            {
                totalValorDoEstoque += produto.Preco * produto.Estoque;
            }

            Console.WriteLine($"O valor total do estoque atual é: {totalValorDoEstoque:C}");
            AguardarEnter();
            Console.ReadLine();
        }

        static void MostrarHistoricoDeVendas(Estoque estoque)
        {
            Console.WriteLine("=== Histórico de Vendas ===");

            if (!estoque.HistoricoVendas.Any())
            {
                Console.WriteLine("Nenhuma venda realizada até o momento.");
            }

            foreach (var venda in estoque.HistoricoVendas)
            {
                Console.WriteLine($"Nome do Produto: {venda.Nome}");
                Console.WriteLine($"Quantidade do Produto: {venda.Quantidade}");
                Console.WriteLine($"Data do Produto: {venda.Data}");
                Console.WriteLine(new string('-', 30));
            }
        }

        static void ReporEstoqueProduto(Estoque estoque)
        {
            Console.WriteLine("Digite o ID do Produto que deseja repor o estoque ");
            var produtoId = int.Parse(Console.ReadLine()!);

            var produtoEncontrado = estoque.Produtos.FirstOrDefault(produto => produto.Id == produtoId);

            if (produtoEncontrado is null)
            {
                Console.WriteLine($"Produto com ID não {produtoId} não encontrado!");
                AguardarEnter();
                Console.ReadLine();
                return;
            }

            Console.WriteLine("Digite o valor repor o estoque do produto: ");
            var quantidadeParaRepor = int.Parse(Console.ReadLine()!);

            produtoEncontrado.Estoque += quantidadeParaRepor;
        }

        static void MostrarProdutosBaixoEstoque(Estoque estoque)
        {
            foreach (var produto in estoque.Produtos)
            {
                if (produto.Estoque < 5)
                {
                    Console.WriteLine($"Atenção! Produto {produto.Nome} está precisando de reposição");
                }
                else
                {
                    Console.WriteLine($"Produto não precisa de reposição");
                }
            }
        }

        static void AguardarEnter()
        {
            Console.WriteLine("\nPressione Enter para continuar...");
            Console.ReadLine();
        }
    }
}
