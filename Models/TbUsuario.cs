using System;
using System.Collections.Generic;

namespace PrjPanifMVC.Models;

public partial class TbUsuario
{
    public int IdUsuario { get; set; }
    public string NomeUsuario { get; set; } = null!;

    public string SenhaUsuario { get; set; } = null!;

    public string Ativo { get; set; } = null!;
}
