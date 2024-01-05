using System;
using System.Collections.Generic;

namespace PrjPanifMVC.Models;

public partial class TbPedido
{
    public int IdPedido { get; set; }

    public int IdCliente { get; set; }


    public int IdRota { get; set; }

    public string? Observacoes { get; set; }

    public DateTime? DataInicioRecorrencia { get; set; }

    public DateTime? DataFinalRecorrencia { get; set; }

    public DateTime Data { get; set; }

    public virtual TbCliente IdClienteNavigation { get; set; } = null!;

    public virtual TbRotum IdRotaNavigation { get; set; } = null!;

    public virtual ICollection<TbItemPedido> TbItemPedidos { get; } = new List<TbItemPedido>();
}
