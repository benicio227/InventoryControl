﻿namespace ControleEstoqueConsole.Entities;
public class Produto
{
    public int Id { get; set; } 
    public string Nome { get; set; } = string.Empty;
    public int Estoque {  get; set; }
    public decimal Preco {  get; set; }
}
