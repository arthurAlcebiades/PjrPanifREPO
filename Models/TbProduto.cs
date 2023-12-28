using System;
using System.Collections.Generic;

namespace PrjPanifMVC.Models;

public partial class TbProduto
{
    public int IdProduto { get; set; }

    public string NomeProduto { get; set; } = null!;

    public string Unidade { get; set; } = null!;

    public virtual ICollection<TbItemPedido> TbItemPedidos { get; } = new List<TbItemPedido>();
}
