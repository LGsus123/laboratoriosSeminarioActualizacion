using System;
using System.Collections.Generic;

namespace Prj_JACV_DemoMVCApp.Models;

public partial class Grade
{
    public int Id { get; set; }

    public string StudentCourseId { get; set; } = null!;

    public decimal Grade1 { get; set; }

    public DateTime InsertedDate { get; set; }

    public virtual StudentCourse StudentCourse { get; set; } = null!;
}
