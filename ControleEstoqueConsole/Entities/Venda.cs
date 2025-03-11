namespace ControleEstoqueConsole.Entities;
public class Venda
{
    public int Id { get; set; } 
    public string Nome {  get; set; } = string.Empty;
    public int Quantidade {  get; set; }
    public DateTime Data { get; set; }
}
