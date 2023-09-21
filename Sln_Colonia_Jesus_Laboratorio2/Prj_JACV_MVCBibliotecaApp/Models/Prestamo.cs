using System;
using System.Collections.Generic;

namespace Prj_JACV_MVCBibliotecaApp.Models;

public partial class Prestamo
{
    public int IDPrestamo { get; set; }

    public string? ISBN { get; set; }

    public int? IDUsuario { get; set; }

    public DateTime? FechaPrestamo { get; set; }

    public DateTime? FechaDevolucion { get; set; }

    public virtual Usuario? IdusuarioNavigation { get; set; }

    public virtual Libro? IsbnNavigation { get; set; }
}
