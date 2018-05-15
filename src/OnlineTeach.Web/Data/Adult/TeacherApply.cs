using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineTeach.Web.Data.Adult
{
    public class TeacherApply
    {
        [Key]
        public long Id { get; set; }
        public Guid userId { get; set; }
        public string Name { get; set; }
        public string RealName { get; set; }
        public string School { get; set; }
        public string ApplyReason { get; set; }
        public DateTime ApplyTime { get; set; } = DateTime.Now;
        public int ApplyCount { get; set; } = 0;
    }
}
