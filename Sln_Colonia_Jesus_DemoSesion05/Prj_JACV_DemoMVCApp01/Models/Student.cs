using System;
using System.Collections.Generic;

namespace Prj_JACV_DemoMVCApp01.Models;

public partial class Student
{
    public int Id { get; set; }

    public string? Code { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public DateTime? BirthDate { get; set; }

    public bool Active { get; set; }

    public virtual ICollection<StudentCourse> StudentCourses { get; set; } = new List<StudentCourse>();
}
