using System;
using System.Collections.Generic;

namespace Prj_JACV_DemoLoggerSerilogMVCApp.Models;

public partial class Country
{
    public int Id { get; set; }

    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Latitude { get; set; } = null!;

    public string Longitude { get; set; } = null!;

    public decimal Population { get; set; }

    public bool Active { get; set; }
}
