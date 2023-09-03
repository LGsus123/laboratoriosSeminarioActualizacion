using System;
using System.Collections.Generic;

namespace Prj_AMTH_DemoEFDBToCode.Model;

public partial class Stock
{
    public string StoreCode { get; set; } = null!;

    public int? ProductId { get; set; }

    public int? Quantity { get; set; }

    public virtual Product? Product { get; set; }
}
