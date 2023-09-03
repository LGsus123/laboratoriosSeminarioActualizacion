using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Prj_AMTH_DemoEFCodeToDB.Models
{
    public class Course
    {

        [Key]
        public int CourseId { get; set; }
        public string Name { get; set; }
        public string Section { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}
