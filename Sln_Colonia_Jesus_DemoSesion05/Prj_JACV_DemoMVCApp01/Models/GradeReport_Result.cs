using Microsoft.EntityFrameworkCore;

namespace Prj_JACV_DemoMVCApp01.Models
{
    [Keyless]
    public class GradeReport_Result
    {
        public string Code { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Course { get; set; }
        public int? Year { get; set; }
        public string Term { get; set; }
        public decimal Grade { get; set; }
    }
}
