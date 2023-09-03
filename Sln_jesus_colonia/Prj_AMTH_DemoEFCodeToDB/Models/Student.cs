using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Prj_AMTH_DemoEFCodeToDB.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int CurrentCourseId { get; set; }
        public Course Course { get; set; }
    }
}
