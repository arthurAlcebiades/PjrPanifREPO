using System;
using System.Collections.Generic;

namespace PrjPanifMVC.Models;

public partial class TbItemPedido
{
    public int IdItemPedido { get; set; }

    public int IdPedido { get; set; }

    public int IdProduto { get; set; }

    public int Quantidade { get; set; }

    public decimal ValorUnitario { get; set; }

    public decimal ValorTotal { get; set; }

    public decimal? ValorDesconto { get; set; }

    public virtual TbPedido IdPedidoNavigation { get; set; } = null!;

    public virtual TbProduto IdProdutoNavigation { get; set; } = null!;
}
