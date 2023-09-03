using System;
using System.Collections.Generic;

namespace Prj_JACV_Ejercicio_1.Model;

public partial class Stock
{
    public string StoreCode { get; set; } = null!;

    public int? ProductId { get; set; }

    public int? Quantity { get; set; }

    public virtual Product? Product { get; set; }
}
