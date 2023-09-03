using System;
using System.Collections.Generic;

namespace Prj_JACV_Ejercicio_1.Model;

public partial class Category
{
    public int CategoryId { get; set; }

    public string? CategoryName { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
