# Constrole de Estoque Console
Esse é um sistema simples de controle de estoque e vendas, desenvolvido em **C#** para fins didáticos e aprendizado. A aplicação é executada no terminal(console) e simula operações
básicas de cadastro, controle de produtos e registro de vendas.

## Funcionalidades
- Cadastrar novos produtos no estoque
- Adicionar ou remover unidades de um produto no estoque
- Registrar vendas de produtos
- Consultar produtos disponíveis no estoque
- Consultar histórico de vendas realizadas
  
## 🚀 Tecnologias Utilizadas
- **C#**
- **.NET 8**
- Projeto de console (aplicação de terminal)
## 💻 Como executar o projeto

### 1. Pré-requisitos

- [Instalar o .NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)

### 2. Clonar o repositório

```bash
git clone git@github.com:benicio227/InventoryControl.git
```

### 3. Navegar até a pasta do projeto

```bash
cd ControleEstoqueConsole
```

### 4. Executar o projeto
```bash
dotnet run
```

🛠️ Estrutura do Projeto
```nginx
ControleEstoqueConsole
├── Domain
│   └── Entities
│       ├── Estoque.cs
│       ├── Produto.cs
│       └── Venda.cs
├── Repositories
│   ├── IProdutoRepository.cs
│   ├── IVendaRepository.cs
│   ├── ProdutoRepository.cs
│   └── VendaRepository.cs
├── Services
│   ├── ProdutoService.cs
│   └── VendaService.cs
└── Program.cs
```
📂 Explicação das Pastas

- Domain/Entities: Contém as entidades principais do sistema, como Produto, Estoque e Venda.
- Repositories: Interfaces e implementações dos repositórios de produtos e vendas, simulando um repositório de dados em memória.
- Services: Contém as regras de negócio (serviços), como ProdutoService e VendaService, responsáveis pela lógica das operações de estoque e vendas.
- Program.cs: Ponto de entrada da aplicação console, responsável pelo menu e interação com o usuário.

🔨 Possíveis Melhorias Futuras

- Implementar persistência com um banco de dados (ex: SQLite)
- Adicionar testes unitários com xUnit
- Melhorar a interface de usuário no console
- Criar interface gráfica (WinForms, WPF ou Web API)
