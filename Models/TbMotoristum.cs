using System;
using System.Collections.Generic;

namespace PrjPanifMVC.Models;

public partial class TbMotoristum
{
    public int IdMotorista { get; set; }

    public string NomeMotorista { get; set; } = null!;

    public virtual ICollection<TbRotum> TbRota { get; } = new List<TbRotum>();
}
