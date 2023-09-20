using System;
using System.Collections.Generic;

namespace Prj_JACV_Ejercicio_3.Model;

public partial class Brand
{
    public int BrandId { get; set; }

    public string? BrandName { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
