using OnlineTeach.Web.Domains.AggrationRoot;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineTeach.Web.Data.Adult
{
    public class TeacherApply:AggrationRoot<long>
    {
        public string Name { get; set; }
        public string RealName { get; set; }
        public string School { get; set; }
        public string ApplyReason { get; set; }
        public DateTime ApplyTime { get; set; } = DateTime.Now;
        public int ApplyCount { get; set; } = 0;
    }
}
