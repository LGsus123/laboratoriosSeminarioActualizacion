using System;
using System.Collections.Generic;

namespace Prj_JACV_DemoMVCApp01.Models;

public partial class StudentCourse
{
    public string Id { get; set; } = null!;

    public int StudentId { get; set; }

    public int CourseId { get; set; }

    public int? Year { get; set; }

    public string? Term { get; set; }

    public bool Active { get; set; }

    public virtual Course Course { get; set; } = null!;

    public virtual ICollection<Grade> Grades { get; set; } = new List<Grade>();

    public virtual Student Student { get; set; } = null!;
}
