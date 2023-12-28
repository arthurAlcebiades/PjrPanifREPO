using System;
using System.Collections.Generic;

namespace PrjPanifMVC.Models;

public partial class TbCliente
{
    public int IdCliente { get; set; }

    public string NomeCliente { get; set; } = null!;

    public string CpfCnpj { get; set; } = null!;

    public string? TelefoneContatoCliente { get; set; }

    public string EnderecoCliente { get; set; } = null!;

    public string EnderecoBairro { get; set; } = null!;

    public string EnderecoCidade { get; set; } = null!;

    public long EnderecoCep { get; set; }

    public string EnderecoUf { get; set; } = null!;

    public string? EnderecoComplemento { get; set; }

    public virtual ICollection<TbPedido> TbPedidos { get; } = new List<TbPedido>();
}
