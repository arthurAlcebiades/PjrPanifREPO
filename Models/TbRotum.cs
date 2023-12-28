using System;
using System.Collections.Generic;

namespace PrjPanifMVC.Models;

public partial class TbRotum
{
    public int IdRota { get; set; }

    public int IdMotorista { get; set; }

    public string Periodo { get; set; } = null!;

    public virtual TbMotoristum IdMotoristaNavigation { get; set; } = null!;

    public virtual ICollection<TbPedido> TbPedidos { get; } = new List<TbPedido>();
}
