using System;
using System.Collections.Generic;

namespace Prj_JACV_BooksIdentityCoreMVCApp.Models;

public partial class Libro
{
    public string Id { get; set; } = null!;

    public string? Isbn { get; set; }

    public string? Titulo { get; set; }

    public string? Autor { get; set; }

    public string? Temas { get; set; }

    public string? Editorial { get; set; }

    public DateTime? FechaCreacion { get; set; }
}
