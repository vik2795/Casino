using System;
using System.Collections.Generic;

namespace CasinoProject.Models;

public partial class Play
{
    public int? PlayerId { get; set; }

    public int? GameId { get; set; }

    public int? Amount { get; set; }
}
